using System;
using System.Collections.Generic;
using System.Web.Http;
using AsignacionBusiness;
using AsignacionEntities;

namespace PracticaAsinagcionWebAPI.Controllers
{
    public class MarcaController : ApiController
    {
        ExcepcionesBusiness oExcepcionesBusiness = new ExcepcionesBusiness();
        public bool estado { get; set; }
        public IHttpActionResult Post([FromBody] AsignacionEntities.MarcaEntities OmarcaEntities)
        {
            try
            {
                MarcaBusiness OmarcaBusiness = new MarcaBusiness();
                estado = OmarcaBusiness.InsertarMarca(OmarcaEntities);
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
        public IHttpActionResult ActualizarMarca([FromBody] AsignacionEntities.MarcaEntities OmarcaEntities)
        {
            try
            {
                MarcaBusiness OmarcaBusiness = new MarcaBusiness();
                estado = OmarcaBusiness.ActualizarMarca(OmarcaEntities);
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
                return InternalServerError(new Exception("Error Actualizando"));
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
