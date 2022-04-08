<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="NoAutorizado.aspx.cs" Inherits="AsignacionUI.Users.NoAutorizado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="main-content" id="panel">
        <!-- Page content -->
        <div class="container-fluid mt--6 padinnProfile">
            <div class="col order-xl-1">
                <div class="card padinginInfo">
                    <div class="card-header">
                        <div class="row align-items-center">
                            <div class="col-8">
                                <h3 class="mb-0">no tienes permisos para ingresra a la pagina soliciatada</h3>
                                <asp:Literal runat="server" ID="Mensaje" />
                            </div>

                        </div>
                    </div>
           
                </div>
            </div>
        </div>
    </div>
</asp:Content>
