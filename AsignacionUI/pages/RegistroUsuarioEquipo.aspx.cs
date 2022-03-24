﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AsignacionEntities;
using System.Drawing;
using System.IO;

namespace AsignacionUI.pages
{
    public partial class RegistroUsuarioEquipo : System.Web.UI.Page
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
                            ConsultarEquipo();
                            ConsultarEstadoEquipo();
                            ConsultarEstadoSim();
                            ConsultarUsuario();
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //convirtiendo la imgane en byte
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(fuploadImagen.PostedFile.InputStream))
                {
                    bytes = br.ReadBytes(fuploadImagen.PostedFile.ContentLength);
                }

                UsuarioEquipoEntities OusuarioEquipoEntities = new UsuarioEquipoEntities();
                OusuarioEquipoEntities.cedula = DLLcedula.SelectedValue;
                OusuarioEquipoEntities.imei = DLLimei.SelectedValue;
                OusuarioEquipoEntities.iccid = DLLiccid.SelectedValue;
                OusuarioEquipoEntities.observacion = txtObservacion.Text;
                OusuarioEquipoEntities.idEstadoEquipo = int.Parse(DLLidestadoEquipo.SelectedValue);
                OusuarioEquipoEntities.idEstadoSim = int.Parse(DLLidestadoSim.SelectedValue);
                OusuarioEquipoEntities.imagen = bytes;
                OusuarioEquipoEntities.nombreImagen = Path.GetFileName(fuploadImagen.PostedFile.FileName);
                OusuarioEquipoEntities.ContentType = fuploadImagen.PostedFile.ContentType;
                //invocamos al api
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44335");
                //url del proyecto webApi
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("/api/UsuarioEquipo/InsertarUsuarioEquipo", OusuarioEquipoEntities).Result;
                LimpiarCampos();
                lblMensaje.Text = "Registro Exitoso";
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ConsultarEstadoEquipo()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/EstadoEquipo/ConsultarEstadoEquipo");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EstadoEquipoEntities[]>();

                    var EstadoEquipo = readTask.Result;

                    DLLidestadoEquipo.DataSource = EstadoEquipo;
                    DLLidestadoEquipo.DataTextField = "estadoEquipo";
                    DLLidestadoEquipo.DataValueField = "idEstadoEquipo";
                    DLLidestadoEquipo.DataBind();
                    DLLidestadoEquipo.Items.Insert(0, new ListItem("Seleccione Estado Equipo", "0"));
                    DLLidestadoEquipo.Dispose();
                }
            }
        }
        public void ConsultarEstadoSim()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/EstadoSim/ConsultarEstadoSim");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EstadoSimEntities[]>();

                    var estadoSim = readTask.Result;

                    DLLidestadoSim.DataSource = estadoSim;
                    DLLidestadoSim.DataTextField = "estadoSim";
                    DLLidestadoSim.DataValueField = "idEstadoSim";
                    DLLidestadoSim.DataBind();
                    DLLidestadoSim.Items.Insert(0, new ListItem("Seleccione Estado Sim", "0"));
                    DLLidestadoSim.Dispose();
                }
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

                    DLLcedula.DataSource = usuario;
                    DLLcedula.DataTextField = "cedula";
                    DLLcedula.DataBind();
                    DLLcedula.Items.Insert(0, new ListItem("Seleccione cedula", "0"));
                    DLLcedula.Dispose();


                }
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
                    DLLimei.DataSource = equipo;
                    DLLimei.DataTextField = "imei";
                    DLLimei.DataBind();
                    DLLimei.Items.Insert(0, new ListItem("Seleccione imei", "0"));
                    DLLimei.Dispose();
                }
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
                    DLLiccid.DataSource = sim;
                    DLLiccid.DataTextField = "iccid";
                    DLLiccid.DataBind();
                    DLLiccid.Items.Insert(0, new ListItem("Seleccione iccid", "0"));
                    DLLiccid.Dispose();
                }
            }
        }
        public bool ConsultarUsuarioEquipoIndv(int id)
        {
            bool estado = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/UsuarioEquipo/ConsultarUsuarioEquipoIndv/{id}?id=" + id + "");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UsuarioEquipoEntities>();

                    var usuarioEquipo = readTask.Result;

                    if (usuarioEquipo.id == id)
                    {
                        DLLcedula.SelectedValue = usuarioEquipo.cedula.ToString();
                        DLLiccid.Text = usuarioEquipo.iccid.ToString();
                        DLLimei.SelectedValue = usuarioEquipo.imei.ToString();
                        txtObservacion.Text = usuarioEquipo.observacion.ToString();
                        DLLidestadoEquipo.SelectedValue = usuarioEquipo.idEstadoEquipo.ToString();
                        DLLidestadoSim.SelectedValue = usuarioEquipo.idEstadoSim.ToString();

                        if (usuarioEquipo.imagen != null)
                        {
                            string imagenDataUrl64 = "data:image/jpeg;base64," + Convert.ToBase64String(usuarioEquipo.imagen);

                            Image1.ImageUrl = imagenDataUrl64;
                        }

                        estado = true;
                    }
                }
            }
            return estado;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ConsultarUsuarioEquipoIndv(int.Parse(txtId.Text)) == true)
            {
                lblMensaje.Text = "Datos encontrados";
            }
            else
            {
                LimpiarCampos();


            }
        }
        public void LimpiarCampos()
        {
            txtId.Text = "";
            txtObservacion.Text = "";
            DLLcedula.SelectedIndex = 0;
            DLLiccid.SelectedIndex = 0;
            DLLidestadoEquipo.SelectedIndex = 0;
            DLLidestadoSim.SelectedIndex = 0;
            DLLimei.SelectedIndex = 0;
            Image1.ImageUrl = "";
        }
    }
}