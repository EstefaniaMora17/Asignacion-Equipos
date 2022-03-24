using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionEntities;
using AsignacionBusiness;
using AsignacionDatos;
using System.Net.Http;

namespace AsignacionBusiness
{
   public class CargoBusiness
    {
        ConnectionBusiness OconnectionBusiness = new ConnectionBusiness();
        System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
        public bool InsertarCargo(CargoEntities OcargoEntities)
        {
            parameters.Add("cargo", OcargoEntities.cargo);

            return OconnectionBusiness.Execute("Insertarcargo", parameters);
        }
        public bool ActualizarCargo(CargoEntities OcargoEntities)
        {
            parameters.Add("idcargo", OcargoEntities.idcargo);
            parameters.Add("cargo", OcargoEntities.cargo);

            return OconnectionBusiness.Execute("ActualizarCargo", parameters);
        }
        public List<CargoEntities> ConsultarCargo()
        {
            List<CargoEntities> LisData = new List<CargoEntities>();

            dynamic query = OconnectionBusiness.QueryToList("ConsultarCargo");
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
       public CargoEntities ConsultarCargoIndv(int idcargo)
        {
            CargoEntities OcargoEntities = new CargoEntities();
            parameters.Add("idcargo", idcargo);
            dynamic query = OconnectionBusiness.QueryFirstOrDefault("ConsultarCargoIndv", parameters);
            if(query != null)
            {

                OcargoEntities = AsignarData(query);
            }
            return OcargoEntities;
        }
        
        public CargoEntities AsignarData(dynamic cargo)
        {
            CargoEntities OcargoEntities = new CargoEntities();

            OcargoEntities.idcargo = cargo.idcargo;
            OcargoEntities.cargo = cargo.cargo;
            return OcargoEntities;
        }
    }
}
