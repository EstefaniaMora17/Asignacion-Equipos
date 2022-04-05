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
    public class UbicacionEquipoController : ApiController
    {
        ExcepcionesBusiness oExcepcionesBusiness = new ExcepcionesBusiness();
        public bool estado { get; set; }
        public IHttpActionResult Post([FromBody] AsignacionEntities.UbicacionEquipoEntities OubicacionEquipoEntities)
        {
            try
            {
                UbicacionEquipoBusiness OubicacionEquipoBusiness = new UbicacionEquipoBusiness();
                estado = OubicacionEquipoBusiness.InsertarUbicacionEquipo(OubicacionEquipoEntities);
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
        public IHttpActionResult ActualizarUbicacionEquipo([FromBody] AsignacionEntities.UbicacionEquipoEntities OubicacionEquipoEntities)
        {
            try
            {
                UbicacionEquipoBusiness OubicacionEquipoBusiness = new UbicacionEquipoBusiness();
                estado = OubicacionEquipoBusiness.ActualizarUbicacionEquipo(OubicacionEquipoEntities);
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
        public List<UbicacionEquipoEntities> ConsultarUbicacionEquipo()
        {
            try
            {
                AsignacionBusiness.UbicacionEquipoBusiness OubicacionEquipoBusiness = new AsignacionBusiness.UbicacionEquipoBusiness();

                return OubicacionEquipoBusiness.ConsultarUbicacionEquipo();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public UbicacionEquipoEntities ConsultarUbicacionEquipoIndv(int idubicacionEquipo)
        {
            try
            {
                AsignacionBusiness.UbicacionEquipoBusiness OubicacionEquipoBusiness = new AsignacionBusiness.UbicacionEquipoBusiness();

                return OubicacionEquipoBusiness.ConsultarUbicacionEquipoIndv(idubicacionEquipo);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
