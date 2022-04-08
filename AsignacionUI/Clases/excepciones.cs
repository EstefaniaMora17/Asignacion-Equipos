using AsignacionEntities;
using AsignacionUI.Clases;
using System;
using System.Collections.Generic;
using System.IO;
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

           

        }
        public static void capturarExcepcion(Exception ex)
        {
            try
            {
                ExcepcionesEntities OexcepcionesEntities = new ExcepcionesEntities();
                OexcepcionesEntities.excepciones = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);

                EnrutarUri OenrutarUri = new EnrutarUri();

                OenrutarUri.PostApi("Excepciones/Post", OexcepcionesEntities);
            }
            catch (Exception )
            {
                TextWriter mensaje = new StreamWriter("C:\\Users\\Estefania Mora\\Desktop\\nia\\Asignacion-Equipos\\AsignacionDatos\\log\\Test.txt");
                mensaje.WriteLine(string.Concat(ex.Message, ex.InnerException, ex.StackTrace));
                mensaje.Close();
            }
        }
    }
}