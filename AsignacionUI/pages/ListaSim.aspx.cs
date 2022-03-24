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
    public partial class ListaSim : System.Web.UI.Page
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
                            ConsultarSim();
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
        public void ConsultarSim()
        {
            using (var client = new HttpClient())
            {
              
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/Sim/ConsultarSim");

                var result = responseTask.Result;
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

                    //GridDataSim.DataSource = sim;

                    //GridDataSim.DataBind();

                }
            }
            //GridDataSim.UseAccessibleHeader = true;
            //GridDataSim.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

     
    

        //protected void btnDescargar_Click1(object sender, ImageClickEventArgs e)
        //{
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=GridViewSim.xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";

        //    using (StringWriter OstringWriter = new StringWriter())
        //    {
        //        HtmlTextWriter OhtmlTextWriter = new HtmlTextWriter(OstringWriter);

        //        GridDataSim.AllowPaging = false;
        //        this.ConsultarSim();

        //        GridDataSim.HeaderRow.BackColor = Color.White;
        //        foreach (TableCell cell in GridDataSim.HeaderRow.Cells)
        //        {
        //            cell.BackColor = GridDataSim.HeaderStyle.BackColor;
        //        }
        //        foreach (GridViewRow row in GridDataSim.Rows)
        //        {
        //            row.BackColor = Color.White;
        //            foreach (TableCell cell in row.Cells)
        //            {
        //                if (row.RowIndex % 2 == 0)
        //                {
        //                    cell.BackColor = GridDataSim.AlternatingRowStyle.BackColor;
        //                }
        //                else
        //                {
        //                    cell.BackColor = GridDataSim.RowStyle.BackColor;
        //                }
        //                cell.CssClass = "textmode";
        //            }
        //        }
        //        GridDataSim.RenderControl(OhtmlTextWriter);
        //        string style = @"<style> .textmode { } </style>";
        //        Response.Write(style);
        //        Response.Output.Write(OstringWriter.ToString());
        //        Response.Flush();
        //        Response.End();
        //    }

        //}
        public override void VerifyRenderingInServerForm(Control control)
        {

            //Confirma que se representa un control HtmlForm para el control de servidor 
        }
    }
}

