<%@ Page Title="" Language="C#" MasterPageFile="~/TramitesAlillo.Master" AutoEventWireup="true" CodeBehind="Tramites.aspx.cs" Inherits="TramitesAlillo.Web.Configuration.Tramites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AlilloHeaderPH" runat="server">
    <link rel="stylesheet" href="../Styles/Bootstrap/bootstrapValidator.min.css" type="text/css" />
    <link rel="stylesheet" href="../Components/DataTables/css/jquery.dataTables.min.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AlilloBodyPH" runat="server">
    <asp:ScriptManager ID="smTramiteEspecificacion" runat="server" LoadScriptsBeforeUI="true">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/Bootstrap/bootstrapValidator.min.js" />
            <asp:ScriptReference Path="~/Components/DataTables/js/jquery.dataTables.min.js" />
            <asp:ScriptReference Path="~/Scripts/Configuration/Tramites.js" />
        </Scripts>
    </asp:ScriptManager>

    <div class="page-header">Configuracion De Tramites</div>
    <div id="contentBody">
        <div>
            <button type="button" class="btn btn-success btn-sm right" onclick="tramiteEspecificacionObjects.Modal.altaConfiguracion()">
                <span class="glyphicon glyphicon-user"></span> Nueva Configuracion
            </button>
        </div>
    </div>
</asp:Content>
