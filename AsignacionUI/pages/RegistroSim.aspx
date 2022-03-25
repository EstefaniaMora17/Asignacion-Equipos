<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegistroSim.aspx.cs" Inherits="AsignacionUI.pages.RegistroSim" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" GridView="GridDataSim">
    <div class="row">
        <div class="col-xl-12 order-xl-1">
            <div class="card">
                <div class="card-header">
                    <div class="row align-items-center">
                        <div class="col-8">
                            <h3 class="mb-0">Registro de Sim</h3>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <h6 class="heading-small text-muted mb-4">Informacion SIM</h6>
                    <div class="pl-lg-4">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="ICCID" id="lbliccid">ICCID</label>
                                    <asp:TextBox ID="txtIccid" CssClass="form-control" MaxLength="17" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtIccid" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtIccid" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtIccid" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="txtIccid"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-username">Min</label>
                                    <asp:TextBox ID="txtMin" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtMin" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-first-name">Plan</label>
                                    <asp:TextBox ID="txtPlandatos" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPlandatos" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-last-name">Estado Sim</label>
                                    <asp:DropDownList ID="DllidEstadoSim" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="DllidEstadoSim" runat="server" ErrorMessage="* Campo Obligatorio" InitialValue="0" ValidationGroup="campo"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 25%;">
                        <div class="col-lg-4 d-flex justify-content-center" id="Divguardar" runat="server">
                            <asp:Button ID="btnGuardar" CssClass="btn btn-outline-danger" runat="server" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="campo" />
                        </div>
                        <div class="col-lg-4 d-flex justify-content-center" id="Diveditar" runat="server">
                            <asp:Button ID="btnEditar" CssClass="btn btn-outline-danger" OnClick="btnEditar_Click" runat="server" Text="Editar" />
                        </div>
                        <div class="col-lg-4 d-flex justify-content-center">
                            <asp:Button ID="btnBucar" CssClass="btn btn-outline-danger" OnClick="btnBucar_Click" runat="server" Text="Buscar" ValidationGroup="txtIccid" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col">
                            <asp:Label ID="mensajeExcepcion" runat="server" Text=""></asp:Label>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
