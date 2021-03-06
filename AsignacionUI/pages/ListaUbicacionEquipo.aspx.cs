using AsignacionEntities;
using AsignacionUI.Clases;
using System;
using System.Net.Http;
using System.Text;

namespace AsignacionUI.pages
{
    public partial class ListaUbicacion : System.Web.UI.Page
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
                            ConsultarUbicacionEquipo();
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
        public void ConsultarUbicacionEquipo()
        {
            var result = OenrutarUri.GetApi("UbicacionEquipo/ConsultarUbicacionEquipo");
       
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
