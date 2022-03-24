using AsignacionBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AsignacionEntities;

namespace PracticaAsinagcionWebAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        public bool InsertarUsuarios([FromBody] AsignacionEntities.UsuariosEntities OusuariosEntities)
        {
            try
            {
                UsuarioBusiness OusuarioBusiness = new UsuarioBusiness();
                return OusuarioBusiness.InsertarUsuarios(OusuariosEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public bool ActualizarUsuarios([FromBody] AsignacionEntities.UsuariosEntities OusuariosEntities)
        {
            try
            {
                UsuarioBusiness OusuarioBusiness = new UsuarioBusiness();
               return  OusuarioBusiness.ActualizarUsuarios(OusuariosEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public List<UsuariosEntities> ConsultarUsuario()
        {
            try
            {
                AsignacionBusiness.UsuarioBusiness OusuarioBusiness = new AsignacionBusiness.UsuarioBusiness();

                return OusuarioBusiness.consultarUsuario();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public UsuariosEntities ConsultarUsuarioIndv(string cedula)
        {
            try
            {
                AsignacionBusiness.UsuarioBusiness oUsuarioBusiness = new AsignacionBusiness.UsuarioBusiness();

                return oUsuarioBusiness.ConsultarUsuarioIndv(cedula);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
