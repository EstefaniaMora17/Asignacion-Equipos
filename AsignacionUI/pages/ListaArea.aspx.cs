using System.IO;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Http;
using AsignacionEntities;
using System.Web.UI.WebControls;
using System.Web.UI;
using System;
using System.Text;
namespace AsignacionUI.pages
{
    public partial class ListaArea : System.Web.UI.Page
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
                            ConsultarArea();
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
    
        public void ConsultarArea()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Area/consultarArea");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AreaEntities[]>();

                    var area = readTask.Result;

                    StringBuilder sb = new StringBuilder();

                    foreach (var Area in area)
                    {
                        sb.Append("<tr>" +
                    "<th scope = 'row'> " +
                      "<div class='media align-items-center'>" +
                        "<div class='media-body'>" +
                         "<span class='name mb-0 text-sm'>" + Area.idArea + "</span>" +
                        "</div>" +
                      "</div>" +
                    "</th>" +
                    " <td class='budget'>" + Area.area + "</td>" +
                  "</tr>");
                    }

                    dataArea.InnerHtml = sb.ToString();

                    //GridDataArea.DataSource = area;

                    //GridDataArea.DataBind();
                }
            }
            //GridDataArea.UseAccessibleHeader = true;
            //GridDataArea.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}