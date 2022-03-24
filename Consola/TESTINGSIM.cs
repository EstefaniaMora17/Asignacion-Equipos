using AsignacionDatos;
using AsignacionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
   public class TESTINGSIM
    {
        static  ConnectionBusiness OConnectionBusiness = new ConnectionBusiness();
        public static void InsertarSim(SimEntities OsimEntities)
        {
            System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
            parameters.Add("iccid", OsimEntities.iccid);
            parameters.Add("min", OsimEntities.min);
            parameters.Add("planDatos", OsimEntities.planDatos);
            parameters.Add("idEstadoSim", OsimEntities.idEstadoSim);

            OConnectionBusiness.Execute("InsertarSim", parameters);
        }
        public static void ActualizarSim(SimEntities OsimEntities)
        {
            System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
            parameters.Add("iccid", OsimEntities.iccid);
            parameters.Add("min", OsimEntities.min);
            parameters.Add("planDatos", OsimEntities.planDatos);
            parameters.Add("idEstadoSim", OsimEntities.idEstadoSim);

            OConnectionBusiness.Execute("ActualizarSim", parameters);
        }
    }
}
