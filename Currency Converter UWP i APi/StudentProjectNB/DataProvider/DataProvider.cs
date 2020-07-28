using StudentProjectNB.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace StudentProjectNB.DataProvider
{
    class DataProviderC
    {
        public async Task<Rootobject> GetCurrencyDataO()
        {
            string URL = "https://api.frankfurter.app/latest";
            Rootobject dataO = new Rootobject();
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Rootobject>(result.Result);
                    dataO = data;
                }
            }
            return dataO;
        }

        public async Task<Dictionary<string,string>> GetCurrencyList()
        {
            string URL = "https://api.frankfurter.app/currencies";

            Dictionary<string, string> currencyListData = new Dictionary<string, string>();

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                    currencyListData = JsonConvert.DeserializeObject<Dictionary<string, string>>(result.Result);
                  
                }
            }
            return currencyListData;
        }

    }

}
