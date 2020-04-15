using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forecast
{
    /// <summary>
    /// Корневой класс
    /// </summary>
    public class Root
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        /// <summary>
        /// Ответ API для разбора
        /// </summary>
        /// <param name="date">Дата за которую получение данных по API</param>
        /// <param name="day">День недели для выбора метода API</param>
        /// <returns></returns>
        private async Task<string> JResponce(DateTime date, int day)
        {
            var client = new HttpClient();
            Properties.Settings settings = new Properties.Settings();
            
            string url = day == 1 ? @settings.OTS_days.Replace("startDate", date.ToString("yyyy-MM-dd")).Replace("endDate", date.ToString("yyyy-MM-dd")) : @settings.OTS_holi.Replace("startDate", date.ToString("yyyy-MM-dd")).Replace("endDate", date.ToString("yyyy-MM-dd"));   
            var task = client.GetAsync(url);
            return await task.Result.Content.ReadAsStringAsync();            
        }

        /// <summary>
        /// Получает десериализованный json
        /// </summary>
        /// <param name="dateLoadOts"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public Root FromJson(DateTime dateLoadOts, int day)
        {
            var json = JsonConvert.DeserializeObject<Root>(JResponce(dateLoadOts, day).Result);
            return json;
        }
    }

    /// <summary>
    /// Содержимое ответа API
    /// </summary>
    public partial class Data
    {
        [JsonProperty("data")]
        public List<Datum> DataData { get; set; }
    }

    /// <summary>
    /// Массив значений OTS
    /// </summary>
    public partial class Datum
    {
        [JsonProperty("values")]
        public List<double> Values { get; set; }
    }
}