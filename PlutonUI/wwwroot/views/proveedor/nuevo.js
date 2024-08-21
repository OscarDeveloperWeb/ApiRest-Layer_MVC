﻿"use strict";

function fnInsert() {
    let proveedor;

    proveedor = {
        Nombre: $("#NombreTxt").val(),
        Ruc: $("#RucTxt").val(),
        ContactoId: $("#ContactoTxt").val(),
        Direccion: $("#DireccionTxt").val(),
        Ciudad: $("#CiudadTxt").val(),
        Region: $("#RegionTxt").val(),
        CodPostal: $("#CodPostalTxt").val(),
        Pais: $("#PaisTxt").val(),
        Telefono: $("#TelefonoTxt").val(),
        Fax: $("#FaxTxt").val(),
        PaginaPrincipal: $("#PaginaPrincipalTxt").val()
    };

    $.ajax({
        type: "POST",
        async: true,
        cache: false,
        data: { proveedor: JSON.stringify(proveedor) },
        url: "/proveedor/insert",
        dataType: "text",
        crossDomain: true,
        success: function () {
            alert("Se insertó con éxito.");
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("Ocurrió un error al insertar.");
        }
    });
}
$("#GuardarBtn").on("click", function () {
    fnInsert();
});