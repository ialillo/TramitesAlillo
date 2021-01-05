var tramiteEspecificacionObjects = {
    //Creamos una bandera para saber si los catalogos estan listos
    catalogosListos : false,
    // Se crean los objetos en donde almacenaremos los objetos para llenar los selects del modal
    EntidadesFederativas: {},
    TipoTramites: {},
    RequerimientosTramites: {},
    RequerimientosTipoTramitesEntrega: {},
    obtenListaTramitesEspecificacion: function () {
        doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.Configuracion.subURL, tramitesAlilloObjects.Services.URLs.Configuracion.getTramiteEspecificacionList, {},
        tramiteEspecificacionObjects.escribeTablaTramitesEspecificacion);
    },
    // Funcion que dibuja la tabla incial de configuracion de tramites
    escribeTablaTramitesEspecificacion: function (serviceResult) {
        if (serviceResult.Success) {
            $("#tblTramitesEspecificaciones").parent().remove();

            var tramitesEspecificaciones = serviceResult.Object == null ? [] :  serviceResult.Object.TramitesEspecificaciones;
            var htmlTable = "";

            htmlTable += "<table id='tblTramitesEspecificaciones' class='display' cellspacing='0' width='100%'>";

            htmlTable += "<thead>";
            htmlTable += "<tr><th>Entidad</th><th>Tipo Tramite</th><th>Requerimiento</th><th>Tipo Entrega Requerimiento</th><th>Persona Moral</th><th>Carga</th><th>Fecha Creacion</th></tr>";
            htmlTable += "</thead>";

            htmlTable += "<tbody>";

            $(tramitesEspecificaciones).each(function (cont, tramiteEsp) {

                var esPersonaMoral = tramiteEsp.PersonaMoral ? "<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" :
                                     "<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>";
                var esCarga = tramiteEsp.Carga ? "<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" :
                              "<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>";

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

        //Llamamos a la funcion para inicializar los objetos que contendran la informacion que se despliega en el modal
        if (!tramiteEspecificacionObjects.catalogosListos) {
            tramiteEspecificacionObjects.Modal.altaConfiguracion();
        }
    },
    //Funcion que inserta una nueva especificacion de tramite
    InsertaTramiteEspecificacion: function () {

        var tramiteEspecificacion = {
            idEntidadTramite: $("#selEntidadTramite").val(),
            idTipoTramite: $("#selTipoTramite").val(),
            idRequerimientoTramite: $("#selRequerimientoTramite").val(),
            idRequerimientoTramiteTipoEntrega: $("#selRequerimientoTramiteTipoEntrega").val(),
            personaMoral : $("#chkPersonaMoral").prop("checked") ? 1 : 0,
            carga : $("#chkCarga").prop("checked") ? 1 : 0
        }

        //Guardamos la nueva especificacion de tramite
        doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.Configuracion.subURL,
            tramitesAlilloObjects.Services.URLs.Configuracion.insertTramiteEspecificacion, tramiteEspecificacion,
            tramiteEspecificacionObjects.RegresaInsertaTramiteEspecificacion);
    },
    RegresaInsertaTramiteEspecificacion: function (serviceResult) {
        if (serviceResult.Success) {
            tramitesAlilloObjects.Modal.Hide();
            tramiteEspecificacionObjects.obtenListaTramitesEspecificacion();
        }
        else {
            tramitesAlilloObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
        }
    },
    Modal: {
        altaConfiguracion: function () {
            //Llenamos el objeto de Entidades Federativas
            doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.Catalogos.subURL, tramitesAlilloObjects.Services.URLs.Catalogos.getEntidadesTramiteSelect, {},
                tramiteEspecificacionObjects.Modal.guardaEntidadesTramite);
        },
        creaModalConfiguracion: function () {
            // Establecemos el titulo del modal
            var modalTitle = "Nueva Configuraci&oacute;n de Tr&aacute;mite";
            var modalBody = "";
            var modalFooter = "";
            var idModalConfig = "modalConfig"

            //Establecemos el cuerpo del modal
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.codeSnippets.modalBodyOpener;
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.labelWithSelect("Entidad Federativa", "selEntidadTramite",
                tramiteEspecificacionObjects.EntidadesFederativas);
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.labelWithSelect("Tipo de tramite", "selTipoTramite",
                tramiteEspecificacionObjects.TipoTramites);
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.labelWithSelect("Requerimiento del tramite", "selRequerimientoTramite",
                tramiteEspecificacionObjects.RequerimientosTramites);
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.labelWithSelect("Tipo de entrega del requerimiento", "selRequerimientoTramiteTipoEntrega",
                tramiteEspecificacionObjects.RequerimientosTipoTramitesEntrega);
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.labelWithCheckBox("Persona Moral", "chkPersonaMoral");
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.labelWithCheckBox("Tramite de Carga", "chkCarga");
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.codeSnippets.modalBodyCloser;

            modalFooter += "<button id='btnGuardar' type='button' class='btn btn-primary'>Guardar</button>";
            modalFooter += "<button id='btnCancelar' type='button' class='btn btn-default'>Cancelar</button>";

            tramitesAlilloObjects.Modal.Create("body", modalTitle, modalBody, modalFooter, idModalConfig);

            // Le agregamos el evento click al boton de cancelar del modal
            $("#btnCancelar").bind("click", function (event) {
                tramitesAlilloObjects.Modal.Hide(idModalConfig);
            });
            // Le agregamos el event click al boton de guardar del modal
            $("#btnGuardar").bind("click", function (event) {
                tramiteEspecificacionObjects.InsertaTramiteEspecificacion();
            });
            // Le agregamos el evento click al boton de nueva configuracion del modal
            $("#btnAltaConfiguracion").bind("click", function (event) {
                tramitesAlilloObjects.Modal.Show(idModalConfig);
            });

            //Establecemos bandera de que los catalogos estan llenos
            tramiteEspecificacionObjects.catalogosListos = true;
        },
        guardaEntidadesTramite: function (serviceResult) {
            if (serviceResult.Success) {
                tramiteEspecificacionObjects.EntidadesFederativas = [];
                tramiteEspecificacionObjects.EntidadesFederativas = serviceResult.Object == null ? [] : serviceResult.Object.SelectItems;
            }
            else {
                tramitesAlilloObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
            }
            //Llenamos el objeto de Tipo de Tramite
            doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.Catalogos.subURL, tramitesAlilloObjects.Services.URLs.Catalogos.getTipoTramiteSelect, {},
                tramiteEspecificacionObjects.Modal.guardaTipoTramite);
        },
        guardaTipoTramite: function (serviceResult) {
            if (serviceResult.Success) {
                tramiteEspecificacionObjects.TipoTramites = [];
                tramiteEspecificacionObjects.TipoTramites = serviceResult.Object == null ? [] : serviceResult.Object.SelectItems;
            }
            else {
                tramitesAlilloObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
            }
            //Llenamos el objeto de Requerimiento Tramite
            doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.Catalogos.subURL, tramitesAlilloObjects.Services.URLs.Catalogos.getRequerimientoTramiteSelect, {},
                tramiteEspecificacionObjects.Modal.guardaRequerimientoTramite);
        },
        guardaRequerimientoTramite: function (serviceResult) {
            if (serviceResult.Success) {
                tramiteEspecificacionObjects.RequerimientosTramites = [];
                tramiteEspecificacionObjects.RequerimientosTramites = serviceResult.Object == null ? [] : serviceResult.Object.SelectItems;
            }
            else {
                tramitesAlilloObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
            }
            //Llenamos el objeto de Requerimiento Tramite Tipo Entrega
            doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.Catalogos.subURL, tramitesAlilloObjects.Services.URLs.Catalogos.getRequerimientoTramiteTipoEntregaSelect, {},
                tramiteEspecificacionObjects.Modal.guardaRequerimientoTramiteTipoEntrega);
        },
        guardaRequerimientoTramiteTipoEntrega: function (serviceResult) {
            if (serviceResult.Success) {
                tramiteEspecificacionObjects.RequerimientosTipoTramitesEntrega = [];
                tramiteEspecificacionObjects.RequerimientosTipoTramitesEntrega = serviceResult.Object == null ? [] : serviceResult.Object.SelectItems;
            }
            else {
                tramitesAlilloObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
            }
            //Creamos el modal
            tramiteEspecificacionObjects.Modal.creaModalConfiguracion();
        }
    }
}

// Funcion que se inicia antes de que cargue la pagina
$(document).ready(function () {
    tramiteEspecificacionObjects.obtenListaTramitesEspecificacion();
});