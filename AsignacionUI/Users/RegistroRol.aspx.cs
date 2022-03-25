using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsignacionUI.Users
{
    public partial class RegistroRol : System.Web.UI.Page
    {
        excepciones Oexcepciones = new excepciones();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void CrearRol()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            string Rol = txtRol.Text;
            if (string.IsNullOrEmpty(Rol) == false)
            {
                if (!roleManager.RoleExists(Rol))
                {
                    var role = new IdentityRole();
                    role.Name = Rol;
                    roleManager.Create(role);
                    lblMensaje.Text = "Rol registrado correctamente";
                }
                else
                {
                    lblMensaje.Text = "Rol ya existe";
                }
            }

        }

        protected void btnCrearRol_Click(object sender, EventArgs e)
        {
            try
            {
                CrearRol();
            }
            catch (Exception ex)
            {
                Oexcepciones.capturarExcepcion(mensajeExcepcion.Text);
                mensajeExcepcion.Text = (ex.Message);
                lblMensaje.Text = ex.Message + ex.InnerException + ex.StackTrace;
            }
        }
    }
}