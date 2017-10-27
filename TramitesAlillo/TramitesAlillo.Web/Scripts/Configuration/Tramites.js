var tramiteEspecificacionObjects = {
    escribeTablaTramitesEspecificacion: function (serviceResult) {
        if (serviceResult.Success) {
            $("#tblTramitesEspecificaciones").parent().remove();

            var tramitesEspecificaciones = serviceResult.Object.TramiteEspecificacion;
            var htmlTable = "";

            htmlTable += "<table id='tblTramitesEspecificaciones' class='display' cellspacing='0' width='100%'>";

            htmlTable += "<thead>";
            htmlTable += "<tr><th>Entidad</th><th>Tipo Tramite</th><th>Requerimiento</th><th>Tipo Entrega Requerimiento</th><th>Persona Moral</th><th>Carga</th><th>Fecha Creacion</th></tr>";
            htmlTable += "</thead>";

            htmlTable += "<tbody>";

            $(tramitesEspecificaciones).each(function (cont, tramiteEsp) {

                var esPersonaMoral = tramiteEsp.PersonaMoral ? "Si" : "No";
                var esCarga = tramiteEsp.Carga ? "Si" : "No";

                htmlTable += "<tr>";
                htmlTable += "<td>" + tramiteEsp.NombreEntidadTramite + "</td>";
                htmlTable += "<td>" + tramiteEsp.NombreTipoTramite + "</td>";
                htmlTable += "<td>" + tramiteEsp.NombreRequerimientoTramite + "</td>";
                htmlTable += "<td>" + tramiteEsp.NombreRequerimientoTramiteTipoEntrega + "</td>";
                htmlTable += "<td>" + esPersonaMoral + "</td>";
                htmlTable += "<td>" + esCarga + "</td>";
                htmlTable += "<td>" + tramiteEsp.FechaInicioVigencia + "</td>";
                htmlTable += "</tr>"
            });

            htmlTable += "</tobdy>";
            htmlTable += "</table>";

            $("#contentBody:first").append(htmlTable);
            $("#tblTramitesEspecificaciones").dataTable({ ordering: false, bSort: false, bLengthChange: false, iDisplayLength: 10, sPaginationType: "full_numbers" });
        }
        else {
            tramitesAlilloObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
        }
    }
}

$(document).ready(function () {
    doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.Configuracion.subURL, tramitesAlilloObjects.Services.URLs.Configuracion.getTramiteEspecificacionList, {},
        tramiteEspecificacionObjects.escribeTablaTramitesEspecificacion);
});