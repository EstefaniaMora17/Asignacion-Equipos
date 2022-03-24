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
        public bool InsertarEstadoSim([FromBody] AsignacionEntities.EstadoSimEntities OestadoSimEntities)
        {
            try
            {
                EstadoSimBusiness OestadoSimBusiness = new EstadoSimBusiness();
                return OestadoSimBusiness.InsertarEstadoSim(OestadoSimEntities);

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public bool ActaulizarEstadoSim([FromBody] AsignacionEntities.EstadoSimEntities OestadoSimEntities)
        {
            try
            {
                EstadoSimBusiness OestadoSimBusiness = new EstadoSimBusiness();
                return OestadoSimBusiness.ActualizarEstadoSim(OestadoSimEntities);

            }
            catch (Exception)
            {
                throw;
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

