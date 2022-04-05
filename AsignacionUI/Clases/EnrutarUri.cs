using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AsignacionUI.Clases
{
    public class EnrutarUri
    {
        public bool PostApi(string metodo, Object datos)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44335");
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

        public void GetApi(string metodo)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync(string.Format("/api/{0}"));

                var result = responseTask.Result;

            }

        }
    }
}