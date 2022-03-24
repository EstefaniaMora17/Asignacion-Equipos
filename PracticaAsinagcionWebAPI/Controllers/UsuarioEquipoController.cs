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
        public bool InsertarUsuarioEquipo([FromBody] AsignacionEntities.UsuarioEquipoEntities OusuarioEquipoEntities)
        {
            try
            {
                UsuarioEquipoBusiness OusuarioEquipoBusiness = new UsuarioEquipoBusiness();
                return OusuarioEquipoBusiness.InsertarUsuarioEquipo(OusuarioEquipoEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public bool ActualizarUsuarioEquipo([FromBody] AsignacionEntities.UsuarioEquipoEntities OusuarioEquipoEntities)
        {
            try
            {
                UsuarioEquipoBusiness OusuarioEquipoBusiness = new UsuarioEquipoBusiness();
              return   OusuarioEquipoBusiness.ActualizarUsuarioEquipo(OusuarioEquipoEntities);
            }
            catch (Exception)
            {
                throw;
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
