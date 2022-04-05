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
    public class AreaController : ApiController
    {
        ExcepcionesBusiness oExcepcionesBusiness = new ExcepcionesBusiness();
        public bool estado { get; set; }
        public IHttpActionResult Post([FromBody] AsignacionEntities.AreaEntities oAreaEntities)
        {
            try
            {
                AreaBusiness oAreaBusiness = new AsignacionBusiness.AreaBusiness();

                estado = oAreaBusiness.InsertarArea(oAreaEntities);
                if(estado)
                {
                    return Ok<string>("Registro con éxito");
                }
                else
                {
                    return InternalServerError(new Exception("Error registrando area"));
                }

            }
            catch (Exception ex)
            {
                oExcepcionesBusiness.Excepcion(ex);
                return InternalServerError(new Exception("Error registrando area"));
            }
        }
        [HttpPost]
        public IHttpActionResult ActualizarArea([FromBody] AsignacionEntities.AreaEntities oAreaEntities)
        {
            try
            {
                AreaBusiness oAreaBusiness = new AsignacionBusiness.AreaBusiness();

                 estado = oAreaBusiness.ActualizarArea(oAreaEntities);
                if (estado)
                {
                    return Ok<string>("Registro con éxito");
                }
                else
                {
                    return InternalServerError(new Exception("Error actualizando"));
                }

            }
            catch (Exception ex)
            {
                oExcepcionesBusiness.Excepcion(ex);
                return InternalServerError(new Exception("Error actualizando"));
            }
        }
        [HttpGet]
        public List<AreaEntities> consultarArea()
        {
            try
            {
                AsignacionBusiness.AreaBusiness OareaBusiness = new AsignacionBusiness.AreaBusiness();

                return OareaBusiness.ConsultarArea();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public AreaEntities consultarAreaIndv(int idArea)
        {
            try
            {
                AsignacionBusiness.AreaBusiness OareaBusiness = new AsignacionBusiness.AreaBusiness();

                return OareaBusiness.ConsultarAreaIndv(idArea);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
