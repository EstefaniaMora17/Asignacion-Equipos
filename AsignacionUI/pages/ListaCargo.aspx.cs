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
    public partial class ListaCargo : System.Web.UI.Page
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
                            ConsultarCargo();
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
        public void ConsultarCargo()
        {
            var result = OenrutarUri.GetApi("Cargo/ConsultarCargo");

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<CargoEntities[]>();

                var cargo = readTask.Result;

                StringBuilder sb = new StringBuilder();

                foreach (var Cargo in cargo)
                {
                    sb.Append("<tr>" +
                "<th scope = 'row'> " +
                  "<div class='media align-items-center'>" +
                    "<div class='media-body'>" +
                     "<span class='name mb-0 text-sm'>" + Cargo.idcargo + "</span>" +
                    "</div>" +
                  "</div>" +
                "</th>" +
                " <td class='budget'>" + Cargo.cargo + "</td>" +
              "</tr>");
                }

                dataCargo.InnerHtml = sb.ToString();



            }

        }
    }
}