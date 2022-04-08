
using AsignacionEntities;
using AsignacionUI.Clases;
using System;
using System.Net.Http;
using System.Web.UI.WebControls;

namespace AsignacionUI.pages
{
    public partial class RegistroEquipos : System.Web.UI.Page
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
                            ConsultarEstadoEquipo();
                            ConsultarUbicacionEquipo();
                            ConsultarMarca();
                            ocultarBotones(1);
                        }
                        else
                        {
                            Response.Redirect("../Users/NoAutorizado.aspx",false);
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
                lblMensaje.Text = "Ocurrio un error, por favor intenta nuevamente";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarEquipoIndv(txtImei.Text) == false)
                {
                    EquipoEntities OequipoEntities = new EquipoEntities();
                    OequipoEntities.imei = txtImei.Text;
                    OequipoEntities.Referencia = txtReferencia.Text;
                    OequipoEntities.rom = txtRom.Text;
                    OequipoEntities.ram = txtRam.Text;
                    OequipoEntities.bateria = txtBateria.Text;
                    OequipoEntities.accesorios = txtAccesorios.Text;
                    OequipoEntities.observacion = txtObservacion.Text;
                    OequipoEntities.idEstadoEquipo = int.Parse(DLLidEstadoEquipo.SelectedValue);
                    OequipoEntities.idubicacionEquipo = int.Parse(DLLidUbicacionEquipo.SelectedValue);
                    OequipoEntities.idMarca = int.Parse(DLLidMarca.SelectedValue);
                    OequipoEntities.Precio = txtPrecio.Text;


                    if (OenrutarUri.PostApi("Equipo/Post", OequipoEntities))
                    {
                        lblMensaje.Text = "Registro Guardado";
                    }
                  
                    else
                    {
                        throw new Exception(string.Format("Error registrando Equipo"));
                    }
                    
                   
                    LimpiarCampos();
                }
                else
                {
                    BtnEditar.Visible = false;

                    lblMensaje.Text = " Ya Existe un registro con ese IMEI";
                    LimpiarCampos();
                }

            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                lblMensaje.Text = "Error registrando, por favor intenta nuevamente";
            }

        }
        public void ConsultarEstadoEquipo()
        {
            var result = OenrutarUri.GetApi("/EstadoEquipo/ConsultarEstadoEquipo");
        
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EstadoEquipoEntities[]>();

                    var EstadoEquipo = readTask.Result;

                    DLLidEstadoEquipo.DataSource = EstadoEquipo;
                    DLLidEstadoEquipo.DataTextField = "estadoEquipo";
                    DLLidEstadoEquipo.DataValueField = "idEstadoEquipo";
                    DLLidEstadoEquipo.DataBind();
                    DLLidEstadoEquipo.Items.Insert(0, new ListItem("Seleccione Estado Equipo", "0"));
                    DLLidEstadoEquipo.Dispose();
                }
            
        }
        public void ConsultarUbicacionEquipo()
        {
            var result = OenrutarUri.GetApi("/UbicacionEquipo/ConsultarUbicacionEquipo");
          
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UbicacionEquipoEntities[]>();

                    var UbicacionEquipo = readTask.Result;

                    DLLidUbicacionEquipo.DataSource = UbicacionEquipo;
                    DLLidUbicacionEquipo.DataTextField = "ubicacionEquipo";
                    DLLidUbicacionEquipo.DataValueField = "idubicacionEquipo";
                    DLLidUbicacionEquipo.DataBind();
                    DLLidUbicacionEquipo.Items.Insert(0, new ListItem("Seleccione Ubicacion Equipo", "0"));
                    DLLidUbicacionEquipo.Dispose();
                }
            
        }
        public void ConsultarMarca()
        {
            var result = OenrutarUri.GetApi("/Marca/ConsultarMarca");
           
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<MarcaEntities[]>();

                    var Marca = readTask.Result;

                    DLLidMarca.DataSource = Marca;
                    DLLidMarca.DataTextField = "marca";
                    DLLidMarca.DataValueField = "idMarca";
                    DLLidMarca.DataBind();
                    DLLidMarca.Items.Insert(0, new ListItem("Seleccione Marca", "0"));
                    DLLidMarca.Dispose();
                }
            
        }
        public bool ConsultarEquipoIndv(string imei)
        {
            bool estado = false;
            var result = OenrutarUri.GetApi("Equipo/ConsultarEquipoIndv?imei=" + imei + "");
           
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EquipoEntities>();

                    //obtiene la infromacio
                    var equipo = readTask.Result;
                    if (equipo.imei == imei)
                    {
                        estado = true;
                    }
                }
            
            return estado;
        }
        public bool ConsultarEquipoBuscar(string imei)
        {
            bool estado = false;
            var result = OenrutarUri.GetApi("Equipo/ConsultarEquipoIndv?imei=" + imei + "");

                if (result.IsSuccessStatusCode)
                {
                                    //convierte la infromacion
                    var readTask = result.Content.ReadAsAsync<EquipoEntities>();

                    var equipo = readTask.Result;
                    if (equipo.imei == imei)
                    {
                        txtReferencia.Text = equipo.Referencia.ToString();
                        txtRom.Text = equipo.rom.ToString();
                        txtRam.Text = equipo.ram.ToString();
                        txtBateria.Text = equipo.bateria.ToString();
                        txtAccesorios.Text = equipo.accesorios.ToString();
                        txtObservacion.Text = equipo.observacion.ToString();
                        txtPrecio.Text = equipo.Precio.ToString();
                        DLLidEstadoEquipo.SelectedValue = equipo.idEstadoEquipo.ToString();
                        DLLidMarca.SelectedValue = equipo.idMarca.ToString();
                        DLLidUbicacionEquipo.SelectedValue = equipo.idubicacionEquipo.ToString();
                        estado = true;
                    }
                }
            
            return estado;
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarEquipoIndv(txtImei.Text) == true)
                {
                    EquipoEntities OequipoEntities = new EquipoEntities();
                    OequipoEntities.imei = txtImei.Text;
                    OequipoEntities.Referencia = txtReferencia.Text;
                    OequipoEntities.rom = txtRom.Text;
                    OequipoEntities.ram = txtRam.Text;
                    OequipoEntities.bateria = txtBateria.Text;
                    OequipoEntities.accesorios = txtAccesorios.Text;
                    OequipoEntities.observacion = txtObservacion.Text;
                    OequipoEntities.idEstadoEquipo = int.Parse(DLLidEstadoEquipo.SelectedValue);
                    OequipoEntities.idubicacionEquipo = int.Parse(DLLidUbicacionEquipo.SelectedValue);
                    OequipoEntities.idMarca = int.Parse(DLLidMarca.SelectedValue);
                    OequipoEntities.Precio = txtPrecio.Text;

                    if (OenrutarUri.PostApi("/Equipo/ActualizarEquipo", OequipoEntities))
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
                    lblMensaje.Text = "No se puedo realizar la edición";
                
                    
                }

            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                mensajeExcepcion.Text = "Ocurrio un error, por favor intenta nuevamente";

            }


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarEquipoBuscar(txtImei.Text) == true)
                {
                    lblMensaje.Text = "Datos Encontrados";
                    ocultarBotones(2);

                }
                else
                {
                    LimpiarCampos();
                    lblMensaje.Text = "imei no registrado";
                }
            }
            catch(Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                mensajeExcepcion.Text = "Ocurrio un error, por favor intenta nuevamente";

            }


        }
        public void LimpiarCampos()
        {
            txtImei.Text = "";
            txtReferencia.Text = "";
            txtRom.Text = "";
            txtRam.Text = "";
            txtBateria.Text = "";
            txtAccesorios.Text = "";
            txtObservacion.Text = "";
            DLLidEstadoEquipo.SelectedIndex = 0;
            DLLidUbicacionEquipo.SelectedIndex = 0;
            DLLidMarca.SelectedIndex = 0;
            txtPrecio.Text = "";
         
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