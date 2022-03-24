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
    public partial class ListaUsuario : System.Web.UI.Page
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
                throw ex;
            }
        }
        public void ConsultarUsuario()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Usuarios/ConsultarUsuario");

                var result = responseTask.Result;
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

                    //GridDataUsuario.DataSource = usuario;

                    //GridDataUsuario.DataBind();
                }
            }

            //GridDataUsuario.UseAccessibleHeader = true;
            //GridDataUsuario.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        //protected void btnDescargar_Click(object sender, ImageClickEventArgs e)
        //{
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=GridDataUsuario.xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";

        //    using (StringWriter OstringWriter = new StringWriter())
        //    {
        //        HtmlTextWriter OhtmlTextWriter = new HtmlTextWriter(OstringWriter);

        //        GridDataUsuario.AllowPaging = false;
        //        this.ConsultarUsuario();

        //        GridDataUsuario.HeaderRow.BackColor = Color.White;
        //        foreach (TableCell cell in GridDataUsuario.HeaderRow.Cells)
        //        {
        //            cell.BackColor = GridDataUsuario.HeaderStyle.BackColor;
        //        }
        //        foreach (GridViewRow row in GridDataUsuario.Rows)
        //        {
        //            row.BackColor = Color.White;
        //            foreach (TableCell cell in row.Cells)
        //            {
        //                if (row.RowIndex % 2 == 0)
        //                {
        //                    cell.BackColor = GridDataUsuario.AlternatingRowStyle.BackColor;
        //                }
        //                else
        //                {
        //                    cell.BackColor = GridDataUsuario.RowStyle.BackColor;
        //                }
        //                cell.CssClass = "textmode";
        //            }
        //        }
        //        GridDataUsuario.RenderControl(OhtmlTextWriter);
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