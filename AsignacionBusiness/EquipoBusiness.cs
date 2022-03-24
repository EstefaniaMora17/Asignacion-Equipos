using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionDatos;
using AsignacionEntities;
namespace AsignacionBusiness
{
    public class EquipoBusiness
    {
        ConnectionBusiness OconnectionBusiness = new ConnectionBusiness();
        System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
        public bool InsertarEquipo(EquipoEntities OequipoEntities)
        {
            //captura la informacion
            parameters.Add("imei", OequipoEntities.imei);                                                                                                                                       
            parameters.Add("Referencia", OequipoEntities.Referencia);
            parameters.Add("rom", OequipoEntities.rom);
            parameters.Add("ram", OequipoEntities.ram);
            parameters.Add("bateria", OequipoEntities.bateria);
            parameters.Add("accesorios", OequipoEntities.accesorios);
            parameters.Add("observacion", OequipoEntities.observacion);
            parameters.Add("idEstadoEquipo", OequipoEntities.idEstadoEquipo);
            parameters.Add("idubicacionEquipo", OequipoEntities.idubicacionEquipo);
            parameters.Add("idMarca", OequipoEntities.idMarca);
            parameters.Add("Precio", OequipoEntities.Precio);
            return OconnectionBusiness.Execute("InsertarEquipo", parameters);
        }
        public bool ActualizarEquipo(EquipoEntities OequipoEntities)
        {
            parameters.Add("imei", OequipoEntities.imei);
            parameters.Add("Referencia", OequipoEntities.Referencia);
            parameters.Add("rom", OequipoEntities.rom);
            parameters.Add("ram", OequipoEntities.ram);
            parameters.Add("bateria", OequipoEntities.bateria);
            parameters.Add("accesorios", OequipoEntities.accesorios);
            parameters.Add("observacion", OequipoEntities.observacion);
            parameters.Add("idEstadoEquipo", OequipoEntities.idEstadoEquipo);
            parameters.Add("idubicacionEquipo", OequipoEntities.idubicacionEquipo);
            parameters.Add("idMarca", OequipoEntities.idMarca);
            parameters.Add("Precio", OequipoEntities.Precio);
            return OconnectionBusiness.Execute("ActualizarEquipo", parameters);
        }
        public List<EquipoEntities> consultarEquipo()
        {
            List<EquipoEntities> LisData = new List<EquipoEntities>();
            dynamic query = OconnectionBusiness.QueryToList("consultarEquipo");
            foreach (var item in query)
            {
                try
                {
                    //SE LLAMA EL METODO 
                    LisData.Add(AsignarData(item));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return LisData;
        }
        public EquipoEntities ConsultarEquipoIndv(string imei)
        {
            EquipoEntities OequipoEntities = new EquipoEntities();
            parameters.Add("imei", imei);
            dynamic query = OconnectionBusiness.QueryFirstOrDefault("ConsultarEquipoIndv", parameters);
            if (query != null)
            {
                OequipoEntities = AsignarData(query);
            }
            return OequipoEntities;
        }
      
        public EquipoEntities AsignarData(dynamic Equipo)
        {

            EquipoEntities OeEquipoEntities = new EquipoEntities();

            OeEquipoEntities.imei = Equipo.imei;
            OeEquipoEntities.Referencia = Equipo.Referencia;
            OeEquipoEntities.rom = Equipo.rom;
            OeEquipoEntities.ram = Equipo.ram;
            OeEquipoEntities.bateria = Equipo.bateria;
            OeEquipoEntities.accesorios = Equipo.accesorios;
            OeEquipoEntities.observacion = Equipo.observacion;
            OeEquipoEntities.idEstadoEquipo = Equipo.idEstadoEquipo;
            OeEquipoEntities.estadoEquipo = Equipo.estadoEquipo;
            OeEquipoEntities.idubicacionEquipo = Equipo.idubicacionEquipo;
            OeEquipoEntities.ubicacionEquipo = Equipo.ubicacionEquipo;
            OeEquipoEntities.idMarca = Equipo.idMarca;
            OeEquipoEntities.marca = Equipo.marca;
            OeEquipoEntities.Precio = Equipo.Precio;
            OeEquipoEntities.FechaEquipo = Equipo.FechaEquipo;
            return OeEquipoEntities;

        }
    }
}
