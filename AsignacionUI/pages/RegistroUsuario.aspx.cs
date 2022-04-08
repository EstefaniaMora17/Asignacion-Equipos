using AsignacionEntities;
using AsignacionUI.Clases;
using System;
using System.Net.Http;
using System.Web.UI.WebControls;

namespace AsignacionUI.pages
{
    public partial class RegitroUsuario : System.Web.UI.Page
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
                            ConsultarArea();
                            ConsultarCargo();
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
                mensajeExcepcion.Text = "Ocurrio un error, por favor intenta nuevamente";
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarUsuarioIndv(txtCedula.Text) == false)
                {
                    UsuariosEntities OusuariosEntities = new UsuariosEntities();
                    OusuariosEntities.cedula = txtCedula.Text;
                    OusuariosEntities.nombre = txtNombre.Text;
                    OusuariosEntities.apellido = txtApellido.Text;
                    OusuariosEntities.telefono = txtTelefono.Text;
                    OusuariosEntities.idArea = int.Parse(DLLidArea.SelectedValue);
                    OusuariosEntities.idcargo = int.Parse(DLLidCargo.SelectedValue);

                    if (OenrutarUri.PostApi("Usuarios/Post", OusuariosEntities))
                    {
                        lblMensaje.Text = "Registro Guardado";
                    }
                    else
                    {
                        throw new Exception(string.Format("Error registrando Usuario. {0} ", OusuariosEntities.cedula, "{1}",
                      OusuariosEntities.nombre, "{2}", OusuariosEntities.apellido, "{3}", OusuariosEntities.telefono, "{4}",
                      OusuariosEntities.idArea, "{5}", OusuariosEntities.idcargo));
                    }
                    
                 
                    LimpiarCampos();
                }
                else
                {
                    lblMensaje.Text = "Ya Existe un registro con esa Cedula";
                    LimpiarCampos();

                }
            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                lblMensaje.Text = "Error registrando, por favor intenta nuevamente";
            }
        }
        public void ConsultarArea()
        {
            var result = OenrutarUri.GetApi("Area/consultarArea");
            
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AreaEntities[]>();

                    var area = readTask.Result;

                    DLLidArea.DataSource = area;
                    DLLidArea.DataTextField = "area";
                    DLLidArea.DataValueField = "idArea";
                    DLLidArea.DataBind();
                    DLLidArea.Items.Insert(0, new ListItem("Seleccione area", "0"));
                    DLLidArea.Dispose();
                }
            
        }
        public void ConsultarCargo()
        {
            var result = OenrutarUri.GetApi("Cargo/ConsultarCargo");
            
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CargoEntities[]>();

                    var cargo = readTask.Result;

                    DLLidCargo.DataSource = cargo;
                    DLLidCargo.DataTextField = "cargo";
                    DLLidCargo.DataValueField = "idCargo";
                    DLLidCargo.DataBind();
                    DLLidCargo.Items.Insert(0, new ListItem("Seleccione cargo", "0"));
                    DLLidCargo.Dispose();
                }
            
        }
        public bool ConsultarUsuarioIndv(string cedula)
        {
            bool estado = false;
            var result = OenrutarUri.GetApi("Usuarios/ConsultarUsuarioIndv?cedula=" + cedula + "");
           
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UsuariosEntities>();

                    var usuario = readTask.Result;
                    if (usuario.cedula == cedula)
                    {
                        estado = true;
                    }

                }
            
            return estado;
        }
        public bool ConsultarUsuarioBuscar(string cedula)
        {
            bool estado = false;
            var result = OenrutarUri.GetApi("Usuarios/ConsultarUsuarioIndv?cedula=" + cedula + "");
            
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UsuariosEntities>();

                    var usuario = readTask.Result;
                    if (usuario.cedula == cedula)
                    {
                        txtNombre.Text = usuario.nombre.ToString();
                        txtApellido.Text = usuario.apellido.ToString();
                        txtTelefono.Text = usuario.telefono.ToString();
                        DLLidArea.SelectedValue = usuario.idArea.ToString();
                        DLLidCargo.SelectedValue = usuario.idcargo.ToString();
                        estado = true;
                    }
                }
            
            return estado;
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarUsuarioIndv(txtCedula.Text) == true)
                {
                    UsuariosEntities OusuariosEntities = new UsuariosEntities();
                    OusuariosEntities.cedula = txtCedula.Text;
                    OusuariosEntities.nombre = txtNombre.Text;
                    OusuariosEntities.apellido = txtApellido.Text;
                    OusuariosEntities.telefono = txtTelefono.Text;
                    OusuariosEntities.idArea = int.Parse(DLLidArea.SelectedValue);
                    OusuariosEntities.idcargo = int.Parse(DLLidCargo.SelectedValue);

                    if (OenrutarUri.PostApi("/Usuarios/ActualizarUsuarios", OusuariosEntities))
                    {
                        lblMensaje.Text = "Edicion Exitosa";
                    }
                    else
                    {
                        lblMensaje.Text = "Error registrando, por favor intenta nuevamente";
                    }

                  
                    ocultarBotones(3);
                    LimpiarCampos();
                }
                else
                {
                    lblMensaje.Text = "cedula no Registrada";
                    
                }

            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                mensajeExcepcion.Text = "Ocurrio un error, por favor intenta nuevamente";

            }
        }
        private void LimpiarCampos()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            DLLidArea.SelectedIndex = 0;
            DLLidCargo.SelectedIndex = 0;

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarUsuarioBuscar(txtCedula.Text) == true)
                {

                    lblMensaje.Text = "Datos Encontrados";
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

