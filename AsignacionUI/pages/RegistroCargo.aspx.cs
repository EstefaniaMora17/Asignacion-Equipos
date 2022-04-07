using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI.WebControls;
using AsignacionEntities;
using AsignacionUI.Clases;

namespace AsignacionUI.pages
{
    public partial class RegistroCargo : System.Web.UI.Page
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
                            ConsultaListCargo();
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

                CargoEntities OcargoEntities = new CargoEntities();
                OcargoEntities.cargo = txtCargo.Text;

                if (OenrutarUri.PostApi("Cargo/Post", OcargoEntities))
                {
                    lblMensaje.Text = "Registro Guardado";
                }
                else
                {
                    throw new Exception(string.Format("Error registrando cargo. {0} ",OcargoEntities.cargo));
                }
            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                lblMensaje.Text = "Error registrando, por favor intenta nuevamente";
            }
        }
        public bool ConsultarCargoIndv(int idcargo)
        {
            bool estado = false;

            var result = OenrutarUri.GetApi("/Cargo/ConsultarCargoIndv?idcargo=" + idcargo + "");
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<CargoEntities>();

                var cargo = readTask.Result;

                if (cargo.idcargo == idcargo)
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
                if (ConsultarCargoIndv(int.Parse(DllCargo.SelectedValue)) == true)
                {
                    CargoEntities OcargoEntities = new CargoEntities();
                    OcargoEntities.idcargo = int.Parse(DllCargo.SelectedValue);
                    OcargoEntities.cargo = txtCargoUpdate.Text;
                    if (OenrutarUri.PostApi("Cargo/ActualizarCargo", OcargoEntities))
                    {

                        lblMensaje.Text = "Edicion Exitosa";
                        ConsultaListCargo();
                        txtCargoUpdate.Text = string.Empty;
                    }
                    else
                    {
                        lblMensaje.Text = "Error en la edicion, por favor intenta nuevamente";
                    }

                }
                else
                {
                    lblMensaje.Text = "id Cargo No Registrado";
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
           
            txtCargo.Text = "";
        }

        public void ConsultaListCargo()
        {
            var result = OenrutarUri.GetApi("/Cargo/ConsultarCargo");
            
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CargoEntities[]>();

                    var cargo = readTask.Result;

                    DllCargo.DataSource = cargo;
                    DllCargo.DataTextField = "cargo";
                    DllCargo.DataValueField = "idcargo";
                    DllCargo.DataBind();
                    DllCargo.Items.Insert(0, new ListItem("Seleccionar cargo", "0"));
                    DllCargo.Dispose();


                }
            }
        }


    }
