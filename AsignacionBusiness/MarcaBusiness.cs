using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionDatos;
using AsignacionEntities;
namespace AsignacionBusiness
{
   public class MarcaBusiness
    {
        ConnectionBusiness OconnectionBusiness = new ConnectionBusiness();
        System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
        public bool InsertarMarca(MarcaEntities OmarcaEntities)
        {
            parameters.Add("marca", OmarcaEntities.marca);

            return OconnectionBusiness.Execute("InsertarMarca", parameters);
        }
        public bool ActualizarMarca(MarcaEntities OmarcaEntities)
        {
            parameters.Add("idMarca", OmarcaEntities.idMarca);
            parameters.Add("marca", OmarcaEntities.marca);

            return OconnectionBusiness.Execute("ActualizarMarca", parameters);
        }
        public List<MarcaEntities> ConsultarMarca()
        {
            List<MarcaEntities> LisData = new List<MarcaEntities>();
            dynamic query = OconnectionBusiness.QueryToList("ConsultarMarca");
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
        public MarcaEntities ConsultarMarcaIndv(int idMarca)
        {
            MarcaEntities OmarcaEntities = new MarcaEntities();
            parameters.Add("idMarca", idMarca);
            dynamic query = OconnectionBusiness.QueryFirstOrDefault("ConsultarMarcaIndv", parameters);
            if(query != null)
            {
                OmarcaEntities = AsignarData(query);
            }
            return OmarcaEntities;    
        }
        public MarcaEntities AsignarData(dynamic marca)
        {
            MarcaEntities OmarcaEntities = new MarcaEntities();
            OmarcaEntities.idMarca = marca.idMarca;
            OmarcaEntities.marca = marca.marca;
            return OmarcaEntities;
        }
    }
}
