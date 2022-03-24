



using AsignacionDatos;
using AsignacionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignacionBusiness
{
    public class AreaBusiness
    {
        ConnectionBusiness OconnectionBusiness = new ConnectionBusiness();
        System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
        public bool InsertarArea(AreaEntities oAreaEntities)
        {
           
            parameters.Add("area", oAreaEntities.area);

           return OconnectionBusiness.Execute("InsertarArea", parameters);
        }
        public bool ActualizarArea(AreaEntities oAreaEntities)
        {
         
            parameters.Add("idArea", oAreaEntities.idArea);
            parameters.Add("area", oAreaEntities.area);

           return OconnectionBusiness.Execute("ActualizarArea", parameters);
        }
        public List<AreaEntities> ConsultarArea()
        {
            List<AreaEntities> LisData = new List<AreaEntities>();
            dynamic query = OconnectionBusiness.QueryToList("ConsultarArea");
            foreach (var item in query)
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
        public AreaEntities ConsultarAreaIndv(int idArea)
        {
            AreaEntities OareaEntities = new AreaEntities();
            parameters.Add("idArea", idArea);
            dynamic query = OconnectionBusiness.QueryFirstOrDefault("ConsultarAreaIndv", parameters);
            if (query != null)
            {
                OareaEntities = AsignarData(query);

            }

            return OareaEntities;

        }
        public AreaEntities AsignarData(dynamic area)
        {
            AreaEntities OareaEntities = new AreaEntities();
            OareaEntities.idArea = area.idArea;
            OareaEntities.area = area.area;
            return OareaEntities;
        }
    }
}
