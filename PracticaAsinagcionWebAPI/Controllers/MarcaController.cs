using System;
using System.Collections.Generic;
using System.Web.Http;
using AsignacionBusiness;
using AsignacionEntities;

namespace PracticaAsinagcionWebAPI.Controllers
{
    public class MarcaController : ApiController
    {
        public bool InsertarMarca([FromBody] AsignacionEntities.MarcaEntities OmarcaEntities)
        {
            try
            {
                MarcaBusiness OmarcaBusiness = new MarcaBusiness();
                return OmarcaBusiness.InsertarMarca(OmarcaEntities);

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public bool ActualizarMarca([FromBody] AsignacionEntities.MarcaEntities OmarcaEntities)
        {
            try
            {
                MarcaBusiness OmarcaBusiness = new MarcaBusiness();
                return OmarcaBusiness.ActualizarMarca(OmarcaEntities);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public List<MarcaEntities> ConsultarMarca()
        {
            try
            {
                AsignacionBusiness.MarcaBusiness OmarcaBusiness = new AsignacionBusiness.MarcaBusiness();

                return OmarcaBusiness.ConsultarMarca();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public MarcaEntities ConsultarMarcaIndv(int idMarca)
        {
            try
            {
                AsignacionBusiness.MarcaBusiness OmarcaBusiness = new AsignacionBusiness.MarcaBusiness();

                return OmarcaBusiness.ConsultarMarcaIndv(idMarca);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
