var admonUsuarios = {
    objects:{
        perfiles: new Object,
        currentUserId: 0
    },
    establecePerfiles: function (serviceResult) {
        //Si la llamada al servicio traé un error, lo mostramos
        if (!serviceResult.Success) {
            //Mostramos el mensaje del error.
            tramitesAlilloObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
            //Salimos de la función.
            return;
        }

        // Guardamos los perfiles en una arreglo global
        admonUsuarios.objects.perfiles = serviceResult.Object.Perfiles;
        
        //Traemos la lista de usuarios activos de la base de datos
        admonUsuarios.traerUsuarios();
    },
    traerUsuarios: function () {
        //Traemos a todos los usuarios activos de la base de datos
        doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.UserManagement.subUrl, tramitesAlilloObjects.Services.URLs.UserManagement.getUsers, {}, admonUsuarios.escribeTablaUsuarios);
    },
    escribeTablaUsuarios: function (serviceResult) {
        if (serviceResult.Success) {

            //Eliminamos la tabla del dom si es que existe
            $("#tblUsuariosChatties").parent().remove();
            
            //Guardamos el arreglo de usuarios en una variable-
            var usuarios = serviceResult.Object.LoggedUsers;
            var htmlTable = "";

            //Construimos el html de los usuarios.
            htmlTable += "<table id='tblUsuariosChatties' class='display' cellspacing='0' width='100%'>";

            htmlTable += "<thead>";
            htmlTable += "<tr><th>Nombre</th><th>Perfil</th><th>Editar</th><th>Desactivar</th></tr>";
            htmlTable += "</thead>";

            htmlTable += "<tbody>";
            $(usuarios).each(function (cont, LoggedUser) {
                htmlTable += "<tr>";
                htmlTable += "<td>" + LoggedUser.Nombre + " " + LoggedUser.ApellidoPaterno + " " + LoggedUser.ApellidoMaterno + "</td>";
                htmlTable += "<td>" + LoggedUser.Perfil + "</td>";
                htmlTable += "<td><button data-userid='" + LoggedUser.Id + "' type='button' class='btn btn-primary btn-xs' onclick='admonUsuarios.Modal.editaUsuario(this);'><span class='glyphicon glyphicon-pencil'></span> Editar</button></td>";
                htmlTable += "<td><button data-userid='" + LoggedUser.Id + "' type='button' class='btn btn-danger btn-xs' onclick='admonUsuarios.Modal.bajaUsuario(this);'><span class='glyphicon glyphicon-remove-sign'></span> Desactivar</button></td>";
                htmlTable += "</tr>";
            });

            htmlTable += "</tbody>"
            htmlTable += "</table>"

            //Insertamos el HTML de la tabla.
            $("#contentBody:first").append(htmlTable);
            $("#tblUsuariosChatties").dataTable({ ordering: false, bSort: false, bLengthChange: false, iDisplayLength: 10, sPaginationType: "full_numbers"});
        }
        else {
            // Si existe un error en la llamada del servicio mostramos el mensaje de error
            tramitesAlilloObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
        }
    },
    Modal: {
        altaUsuario: function () {
            //Creamos el modal del usuario.
            this.creaModalUsuario(true);
            //Mostramos el modal con los controles necesarios.
            tramitesAlilloObjects.Modal.Show();
        },
        editaUsuario: function (btnUsuario) {
            // Creamos el modal con los controles default
            this.creaModalUsuario(false);
            //Establecemos el usuario que queremos editar
            admonUsuarios.objects.currentUserId = $(btnUsuario).data("userid");
            //Traemos la información del usuario seleccionado.
            doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.UserManagement.subUrl, tramitesAlilloObjects.Services.URLs.UserManagement.getUser, {idUsuario: admonUsuarios.objects.currentUserId}, this.llenaModalConDatosDeUsuario)
        },
        llenaModalConDatosDeUsuario: function (serviceResult) {
            //Si la llamada al servicio regresa un error lo mostramos.
            if (!serviceResult.Success) {
                //Mostramos el error de la llamada al servicio.
                tramitesAlilloObjects.GlobalMessage.Show(serviceResult.ServiceMessage, true);
                //Salimos de la función.
                return;
            }

            // Obtenemos el Objeto y se lo asignamos a una variable.
            var currentUser = serviceResult.Object;

            // Llenamos los datos del usuario.
            $("#txtNombre").val(currentUser.Nombre);
            $("#txtApPaterno").val(currentUser.ApellidoPaterno);
            $("#txtApMaterno").val(currentUser.ApellidoMaterno);
            $("#txtUsuario").val(currentUser.Usuario);
            $("#txtEmail").val(currentUser.Email);

            //Iteramos en el selector para establecer el perfil actual del usuario de la lista de perfiles.
            $("#selPerfiles").val(currentUser.IdPerfil);

            //Mostramos el modal con la información del usuario.
            tramitesAlilloObjects.Modal.Show();
        },
        bajaUsuario: function (btnUsuario) {
            var htmlModalBody = "";
            var htmlModalFooter = "";
            var fnDesactivaUsuario = "doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.UserManagement.subUrl, tramitesAlilloObjects.Services.URLs.UserManagement.deleteUser,";
            fnDesactivaUsuario += "{ idUsuario: " + $(btnUsuario).data("userid") + " }, admonUsuarios.Modal.guardarUsuario);";

            htmlModalBody = "<p>Est&aacute; seguro que desea desactivar al usuario " + $(btnUsuario).parent().parent().find("td:first").html() + "?";

            htmlModalFooter += "<button id='btnGuardar' type='button' class='btn btn-sm btn-primary' onclick='" + fnDesactivaUsuario + "'>Aceptar</button>";
            htmlModalFooter += "<button id='btnCancelar' type='button' class='btn btn-sm btn-default' onclick='tramitesAlilloObjects.Modal.Hide();'>Cancelar</button>";

            tramitesAlilloObjects.Modal.Create("body", "Desactiva Usuario", htmlModalBody, htmlModalFooter);
            tramitesAlilloObjects.Modal.Show();
        },
        creaModalUsuario: function (esAlta) {
            //Establecemos el titulo del modal.
            var modalTitle = esAlta ? "Alta de Usuario" : "Edici&oacute;n de Usuario";
            var modalBody = "";
            var modalFooter = "";
            var btnGuardarModifier = esAlta ? "A" : "E";

            //Establecemos el cuerpo del modal.
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.codeSnippets.openFormContainer;
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.labelWithTextBox("Nombre", "txtNombre", "Nombre", 2, 20, true);
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.labelWithTextBox("A Paterno", "txtApPaterno", "Apellido Paterno", 2, 20, true);
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.labelWithTextBox("A Materno", "txtApMaterno", "Apellido Materno", 2, 20, true);
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.labelWithTextBox("Usuario", "txtUsuario", "Usuario", 5, 10, true);
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.labelWithEmail("Email", "txtEmail", "e-mail", 30, true);
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.labelWithSelect("Perfiles", "selPerfiles", admonUsuarios.objects.perfiles);
            //Establecemos los botones del modal, tienen que estar en el body para que se pueda hacer la validación de manera correcta.
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.codeSnippets.openFormGroup;
            modalBody += "<button id='btnGuardar' data-modifier='" + btnGuardarModifier + "' type='submit' class='btn btn-sm btn-primary'>Guardar</button>";
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.codeSnippets.blankSpace;
            modalBody += "<button id='btnCancelar' type='button' class='btn btn-sm btn-default' onclick='tramitesAlilloObjects.Modal.Hide();'>Cancelar</button>";
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.codeSnippets.closeFormGroup;
            modalBody += tramitesAlilloObjects.Tools.HTMLControls.FormGroups.codeSnippets.closeFormContainer;

            //Insertamos el html del modal en el DOM
            tramitesAlilloObjects.Modal.Create("body", modalTitle, modalBody, modalFooter);

            // Si es edición no dejamos que modifiquen el usuario.
            if (!esAlta) {
                $("#txtUsuario").attr("disabled", "disabled");
            }

            // Establecemos las validaciones del modal.
            $("#chattiesForm").bootstrapValidator({
                fields: {
                    txtNombre: {
                        validators: {
                            notEmpty: {
                                message: "El Nombre es requerido."
                            }
                        }
                    },
                    txtApPaterno: {
                        validators: {
                            notEmpty: {
                                message: "El Apellido Paterno es requerido."
                            }
                        }
                    },
                    txtApMaterno: {
                        validators: {
                            notEmpty: {
                                message: "El Apellido Materno es requerido."
                            }
                        }
                    },
                    txtUsuario: {
                        validators: {
                            notEmpty: {
                                message: "El Usuario es requerido."
                            }
                        }
                    },
                    txtEmail: {
                        validators: {
                            notEmpty: {
                                message: "El Email es requerido."
                            },
                            emailAddress: {
                                message: "El Email proporcionado no es válido."
                            }
                        }
                    },
                    selPerfiles: {
                        validators: {
                            notEmpty: {
                                message: "Debe seleccionar un perfil."
                            }
                        }
                    }
                },
                //Se desencadena cuando pasa todas las validaciones.
                submitHandler: function (validator, form, submitButton) {
                    var user = {
                        user: {
                            Id: $("#btnGuardar").data("modifier") === "E" ? parseInt(admonUsuarios.objects.currentUserId) : 0,
                            ApellidoMaterno: $("#txtApMaterno").val(),
                            ApellidoPaterno: $("#txtApPaterno").val(),
                            Nombre: $("#txtNombre").val(),
                            Usuario: $("#txtUsuario").val(),
                            Email: $("#txtEmail").val(),
                            IdPerfil: $("#selPerfiles").val()
                        }
                    }

                    //Dependiendo del tipo de Edición hacemos la respectiva llamada.
                    switch ($("#btnGuardar").data("modifier")) {
                        case "A":
                            doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.UserManagement.subUrl, tramitesAlilloObjects.Services.URLs.UserManagement.newUser, user, admonUsuarios.Modal.guardarUsuario);
                            break;
                        case "E":
                            doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.UserManagement.subUrl, tramitesAlilloObjects.Services.URLs.UserManagement.editUser, user, admonUsuarios.Modal.guardarUsuario);
                            break;
                    }
                }
            });
        },
        guardarUsuario: function (serviceResult) {
            //Si hubo algun error se manda el mensaje correspondiente.
            if (!serviceResult.Success) {
                tramitesAlilloObjects.PopUp.Show("#btnGuardar", "Error", "top", serviceResult.ServiceMessage, true, 8);
                return;
            }

            tramitesAlilloObjects.Modal.Hide();
            tramitesAlilloObjects.GlobalMessage.Show(serviceResult.ServiceMessage, false);
            admonUsuarios.traerUsuarios();
        }
    }
}

// Funciones que se ejecutan al cargar la pagina
$(document).ready(function () {
    //Traemos los perfiles y los guardamos en un arreglo global
    doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.UserManagement.subUrl, tramitesAlilloObjects.Services.URLs.UserManagement.getProfiles, {}, admonUsuarios.establecePerfiles);
});