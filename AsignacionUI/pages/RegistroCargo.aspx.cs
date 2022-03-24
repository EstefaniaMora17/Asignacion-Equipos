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
    public partial class RegistroCargo : System.Web.UI.Page
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
                if (ConsultarCargoIndv(int.Parse(txtidCargo.Text)) == false)
                {
                    CargoEntities OcargoEntities = new CargoEntities();
                    OcargoEntities.cargo = txtCargo.Text;

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/Cargo/InsertarCargo", OcargoEntities).Result;
                    //url del api guardar
                    lblMensaje.Text = "Registro Exitoso";
                }
                else
                {
                    lblMensaje.Text = "Id Cargo Ya Existe";
                    txtCargo.Text = "";
                }  

            }
            catch (Exception)
            {
                throw;
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
            if(ConsultarCargoIndv(int.Parse(txtidCargo.Text))== true)
            {
                CargoEntities OcargoEntities = new CargoEntities();
                OcargoEntities.idcargo = int.Parse(txtidCargo.Text);
                OcargoEntities.cargo = txtCargo.Text;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44335");
                //url del proyecto webApi
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("/api/Cargo/Actualizarcargo", OcargoEntities).Result;
                //url del api guardar

                lblMensaje.Text = "Edicion Exitosa";
            }
            else
            {
                lblMensaje.Text = "id Cargo No Registrado";
                txtidCargo.Text = "";
                txtCargo.Text = "";
            }

        }

       
    }
}