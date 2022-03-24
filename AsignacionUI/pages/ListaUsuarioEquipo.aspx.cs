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
    public partial class ListaUsuarioEquipo : System.Web.UI.Page
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

                throw ex;
            }
        }

        public void ConsultarUsurioEquipo()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/UsuarioEquipo/ConsultarUsuarioEquipo");

                var result = responseTask.Result;
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
                          //" <td class='budget'>" + equipo.imagen + "</td>" +
                        " <td class='budget'>" + equipo.fechaUsuarioEquipo + "</td>" +
                      "</tr>");

                        //string imagenDataUrl64 = "data:image/jpeg;base64," + Convert.ToBase64String(equipo.imagen);

                        //equipo.imagen = Encoding.ASCII.GetBytes(imagenDataUrl64);
                        ////    imagen1.ImageUrl = System.Text.Encoding.UTF8.GetString(equipo.imagen);
                        
                    }


                    dataUsuarioEquipo.InnerHtml = sb.ToString();
                }
            }

        }


        //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //    // UsuarioEquipoEntities usuarioEquipo = new UsuarioEquipoEntities();
        //    //if(dr.imagen != null)
        //    //{
        //    //    string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr.imagen);
        //    //    (e.Row.FindControl("Image1")as System.Web.UI.WebControls.Image).ImageUrl = imageUrl;

        //    //}


        //}
    }


    //protected void btnDescargar_Click(object sender, ImageClickEventArgs e)
    //{
    //    Response.Clear();+
    //    Response.Buffer = true;
    //    Response.AddHeader("content-disposition", "attachment;filename=GridDataUsuarioEquipo.xls");
    //    Response.Charset = "";
    //    Response.ContentType = "application/vnd.ms-excel";

    //    using (StringWriter OstringWriter = new StringWriter())
    //    {
    //        HtmlTextWriter OhtmlTextWriter = new HtmlTextWriter(OstringWriter);

    //        GridDataUsuarioEquipo.AllowPaging = false;
    //        this.ConsultarUsurioEquipo();

    //        GridDataUsuarioEquipo.HeaderRow.BackColor = Color.White;
    //        foreach (TableCell cell in GridDataUsuarioEquipo.HeaderRow.Cells)
    //        {
    //            cell.BackColor = GridDataUsuarioEquipo.HeaderStyle.BackColor;
    //        }
    //        foreach (GridViewRow row in GridDataUsuarioEquipo.Rows)
    //        {
    //            row.BackColor = Color.White;
    //            foreach (TableCell cell in row.Cells)
    //            {
    //                if (row.RowIndex % 2 == 0)
    //                {
    //                    cell.BackColor = GridDataUsuarioEquipo.AlternatingRowStyle.BackColor;
    //                }
    //                else
    //                {
    //                    cell.BackColor = GridDataUsuarioEquipo.RowStyle.BackColor;
    //                }
    //                cell.CssClass = "textmode";
    //            }
    //        }
    //        GridDataUsuarioEquipo.RenderControl(OhtmlTextWriter);
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

