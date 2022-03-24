using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionDatos;
using AsignacionEntities;
namespace Consola
{
    public class TESTINGEquipo
    {
        static ConnectionBusiness OconnectionBusiness = new ConnectionBusiness();
       static  System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
        public static void InsertarEquipo(EquipoEntities OequipoEntities)
        {
         
            parameters.Add("imei", OequipoEntities.imei);
            parameters.Add("Referencia", OequipoEntities.Referencia);
            parameters.Add("rom", OequipoEntities.rom);
            parameters.Add("ram", OequipoEntities.ram);
            parameters.Add("bateria", OequipoEntities.bateria);
            parameters.Add("accesorios", OequipoEntities.accesorios);
            parameters.Add("observacion", OequipoEntities.observacion);
            parameters.Add("idEstadoEquipo", OequipoEntities.idEstadoEquipo);
            parameters.Add("idUbicacionEquipo", OequipoEntities.idubicacionEquipo);
            parameters.Add("idMarca", OequipoEntities.idMarca);

            OconnectionBusiness.Execute("InsertarEquipo", parameters);
        }
        public static void ActualizarEquipo(EquipoEntities OequipoEntities)
        {

            parameters.Add("imei", OequipoEntities.imei);
            parameters.Add("Referencia", OequipoEntities.Referencia);
            parameters.Add("rom", OequipoEntities.rom);
            parameters.Add("ram", OequipoEntities.ram);
            parameters.Add("bateria", OequipoEntities.bateria);
            parameters.Add("accesorios", OequipoEntities.accesorios);
            parameters.Add("observacion", OequipoEntities.observacion);
            parameters.Add("idEstadoEquipo", OequipoEntities.idEstadoEquipo);
            parameters.Add("idUbicacionEquipo", OequipoEntities.idubicacionEquipo);
            parameters.Add("idMarca", OequipoEntities.idMarca);

            OconnectionBusiness.Execute("ActualizarEquipo", parameters);
        }
        public EquipoEntities ConsultarEquipoIndv(string imei)
        {
            EquipoEntities OequipoEntities = new EquipoEntities();//
            parameters = new Dictionary<string, object>();
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
            return OeEquipoEntities;

        }
    }
}
