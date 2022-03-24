using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AsignacionDatos;
using AsignacionEntities;
namespace AsignacionBusiness
{
    public class SimBusiness
    {
        ConnectionBusiness OConnectionBusiness = new ConnectionBusiness();
        System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
        public bool InsertarSim(SimEntities OsimEntities)
        {

            parameters.Add("iccid", OsimEntities.iccid);
            parameters.Add("min", OsimEntities.min);
            parameters.Add("planDatos", OsimEntities.planDatos);
            parameters.Add("idEstadoSim", OsimEntities.idEstadoSim);

            return OConnectionBusiness.Execute("InsertarSim", parameters);
        }
        public bool ActualizarSim(SimEntities OsimEntities)
        {

            parameters.Add("iccid", OsimEntities.iccid);
            parameters.Add("min", OsimEntities.min);
            parameters.Add("planDatos", OsimEntities.planDatos);
            parameters.Add("idEstadoSim", OsimEntities.idEstadoSim);

            return OConnectionBusiness.Execute("ActualizarSim", parameters);
        }
        public List<SimEntities> ConsultarSim()
        {
            List<SimEntities> LisData = new List<SimEntities>();
            dynamic query = OConnectionBusiness.QueryToList("ConsultarSim");
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
        public SimEntities ConsultarSimIndv(string iccid)
        {
            SimEntities OsimEntities = new SimEntities();
            parameters.Add("iccid", iccid);
            dynamic query = OConnectionBusiness.QueryFirstOrDefault("ConsultarSimIndv", parameters);
            if (query != null)
            {
                OsimEntities = AsignarData(query);

            }

            return OsimEntities;
        }
        public SimEntities AsignarData(dynamic Sim)
        {
            SimEntities OsimEntities = new SimEntities();

            OsimEntities.iccid = Sim.iccid;
            OsimEntities.min = Sim.min;
            OsimEntities.planDatos = Sim.planDatos;
            OsimEntities.idEstadoSim = Sim.idEstadoSim;
            OsimEntities.estadoSim = Sim.estadoSim;
            OsimEntities.fechaSim = Sim.fechaSim;
            return OsimEntities;

        }


    }
}
