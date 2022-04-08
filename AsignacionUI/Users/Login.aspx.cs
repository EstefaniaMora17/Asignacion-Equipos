using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Web;

namespace AsignacionUI.pages
{
    public partial class Login : System.Web.UI.Page
    {
        excepciones Oexcepciones = new excepciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "clearHistory", "ClearHistory();", true);
                    //CERAR SESION
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    authenticationManager.SignOut();          
                }
            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                mensajeExcepcion.Text = "Error registrando, por favor intenta nuevamente";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                //busca si el usuario existe
                var user = userManager.Find(txtEmail.Text, txtContraseña.Text);

                if (user != null)
                {
                    //inicia sesion
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                    // redirecina dentro el sistema
                    Response.Redirect("../Pages/Perfil.aspx", false);
                }
                else
                {
                    Mensaje.Text = "Usuario o contraseña no coinciden";

                }
            }
            catch(Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                mensajeExcepcion.Text = "Error registrando, por favor intenta nuevamente";
            }
           
           
        }
       
    }
}
