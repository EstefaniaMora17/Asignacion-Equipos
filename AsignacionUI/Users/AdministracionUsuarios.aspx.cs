using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsignacionUI.Users
{
    public partial class AdministracionUsuarios : System.Web.UI.Page
    {
        excepciones Oexcepciones = new excepciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        if (!User.IsInRole("Coordinador"))
                        {
                            Response.Redirect("NoAutorizado.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("../Users/Login.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Oexcepciones.capturarExcepcion(mensajeExcepcion.Text);
                mensajeExcepcion.Text = (ex.Message);
            }
        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrarUsuario();
            }
            catch (Exception ex)
            {

                Oexcepciones.capturarExcepcion(mensajeExcepcion.Text);
                mensajeExcepcion.Text = (ex.Message);
            }
        }

        void RegistrarUsuario()
        {
            string Email = txtEmail.Text;
            string Rol = dllRol.SelectedItem.Text;
            if (string.IsNullOrEmpty(Email))
            {
                Mensaje.Text = "email esta vacio";
            }
            else if (txtContraseña.Text != txtCcontraseña.Text)
            {
                Mensaje.Text = "contraseña diferente";

            }
            else
            {
                //Hemos agregado soporte para crear usuarios.
                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);
                //guardara los cambios de UserStore.
                var user = new IdentityUser() { UserName = Email };
                //CREA EL USUARIO Y LA ASOCIA CON LA CONTRASEÑA DADA
                IdentityResult result = manager.Create(user, txtContraseña.Text);
                if (result.Succeeded)
                {
                    AsignarRol(Email, Rol);
                }
                else
                {
                    Mensaje.Text = result.Errors.FirstOrDefault();
                }
            }
        }
        void AsignarRol(string Email, string Rol)
        {

            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            IdentityResult IdUserResult = manager.AddToRole(manager.FindByName(Email).Id, Rol);

            if (IdUserResult.Succeeded == true)
            {
                Mensaje.Text = string.Format("usuario {0} fue cread@ con exito! y rol asignado exitosamente", Email);
            }
            else
            {
                //en caso de que falle asignado rol, se acnseja elimnar el usaurio,y se de volver a crear
                string[] error = IdUserResult.Errors.ToArray();
                Mensaje.Text = string.Format("usuario {0} fue cread@ con exito!, error asignado Rol", Email);
            }
        }
    }
}