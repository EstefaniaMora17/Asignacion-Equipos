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
      
        public bool Post([FromBody] AsignacionEntities.AreaEntities oAreaEntities)
        {
            try
            {
                AreaBusiness oAreaBusiness = new AsignacionBusiness.AreaBusiness();

                return oAreaBusiness.InsertarArea(oAreaEntities);

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public bool ActualizarArea([FromBody] AsignacionEntities.AreaEntities oAreaEntities)
        {
            try
            {
                AreaBusiness oAreaBusiness = new AsignacionBusiness.AreaBusiness();

               return oAreaBusiness.ActualizarArea(oAreaEntities);

            }
            catch (Exception)
            {
                throw;
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
