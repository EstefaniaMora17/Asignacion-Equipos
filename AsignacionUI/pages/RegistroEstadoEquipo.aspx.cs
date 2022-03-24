﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AsignacionEntities;
namespace AsignacionUI.pages
{
    public partial class RegistroEstadoEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        if (User.IsInRole("Soporte") || User.IsInRole("Coordinador"))
                        {
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarEstadoEquipoIndv(int.Parse(txtidEstadoEquipo.Text)) == false)
                {
                    EstadoEquipoEntities OestadoEquipoEntities = new EstadoEquipoEntities();
                    OestadoEquipoEntities.estadoEquipo = txtestadoEquipo.Text;

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/EstadoEquipo/InsertarEstadoEquipo", OestadoEquipoEntities).Result;
                    //url del api guardar

                    lblMensaje.Text = "Registro Exitoso";
                }
                else
                {
                    lblMensaje.Text = "id Estado Equipo ya Existe";
                    txtidEstadoEquipo.Text = "";
                    txtestadoEquipo.Text = "";
                }
            }
            catch (Exception)
            {
                throw;
            }



        }
        public bool ConsultarEstadoEquipoIndv(int idEstadoEquipo)
        {
            bool estado = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/EstadoEquipo/ConsultarEstadoEquipoIndv?idEstadoEquipo=" + idEstadoEquipo + "");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EstadoEquipoEntities>();

                    var estadoEquipo = readTask.Result;

                    if (estadoEquipo.idEstadoEquipo == idEstadoEquipo)
                    {

                        estado = true;
                    }

                }
                return estado;
            }
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {  
            if (ConsultarEstadoEquipoIndv(int.Parse(txtidEstadoEquipo.Text)) == true)
            {
                EstadoEquipoEntities OestadoEquipoEntities = new EstadoEquipoEntities();
                OestadoEquipoEntities.idEstadoEquipo = int.Parse(txtidEstadoEquipo.Text);
                OestadoEquipoEntities.estadoEquipo = txtestadoEquipo.Text;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44335");
                //url del proyecto webApi
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("/api/EstadoEquipo/ActualizarEstadoEquipo", OestadoEquipoEntities).Result;
                //url del api guardar

                 lblMensaje.Text = "Edicion Exitosa";
            }
            else
            {
                lblMensaje.Text = "id Estado Equipo No Registrado";
                txtidEstadoEquipo.Text = "";
                txtestadoEquipo.Text = "";
            }

        }
    }
}