var AppSession = "../Maestros/VehiculoWong.aspx";

var CodigoMenu = 1000;
var CodigoInterno = 7;
var FilaModelo = null;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    
    $('#divTabs').tabs();  
    $('#MainContent_btnGrabEdiVehiculoMarca').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {

             if (!F_ValidarGrabarMarca())
                return false;

             if($('#hfCodVehiculo').val()==0){

             if (confirm("ESTA SEGURO DE GRABAR LA NUEVA MARCA DE VEHICULO"))
                F_GabarMarca();

              return false;
              }

             
             if (confirm("ESTA SEGURO DE ACTUALIZAR LA NUEVA MARCA DE VEHICULO"))
                F_EdicionMarca();

              return false;
              }


          
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });
    $('#MainContent_btnGrabarModelo').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarGrabarModelo())
                return false;

             if($('#hfCodModelo').val()==0)
             {

                 if (confirm("ESTA SEGURO DE GRABAR EL MODELO"))
                   F_GrabarModelo();

              return false;
             }
           
                if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DEL MODELO"))
                F_EdicionModelo();
           
                  return false;
           


        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });
    $('#MainContent_btnGrabarTipoMotor').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    try {
        if (!F_ValidarGrabarMotor())
            return false;

          if($('#hfCodMotor').val()==0){
            if (confirm("ESTA SEGURO DE GRABAR EL TIPO DE MOTOR "))

            F_GrabarMotor();

           return false;
        }
           
           if (confirm("ESTA SEGURO DE ACTUALIZAR EL TIPO DE MOTOR"))
            F_EditarTipoMotors();

        return false;

        }
    
        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }
    });

    F_Controles_Inicializar();
    //stylo para las cajas y combos   
    $('#MainContent_txtDescripcion').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');
    $('#MainContent_ddlEstadoVehiculo').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionMotor').css('background', '#FFFFE0');
    $('#MainContent_ddlEstadoMarcaModelo').css('background', '#FFFFE0');
    $('#MainContent_txtCodigoModelo').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionModelo').css('background', '#FFFFE0');    
    $('#MainContent_txtEdicionCategoria').css('background', '#FFFFE0');
    
    $('#MainContent_txtCodigoMotor').css('background', '#FFFFE0');
        
     

});
$(document).on("change", "select[id $= 'MainContent_ddlMarcaMotor']",function () {
      var Cuerpo = '#MainContent_';
      F_ListarComboModels($(Cuerpo + 'ddlMarcaMotor').val());
} );
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

                        F_Update_Division_HTML('divEstadoVehiculo', result.split('~')[2])
                        F_Update_Division_HTML('div_EstadoEdicion', result.split('~')[3]);
                        F_Update_Division_HTML('div_EstadoMarcaModelo', result.split('~')[4]);
                        F_Update_Division_HTML('div_ModeloMotor', result.split('~')[5]);
                        F_Update_Division_HTML('div_Almacen', result.split('~')[6]);
                        F_Update_Division_HTML('div_EstadoMotor', result.split('~')[7]);
                        F_Update_Division_HTML('div_EstadoModelo', result.split('~')[8]);
                        F_Update_Division_HTML('div_ddlMarcaMotor', result.split('~')[9]); 
                                      
                        F_BuscarMarca();   
                       $('#MainContent_ddlMarcaMotor').css('background', '#FFFFE0');                  
                       $('#MainContent_ddlEstadoModelo').css('background', '#FFFFE0');
                       $('#MainContent_ddlEstado').css('background', '#FFFFE0');
                       $('#MainContent_ddlEstadoVehiculo').css('background', '#FFFFE0');
                       $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');
                       $('#MainContent_txtCodigoMotor').css('background', '#FFFFE0');
                       $('#MainContent_ddlAlmacen').css('background', '#FFFFE0');
                       $('#MainContent_ddlModeloMotor').css('background', '#FFFFE0');
                       $('#MainContent_txtDescripcionMotor').css('background', '#FFFFE0');
                       $('#MainContent_ddlEstadoMotor').css('background', '#FFFFE0');
                       $('#MainContent_ddlEstadoMarcaModelo').css('background', '#FFFFE0');                     
                       $('#MainContent_ddlAlmacenEdiccionProducto').css('background', '#FFFFE0');                  
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
//////////////////////////MARCAS//////////////////////////////
function F_BuscarMarca() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var objParams = {
            Filtro_Descripcion: $("").val()
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
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'hfCodVehiculo'));
                F_BuscarModelo(result.split('~')[3]);
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

} //ready
function F_Agregar_Marca() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {

        $("#divRegEdiMarca").dialog({//--------
            resizable: false,
            modal: true,
            title: "Agregar Marca de Vehiculo",
            title_html: true,
            height: 150,
            width:450,
            autoOpen: false
        });
        
        F_Nuevo();
        $('#divRegEdiMarca').dialog('open');//--------

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

} //ready
function F_GabarMarca() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var objParams = {
          
            Filtro_Descripcion: $(Contenedor + 'txtDescripcion').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoVehiculo').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarMarca_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    toastr.success('Se Grabo Correctamente');
                    $('#divRegEdiMarca').dialog('close');
                    
                     F_Nuevo();
                     F_Controles_Inicializar();
                   
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
function F_EditarMarca(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var hfCodVehiculo = '#' + imgID.replace('imgEditarRegistro', 'hfCodVehiculo');
        //var hfCodFamilia = '#' + imgID.replace('imgEditarRegistro', 'hfCodFamilia');
        var lblDescripcion = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcion');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var Cuerpo = '#MainContent_';



        $('#hfCodVehiculo').val($(hfCodVehiculo).val());
        $(Cuerpo + 'ddlEstadoVehiculo').val($(hfCodEstado).val());
        $(Cuerpo + 'txtDescripcion').val($(lblDescripcion).text());

        $("#divRegEdiMarca").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de la Marca",
            title_html: true,
            height: 150,
            width: 450,
            autoOpen: false
        });

        $('#divRegEdiMarca').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}
