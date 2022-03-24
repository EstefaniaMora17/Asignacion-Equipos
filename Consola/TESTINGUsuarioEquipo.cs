using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionDatos;
using AsignacionEntities;
namespace Consola
{
    public class TESTINGUsuarioEquipo
    {
        static ConnectionBusiness OConnectionBusiness = new ConnectionBusiness();
        public static void InsertarUsuarioEquipo(UsuarioEquipoEntities OusuarioEquipoEntities)
        {
            System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
            parameters.Add("Cedula", OusuarioEquipoEntities.cedula);
            parameters.Add("iccid", OusuarioEquipoEntities.iccid);
            parameters.Add("imei", OusuarioEquipoEntities.imei);
            parameters.Add("observacion", OusuarioEquipoEntities.observacion);
            parameters.Add("idEstadoSim", OusuarioEquipoEntities.idEstadoSim);
            parameters.Add("idEstadoEquipo", OusuarioEquipoEntities.idEstadoEquipo);



            OConnectionBusiness.Execute("InsertarUsuarioEquipo", parameters);
        }
        public static void ActualizarUsuarioEquipo(UsuarioEquipoEntities OusuarioEquipoEntities)
        {
            System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
            parameters.Add("id", OusuarioEquipoEntities.id);
            parameters.Add("Cedula", OusuarioEquipoEntities.cedula);
            parameters.Add("iccid", OusuarioEquipoEntities.iccid);
            parameters.Add("imei", OusuarioEquipoEntities.imei);
            parameters.Add("observacion", OusuarioEquipoEntities.observacion);
            parameters.Add("idEstadoSim", OusuarioEquipoEntities.idEstadoSim);
            parameters.Add("idEstadoEquipo", OusuarioEquipoEntities.idEstadoEquipo);



            OConnectionBusiness.Execute("ActualizarUsuarioEquipo", parameters);
        }
    }
}
