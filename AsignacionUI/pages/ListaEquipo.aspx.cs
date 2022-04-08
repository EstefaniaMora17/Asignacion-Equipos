using AsignacionEntities;
using AsignacionUI.Clases;
using System;
using System.Net.Http;
using System.Text;

namespace AsignacionUI.pages
{
    public partial class ListaEquipo : System.Web.UI.Page
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
                            ConsultarEquipo();
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
        public void ConsultarEquipo()
        {
            var result = OenrutarUri.GetApi("Equipo/consultarEquipos");

               if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EquipoEntities[]>();

                    var equipo = readTask.Result;
                    StringBuilder sb = new StringBuilder();

                    foreach (var Equipo  in equipo)
                    {
                        sb.Append("<tr>" +
                    "<th scope = 'row'> " +
                      "<div class='media align-items-center'>" +
                        "<div class='media-body'>" +
                         "<span class='name mb-0 text-sm'>" + Equipo.imei + "</span>" +
                        "</div>" +
                      "</div>" +
                    "</th>" +
                    " <td class='budget'>" + Equipo.Referencia + "</td>" +
                   " <td class='budget'>" + Equipo.marca + "</td>" +
                        " <td class='budget'>" + Equipo.rom + "</td>" +
                          " <td class='budget'>" + Equipo.ram + "</td>" +
                          " <td class='budget'>" + Equipo.bateria + "</td>" +
                          " <td class='budget'>" + Equipo.accesorios + "</td>" +
                          " <td class='budget'>" + Equipo.Precio + "</td>" +
                            " <td class='budget'>" + Equipo.observacion + "</td>" +
                              " <td class='budget'>" + Equipo.estadoEquipo + "</td>" +
                                " <td class='budget'>" + Equipo.ubicacionEquipo + "</td>" +
                                " <td class='budget'>" + Equipo.FechaEquipo + "</td>" +
                  "</tr>");
                    }

                    dataEquipo.InnerHtml = sb.ToString();

                }
            }
         
        }

   
    }


