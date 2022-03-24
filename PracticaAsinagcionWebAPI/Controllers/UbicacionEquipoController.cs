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
        public bool InsertarUbicacionEquipo([FromBody] AsignacionEntities.UbicacionEquipoEntities OubicacionEquipoEntities)
        {
            try
            {
                UbicacionEquipoBusiness OubicacionEquipoBusiness = new UbicacionEquipoBusiness();
                return OubicacionEquipoBusiness.InsertarUbicacionEquipo(OubicacionEquipoEntities);

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public bool ActualizarUbicacionEquipo([FromBody] AsignacionEntities.UbicacionEquipoEntities OubicacionEquipoEntities)
        {
            try
            {
                UbicacionEquipoBusiness OubicacionEquipoBusiness = new UbicacionEquipoBusiness();
                return OubicacionEquipoBusiness.ActualizarUbicacionEquipo(OubicacionEquipoEntities);

            }
            catch (Exception)
            {
                throw;
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
