using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionDatos;
using AsignacionEntities;
namespace Consola
{
    public class TESTINGUsuario
    {
        static ConnectionBusiness OconnectionBusiness = new ConnectionBusiness();

        public static void InsertarUsuarios(UsuariosEntities OusuariosEntities)
        {
            System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
            parameters.Add("Cedula", OusuariosEntities.cedula);
            parameters.Add("nombre", OusuariosEntities.nombre);
            parameters.Add("apellido", OusuariosEntities.apellido);
            parameters.Add("telefono", OusuariosEntities.telefono);
            parameters.Add("idArea", OusuariosEntities.idArea);
            parameters.Add("idcargo", OusuariosEntities.idcargo);


            OconnectionBusiness.Execute("InsertarUsuarios", parameters);
        }
        public static void ActualizarUsuarios(UsuariosEntities OusuariosEntities)
        {
            System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
            parameters.Add("Cedula", OusuariosEntities.cedula);
            parameters.Add("nombre", OusuariosEntities.nombre);
            parameters.Add("apellido", OusuariosEntities.apellido);
            parameters.Add("telefono", OusuariosEntities.telefono);
            parameters.Add("idArea", OusuariosEntities.idArea);
            parameters.Add("idcargo", OusuariosEntities.idcargo);


            OconnectionBusiness.Execute("ActualizarUsuarios", parameters);
        }
    }

}

