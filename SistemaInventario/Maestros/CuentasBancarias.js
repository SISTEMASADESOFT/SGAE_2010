var AppSession = "../Maestros/CuentasBancarias.aspx";

var CodigoMenu = 1000;
var CodigoInterno = 7;

$(document).ready(function () {
   // if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#divTabs').tabs();

    $('#MainContent_imgBuscar').click(function () {
        try {
            var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val == "")
                cadena = cadena + "<p></p>" + "Articulo"

            if ($('#MainContent_ddlMoneda option').size() == 0)
            { cadena = cadena + "<p></p>" + "Moneda"; }
            else {
                if ($('#MainContent_ddlMoneda').val() == "-1")
                    cadena = cadena + "<p></p>" + "Moneda";
            }

            if (cadena != "Ingresar los sgtes. campos :") {
                toastr.warning(cadena);
                return false;
            }

            F_Buscar_Productos()
        }
        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnAgregarFactura').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            var Cadena = "Ingrese los sgtes. campos: "
            if ($('#hfCodCtaCte').val() == "0")
                Cadena = Cadena + '<p></p>' + "Razon Social";

            if (Cadena != "Ingrese los sgtes. campos: ") {
                toastr.warning(Cadena);
                return false;
            }

            $("#divEdicionRegistro").dialog({
                resizable: false,
                modal: true,
                title: "Consulta de Factura",
                title_html: true,
                height: 490,
                width: 420,
                autoOpen: false
            });

            $('#divEdicionRegistro').dialog('open');

            var Letra = 0;
            var Factura = 0;

            if ($('#MainContent_chkFactura').is(':checked'))
                Factura = 1;

            if ($('#MainContent_chkFactura').is(':checked'))
                Letra = 1;

            var objParams = {
                Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                Filtro_Letra: Letra,
                Filtro_Factura: Factura
            };
            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);


            F_Buscar_Factura_NET(arg, function (result) {
                //                var Entity = Sys.Serialization.JavaScriptSerializer.deserialize(result);

                //                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    F_Update_Division_HTML('div_grvConsultaFactura', result.split('~')[2]);

                }
                else {
                    toastr.warning(result.split('~')[1]);
                }

                return false;

            });


        }
        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnAgregar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (F_ValidarAgregar() == false)
                return false;

            F_AgregarTemporal();
            $('#MainContent_txtArticulo').focus();
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEliminarFactura').click(function () {
       // if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (F_ValidarEliminar_Factura() == false)
                return false;

            if (confirm("Esta seguro de eliminar los documentos seleccionado"))
                F_EliminarTemporal_Factura();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnGrabar').click(function () {
     //   if (!F_SesionRedireccionar(AppSession)) return false;
    //   if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarGrabarDocumento())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR LA FAMILIA"))
                F_GrabarCuenta();
      
            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnGrabarBanco').click(function () {
      //  if (!F_SesionRedireccionar(AppSession)) return false;
      // if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarGrabarBanco())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR El Banco"))
                F_GrabarBanco();

            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnNuevo').click(function () {
      if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Nuevo();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnNuevoBanco').click(function () {
     //   if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Nuevo();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnBuscarConsulta').click(function () {
      //  if (!F_SesionRedireccionar(AppSession)) return false;
     //   if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEdicion').click(function () {
     //  if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (!F_ValidarEdicionDocumento())
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DE LA FAMILIA"))
                F_EdicionRegistro();
      
            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    
    $('#MainContent_btnEdicionBanco').click(function () {
     //  if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (!F_ValidarEdicionBanco())
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DE LA FAMILIA"))
                F_EdicionRegistroBanco();
      
            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    F_Controles_Inicializar();

    $('#MainContent_txtDescripcionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtCodFamiliaEdicion').css('background', '#FFFFE0');

    F_Inicializar_CajaTexto();
});

