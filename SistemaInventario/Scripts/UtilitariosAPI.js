


var API_CON = GET_API_CONFIGURATION();


var redireccionar = false;
function GET_API_CONFIGURATION() {
    var Espera = false;
    var Resultado = false;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    var RESULTADO;

    $.ajax({
        type: "POST",
        url: '../Servicios/API_NET.asmx/GET_API_CONFIGURATION',
        contentType: "application/json; charset=utf-8",
        data: '{}',
        dataType: "json",
        async: false,
        success: function (dbObject) {

            if (dbObject.d.urlBase == "auto") {
                dbObject.d.urlBase = window.location.protocol + "//" + window.location.host + "/";
            }

            if (dbObject.d.urlSegi != "") { 
                dbObject.d.urlBase = dbObject.d.urlBase + dbObject.d.urlSegi
            }
            
            RESULTADO = dbObject.d;
        },
        complete: function () {
            //MostrarEspera(false);

        },
        error: function (response) {
            console.log("error response", response.responseText)
            alertify.log(response.responseText);
            //MostrarEspera(false);

        },
        failure: function (response) {
            console.log("failure response", response.responseText)
            alertify.log(response.responseText);
            //MostrarEspera(false);

        }
    });

    //do { } while (Espera == false); //Esperar a que se ejecuta el Ajax

    return RESULTADO;
}


var redireccionar = false;
function API_NET(tipo, controller, parametros) {
    var Espera = false;
    var Resultado = false;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    //parametros = Sys.Serialization.JavaScriptSerializer.serialize(parametros);

    parametros = parametros == null || parametros == undefined ? {} : parametros

    var RESULTADO;

    $.ajax({
        type: tipo,
        url: API_CON.urlBase + controller,
        contentType: "application/json; charset=utf-8",
        data: parametros,
        dataType: "json",
        async: false,
        success: function (dbObject) {

            RESULTADO = dbObject;

        },
        complete: function () {
            //MostrarEspera(false);

        },
        error: function (response) {
            console.log("error response", response.responseText)
            alertify.log(response.responseText);
            //MostrarEspera(false);

        },
        failure: function (response) {
            console.log("failure response", response.responseText)
            alertify.log(response.responseText);
            //MostrarEspera(false);

        }
    }).done((res) => {

    })

    //do { } while (Espera == false); //Esperar a que se ejecuta el Ajax

    return RESULTADO;
}



var redireccionar = false;
function API_NET_BODY(tipo, controller, parametros) {
    var Espera = false;
    var Resultado = false;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    //parametros = Sys.Serialization.JavaScriptSerializer.serialize(parametros);

    parametros = parametros == null || parametros == undefined ? {} : parametros

    var par = JSON.stringify( parametros )

    var RESULTADO;

    $.ajax({
        type: tipo,
        url: API_CON.urlBase + controller,
        contentType: "application/json; charset=utf-8",
        data: par,
        dataType: "json",
        async: false,
        success: function (dbObject) {

            RESULTADO = dbObject;

            if (RESULTADO["ShowMessage"] != undefined && RESULTADO["ShowMessage"] == true) {

                if (RESULTADO["IsOk"] == true) {
                    var msg = RESULTADO["Message"] == null || RESULTADO["Message"] == undefined ? "Operacion OK!" : RESULTADO["Message"];
                    try {
                        toast({ message: msg, type: "ok" });
                    } catch (e) {
                        alertify.log(msg);
                    }
                    
                    return;
                }

                if (RESULTADO["IsOk"] == false) {

                    var msg = "";
                    var typ = "";
                    if (RESULTADO["HasError"] == false) {
                        msg = "Operación con ERROR!";
                        typ = "warning"
                    }
                    if (RESULTADO["HasError"] == true) {
                        msg = RESULTADO["ErrorMessage"] == null || RESULTADO["ErrorMessage"] == undefined ? "Operacion con ERROR!" : RESULTADO["ErrorMessage"];
                        typ = "error"
                    }
                    try {
                        toast({ message: msg, type: typ });
                    } catch (e) {
                        alertify.log(msg);
                    }
                    
                    return;
                }
            
            }

        },
        complete: function () {
            //MostrarEspera(false);

        },
        error: function (response) {
            console.log("error response", response.responseText)
            alertify.log(response.responseText);
            //MostrarEspera(false);

        },
        failure: function (response) {
            console.log("failure response", response.responseText)
            alertify.log(response.responseText);
            //MostrarEspera(false);

        }
    }).done((res) => {

    })

    //do { } while (Espera == false); //Esperar a que se ejecuta el Ajax

    return RESULTADO;
}