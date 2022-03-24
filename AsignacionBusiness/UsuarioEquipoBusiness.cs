using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionDatos;
using AsignacionEntities;
namespace AsignacionBusiness
{
    public class UsuarioEquipoBusiness
    {
        ConnectionBusiness OconnectionBusiness = new ConnectionBusiness();
        System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
        public bool InsertarUsuarioEquipo(UsuarioEquipoEntities OusuarioEquipoEntities)
        {
           
            parameters.Add("cedula", OusuarioEquipoEntities.cedula);
            parameters.Add("imei", OusuarioEquipoEntities.imei);
            parameters.Add("iccid", OusuarioEquipoEntities.iccid);
            parameters.Add("observacion", OusuarioEquipoEntities.observacion);
            parameters.Add("idEstadoEquipo", OusuarioEquipoEntities.idEstadoEquipo);
            parameters.Add("idEstadoSim", OusuarioEquipoEntities.idEstadoSim);
            parameters.Add("imagen", OusuarioEquipoEntities.imagen);
            parameters.Add("nombreImagen", OusuarioEquipoEntities.nombreImagen);
            parameters.Add("ContentType", OusuarioEquipoEntities.ContentType);

            return OconnectionBusiness.Execute("InsertarUsuarioEquipo", parameters);
        }
        public bool ActualizarUsuarioEquipo(UsuarioEquipoEntities OusuarioEquipoEntities)
        {
           
            parameters.Add("id", OusuarioEquipoEntities.id);
            parameters.Add("cedula", OusuarioEquipoEntities.cedula);
            parameters.Add("imei", OusuarioEquipoEntities.imei);
            parameters.Add("iccid", OusuarioEquipoEntities.iccid);
            parameters.Add("observacion", OusuarioEquipoEntities.observacion);
            parameters.Add("idEstadoEquipo", OusuarioEquipoEntities.idEstadoEquipo);
            parameters.Add("idEstadoSi", OusuarioEquipoEntities.idEstadoSim);

            return OconnectionBusiness.Execute("ActualizarUsuarioEquipo", parameters);
        }
        public List<UsuarioEquipoEntities> ConsultarUsuarioEquipo()
        {
            List<UsuarioEquipoEntities> LisData = new List<UsuarioEquipoEntities>();
            dynamic query = OconnectionBusiness.QueryToList("ConsultarUsuarioEquipo");
            foreach(var item  in query)
            {
                try
                {
                    LisData.Add(AsignarData(item));
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            }
            return LisData;
        }
        public UsuarioEquipoEntities ConsultarUsuarioEquipoIndv(int id)
        {
            UsuarioEquipoEntities OusuarioEquipoEntities = new UsuarioEquipoEntities();
            parameters.Add("id", id);
            dynamic query = OconnectionBusiness.QueryFirstOrDefault("ConsultarUsuarioEquipoIndv", parameters);
            if (query != null)
            {
                OusuarioEquipoEntities = AsignarData(query);

            }

            return OusuarioEquipoEntities;
            
        }
        public UsuarioEquipoEntities AsignarData(dynamic UsuarioEquipo)
        {
            UsuarioEquipoEntities OusuarioEquipoEntities = new UsuarioEquipoEntities();
            OusuarioEquipoEntities.id = UsuarioEquipo.id;
            OusuarioEquipoEntities.cedula = UsuarioEquipo.cedula;
            OusuarioEquipoEntities.nombre = UsuarioEquipo.nombre;
            OusuarioEquipoEntities.imei = UsuarioEquipo.imei;
            OusuarioEquipoEntities.iccid = UsuarioEquipo.iccid;
            OusuarioEquipoEntities.observacion = UsuarioEquipo.observacion;
            OusuarioEquipoEntities.idEstadoEquipo = UsuarioEquipo.idEstadoEquipo;
            OusuarioEquipoEntities.estadoEquipo = UsuarioEquipo.estadoEquipo;
            OusuarioEquipoEntities.idEstadoSim = UsuarioEquipo.idEstadoSim;
            OusuarioEquipoEntities.estadoSim = UsuarioEquipo.estadoSim;
            OusuarioEquipoEntities.imagen = UsuarioEquipo.imagen;
            OusuarioEquipoEntities.fechaUsuarioEquipo = UsuarioEquipo.fechaUsuarioEquipo;
            return OusuarioEquipoEntities;
        }
    }
}
