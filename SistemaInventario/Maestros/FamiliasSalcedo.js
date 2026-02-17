var AppSession = "../Maestros/Familias.aspx";

var CodigoMenu = 1000;
var CodigoInterno = 7;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

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
        if (!F_SesionRedireccionar(AppSession)) return false;
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
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarGrabarDocumento())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR LA FAMILIA"))
                F_GrabarDocumento();

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

    $('#MainContent_btnBuscarConsulta').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEdicion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
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

    F_Controles_Inicializar();

    $('#MainContent_txtDescripcionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtCodigo').css('background', '#FFFFE0');

    $('#MainContent_txtCodFamiliaEdicion').css('background', '#FFFFE0');

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

                        F_Update_Division_HTML('div_Empresa', result.split('~')[4]);
                        F_Update_Division_HTML('div_EmpresaEdicion', result.split('~')[5]);
                        F_Update_Division_HTML('div_EmpresaConsulta', result.split('~')[6]);


                        $('#MainContent_ddlEstado').val(1);
                        $('#MainContent_ddlEstado').css('background', '#FFFFE0');
                        $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');

                        $('#MainContent_ddlEmpresa').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpresaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpresaConsulta').css('background', '#FFFFE0');
                        $('#MainContent_txtNroDni').focus();
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
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Familia';

        if ($(Cuerpo + 'txtCodigo').val() == '')
            Cadena = Cadena + '<p></p>' + 'Codigo';

        if ($(Cuerpo + 'ddlEstado').val() == 0 || $(Cuerpo + 'ddlEstado').val() == null)
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

function F_GrabarDocumento() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var ChkCodigoProducto=0;
        var ChkMotor=0;
        var ChkModeloVehiculo=0;
        var ChkAño=0;
        var ChkMarcaVehiculo=0;
        var ChkOtroDetalles=0;
        var ChkPlato=0;
        var ChkDisco=0;
        var ChkCollarin=0;
        var Chkespesor=0;
        var ChkMedidasA=0;
        var ChkMedidasB=0;
        var ChkMedidasC=0;
        var ChkMedidasD=0;
        var ChkPosicion=0;
        var ChkLado=0;

        if ($('#MainContent_ChkCodigoProducto').is(':checked'))
            ChkCodigoProducto = 1;
        if ($('#MainContent_ChkMotor').is(':checked'))
            ChkMotor = 1;
        if ($('#MainContent_ChkModelo').is(':checked'))
            ChkModeloVehiculo = 1;
        if ($('#MainContent_ChkAño').is(':checked'))
            ChkAño = 1;
        if ($('#MainContent_ChkMarca').is(':checked'))
            ChkMarcaVehiculo = 1;
        if ($('#MainContent_ChkDetalles').is(':checked'))
            ChkOtroDetalles = 1;
        if ($('#MainContent_ChkPlato').is(':checked'))
            ChkPlato = 1;
        if ($('#MainContent_ChkDisco').is(':checked'))
            ChkDisco = 1;
        if ($('#MainContent_ChkCollarin').is(':checked'))
            ChkCollarin = 1;
        if ($('#MainContent_ChkEspesor').is(':checked'))
            Chkespesor = 1;
        if ($('#MainContent_ChkMedidaA').is(':checked'))
            ChkMedidasA = 1;
        if ($('#MainContent_ChkMedidaB').is(':checked'))
            ChkMedidasB = 1;
        if ($('#MainContent_ChkMedidaC').is(':checked'))
            ChkMedidasC = 1;
        if ($('#MainContent_ChkMedidaD').is(':checked'))
            ChkMedidasD = 1;
        if ($('#MainContent_ChkPosicion').is(':checked'))
            ChkPosicion = 1;
        if ($('#MainContent_ChkLado').is(':checked'))
            ChkLado = 1;

        var objParams = {
            Filtro_CodEmpresa: $(Contenedor + 'ddlEmpresa').val(),
            Filtro_CodigoFamilia: $(Contenedor + 'txtCodigo').val(),
            Filtro_DscFamilia: $(Contenedor + 'txtDescripcion').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstado').val(),
            Filtro_ChkCodigoProducto: ChkCodigoProducto,
            Filtro_ChkMotor: ChkMotor,
            Filtro_ChkModeloVehiculo: ChkModeloVehiculo,
            Filtro_ChkAño: ChkAño,
            Filtro_ChkMarcaVehiculo: ChkMarcaVehiculo,
            Filtro_ChkOtroDetalles: ChkOtroDetalles,
            Filtro_ChkPlato: ChkPlato,
            Filtro_ChkDisco: ChkDisco,
            Filtro_ChkCollarin: ChkCollarin,
            Filtro_Chkespesor: Chkespesor,
            Filtro_ChkMedidasA: ChkMedidasA,
            Filtro_ChkMedidasB: ChkMedidasB,
            Filtro_ChkMedidasC: ChkMedidasC,
            Filtro_ChkMedidasD: ChkMedidasD,
            Filtro_ChkPosicion: ChkPosicion,
            Filtro_ChkLado: ChkLado

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
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
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
    $(Contenedor + 'txtDescripcion').val('');
    $(Contenedor + 'txtCodigo').val('');
    $(Contenedor + 'ddlEstado').val(1);

   $('#MainContent_ChkCodigoProducto').prop('checked', false);
   $('#MainContent_ChkMotor').prop('checked', false);
   $('#MainContent_ChkModelo').prop('checked', false);
   $('#MainContent_ChkAño').prop('checked', false);
   $('#MainContent_ChkMarca').prop('checked', false);
   $('#MainContent_ChkDetalles').prop('checked', false);
   $('#MainContent_ChkPlato').prop('checked', false);
   $('#MainContent_ChkDisco').prop('checked', false);
   $('#MainContent_ChkCollarin').prop('checked', false);
   $('#MainContent_ChkEspesor').prop('checked', false);
   $('#MainContent_ChkMedidaA').prop('checked', false);
   $('#MainContent_ChkMedidaB').prop('checked', false);
   $('#MainContent_ChkMedidaC').prop('checked', false);
   $('#MainContent_ChkMedidaD').prop('checked', false);
   $('#MainContent_ChkPosicion').prop('checked', false);
   $('#MainContent_ChkLado').prop('checked', false);
    return false;
}

