// Funcion generica para hacer los callbacks al servidor
function doJsonObjectAjaxCallback(serviceUrl, method, jsonObject, successFunction) {
    $.ajax(
        {
            type: "POST",
            url: tramitesAlilloObjects.BaseURL + serviceUrl + method,
            data: JSON.stringify(jsonObject),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            /*beforeSend: function () {
                tramitesAlilloObjects.LoadingModal.Show();
            },
            complete: function () {
                tramitesAlilloObjects.LoadingModal.Hide();
            },*/
            success: function (result) {
                successFunction(result.d || result);
            },
            error: function (xhr, status, error) {
                tramitesAlilloObjects.GlobalMessage.Show(xhr.responseText, true);
            }
        });
}