$().ready(function () {

    $(document).everyTime(600000, function () {
        if (!F_ValidaSesionActiva(AppSession)) return false;
    });


});

$(document).unbind('keydown').bind('keydown', function (event) {
    var doPrevent = false;
    if (event.keyCode === 8) {
        var d = event.srcElement || event.target;
        if ((d.tagName.toUpperCase() === 'INPUT' && (d.type.toUpperCase() === 'TEXT' || d.type.toUpperCase() === 'PASSWORD' || d.type.toUpperCase() === 'FILE' || d.type.toUpperCase() === 'EMAIL'))
             || d.tagName.toUpperCase() === 'TEXTAREA') {
            doPrevent = d.readOnly || d.disabled;
        }
        else {
            doPrevent = true;
        }
    }

    if (doPrevent) {
        event.preventDefault();
    }
});

function VerifySessionState(result) { }
//--------------------------------------------------------------
function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams = {};

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Controles_Inicializar_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_Estado', result.split('~')[2]);
                        F_Update_Division_HTML('div_EstadoEdicion', result.split('~')[3]);
                        F_Update_Division_HTML('div_CuentasBancarias', result.split('~')[4]);
                        F_Update_Division_HTML('div_EmpresaEdicion', result.split('~')[5]);
                        F_Update_Division_HTML('div_EmpresaConsulta', result.split('~')[6]);
                        F_Update_Division_HTML('div_Moneda', result.split('~')[7]);
                        F_Update_Division_HTML('div_EstadoBanco', result.split('~')[8]);
                        F_Update_Division_HTML('div_BancoEdicion', result.split('~')[9])
                        F_Update_Division_HTML('div_MonedaEdicion', result.split('~')[10]);
                        F_Update_Division_HTML('div_EstadoEdicion2', result.split('~')[11]);
                         
                        $('#MainContent_ddlEstado').val(1);
                        $('#MainContent_ddlEstadoBanco').val(1);
                        $('#MainContent_ddlEstado').css('background', '#FFFFE0');
                        $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlEstadoEdicion2').css('background', '#FFFFE0');
                        

                        $('#MainContent_ddlCuentasBancarias').css('background', '#FFFFE0');
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                         $('#MainContent_ddlMonedaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpresaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpresaConsulta').css('background', '#FFFFE0');
                        $('#MainContent_txtNroDni').focus();
                        $('#MainContent_ddlEstadoBanco').css('background', '#FFFFE0');
                        $('#MainContent_ddlBancoEdicion').css('background', '#FFFFE0');
                        $('.ccsestilo').css('background', '#FFFFE0');
                    }
                    else {

                        toastr.warning(str_mensaje_operacion);

                    }


                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);

    }

}

function F_ValidarTipoCliente(CodTipoCliente) {
    var arg;
    try {
        if (CodTipoCliente == '1') {
            $('#MainContent_txtNroDni').prop('disabled', false);
            $('#MainContent_txtApellidoPaterno').prop('disabled', false);
            $('#MainContent_txtApellidoMaterno').prop('disabled', false);
            $('#MainContent_txtNombres').prop('disabled', false);
            $('#MainContent_txtRazonSocial').prop('disabled', true);
            $('#MainContent_txtNroRuc').prop('disabled', true);
            $('#MainContent_txtRazonSocial').val('');
            $('#MainContent_txtNroRuc').val('');
            $('#MainContent_txtNroDni').focus();

        }
        else {
            $('#MainContent_txtRazonSocial').prop('disabled', false);
            $('#MainContent_txtNroRuc').prop('disabled', false);
            $('#MainContent_txtApellidoPaterno').val('');
            $('#MainContent_txtApellidoMaterno').val('');
            $('#MainContent_txtNombres').val('');
            $('#MainContent_txtNroDni').val('');
            $('#MainContent_txtApellidoPaterno').prop('disabled', true);
            $('#MainContent_txtApellidoMaterno').prop('disabled', true);
            $('#MainContent_txtNombres').prop('disabled', true);
            $('#MainContent_txtNroDni').prop('disabled', true);
            $('#MainContent_txtNroRuc').focus();
        }
        return false;


    }
    catch (mierror) {
        toastr.warning("Error detectado: " + mierror);
    }

}

