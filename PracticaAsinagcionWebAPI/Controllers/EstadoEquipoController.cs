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
    public class EstadoEquipoController : ApiController
    {
        public bool InsertarEstadoEquipo([FromBody] AsignacionEntities.EstadoEquipoEntities OestadoEquipoEntities)
        {
            try
            {
                EstadoEquipoBusiness OestadoEquipoBusiness = new EstadoEquipoBusiness();
               return OestadoEquipoBusiness.InsertarEstadoEquipo(OestadoEquipoEntities);

            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPost]
        public bool ActualizarEstadoEquipo([FromBody] AsignacionEntities.EstadoEquipoEntities OestadoEquipoEntities)
        {
            try
            {
                EstadoEquipoBusiness OestadoEquipoBusiness = new EstadoEquipoBusiness();
               return OestadoEquipoBusiness.ActualizarEstadoEquipo(OestadoEquipoEntities);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public List<EstadoEquipoEntities> ConsultarEstadoEquipo()
        {
            try
            {
                AsignacionBusiness.EstadoEquipoBusiness OestadoEquipoBusiness = new AsignacionBusiness.EstadoEquipoBusiness();

                return OestadoEquipoBusiness.ConsultarEstadoEquipo();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public EstadoEquipoEntities ConsultarEstadoEquipoIndv(int idEstadoEquipo)
        {
            try
            {
                AsignacionBusiness.EstadoEquipoBusiness OestadoEquipoBusiness = new AsignacionBusiness.EstadoEquipoBusiness();

                return OestadoEquipoBusiness.ConsultarEstadoEquipoIndv(idEstadoEquipo);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
