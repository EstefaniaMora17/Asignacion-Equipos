using AsignacionEntities;
using AsignacionUI.Clases;
using System;
using System.Net.Http;
using System.Web.UI.WebControls;

namespace AsignacionUI.pages
{
    public partial class RegistroMarca : System.Web.UI.Page
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
                            Response.Redirect("../Users/NoAutorizado.aspx",false);
                        }
                        else
                        {
                            ConsultaListMarca();
                        }


                    }
                    else
                    {
                        Response.Redirect("/Users/Login.aspx",false);
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
                  MarcaEntities OmarcaEntitites = new MarcaEntities();
                    OmarcaEntitites.marca = txtMarca.Text;


                    if (OenrutarUri.PostApi("Marca/Post", OmarcaEntitites))
                    {
                        lblMensaje.Text = "Registro Guardado";
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
            var result = OenrutarUri.GetApi("/Marca/ConsultarMarcaIndv?idMarca=" + idMarca + "");
           
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
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if(ConsultarMarcaIndv(int.Parse(DllMarca.SelectedValue)) == true)
                {
                    MarcaEntities OmarcaEntitites = new MarcaEntities();
                    OmarcaEntitites.idMarca = int.Parse(DllMarca.SelectedValue);
                    OmarcaEntitites.marca = txtMarcaUpdate.Text;

                    if (OenrutarUri.PostApi("/Marca/ActualizarMarca", OmarcaEntitites))
                    {
                        lblMensaje.Text = "Edicion Exitosa";
                        ConsultaListMarca();
                        txtMarcaUpdate.Text = string.Empty;

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
                excepciones.capturarExcepcion(ex);
                mensajeExcepcion.Text = "Ocurrio un error, por favor intenta nuevamente";

            }
        }
        public void LimpiarCampos()
        {
            txtMarca.Text = "";
        }
        public void ConsultaListMarca()
        {
            var result = OenrutarUri.GetApi("/Marca/ConsultarMarca");

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<MarcaEntities[]>();

                var marca = readTask.Result;

                DllMarca.DataSource = marca;
                DllMarca.DataTextField = "marca";
                DllMarca.DataValueField = "idMarca";
                DllMarca.DataBind();
                DllMarca.Items.Insert(0, new ListItem("Seleccione Marca", "0"));
                DllMarca.Dispose();
            }

        }
    }
 }
