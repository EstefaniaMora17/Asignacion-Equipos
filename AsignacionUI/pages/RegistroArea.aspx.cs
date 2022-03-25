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
    public partial class RegistroArea : System.Web.UI.Page
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
                if (ConsultarAreaIndv(int.Parse(txtidArea.Text)) == false)
                {

                    AreaEntities OareaEntities = new AreaEntities();
                    OareaEntities.area = txtArea.Text;
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/Area/Post", OareaEntities).Result;
                    //url del api guardar
                    lblMensaje.Text = "Registro Guardados";
                }
                else
                {
                    lblMensaje.Text = "Id Area Ya Existe";
                    txtArea.Text = "";
                }
            }
            catch (Exception ex)
            {
                Oexcepciones.capturarExcepcion(mensajeExcepcion.Text);
                mensajeExcepcion.Text = (ex.Message);
            }
        }
        public bool ConsultarAreaIndv(int idArea)
        {
            bool estado = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Area/ConsultarAreaIndv?idArea=" + idArea + "");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AreaEntities>();

                    var area = readTask.Result;

                    if (area.idArea == idArea)
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
                if (ConsultarAreaIndv(int.Parse(txtidArea.Text))== true){

                    AreaEntities OareaEntities = new AreaEntities();
                    OareaEntities.idArea = int.Parse(txtidArea.Text);
                    OareaEntities.area = txtArea.Text;
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/Area/consultarAreaIndv", OareaEntities).Result;
                    //url del api guardar

                    lblMensaje.Text = "Edicion Exitosa";
                }
                else
                {
                    txtidArea.Text = "";
                    txtArea.Text = "";
                    lblMensaje.Text = "Id Area no registrado";
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
