﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AsignacionEntities;
using AsignacionUI.Clases;

namespace AsignacionUI.pages
{
    public partial class RegistroEstadoSim : System.Web.UI.Page
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
                        if (User.IsInRole("Usuarios Administrativos") )
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
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
               
                    EstadoSimEntities OestadoSimEntities = new EstadoSimEntities();
                    OestadoSimEntities.estadoSim = txtEstadoSim.Text;

                    if (OenrutarUri.PostApi("EstadoSim/Post", OestadoSimEntities))
                    {
                        lblMensaje.Text = "Registro Guardados";
                    }
                    else
                    {
                        throw new Exception(string.Format("Error registrando Estado Sim. {0} ",
                        OestadoSimEntities.estadoSim));
                    }
                   
               
            }
            catch (Exception ex)
            {
                excepciones.capturarExcepcion(ex);
                lblMensaje.Text = "Error registrando, por favor intenta nuevamente";
            }
          
        }
        public bool ConsultarEstadoSimIndv(int idEstadoSim)
        {
            bool estado = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44335");
                var responseTask = client.GetAsync("/api/EstadoSim/ConsultarEstadoSimIndv?idEstadoSim=" + idEstadoSim + "");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EstadoSimEntities>();

                    var estadoSim = readTask.Result;

                    if (estadoSim.idEstadoSim == idEstadoSim)
                    {

                        estado = true;
                    }

                }
                return estado;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultarEstadoSimIndv(int.Parse(txtidEstadoSim.Text)) == true)
                {
                    EstadoSimEntities OestadoSimEntities = new EstadoSimEntities();
                    OestadoSimEntities.idEstadoSim = int.Parse(txtidEstadoSim.Text);
                    OestadoSimEntities.estadoSim = txtEstadoSim.Text;

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:44335");
                    //url del proyecto webApi
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/EstadoSim/ActaulizarEstadoSim", OestadoSimEntities).Result;
                    //url del api guardar

                    lblMensaje.Text = "Edicion Exitosa";
                }
                else
                {
                    lblMensaje.Text = "id Estado Sim No Registrado";
                    txtidEstadoSim.Text = "";
                    txtEstadoSim.Text = "";
                }
            }
            catch(Exception ex)
            {
                Oexcepciones.capturarExcepcion(mensajeExcepcion.Text);
                mensajeExcepcion.Text = (ex.Message);
            }
        
        }

    }
}