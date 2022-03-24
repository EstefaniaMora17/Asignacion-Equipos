using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionDatos;
using AsignacionEntities;
namespace AsignacionBusiness
{
   public class EstadoSimBusiness
    {
        ConnectionBusiness OconnectionBusiness = new ConnectionBusiness();
        System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
        public bool InsertarEstadoSim(EstadoSimEntities OestadoSimEntities)
        {
          
            parameters.Add("estadoSim", OestadoSimEntities.estadoSim);

            return OconnectionBusiness.Execute("InsertarEstadoSim", parameters);
        }
        public bool ActualizarEstadoSim(EstadoSimEntities OestadoSimEntities)
        {
            
            parameters.Add("idEstadoSim", OestadoSimEntities.idEstadoSim);
            parameters.Add("estadoSim", OestadoSimEntities.estadoSim);

            return OconnectionBusiness.Execute("ActualizarEstadoSim", parameters);
        }
        public List<EstadoSimEntities> ConsultarEstadoSim()
        {
            List<EstadoSimEntities> LisData = new List<EstadoSimEntities>();
            dynamic query = OconnectionBusiness.QueryToList("ConsultarEstadoSim");
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
        public EstadoSimEntities ConsultarEstadoSimIndv(int idEstadoSim)
        {
            EstadoSimEntities OestadoSimEntities = new EstadoSimEntities();
            parameters.Add("idEstadoSim", idEstadoSim);
            dynamic query = OconnectionBusiness.QueryFirstOrDefault("ConsultarEstadoSimIndv", parameters);
            if(query != null)
            {
                OestadoSimEntities = AsignarData(query);
            }
            return (OestadoSimEntities);
        }
        public EstadoSimEntities AsignarData(dynamic EstadoSim)
        {
            EstadoSimEntities OestadoSimEntities = new EstadoSimEntities();
            OestadoSimEntities.idEstadoSim = EstadoSim.idEstadoSim;
            OestadoSimEntities.estadoSim = EstadoSim.estadoSim;
            return OestadoSimEntities;
        }
    }
}

