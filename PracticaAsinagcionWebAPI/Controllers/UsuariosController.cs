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
        ExcepcionesBusiness oExcepcionesBusiness = new ExcepcionesBusiness();
        public bool estado { get; set; }
        public IHttpActionResult Post([FromBody] AsignacionEntities.UsuariosEntities OusuariosEntities)
        {
            try
            {
                UsuarioBusiness OusuarioBusiness = new UsuarioBusiness();
                estado = OusuarioBusiness.InsertarUsuarios(OusuariosEntities);
                if (estado)
                {
                    return Ok<string>("Registro con éxito");
                }
                else
                {
                    return InternalServerError(new Exception("Error registrando"));
                }
            }
            catch (Exception ex)
            {
                oExcepcionesBusiness.Excepcion(ex);
                return InternalServerError(new Exception("Error registrando"));
            }
        }
        
        [HttpPost]
        public IHttpActionResult ActualizarUsuarios([FromBody] AsignacionEntities.UsuariosEntities OusuariosEntities)
        {
            try
            {
                UsuarioBusiness OusuarioBusiness = new UsuarioBusiness();
               estado =  OusuarioBusiness.ActualizarUsuarios(OusuariosEntities);
                if (estado)
                {
                    return Ok<string>("Registro con éxito");
                }
                else
                {
                    return InternalServerError(new Exception("Error Actualizando"));
                }
            }
            catch (Exception ex)
            {
                oExcepcionesBusiness.Excepcion(ex);
                return InternalServerError(new Exception("Error Actualizando"));
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
