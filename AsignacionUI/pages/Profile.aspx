<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="AsignacionUI.pages.Profile" %>

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
                                </div>

                            </div>
                        </div>
                        <div class="card-body ">
                                <h6 class="heading-small text-muted mb-4">Informacion Usuario</h6>
                                <div class="pl-lg-4">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">


                                                <label class="form-control-label" for="input-username">Nombre De Usuario</label>
                                                <input type="text" id="input-username" class="form-control">
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="input-email">Email </label>
                                                <input type="email" id="input-email" class="form-control">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="input-first-name">Nombre</label>
                                                <input type="text" id="input-first-name" class="form-control">
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="input-last-name">Apellido</label>
                                                <input type="text" id="input-last-name" class="form-control">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="d-flex justify-content-center">
                                    <a href="#!" class="btn btn-neutral">Editar perfil</a>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
