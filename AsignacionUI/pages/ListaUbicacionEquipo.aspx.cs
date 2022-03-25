using AsignacionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
namespace AsignacionUI.pages
{
    public partial class ListaUbicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        if (User.IsInRole("Soporte") || User.IsInRole("Coordinador") || User.IsInRole("Usuarios Administrativos"))
                        {
                            ConsultarUbicacionEquipo();
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
                lblMensaje.Text = (ex.Message);
            }
        }
        public void ConsultarUbicacionEquipo()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/UbicacionEquipo/ConsultarUbicacionEquipo");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UbicacionEquipoEntities[]>();

                    var ubicacionEquipo = readTask.Result;
                    StringBuilder sb = new StringBuilder();

                    foreach (var UbicacionEquipo in ubicacionEquipo)
                    {
                        sb.Append("<tr>" +
                    "<th scope = 'row'> " +
                      "<div class='media align-items-center'>" +
                        "<div class='media-body'>" +
                         "<span class='name mb-0 text-sm'>" + UbicacionEquipo.idubicacionEquipo + "</span>" +
                        "</div>" +
                      "</div>" +
                    "</th>" +
                    " <td class='budget'>" + UbicacionEquipo.ubicacionEquipo + "</td>" +
                  "</tr>");
                    }

                    dataUbicacionEquipo.InnerHtml = sb.ToString();

                   

                }
            }
          
        }
    }
}