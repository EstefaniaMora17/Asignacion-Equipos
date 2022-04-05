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
    public class EstadoEquipoController : ApiController
    {
        ExcepcionesBusiness oExcepcionesBusiness = new ExcepcionesBusiness();
        public bool estado { get; set; }
        public IHttpActionResult Post([FromBody] AsignacionEntities.EstadoEquipoEntities OestadoEquipoEntities)
        {
            try
            {
                EstadoEquipoBusiness OestadoEquipoBusiness = new EstadoEquipoBusiness();
               estado = OestadoEquipoBusiness.InsertarEstadoEquipo(OestadoEquipoEntities);
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
        public IHttpActionResult ActualizarEstadoEquipo([FromBody] AsignacionEntities.EstadoEquipoEntities OestadoEquipoEntities)
        {
            try
            {
                EstadoEquipoBusiness OestadoEquipoBusiness = new EstadoEquipoBusiness();
               estado = OestadoEquipoBusiness.ActualizarEstadoEquipo(OestadoEquipoEntities);
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
        public List<EstadoEquipoEntities> ConsultarEstadoEquipo()
        {
            try
            {
                AsignacionBusiness.EstadoEquipoBusiness OestadoEquipoBusiness = new AsignacionBusiness.EstadoEquipoBusiness();

                return OestadoEquipoBusiness.ConsultarEstadoEquipo();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public EstadoEquipoEntities ConsultarEstadoEquipoIndv(int idEstadoEquipo)
        {
            try
            {
                AsignacionBusiness.EstadoEquipoBusiness OestadoEquipoBusiness = new AsignacionBusiness.EstadoEquipoBusiness();

                return OestadoEquipoBusiness.ConsultarEstadoEquipoIndv(idEstadoEquipo);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
