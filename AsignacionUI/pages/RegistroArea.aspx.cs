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
    public partial class RegistroArea : System.Web.UI.Page
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
                AreaEntities OareaEntities = new AreaEntities();
                OareaEntities.area = txtArea.Text;

                if(OenrutarUri.PostApi("Area/Post", OareaEntities))
                {
                    lblMensaje.Text = "Registro Guardado";
                }
                else
                {      
                   throw new Exception(string.Format("Error registrando área. {0}", OareaEntities.area));
                }         
            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                lblMensaje.Text = "Error registrando, por favor intenta nuevamente";
            }
        }
        public bool ConsultarAreaIndv(int idArea)
        {
            bool estado = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Area/ConsultarAreaIndv?idArea=" + idArea + "");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AreaEntities>();

                    var area = readTask.Result;

                    if (area.idArea == idArea)
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
                if (ConsultarAreaIndv(int.Parse(txtidArea.Text))== true){

                    AreaEntities OareaEntities = new AreaEntities();
                    OareaEntities.idArea = int.Parse(txtidArea.Text);
                    OareaEntities.area = txtArea.Text;
                    if (OenrutarUri.PostApi("Area/Post", OareaEntities))
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
                   
                    lblMensaje.Text = "Id Area no registrado";
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
            txtidArea.Text = "";
            txtArea.Text = "";
        }


    }
}
