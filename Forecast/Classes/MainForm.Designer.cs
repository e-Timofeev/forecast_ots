namespace Forecast
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Layuot = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btDeleteData = new System.Windows.Forms.Button();
            this.ForecastBt = new System.Windows.Forms.Button();
            this.editAlg = new System.Windows.Forms.CheckBox();
            this.covid = new System.Windows.Forms.TextBox();
            this.Diagram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tab = new System.Windows.Forms.TabControl();
            this.ForecastTab = new System.Windows.Forms.TabPage();
            this.ImportTab = new System.Windows.Forms.TabPage();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lUID = new System.Windows.Forms.Label();
            this.tbUID = new System.Windows.Forms.TextBox();
            this.FillDB = new System.Windows.Forms.Button();
            this.GetResponceHolidays = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dDateLoadOTS = new System.Windows.Forms.DateTimePicker();
            this.Import = new System.Windows.Forms.Button();
            this.GetResponce = new System.Windows.Forms.Button();
            this.lDateLoadOTS = new System.Windows.Forms.Label();
            this.dgvExcel = new System.Windows.Forms.DataGridView();
            this.Layuot.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Diagram)).BeginInit();
            this.tab.SuspendLayout();
            this.ForecastTab.SuspendLayout();
            this.ImportTab.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // Layuot
            // 
            this.Layuot.AutoSize = true;
            this.Layuot.ColumnCount = 2;
            this.Layuot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Layuot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Layuot.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.Layuot.Controls.Add(this.Diagram, 0, 0);
            this.Layuot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Layuot.Location = new System.Drawing.Point(3, 3);
            this.Layuot.Name = "Layuot";
            this.Layuot.RowCount = 1;
            this.Layuot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Layuot.Size = new System.Drawing.Size(977, 586);
            this.Layuot.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.monthCalendar2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.monthCalendar1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btDeleteData, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ForecastBt, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.editAlg, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.covid, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(626, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(348, 580);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar2.Location = new System.Drawing.Point(183, 49);
            this.monthCalendar2.MaxSelectionCount = 365;
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(177, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Период для прогноза";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableLayoutPanel1.SetColumnSpan(this.dgv, 2);
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(3, 217);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(342, 255);
            this.dgv.TabIndex = 1;
            this.dgv.VirtualMode = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Период для выборки";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar1.Location = new System.Drawing.Point(9, 49);
            this.monthCalendar1.MaxSelectionCount = 365;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            // 
            // btDeleteData
            // 
            this.btDeleteData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btDeleteData.Location = new System.Drawing.Point(3, 524);
            this.btDeleteData.Name = "btDeleteData";
            this.btDeleteData.Size = new System.Drawing.Size(168, 53);
            this.btDeleteData.TabIndex = 6;
            this.btDeleteData.Text = "Очистить данные";
            this.btDeleteData.UseVisualStyleBackColor = true;
            this.btDeleteData.Click += new System.EventHandler(this.BtDeleteData_Click);
            // 
            // ForecastBt
            // 
            this.ForecastBt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ForecastBt.Location = new System.Drawing.Point(177, 524);
            this.ForecastBt.Name = "ForecastBt";
            this.ForecastBt.Size = new System.Drawing.Size(168, 53);
            this.ForecastBt.TabIndex = 4;
            this.ForecastBt.Text = "Построить график по заданным фильтрам";
            this.ForecastBt.UseVisualStyleBackColor = true;
            this.ForecastBt.Click += new System.EventHandler(this.ForecastBt_Click);
            // 
            // editAlg
            // 
            this.editAlg.AutoSize = true;
            this.editAlg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editAlg.Location = new System.Drawing.Point(3, 478);
            this.editAlg.Name = "editAlg";
            this.editAlg.Size = new System.Drawing.Size(168, 40);
            this.editAlg.TabIndex = 4;
            this.editAlg.Text = "Включить алгоритм корректировки прогноза.";
            this.editAlg.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.editAlg.UseVisualStyleBackColor = true;
            this.editAlg.CheckedChanged += new System.EventHandler(this.EditAlg_CheckedChanged);
            // 
            // covid
            // 
            this.covid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.covid.Location = new System.Drawing.Point(177, 478);
            this.covid.Multiline = true;
            this.covid.Name = "covid";
            this.covid.Size = new System.Drawing.Size(168, 40);
            this.covid.TabIndex = 5;
            this.covid.Text = "0,315";
            this.covid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Diagram
            // 
            this.Diagram.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.FrameThin6;
            chartArea1.Name = "ChartArea1";
            this.Diagram.ChartAreas.Add(chartArea1);
            this.Diagram.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend";
            this.Diagram.Legends.Add(legend1);
            this.Diagram.Location = new System.Drawing.Point(3, 3);
            this.Diagram.Name = "Diagram";
            this.Diagram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.Diagram.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Blue};
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend";
            series1.Name = "OTS";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend";
            series2.Name = "Forecast";
            this.Diagram.Series.Add(series1);
            this.Diagram.Series.Add(series2);
            this.Diagram.Size = new System.Drawing.Size(617, 580);
            this.Diagram.TabIndex = 0;
            this.Diagram.Text = "Diagram";
            title1.Name = "Title1";
            title1.Text = "Соотношение OTS факт и прогноза";
            this.Diagram.Titles.Add(title1);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.ForecastTab);
            this.tab.Controls.Add(this.ImportTab);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(991, 618);
            this.tab.TabIndex = 1;
            // 
            // ForecastTab
            // 
            this.ForecastTab.Controls.Add(this.Layuot);
            this.ForecastTab.Location = new System.Drawing.Point(4, 22);
            this.ForecastTab.Name = "ForecastTab";
            this.ForecastTab.Padding = new System.Windows.Forms.Padding(3);
            this.ForecastTab.Size = new System.Drawing.Size(983, 592);
            this.ForecastTab.TabIndex = 0;
            this.ForecastTab.Text = "Прогнозные эксперименты";
            this.ForecastTab.UseVisualStyleBackColor = true;
            // 
            // ImportTab
            // 
            this.ImportTab.Controls.Add(this.groupBox);
            this.ImportTab.Controls.Add(this.dgvExcel);
            this.ImportTab.Location = new System.Drawing.Point(4, 22);
            this.ImportTab.Name = "ImportTab";
            this.ImportTab.Padding = new System.Windows.Forms.Padding(3);
            this.ImportTab.Size = new System.Drawing.Size(983, 592);
            this.ImportTab.TabIndex = 1;
            this.ImportTab.Text = "Импорт данных";
            this.ImportTab.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lUID);
            this.groupBox.Controls.Add(this.tbUID);
            this.groupBox.Controls.Add(this.FillDB);
            this.groupBox.Controls.Add(this.GetResponceHolidays);
            this.groupBox.Controls.Add(this.button1);
            this.groupBox.Controls.Add(this.dDateLoadOTS);
            this.groupBox.Controls.Add(this.Import);
            this.groupBox.Controls.Add(this.GetResponce);
            this.groupBox.Controls.Add(this.lDateLoadOTS);
            this.groupBox.Location = new System.Drawing.Point(6, 6);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(285, 297);
            this.groupBox.TabIndex = 14;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Параметры";
            // 
            // lUID
            // 
            this.lUID.AutoSize = true;
            this.lUID.Location = new System.Drawing.Point(11, 27);
            this.lUID.Name = "lUID";
            this.lUID.Size = new System.Drawing.Size(21, 13);
            this.lUID.TabIndex = 17;
            this.lUID.Text = "ID:";
            // 
            // tbUID
            // 
            this.tbUID.Location = new System.Drawing.Point(35, 24);
            this.tbUID.Name = "tbUID";
            this.tbUID.Size = new System.Drawing.Size(226, 20);
            this.tbUID.TabIndex = 16;
            this.tbUID.Text = "9dec36d1-9648-4c91-81e8-3bdbc193adee";
            // 
            // FillDB
            // 
            this.FillDB.Location = new System.Drawing.Point(11, 245);
            this.FillDB.Name = "FillDB";
            this.FillDB.Size = new System.Drawing.Size(250, 32);
            this.FillDB.TabIndex = 15;
            this.FillDB.Text = "Получить все показатели из базы\r\n";
            this.FillDB.UseVisualStyleBackColor = true;
            this.FillDB.Click += new System.EventHandler(this.FillDB_Click);
            // 
            // GetResponceHolidays
            // 
            this.GetResponceHolidays.Location = new System.Drawing.Point(11, 169);
            this.GetResponceHolidays.Name = "GetResponceHolidays";
            this.GetResponceHolidays.Size = new System.Drawing.Size(250, 32);
            this.GetResponceHolidays.TabIndex = 14;
            this.GetResponceHolidays.Text = "Получить по API OTS, тыс (вых-е)";
            this.GetResponceHolidays.UseVisualStyleBackColor = true;
            this.GetResponceHolidays.Click += new System.EventHandler(this.GetResponceHolidays_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Location = new System.Drawing.Point(11, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Экспорт в БД";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dDateLoadOTS
            // 
            this.dDateLoadOTS.Location = new System.Drawing.Point(141, 60);
            this.dDateLoadOTS.Name = "dDateLoadOTS";
            this.dDateLoadOTS.Size = new System.Drawing.Size(118, 20);
            this.dDateLoadOTS.TabIndex = 12;
            this.dDateLoadOTS.Value = new System.DateTime(2020, 4, 14, 14, 20, 16, 0);
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(11, 93);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(250, 32);
            this.Import.TabIndex = 3;
            this.Import.Text = "Импорт из экселя (для первичной загрузки)";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // GetResponce
            // 
            this.GetResponce.Location = new System.Drawing.Point(11, 131);
            this.GetResponce.Name = "GetResponce";
            this.GetResponce.Size = new System.Drawing.Size(250, 32);
            this.GetResponce.TabIndex = 5;
            this.GetResponce.Text = "Получить по API OTS, тыс (будни)";
            this.GetResponce.UseVisualStyleBackColor = true;
            this.GetResponce.Click += new System.EventHandler(this.GetResponce_Click);
            // 
            // lDateLoadOTS
            // 
            this.lDateLoadOTS.AutoSize = true;
            this.lDateLoadOTS.Location = new System.Drawing.Point(11, 64);
            this.lDateLoadOTS.Name = "lDateLoadOTS";
            this.lDateLoadOTS.Size = new System.Drawing.Size(127, 13);
            this.lDateLoadOTS.TabIndex = 13;
            this.lDateLoadOTS.Text = "Загрузить OTS за дату:";
            // 
            // dgvExcel
            // 
            this.dgvExcel.AllowUserToAddRows = false;
            this.dgvExcel.AllowUserToDeleteRows = false;
            this.dgvExcel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvExcel.Location = new System.Drawing.Point(297, 3);
            this.dgvExcel.Name = "dgvExcel";
            this.dgvExcel.ReadOnly = true;
            this.dgvExcel.Size = new System.Drawing.Size(683, 586);
            this.dgvExcel.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 618);
            this.Controls.Add(this.tab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прогнозирование алгоритмом ETS";
            this.Layuot.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Diagram)).EndInit();
            this.tab.ResumeLayout(false);
            this.ForecastTab.ResumeLayout(false);
            this.ForecastTab.PerformLayout();
            this.ImportTab.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Layuot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.CheckBox editAlg;
        private System.Windows.Forms.TextBox covid;
        private System.Windows.Forms.Button ForecastBt;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage ForecastTab;
        private System.Windows.Forms.TabPage ImportTab;
        private System.Windows.Forms.DataGridView dgvExcel;
        private System.Windows.Forms.Button btDeleteData;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataVisualization.Charting.Chart Diagram;
        private System.Windows.Forms.Button GetResponce;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DateTimePicker dDateLoadOTS;
        private System.Windows.Forms.Label lDateLoadOTS;
        private System.Windows.Forms.Button GetResponceHolidays;
        private System.Windows.Forms.Button FillDB;
        private System.Windows.Forms.Label lUID;
        private System.Windows.Forms.TextBox tbUID;
        //private System.Windows.Forms.Button Fill;
    }
}