function F_ValidarGrabarDocumento() {
   // if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtCuenta').val()?.trim() === '')
            Cadena = Cadena + '<p></p>' + 'Numero Cuenta';

//        if ($(Cuerpo + 'txtCci').val()?.trim() === '')
//            Cadena = Cadena + '<p></p>' + 'CCI';
//        
//        if ($(Cuerpo + 'txtObservacion').val()?.trim() === '')
//            Cadena = Cadena + '<p></p>' + 'Observacion';

//        if ($(Cuerpo + 'txtCuentaContable').val()?.trim() === '')
//            Cadena = Cadena + '<p></p>' + 'CuentaContable';

//        if ($(Cuerpo + 'txtTd').val()?.trim() === '')
//            Cadena = Cadena + '<p></p>' + 'Td';

//        
//        if ($(Cuerpo + 'txtCodigoAnexo').val()?.trim() === '')
//            Cadena = Cadena + '<p></p>' + 'CodigoAnexo';
                                         
        if ($(Cuerpo + 'ddlEstado').val()?.trim() === '0' || $(Cuerpo + 'ddlEstado').val()?.trim() === null || $(Cuerpo + 'ddlEstado').val()?.trim() === '')
         Cadena = Cadena + '<p></p>' + 'Estado';

        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_ValidarGrabarBanco() {
   // if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcion').val().trim() === '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if ($(Cuerpo + 'txtDescripcionCorta').val().trim() === '')
            Cadena = Cadena + '<p></p>' + 'DescripcionCorta';

        if ($(Cuerpo + 'txtOrden').val().trim() === '0' || $(Cuerpo + 'txtOrden').val().trim() === null || $(Cuerpo + 'txtOrden').val().trim() === '')
         Cadena = Cadena + '<p></p>' + 'Numero de Orden';
                                         
        if ($(Cuerpo + 'ddlEstadoBanco').val().trim() === '0' || $(Cuerpo + 'ddlEstadoBanco').val().trim() === null || $(Cuerpo + 'ddlEstadoBanco').val().trim() === '')
         Cadena = Cadena + '<p></p>' + 'Estado';

        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_GrabarCuenta() {
    //if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var objParams = {
            Filtro_CodBanco: $(Contenedor + 'ddlCuentasBancarias').val(),
            Filtro_CodMoneda: $(Contenedor + 'ddlMoneda').val(),
            Filtro_Cuenta: $(Contenedor + 'txtCuenta').val(),
            Filtro_Cci: $(Contenedor + 'txtCci').val(),
            Filtro_Observacion: $(Contenedor + 'txtObservacion').val().toUpperCase(),
            Filtro_CuentaContable: $(Contenedor + 'txtCuentaContable').val(),
            Filtro_Td: $(Contenedor + 'txtTd').val(),
            Filtro_CodigoAnexo: $(Contenedor + 'txtCodigoAnexo').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstado').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDocumento_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Banco ingresado correctamente.') {

                    $(Contenedor + 'txtCuenta').val('');
                    $(Contenedor + 'txtCci').val('');
                    $(Contenedor + 'txtObservacion').val('');
                    $(Contenedor + 'txtCuentaContable').val('');  
                    $(Contenedor + 'txtTd').val('');              
                    $(Contenedor + 'txtCodigoAnexo').val('');       
                    $(Contenedor + 'ddlEstado').val('');

                    toastr.success('Se Grabo Correctamente');
                     F_Nuevo();
                }
                else
                    toastr.warning(result.split('~')[1]);
            }
            else {
                toastr.warning(result.split('~')[1]);
            }
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_GrabarBanco() {
    // if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var FlagBancoInterno = 0;

        if ($('#MainContent_chkBancoInterno').is(':checked'))
            FlagBancoInterno = 1;

        var objParams = {
            Filtro_CodBanco:         $(Contenedor + 'txtDescripcion').val(),
            Filtro_Descripcion:         $(Contenedor + 'txtDescripcion').val().toUpperCase(),
            Filtro_DescripcionCorta: $(Contenedor + 'txtDescripcionCorta').val().toUpperCase(),
            Filtro_Orden: $(Contenedor + 'txtOrden').val().toUpperCase(),
            Filtro_Estado: $(Contenedor + 'ddlEstadoBanco').val(),

            Filtro_BancoInterno:        FlagBancoInterno,

       };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_RegistrarBanco_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Banco creado correctamente.') {

                    $(Contenedor + 'txtDescripcion').val('');
                    $(Contenedor + 'txtDescripcionCorta').val('');
                    $(Contenedor + 'txtOrden').val('');
                    $(Contenedor + 'ddlEstadoBanco').val('');

                    toastr.success('Se Grabo Correctamente');
                        F_Nuevo();
                    }
                    else
                        toastr.warning(result.split('~')[1]);
            }
            else {
                toastr.warning(result.split('~')[1]);
            }
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_Nuevo() {
    var Contenedor = '#MainContent_';
    $(Contenedor + 'txtCuenta').val('');
    $(Contenedor + 'txtCci').val('');
    $(Contenedor + 'txtObservacion').val('');
    $(Contenedor + 'txtCuentaContable').val('');
    $(Contenedor + 'txtTd').val('');
    $(Contenedor + 'txtCodigoAnexo').val('');
    $(Contenedor + 'ddlEstado').val(1);

    $(Contenedor + 'txtDescripcion').val('');
    $(Contenedor + 'txtDescripcionCorta').val('');
    $(Contenedor + 'txtOrden').val('');
    $(Contenedor + 'ddlEstadoBanco').val(1);
    $(Contenedor + 'chkPrincipal').prop('checked', false);


return false;
}

