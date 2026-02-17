var AppSession = "../Maestros/ProductosMarcaWong.aspx";

var CodigoMenu = 1000;
var CodigoInterno = 7;
var FilaModelo = null;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    
    $('#divTabs').tabs();  
    $('#MainContent_btnGrabEdiProductoMarca').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {

             if (!F_ValidarGrabarProductoMarca())
                return false;

             if($('#hfCodMarca').val()==0){

             if (confirm("ESTA SEGURO DE GRABAR LA NUEVA MARCA DE PRODUCTO"))
                F_GabarProductoMarca();

              return false;
              }

             
             if (confirm("ESTA SEGURO DE ACTUALIZAR LA NUEVA MARCA DE PRODUCTO"))
                F_EdicionProductoMarca();

              return false;
              }


          
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });
    $('#MainContent_btnGrabarPais').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarGrabarPais())
                return false;

             if($('#hfCodPais').val()==0)
             {

                 if (confirm("ESTA SEGURO DE GRABAR EL PAIS"))
                   F_GrabarPais();

              return false;
             }
           
                if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DEL PAIS"))
                F_EdicionPais();
           
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
    $('#MainContent_ddlEstadoMarca').css('background', '#FFFFE0');
    $('#MainContent_ddlEstadoMarcaPPais').css('background', '#FFFFE0');
    $('#MainContent_txtCodigoPais').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionPais').css('background', '#FFFFE0');    
    $('#MainContent_txtEdicionCategoria').css('background', '#FFFFE0');
    
     

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
                        F_Update_Division_HTML('div_EstadoPais', result.split('~')[3]);                                      
                        F_BuscarProductoMarca();                    
                        $('#MainContent_ddlEstadoPais').css('background', '#FFFFE0');
                        $('#MainContent_ddlEstado').css('background', '#FFFFE0');
                        $('#MainContent_ddlEstadoMarca').css('background', '#FFFFE0');
                        $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlEstadoMarcaPPais').css('background', '#FFFFE0');                            
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
//////////////////////////MARCAS PRODUCTO//////////////////////////////
function F_BuscarProductoMarca() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var objParams = {
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
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'hfCodMarca'));
                  F_BuscarPais();
                if (str_mensaje_operacion != "")
                {
                toastr.warning(result.split('~')[1]);
                
                }
                    
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
function F_Agregar_ProductoMarca() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {

        $("#divRegEdiProMarca").dialog({//--------
            resizable: false,
            modal: true,
            title: "Agregar una Marca de Producto",
            title_html: true,
            height: 150,
            width:450,
            autoOpen: false
        });
        
        F_Nuevo();
        $('#divRegEdiProMarca').dialog('open');//--------

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

} //ready
function F_GabarProductoMarca() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var objParams = {
          
            Filtro_Descripcion: $(Contenedor + 'txtDescripcion').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoMarca').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarProductoMarca_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    toastr.success('Se Grabo Correctamente');
                    $('#divRegEdiProMarca').dialog('close');
                    
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
function F_EditarProductoMarca(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var hfCodMarca = '#' + imgID.replace('imgEditarRegistro', 'hfCodMarca');
        //var hfCodFamilia = '#' + imgID.replace('imgEditarRegistro', 'hfCodFamilia');
        var lblDescripcion = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcion');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var Cuerpo = '#MainContent_';



        $('#hfCodMarca').val($(hfCodMarca).val());
        $(Cuerpo + 'ddlEstadoMarca').val($(hfCodEstado).val());
        $(Cuerpo + 'txtDescripcion').val($(lblDescripcion).text());

        $("#divRegEdiProMarca").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de la Marca de Producto",
            title_html: true,
            height: 150,
            width: 450,
            autoOpen: false
        });

        $('#divRegEdiProMarca').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}
