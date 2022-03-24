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
    public class EquipoController : ApiController
    {
        public bool InsertarEquipo([FromBody] AsignacionEntities.EquipoEntities OequipoEntities)
        {
            try
            {
                EquipoBusiness oEquipoBusiness = new EquipoBusiness();
               return oEquipoBusiness.InsertarEquipo(OequipoEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public bool ActualizarEquipo([FromBody] AsignacionEntities.EquipoEntities OequipoEntities)
        {
            try
            {
                EquipoBusiness oEquipoBusiness = new EquipoBusiness();
                return oEquipoBusiness.ActualizarEquipo(OequipoEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public List<EquipoEntities> consultarEquipos()
        {
            try
            {
                AsignacionBusiness.EquipoBusiness oEquipoBusiness = new AsignacionBusiness.EquipoBusiness();

                return oEquipoBusiness.consultarEquipo();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public EquipoEntities ConsultarEquipoIndv(string imei)
        {
            try
            {
                AsignacionBusiness.EquipoBusiness oEquipoBusiness = new AsignacionBusiness.EquipoBusiness();

                return oEquipoBusiness.ConsultarEquipoIndv(imei);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
