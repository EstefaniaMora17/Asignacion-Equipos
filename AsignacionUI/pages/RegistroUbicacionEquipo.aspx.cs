using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AsignacionEntities;

namespace AsignacionUI.pages
{
    public partial class RegistroUbicacionEquipo : System.Web.UI.Page
    {
        excepciones Oexcepciones = new excepciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        if (User.IsInRole("Soporte") || User.IsInRole("Coordinador"))
                        {

                        }
                        else
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
                Oexcepciones.capturarExcepcion(mensajeExcepcion.Text);
                mensajeExcepcion.Text = (ex.Message);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarUbicacionEquipoIndv(int.Parse(txidubicacionEquipo.Text)) == false)
                {
                    UbicacionEquipoEntities OubicacionEquipoEntities = new UbicacionEquipoEntities();
                    OubicacionEquipoEntities.ubicacionEquipo = txtUbicacionEquipo.Text;

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/UbicacionEquipo/InsertarUbicacionEquipo", OubicacionEquipoEntities).Result;
                    //url del api guardar
                    lblMensaje.Text = "Registro Existe";
                }
                else
                {
                    lblMensaje.Text = "id Ubicacion Equipo Ya Existe";
                    txidubicacionEquipo.Text = "";
                    txtUbicacionEquipo.Text = "";
                }
            }
            catch (Exception ex)
            {
                Oexcepciones.capturarExcepcion(mensajeExcepcion.Text);
                mensajeExcepcion.Text = (ex.Message);
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

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/UbicacionEquipo/ActualizarUbicacionEquipo", OubicacionEquipoEntities).Result;
                    //url del api guardar

                    lblMensaje.Text = "Edicion Exitosa";
                }
                else
                {
                    lblMensaje.Text = "id Ubicacion Equipo No Registrado";
                    txidubicacionEquipo.Text = "";
                    txtUbicacionEquipo.Text = "";
                }
            }
            catch (Exception ex)
            {
                Oexcepciones.capturarExcepcion(mensajeExcepcion.Text);
                mensajeExcepcion.Text = (ex.Message);
            }

        }
    }
}