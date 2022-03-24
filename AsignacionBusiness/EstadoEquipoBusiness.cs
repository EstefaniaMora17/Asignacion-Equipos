using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionEntities;
using AsignacionDatos;
namespace AsignacionBusiness
{
    public class EstadoEquipoBusiness
    {
        ConnectionBusiness OconnectionBusiness = new ConnectionBusiness();
        System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
        public bool InsertarEstadoEquipo( EstadoEquipoEntities OestadoEquipoEntities)
        {
           
            parameters.Add("estadoEquipo", OestadoEquipoEntities.estadoEquipo);

            return OconnectionBusiness.Execute("InsertarEstadoEquipo", parameters);
        }
        public bool ActualizarEstadoEquipo(EstadoEquipoEntities OestadoEquipoEntities)
        {
           
            parameters.Add("idEstadoEquipo", OestadoEquipoEntities.idEstadoEquipo);
            parameters.Add("estadoEquipo", OestadoEquipoEntities.estadoEquipo);

            return OconnectionBusiness.Execute("ActualizarEstadoEquipo", parameters);
        }
        public List<EstadoEquipoEntities> ConsultarEstadoEquipo()
        {
            List<EstadoEquipoEntities> LisData = new List<EstadoEquipoEntities>();
            dynamic query = OconnectionBusiness.QueryToList("ConsultarEstadoEquipo");
            foreach (var item in query)
            {
                try
                {
                    LisData.Add(AsignarData(item));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return LisData;

        }
        public EstadoEquipoEntities ConsultarEstadoEquipoIndv(int idEstadoEquipo)
        {
            EstadoEquipoEntities OestadoEquipoEntities = new EstadoEquipoEntities();
            parameters.Add("idEstadoEquipo", idEstadoEquipo);
            dynamic query = OconnectionBusiness.QueryFirstOrDefault("ConsultarEstadoEquipoIndv", parameters);
            if(query != null){
                OestadoEquipoEntities = AsignarData(query);
            }
            return OestadoEquipoEntities;
        }
        public EstadoEquipoEntities AsignarData(dynamic EstadoEquipo)
        {
            EstadoEquipoEntities OestadoEquipoEntities = new EstadoEquipoEntities();
            OestadoEquipoEntities.idEstadoEquipo = EstadoEquipo.idEstadoEquipo;
            OestadoEquipoEntities.estadoEquipo = EstadoEquipo.estadoEquipo;
            return OestadoEquipoEntities;
        }
    }
}
