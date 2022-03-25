<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegistroMarca.aspx.cs" Inherits="AsignacionUI.pages.RegistroMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xl-12 order-xl-1">
            <div class="card">
                <div class="card-header">
                    <div class="row align-items-center">
                        <div class="col-8">
                            <h3 class="mb-0">Registro de Marca</h3>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <h6 class="heading-small text-muted mb-4">Informacion Marca</h6>
                    <div class="pl-lg-4">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-username">Id Marca</label>
                                    <asp:TextBox ID="txtidMarca" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtidMarca" runat="server" ErrorMessage="* Campo Obligatorio"  ValidationGroup="id"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-username">Marca</label>
                                    <asp:TextBox ID="txtMarca" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqUserName" ControlToValidate="txtMarca" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div class="row">
                                <div class="col  d-flex justify-content-center">
                                    <asp:Button ID="btnGuardar" CssClass="btn btn-outline-danger btnmargin" runat="server" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="campo" />
                                </div>
                                <div class="col  d-flex justify-content-center ">
                                    <asp:Button ID="btnEditar" CssClass="btn btn-outline-danger btnmargin" runat="server" OnClick="btnEditar_Click" Text="Editar"  ValidationGroup="id"/>
                                </div>
                            </div>
                            <div>
                                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Lita -->

</asp:Content>