function F_EdicionProductoMarca() {
    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodMarca: $('#hfCodMarca').val(),
            Filtro_Descripcion: $(Contenedor + 'txtDescripcion').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoMarca').val()
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
                    $('#hfCodMarca').val('0');
                    toastr.success('Se ACTUALIZO CORRECTAMENTE.');
                    F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                    $('#divRegEdiProMarca').dialog('close');
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
function F_EliminarProductoMarca(Fila) {

    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodMarca = '#' + imgID.replace('imgAnularDocumento', 'hfCodMarca');
        var lblDescripcion = '#' + imgID.replace('imgAnularDocumento', 'lblDescripcion');

        if (!confirm("ESTA SEGURO DE ELIMINAR LA MARCA DEL PRODUCTO: " + $(lblDescripcion).text()))
            return false;

        var objParams = {
            Filtro_CodMarca: $(hfCodMarca).val(),
            
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarProductoMarca_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblDescripcion'));
                toastr.warning(result.split('~')[1]);
                F_ListarComboProductoMarca();// LLAMO A LA FUNCION QUE ACTUALIZARA EL COMBO PRODUCTOMARCA
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
////////////////////////PAIS////////////////////////////////////
var filaProductoMarcaCombo; // Variable que da el numero de fila al combo de ProductoMarca
function F_Agregar_Pais() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; 

    //ya que este metodo no se encuentra en la grilla, llamo directamente la grilla grvColsulta y a su hidden, luelo le añado la fila seleccionada que obtengo de el metodo F_LlenarGridModelo
    var hfCodMarca = '#MainContent_grvConsulta_hfCodMarca_' + filaProductoMarcaCombo;

        var Cuerpo = '#MainContent_';
        $(Cuerpo + 'ddlEstadoMarcaPPais').val($(hfCodMarca).val());

    try {

        $("#divRegEdiPais").dialog({
            resizable: false,
            modal: true,
            title: "Agregar Nuevo Pais",
            title_html: true,
            height: 170,
            width: 530,
            autoOpen: false
        });
        F_Nuevo();
        $('#divRegEdiPais').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}
function F_GrabarPais() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var objParams = {

            Filtro_CodMarca: $(Contenedor + 'ddlEstadoMarcaPPais').val(),
            Filtro_Codigo: $(Contenedor + 'txtCodigoPais').val(),
            Filtro_Descripcion: $(Contenedor + 'txtDescripcionPais').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoPais').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarPais_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    toastr.success('Se Grabo Correctamente');                                     
                    F_BuscarPais($(Contenedor + 'ddlEstadoMarcaPPais').val());
                    $(Contenedor + 'txtDescripcionPais').val('');
                    $(Contenedor + 'txtCodigoPais').val('');
                    $(Contenedor + 'ddlEstadoMarcaPPais').val(0);
                    $('#divRegEdiPais').dialog('close');
                    
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
function F_EditarPais(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var hfCodPais = '#' + imgID.replace('imgEditarRegistro', 'hfCodPais');
        var hfCodMarca = '#' + imgID.replace('imgEditarRegistro', 'hfCodMarca');
        var lblCodigo = '#' + imgID.replace('imgEditarRegistro', 'lblCodigo');
        var lblDescripcion = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcion');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        
        var Cuerpo = '#MainContent_';

        $('#hfCodPais').val($(hfCodPais).val());
        $(Cuerpo + 'ddlEstadoMarcaPPais').val($(hfCodMarca).val());
        $(Cuerpo + 'txtCodigoPais').val($(lblCodigo).text());
        $(Cuerpo + 'txtDescripcionPais').val($(lblDescripcion).text());
        $(Cuerpo + 'ddlEstadoPais').val($(hfCodEstado).val());

       $("#divRegEdiPais").dialog({
       resizable: false,
       modal: true,
       title: "Edicion del Pais",
       title_html: true,
       height: 170,
       width: 530,
       autoOpen: false
        });

        $('#divRegEdiPais').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}
function F_EdicionPais() {
    try {

        var Contenedor = '#MainContent_';
        var objParams = {
            Filtro_CodPais: $('#hfCodPais').val(),
            Filtro_CodMarca  : $(Contenedor + 'ddlEstadoMarcaPPais').val(),
            Filtro_Descripcion: $(Contenedor + 'txtDescripcionPais').val(),
            Filtro_Codigo: $(Contenedor + 'txtCodigoPais').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoPais').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EdicionPais_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE ACTUALIZO CORRECTAMENTE') { 
                          
                     toastr.success('SE ACTUALIZO CORRECTAMENTE');
                    F_Update_Division_HTML('divEdicionPais', result.split('~')[2]);
                     $('#divRegEdiPais').dialog('close');
                    F_BuscarPais($(Contenedor + 'ddlEstadoMarcaPPais').val());
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
function F_EliminarPais(Fila) {

    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var hfCodPais = '#' + imgID.replace('imgAnularDocumento', 'hfCodPais');
        var lblDescripcion = '#' + imgID.replace('imgAnularDocumento', 'lblDescripcion');
        var hfCodMarca = '#' + imgID.replace('imgAnularDocumento', 'hfCodMarca');

        if (!confirm("ESTA SEGURO DE ELIMINAR EL PAIS : " + $(lblDescripcion).text()))
            return false;

        var objParams = {
            Filtro_CodPais: $(hfCodPais).val(),
            Filtro_CodMarca: $(hfCodMarca).val()
            
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarPais_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblDescripcion'));
                toastr.warning(result.split('~')[1]);
                F_BuscarPais( $(hfCodMarca).val());
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
function F_LlenarGridPais(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
           var imgID = Fila.id;
        var hfCodMarca = '#' + imgID.replace('imgGrillaPais', 'hfCodMarca');
        filaProductoMarcaCombo = hfCodMarca.split('_').pop(); //obtengo la posicion de la fila seleccionada y la almaceno en una variable global
        F_BuscarPais($(hfCodMarca).val());
        return false

     }
function F_BuscarPais() {
    try {         
        var objParams = {
          
                        };
        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_LlenarGridPais_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
               //F_Controles_Inicializar();
                F_Update_Division_HTML('div_consulta_pais', result.split('~')[2]);
                $('#lblNumeroConsultaPais').text(F_Numerar_Grilla("grvConsultaPais",'hfCodPais'));
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

//FULL VALIDACIONES
var ExReg = /\S/;
function F_ValidarGrabarProductoMarca() {
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
function F_ValidarGrabarPais() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';
                   
        if ($(Cuerpo + 'txtDescripcionPais').val() == '')
            Cadena = Cadena + '<p></p>' + 'DESCRIPCION';      
        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        if(!ExReg.test($(Cuerpo + 'txtDescripcionPais').val())){
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

    $(Contenedor + 'txtCodigoPais').val('');//------
    
    $(Contenedor + 'txtDescripcionPais').val('');//--------
    $(Contenedor + 'ddlEstadoMarca').val(1);//------
    
    $('#hfCodMarca').val(0);//------
    $('#hfCodPais').val(0);//------
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
function F_ListarComboProductoMarca() { // FUNCION QUE ACTUALIZA EL COMBO PRODUCTOMARCA
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;
    try {
        var objParams = {};
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarComboProductoMarca_NET
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
                     F_Update_Division_HTML('div_EstadoMarcaPPais', result.split('~')[2]);
                            $('#MainContent_ddlEstadoMarcaPPais').css('background', '#FFFFE0');       
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