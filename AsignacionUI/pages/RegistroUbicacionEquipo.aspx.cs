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
                        else
                        {
                            ConsultaListUbiacionEquipo();
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
                mensajeExcepcion.Text = "Ocurrio un error, por favor intenta nuevamente";
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
                        lblMensaje.Text = "Registro Guardado";
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
            var result = OenrutarUri.GetApi("/UbicacionEquipo/ConsultarUbicacionEquipoIndv?idubicacionEquipo=" + idubicacionEquipo + "");
           
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
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarUbicacionEquipoIndv(int.Parse(DllUbiacionEquipo.SelectedValue)) == true)
                    {
                    UbicacionEquipoEntities OubicacionEquipoEntities = new UbicacionEquipoEntities();
                    OubicacionEquipoEntities.idubicacionEquipo = int.Parse(DllUbiacionEquipo.SelectedValue);
                    OubicacionEquipoEntities.ubicacionEquipo = txtUbiacionEquipoUpdate.Text;

                    if (OenrutarUri.PostApi("/UbicacionEquipo/ActualizarUbicacionEquipo", OubicacionEquipoEntities))
                    {
                        lblMensaje.Text = "Edicion Exitosa";
                        ConsultaListUbiacionEquipo();
                        txtUbiacionEquipoUpdate.Text = string.Empty;
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
                excepciones.capturarExcepcion(ex);
                mensajeExcepcion.Text = "Ocurrio un error, por favor intenta nuevamente";
            }

        }
        public void LimpiarCampos()
        {
            txtUbicacionEquipo.Text = "";
        }
        public void ConsultaListUbiacionEquipo()
        {
            var result = OenrutarUri.GetApi("/UbicacionEquipo/ConsultarUbicacionEquipo");

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<UbicacionEquipoEntities[]>();

                var UbiacionEquipo = readTask.Result;

                DllUbiacionEquipo.DataSource = UbiacionEquipo;
                DllUbiacionEquipo.DataTextField = "ubicacionEquipo";
                DllUbiacionEquipo.DataValueField = "idubicacionEquipo";
                DllUbiacionEquipo.DataBind();
                DllUbiacionEquipo.Items.Insert(0, new ListItem("Seleccione Ubicaicon Equipo", "0"));
                DllUbiacionEquipo.Dispose();
            }

        }
    }
}