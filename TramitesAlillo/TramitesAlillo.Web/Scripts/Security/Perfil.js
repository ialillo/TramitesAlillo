var perfilObjects = {
    contCambioPass: 1,
    objCP: {},
    MuestraInfoUsuario: function (result) {
        if (result.Success) {
            $("#csNombre").html(result.Object.Nombre + ' ' + result.Object.ApellidoPaterno + ' ' + result.Object.ApellidoMaterno);
            $("#csEmail").html(result.Object.Email);
            $("#csPerfil").html(result.Object.Perfil);
        } else{
            tramitesAlilloObjects.Tools.Redirectors.RedirectToLogin();
        }
    },
    CambiaPassword: function () {
        if (this.ValidaContrasena()) {
            if (this.contCambioPass === 1) {
                this.objCP.oldPassword = $("#txtPassword").val();

                $("#txtPassword").val("");
                $("#txtPassword").attr("placeholder", "Escriba su contraseña nueva");
                this.contCambioPass += 1;
            }
            else {
                this.objCP.newPassword = $("#txtPassword").val();
                doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.Seguridad.subURL, tramitesAlilloObjects.Services.URLs.Seguridad.changePassword, this.objCP, this.CredencialesCorrectas);
            }
        }
    },
    CredencialesCorrectas: function (result) {
        if (!result.Success) {
            perfilObjects.ResetAllControls();
            tramitesAlilloObjects.GlobalMessage.Show(result.ServiceMessage, true);
        }
        else {
            perfilObjects.ResetAllControls();
            tramitesAlilloObjects.GlobalMessage.Show("La contraseña se cambio exitosamente", false);
        }
    },
    ResetAllControls: function () {
        this.contCambioPass = 1;
        $("#txtPassword").val("");
        $("#txtPassword").attr("placeholder", "Escriba su contraseña actual");
    },
    ValidaContrasena: function () {
        if ($("#txtPassword").val() == "") {
            tramitesAlilloObjects.PopUp.Show("#txtPassword", "Error", "bottom", "La contraseña no puede ser un texto en blanco", true, 3);
            $("#txtPassword").focus();
            return false;
        }
        else if (!tramitesAlilloObjects.regExValidators.validPassword($("#txtPassword").val())) {
            var mensajePopOver;
            mensajePopOver = "<ul>";
            mensajePopOver += "<li>Debe contener al menos 6 caracteres.</li>";
            mensajePopOver += "<li>Al menos un numero.</li>";
            mensajePopOver += "<li>Al menos una letra mayuscula.</li>";
            mensajePopOver += "<li>Al menos una letra minuscula.</li>";
            mensajePopOver += "</ul>";

            tramitesAlilloObjects.PopUp.Show("#txtPassword", "Requerimientos de Contraseña:", "bottom", mensajePopOver, true, 8);
            $("#txtPassword").focus();
            return false;
        }
        return true;
    }
}

$(document).ready(function (){
    doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.Seguridad.subURL, tramitesAlilloObjects.Services.URLs.Seguridad.currentUser, {}, perfilObjects.MuestraInfoUsuario);
});