function F_EdicionMarca() {
    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodVehiculo: $('#hfCodVehiculo').val(),
            Filtro_Descripcion: $(Contenedor + 'txtDescripcion').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoVehiculo').val()
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
                    $('#hfCodVehiculo').val('0');
                    toastr.success('Se ACTUALIZO CORRECTAMENTE.');
                    F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                    $('#divRegEdiMarca').dialog('close');
                    F_Controles_Inicializar();                    
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
function F_EliminarMarca(Fila) {

    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodVehiculo = '#' + imgID.replace('imgAnularDocumento', 'hfCodVehiculo');
        var lblDescripcion = '#' + imgID.replace('imgAnularDocumento', 'lblDescripcion');

        if (!confirm("ESTA SEGURO DE ELIMINAR LA MARCA DE VEHICULO : " + $(lblDescripcion).text()))
            return false;

        var objParams = {
            Filtro_CodVehiculo: $(hfCodVehiculo).val(),
            
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarMarca_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblDescripcion'));
                toastr.warning(result.split('~')[1]);
                F_ListarComboMarca();// LLAMO A LA FUNCION QUE ACTUALIZARA EL COMBO MARCA
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
////////////////////////MODELOS////////////////////////////////////
var filaMarcaCombo; // Variable que da el numero de fila al combo de Marca
function F_Agregar_Modelo() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; 

    try {
        //ya que este metodo no se encuentra en la grilla, llamo directamente la grilla grvColsulta y a su hidden, luelo le añado la fila seleccionada que obtengo de el metodo F_LlenarGridModelo
        var hfCodVehiculo = '#MainContent_grvConsulta_hfCodVehiculo_' + filaMarcaCombo;
        //defino por defecto la posicion del combo
        var Cuerpo = '#MainContent_';
        $(Cuerpo + 'ddlEstadoMarcaModelo').val($(hfCodVehiculo).val());

        $("#divRegistroModelo").dialog({
            resizable: false,
            modal: true,
            title: "Agregar Nuevo Modelo",
            title_html: true,
            height: 170,
            width: 530,
            autoOpen: false
        });
        F_Nuevo();
        $('#divRegistroModelo').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}
function F_GrabarModelo() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var objParams = {
            Filtro_CodVehiculo: $(Contenedor + 'ddlEstadoMarcaModelo').val(),
            Filtro_Descripcion: $(Contenedor + 'txtDescripcionModelo').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoModelo').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarModelo_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    toastr.success('Se Grabo Correctamente');                                     
                    F_BuscarModelo($(Contenedor + 'ddlEstadoMarcaModelo').val());
                    $(Contenedor + 'txtDescripcionModelo').val('');
                    $(Contenedor + 'txtCodigoModelo').val('');
                    $(Contenedor + 'ddlEstadoMarcaModelo').val(0);
                    $('#divRegistroModelo').dialog('close');
                    
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
function F_EditarModelo(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var hfCodModelo = '#' + imgID.replace('imgEditarRegistro', 'hfCodModelo');
        var hfCodVehiculo = '#' + imgID.replace('imgEditarRegistro', 'hfCodVehiculo');
        var lblCodigo = '#' + imgID.replace('imgEditarRegistro', 'lblCodigo');
        var lblDescripcion = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcion');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var see = $(hfCodVehiculo).val();
        
        var Cuerpo = '#MainContent_';

        $('#hfCodModelo').val($(hfCodModelo).val());
        $(Cuerpo + 'ddlEstadoMarcaModelo').val($(hfCodVehiculo).val());
        $(Cuerpo + 'txtCodigoModelo').val($(lblCodigo).text());
        $(Cuerpo + 'txtDescripcionModelo').val($(lblDescripcion).text());
        $(Cuerpo + 'ddlEstadoModelo').val($(hfCodEstado).val());

       $("#divRegistroModelo").dialog({
       resizable: false,
       modal: true,
       title: "Edicion del Modelo",
       title_html: true,
       height: 170,
       width: 530,
       autoOpen: false
        });

        $('#divRegistroModelo').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}
function F_EdicionModelo() {
    try {

        var Contenedor = '#MainContent_';
        var objParams = {
            Filtro_CodModelo: $('#hfCodModelo').val(),
            Filtro_CodVehiculo  : $(Contenedor + 'ddlEstadoMarcaModelo').val(),
            Filtro_Descripcion: $(Contenedor + 'txtDescripcionModelo').val(),
            Filtro_Codigo: $(Contenedor + 'txtCodigoModelo').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoModelo').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EdicionModelo_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE ACTUALIZO CORRECTAMENTE') { 
                          
                     toastr.success('SE ACTUALIZO CORRECTAMENTE');                    
                    F_Update_Division_HTML('divEdicionCategoria', result.split('~')[2]);
                     $('#divRegistroModelo').dialog('close');
                    F_BuscarModelo($(Contenedor + 'ddlEstadoMarcaModelo').val());
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
function F_EliminarModelo(Fila) {

    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodModelo = '#' + imgID.replace('imgAnularDocumento', 'hfCodModelo');
        var lblDescripcion = '#' + imgID.replace('imgAnularDocumento', 'lblDescripcion');
        var hfCodVehiculo = '#' + imgID.replace('imgAnularDocumento', 'hfCodVehiculo');

        if (!confirm("ESTA SEGURO DE ELIMINAR EL MODELO : " + $(lblDescripcion).text()))
            return false;

        var objParams = {
            Filtro_CodModelo: $(hfCodModelo).val(),
            Filtro_CodVehiculo: $(hfCodVehiculo).val()
            
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarModelo_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblDescripcion'));
                toastr.warning(result.split('~')[1]);
                F_BuscarModelo( $(hfCodVehiculo).val());
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
function F_LlenarGridModelo(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
           var imgID = Fila.id;
        var hfCodVehiculo = '#' + imgID.replace('imgGrillaModelo', 'hfCodVehiculo');
        filaMarcaCombo = hfCodVehiculo.split('_').pop(); //obtengo la posicion de la fila seleccionada y la almaceno en una variable global
        F_BuscarModelo($(hfCodVehiculo).val());
        return false

     }
function F_BuscarModelo(CodVehiculo) {
    try {         
        var objParams = {
                    Filtro_CodVehiculo: CodVehiculo
                        };
        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_LlenarGridModelo_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
               //F_Controles_Inicializar();
                F_Update_Division_HTML('div_consulta_modelo', result.split('~')[2]);
                $('#lblNumeroConsultaModelo').text(F_Numerar_Grilla("grvConsultaModelo",'hfCodModelo'));
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
/////////////////////////TIPO MOTOR//////////////////////
var CtlgvCorreo;
var HfgvCorreo;
function F_Buscar_TipoMotor(Control) {
    CtlgvCorreo = Control;
    var Src = $(Control).attr('src');
    FilaModelo = Control;

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_LlenarGridMotor(grid.attr('id'));        
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {        
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}
function F_LlenarGridMotor(Fila) {
    try {
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlTipoMotor', 'hfCodModelo')).val();
        var grvNombre = 'MainContent_grvConsultaModelo_grvTipoMotor_';

        if(Codigo=="")
        {
        Codigo=0;
        }

        if ($(HfgvCorreo).val() === "1") {
                    $(CtlgvCorreo).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvCorreo).next().html() + '</td></tr>');
                    $(CtlgvCorreo).attr('src', '../Asset/images/minus.gif');
        }
        else {
            {


                var objParams =
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,                           
                            Filtro_grvNombre: grvNombre
                        };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                
                $(CtlgvCorreo).attr('src', '../Asset/images/loading.gif');
                F_LlenarGridDetalle_NET(arg, function (result) {
                $(CtlgvCorreo).attr('src', '../Asset/images/minus.gif');        

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();
                        F_Update_Division_HTML($(p).attr('id'),result.split('~')[2]);                  
                        $(CtlgvCorreo).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvCorreo).next().html() + '</td></tr>');
                        if(str_mensaje_operacion != "")
                            toastr.warning(str_mensaje_operacion);
                            
                    }
                    else {
                        toastr.warning(str_mensaje_operacion);
                    }
                    return false;
                });
            }
        }
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("ERROR DETECTADO: " + e);
        return false;
    }
    return true;
}
function F_Agregar_Motor(){
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        
      //  var hfCodVehiculo = '#MainContent_grvConsulta_hfCodVehiculo_' + filaMarcaCombo;
        var Cuerpo = '#MainContent_';
        $(Cuerpo + 'txtDescripcionMotor').val('');
        $(Cuerpo + 'ddlEstadoMotor').val(1);
        //Reutilizo la variable global para jalar el combo marca
        
        F_ListarComboModels($(Cuerpo + 'ddlMarcaMotor').val());    //Añadir el escuchador de evento para actualizar el combo MarcaModelo

        $("#divRegistroMotor").dialog({
            resizable: false,
            modal: true,
            title: "Agregar Nuevo Tipo de Motor",
            title_html: true,
            height: 210,
            width: 530,
            autoOpen: false
        });

      //  F_Nuevo_TipoMotor(); 
        $('#divRegistroMotor').dialog('open');
        return false;
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
        return false;
    }

}
function F_GrabarMotor() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var objParams = {        
            Filtro_IDModelo: $(Contenedor + 'ddlModeloMotor').val(),
            Filtro_DescripcionMotor: $(Contenedor + 'txtDescripcionMotor').val(),    
            Filtro_EstadoMotor: $(Contenedor + 'ddlEstadoMotor').val()           
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarTipoMotor_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";
            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    toastr.success('Se GRABO CORRECTAMENTE');               
                   $('#divRegistroMotor').dialog('close');                     
                     //AQUI ACTUALIZA LA SUB GRILLA PRODCUCTO CON EL ID DE CATEGORIA
                  $(FilaModelo).closest("tr").next().remove();
                  var grilla = $(FilaModelo).next();
                   F_LlenarGridMotor(grilla.attr('id'));               
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
function F_EditarTipoMotor(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var lblDescripcion = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcion');
        var hfCodMotor = '#' + imgID.replace('imgEditarRegistro', 'hfCodMotor');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var hfCodModelo = '#' + imgID.replace('imgEditarRegistro', 'hfCodModelo');
        var hfCodVehiculo = '#' + imgID.replace('imgEditarRegistro', 'hfCodVehiculo');
 
        var Cuerpo = '#MainContent_';
        $('#hfCodMotor').val($(hfCodMotor).val());                
       
        $(Cuerpo + 'txtDescripcionMotor').val($(lblDescripcion).text());             
        $(Cuerpo + 'ddlEstadoMotor').val($(hfCodEstado).val());
        $(Cuerpo + 'ddlMarcaMotor').val($(hfCodVehiculo).val());
        $('#hfCodVehiculo').val($(hfCodVehiculo).val());  

        F_ListarComboModels($(hfCodVehiculo).val());
    
       $(Cuerpo + 'ddlModeloMotor').val($(hfCodModelo).val());
                      
        $("#divRegistroMotor").dialog({
            resizable: false,
            modal: true,
            title: "Editar Tipo De Motor",
            title_html: true,
            height: 200,
            width: 540,
            autoOpen: false
        });

        $('#divRegistroMotor').dialog('open');
        return false;
            }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
        return false;
            }
}
function F_EditarTipoMotors() {
    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodMotor: $('#hfCodMotor').val(), 
            Filtro_CodModelo: $(Contenedor + 'ddlModeloMotor').val(),        
            Filtro_Descripcion: $(Contenedor + 'txtDescripcionMotor').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoMotor').val()         
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EdicionTipoMotor_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE ACTUALIZO CORRECTAMENTE') {
               
                    
                    toastr.success('Se ACTUALIZO CORRECTAMENTE');
                    
                    F_Update_Division_HTML('divEdicionProducto', result.split('~')[2]);

                    $('#divRegistroMotor').dialog('close');


                     $(FilaModelo).closest("tr").next().remove();
                      var grilla = $(FilaModelo).next();
                      
                      F_LlenarGridMotor(grilla.attr('id'));
                      
                 
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
function F_EliminarTipoMotor(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodMotor = '#' + imgID.replace('imgAnularDocumento', 'hfCodMotor');
        var lblDescripcion = '#' + imgID.replace('imgAnularDocumento', 'lblDescripcion');

        if (!confirm("ESTA SEGURO DE ELIMINAR EL TIPO MOTOR: " + $(lblDescripcion).text()))
            return false;

        var objParams = {
            Filtro_CodMotor: $(hfCodMotor).val()
            
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarTipoMotor_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblCodFamilia'));
                
               $(FilaModelo).closest("tr").next().remove();
               var grilla = $(FilaModelo).next();
               F_LlenarGridMotor(grilla.attr('id'));

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

//FULL VALIDACIONES
var ExReg = /\S/;
function F_ValidarGrabarMarca() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcion').val() == '')
            Cadena = Cadena + '<p></p>' + 'DESCRIPCION';
        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        if(!ExReg.test($(Cuerpo + 'txtDescripcion').val())){
            toastr.warning('La descripcion debe contener almenos un caracter');
            return false;
        }
        return true;
         }
       catch (e) {
               toastr.warning("Error Detectado: " + e);
           }
}
function F_ValidarGrabarModelo() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'ddlEstadoMarcaModelo').val() == 0 || $(Cuerpo + 'ddlEstadoMarcaModelo').val() == null)
            Cadena = Cadena + '<p></p>' + 'MARCA';
        if ($(Cuerpo + 'txtDescripcionModelo').val() == '')
            Cadena = Cadena + '<p></p>' + 'DESCRIPCION';      
        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        if(!ExReg.test($(Cuerpo + 'txtDescripcionModelo').val())){
            toastr.warning('La descripcion debe contener almenos un caracter');
            return false;
        }
        return true;
    }
    catch (e) {
            toastr.warning("Error Detectado: " + e);
    }
}
function F_ValidarGrabarMotor() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

         if ($(Cuerpo + 'ddlModeloMotor').val() == 0 || $(Cuerpo + 'ddlModeloMotor').val() == null)
         Cadena = Cadena + '<p></p>' + 'MODELO';       
         if ($(Cuerpo + 'txtDescripcionMotor').val() == '')
            Cadena = Cadena + '<p></p>' + 'DESCRIPCION';
         if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        if(!ExReg.test($(Cuerpo + 'txtDescripcionMotor').val())){
            toastr.warning('La descripcion debe contener almenos un caracter');
            return false;
        }
        return true;
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
    }
}
function F_Nuevo() {
    var Contenedor = '#MainContent_';
    $(Contenedor + 'txtDescripcion').val('');

    $(Contenedor + 'txtCodigoModelo').val('');//------
    
    $(Contenedor + 'txtDescripcionModelo').val('');//--------
    $(Contenedor + 'ddlEstadoVehiculo').val(1);//------
    
    $('#hfCodVehiculo').val(0);//------
    $('#hfCodModelo').val(0);//------
    return false;
} 
function F_Nuevo_TipoMotor() {
    var Contenedor = '#MainContent_';   
    
    $(Contenedor + 'txtCodigoMotor').val('');
    $(Contenedor + 'txtDescripcionMotor').val('');
    $(Contenedor + 'ddlAlmacen').val(3);
    $(Contenedor + 'ddlEstadoMotor').val(1);    
    $('#hfCodMotor').val(0);
    return false;
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
function F_ListarComboModels(CodVehiculo) {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;
    try {
        var objParams = {
            Filtro_CodVehiculo: CodVehiculo            
        };
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarComboModels_NET
            (
                arg,
                function (result) {
                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") 
                    {
                     F_Update_Division_HTML('div_ModeloMotor', result.split('~')[2]);
                            $('#MainContent_ddlModeloMotor').css('background', '#FFFFE0');       
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
function F_ListarComboMarca() { // FUNCION QUE ACTUALIZA EL COMBO MARCA
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;
    try {
        var objParams = {};
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarComboMarca_NET
            (
                arg,
                function (result) {
                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") 
                    {
                     F_Update_Division_HTML('div_EstadoMarcaModelo', result.split('~')[2]);
                            $('#MainContent_ddlEstadoMarcaModelo').css('background', '#FFFFE0');       
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