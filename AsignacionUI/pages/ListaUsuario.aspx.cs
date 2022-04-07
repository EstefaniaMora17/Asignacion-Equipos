﻿using System.IO;
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
    public partial class ListaUsuario : System.Web.UI.Page
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
                            ConsultarUsuario();
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
        public void ConsultarUsuario()
        {
            var result = OenrutarUri.GetApi("Usuarios/ConsultarUsuario");
          
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UsuariosEntities[]>();

                    var usuario = readTask.Result;
                    StringBuilder sb = new StringBuilder();
                    foreach (var Usuario in usuario)
                    {
                        sb.Append("<tr>" +
                    "<th scope = 'row'> " +
                      "<div class='media align-items-center'>" +
                        "<div class='media-body'>" +
                         "<span class='name mb-0 text-sm'>" + Usuario.cedula + "</span>" +
                        "</div>" +
                      "</div>" +
                    "</th>" +
                    " <td class='budget'>" + Usuario.nombre + "</td>" +
                   " <td class='budget'>" + Usuario.apellido + "</td>" +
                        " <td class='budget'>" + Usuario.telefono + "</td>" +
                          " <td class='budget'>" + Usuario.area + "</td>" +
                          " <td class='budget'>" + Usuario.cargo + "</td>" +
                          " <td class='budget'>" + Usuario.FechaUsuario + "</td>" +
                  "</tr>");
                    }

                    dataUsuarioEquipo.InnerHtml = sb.ToString();

                    
                }
            }
          
        }

    }
