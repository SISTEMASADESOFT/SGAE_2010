var AppSession = "../Maestros/FamiliasWong.aspx";

var CodigoMenu = 1000;
var CodigoInterno = 7;
var FilaCategoria = null;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    
    $('#divTabs').tabs();  
    $('#MainContent_btnGrabarFamilia').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {

             if (!F_ValidarGrabarFamilia())
                return false;

             if($('#hfIDFamilia').val()==0){

             if (confirm("ESTA SEGURO DE GRABAR LA FAMILIA"))
                F_GrabarFamilia();

              return false;
              }

             
             if (confirm("ESTA SEGURO DE ACTUALIZAR LA FAMILIA"))
                F_EdicionFamilia();

              return false;
              }


          
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });
    $('#MainContent_btnGrabarCategoria').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarGrabarCategoria())
                return false;

             if($('#hfCodCategoria').val()==0)
             {

                 if (confirm("ESTA SEGURO DE GRABAR LA CATEGORIA"))
                   F_GrabarCategoria();

              return false;
             }
           
                if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DE LA CATEGORIA"))
                F_EdicionCategoria();
           
                  return false;
           


        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });
    $('#MainContent_btnGrabarTipoProducto').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    try {
        if (!F_ValidarGrabarProducto())
            return false;

          if($('#hfCodTipoProducto').val()==0){
            if (confirm("ESTA SEGURO DE GRABAR EL TIPO PRODUCTO "))

            F_GrabarProducto();

           return false;
        }
           
           if (confirm("ESTA SEGURO DE ACTUALIZAR EL TIPO PRODUCTO"))
            F_EditarTipoProductos();

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
    $('#MainContent_ddlEstadoFamilia').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionProducto').css('background', '#FFFFE0');
    $('#MainContent_ddlEstadoFamiliaCategoria').css('background', '#FFFFE0');
    $('#MainContent_txtCodigoCategoria').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionCategoria').css('background', '#FFFFE0');    
    $('#MainContent_txtEdicionCategoria').css('background', '#FFFFE0');
    
    $('#MainContent_txtCodigoProducto').css('background', '#FFFFE0');
        
     

});
$(document).on("change", "select[id $= 'MainContent_ddlFamiliaProducto']",function () {
      var Cuerpo = '#MainContent_';
      F_ListarComboCategoriar($(Cuerpo + 'ddlFamiliaProducto').val());
      
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

                        F_Update_Division_HTML('div_EstadoFamilia', result.split('~')[2])
                        F_Update_Division_HTML('div_EstadoEdicion', result.split('~')[3]);
                        F_Update_Division_HTML('div_EstadoFamiliaCategoria', result.split('~')[4]);
                        F_Update_Division_HTML('div_Almacen', result.split('~')[6]);
                        F_Update_Division_HTML('div_EstadoProducto', result.split('~')[7]);
                        F_Update_Division_HTML('div_CategoriaProducto', result.split('~')[5]);
                        F_Update_Division_HTML('div_EstadoCategoria', result.split('~')[8]);
                        F_Update_Division_HTML('div_ddlFamiliaProducto', result.split('~')[9]); 
                                      
                        F_BuscarFamilia(); 
                          setTimeout(function () {
                            let primerCheck = document.querySelector('#MainContent_grvConsulta input[onclick*="F_LlenarGridCategoria"]');
                            if (primerCheck) {
                                primerCheck.click();
                            }
                        }, 200);  
                       $('#MainContent_ddlFamiliaProducto').css('background', '#FFFFE0');                  
                       $('#MainContent_ddlEstadoCategoria').css('background', '#FFFFE0');
                       $('#MainContent_ddlEstado').css('background', '#FFFFE0');
                       $('#MainContent_ddlEstadoFamilia').css('background', '#FFFFE0');
                       $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');
                       $('#MainContent_ txtCodigoProducto').css('background', '#FFFFE0');
                       $('#MainContent_ddlAlmacen').css('background', '#FFFFE0');
                       $('#MainContent_ddlCategoriaProducto').css('background', '#FFFFE0');
                       $('#MainContent_txtDescripcionProducto').css('background', '#FFFFE0');
                       $('#MainContent_ddlEstadoProducto').css('background', '#FFFFE0');
                       $('#MainContent_ddlEstadoFamiliaCategoria').css('background', '#FFFFE0');                     
                       $('#MainContent_ddlAlmacenEdiccionProducto').css('background', '#FFFFE0');                  
                       $('.ccsestilo').css('background', '#FFFFE0');
                       $('#MainContent_ddlEstadoCategoria').val(1);
                       
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
//////////////////////////FAMILIA//////////////////////////////
function F_BuscarFamilia() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var objParams = {
            Filtro_DscFamilia: $("").val()

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
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'hfIDFamilia'));
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
function F_Agregar_Familia() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {

        $("#divRegistroFamilia").dialog({
            resizable: false,
            modal: true,
            title: "Agregar Familia",
            title_html: true,
            height: 150,
            width:450,
            autoOpen: false
        });
        
        F_Nuevo();
        $('#divRegistroFamilia').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}
function F_GrabarFamilia() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var objParams = {
          
            Filtro_DscFamilia: $(Contenedor + 'txtDescripcion').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoFamilia').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarFamilia_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    toastr.success('Se Grabo Correctamente');
                    $('#divRegistroFamilia').dialog('close');
                    
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
function F_EditarFamilia(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var hfIDFamilia = '#' + imgID.replace('imgEditarRegistro', 'hfIDFamilia');
        var hfCodFamilia = '#' + imgID.replace('imgEditarRegistro', 'hfCodFamilia');
        var lblDescripcion = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcion');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var Cuerpo = '#MainContent_';



        $('#hfIDFamilia').val($(hfIDFamilia).val());
        $(Cuerpo + 'ddlEstadoFamilia').val($(hfCodEstado).val());
        $(Cuerpo + 'txtDescripcion').val($(lblDescripcion).text());

        $("#divRegistroFamilia").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Familia",
            title_html: true,
            height: 150,
            width: 450,
            autoOpen: false
        });

        $('#divRegistroFamilia').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}