function F_Buscar() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var objParams = {
            Filtro_DscFamilia: $("#MainContent_txtDescripcionConsulta").val()

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
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblCodFamilia'));
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

function F_EliminarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfIDFamilia = '#' + imgID.replace('imgAnularDocumento', 'hfIDFamilia');
        var lblDescripcion = '#' + imgID.replace('imgAnularDocumento', 'lblDescripcion');

        if (!confirm("ESTA SEGURO DE ELIMINAR LA FAMILIA " + $(lblDescripcion).text().toUpperCase()))
            return false;

        var objParams = {
            Filtro_IDFamilia: $(hfIDFamilia).val(),
            Filtro_DscFamilia: $('#MainContent_txtDescripcionConsulta').val()
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
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblCodFamilia'));
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

function F_EditarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var hfCodEmpresa = '#' + imgID.replace('imgEditarRegistro', 'hfCodEmpresa');
        var hfCodLinea = '#' + imgID.replace('imgEditarRegistro', 'hfIDFamilia');
        var lblCodigoLinea = '#' + imgID.replace('imgEditarRegistro', 'lblCodFamilia');
        var lblDescripcion = '#' + imgID.replace('imgEditarRegistro', 'lblDscFamilia');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        //permisos
        var hfPermisoCodigoProducto = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoCodigoProducto');
        var hfPermisoMotor = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoMotor');
        var hfPermisoModeloVehiculo = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoModeloVehiculo');
        var hfPermisoAño = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoAño');
        var hfPermisoMarcaVehiculo = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoMarcaVehiculo');
        var hfPermisoOtrosDetalles = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoOtrosDetalles');
        var hfPermisoPlato = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoPlato');
        var hfPermisoDisco = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoDisco');
        var hfPermisoCollarin = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoCollarin');
        var hfPermisoEspesor = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoEspesor');
        var hfPermisoMedidaA = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoMedidaA');
        var hfPermisoMedidaB = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoMedidaB');
        var hfPermisoMedidaC = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoMedidaC');
        var hfPermisoMedidaD = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoMedidaD');
        var hfPermisoPosicion = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoPosicion');
        var hfPermisoLado = '#' + imgID.replace('imgEditarRegistro', 'hfPermisoLado');
        var Cuerpo = '#MainContent_';

        $('#hfIDFamilia').val($(hfCodLinea).val());
        $(Cuerpo + 'ddlEmpresaEdicion').val($(hfCodEmpresa).val());
        $(Cuerpo + 'txtCodFamiliaEdicion').val($(lblCodigoLinea).text());
        $(Cuerpo + 'ddlEstadoEdicion').val($(hfCodEstado).val());
        $(Cuerpo + 'txtDescripcionEdicion').val($(lblDescripcion).text());

        $("#divEdicionRegistro").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Familia",
            title_html: true,
            height: 390,
            width: 530,
            autoOpen: false
        });

        if ($(hfPermisoCodigoProducto).val() == 1)
            $('#MainContent_ChkCodigoProductoEdicion').prop('checked', true);
        else
            $('#MainContent_ChkCodigoProductoEdicion').prop('checked', false);

        if ($(hfPermisoMotor).val() == 1)
            $('#MainContent_ChkMotorEdicion').prop('checked', true);
        else
            $('#MainContent_ChkMotorEdicion').prop('checked', false);

        if ($(hfPermisoModeloVehiculo).val() == 1)
            $('#MainContent_ChkModeloEdicion').prop('checked', true);
        else
            $('#MainContent_ChkModeloEdicion').prop('checked', false);

        if ($(hfPermisoAño).val() == 1)
            $('#MainContent_ChkAñoEdicion').prop('checked', true);
        else
            $('#MainContent_ChkAñoEdicion').prop('checked', false);

        if ($(hfPermisoMarcaVehiculo).val() == 1)
            $('#MainContent_ChkMarcaEdicion').prop('checked', true);
        else
            $('#MainContent_ChkMarcaEdicion').prop('checked', false);

        if ($(hfPermisoOtrosDetalles).val() == 1)
            $('#MainContent_ChkDetallesEdicion').prop('checked', true);
        else
            $('#MainContent_ChkDetallesEdicion').prop('checked', false);

        if ($(hfPermisoPlato).val() == 1)
            $('#MainContent_ChkPlatoEdicion').prop('checked', true);
        else
            $('#MainContent_ChkPlatoEdicion').prop('checked', false);

        if ($(hfPermisoDisco).val() == 1)
            $('#MainContent_ChkDiscoEdicion').prop('checked', true);
        else
            $('#MainContent_ChkDiscoEdicion').prop('checked', false);

        if ($(hfPermisoCollarin).val() == 1)
            $('#MainContent_ChkCollarinEdicion').prop('checked', true);
        else
            $('#MainContent_ChkCollarinEdicion').prop('checked', false);

        if ($(hfPermisoEspesor).val() == 1)
            $('#MainContent_ChkEspesorEdicion').prop('checked', true);
        else
            $('#MainContent_ChkEspesorEdicion').prop('checked', false);

        if ($(hfPermisoMedidaA).val() == 1)
            $('#MainContent_ChkMedidaAEdicion').prop('checked', true);
        else
            $('#MainContent_ChkMedidaAEdicion').prop('checked', false);

        if ($(hfPermisoMedidaB).val() == 1)
            $('#MainContent_ChkMedidaBEdicion').prop('checked', true);
        else
            $('#MainContent_ChkMedidaBEdicion').prop('checked', false);

        if ($(hfPermisoMedidaC).val() == 1)
            $('#MainContent_ChkMedidaCEdicion').prop('checked', true);
        else
            $('#MainContent_ChkMedidaCEdicion').prop('checked', false);

        if ($(hfPermisoMedidaD).val() == 1)
            $('#MainContent_ChkMedidaDEdicion').prop('checked', true);
        else
            $('#MainContent_ChkMedidaDEdicion').prop('checked', false);

        if ($(hfPermisoPosicion).val() == 1)
            $('#MainContent_ChkPosicionEdicion').prop('checked', true);
        else
            $('#MainContent_ChkPosicionEdicion').prop('checked', false);

        if ($(hfPermisoLado).val() == 1)
            $('#MainContent_ChkLadoEdicion').prop('checked', true);
        else
            $('#MainContent_ChkLadoEdicion').prop('checked', false);


        $('#divEdicionRegistro').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}

