using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AsignacionEntities;
using System.Drawing;
using System.IO;
using AsignacionUI.Clases;

namespace AsignacionUI.pages
{
    public partial class RegistroUsuarioEquipo : System.Web.UI.Page
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
                        if (User.IsInRole("Soporte") || User.IsInRole("Coordinador"))
                        {
                            ConsultarEquipo();
                            ConsultarEstadoEquipo();
                            ConsultarEstadoSim();
                            ConsultarUsuario();
                            ConsultarSim();
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
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //convirtiendo la imgane en byte
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(fuploadImagen.PostedFile.InputStream))
                {
                    bytes = br.ReadBytes(fuploadImagen.PostedFile.ContentLength);
                }

                UsuarioEquipoEntities OusuarioEquipoEntities = new UsuarioEquipoEntities();
                OusuarioEquipoEntities.cedula = DLLcedula.SelectedValue;
                OusuarioEquipoEntities.imei = DLLimei.SelectedValue;
                OusuarioEquipoEntities.iccid = DLLiccid.SelectedValue;
                OusuarioEquipoEntities.observacion = txtObservacion.Text;
                OusuarioEquipoEntities.idEstadoEquipo = int.Parse(DLLidestadoEquipo.SelectedValue);
                OusuarioEquipoEntities.idEstadoSim = int.Parse(DLLidestadoSim.SelectedValue);
                OusuarioEquipoEntities.imagen = bytes;
                OusuarioEquipoEntities.nombreImagen = Path.GetFileName(fuploadImagen.PostedFile.FileName);
                OusuarioEquipoEntities.ContentType = fuploadImagen.PostedFile.ContentType;

                if (OenrutarUri.PostApi("UsuarioEquipo/Post", OusuarioEquipoEntities))
                {
                    lblMensaje.Text = "Registro Guardados";
                }
                else
                {

                    throw new Exception(string.Format("Error registrando Usuario Equipo. {0} ", OusuarioEquipoEntities.cedula, "{1}",
                  OusuarioEquipoEntities.imei, "{2}", OusuarioEquipoEntities.iccid, "{3}", OusuarioEquipoEntities.observacion, "{4}",
                 OusuarioEquipoEntities.idEstadoEquipo, "{5}", OusuarioEquipoEntities.idEstadoSim, "{6}", OusuarioEquipoEntities.imagen,
                  "{7}", OusuarioEquipoEntities.nombreImagen, "{8}", OusuarioEquipoEntities.ContentType));
                }
                
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                lblMensaje.Text = "Error registrando, por favor intenta nuevamente";
            }
        }
        public void ConsultarEstadoEquipo()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/EstadoEquipo/ConsultarEstadoEquipo");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EstadoEquipoEntities[]>();

                    var EstadoEquipo = readTask.Result;

                    DLLidestadoEquipo.DataSource = EstadoEquipo;
                    DLLidestadoEquipo.DataTextField = "estadoEquipo";
                    DLLidestadoEquipo.DataValueField = "idEstadoEquipo";
                    DLLidestadoEquipo.DataBind();
                    DLLidestadoEquipo.Items.Insert(0, new ListItem("Seleccione Estado Equipo", "0"));
                    DLLidestadoEquipo.Dispose();
                }
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

                    DLLidestadoSim.DataSource = estadoSim;
                    DLLidestadoSim.DataTextField = "estadoSim";
                    DLLidestadoSim.DataValueField = "idEstadoSim";
                    DLLidestadoSim.DataBind();
                    DLLidestadoSim.Items.Insert(0, new ListItem("Seleccione Estado Sim", "0"));
                    DLLidestadoSim.Dispose();
                }
            }
        }
        public void ConsultarUsuario()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Usuarios/ConsultarUsuario");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UsuariosEntities[]>();

                    var usuario = readTask.Result;

                    DLLcedula.DataSource = usuario;
                    DLLcedula.DataTextField = "cedula";
                    DLLcedula.DataBind();
                    DLLcedula.Items.Insert(0, new ListItem("Seleccione cedula", "0"));
                    DLLcedula.Dispose();


                }
            }
        }
        public void ConsultarEquipo()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Equipo/consultarEquipos");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EquipoEntities[]>();

                    var equipo = readTask.Result;
                    DLLimei.DataSource = equipo;
                    DLLimei.DataTextField = "imei";
                    DLLimei.DataBind();
                    DLLimei.Items.Insert(0, new ListItem("Seleccione imei", "0"));
                    DLLimei.Dispose();
                }
            }
        }
        public void ConsultarSim()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Sim/ConsultarSim");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<SimEntities[]>();

                    var sim = readTask.Result;
                    DLLiccid.DataSource = sim;
                    DLLiccid.DataTextField = "iccid";
                    DLLiccid.DataBind();
                    DLLiccid.Items.Insert(0, new ListItem("Seleccione iccid", "0"));
                    DLLiccid.Dispose();
                }
            }
        }
        public bool ConsultarUsuarioEquipoIndv(int id)
        {
            bool estado = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/UsuarioEquipo/ConsultarUsuarioEquipoIndv/{id}?id=" + id + "");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UsuarioEquipoEntities>();

                    var usuarioEquipo = readTask.Result;

                    if (usuarioEquipo.id == id)
                    {
                        DLLcedula.SelectedValue = usuarioEquipo.cedula.ToString();
                        DLLiccid.Text = usuarioEquipo.iccid.ToString();
                        DLLimei.SelectedValue = usuarioEquipo.imei.ToString();
                        txtObservacion.Text = usuarioEquipo.observacion.ToString();
                        DLLidestadoEquipo.SelectedValue = usuarioEquipo.idEstadoEquipo.ToString();
                        DLLidestadoSim.SelectedValue = usuarioEquipo.idEstadoSim.ToString();

                        if (usuarioEquipo.imagen != null)
                        {
                            string imagenDataUrl64 = "data:image/jpeg;base64," + Convert.ToBase64String(usuarioEquipo.imagen);

                            Image1.ImageUrl = imagenDataUrl64;
                        }

                        estado = true;
                    }
                }
            }
            return estado;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarUsuarioEquipoIndv(int.Parse(txtId.Text)) == true)
                {
                    lblMensaje.Text = "Datos encontrados";
                }
                else
                {
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
            txtId.Text = "";
            txtObservacion.Text = "";
            DLLcedula.SelectedIndex = 0;
            DLLiccid.SelectedIndex = 0;
            DLLidestadoEquipo.SelectedIndex = 0;
            DLLidestadoSim.SelectedIndex = 0;
            DLLimei.SelectedIndex = 0;
            Image1.ImageUrl = "";
        }
    }
}