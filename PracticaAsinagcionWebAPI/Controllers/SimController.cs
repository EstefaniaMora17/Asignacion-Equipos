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
    public class SimController : ApiController
    {
        ExcepcionesBusiness oExcepcionesBusiness = new ExcepcionesBusiness();
        public bool estado { get; set; }
        //captura la peticion que manda el cliente
        public IHttpActionResult Post([FromBody] AsignacionEntities.SimEntities OsimEntities)
        {
            try
            {
                SimBusiness OsimBusiness = new SimBusiness();
                estado = OsimBusiness.InsertarSim(OsimEntities);
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
        public IHttpActionResult ActualizarSim([FromBody] AsignacionEntities.SimEntities OsimEntities)
        {
            try
            {
                SimBusiness OsimBusiness = new SimBusiness();
                estado = OsimBusiness.ActualizarSim(OsimEntities);
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
        public List<SimEntities> ConsultarSim()
        {
            try
            {
                AsignacionBusiness.SimBusiness OsimBusiness = new AsignacionBusiness.SimBusiness();

                return OsimBusiness.ConsultarSim();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public SimEntities ConsultarSimIndv(string iccid)
        {
            try
            {
                AsignacionBusiness.SimBusiness OsimBusiness = new AsignacionBusiness.SimBusiness();

                return OsimBusiness.ConsultarSimIndv(iccid);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

