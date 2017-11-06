var masterPageObject = {
    Menu: {
        GoTo: function (menuURL) {
            window.location.href = tramitesAlilloObjects.BaseURL + $(menuURL).data("link");
        }
    },
    EstableceItemMenuActivo: function () {
        //Quitamos la clase de activo al elemento que la tenga
        $("li[class='active']").removeClass("active");

        // Obtenemos el nombre de la pagina actual
        var curPage = window.location.href.split("/")[window.location.href.split("/").length - 1];

        // Buscamos al elemento del menú que tiene el link y le ponemos la clase de activo
        $("#menu li .submodulo").each(function (inc, obj) {
            //var aLinkPage = $(obj).data("link").split("/")[$(obj).data("link").split("/").length - 1];

            if ($(obj).data("link").indexOf(curPage) >= 0) {
                $(obj).addClass("active");
            }
        });
    },
    PintaMenu: function (serviceResult) {
        if (serviceResult.GetMenuResult.Success) {

            var menu = serviceResult.GetMenuResult.Object;
            var menuToAppend = "";

            //Iteramos en los modulos para ir armando el HTML
            $(menu.Modulos).each(function (i, modulo) {
                menuToAppend += '<li>';
                menuToAppend += '<ul class="nav nav-sidebar">';
                menuToAppend += '<li class="menu-title"><a>' + modulo.DescModulo + '</a></li>';
                //Iteramos en los submodulos para complementar el HTML
                $(modulo.SubModulos).each(function (j, sModulo) {
                    menuToAppend += '<li data-link="' + sModulo.Url + '" class="submodulo" onclick="masterPageObject.Menu.GoTo(this);"><a href="#">' +
                        sModulo.DescSubmodulo + '</a></li>';
                });
                menuToAppend += '</ul>';
                menuToAppend += '</li> ';
            });

            //Insertamos el html del menu
            $("#menu ul:first").html(menuToAppend);

            //Ponemos la clase de activo al elemnto que representa la pagina actual en el menu del sitio
            masterPageObject.EstableceItemMenuActivo();
        } else {
            tramitesAlilloObjects.GlobalMessage.Show(serviceResult.GetMenuResult.ServiceMessage, true);
        }
    },
    PreparaModal: function (serviceResult) {
        if (serviceResult.Success) {
            // Traemos el usuario que está en sesión.
            tramitesAlilloObjects.UsuarioEnSesion = serviceResult.Object;

            // Le ponemos al link de ayuda la funcionalidad
            $("#linkAyuda").bind("click", function () {
                masterPageObject.MuestraModal();
            });
        } else {
            // Re dirijimos al login ya que la sesión expiró.
            tramitesAlilloObjects.Tools.Redirectors.RedirectToLogin();
        }
    },
    MuestraModal: function () {
        //Preparamos el modal de ayuda.
        var loggedUserName = tramitesAlilloObjects.UsuarioEnSesion.Nombre + ' ' + tramitesAlilloObjects.UsuarioEnSesion.ApellidoPaterno + ' ' +
            tramitesAlilloObjects.UsuarioEnSesion.ApellidoMaterno;
        var mailGOTA = "mailto:alilloem@gmail.com?subject=" + loggedUserName + "(Ayuda GOTA)";

        // Preparamos el contenido del modal de ayuda
        var dialogTitle = "";
        var dialogBody = "";
        var dialogFooter = "";

        dialogTitle += "Ayuda";

        dialogBody += "<p>Si tienes alg&uacute;n problema, envi&iacute;anos un correo para atender la situaci&oacute;n:</p>";
        dialogBody += "<p><a href = '" + mailGOTA + "'><span class = 'glyphicon glyphicon-envelope'></span> Isaí Alillo</a><p>";

        dialogFooter += "<button id='btnAyudaOK' type='button' class='btn btn-default'>OK</button>";

        // Insertamos el html del modal
        tramitesAlilloObjects.Modal.Create("body", dialogTitle, dialogBody, dialogFooter);

        // Boton que oculta el modal de ayuda
        $("#btnAyudaOK").bind("click", function () {
            tramitesAlilloObjects.Modal.Hide();
        });

        tramitesAlilloObjects.Modal.Show();
    }
}


$(document).ready(function () {
    //Creamos el objeto de mensajes globales del sitio
    tramitesAlilloObjects.GlobalMessage.Create();

    //Traemos al usuario en sesión para crear el modal
    doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.Seguridad.subURL, tramitesAlilloObjects.Services.URLs.Seguridad.currentUser, {}, masterPageObject.PreparaModal);

    //Creamos el menu y lo pintamos
    doJsonObjectAjaxCallback(tramitesAlilloObjects.Services.URLs.Navegacion.subURL, tramitesAlilloObjects.Services.URLs.Navegacion.getMenu, {}, masterPageObject.PintaMenu);
});