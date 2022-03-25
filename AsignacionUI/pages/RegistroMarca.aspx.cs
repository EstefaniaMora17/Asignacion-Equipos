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
    public partial class RegistroMarca : System.Web.UI.Page
    {
        excepciones Oexcepciones = new excepciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (User.Identity.IsAuthenticated )
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
                if (ConsultarMarcaIndv(int.Parse(txtidMarca.Text)) == false)
                {
                    MarcaEntities OmarcaEntitites = new MarcaEntities();
                    OmarcaEntitites.marca = txtMarca.Text;


                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/Marca/InsertarMarca", OmarcaEntitites).Result;
                    //url del api guardar
                    lblMensaje.Text = "Registro Exitoso";
                }
                else
                {
                    lblMensaje.Text = "id Marca Ya Existe";
                    txtidMarca.Text = "";
                    txtMarca.Text = "";
                }
            }
            catch (Exception ex)
            {
                Oexcepciones.capturarExcepcion(mensajeExcepcion.Text);
                mensajeExcepcion.Text = (ex.Message);
            }
        }
        public bool ConsultarMarcaIndv(int idMarca)
        {
            bool estado = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Marca/ConsultarMarcaIndv?idMarca=" + idMarca + "");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<MarcaEntities>();

                    var marca = readTask.Result;

                    if (marca.idMarca == idMarca)
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
                if(ConsultarMarcaIndv(int.Parse(txtidMarca.Text)) == true)
                {
                    MarcaEntities OmarcaEntitites = new MarcaEntities();
                    OmarcaEntitites.idMarca = int.Parse(txtidMarca.Text);
                    OmarcaEntitites.marca = txtMarca.Text;


                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/Marca/ActualizarMarca", OmarcaEntitites).Result;
                    //url del api guardar

                    lblMensaje.Text = "Edicion Exitosa";
                }
                else
                {
                    lblMensaje.Text = "id Marca No Registrado";
                    txtidMarca.Text = "";
                    txtMarca.Text = "";
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