function F_Buscar() {
    //if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var objParams = {
            Filtro_DscBanco: $("#MainContent_txtDescripcionConsulta").val()


        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Buscar_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {

                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblNombreBanco'));
                if (str_mensaje_operacion != "")
                    toastr.warning(result.split('~')[1]);

            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}

function F_AbrirBanco(Fila) {

  if (!$("#tabGrabarBanco").data("ui-dialog")) {
    $("#tabGrabarBanco").dialog({
      resizable: false,
      modal: true,
      title: "Grabar Banco", 
      title_html: true,
     
      height: 250,
      width: 530,
      autoOpen: false
    });
  }

  
  $("#tabGrabarBanco").dialog("open");

  return false; 
}

$(document).ready(function() {
  $("#btnCerrarBanco").on("click", function() {
    $("#tabGrabarBanco").dialog("close");
  });
});

function F_EliminarRegistro(Fila) {

    try {
        var imgID = Fila.id;
        var hfCodCuenta = '#' + imgID.replace('imgAnularDocumento', 'hfCodCuenta');
        var lblNombreBanco = '#' + imgID.replace('imgAnularDocumento', 'lblNombreBanco');

        if (!confirm("ESTA SEGURO DE ELIMINAR LA CUENTA? " + $(lblNombreBanco).text()))
            return false;

        var objParams = {
            Filtro_IDcuenta: $(hfCodCuenta).val(),
            Filtro_Descripcion: $('#MainContent_txtDescripcionConsulta').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarRegistro_Net(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                toastr.success(str_mensaje_operacion); 
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
               
            }
            else {
                toastr.warning(str_mensaje_operacion); 
            }

            return false;
        });

    } catch (e) {
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_EditarRegistro(control) {
    try {
        var Contenedor = '#MainContent_'; 

      
        var bancoSeleccionado = $(Contenedor + 'ddlCuentasBancarias').val();

        
        if (!bancoSeleccionado) {
            toastr.warning("Por favor, seleccione un banco válido.");
            return false;
        }

        
        $(Contenedor + 'ddlBancoEdicion').val(bancoSeleccionado);
      
        var objParams = {
            Filtro_CodBanco: bancoSeleccionado
        };

        var arg = JSON.stringify(objParams);

        MostrarEspera(true);

       
        F_ObtenerDatosBanco_NET(arg, function (result) {
            try {
                MostrarEspera(false); 

               
                var [str_resultado_operacion, str_mensaje_operacion, datosBanco] = result.split('~');

                if (str_resultado_operacion === "1") {
                   
                    var detalles = JSON.parse(datosBanco);

                  
                    $(Contenedor + 'txtDescripcionEdicion').val(detalles.DscBanco || '');
                    $(Contenedor + 'txtDescripcionCortaEdicion').val(detalles.DescripcionCorta || '');
                    $(Contenedor + 'txtOrdenEdicion').val(detalles.Orden || '');
                    $(Contenedor + 'ddlEstadoEdicion2').val(detalles.CodEstado || '');
                    

                    toastr.success("Datos cargados correctamente.");
                } else {
                   
                    toastr.warning(str_mensaje_operacion || "Error desconocido en la operación.");
                }
            } catch (error) {
              
                toastr.warning("Error al procesar respuesta: " + error.message);
            }
        });
    } catch (error) {
        MostrarEspera(false); 
        toastr.warning("Error Detectado: " + error.message);
    }

    
    if (!$("#tabEdicionBanco").data("ui-dialog")) {
        $("#tabEdicionBanco").dialog({
            resizable: false,
            modal: true,
            title: "Editar Banco",
            title_html: true,
            height: 250,
            width: 530,
            autoOpen: false
        });
    }

   
    $("#tabEdicionBanco").dialog("open");

    return false; 
}

function F_EdicionRegistro() {
    try {
        var Contenedor = '#MainContent_';

        var FlagDetraccion = 0;

        if($('#MainContent_chkDetraccion').is(':checked'))
            FlagDetraccion = 1;

        var objParams = {
               
            Filtro_CodCuenta:                      $('#hfCodCuenta').val(),
            Filtro_Observacionon: $(Contenedor + 'txtObservacionEdicion').val().toUpperCase(),
            Filtro_Cci: $(Contenedor + 'txtCciEdicion').val().toUpperCase(),
            Filtro_Moneda:  $(Contenedor + 'ddlMonedaEdicion').val(), 
            Filtro_NumeroCuenta: $(Contenedor + 'txtNumeroCuenta').val(),
            Filtro_Estado: $(Contenedor + 'ddlEstadoEdicion').val(),
            Filtro_Td: $(Contenedor + 'txtTdEdicion').val(),
            Filtro_Anexo: $(Contenedor + 'txtCodigoAnexoEdicion').val(),
            Filtro_CuentaContable  : $(Contenedor + 'txtCuentaContableEdicion').val(),
            Filtro_FlagDetraccion:        FlagDetraccion,
          
          
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EdicionRegistro_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Banco actualizado correctamente.') {
                    
                    $(Contenedor + 'txtObservacionEdicion').val('');
                    $(Contenedor + 'txtCciEdicion').val('');
                    $(Contenedor + 'txtOrdenEdicion').val('');
                    $(Contenedor + 'txtNumeroCuenta').val('');
                                
                    toastr.success('Se ACTUALIZO Correctamente.');
                    F_Nuevo();  

                    F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                    $('#divEdicionBanco').dialog('close'); 

                }
                else
                    toastr.warning(result.split('~')[1]);
            }
            else {
                toastr.warning(result.split('~')[1]);
            }
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_EdicionRegistroBanco() {
    try {
        var Contenedor = '#MainContent_';

//        var FlagDetraccion = 0;

//        if($('#MainContent_chkDetraccion').is(':checked'))
//            FlagDetraccion = 1;

        var objParams = {
               
            Filtro_CodBanco: $(Contenedor + 'ddlBancoEdicion').val(), 
            Filtro_DescripcionEdicion: $(Contenedor + 'txtDescripcionEdicion').val().toUpperCase(),
            Filtro_DescripcionCorta: $(Contenedor + 'txtDescripcionCortaEdicion').val().toUpperCase(),
            Filtro_NumeroOrden: $(Contenedor + 'txtOrdenEdicion').val(),
            Filtro_Estado: $(Contenedor + 'ddlEstadoEdicion2').val(),
//            Filtro_FlagDetraccion:        FlagDetraccion,
//          
          
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EdicionRegistroBanco_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Banco actualizado correctamente.') {
                    
                    $(Contenedor + 'txtObservacionEdicion').val('');
                    $(Contenedor + 'txtCciEdicion').val('');
//                    $(Contenedor + 'txtOrdenEdicion').val('');
                    $(Contenedor + 'txtNumeroCuenta').val('');
                                
                    toastr.success('Se ACTUALIZO Correctamente.');
                    F_Nuevo();  

                    F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                    $('#divEdicionBanco').dialog('close'); 

                }
                else
                    toastr.warning(result.split('~')[1]);
            }
            else {
                toastr.warning(result.split('~')[1]);
            }
            return false;
        });
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_EditarRegistro2(Fila) {
//    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var hfCodCuenta                    = '#' + imgID.replace('imgEditarRegistro', 'hfCodCuenta');
         var lblNombreBanco                    = '#' + imgID.replace('imgEditarRegistro', 'lblNombreBanco');
        var lblObservacion                    = '#' + imgID.replace('imgEditarRegistro', 'lblObservacion');
        var lblCci                  = '#' + imgID.replace('imgEditarRegistro', 'lblCci');
        var lblMoneda                     = '#' + imgID.replace('imgEditarRegistro', 'lblMoneda');
        var lblNumeroCuenta                     = '#' + imgID.replace('imgEditarRegistro', 'lblNumeroCuenta');
        var hfestado = '#' + imgID.replace('imgEditarRegistro', 'hfestado');
//      var hfDireccion                     = '#' + imgID.replace('imgEditarRegistro', 'lblDireccion');

        var hfDetraccion = '#' + imgID.replace('imgEditarRegistro', 'hfDetraccion');
        var lblTd = '#' + imgID.replace('imgEditarRegistro', 'lblTd');
        var lblAnexo = '#' + imgID.replace('imgEditarRegistro', 'lblAnexo');
        var lblCuentaContable = '#' + imgID.replace('imgEditarRegistro', 'lblCuentaContable');
       
  

        var Cuerpo = '#MainContent_';
        
      

        $('#hfCodCuenta').val($(hfCodCuenta).val());

         $(Cuerpo + 'txtObservacionEdicion').val($(lblObservacion).val());

        $(Cuerpo + 'txtCciEdicion').val($(lblCci).val());

        $(Cuerpo + 'txtTdEdicion').val($(lblTd).val());
        $(Cuerpo + 'txtCodigoAnexoEdicion').val($(lblAnexo).val());
        $(Cuerpo + 'txtCuentaContableEdicion').val($(lblCuentaContable).val());


        $(Cuerpo + 'ddlMonedaEdicion').val($(lblMoneda).val());

        $(Cuerpo + 'txtNumeroCuenta').val($(lblNumeroCuenta).val());

        $(Cuerpo + 'ddlEstadoEdicion').val($(hfestado).val());

 

       if ($(hfDetraccion).val() === 'SI')
       $(Cuerpo + 'chkDetraccion').prop('checked', true);
      else
        $(Cuerpo + 'chkDetraccion').prop('checked', false);
 

        $("#tabEdicionCuentas").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Cuentas bancarias",
            title_html: true,
            height: 350,
            width: 500,
            autoOpen: false
        });

        $('#tabEdicionCuentas').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}

