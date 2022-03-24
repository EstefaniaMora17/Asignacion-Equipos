using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsignacionUI.pages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (User.Identity.IsAuthenticated)
                {
                 
                    //MostrarInformacion

                }
                else
                {
                    Response.Redirect("/Users/Login.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}