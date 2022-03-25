using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AsignacionBusiness;
using AsignacionEntities;
namespace PracticaAsinagcionWebAPI.Controllers
{
    public class ExcepcionesController : ApiController
    {
        public bool Post([FromBody] ExcepcionesEntities OexcepcionesEntities)
        {
            try
            {
                ExcepcionesBusiness OexcepcionesBusiness = new ExcepcionesBusiness();

                return OexcepcionesBusiness.insertarExcepciones(OexcepcionesEntities);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
