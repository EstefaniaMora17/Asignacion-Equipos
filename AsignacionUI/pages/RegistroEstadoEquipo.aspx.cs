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
                EstadoEquipoEntities OestadoEquipoEntities = new EstadoEquipoEntities();
                OestadoEquipoEntities.estadoEquipo = txtestadoEquipo.Text;

                if (OenrutarUri.PostApi("EstadoEquipo/Post", OestadoEquipoEntities))
                {
                    lblMensaje.Text = "Registro Guardados";
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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/EstadoEquipo/ConsultarEstadoEquipoIndv?idEstadoEquipo=" + idEstadoEquipo + "");

                var result = responseTask.Result;
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
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarEstadoEquipoIndv(int.Parse(txtidEstadoEquipo.Text)) == true)
                {
                    EstadoEquipoEntities OestadoEquipoEntities = new EstadoEquipoEntities();
                    OestadoEquipoEntities.idEstadoEquipo = int.Parse(txtidEstadoEquipo.Text);
                    OestadoEquipoEntities.estadoEquipo = txtestadoEquipo.Text;

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/EstadoEquipo/ActualizarEstadoEquipo", OestadoEquipoEntities).Result;
                    //url del api guardar

                    lblMensaje.Text = "Edicion Exitosa";
                }
                else
                {
                    lblMensaje.Text = "id Estado Equipo No Registrado";
                    txtidEstadoEquipo.Text = "";
                    txtestadoEquipo.Text = "";
                }
            }
            catch(Exception ex)
            {
                Oexcepciones.capturarExcepcion(mensajeExcepcion.Text);
                mensajeExcepcion.Text = (ex.Message);
            }
          

        }
       
    }
}