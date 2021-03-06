<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AsignacionUI.pages.Login" %>

<!DOCTYPE html>

<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Start your development with a Dashboard for Bootstrap 4.">
    <meta name="author" content="Creative Tim">
      <title>SER COMUNICACIONES</title>
    <!-- Favicon -->
    <link rel="icon" href="../assets/img/brand/favicon.png" type="image/png">
    <!-- Fonts -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700">
    <!-- Icons -->
    <link rel="stylesheet" href="../assets/vendor/nucleo/css/nucleo.css" type="text/css">
    <link rel="stylesheet" href="../assets/vendor/@fortawesome/fontawesome-free/css/all.min.css" type="text/css">
    <!-- Argon CSS -->
    <link rel="stylesheet" href="../assets/css/argon.css?v=1.2.0" type="text/css">

    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
</head>


<body class="bg-default">

    <!-- Main content -->
    <div class="main-content">
        <!-- Header -->
        <div class="header bg-gradient-primary py-7 py-lg-8 pt-lg-9">
            <div class="container">
            </div>
            <div class="separator separator-bottom separator-skew zindex-100">
                <svg x="0" y="0" viewBox="0 0 2560 100" preserveAspectRatio="none" version="1.1" xmlns="http://www.w3.org/2000/svg">
                    <polygon class="fill-default" points="2560 0 2560 100 0 100"></polygon>
                </svg>
                  
            </div>
              <div class="header-body text-center">
                        <div class="row justify-content-center">
                             <img alt="Image placeholder" src="../assets/img/theme/sercomunicaciones.png">
                        </div>
                    </div> 
        </div>
         
        <!-- Page content -->
        <div class="container mt--8">
            <div class="row justify-content-center">
                <div class="col-lg-5 col-md-7 pb-5">
                    
                    <div class="card bg-secondary border-0 mb-0">
                        <div class="card-body px-lg-5 py-lg-5">
                        
                            <div class="text-center text-muted mb-4">
                                <h1>Inciar Sesion</h1>
                            </div>
                            <p>
                                <asp:Literal runat="server" ID="Mensaje" />
                            </p>
                            <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false"></asp:PlaceHolder>
                            <form runat="server">
                                <div class="form-group mb-3">
                                    <label class="form-control-label" for="input-username">Email</label>
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmail" runat="server" ErrorMessage="* Campo Obligatorio"></asp:RequiredFieldValidator>

                                </div>
                                <div class="form-group">
                                    <label class="form-control-label" for="input-username">Contraseña</label>
                                    <asp:TextBox ID="txtContraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtContraseña" runat="server" ErrorMessage="* Campo Obligatorio"></asp:RequiredFieldValidator>

                                </div>
                                <div class="text-center">
                                    <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesion" CssClass="btn btn-primary my-4" OnClick="btnLogin_Click" />
                                </div>

                            </form>
                            <div>
                                <asp:Label ID="mensajeExcepcion" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>
    <script src="../assets/vendor/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="../assets/vendor/js-cookie/js.cookie.js"></script>
    <script src="../assets/vendor/jquery.scrollbar/jquery.scrollbar.min.js"></script>
    <script src="../assets/vendor/jquery-scroll-lock/dist/jquery-scrollLock.min.js"></script>
    <!-- Argon JS -->
    <script src="../assets/js/argon.js?v=1.2.0"></script>

</body>

</html>
