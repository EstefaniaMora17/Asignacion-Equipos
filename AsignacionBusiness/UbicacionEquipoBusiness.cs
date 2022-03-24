using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionDatos;
using AsignacionEntities;
namespace AsignacionBusiness
{
   public class UbicacionEquipoBusiness
    {
        ConnectionBusiness OConnectionBussines = new ConnectionBusiness();
        System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
        public bool InsertarUbicacionEquipo(UbicacionEquipoEntities OubicacionEquipoEntities)
        {
            parameters.Add("ubicacionEquipo", OubicacionEquipoEntities.ubicacionEquipo);

            return OConnectionBussines.Execute("InsertarUbicacionEquipo", parameters);

        }
        public bool ActualizarUbicacionEquipo(UbicacionEquipoEntities OubicacionEquipoEntities)
        {
           

            parameters.Add("idUbicacionEquipo", OubicacionEquipoEntities.idubicacionEquipo);
            parameters.Add("ubicacionEquipo", OubicacionEquipoEntities.ubicacionEquipo);

            return OConnectionBussines.Execute("ActualizarUbicacionEquipo", parameters);

        }
        public List<UbicacionEquipoEntities> ConsultarUbicacionEquipo()
        {
            List<UbicacionEquipoEntities> LisData = new List<UbicacionEquipoEntities>();
            dynamic query = OConnectionBussines.QueryToList("ConsultarUbicacionEquipo");
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
        public UbicacionEquipoEntities ConsultarUbicacionEquipoIndv(int idubicacionEquipo)
        {
            UbicacionEquipoEntities OubicacionEquipoEntities = new UbicacionEquipoEntities();
            parameters.Add("idubicacionEquipo", idubicacionEquipo);
            dynamic query = OConnectionBussines.QueryFirstOrDefault("ConsultarUbicacionEquipoIndv", parameters);
            if(query != null)
            {
                OubicacionEquipoEntities = AsignarData(query);
            }
            return OubicacionEquipoEntities;
        }
        public UbicacionEquipoEntities AsignarData(dynamic ubicacionEquipo)
        {
            UbicacionEquipoEntities OubicacionEquipoEntities = new UbicacionEquipoEntities();
            OubicacionEquipoEntities.idubicacionEquipo = ubicacionEquipo.idubicacionEquipo;
            OubicacionEquipoEntities.ubicacionEquipo = ubicacionEquipo.ubicacionEquipo;
            return OubicacionEquipoEntities;
        }
    }
}