function F_ValidarEdicionDocumento() {
     try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtObservacionEdicion').val().trim() === '')
            Cadena = Cadena + '<p></p>' + 'Observacion';


        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
    }
}

function F_ValidarEdicionBanco() {
     try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcionEdicion').val().trim() === '')
            Cadena = Cadena + '<p></p>' + 'Observacion';


        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
    }
}

function ValidarRuc(valor) {
    valor = trim(valor)
    if (esnumero(valor)) {
        if (valor.length == 8) {
            suma = 0
            for (i = 0; i < valor.length - 1; i++) {

                if (i == 0) suma += (digito * 2)
                else suma += (digito * (valor.length - i))
            }
            resto = suma % 11;
            if (resto == 1) resto = 11;
            if (resto + (valor.charAt(valor.length - 1) - '0') == 11) {
                return true
            }
        } else if (valor.length == 11) {
            suma = 0
            x = 6
            for (i = 0; i < valor.length - 1; i++) {
                if (i == 4) x = 8
                digito = valor.charAt(i) - '0';
                x--
                if (i == 0) suma += (digito * x)
                else suma += (digito * x)
            }
            resto = suma % 11;
            resto = 11 - resto

            if (resto >= 10) resto = resto - 10;
            if (resto == valor.charAt(valor.length - 1) - '0') {
                return true
            }
        }
    }
    return false
}