function F_EdicionFamilia() {
    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_IDFamilia: $('#hfIDFamilia').val(),
            Filtro_DscFamilia: $(Contenedor + 'txtDescripcion').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoFamilia').val()
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
                    $('#hfIDFamilia').val('0');
                    toastr.success('Se ACTUALIZO CORRECTAMENTE.');
                    F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                    $('#divRegistroFamilia').dialog('close');
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
function F_EliminarFamilia(Fila) {

    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfIDFamilia = '#' + imgID.replace('imgAnularDocumento', 'hfIDFamilia');
        var lblDescripcion = '#' + imgID.replace('imgAnularDocumento', 'lblDescripcion');

        if (!confirm("ESTA SEGURO DE ELIMINAR LA FAMILIA : " + $(lblDescripcion).text()))
            return false;

        var objParams = {
            Filtro_IDFamilia: $(hfIDFamilia).val(),
            
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarFamilia_NET(arg, function (result) {

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
////////////////////////CATEGORIA////////////////////////////////////
function F_Agregar_Categoria() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; 

    try {

        $("#divRegistroCategoria").dialog({
            resizable: false,
            modal: true,
            title: "Agregar Categoria",
            title_html: true,
            height: 170,
            width: 530,
            autoOpen: false
        });
        F_Nuevo();
        $('#divRegistroCategoria').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}

function F_GrabarCategoria() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var objParams = {

            Filtro_IDFamilia: $(Contenedor + 'ddlEstadoFamiliaCategoria').val(),
            Filtro_Codigo: $(Contenedor + 'txtCodigoCategoria').val(),
            Filtro_Descripcion: $(Contenedor + 'txtDescripcionCategoria').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoCategoria').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarCategoria_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    toastr.success('Se Grabo Correctamente');                                     
                    F_BuscarCategoria($(Contenedor + 'ddlEstadoFamiliaCategoria').val());
                    $(Contenedor + 'txtDescripcionCategoria').val('');
                    $(Contenedor + 'txtCodigoCategoria').val('');
                    $(Contenedor + 'ddlEstadoFamiliaCategoria').val(0);
                    $('#divRegistroCategoria').dialog('close');
                    
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
function F_EditarCategoria(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var hfCodCategoria = '#' + imgID.replace('imgEditarRegistro', 'hfCodCategoria');
         var hfIDFamilia = '#' + imgID.replace('imgEditarRegistro', 'hfIDFamilia');
        var lblCodigo = '#' + imgID.replace('imgEditarRegistro', 'lblCodigo');
        var lblDescripcion = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcion');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        
        var Cuerpo = '#MainContent_';

        $('#hfCodCategoria').val($(hfCodCategoria).val());
        $(Cuerpo + 'ddlEstadoFamiliaCategoria').val($(hfIDFamilia).val());
        $(Cuerpo + 'txtCodigoCategoria').val($(lblCodigo).text());
        $(Cuerpo + 'txtDescripcionCategoria').val($(lblDescripcion).text());
        $(Cuerpo + 'ddlEstadoCategoria').val($(hfCodEstado).val());

       $("#divRegistroCategoria").dialog({
       resizable: false,
       modal: true,
       title: "Edicion de Categoria",
       title_html: true,
       height: 170,
       width: 530,
       autoOpen: false
        });

        $('#divRegistroCategoria').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}
function F_EdicionCategoria() {
    try {

        var Contenedor = '#MainContent_';
        var objParams = {
            Filtro_CodCategoria: $('#hfCodCategoria').val(),
            Filtro_IDFamilia  : $(Contenedor + 'ddlEstadoFamiliaCategoria').val(),
            Filtro_Descripcion: $(Contenedor + 'txtDescripcionCategoria').val(),
            Filtro_Codigo: $(Contenedor + 'txtCodigoCategoria').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoCategoria').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EdicionCategoria_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE ACTUALIZO CORRECTAMENTE') { 
                          
                     toastr.success('SE ACTUALIZO CORRECTAMENTE');                    
                    F_Update_Division_HTML('divEdicionCategoria', result.split('~')[2]);
                     $('#divRegistroCategoria').dialog('close');
                    F_BuscarCategoria($(Contenedor + 'ddlEstadoFamiliaCategoria').val());
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
function F_EliminarCategoria(Fila) {

    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodCategoria = '#' + imgID.replace('imgAnularDocumento', 'hfCodCategoria');
        var lblDescCategoria = '#' + imgID.replace('imgAnularDocumento', 'lblDescripcion');
        var hfIDFamilia = '#' + imgID.replace('imgAnularDocumento', 'hfIDFamilia');

        if (!confirm("ESTA SEGURO DE ELIMINAR LA CATEGORIA : " + $(lblDescCategoria).text()))
            return false;

        var objParams = {
            Filtro_CodCategoria: $(hfCodCategoria).val(),
            Filtro_IDFamilia: $(hfIDFamilia).val()
            
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarCategoria_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblCodFamilia'));
                toastr.warning(result.split('~')[1]);
                F_BuscarCategoria( $(hfIDFamilia).val());
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
function F_LlenarGridCategoria(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
           var imgID = Fila.id;
        var hfIDFamilia = '#' + imgID.replace('imgGrillaCategoria', 'hfIDFamilia');
        F_BuscarCategoria($(hfIDFamilia).val());
        return false

     }
function F_BuscarCategoria(IdFamilia) {
    try {         
        var objParams = {
                    Filtro_IDFamilia: IdFamilia
                        };
        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_LlenarGridCategoria_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
               //F_Controles_Inicializar();
                F_Update_Division_HTML('div_consulta_categoria', result.split('~')[2]);
                $('#lblNumeroConsultaCategoria').text(F_Numerar_Grilla("grvConsultaCategoria",'hfCodCategoria'));
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
/////////////////////////TIPO PRODUCTO//////////////////////
var CtlgvCorreo;
var HfgvCorreo;
function F_Buscar_TipoProducto(Control) {
    CtlgvCorreo = Control;
    var Src = $(Control).attr('src');
    FilaCategoria = Control;

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_LlenarGridProducto(grid.attr('id'));        
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {        
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}
function F_LlenarGridProducto(Fila) {
    try {
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlTipoProducto', 'hfCodCategoria')).val();
        var grvNombre = 'MainContent_grvConsultaCategoria_grvTipoProducto_';

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
function F_Agregar_Producto(){
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        $("#divRegistroProducto").dialog({
            resizable: false,
            modal: true,
            title: "Agregar Tipo Producto",
            title_html: true,
            height: 210,
            width: 530,
            autoOpen: false
        });

        F_Nuevo_TipoProducto(); 
        $('#divRegistroProducto').dialog('open');
        return false;
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
        return false;
    }

}
function F_GrabarProducto() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var objParams = {        
            Filtro_IDCategoria: $(Contenedor + 'ddlCategoriaProducto').val(),
            Filtro_DscProducto: $(Contenedor + 'txtDescripcionProducto').val(),
            Filtro_CodigoProducto: $(Contenedor + 'txtCodigoProducto').val(),
            Filtro_Almacen: $(Contenedor + 'ddlAlmacen').val(),
            Filtro_EstadoProducto: $(Contenedor + 'ddlEstadoProducto').val(),
           
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarTipoProducto_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";
            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    toastr.success('Se GRABO CORRECTAMENTE');               
                   $('#divRegistroProducto').dialog('close');                     
                     //AQUI ACTUALIZA LA SUB GRILLA PRODCUCTO CON EL ID DE CATEGORIA
                  $(FilaCategoria).closest("tr").next().remove();
                  var grilla = $(FilaCategoria).next();
                   F_LlenarGridProducto(grilla.attr('id'));               
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
function F_EditarTipoProducto(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var lblCodigo = '#' + imgID.replace('imgEditarRegistro', 'lblCodigo');
        var lblDescripcion = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcion');
        var hfCodTipoProducto = '#' + imgID.replace('imgEditarRegistro', 'hfCodTipoProducto');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var hfCodAlmacen = '#' + imgID.replace('imgEditarRegistro', 'hfCodAlmacen');
        var hfCodCategoria = '#' + imgID.replace('imgEditarRegistro', 'hfCodCategoria');
        var hfIDFamilia = '#' + imgID.replace('imgEditarRegistro', 'hfIDFamilia');
 
        var Cuerpo = '#MainContent_';
        $('#hfCodTipoProducto').val($(hfCodTipoProducto).val());  
            
        $(Cuerpo + 'txtCodigoProducto').val($(lblCodigo).text());          
        $(Cuerpo + 'txtDescripcionProducto').val($(lblDescripcion).text());       
        $(Cuerpo + 'ddlAlmacen').val($(hfCodAlmacen).val());       
        $(Cuerpo + 'ddlEstadoProducto').val($(hfCodEstado).val());
        $(Cuerpo + 'ddlFamiliaProducto').val($(hfIDFamilia).val());
        $('#hfIDFamilia').val($(hfIDFamilia).val());  
                     
      //  F_ListarComboCategoriar($(hfIDFamilia).val());
    
        $(Cuerpo + 'ddlCategoriaProducto').val($(hfCodCategoria).val());  
                      
        $("#divRegistroProducto").dialog({
            resizable: false,
            modal: true,
            title: "Editar Tipo Producto",
            title_html: true,
            height: 200,
            width: 540,
            autoOpen: false
        });

        $('#divRegistroProducto').dialog('open');
        return false;
            }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
        return false;
            }
}
function F_EditarTipoProductos() {
    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodTipoProducto: $('#hfCodTipoProducto').val(), 
            Filtro_CodCategoria: $(Contenedor + 'ddlCategoriaProducto').val(),
            Filtro_CodigoProducto: $(Contenedor + 'txtCodigoProducto').val(),    
            Filtro_Descripcion: $(Contenedor + 'txtDescripcionProducto').val(),
            Filtro_CodAlmacen: $(Contenedor + 'ddlAlmacen').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoProducto').val()         
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EdicionTipoProducto_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE ACTUALIZO CORRECTAMENTE') {
               
                    
                    toastr.success('Se ACTUALIZO CORRECTAMENTE');
                    
                    F_Update_Division_HTML('divEdicionProducto', result.split('~')[2]);

                    $('#divRegistroProducto').dialog('close');


                     $(FilaCategoria).closest("tr").next().remove();
                      var grilla = $(FilaCategoria).next();
                      
                      F_LlenarGridProducto(grilla.attr('id'));
                      
                 
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
function F_EliminarTipoProducto(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodTipoProducto = '#' + imgID.replace('imgAnularDocumento', 'hfCodTipoProducto');
        var lblDescripcion = '#' + imgID.replace('imgAnularDocumento', 'lblDescripcion');

        if (!confirm("ESTA SEGURO DE ELIMINAR EL TIPO PRODUCTO : " + $(lblDescripcion).text()))
            return false;

        var objParams = {
            Filtro_CodProducto: $(hfCodTipoProducto).val()
            
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarTipoProducto_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblCodFamilia'));
                
               $(FilaCategoria).closest("tr").next().remove();
               var grilla = $(FilaCategoria).next();
               F_LlenarGridProducto(grilla.attr('id'));

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
function F_ValidarGrabarFamilia() {
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
        return true;
         }
       catch (e) {
               toastr.warning("Error Detectado: " + e);
           }
}
function F_ValidarGrabarCategoria() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'ddlEstadoFamiliaCategoria').val() == 0 || $(Cuerpo + 'ddlEstadoFamiliaCategoria').val() == null)
            Cadena = Cadena + '<p></p>' + 'FAMILIA';
        if ($(Cuerpo + 'txtCodigoCategoria').val() == '')
            Cadena = Cadena + '<p></p>' + 'CODIGO';
        if ($(Cuerpo + 'txtDescripcionCategoria').val() == '')
            Cadena = Cadena + '<p></p>' + 'DESCRIPCION';      
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
function F_ValidarGrabarProducto() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

         if ($(Cuerpo + 'ddlCategoriaProducto').val() == 0 || $(Cuerpo + 'ddlCategoriaProducto').val() == null)
         Cadena = Cadena + '<p></p>' + 'CATEGORIA';
//         if ($(Cuerpo + 'txtCodigoProducto').val() == '')
//         Cadena = Cadena + '<p></p>' + 'CODIGO';
         if ($(Cuerpo + 'txtDescripcionProducto').val() == '')
            Cadena = Cadena + '<p></p>' + 'DESCRIPCION';
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
function F_Nuevo() {
    var Contenedor = '#MainContent_';
    $(Contenedor + 'txtDescripcion').val('');

    $(Contenedor + 'txtCodigoCategoria').val('');
    
    $(Contenedor + 'txtDescripcionCategoria').val('');
    $(Contenedor + 'ddlEstadoFamilia').val(1);
    
    $('#hfIDFamilia').val(0);
    $('#hfCodCategoria').val(0);
    return false;
}
function F_Nuevo_TipoProducto() {
    var Contenedor = '#MainContent_';   
    
    $(Contenedor + 'txtCodigoProducto').val('');
    $(Contenedor + 'txtDescripcionProducto').val('');
    $(Contenedor + 'ddlAlmacen').val(3);
    $(Contenedor + 'ddlEstadoProducto').val(1);    
    $('#hfCodTipoProducto').val(0);
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
function F_ListarComboCategoriar(IDFamilia) {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;
    try {
        var objParams = {
            Filtro_IDFamilia: IDFamilia            
        };
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarComboCategoriar_NET
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
                     F_Update_Division_HTML('div_CategoriaProducto', result.split('~')[2]);

                      $('#MainContent_ddlCategoriaProducto').css('background', '#FFFFE0'); 
     
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