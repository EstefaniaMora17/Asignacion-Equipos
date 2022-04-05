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
        ExcepcionesBusiness oExcepcionesBusiness = new ExcepcionesBusiness();
        public bool estado { get; set; }
        public IHttpActionResult Post([FromBody] AsignacionEntities.CargoEntities OcargoEntities)
        {
            try
            {
                CargoBusiness OcargoBusiness = new CargoBusiness();
               estado = OcargoBusiness.InsertarCargo(OcargoEntities);
                if (estado)
                {
                    return Ok<string>("Registro con éxito");
                }
                else
                {
                    return InternalServerError(new Exception("Error registrando cargo"));
                }
            }
            catch (Exception ex)
            {
                oExcepcionesBusiness.Excepcion(ex);
                return InternalServerError(new Exception("Error registrando cargo"));
            }
        }
        [HttpPost]
        public IHttpActionResult ActualizarCargo([FromBody] AsignacionEntities.CargoEntities OcargoEntities)
        {
            try
            {
                CargoBusiness OcargoBusiness = new CargoBusiness();
               estado = OcargoBusiness.ActualizarCargo(OcargoEntities);
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

