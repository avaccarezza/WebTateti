$("#buscarUsuario").click(function () {

    var usuarioId = parseInt($("#usuarioIdConAjax").val());

    console.log(usuarioId);

    var json = {}
    json["id"] = usuarioId;

    console.log(json);

    $.ajax({
        type: "POST",
        url: "/Home/BuscarUsuarioConAjax",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(json),

        success: function (response) {

            console.log(response);

            var response = JSON.parse(response);

            $("#usuario").html("" +
                "<p><h3>Usuario encontrado con AJAX</h3></p>" +
                "<p><b>ID: </b>" + response["id"] + "</p>" +
                "<p><b>Usuario: </b>" + response["usuario"] + "</p>" +
                "<p><b>Contraseña: </b>" + response["contrasena"] + "</p>" +
                "<p><b>Puntaje: </b>" + response["puntaje"] + "</p>" +
                "<p><b>Partidas ganadas: </b>" + response["partidas_ganadas"] + "</p>" +
                "<p><b>Partidas jugadas: </b>" + response["partidas_jugadas"] + "</p>" +
            "");

        }

    })

});