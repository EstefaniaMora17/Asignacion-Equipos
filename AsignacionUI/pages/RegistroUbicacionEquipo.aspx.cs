using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AsignacionEntities;
using AsignacionUI.Clases;

namespace AsignacionUI.pages
{
    public partial class RegistroUbicacionEquipo : System.Web.UI.Page
    {
        excepciones Oexcepciones = new excepciones();
        EnrutarUri OenrutarUri = new EnrutarUri();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        if (User.IsInRole("Usuarios Administrativos"))
                        {
                            Response.Redirect("../Users/NoAutorizado.aspx");
                        }
                       

                    }
                    else
                    {
                        Response.Redirect("/Users/Login.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                    UbicacionEquipoEntities OubicacionEquipoEntities = new UbicacionEquipoEntities();
                    OubicacionEquipoEntities.ubicacionEquipo = txtUbicacionEquipo.Text;

                    if (OenrutarUri.PostApi("UbicacionEquipo/Post", OubicacionEquipoEntities))
                    {
                        lblMensaje.Text = "Registro Guardados";
                    }
                    else
                    {
                        throw new Exception(string.Format("Error registrando Ubicacion Equipo. {0} ", OubicacionEquipoEntities.ubicacionEquipo));
                    }
                  
            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                lblMensaje.Text = "Error registrando, por favor intenta nuevamente";
            }

        }
        public bool ConsultarUbicacionEquipoIndv(int idubicacionEquipo)
        {
            bool estado = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/UbicacionEquipo/ConsultarUbicacionEquipoIndv?idubicacionEquipo=" + idubicacionEquipo + "");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UbicacionEquipoEntities>();

                    var ubicacionEquipo = readTask.Result;

                    if (ubicacionEquipo.idubicacionEquipo == idubicacionEquipo)
                    {

                        estado = true;
                    }

                }
                return estado;
            }
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarUbicacionEquipoIndv(int.Parse(txidubicacionEquipo.Text)) == true)
                {
                    UbicacionEquipoEntities OubicacionEquipoEntities = new UbicacionEquipoEntities();
                    OubicacionEquipoEntities.idubicacionEquipo = int.Parse(txidubicacionEquipo.Text);
                    OubicacionEquipoEntities.ubicacionEquipo = txtUbicacionEquipo.Text;

                    if (OenrutarUri.PostApi("UbicacionEquipo/Post", OubicacionEquipoEntities))
                    {
                        lblMensaje.Text = "Edicion Exitosa";
                    }
                    else
                    {
                        lblMensaje.Text = "Error en la edicion, por favor intenta nuevamente";
                    }

                }
                else
                {
                    lblMensaje.Text = "id Ubicacion Equipo No Registrado";
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                Oexcepciones.capturarExcepcion(mensajeExcepcion.Text);
                mensajeExcepcion.Text = (ex.Message);
            }

        }
        public void LimpiarCampos()
        {
            txidubicacionEquipo.Text = "";
            txtUbicacionEquipo.Text = "";
        }
    }
}