using AsignacionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AsignacionUI.Clases;

namespace AsignacionUI.pages
{
    public partial class ListaMarca : System.Web.UI.Page
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
                            ConsultarMarca();
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
        public void ConsultarMarca()
        {
            var result = OenrutarUri.GetApi("Marca/ConsultarMarca");
          
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<MarcaEntities[]>();

                    var marca = readTask.Result;

                    StringBuilder sb = new StringBuilder();

                    foreach (var Marca in marca)
                    {
                        sb.Append("<tr>" +
                    "<th scope = 'row'> " +
                      "<div class='media align-items-center'>" +
                        "<div class='media-body'>" +
                         "<span class='name mb-0 text-sm'>" + Marca.idMarca + "</span>" +
                        "</div>" +
                      "</div>" +
                    "</th>" +
                    " <td class='budget'>" + Marca.marca + "</td>" +
                  "</tr>");
                    }

                    dataMarca.InnerHtml = sb.ToString();

                 

                }

            }
          

        }
    }
