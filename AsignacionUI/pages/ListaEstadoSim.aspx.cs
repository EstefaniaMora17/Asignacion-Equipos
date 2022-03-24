using AsignacionEntities;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.UI.WebControls;
using System.Text;
namespace AsignacionUI.pages
{
    public partial class ListaEstadoSim : System.Web.UI.Page
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
                            ConsultarEstadoSim();
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
        public void ConsultarEstadoSim()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/EstadoSim/ConsultarEstadoSim");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EstadoSimEntities[]>();

                    var estadoSim = readTask.Result;
                    StringBuilder sb = new StringBuilder();

                    foreach (var EstadoSim in estadoSim)
                    {
                        sb.Append("<tr>" +
                    "<th scope = 'row'> " +
                      "<div class='media align-items-center'>" +
                        "<div class='media-body'>" +
                         "<span class='name mb-0 text-sm'>" + EstadoSim.idEstadoSim + "</span>" +
                        "</div>" +
                      "</div>" +
                    "</th>" +
                    " <td class='budget'>" + EstadoSim.estadoSim + "</td>" +
                  "</tr>");
                    }

                    dataEstadoSim.InnerHtml = sb.ToString();

                    //GridDataEstadoSim.DataSource = estadoSim;

                    //GridDataEstadoSim.DataBind();


                }
            }
            //GridDataEstadoSim.UseAccessibleHeader = true;
            //GridDataEstadoSim.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }
}