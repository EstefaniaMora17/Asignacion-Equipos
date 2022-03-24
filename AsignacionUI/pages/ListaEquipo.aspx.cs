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
    public partial class ListaEquipo : System.Web.UI.Page
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
                            ConsultarEquipo();
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
        public void ConsultarEquipo()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Equipo/consultarEquipos");

                var result = responseTask.Result;
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

                    //GridDataEquipo.DataSource = equipo;

                    //GridDataEquipo.DataBind();


                }
            }
            //GridDataEquipo.UseAccessibleHeader = true;
            //GridDataEquipo.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        //protected void btnDescargar_Click(object sender, ImageClickEventArgs e)
        //{
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=GridDataEquipo.xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";

        //    using (StringWriter OstringWriter = new StringWriter())
        //    {
        //        HtmlTextWriter OhtmlTextWriter = new HtmlTextWriter(OstringWriter);

        //        GridDataEquipo.AllowPaging = false;
        //        this.ConsultarEquipo();
        //        GridDataEquipo.HeaderRow.BackColor = Color.White;
        //        foreach (TableCell cell in GridDataEquipo.HeaderRow.Cells)
        //        {
        //            cell.BackColor = GridDataEquipo.HeaderStyle.BackColor;
        //        }
        //        foreach (GridViewRow row in GridDataEquipo.Rows)
        //        {
        //            row.BackColor = Color.White;
        //            foreach (TableCell cell in row.Cells)
        //            {
        //                if (row.RowIndex % 2 == 0)
        //                {
        //                    cell.BackColor = GridDataEquipo.AlternatingRowStyle.BackColor;
        //                }
        //                else
        //                {
        //                    cell.BackColor = GridDataEquipo.RowStyle.BackColor;
        //                }
        //                cell.CssClass = "textmode";
        //            }
        //        }
        //        GridDataEquipo.RenderControl(OhtmlTextWriter);
        //        string style = @"<style> .textmode { } </style>";
        //        Response.Write(style);
        //        Response.Output.Write(OstringWriter.ToString());
        //        Response.Flush();
        //        Response.End();
        //    }

        //}
        //public override void VerifyRenderingInServerForm(Control control)
        //{

        //    //Confirma que se representa un control HtmlForm para el control de servidor 
        //}
    }

}
