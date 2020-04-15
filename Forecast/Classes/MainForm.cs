using Microsoft.Office.Interop.Excel;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Windows.Forms;

using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;

namespace Forecast
{
    public partial class Main : Form
    {
        #region Переменнные
        /// <summary>
        /// _y интервалы для прогноза
        /// _x прогнозные OTS
        /// OTS факт за период прогноза
        /// </summary>
        private double[] _y, _x, editY;

        /// <summary>
        /// Таблица для записи OTS в базу данных
        /// </summary>
        private static DataTable _table;

        /// <summary>
        /// Для масштабирования
        /// </summary>
        private const float CZoomScale = 4f;

        /// <summary>
        /// Для масштабирования
        /// </summary>
        private int FZoomLevel = 0;

        /// <summary>
        /// День недели для выбора метода API
        /// </summary>
        public enum DaysofWeek { Будние = 1, Выходные = 2 };

        /// <summary>
        /// Корневой каталог приложения
        /// </summary>
        private string s = System.Windows.Forms.Application.StartupPath;

        /// <summary>
        /// Строка подключения
        /// </summary>
        public readonly string stringConn = ConfigurationManager.ConnectionStrings["Forecast.Properties.Settings.ConnectionString"]?.ConnectionString;
        #endregion

        /// <summary>
        /// Точка входа
        /// </summary>
        public Main()
        {
            InitializeComponent();
            Diagram.MouseWheel += Diagram_MouseWheel;
        }

