using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionDatos;
using AsignacionEntities;
namespace AsignacionBusiness
{
    public class UsuarioBusiness
    {
        ConnectionBusiness OconnectionBusiness = new ConnectionBusiness();
        System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
        public bool InsertarUsuarios(UsuariosEntities OusuariosEntities)
        {
      
            parameters.Add("cedula", OusuariosEntities.cedula);
            parameters.Add("nombre", OusuariosEntities.nombre);
            parameters.Add("apellido", OusuariosEntities.apellido);
            parameters.Add("telefono", OusuariosEntities.telefono);
            parameters.Add("idcargo", OusuariosEntities.idcargo);
            parameters.Add("idArea", OusuariosEntities.idArea);

            return OconnectionBusiness.Execute("InsertarUsuarios", parameters);

        }
        public bool ActualizarUsuarios(UsuariosEntities OusuariosEntities)
        {
          

            parameters.Add("cedula", OusuariosEntities.cedula);
            parameters.Add("nombre", OusuariosEntities.nombre);
            parameters.Add("apellido", OusuariosEntities.apellido);
            parameters.Add("telefono", OusuariosEntities.telefono);
            parameters.Add("idcargo", OusuariosEntities.idcargo);
            parameters.Add("idArea", OusuariosEntities.idArea);

                return OconnectionBusiness.Execute("ActualizarUsuarios", parameters);

        }
        public List<UsuariosEntities> consultarUsuario()
        {
            List<UsuariosEntities> LisData = new List<UsuariosEntities>();
            dynamic query = OconnectionBusiness.QueryToList("consultarUsuario");
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
        public UsuariosEntities ConsultarUsuarioIndv(string cedula)
        {
            UsuariosEntities OusuariosEntities = new UsuariosEntities ();
            parameters.Add("cedula", cedula);
            dynamic query = OconnectionBusiness.QueryFirstOrDefault("ConsultarUsuarioIndv",parameters);
            if(query != null)
            {
                OusuariosEntities = AsignarData(query);
            }
        

            return OusuariosEntities;
        }
        public UsuariosEntities AsignarData(dynamic Usuario)
        {
            UsuariosEntities OusuariosEntities = new UsuariosEntities();

            //se le asigna      <-- //tiene informacion    
            OusuariosEntities.cedula = Usuario.cedula;
            OusuariosEntities.nombre = Usuario.nombre;
            OusuariosEntities.apellido = Usuario.apellido;
            OusuariosEntities.telefono = Usuario.telefono;
            OusuariosEntities.idcargo = Usuario.idcargo;
            OusuariosEntities.cargo = Usuario.cargo;
            OusuariosEntities.idArea = Usuario.idArea;
            OusuariosEntities.area = Usuario.area;
            OusuariosEntities.FechaUsuario = Usuario.FechaUsuario;


            return OusuariosEntities;
        }
    }
}
