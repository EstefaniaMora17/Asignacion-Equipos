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
    public partial class RegistroSim : System.Web.UI.Page
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
                        if (User.IsInRole("Soporte") || User.IsInRole("Coordinador"))
                        {
                            ConsultarEstadoSim();
                            ocultarBotones(1);
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
                excepciones.capturarExcepcion(ex);
                mensajeExcepcion.Text = "Ocurrio un error, por favor intenta nuevamente";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarSimIndv(txtIccid.Text) == false)
                {
                    SimEntities OsimEntities = new SimEntities();
                    OsimEntities.iccid = txtIccid.Text;
                    OsimEntities.min = txtMin.Text;
                    OsimEntities.planDatos = txtPlandatos.Text;
                    OsimEntities.idEstadoSim = int.Parse(DllidEstadoSim.SelectedValue);

                    if (OenrutarUri.PostApi("Sim/Post", OsimEntities))
                    {
                        lblMensaje.Text = "Registro Guardado";
                    }
                    else
                    {
                        throw new Exception(string.Format("Error registrando Sim. {0} ", OsimEntities.iccid, "{1}", 
                            OsimEntities.min, "{2}", OsimEntities.planDatos, "{3}", OsimEntities.estadoSim));
                    }

                    LimpiarCampos();

                }
                else
                {
                    lblMensaje.Text = "Ya Existe un registro con ese ICCID";
                    LimpiarCampos();
                }

            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                lblMensaje.Text = "Error registrando, por favor intenta nuevamente";
            }
        }
        public void ConsultarEstadoSim()
        {
            var result = OenrutarUri.GetApi("/EstadoSim/ConsultarEstadoSim");
          
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EstadoSimEntities[]>();

                    var estadoSim = readTask.Result;

                    DllidEstadoSim.DataSource = estadoSim;
                    DllidEstadoSim.DataTextField = "estadoSim";
                    DllidEstadoSim.DataValueField = "idEstadoSim";
                    DllidEstadoSim.DataBind();
                    DllidEstadoSim.Items.Insert(0, new ListItem("Seleccione Estado Sim", "0"));
                    DllidEstadoSim.Dispose();


                }
            
        }
        public bool ConsultarSimIndv(string iccid)
        {
            bool estado = false;
            var result = OenrutarUri.GetApi("/Sim/ConsultarSimIndv?iccid=" + iccid + "");
           
              
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<SimEntities>();

                    var sim = readTask.Result;

                    if (sim.iccid == iccid)
                    {

                        estado = true;
                    }
                }
            
            return estado;
        }
        public bool ConsultarSimBuscar(string iccid)
        {
            bool estado = false;
            var result = OenrutarUri.GetApi("/Sim/ConsultarSimIndv?iccid=" + iccid + "");
          
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<SimEntities>();

                    var sim = readTask.Result;

                    if (sim.iccid == iccid)
                    {
                        txtMin.Text = sim.min.ToString();
                        txtPlandatos.Text = sim.planDatos.ToString();
                        DllidEstadoSim.SelectedValue = sim.idEstadoSim.ToString();
                        estado = true;
                    }
                }
            
            return estado;
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarSimIndv(txtIccid.Text) == true)
                {
                    SimEntities OsimEntities = new SimEntities();
                    OsimEntities.iccid = txtIccid.Text;
                    OsimEntities.min = txtMin.Text;
                    OsimEntities.planDatos = txtPlandatos.Text;
                    OsimEntities.idEstadoSim = int.Parse(DllidEstadoSim.SelectedValue);

                  

                    if (OenrutarUri.PostApi("Sim/ActualizarSim", OsimEntities))
                    {
                        lblMensaje.Text = "Edicion Exitosa";
                    }
                    else
                    {
                        lblMensaje.Text = "Error en la edicion, por favor intenta nuevamente";
                    }
                    LimpiarCampos();
                    ocultarBotones(3);

                }
                else
                {

                    lblMensaje.Text = "ICCID no registrado";

                }

            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                mensajeExcepcion.Text = "Ocurrio un error, por favor intenta nuevamente";

            }

        }
        protected void btnBucar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarSimBuscar(txtIccid.Text) == true)
                {
                    lblMensaje.Text = "Datos encontrados";
                    ocultarBotones(2);
                }
                else
                {
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
            txtIccid.Text = "";
            txtMin.Text = "";
            txtPlandatos.Text = "";
            DllidEstadoSim.SelectedIndex = 0;

        }
        public void ocultarBotones(int num)
        {
            switch (num)
            {
                case 1:
                    Diveditar.Visible = false;
                    break;
                case 2:

                    Divguardar.Visible = false;
                    Diveditar.Visible = true;
                    break;
                case 3:
                    Divguardar.Visible = true;
                    Diveditar.Visible = false;
                    break;


            }

        }
    }
}
