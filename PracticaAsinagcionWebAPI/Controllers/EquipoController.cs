using AsignacionBusiness;
using AsignacionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PracticaAsinagcionWebAPI.Controllers
{
    public class EquipoController : ApiController
    {
        ExcepcionesBusiness oExcepcionesBusiness = new ExcepcionesBusiness();
      
        public IHttpActionResult Post([FromBody] AsignacionEntities.EquipoEntities OequipoEntities)
        {
            try
            {
                EquipoBusiness oEquipoBusiness = new EquipoBusiness();
                bool Estado = oEquipoBusiness.InsertarEquipo(OequipoEntities);
                if (Estado)
                {
                    return Ok<string>("Registro con éxito");
                }
                else
                {
                    return InternalServerError(new Exception("Error Registrando equipo"));
                }
            }
            catch (Exception ex)
            {
                oExcepcionesBusiness.Excepcion(ex);
                return InternalServerError(new Exception("Error Registrando equipo"));
            }
        }
        [HttpPost]
        public IHttpActionResult ActualizarEquipo([FromBody] AsignacionEntities.EquipoEntities OequipoEntities)
        {
            try
            {
                EquipoBusiness oEquipoBusiness = new EquipoBusiness();
                bool Estado =  oEquipoBusiness.ActualizarEquipo(OequipoEntities);
                if (Estado)
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
                return InternalServerError(new Exception("Error registrando"));
            }
        }
        [HttpGet]
        public List<EquipoEntities> consultarEquipos()
        {
            try
            {
                AsignacionBusiness.EquipoBusiness oEquipoBusiness = new AsignacionBusiness.EquipoBusiness();

                return oEquipoBusiness.consultarEquipo();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public EquipoEntities ConsultarEquipoIndv(string imei)
        {
            try
            {
                AsignacionBusiness.EquipoBusiness oEquipoBusiness = new AsignacionBusiness.EquipoBusiness();

                return oEquipoBusiness.ConsultarEquipoIndv(imei);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
