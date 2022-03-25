using AsignacionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AsignacionUI
{
    public class excepciones
    {
       
        public void capturarExcepcion(string mensaje)
        {
            ExcepcionesEntities OexcepcionesEntities = new ExcepcionesEntities();
            OexcepcionesEntities.excepciones = mensaje;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44335");
            //url del proyecto webApi
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("/api/Excepciones/Post", OexcepcionesEntities).Result;

            
        }
    }
}