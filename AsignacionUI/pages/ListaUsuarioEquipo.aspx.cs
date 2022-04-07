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
using AsignacionUI.Clases;

namespace AsignacionUI.pages
{
    public partial class ListaUsuarioEquipo : System.Web.UI.Page
    {
        excepciones Oexcepciones = new excepciones();
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
                            ConsultarUsurioEquipo();
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
                excepciones.capturarExcepcion(ex);
                mensajeExcepcion.Text = "Ocurrio un error, por favor intenta nuevamente";
            }
        }

        public void ConsultarUsurioEquipo()
        {
            var result = OenrutarUri.GetApi("UsuarioEquipo/ConsultarUsuarioEquipo");

         
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UsuarioEquipoEntities[]>();

                    var usuarioEquipo = readTask.Result;

                    StringBuilder sb = new StringBuilder();

                    foreach (var equipo in usuarioEquipo)
                    {
                        sb.Append("<tr>" +
                        "<th scope = 'row'> " +
                          "<div class='media align-items-center'>" +
                            "<div class='media-body'>" +
                             "<span class='name mb-0 text-sm'>" + equipo.id + "</span>" +
                            "</div>" +
                          "</div>" +
                        "</th>" +
                        " <td class='budget'>" + equipo.nombre + "</td>" +
                       " <td class='budget'>" + equipo.iccid + "</td>" +
                        " <td class='budget'>" + equipo.imei + "</td>" +
                          " <td class='budget'>" + equipo.observacion + "</td>" +
                          " <td class='budget'>" + equipo.estadoSim + "</td>" +
                          " <td class=''>" + equipo.estadoEquipo + "</td>" +
                        
                        " <td class='budget'>" + equipo.fechaUsuarioEquipo + "</td>" +
                      "</tr>");

                       
                        
                    }


                    dataUsuarioEquipo.InnerHtml = sb.ToString();
                }
            }

        }


     
    }



