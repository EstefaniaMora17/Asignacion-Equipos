<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="AsignacionUI.pages.RegitroUsuario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xl-12 order-xl-1">
            <div class="card">

                <div class="card-header">
                    <div class="row align-items-center">
                        <div class="col-8">
                            <h3 class="mb-0">Registro de Asesores</h3>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <h6 class="heading-small text-muted mb-4">Informacion Asesor</h6>
                    <div class="pl-lg-4">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-first-name">Cedula</label>
                                    <asp:TextBox ID="txtCedula" CssClass="form-control" MaxLength="10" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtCedula" runat="server" ErrorMessage="*Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtCedula" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCedula" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="txtCedula"></asp:RequiredFieldValidator>
                                    
                                </div>
                            </div>  
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-last-name">Nombre</label>
                                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNombre" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-first-name">Apellido</label>
                                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtApellido" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-first-name">Telefono</label>
                                    <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtTelefono" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-last-name">Area</label>
                                    <asp:DropDownList ID="DLLidArea" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="DLLidArea" runat="server" ErrorMessage="* Campo Obligatorio" InitialValue="0" ValidationGroup="campo"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-last-name">Cargo</label>
                                    <asp:DropDownList ID="DLLidCargo" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="DLLidCargo" runat="server" ErrorMessage="* Campo Obligatorio" InitialValue="0" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-left: 28%;">

                            <div class="col-lg-4 d-flex justify-content-center" id="Divguardar" runat="server">
                                <asp:Button ID="btnGuardar" CssClass="btn btn-outline-danger" OnClick="btnGuardar_Click" runat="server" Text="Guardar" ValidationGroup="campo"   />
                            </div>

                            <div class=" col-lg-4 d-flex justify-content-center" id="Diveditar" runat="server">
                                <asp:Button ID="btnEditar" CssClass="btn btn-outline-danger" OnClick="btnEditar_Click" runat="server" Text="Editar" />
                            </div>
                            <div class=" col-lg-4 d-flex justify-content-center">
                                <asp:Button ID="btnBuscar" CssClass="btn btn-outline-danger" OnClick="btnBuscar_Click" runat="server" Text="Buscar" ValidationGroup="txtCedula" />
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Label ID="lblmensaje" runat="server"></asp:Label>
            </div>
        </div>

    </div>





</asp:Content>
