using System;
using System.IO;
using AsignacionDatos;
using AsignacionEntities;
namespace AsignacionBusiness
{
    public class ExcepcionesBusiness
    {
        ConnectionBusiness OconnectionBusiness = new ConnectionBusiness();
        System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
      
        public bool insertarExcepciones(ExcepcionesEntities OexcepcionesEntities)
        {

            parameters.Add("excepcione", OexcepcionesEntities.excepciones);

            return OconnectionBusiness.Execute("insertarExcepcione", parameters);
        }

        public void Excepcion(Exception ex)
        {
            try
            {
               parameters.Add("excepciones", string.Concat(ex.Message, ex.InnerException, ex.StackTrace));

                OconnectionBusiness.Execute("insertarExcepciones", parameters);
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
