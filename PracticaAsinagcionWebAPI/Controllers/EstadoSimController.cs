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
    public class EstadoSimController : ApiController
    {
        ExcepcionesBusiness oExcepcionesBusiness = new ExcepcionesBusiness();
        public bool estado { get; set; }
        public IHttpActionResult Post([FromBody] AsignacionEntities.EstadoSimEntities OestadoSimEntities)
        {
            try
            {
                EstadoSimBusiness OestadoSimBusiness = new EstadoSimBusiness();
                estado = OestadoSimBusiness.InsertarEstadoSim(OestadoSimEntities);
                if (estado)
                {
                    return Ok<string>("Registro con éxito");
                }
                else
                {
                    return InternalServerError(new Exception("Error Registrando"));
                }

            }
            catch (Exception ex)
            {
                oExcepcionesBusiness.Excepcion(ex);
                return InternalServerError(new Exception("Error registrando"));
            }
        }
        [HttpPost]
        public IHttpActionResult ActaulizarEstadoSim([FromBody] AsignacionEntities.EstadoSimEntities OestadoSimEntities)
        {
            try
            {
                EstadoSimBusiness OestadoSimBusiness = new EstadoSimBusiness();
                estado = OestadoSimBusiness.ActualizarEstadoSim(OestadoSimEntities);
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
        public List<EstadoSimEntities> ConsultarEstadoSim()
        {
            try
            {
                AsignacionBusiness.EstadoSimBusiness OestadoSimBusiness = new AsignacionBusiness.EstadoSimBusiness();

                return OestadoSimBusiness.ConsultarEstadoSim();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
     
        public EstadoSimEntities ConsultarEstadoSimIndv(int idEstadoSim)
        {
            try
            {
                AsignacionBusiness.EstadoSimBusiness OestadoSimBusiness = new AsignacionBusiness.EstadoSimBusiness();

                return OestadoSimBusiness.ConsultarEstadoSimIndv(idEstadoSim);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

