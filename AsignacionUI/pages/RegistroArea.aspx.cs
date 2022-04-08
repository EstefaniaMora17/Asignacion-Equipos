using AsignacionEntities;
using AsignacionUI.Clases;
using System;
using System.Net.Http;
using System.Web.UI.WebControls;

namespace AsignacionUI.pages
{
    public partial class RegistroArea : System.Web.UI.Page
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
                            ConsultaListArea();
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
            var result = OenrutarUri.GetApi("/Area/consultarAreaIndv?idArea=" + idArea + "");
            
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
       
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarAreaIndv(int.Parse(DllArea.SelectedValue))== true){

                    AreaEntities OareaEntities = new AreaEntities();
                    OareaEntities.idArea = int.Parse(DllArea.SelectedValue);
                    OareaEntities.area = txtAreaUpdate.Text;
                    if (OenrutarUri.PostApi("/Area/ActualizarArea", OareaEntities))
                    {
                        lblMensaje.Text = "Edicion Exitosa";
                        ConsultaListArea();
                        txtAreaUpdate.Text = string.Empty;
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
                excepciones.capturarExcepcion(ex);
                mensajeExcepcion.Text = "Ocurrio un error, por favor intenta nuevamente";

            }
        }
        public void LimpiarCampos()
        {
           
            txtArea.Text = "";
            DllArea.SelectedIndex = 0;
            
        }
   
        
        public void ConsultaListArea()
        {
            var result = OenrutarUri.GetApi("Area/consultarArea");

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<AreaEntities[]>();

                var area = readTask.Result;

                DllArea.DataSource = area;
                DllArea.DataTextField = "area";
                DllArea.DataValueField = "idArea";
                DllArea.DataBind();
                DllArea.Items.Insert(0, new ListItem("Seleccione area", "0"));
                DllArea.Dispose();
            }

        }
    }

}