function F_EdicionRegistro() {
    try {
        var Contenedor = '#MainContent_';
        var ChkCodigoProducto = 0;
        var ChkMotor = 0;
        var ChkModeloVehiculo = 0;
        var ChkAño = 0;
        var ChkMarcaVehiculo = 0;
        var ChkOtroDetalles = 0;
        var ChkPlato = 0;
        var ChkDisco = 0;
        var ChkCollarin = 0;
        var Chkespesor = 0;
        var ChkMedidasA = 0;
        var ChkMedidasB = 0;
        var ChkMedidasC = 0;
        var ChkMedidasD = 0;
        var ChkPosicion = 0;
        var ChkLado = 0;

        if ($('#MainContent_ChkCodigoProductoEdicion').is(':checked'))
            ChkCodigoProducto = 1;
        if ($('#MainContent_ChkMotorEdicion').is(':checked'))
            ChkMotor = 1;
        if ($('#MainContent_ChkModeloEdicion').is(':checked'))
            ChkModeloVehiculo = 1;
        if ($('#MainContent_ChkAñoEdicion').is(':checked'))
            ChkAño = 1;
        if ($('#MainContent_ChkMarcaEdicion').is(':checked'))
            ChkMarcaVehiculo = 1;
        if ($('#MainContent_ChkDetallesEdicion').is(':checked'))
            ChkOtroDetalles = 1;
        if ($('#MainContent_ChkPlatoEdicion').is(':checked'))
            ChkPlato = 1;
        if ($('#MainContent_ChkDiscoEdicion').is(':checked'))
            ChkDisco = 1;
        if ($('#MainContent_ChkCollarinEdicion').is(':checked'))
            ChkCollarin = 1;
        if ($('#MainContent_ChkEspesorEdicion').is(':checked'))
            Chkespesor = 1;
        if ($('#MainContent_ChkMedidaAEdicion').is(':checked'))
            ChkMedidasA = 1;
        if ($('#MainContent_ChkMedidaBEdicion').is(':checked'))
            ChkMedidasB = 1;
        if ($('#MainContent_ChkMedidaCEdicion').is(':checked'))
            ChkMedidasC = 1;
        if ($('#MainContent_ChkMedidaDEdicion').is(':checked'))
            ChkMedidasD = 1;
        if ($('#MainContent_ChkPosicionEdicion').is(':checked'))
            ChkPosicion = 1;
        if ($('#MainContent_ChkLadoEdicion').is(':checked'))
            ChkLado = 1;

        var objParams = {
            Filtro_IDFamilia: $('#hfIDFamilia').val(),
            Filtro_CodEmpresa: $(Contenedor + 'ddlEmpresaEdicion').val(),
            Filtro_DscFamilia: $(Contenedor + 'txtDescripcionEdicion').val(),
            Filtro_CodFamilia: $(Contenedor + 'txtCodFamiliaEdicion').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoEdicion').val(),
            Filtro_ChkCodigoProducto: ChkCodigoProducto,
            Filtro_ChkMotor: ChkMotor,
            Filtro_ChkModeloVehiculo: ChkModeloVehiculo,
            Filtro_ChkAño: ChkAño,
            Filtro_ChkMarcaVehiculo: ChkMarcaVehiculo,
            Filtro_ChkOtroDetalles: ChkOtroDetalles,
            Filtro_ChkPlato: ChkPlato,
            Filtro_ChkDisco: ChkDisco,
            Filtro_ChkCollarin: ChkCollarin,
            Filtro_Chkespesor: Chkespesor,
            Filtro_ChkMedidasA: ChkMedidasA,
            Filtro_ChkMedidasB: ChkMedidasB,
            Filtro_ChkMedidasC: ChkMedidasC,
            Filtro_ChkMedidasD: ChkMedidasD,
            Filtro_ChkPosicion: ChkPosicion,
            Filtro_ChkLado: ChkLado
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
                if (str_mensaje_operacion == 'SE ACTUALIZO CORRECTAMENTE') {
                    $(Contenedor + 'txtDescripcionEdicion').val('');
                    $(Contenedor + 'ddlEstadoEdicion').val(0);
                    $('#hfIDFamilia').val('0');
                    toastr.success('Se ACTUALIZO Correctamente.');
                    F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                    $('#divEdicionRegistro').dialog('close');
                    F_Buscar();
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

function F_ValidarEdicionDocumento() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcionEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if ($(Cuerpo + 'ddlEstadoEdicion').val() == 0 || $(Cuerpo + 'ddlEstadoEdicion').val() == null)
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

