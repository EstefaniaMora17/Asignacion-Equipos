using AsignacionEntities;
using AsignacionUI.Clases;
using System;
using System.Net.Http;
using System.Text;

namespace AsignacionUI.pages
{
    public partial class ListaSim : System.Web.UI.Page
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
                            ConsultarSim();
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
        public void ConsultarSim()
        {
            var result = OenrutarUri.GetApi("Sim/ConsultarSim");
          
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<SimEntities[]>();

                    var sim = readTask.Result;

                    StringBuilder sb = new StringBuilder();

                    foreach (var Sim in sim)
                    {
                        sb.Append("<tr>" +
                    "<th scope = 'row'> " +
                      "<div class='media align-items-center'>" +
                        "<div class='media-body'>" +
                         "<span class='name mb-0 text-sm'>" + Sim.iccid + "</span>" +
                        "</div>" +
                      "</div>" +
                    "</th>" +
                    " <td class='budget'>" + Sim.min + "</td>" +
                   " <td class='budget'>" + Sim.planDatos + "</td>" +
                        " <td class='budget'>" + Sim.estadoSim + "</td>" +
                          " <td class='budget'>" + Sim.fechaSim + "</td>" +
                  "</tr>");
                    }

                    dataSim.InnerHtml = sb.ToString();

                 

                }
            }
          
        }
    }


