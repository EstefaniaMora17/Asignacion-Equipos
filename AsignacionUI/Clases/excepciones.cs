using AsignacionEntities;
using AsignacionUI.Clases;
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

           

        }
        public static void capturarExcepcion(Exception mensaje)
        {
            try
            {
                ExcepcionesEntities OexcepcionesEntities = new ExcepcionesEntities();
                OexcepcionesEntities.excepciones = string.Concat(mensaje.Message, mensaje.InnerException, mensaje.StackTrace);

                EnrutarUri OenrutarUri = new EnrutarUri();

                OenrutarUri.PostApi("Excepciones/Post", OexcepcionesEntities);
            }
            catch (Exception)
            {
                //guardar un log en un archivo txt
            }
        }
    }
}