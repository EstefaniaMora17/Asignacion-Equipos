<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="    .cs" Inherits="AsignacionUI.Users.AdministracionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content" id="panel">
        <!-- Page content -->
        <div class="container-fluid mt--6 padinnProfile">
            <div class="row">
                <div class="col-xl-4 order-xl-2">
                    <div class="card card-profile">
                        <img src="../assets/img/theme/img-1-1000x600.jpg" alt="Image placeholder" class="card-img-top">
                        <div class="row justify-content-center">
                            <div class="col-lg-3 order-lg-2">
                                <div class="card-profile-image">
                                    <a href="#">
                                        <img src="../assets/img/theme/team-4.jpg" class="rounded-circle">
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                            <div class="card-body pt-0">

                                <div class="text-center pt-6">
                                    <h5 class="h3">Jessica Jones<span class="font-weight-light">, 27</span>
                                    </h5>
                                    <div class="h5 font-weight-300">
                                        <i class="ni location_pin mr-2"></i>Bucharest, Romania
               
                                    </div>
                                    <div class="h5 mt-4">
                                        <i class="ni business_briefcase-24 mr-2"></i>Solution Manager - Creative Tim Officer
               
                                    </div>
                                    <div>
                                        <i class="ni education_hat mr-2"></i>University of Computer Science
               
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-xl-8 order-xl-1">
                    <div class="card padinginInfo">
                        <div class="card-header">
                            <div class="row align-items-center">
                                <div class="col-8">
                                    <h3 class="mb-0">Editar Perfil</h3>
                                    <asp:Literal runat="server" ID="Mensaje" />
                                </div>

                            </div>
                        </div>
                        <div class="card-body ">
                            <div>
                                <h6 class="heading-small text-muted mb-4">Informacion Usuario</h6>
                                <div class="pl-lg-4">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">


                                                <label class="form-control-label" for="input-username">Email</label>
                                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmail" runat="server" ErrorMessage="* Campo Obligatorio"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="input-email">Rol </label>
                                                <asp:DropDownList ID="dllRol" CssClass="select2_single form-control" runat="server">
                                                    <asp:ListItem Value="1">Soporte</asp:ListItem>
                                                    <asp:ListItem Value="2">Usuarios Administrativos</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ValidationGroup="AsignarRoL" ID="RequiredFieldValidator4" runat="server" ControlToValidate="dllRol" InitialValue="0" ErrorMessage="* Campo Obligatorio" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="input-first-name">Contraseña</label>
                                                <asp:TextBox ID="txtContraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtContraseña" runat="server" ErrorMessage="* Campo Obligatorio"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="input-last-name">Confirmar Contraseña</label>
                                                <asp:TextBox ID="txtCcontraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCcontraseña" runat="server" ErrorMessage="* Campo Obligatorio"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="d-flex justify-content-center">
                                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary my-4" OnClick="btnRegistrar_Click" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

