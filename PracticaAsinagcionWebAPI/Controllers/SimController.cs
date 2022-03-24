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
        //captura la peticion que manda el cliente
        public bool InsertarSim([FromBody] AsignacionEntities.SimEntities OsimEntities)
        {
            try
            {
                SimBusiness OsimBusiness = new SimBusiness();
                return OsimBusiness.InsertarSim(OsimEntities);

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public bool ActualizarSim([FromBody] AsignacionEntities.SimEntities OsimEntities)
        {
            try
            {
                SimBusiness OsimBusiness = new SimBusiness();
                return OsimBusiness.ActualizarSim(OsimEntities);

            }
            catch (Exception)
            {
                throw;
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

