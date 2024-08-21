"use strict";

function fnGet(proveedorId) {
    $.ajax({
        type: "GET",
        contentType: "application/json; chartset=utf-8",
        async: true,
        cache: false,
        url: "/proveedor/select-by-id/" + proveedorId,

        success: function (data) {
            alert("Se busco : '" + proveedorId + "'.");
            console.info("data: ",data);
            var proveedor = "Nombre: " + data.Nombre + "<br>" +
                "Ruc: " + data.Ruc + "<br>" +
                "ContactoId: " + data.ContactoId + "<br>" +
                "Dirección: " + data.Direccion + "<br>" +
                "Ciudad: " + data.Ciudad + "<br>" +
                "Región: " + data.Region + "<br>" +
                "Codigo Postal: " + data.CodPostal + "<br>" +
                "Pais: " + data.Pais + + "<br>" +
                "Telefono: " + data.Telefono + "<br>" +
                "Fax: " + data.Fax + "<br>" +
                "Pagina Web: " + data.PaginaPrincipal;

            $("#ProductoResult").html(proveedor);
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo leer el producto de código '" + proveedorId + "'.");
        }

    });
}

$("#GetBtn").on("click", function () {
    let proveedorId = $("#IdProveedorTxt").val();
    fnGet(proveedorId);
});