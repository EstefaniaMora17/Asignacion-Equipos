using AsignacionEntities;
using AsignacionUI.Clases;
using System;
using System.Net.Http;
using System.Web.UI.WebControls;

namespace AsignacionUI.pages
{
    public partial class RegistroEstadoSim : System.Web.UI.Page
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
                            ConsultaListEstadoSim();
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

                EstadoSimEntities OestadoSimEntities = new EstadoSimEntities();
                OestadoSimEntities.estadoSim = txtEstadoSim.Text;

                if (OenrutarUri.PostApi("EstadoSim/Post", OestadoSimEntities))
                {
                    lblMensaje.Text = "Registro Guardado";
                }
                else
                {
                    throw new Exception(string.Format("Error registrando Estado Sim. {0} ",
                    OestadoSimEntities.estadoSim));
                }


            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                lblMensaje.Text = "Error registrando, por favor intenta nuevamente";
            }

        }
        public bool ConsultarEstadoSimIndv(int idEstadoSim)
        {
            bool estado = false;
            var result = OenrutarUri.GetApi(("/EstadoSim/ConsultarEstadoSimIndv?idEstadoSim=" + idEstadoSim + ""));
           
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EstadoSimEntities>();

                    var estadoSim = readTask.Result;

                    if (estadoSim.idEstadoSim == idEstadoSim)
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
                if (ConsultarEstadoSimIndv(int.Parse(DllEstadoSim.SelectedValue)) == true)
                {
                    EstadoSimEntities OestadoSimEntities = new EstadoSimEntities();
                    OestadoSimEntities.idEstadoSim = int.Parse(DllEstadoSim.SelectedValue);
                    OestadoSimEntities.estadoSim = txtEstadoSimUpdate.Text;
                    if (OenrutarUri.PostApi("/EstadoSim/ActaulizarEstadoSim", OestadoSimEntities))
                    {
                        lblMensaje.Text = "Edicion Exitosa";
                        ConsultaListEstadoSim();
                        txtEstadoSimUpdate.Text = string.Empty;
                        LimpiarCampos();
                    }
                    else
                    {
                        lblMensaje.Text = "Error en la edicion, por favor intenta nuevamente";
                    }

                }
                else
                {

                    lblMensaje.Text = "Id Estado Sim no registrado";
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

            txtEstadoSim.Text = "";
            txtEstadoSimUpdate.Text = "";
            DllEstadoSim.SelectedIndex = 0;
        }
        public void ConsultaListEstadoSim()
        {
            var result = OenrutarUri.GetApi("/EstadoSim/ConsultarEstadoSim");

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<EstadoSimEntities[]>();

                var estadoSim = readTask.Result;

                DllEstadoSim.DataSource = estadoSim;
                DllEstadoSim.DataTextField = "estadoSim";
                DllEstadoSim.DataValueField = "idEstadoSim";
                DllEstadoSim.DataBind();
                DllEstadoSim.Items.Insert(0, new ListItem("Seleccione Estado Sim", "0"));
                DllEstadoSim.Dispose();
            }

        }
    }
}