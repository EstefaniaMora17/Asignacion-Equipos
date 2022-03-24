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
    public partial class RegitroUsuario : System.Web.UI.Page
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
                            ConsultarArea();
                            ConsultarCargo();
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
                if (ConsultarUsuarioIndv(txtCedula.Text)== false)
                {
                    UsuariosEntities OusuariosEntities = new UsuariosEntities();
                    OusuariosEntities.cedula = txtCedula.Text;
                    OusuariosEntities.nombre = txtNombre.Text;
                    OusuariosEntities.apellido = txtApellido.Text;
                    OusuariosEntities.telefono = txtTelefono.Text;
                    OusuariosEntities.idArea = int.Parse(DLLidArea.SelectedValue);
                    OusuariosEntities.idcargo = int.Parse(DLLidCargo.SelectedValue);

                    //invocamos al api
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/Usuarios/InsertarUsuarios", OusuariosEntities).Result;

                    lblmensaje.Text = "Registro Exitoso";

                }
                else{

                    LimpiarCampos();

                }
            }
            catch (Exception)   
            {
                throw;
            }
        }
        public void ConsultarArea()
        {
            using ( var client = new HttpClient()) 
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Area/consultarArea");

                var result = responseTask.Result;
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
        }
        public void ConsultarCargo()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Cargo/ConsultarCargo");

                var result = responseTask.Result;
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
        }
        public bool ConsultarUsuarioIndv(string cedula)
        {
            bool estado = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Usuarios/ConsultarUsuarioIndv?cedula="+ cedula+"");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UsuariosEntities>();

                    var usuario = readTask.Result;
                    if (usuario.cedula == cedula)
                    {
                        estado = true;
                    }

                }
            }
            return estado;
        }
        public bool ConsultarUsuario(string cedula)
        {
            bool estado = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Usuarios/ConsultarUsuarioIndv?cedula=" + cedula + "");

                var result = responseTask.Result;
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

                    //invocamos al api
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/Usuarios/InsertarUsuarios", OusuariosEntities).Result;

                    lblmensaje.Text = "Edicion Exitosa";
                    LimpiarCampos();
                    ocultarBotones(3);

                }
                else
                {
                    lblmensaje.Text = "cedula no Registrada";
                    LimpiarCampos();
                }

            }
            catch (Exception)
            {
                throw;
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
          if  (ConsultarUsuario(txtCedula.Text) == true)
            {

                lblmensaje.Text = "Datos Encontrados";
                ocultarBotones(2);
            }
            else
            {
                LimpiarCampos();
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
 
