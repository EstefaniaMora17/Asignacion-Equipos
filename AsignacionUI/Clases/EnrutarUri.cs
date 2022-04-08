using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AsignacionUI.Clases
{
    public class EnrutarUri

    {
        string UrlApi = ConfigurationManager.AppSettings["UrlAPI"];
        public bool PostApi(string metodo, Object datos)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(UrlApi);
                //url del proyecto webApi
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync(string.Format("/api/{0}", metodo), datos).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                return false;
            }

        }

        public HttpResponseMessage GetApi(string metodo)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlApi);
                var responseTask = client.GetAsync(string.Format("/api/{0}", metodo));
                return responseTask.Result;

            }

        }
    }
}