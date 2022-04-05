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
    public partial class RegistroMarca : System.Web.UI.Page
    {
        excepciones Oexcepciones = new excepciones();
        EnrutarUri OenrutarUri = new EnrutarUri();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (User.Identity.IsAuthenticated )
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
                  MarcaEntities OmarcaEntitites = new MarcaEntities();
                    OmarcaEntitites.marca = txtMarca.Text;


                    if (OenrutarUri.PostApi("Marca/Post", OmarcaEntitites))
                    {
                        lblMensaje.Text = "Registro Exitoso";
                    }
                    else
                    {
                    throw new Exception(string.Format("Error registrando Marca. {0} ", OmarcaEntitites.marca));
                    }
               
            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                lblMensaje.Text = "Error registrando, por favor intenta nuevamente";
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

                    if (OenrutarUri.PostApi("Marca/Post", OmarcaEntitites))
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
                    lblMensaje.Text = "id Marca No Registrado";
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
            txtidMarca.Text = "";
            txtMarca.Text = "";
        }
    }
 }
