using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Web;

namespace AsignacionUI.pages
{
    public partial class Login : System.Web.UI.Page
    {
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
                    HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
                    HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
                    HttpContext.Current.Response.AddHeader("Expires", "0");

                    //Response.CacheControl = "no-cache";

                    //Response.AddHeader("Pragma", "no-cache");

                    //Response.Expires = -1;

                    //Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                    //Response.Cache.SetAllowResponseInBrowserHistory(false);
                    //Response.Cache.SetNoStore();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
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
                Response.Redirect("../Pages/Profile.aspx");
            }
            else
            {
                Mensaje.Text = "No se encontró el usuario";

            }
           
        }
       
    }
}