        #region Обработчики
        /// <summary>
        /// Импорт из екселя в datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Import_Click(object sender, EventArgs e)
        {
            // очистка перед вызовом
            dgvExcel.DataSource = null;
            dgvExcel.Columns.Clear();
            dgvExcel.Rows.Clear();

            OpenFileDialog opf = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                InitialDirectory = (s)
            };
            opf.ShowDialog();
            string filename = opf.FileName;
            if (filename != "")
            {
                #region Загрузка из Екселя в новый грид
                try
                {
                    FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
                    Excel.IExcelDataReader IEDR;
                    int fileformat = opf.SafeFileName.IndexOf(".xlsx");
                    if (fileformat > -1)
                    {
                        IEDR = Excel.ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        IEDR = Excel.ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    IEDR.IsFirstRowAsColumnNames = true;
                    DataSet ds = IEDR.AsDataSet();
                    System.Data.DataTable dt = ds.Tables[0];
                    dgvExcel.DataSource = dt;
                    IEDR.Close();
                    dgvExcel.Columns[1].DefaultCellStyle.Format = "0.000###";
                }
                catch (Exception load)
                {
                    MessageBox.Show(load.ToString(), "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Не выбран файл для загрузки.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            opf.RestoreDirectory = true;
        }

        /// <summary>
        /// Сохраняет даннные, импортированные из екселя, в базу данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCeConnection connect = new SqlCeConnection(stringConn))
                {
                    using (SqlCeCommand command = new SqlCeCommand())
                    {
                        command.Connection = connect;
                        command.CommandText = "INSERT INTO Indicators(PlayerID, OTS, EventTime) VALUES (@uid,@ots,@date)";

                        command.Parameters.Add(new SqlCeParameter("@uid", SqlDbType.UniqueIdentifier));
                        command.Parameters.Add(new SqlCeParameter("@ots", SqlDbType.Decimal));
                        command.Parameters.Add(new SqlCeParameter("@date", SqlDbType.DateTime));                      
                        if (dgvExcel.RowCount == 0)
                        {
                            MessageBox.Show("Не загружены данные для экспорта в базу", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        connect.Open();
                        for (int i = 0; i < dgvExcel.RowCount; i++)
                        {
                            command.Parameters["@uid"].Value = Guid.Parse(dgvExcel[0, i].Value.ToString());
                            command.Parameters["@ots"].Value = dgvExcel[1, i].Value;
                            command.Parameters["@date"].Value = Convert.ToDateTime(dgvExcel[2, i].Value);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Данные успешно экспортированы в базу данных.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка при загрузке строк в базу данных.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Прогнозирование временного ряда алгоритмом ETS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForecastBt_Click(object sender, EventArgs e)
        {
            Application xl = new Application();
            WorksheetFunction wsf = xl.WorksheetFunction;
            dgv.DataSource = GetData(monthCalendar1).DefaultView;
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Не загружены данные из базы", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            // если есть данные
            var _OTS = GetData(monthCalendar2);
            int ch = 0, ch1 = 1;
            int count = dgv.RowCount;
            // интервалы выборки
            double[] x = new double[count];
            // значения выборки
            double[] y = new double[count];
            _x = new double[24 * (monthCalendar2.SelectionRange.End.Subtract(monthCalendar2.SelectionRange.Start).Days + 1)];
            _y = new double[_x.Length];
            double[] otsFact = new double[_x.Length];

            for (int k = 0; k < count; k++)
            {
                x[k] = Convert.ToDouble(dgv.Rows[k].Index + 1);
                y[k] = Convert.ToDouble(dgv.Rows[k].Cells[1].Value);
                ch++;
            }
            // получаем интервалы в часах для прогнозных точек
            for (int i = 0; i < _x.Length; i++)
            {
                _x[i] = ch1;
                ch1++;
            }
            // запускаем алгоритм прогнозирования ETS
            for (int i = 0; i < _y.Length; i++)
            {
                _y[i] = Math.Round(wsf.Forecast_ETS(_x[i] + Convert.ToDouble(x.Length), y, x, 1, 1), 3);
                otsFact[i] = Convert.ToDouble(_OTS.Rows[i].Field<Decimal>("OTS"));
                Diagram.Series[0].Points.Add(otsFact[i]);
                Diagram.Series[1].Points.Add(_y[i]);
            }
        }

        /// <summary>
        /// Алгоритм корректировки прогнозных значений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditAlg_CheckedChanged(object sender, EventArgs e)
        {
            // сначала очистим прогнозные значения
            Diagram.Series[1].Points.Clear();
            int Days = monthCalendar2.SelectionRange.End.Subtract(monthCalendar2.SelectionRange.Start).Days + 1;
            int ch = 1;
            if (editAlg.Checked)
            {
                editY = new double[_y.Length];
                for (int i = 0; i < _y.Length; i++)
                {
                    if (_y[i] < 0)
                    {
                        _y[i] *= (-1);
                    }
                }
                for (int i = 0; i < _y.Length;)
                {
                    for (int j = i; j < 24 * ch; j++)
                    {
                        if (j < 8) editY[j] = _y[j] + (_y[j] * Convert.ToDouble(covid.Text));
                        else if (j > 8) editY[j] = _y[j] - (_y[j] * Convert.ToDouble(covid.Text));
                        Diagram.Series[1].Points.Add(editY[j]);
                    }
                    i = i + 24;
                    ch++;
                }
            }
        }

        /// <summary>
        /// Получение OTS по API в будний день
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetResponce_Click(object sender, EventArgs e)
        {
            //очистим скверну
            {
                dgvExcel.DataSource = null;
                dgvExcel.Columns.Clear();
                dgvExcel.Rows.Clear();
                _table?.Clear();
            }
            Root root = new Root();
            Root responce = root.FromJson(dDateLoadOTS.Value, (int)DaysofWeek.Будние);
            DateTime[] date = new DateTime[24];
            Properties.Settings settings = new Properties.Settings();
            for (int i = dDateLoadOTS.Value.Date.Hour; i < 24; i++)
            {
                date[i] = dDateLoadOTS.Value.Date.AddHours(i);
            }
            DataRow row;
            for (int i = 0; i < 24; i++)
            {
                row = AddInformation().NewRow();
                row[0] = tbUID?.Text;
                row[1] = responce.Data.DataData[0].Values[i];
                row[2] = date[i];
                AddInformation().Rows.Add(row);
            }
            dgvExcel.DataSource = AddInformation();
        }

        /// <summary>
        /// Получение OTS по API в выходной день
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetResponceHolidays_Click(object sender, EventArgs e)
        {
            //очистим скверну
            {
                dgvExcel.DataSource = null;
                dgvExcel.Columns.Clear();
                dgvExcel.Rows.Clear();
                _table?.Clear();
            }
            Root root = new Root();
            Root responce = root.FromJson(dDateLoadOTS.Value, (int)DaysofWeek.Выходные);
            DateTime[] date = new DateTime[24];
            Properties.Settings settings = new Properties.Settings();
            for (int i = dDateLoadOTS.Value.Date.Hour; i < 24; i++)
            {
                date[i] = dDateLoadOTS.Value.Date.AddHours(i);
            }
            DataRow row;
            for (int i = 0; i < 24; i++)
            {
                row = AddInformation().NewRow();
                row[0] = tbUID?.Text;
                row[1] = responce.Data.DataData[0].Values[i];
                row[2] = date[i];
                AddInformation().Rows.Add(row);
            }
            dgvExcel.DataSource = AddInformation();
        }

        /// <summary>
        /// Получение из базы всех данных по конструкции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillDB_Click(object sender, EventArgs e)
        {
            //очистим скверну
            {
                dgvExcel.DataSource = null;
                dgvExcel.Columns.Clear();
                dgvExcel.Rows.Clear();
                _table?.Clear();
            }
            dgvExcel.DataSource = Fill().DefaultView;
        }

        /// <summary>
        /// Очистка формы для последующих экспериментов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtDeleteData_Click(object sender, EventArgs e)
        {
            Diagram.Series[0].Points.Clear();
            Diagram.Series[1].Points.Clear();
            var today = DateTime.Today;
            monthCalendar1.SelectionStart = today;
            monthCalendar1.SelectionEnd = today;
            monthCalendar2.SelectionStart = today;
            monthCalendar2.SelectionEnd = today;
            dDateLoadOTS.Value = today;
            //табличка с данными по выборке
            dgv.DataSource = null;
            dgv.Columns.Clear();
            dgv.Rows.Clear();
            //для кучи табличка импорта из екселя
            dgvExcel.DataSource = null;
            dgvExcel.Columns.Clear();
            dgvExcel.Rows.Clear();
            _table?.Clear();
            editAlg.Checked = false;
        }
        #endregion

        #region Вспомогательные методы
        /// <summary>
        /// Таблица для склеивания загруженных данных OTS и временного ряда
        /// </summary>
        /// <returns></returns>
        public DataTable AddInformation()
        {
            var _colNames = new[] { "PlayerID", "OTS", "EventTime" };
            if (_table == null)
                CreateTable(_colNames);
            return _table;
        }

        /// <summary>
        /// Создает таблицу для сохранения в базу OTS, полученных через API
        /// </summary>
        /// <param name="_colNames"></param>
        private void CreateTable(IEnumerable<string> _colNames)
        {
            _table = new DataTable("Indicators");
            foreach (string colname in _colNames)
            {
                var column = new DataColumn(colname)
                {
                    DataType = Type.GetType("System.String")
                };
                _table.Columns.Add(column);
            }
        }

        /// <summary>
        /// Получение из локальной базы OTS за выбранный период 
        /// </summary>
        /// <returns></returns>
        public DataTable GetData(MonthCalendar calendar)
        {
            DataTable dataTable = new DataTable();
            using (SqlCeConnection connect = new SqlCeConnection(stringConn))
            {
                try
                {
                    SqlCeCommand command = new SqlCeCommand("Select EventTime, OTS from Indicators where (EventTime >= @DateBegin AND EventTime <= @DateEnd)", connect)
                    {
                        CommandType = CommandType.Text
                    };
                    command.Parameters.Add("@DateBegin", SqlDbType.DateTime).Value = calendar.SelectionStart;
                    command.Parameters.Add("@DateEnd", SqlDbType.DateTime).Value = calendar.SelectionEnd;
                    SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }
                catch (SqlException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
                return dataTable;
            }
        }

        /// <summary>
        /// Возвращает из базы всю таблицу
        /// </summary>
        /// <returns></returns>
        public DataTable Fill()
        {
            DataTable dataTable = new DataTable();
            using (SqlCeConnection connect = new SqlCeConnection(stringConn))
            {
                try
                {
                    SqlCeCommand command = new SqlCeCommand("Select * from Indicators", connect)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }
                catch (SqlException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
                return dataTable;
            }
        }

        #region Масштабирование диаграммы
        private void Diagram_MouseEnter(object sender, EventArgs e)
        {
            if (!Diagram.Focused)
                Diagram.Focus();
        }

        private void Diagram_MouseLeave(object sender, EventArgs e)
        {
            if (Diagram.Focused)
                Diagram.Parent.Focus();
        }

        private void Diagram_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                var xAxis = Diagram.ChartAreas[0].AxisX;
                double xMin = xAxis.ScaleView.ViewMinimum;
                double xMax = xAxis.ScaleView.ViewMaximum;
                double xPixelPos = xAxis.PixelPositionToValue(e.Location.X);

                if (e.Delta < 0 && FZoomLevel > 0)
                {
                    // Scrolled down, meaning zoom out
                    if (--FZoomLevel <= 0)
                    {
                        FZoomLevel = 0;
                        xAxis.ScaleView.ZoomReset();
                    }
                    else
                    {
                        double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) * CZoomScale, 0);
                        double xEndPos = Math.Min(xStartPos + (xMax - xMin) * CZoomScale, xAxis.Maximum);
                        xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                    }
                }
                else if (e.Delta > 0)
                {
                    // Scrolled up, meaning zoom in
                    double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) / CZoomScale, 0);
                    double xEndPos = Math.Min(xStartPos + (xMax - xMin) / CZoomScale, xAxis.Maximum);
                    xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                    FZoomLevel++;
                }
            }
            catch { }
        }
        #endregion
        #endregion
    }
}
