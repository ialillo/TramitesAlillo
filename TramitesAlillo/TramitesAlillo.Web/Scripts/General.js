var tramitesAlilloObjects = {
    UsuarioEnSesion: {},
    BaseURL: null,
    regExValidators: {
        // Regresa verdadero si es un password válido.
        validPassword: function (str) {
            // Por lo menos un numero, por lo menos una letra minuscula y una mayuscula
            // Por lo menos 6 caracteres
            var re = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}/;

            return re.test(str);
        },
        // Regresa verdadero si la cadena está vacía.
        emptyString: function (str) {
            var re = /^$/;

            return re.test(str);
        },
        // Regresa verdadero si la cadena no contiene espacios en blanco.
        noWhiteSpaces: function(str){
            var re = /^[\S]*$/;

            return re.test(str);
        },
        // Regresa verdadero si el formato del email es válido.
        validEmail: function (str) {
            var re = /^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$/;

            return re.test(str);
        }
    },
    Services: {
        URLs: {
            Seguridad: {
                subURL: "Services/Security",
                authenticate: "/Authenticate",
                changePassword: "/ChangePassword",
                currentUser: "/CurrentSessionUser"
            },
            UserManagement: {
                subUrl: "Services/Security.UserManagement",
                getUsers: "/GetUsersFromDB",
                getProfiles: "/GetProfiles",
                getUser: "/GetUserById",
                newUser: "/SaveNewUser",
                editUser: "/SaveUser",
                deleteUser: "/DeactivateUser"
            },
            Navegacion: {
                subURL: "Services/Navegation",
                getMenu: "/GetMenu"
            },
            Configuracion: {
                subURL: "Services/Configuration",
                getTramiteEspecificacionList: "/GetTramiteEspecificacionList",
                insertTramiteEspecificacion: "/SaveTramiteConfiguracion"
            },
            Catalogos: {
                subURL: "Services/Catalogs.Selects",
                getEntidadesTramiteSelect: "/GetEntidadTramiteList",
                getTipoTramiteSelect: "/GetTipoTramiteList",
                getRequerimientoTramiteSelect: "/GetRequerimientoTramiteList",
                getRequerimientoTramiteTipoEntregaSelect: "/GetRequerimientoTramiteTipoEntregaList"
            }
        }
    },
    GlobalMessage: {
        autoHide: true,
        timeToHideInSeconds: 8,
        selectors: {
            containerId: "#globalMessageContainer",
            alertId: "#alertDiv",
            messageId: "#alertMessage",
        },
        alertHTMLString: "<div id='alertDiv' class='alert alert-dismissable' style='display:none;'></div>",
        Create: function () {
            $(this.selectors.containerId).append(this.alertHTMLString);
        },
        Show: function (message, errorStyle) {

            // Quitamos todos los estilos que pueda tener el mensaje
            $(this.selectors.alertId).removeClass("alert-danger");
            $(this.selectors.alertId).removeClass("alert-success");

            // Vemos que estilo va a tener el mensaje, si un estilo de error o de exito
            if (errorStyle) {
                $(this.selectors.alertId).addClass("alert-danger");
            } else {
                $(this.selectors.alertId).addClass("alert-success");
            }

            // Cambiamos el texto de la etiqueta del mesnaje y mostramos el mensaje
            $(this.selectors.alertId).html(message);
            $(this.selectors.alertId).show();

            // Si se especifica que el mensaje se auto oculte se hace un time out en el tiempo especificado en segundos, el valor default es 3
            if (this.autoHide) {
                setTimeout(function () {
                    tramitesAlilloObjects.GlobalMessage.Hide();
                }, (this.timeToHideInSeconds * 1000))
            }
        },
        Hide: function () {
            $(this.selectors.alertId).hide();
        }
    },
    PopUp: {
        popBootStrapSettigs: {
            title: "",
            placement: "",
            html: true,
            selector: "",
            content: ""
        },
        linkedControlId: "",
        Show: function (linkedControlId, title, placement, popUpHTML, autoHide, timeToHideInSeconds) {
            this.popBootStrapSettigs.title = "<strong>" + title + "</strong>";
            this.popBootStrapSettigs.placement = placement;
            this.popBootStrapSettigs.content = popUpHTML;
            this.linkedControlId = linkedControlId;

            $(linkedControlId).popover(this.popBootStrapSettigs);
            $(linkedControlId).popover("show");

            if (autoHide) {
                setTimeout(function () {
                    tramitesAlilloObjects.PopUp.Hide();
                }, timeToHideInSeconds * 1000)
            }
        },
        Hide: function () {
            $(this.linkedControlId).popover("hide");
            $(this.linkedControlId).popover("destroy");
        }
    },
    LoadingModal: {
        selectors: {
            lmId: "#modalLoading",
            lmTitle: "Loading...",
            lmBody: "div[class='modal-body']",
            lmFooter: "div[class='modal-footer']"
        },
        lmHtmlString: "<div class='modal fade' id='modalLoading' tabindex='0' role='dialog' aria-labelledby='dialogTitle' aria-hidden='true'>" +
            "<div class='modal-dialog'><div class='modal-content'><div class='modal-header'><h3>Processing...</h3></div>" +
            "<div class='modal-body'><div class='progress'>" +
            "<div class='progress-bar progress-bar-striped progress-bar-animated' role='progressbar' aria-valuenow='80' aria-valuemin='0' aria-valuemax='100' style='width: 100%;'>" +
            "</div></div></div></div></div></div>",
        Show: function () {
            if ($("#modalLoading").length <= 0)
            {
                $("body").append(this.lmHtmlString);
                $("#modalLoading").modal({ backdrop: 'static', keyboard: false });
            }
            $("#modalLoading").modal("show");
        },
        Hide: function () {
            $("#modalLoading").modal("hide");
        }
    },
    Modal: {
        autoHide: false,
        timeToHideInSeconds: 3,
        selectors: {
            myModal: "#mG",
            modalTitle: "#mT",
            modalBody: "#mB",
            modalFooter: "#mF"
        },
        Create: function (parentSelector, title, body, footer, idModal) {

            var modalBaseHTML = "<div class='modal fade' id='mG' tabindex='-1' role='dialog' aria-labelledby='dialogTitle' aria-hidden='true'><div class='modal-dialog'>" +
            "<div class='modal-content'><div class='modal-header'><h5 class='modal-title' id='mT'></h5></div><div id='mB' class='modal-body'></div>" +
            "<div id='mF' class='modal-footer'></div></div></div></div>";

            this.selectors.myModal = "#mG" + idModal;
            this.selectors.modalTitle = "#mT" + idModal;
            this.selectors.modalBody = "#mB" + idModal;
            this.selectors.modalFooter = "#mF" + idModal;

            modalBaseHTML = modalBaseHTML.replace("mG", "mG" + idModal);
            modalBaseHTML = modalBaseHTML.replace("mT", "mT" + idModal);
            modalBaseHTML = modalBaseHTML.replace("mB", "mB" + idModal);
            modalBaseHTML = modalBaseHTML.replace("mF", "mF" + idModal);

            $(this.selectors.myModal).remove();
            $(parentSelector).append(modalBaseHTML);
            $(this.selectors.modalTitle).html("<strong>" + title + "</strong>");
            $(this.selectors.modalBody).html(body);
            if (footer) {
                $(this.selectors.modalFooter).html(footer);
            } else {
                $(this.selectors.modalFooter).remove();
            }
        },
        Show: function (idModal) {
            idModal = "#mG" + idModal;

            $(idModal).modal({backdrop: 'static', keyboard: false});
            $(idModal).modal("show");

            if (this.autoHide) {
                setTimeout(function () {
                    tramitesAlilloObjects.Modal.Hide(idModal);
                }, this.timeToHideInSeconds * 1000)
            }
        },
        Hide: function (idModal) {
            idModal = "#mG" + idModal;

            $(idModal).modal("hide");
        }
    },
    Tools: {
        Redirectors: {
            RedirectToLogin: function () {
                window.location.href = tramitesAlilloObjects.BaseURL + "Login.aspx";
            },
            RedirectToHome: function () {
                window.location.href = tramitesAlilloObjects.BaseURL + "Home.aspx";
            }
        },
        HTMLControls: {
            FormGroups: {
                codeSnippets: {
                    openFormHorizontalContainer: "<form id='chattiesForm' class='form-horizontal' role='form'>",
                    closeFormHorizontalContainer: "</form>",
                    openFormContainer: "<form id='chattiesForm' class='form' role='form'>",
                    closeFormContainer: "</form>",
                    openFormGroup: "<div class='form-group'>",
                    closeFormGroup: "</div>",
                    openInputGroupContainer: "<div class='input-group col-xs-12 col-sm-12 col-md-12 col-lg-12'>",
                    closeInputGroupContainer: "</div>",
                    blankSpace: "&nbsp;",
                    modalBodyOpener: "<div class='form' role='form'>",
                    modalBodyCloser: "</div>"
                },
                labelWithTextBox: function(labelText, txtBoxId, txtBoxPlaceHolder, txtBoxMinLength, txtBoxMaxLength){
                    var htmlToReturn = "";

                    htmlToReturn += this.codeSnippets.openFormGroup;
                    htmlToReturn += "<label for='" + txtBoxId + "' class='control-label'>" + labelText + "</label>";
                    htmlToReturn += this.codeSnippets.openInputGroupContainer;
                    htmlToReturn += "<input type='text' id='" + txtBoxId + "' name='" + txtBoxId + "' class='form-control' placeholder='" + txtBoxPlaceHolder + "' " +
                        "maxlength='" + txtBoxMaxLength + "' data-minlength='" + txtBoxMinLength + "'></input>";
                    htmlToReturn += this.codeSnippets.closeInputGroupContainer;
                    htmlToReturn += this.codeSnippets.closeFormGroup;

                    return htmlToReturn;
                },
                labelWithEmail: function (labelText, txtBoxId, txtBoxPlaceHolder, txtBoxMaxLength) {
                    var htmlToReturn = "";

                    htmlToReturn += this.codeSnippets.openFormGroup;
                    htmlToReturn += "<label for='" + txtBoxId + "' class='control-label'>" + labelText + "</label>";
                    htmlToReturn += this.codeSnippets.openInputGroupContainer;
                    htmlToReturn += "<input type='email' id='" + txtBoxId + "' name='" + txtBoxId + "' class='form-control' placeholder='" + txtBoxPlaceHolder + "'" +
                        "maxlength='" + txtBoxMaxLength + "' data-error='Email no valido'></input>";
                    htmlToReturn += this.codeSnippets.closeInputGroupContainer;
                    htmlToReturn += this.codeSnippets.closeFormGroup;

                    return htmlToReturn;
                },
                labelWithSelect: function (labelText, selectId, selectArray) {
                    var htmlToReturn = "";

                    htmlToReturn += this.codeSnippets.openFormGroup;
                    htmlToReturn += "<label for='" + selectId + "'>" + labelText + "</label>";
                    htmlToReturn += this.codeSnippets.openInputGroupContainer;
                    htmlToReturn += "<select id='" + selectId + "' name='" + selectId + "' class='form-control'>";

                    $(selectArray).each(function (cont, element) {
                        var valor = String(element.Value) === "0" ? "" : String(element.Value);
                        htmlToReturn += "<option value='" + valor + "'>" + element.Description + "</option>";
                    });

                    htmlToReturn += "</select>";
                    htmlToReturn += this.codeSnippets.closeInputGroupContainer;
                    htmlToReturn += this.codeSnippets.closeFormGroup;

                    return htmlToReturn;
                },
                labelWithCheckBox: function (labelText, checkId) {
                    var htmlToReturn = "";

                    htmlToReturn += this.codeSnippets.openFormGroup;
                    htmlToReturn += "<input type='checkbox' id='" + checkId + "' name='" + checkId + "' class='form-check'>";
                    htmlToReturn += "<label class='chkLabel'>" + labelText + "</label>";
                    htmlToReturn += this.codeSnippets.closeFormGroup;

                    return htmlToReturn;

                }
            }
        }
    }
};

// Funciones y acciones iniciales
$(document).ready(function () {
    tramitesAlilloObjects.BaseURL = document.location.protocol + "//" + document.location.host + "/";
});