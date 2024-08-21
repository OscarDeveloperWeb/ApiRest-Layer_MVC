"use strict";

function fnDelete(proveedorId) {
    $.ajax({
        type: "DELETE",
        contentType: "application/json; chartset=utf-8",
        async: true,
        cache: false,
        url: "/proveedor/delete/" + proveedorId,
        success: function () {
            alert("Se eliminó el producto de código '" + proveedorId + "', con éxito.");
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo eliminar el producto de código '" + proveedorId + "'.");
        }
    });
}

$("#EliminarBtn").on("click", function () {
    let proveedorId = $("#ProveedorIdTxt").val();
    fnDelete(proveedorId);
});