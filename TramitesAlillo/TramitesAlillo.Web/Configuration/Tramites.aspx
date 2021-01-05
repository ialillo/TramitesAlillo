<%@ Page Title="" Language="C#" MasterPageFile="~/TramitesAlillo.Master" AutoEventWireup="true" CodeBehind="Tramites.aspx.cs" Inherits="TramitesAlillo.Web.Configuration.Tramites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AlilloHeaderPH" runat="server">
    <link rel="stylesheet" href="../Styles/Bootstrap/bootstrapValidator.min.css" type="text/css" />
    <link rel="stylesheet" href="../Components/DataTables/css/jquery.dataTables.min.css" type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/Configuration/Tramites.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AlilloBodyPH" runat="server">
    <asp:ScriptManager ID="smTramiteEspecificacion" runat="server" LoadScriptsBeforeUI="false">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/Bootstrap/bootstrapValidator.min.js" />
            <asp:ScriptReference Path="~/Components/DataTables/js/jquery.dataTables.min.js" />
        </Scripts>
    </asp:ScriptManager>

    <div class="page-header">Configuraci&oacute;n De Tramites</div>
    <div id="contentBody">
        <div>
            <button id="btnAltaConfiguracion" type="button" class="btn btn-success btn-sm right">
                <span class="glyphicon glyphicon-user"></span> Nueva Configuraci&oacute;n
            </button>
        </div>
    </div>
</asp:Content>
