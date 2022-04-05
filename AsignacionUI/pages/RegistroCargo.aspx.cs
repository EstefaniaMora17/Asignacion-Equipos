using System;
using System.Net.Http;
using System.Net.Http.Headers;
using AsignacionEntities;
using AsignacionUI.Clases;

namespace AsignacionUI.pages
{
    public partial class RegistroCargo : System.Web.UI.Page
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

                CargoEntities OcargoEntities = new CargoEntities();
                OcargoEntities.cargo = txtCargo.Text;

                if (OenrutarUri.PostApi("Cargo/Post", OcargoEntities))
                {
                    lblMensaje.Text = "Registro Guardados";
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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Cargo/ConsultarCargoIndv?idcargo=" + idcargo + "");

                var result = responseTask.Result;
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
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarCargoIndv(int.Parse(txtidCargo.Text)) == true)
                {
                    CargoEntities OcargoEntities = new CargoEntities();
                    OcargoEntities.idcargo = int.Parse(txtidCargo.Text);
                    OcargoEntities.cargo = txtCargo.Text;
                    if (OenrutarUri.PostApi("/api/Cargo", OcargoEntities))
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
                    lblMensaje.Text = "id Cargo No Registrado";
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
            txtidCargo.Text = "";
            txtCargo.Text = "";
        }


    }
}