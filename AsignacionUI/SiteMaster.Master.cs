using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AsignacionEntities;
using Microsoft.Office.Interop.Access.Dao;

namespace AsignacionUI
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        

        }
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("../Users/Login.aspx", true);
        }
    }
}