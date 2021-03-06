using AsignacionEntities;
using AsignacionUI.Clases;
using System;
using System.Net.Http;
using System.Text;

namespace AsignacionUI.pages
{
    public partial class ListaEstadoSim : System.Web.UI.Page
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
                        if (User.IsInRole("Soporte") || User.IsInRole("Coordinador") || User.IsInRole("Usuarios Administrativos"))
                        {
                            ConsultarEstadoSim();
                        }
                        else
                        {
                            Response.Redirect("../Users/NoAutorizado.aspx",false);
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
                mensajeExcepcion.Text = "Ocurrio un error, por favor intenta nuevamente";
            }
        
        }
        public void ConsultarEstadoSim()
        {
            var result = OenrutarUri.GetApi("EstadoSim/ConsultarEstadoSim");
            
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



                }
            }
          
        }

    }
