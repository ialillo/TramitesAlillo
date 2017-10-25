var tramiteEspecificacionObjects = {
    escribeTablaTramitesEspecificacion: function (serviceResult) {
        if (serviceResult.Success) {
            $("#tblTramitesEspecificaciones").parent().remove();

            var htmlTable = "";

            htmlTable += "<table id='tblTramitesEspecificaciones' class='display' cellspacing='0' width='100%'>";

            htmlTable += "<thead>";
            htmlTable += "<tr><th>Entidad</th><th>Tipo Tramite</th><th>Requerimiento</th><th>Tipo Entrega Requerimiento</th><th>Persona Moral</th><th>Carga</th><th>Fecha Creacion</th></tr>";
            htmlTable += "</thead>";

            htmlTable += "<tbody>";
            htmlTable += "";
        }
        else {
            tramitesAlilloObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
        }
    }
}

$(document).ready(function () {
    doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.Configuracion.subURL, tramitesAlilloObjects.Services.URLs.Configuracion.getTramiteEspecificacionList, {},
        tramiteEspecificacionObjects);
});