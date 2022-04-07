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
    public partial class RegistroEstadoEquipo : System.Web.UI.Page
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
                            ConsultaListEstadoEquipo();
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
                lblMensaje.Text = "Ocurrio un error, por favor intenta nuevamente";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EstadoEquipoEntities OestadoEquipoEntities = new EstadoEquipoEntities();
                OestadoEquipoEntities.estadoEquipo = txtestadoEquipo.Text;

                if (OenrutarUri.PostApi("EstadoEquipo/Post", OestadoEquipoEntities))
                {
                    lblMensaje.Text = "Registro Guardado";
                }
                else
                {
                    throw new Exception(string.Format("Error registrando Estado Equipo. {0} ",
                     OestadoEquipoEntities.estadoEquipo));
                }

            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                lblMensaje.Text = "Error registrando, por favor intenta nuevamente";
            }
        }
        public bool ConsultarEstadoEquipoIndv(int idEstadoEquipo)
        {
            bool estado = false;
            var result = OenrutarUri.GetApi("/EstadoEquipo/ConsultarEstadoEquipoIndv?idEstadoEquipo=" + idEstadoEquipo + "");

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EstadoEquipoEntities>();

                    var estadoEquipo = readTask.Result;

                    if (estadoEquipo.idEstadoEquipo == idEstadoEquipo)
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
                if (ConsultarEstadoEquipoIndv(int.Parse(DllestadoEquipo.SelectedValue)) == true)
                {
                    EstadoEquipoEntities OestadoEquipoEntities = new EstadoEquipoEntities();
                    OestadoEquipoEntities.idEstadoEquipo = int.Parse(DllestadoEquipo.SelectedValue);
                    OestadoEquipoEntities.estadoEquipo = txtEstadoEquipoUpdate.Text;

                    if (OenrutarUri.PostApi("/EstadoEquipo/ActualizarEstadoEquipo", OestadoEquipoEntities))
                    {
                        lblMensaje.Text = "Edicion Exitosa";
                        ConsultaListEstadoEquipo();
                        txtEstadoEquipoUpdate.Text = string.Empty;
                    }
                    else
                    {
                        lblMensaje.Text = "Error en la edicion, por favor intenta nuevamente";
                    }

                }
                else
                {

                    lblMensaje.Text = "Id Estado Equipo no registrado";
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

            txtestadoEquipo.Text = "";
        }


        public void ConsultaListEstadoEquipo()
        {
            var result = OenrutarUri.GetApi("/EstadoEquipo/ConsultarEstadoEquipo");

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<EstadoEquipoEntities[]>();

                var estadoEquipo = readTask.Result;

                DllestadoEquipo.DataSource = estadoEquipo;
                DllestadoEquipo.DataTextField = "estadoEquipo";
                DllestadoEquipo.DataValueField = "idEstadoEquipo";
                DllestadoEquipo.DataBind();
                DllestadoEquipo.Items.Insert(0, new ListItem("Seleccione Estado Equipo", "0"));
                DllestadoEquipo.Dispose();
            }

        }
    }
}
