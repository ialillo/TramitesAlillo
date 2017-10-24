<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TramitesAlillo.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tramites Alillo</title>
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Pacifico" rel="stylesheet">
    <link href="<%= ResolveUrl("~/Styles/Bootstrap/bootstrap.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/Styles/Login.css") %>" rel="stylesheet" />

    <script src="<%= ResolveUrl("~/Scripts/JQuery/jquery-2.1.0.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/Bootstrap/bootstrap.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/JSON2/json2.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/JSON2/JSONHelper.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/General.js?<?=time()?") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/Login/Login.js?<?=time()?") %>" type="text/javascript"></script>
</head>
<body>
    <div class="container vertical-center">
        <form  class="form-signin">
            <h2 class="form-signin-heading">Tramites Alillo</h2>  
            <input id="txtUsuario" type="text" class="form-control input-sm" placeholder="Usuario" required autofocus />
            <input id="txtPassword" type="password" class="form-control input-sm" placeholder="Contraseña" required />
            <button type="button" id="btnLogin" class="btn btn-lg btn-primary btn-block">Login</button>
        </form>
        <div id="globalMessageContainer" class='navbar-fixed-bottom col-sm-6 col-sm-offset-3 col-md-8 col-md-offset-2 col-lg-8 col-lg-offset-2'></div>
    </div>
</body>
</html>
