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
    public partial class RegistroSim : System.Web.UI.Page
    {
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
                throw ex;
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

                    //invocamos al api
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/Sim/InsertarSim", OsimEntities).Result;

                    lblMensaje.Text = "Registro Exitoso";
                    LimpiarCampos();
                }
                else
                {
                    lblMensaje.Text = "Ya Existe un registro con ese ICCID";
                    LimpiarCampos();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ConsultarEstadoSim()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/EstadoSim/ConsultarEstadoSim");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EstadoSimEntities[]>();

                    var estadoSim = readTask.Result;

                    DllidEstadoSim.DataSource =  estadoSim;
                    DllidEstadoSim.DataTextField = "estadoSim";
                    DllidEstadoSim.DataValueField = "idEstadoSim";
                    DllidEstadoSim.DataBind();
                    DllidEstadoSim.Items.Insert(0, new ListItem("Seleccione Estado Sim", "0"));
                    DllidEstadoSim.Dispose();

                    
                }
            }
        } 
        public bool ConsultarSimIndv(string iccid)
        {
            bool estado = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Sim/ConsultarSimIndv?iccid=" + iccid + "");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<SimEntities>();

                    var sim = readTask.Result;

                    if (sim.iccid == iccid)
                    {
                        
                        estado = true;
                    }
                }
            }
            return estado;
        }
        public bool ConsultarSim(string iccid)
        {
            bool estado = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Sim/ConsultarSimIndv?iccid=" + iccid + "");

                var result = responseTask.Result;
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

                    lblMensaje.Text = "Edicion Exitosa";
                    LimpiarCampos();
                    ocultarBotones(3);
                }
                else
                {

                    LimpiarCampos();
                }

            }
            catch (Exception)
            {
                throw;
            }
        
        }
        protected void btnBucar_Click(object sender, EventArgs e)
        {
            if (ConsultarSim(txtIccid.Text)== true) 
            {
                lblMensaje.Text = "Datos encontrados";
                ocultarBotones(2);
            }
            else
            {
                LimpiarCampos();
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
