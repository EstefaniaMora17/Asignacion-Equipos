<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroRol.aspx.cs" Inherits="AsignacionUI.Users.RegistroRol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5 ">
            <div class="">
                <h1 class="text-center">Cracion De Rol
                </h1>

                <hr />
                <h5 class="text-center " style="color: red">
                    <asp:Label ID="lblMensaje" runat="server"> </asp:Label>
                </h5>
                <h5 class="text-center " style="color: red">
                    <asp:Label ID="mensajeExcepcion" runat="server"> </asp:Label>
                </h5>
                
                <div class="d-flex justify-content-center">
                    <div class="form-group col-md-6 ">
                        <label class="form-control-label" style="font-size: 25px" id="lblRol" runat="server">Rol</label>
                        <asp:TextBox ID="txtRol" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="d-flex justify-content-center mt-5  col-md-12">
                    <asp:Button ID="btnCrearRol" runat="server" Text="Crear Rol" CssClass="btn btn-outline-danger" OnClick="btnCrearRol_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
