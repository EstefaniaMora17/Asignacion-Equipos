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
    public class UsuarioEquipoController : ApiController
    {
        ExcepcionesBusiness oExcepcionesBusiness = new ExcepcionesBusiness();
        public bool estado { get; set; }
        public IHttpActionResult Post([FromBody] AsignacionEntities.UsuarioEquipoEntities OusuarioEquipoEntities)
        {
            try
            {
                UsuarioEquipoBusiness OusuarioEquipoBusiness = new UsuarioEquipoBusiness();
                estado = OusuarioEquipoBusiness.InsertarUsuarioEquipo(OusuarioEquipoEntities);
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
        public IHttpActionResult ActualizarUsuarioEquipo([FromBody] AsignacionEntities.UsuarioEquipoEntities OusuarioEquipoEntities)
        {
            try
            {
                UsuarioEquipoBusiness OusuarioEquipoBusiness = new UsuarioEquipoBusiness();
              estado =   OusuarioEquipoBusiness.ActualizarUsuarioEquipo(OusuarioEquipoEntities);
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
        public List<UsuarioEquipoEntities> ConsultarUsuarioEquipo()
        {
            try
            {
                AsignacionBusiness.UsuarioEquipoBusiness OusuarioEquipoBusiness = new AsignacionBusiness.UsuarioEquipoBusiness();
               return OusuarioEquipoBusiness.ConsultarUsuarioEquipo();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public UsuarioEquipoEntities ConsultarUsuarioEquipoIndv(int id)
        {
            try
            {
                AsignacionBusiness.UsuarioEquipoBusiness OusuarioEquipoBusiness = new AsignacionBusiness.UsuarioEquipoBusiness();
                return OusuarioEquipoBusiness.ConsultarUsuarioEquipoIndv(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
