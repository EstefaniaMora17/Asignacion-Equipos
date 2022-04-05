using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            parameters.Add("excepciones", OexcepcionesEntities.excepciones);

            return OconnectionBusiness.Execute("insertarExcepciones", parameters);
        }

        public void Excepcion(Exception exception)
        {
            try
            {
               parameters.Add("excepciones", string.Concat(exception.Message, exception.InnerException, exception.StackTrace));

                OconnectionBusiness.Execute("insertarExcepciones", parameters);
            }
            catch (Exception )
            {
                //guardar log en txt
            }

        }

    }
}