function esnumero(campo) { return (!(isNaN(campo))); }

function MostrarEspera(pboolMostrar) {
    if (pboolMostrar) {
        $('#dlgWait').dialog({
            autoOpen: false,
            modal: true,
            height: 'auto',
            resizable: false,
            dialogClass: 'alert'
        });

        $('.alert div.ui-dialog-titlebar').hide();
        //        $('.ui-button').remove();
        $('#dlgWait').dialog('open');
    }
    else {
        $('#dlgWait').dialog('close');
    }
}

function getContentTab() {
   
    F_Buscar();
    return false;

}

function F_Inicializar_CajaTexto() {

    $('#MainContent_txtCuenta').css('background', '#FFFFE0');

    $('#MainContent_txtCci').css('background', '#FFFFE0');

    $('#MainContent_txtObservacion').css('background', '#FFFFE0');

    $('#MainContent_txtTd').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoAnexo').css('background', '#FFFFE0');

    $('#MainContent_txtCuentaContable').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionCorta').css('background', '#FFFFE0');

    $('#MainContent_txtOrden').css('background', '#FFFFE0');

    $('#MainContent_ddlEstadoBanco').css('background', '#FFFFE0');

    $('#MainContent_chkPrincipal').css('background', '#FFFFE0');

    $('#MainContent_txtDistrito').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionAzure').css('background', '#FFFFE0');

    $('#MainContent_txtEstablecimientoSunat').css('background', '#FFFFE0');

    $('#MainContent_txtOrdenEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionCortaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCuentaContableEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtTdEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoAnexoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtNumeroCuenta').css('background', '#FFFFE0');

    $('#MainContent_txtObservacionEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtCciEdicion').css('background', '#FFFFE0');

    

    $('#MainContent_txtCodigoAnexo').ForceNumericOnly()

    $('#MainContent_txtCuenta').ForceNumericOnly()
  
   // $('#MainContent_txtCci').ForceNumericOnly()

    $('#MainContent_txtCuentaContable').ForceNumericOnly()

    $('#MainContent_txtCodigoAnexo').ForceNumericOnly()

    $('#MainContent_txtOrdenEdicion').ForceNumericOnly()

    $('#MainContent_txtOrden').ForceNumericOnly()


    return false;
}