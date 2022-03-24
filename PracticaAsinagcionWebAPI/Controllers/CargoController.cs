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
    public class CargoController : ApiController
    {
        public void InsertarCargo([FromBody] AsignacionEntities.CargoEntities OcargoEntities)
        {
            try
            {
                CargoBusiness OcargoBusiness = new CargoBusiness();
                OcargoBusiness.InsertarCargo(OcargoEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public void ActualizarCargo([FromBody] AsignacionEntities.CargoEntities OcargoEntities)
        {
            try
            {
                CargoBusiness OcargoBusiness = new CargoBusiness();
                OcargoBusiness.ActualizarCargo(OcargoEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public List<CargoEntities> ConsultarCargo()
        {
            try
            {
               CargoBusiness OcargoBusiness = new CargoBusiness();

                return OcargoBusiness.ConsultarCargo();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public CargoEntities ConsultarCargoIndv(int idcargo)
        {
            try
            {
                AsignacionBusiness.CargoBusiness OcargoBusiness = new AsignacionBusiness.CargoBusiness();

                return OcargoBusiness.ConsultarCargoIndv(idcargo);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

