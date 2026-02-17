$(document).ready(function () {
    $(".account").click(function () {
        var X = $(this).attr('id');

        if (X == 1) {
            $(".submenu").hide();
            $(this).attr('id', '0');
            $('#lblNombreUsuario').css('color', 'white');
        }
        else {
            $(".submenu").show();
            $(this).attr('id', '1');
            $('#lblNombreUsuario').css('color', 'black');
        }

    });

    //Mouseup textarea false
    $(".submenu").mouseup(function () {
        $('#lblNombreUsuario').css('color', 'white');
        return false
    });
    $(".account").mouseup(function () {
        $('#lblNombreUsuario').css('color', 'white');
        return false
    });


    //Textarea without editing.
    $(document).mouseup(function () {
        $('#lblNombreUsuario').css('color', 'white');
        $(".submenu").hide();
        $(".account").attr('id', '');
    });

    $("#btnSalirSistema").click(function () {

        if (!confirm("¿SALIR DEL SISTEMA?"))
            return false;

        document.location = '../Salir.aspx';
    });

});

function F_Update_Division_HTML(str_nombre_div, str_valor_div) {

    $('#' + str_nombre_div).css('display', 'none');
    $('#' + str_nombre_div).html(str_valor_div);
    $('#' + str_nombre_div).css('display', 'block');

}

function F_General_Inicializar_UserControl_Paginacion(str_nombre_control_paginacion) {

    $('#' + str_nombre_control_paginacion + '_hid_total_paginas').val(0);
    $('#' + str_nombre_control_paginacion + '_lbl_total_paginas').text(0);
    $('#' + str_nombre_control_paginacion + '_txt_pagina').val(0);

}

function F_General_Validar_UserControl_Paginacion(str_nombre_control_paginacion) {

    var str_pagina_actual;
    var str_pagina_total;

    str_pagina_actual = $('#' + str_nombre_control_paginacion + "_txt_pagina").val();
    str_pagina_total = $("#" + str_nombre_control_paginacion + "_hid_total_paginas").val();

    if (parseInt(str_pagina_actual) > (str_pagina_total)) {

        $('#' + str_nombre_control_paginacion + "_txt_pagina").val(str_pagina_total);

    }
    else {

        if (parseInt(str_pagina_actual) == 0) {

            $('#' + str_nombre_control_paginacion + "_txt_pagina").val("1");

        }
        else {

            $('#' + str_nombre_control_paginacion + "_txt_pagina").val(str_pagina_actual);

        }

    }

}

function F_General_Validar_Resultado_Busqueda_UserControl_Paginacion(str_nombre_control_paginacion, str_tipo_busqueda, str_valor) {

    $('#' + str_nombre_control_paginacion + '_hid_total_paginas').val(str_valor);
    $('#' + str_nombre_control_paginacion + '_lbl_total_paginas').text(str_valor);

    if (str_tipo_busqueda == "0" & str_valor != "0") {

        //una nueva busqueda

        $('#' + str_nombre_control_paginacion + '_txt_pagina').val(1);

    }
    else {

        if (str_valor == "0") {

            $('#' + str_nombre_control_paginacion + '_txt_pagina').val(0);

        }

    }

}

function F_General_Limpiar_Control_Buscador_Instituto(str_contro_busqueda_instituto) {

    $('#' + str_contro_busqueda_instituto + '_txt_bus_ins_codigo').val('');
    $('#' + str_contro_busqueda_instituto + '_txt_bus_ins_region').val('');
    $('#' + str_contro_busqueda_instituto + '_txt_bus_ins_descripcion').val('');
    $('#' + str_contro_busqueda_instituto + '_hid_bus_ins_id_instituto').val('');

}

function F_General_Limpiar_Control_Buscador_Docente(str_contro_busqueda_docente) {

    $('#' + str_contro_busqueda_docente + '_txt_bus_codigo').val('');
    $('#' + str_contro_busqueda_docente + '_txt_bus_docente').val('');
    $('#' + str_contro_busqueda_docente + '_hid_bus_id_docente').val('');

    F_General_Limpiar_Control_Buscador_Instituto(str_contro_busqueda_docente + "_" + "txt_bus_instituto");

    $('#' + str_contro_busqueda_docente + '_txt_busqueda').val('');

}

function F_General_Limpiar_Control_Buscador_Alumno(str_control_busqueda_alumno) {


    $('#' + str_control_busqueda_alumno + '_txt_bus_codigo').val('');
    $('#' + str_control_busqueda_alumno + '_txt_bus_alumno').val('');
    $('#' + str_control_busqueda_alumno + '_hid_bus_id_alumno').val('');

    F_General_Limpiar_Control_Buscador_Instituto(str_control_busqueda_alumno + "_" + "txt_bus_instituto");

    $('#' + str_control_busqueda_alumno + '_ddl_bus_especialidad').empty();

    $('#' + str_control_busqueda_alumno + '_txt_busqueda').val('');

}

function F_General_Limpiar_Control_Buscador_Curso(str_control_busqueda_curso) {

    $('#' + str_control_busqueda_curso + '_txt_bus_codigo').val('');
    $('#' + str_control_busqueda_curso + '_txt_bus_curso').val('');
    $('#' + str_control_busqueda_curso + '_hid_bus_id_curso').val('');

    $('#' + str_control_busqueda_curso + '_ddl_bus_especialidad').empty();
    $('#' + str_control_busqueda_curso + '_ddl_bus_curricula').empty();
    $('#' + str_control_busqueda_curso + '_txt_curso').val('');

}

function F_General_Limpiar_Control_Buscador_Unidad_Didactica(str_control_busqueda_curso) {

    $('#' + str_control_busqueda_curso + '_txt_bus_codigo').val('');
    $('#' + str_control_busqueda_curso + '_txt_bus_curso').val('');
    $('#' + str_control_busqueda_curso + '_hid_bus_id_curso').val('');

    $('#' + str_control_busqueda_curso + '_ddl_bus_especialidad').empty();
    $('#' + str_control_busqueda_curso + '_txt_curso').val('');

}

function F_General_Limpiar_Control_Buscador_Ubigeo(str_control_busqueda_ubigeo) {

    $('#' + str_control_busqueda_ubigeo + '_txt_bus_ubi_cod_ubigeo').val('');
    $('#' + str_control_busqueda_ubigeo + '_txt_bus_ubi_departamento').val('');
    $('#' + str_control_busqueda_ubigeo + '_txt_bus_ubi_provincia').val('');
    $('#' + str_control_busqueda_ubigeo + '_txt_bus_ubi_distrito').val('');
    $('#' + str_control_busqueda_ubigeo + '_hid_bus_id_distrito').val('');

}

function F_General_Asignar_Valores_Control_Buscador_Instituto(str_contro_busqueda_instituto, str_codigo, str_region, str_descripcion, str_id) {

    $('#' + str_contro_busqueda_instituto + '_txt_bus_ins_codigo').val(str_codigo);
    $('#' + str_contro_busqueda_instituto + '_txt_bus_ins_region').val(str_region);
    $('#' + str_contro_busqueda_instituto + '_txt_bus_ins_descripcion').val(str_descripcion);
    $('#' + str_contro_busqueda_instituto + '_hid_bus_ins_id_instituto').val(str_id);

}

function F_General_Asignar_Valores_Control_Buscador_Alumno(str_control_busqueda_alumno, str_codigo, str_alumno, str_id_alumno) {

    $('#' + str_control_busqueda_alumno + '_txt_bus_codigo').val(str_codigo);
    $('#' + str_control_busqueda_alumno + '_txt_bus_alumno').val(str_alumno);
    $('#' + str_control_busqueda_alumno + '_hid_bus_id_alumno').val(str_id_alumno);

}

function F_General_Asignar_Valores_Control_Buscador_Docente(str_contro_busqueda_docente, str_dni, str_docente, str_id_docente) {

    $('#' + str_contro_busqueda_docente + '_txt_bus_codigo').val(str_dni);
    $('#' + str_contro_busqueda_docente + '_txt_bus_docente').val(str_docente);
    $('#' + str_contro_busqueda_docente + '_hid_bus_id_docente').val(str_id_docente);

}

function F_General_Asignar_Valores_Control_Buscador_Unidad_Didactica(str_control_busqueda_ud, str_codigo, str_unidad_didactica, str_id_ud) {

    $('#' + str_control_busqueda_ud + '_txt_bus_codigo').val(str_codigo);
    $('#' + str_control_busqueda_ud + '_txt_bus_curso').val(str_unidad_didactica);
    $('#' + str_control_busqueda_ud + '_hid_bus_id_curso').val(str_id_ud);

}

function F_Habilitar_Menu_Modulo_Seguridad() {

    $('ul#menu_seguridad').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Configuracion_Basica() {

    $('ul#menu_configuracion_basica').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Admision_Mantenimiento() {

    $('ul#menu_admision').css('display', 'block');
    $('ul#menu_admision_mantenimiento').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Admision_Operaciones() {

    $('ul#menu_admision').css('display', 'block');
    $('ul#menu_admision_operaciones').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Admision_Operaciones_Exonerados() {

    $('ul#menu_admision').css('display', 'block');
    $('ul#menu_admision_operaciones').css('display', 'block');
    $('ul#menu_admision_exonerados').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Admision_Operaciones_Ordinarios() {

    $('ul#menu_admision').css('display', 'block');
    $('ul#menu_admision_operaciones').css('display', 'block');
    $('ul#menu_admision_ordinarios').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Academico_Mantenimiento() {

    $('ul#menu_academico').css('display', 'block');
    $('ul#menu_academico_mantenimiento').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Academico_Operaciones() {

    $('ul#menu_academico').css('display', 'block');
    $('ul#menu_academico_operaciones').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Academico_Reportes() {

    $('ul#menu_academico').css('display', 'block');
    $('ul#menu_academico_reportes').css('display', 'block');

}

function F_General_MostrarEspera(pboolMostrar) {
    if (pboolMostrar) {
        $('#dlgWait').dialog({
            autoOpen: false,
            modal: true,
            height: 'auto',
            resizable: false,
            dialogClass: 'alert'
        });

        $('.alert div.ui-dialog-titlebar').hide();
        $('.ui-button').remove();
        $('#dlgWait').dialog('open');
    }
    else {
        $('#dlgWait').dialog('close');
    }
}

function Date_AddDays(strFechaIni, intDias) {
    //  --> "intDias" + "strFechaIni" = "strFechaFin"
    var strFechaFin = '';

    milisegundos = parseInt(35 * 24 * 60 * 60 * 1000, 10);

    day = strFechaIni.split('/')[0];
    month = strFechaIni.split('/')[1];
    year = strFechaIni.split('/')[2];

    fecha = new Date(year, month - 1, day);

    //Obtenemos los milisegundos desde media noche del 1/1/1970
    tiempo = fecha.getTime();

    //Calculamos los milisegundos sobre la fecha que hay que sumar o restar...
    milisegundos = parseInt(intDias * 24 * 60 * 60 * 1000, 10);

    //Modificamos la fecha actual
    total = fecha.setTime(tiempo + milisegundos);

    day = fecha.getDate();
    month = fecha.getMonth() + 1;
    year = fecha.getFullYear();

    day = '0' + day;
    month = '0' + month;

    day = day.slice(-2);
    month = month.slice(-2);

    strFechaFin = day + '/' + month + '/' + year;

    return strFechaFin;
}

function F_Derecha() {
    $('.Derecha').css('text-align', 'right');
}

function forceNumber(element) {
    element
    .data("oldValue", '')
    .bind("paste", function (e) {
        var validNumber = /^[-]?\d+(\.\d{1,2})?$/;
        element.data('oldValue', element.val())
        setTimeout(function () {
            if (!validNumber.test(element.val()))
                element.val(element.data('oldValue'));
        }, 0);
    });
    element
    .keypress(function (event) {
        var text = $(this).val();
        if ((event.which != 46 || text.indexOf('.') != -1) && //if the keypress is not a . or there is already a decimal point
        ((event.which < 48 || event.which > 57) && //and you try to enter something that isn't a number
          (event.which != 45 || (element[0].selectionStart != 0 || text.indexOf('-') != -1)) && //and the keypress is not a -, or the cursor is not at the beginning, or there is already a -
          (event.which != 0 && event.which != 8))) { //and the keypress is not a backspace or arrow key (in FF)
            event.preventDefault(); //cancel the keypress
        }

        if ((text.indexOf('.') != -1) && (text.substring(text.indexOf('.')).length > 2) && //if there is a decimal point, and there are more than two digits after the decimal point
        ((element[0].selectionStart - element[0].selectionEnd) == 0) && //and no part of the input is selected
        (element[0].selectionStart >= element.val().length - 2) && //and the cursor is to the right of the decimal point
        (event.which != 45 || (element[0].selectionStart != 0 || text.indexOf('-') != -1)) && //and the keypress is not a -, or the cursor is not at the beginning, or there is already a -
        (event.which != 0 && event.which != 8)) { //and the keypress is not a backspace or arrow key (in FF)
            event.preventDefault(); //cancel the keypress
        }
    });
}

var VerificarSession = true;
$().ready(function () {
//    $(document).everyTime(600000, function () {
    $(document).everyTime(10000, function () {
        if (!F_ValidaSesionActiva('', true)) return false;
    });
});

function F_SesionRedireccionar(directorio) {
    return F_ValidaSesionActiva(directorio, true);
}

var redireccionar = false;
function F_ValidaSesionActiva(directorio, Redir) {
    if (VerificarSession === false)
        return true;

    var Espera = false;
    var Resultado = false;
    redireccionar = Redir;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        url: '../Servicios/Servicios.asmx/KeepActiveSession?time=' + timex,
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (obj, status) {
            if (obj.d.SesionActiva === false) //cambiar a false
            {
                if (redireccionar == true) window.location.href = "../ErrorSession.aspx";
            }
            else {
                Resultado = true;

                var dt = new Date();
                var time = dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds();

                var NombreUsuario = obj.d.Nombre; // +' ' + obj.d.Apellidos;
                if (NombreUsuario.trim() === '')
                    NombreUsuario = obj.d.NombreUsuario;

                if (NombreUsuario.trim() === '')
                    NombreUsuario = '';

                $('#lblAlmacen').text("sucursal : " + obj.d.Almacen);
                $('#imgUsuario').css('display', 'block');
                //$('#imgUsuario').attr('src', '../Asset/images/mainuser.png');
                $('#lblNombreUsuario').text(NombreUsuario.trim().split(' ')[0]);
                $('#lblNombreEmpresa').text('sgae - ' + obj.d.Empresa);



                var rutaImg;
                rutaImg = "../files/temp/session/" + obj.d.ImagenNombre;
                var result = doesFileExist(rutaImg);
                if (result === false) {
                    rutaImg = "../../files/temp/session/" + obj.d.ImagenNombre;
                    result = doesFileExist(rutaImg);
                    if (result === false)
                        rutaImg = "../Asset/images/mainuser.png";
                            result = doesFileExist(rutaImg);
                            if (result === false)
                                rutaImg = "../Asset/images/mainuser.png";
                }
                //var img = new File([""], rutaImg);
                //                if (img.size === 0) {
                //rutaImg = "../files/temp/session/" + obj.d.ImagenNombre;
                //                    img = new File([""], rutaImg);
                //                    if (!img.isFile()) {
                //rutaImg = "../Asset/images/mainuser.png"
                //                    }

                var result = doesFileExist(rutaImg);

                $('#imgUsuario').attr('src', rutaImg);




            };
            redireccionar = false;
            Espera = true;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            alertify.log(textStatus + ": " + XMLHttpRequest.responseText);
            Espera = true;
            Resultado = false;
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax
    return Resultado;
}

function F_ValidarCorreo(Correo) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test(Correo);
}

function F_ValidarCelular(Celular) {
    var Cadena = "";
  
    if (Celular != '' & Celular.length != 9)
        Cadena = Cadena + '<p></p>' + 'Celular debe tener 9 digitos';

    if (Celular != '' & Celular.substring(0, 1) != 9)
        Cadena = Cadena + '<p></p>' + 'Celular debe empezar con 9';

   return Cadena;
}


//Este fragmento de codigo a veces da errores, pero está bien que lo de
//es decir, son errores provocados, ya que valida la existencia de algunos 
//directorios para poder realizar diferentes acciones
function doesFileExist(urlToFile) {
    var xhr = new XMLHttpRequest();
    xhr.open('HEAD', urlToFile, false);
    xhr.send();

    if (xhr.status == "404") {
        return false;
    } else {
        return true;
    }
}

function F_PermisoOpcion(CodigoMenu, CodigoInterno, Opcion) {
    //Para mas facil compresion se utiliza los campos CodigoMenu y CodigoInterno
    //de las tablas Menu, MenuPaginas, y tambien MenuPaginasFunciones.... 
    //debes seguir las reglas de NORMALIZACION DE TABLAS para poder trabajar con ello
    //el parametro Opcion es (Opcional), se pasa en blanco '' cuando no es necesario
    //--
    //La funcion retorna 1/0 tipo texto, donde 1 es true o si tiene permiso.
    //--
    //PERMISOS DENTRO DE LA PAGINA: ------Administrador, Insertar, Consultar, Editar, Eliminar, Anular------
    //son los permisos especificos por cada pagina, se personalizan en la pagina Perfiles.
    //Quiero saber si el usuario logeado tiene permiso de Eliminar clientes..::
    //... se pasan las opciones: F_PermisoOpcion(1000, 1, 'Eliminar')
    //Donde 1000 es el menu de Maestros (Tabla Menu.CodigoMenu), 1 es la Pagina de Clientes (tabla MenuPaginas.CodigoInterno)...
    //--
    //FUNCIONES ESPECIALES DE PAGINA; Si quieres saber si tienes permiso a una funcion de pagina por ejemplo:
    //Permiso especial para aprobar pedidos "VENTAS >> NOTA DE PEDIDO >> APROBACION DE CREDITOS"
    //... se pasan las opciones: F_PermisoOpcion(3000, 777001, '')
    //donde 3000 es el menu de Ventas (Tabla Menu.CodigoMenu), y 777001 Funcion (tabla MenuPaginasFunciones.CodigoInterno)



    var Espera = false; var Resultado = "0";
    var dtx = new Date(); var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Seguridad.asmx/F_PermisoOpcion',
        data: "{'CodigoMenu':'" + CodigoMenu + "','CodigoInterno':'" + CodigoInterno + "','Opcion':'" + Opcion + "'}",
        dataType: "json",
        async: false,
        success: function (obj, status) {
            Resultado = obj.d;
            Espera = true;

            if (Resultado === "0") {

                var textoMensaje = "";
                switch (Opcion) {
                    case "Administrador": textoMensaje = "NO TIENE PERMISO DE ADMINISTRADOR DE PAGINA"; break;
                    case "Insertar": textoMensaje = "NO TIENE PERMISO DE GRABAR NUEVOS DATOS EN ESTA PAGINA"; break;                    
                    case "Consultar": textoMensaje = "NO TIENE PERMISO DE CONSULTAR EN ESTA PAGINA"; break;
                    case "Editar": textoMensaje = "NO TIENE PERMISO DE MODIFICAR INFORMACION EN ESTA PAGINA"; break;
                    case "Eliminar": textoMensaje = "NO TIENE PERMISO DE ELIMINAR DATOS EN ESTA PAGINA"; break;
                    case "Anular": textoMensaje = "NO TIENE PERMISO DE ANULAR REGISTROS EN ESTA PAGINA"; break;
                    default: textoMensaje = "NO TIENE PERMISO A EJECUTAR ESTA OPCION"; break;
                }
                try {
                    alertify.error(textoMensaje);
                } catch (e) {
                    toastr.error(textoMensaje);
                }
                
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            alertify.log(textStatus + ": " + XMLHttpRequest.responseText);
            Espera = true;
            Resultado = false;
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax
    return Resultado;
}

function F_PermisoOpcion_SinAviso(CodigoMenu, CodigoInterno, Opcion) {
    //Para mas facil compresion se utiliza los campos CodigoMenu y CodigoInterno
    //de las tablas Menu, MenuPaginas, y tambien MenuPaginasFunciones.... 
    //debes seguir las reglas de NORMALIZACION DE TABLAS para poder trabajar con ello
    //el parametro Opcion es (Opcional), se pasa en blanco '' cuando no es necesario
    //--
    //La funcion retorna 1/0 tipo texto, donde 1 es true o si tiene permiso.
    //--
    //PERMISOS DENTRO DE LA PAGINA: ------Administrador, Insertar, Consultar, Editar, Eliminar, Anular------
    //son los permisos especificos por cada pagina, se personalizan en la pagina Perfiles.
    //Quiero saber si el usuario logeado tiene permiso de Eliminar clientes..::
    //... se pasan las opciones: F_PermisoOpcion(1000, 1, 'Eliminar')
    //Donde 1000 es el menu de Maestros (Tabla Menu.CodigoMenu), 1 es la Pagina de Clientes (tabla MenuPaginas.CodigoInterno)...
    //--
    //FUNCIONES ESPECIALES DE PAGINA; Si quieres saber si tienes permiso a una funcion de pagina por ejemplo:
    //Permiso especial para aprobar pedidos "VENTAS >> NOTA DE PEDIDO >> APROBACION DE CREDITOS"
    //... se pasan las opciones: F_PermisoOpcion(3000, 777001, '')
    //donde 3000 es el menu de Ventas (Tabla Menu.CodigoMenu), y 777001 Funcion (tabla MenuPaginasFunciones.CodigoInterno)



    var Espera = false; var Resultado = "0";
    var dtx = new Date(); var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Seguridad.asmx/F_PermisoOpcion',
        data: "{'CodigoMenu':'" + CodigoMenu + "','CodigoInterno':'" + CodigoInterno + "','Opcion':'" + Opcion + "'}",
        dataType: "json",
        async: false,
        success: function (obj, status) {
            Resultado = obj.d;
            Espera = true;

            if (Resultado === "0") {

                var textoMensaje = "";
                switch (Opcion) {
                    case "Administrador": textoMensaje = "NO TIENE PERMISO DE ADMINISTRADOR DE PAGINA"; break;
                    case "Insertar": textoMensaje = "NO TIENE PERMISO DE GRABAR NUEVOS DATOS EN ESTA PAGINA"; break;
                    case "Consultar": textoMensaje = "NO TIENE PERMISO DE CONSULTAR EN ESTA PAGINA"; break;
                    case "Editar": textoMensaje = "NO TIENE PERMISO DE MODIFICAR INFORMACION EN ESTA PAGINA"; break;
                    case "Eliminar": textoMensaje = "NO TIENE PERMISO DE ELIMINAR DATOS EN ESTA PAGINA"; break;
                    case "Anular": textoMensaje = "NO TIENE PERMISO DE ANULAR REGISTROS EN ESTA PAGINA"; break;
                    default: textoMensaje = "NO TIENE PERMISO A EJECUTAR ESTA OPCION"; break;
                }
                //alertify.error(textoMensaje);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            alertify.log(textStatus + ": " + XMLHttpRequest.responseText);
            Espera = true;
            Resultado = false;
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax
    return Resultado;
}

function F_ParametrosPagina(Parametro, CodigoMenu, CodigoInterno) {

    var Espera = false; var Resultado = "0";
    var dtx = new Date(); var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_ParametrosListar',
        data: "{'Parametro':'" + Parametro + "','CodigoMenu':'" + CodigoMenu + "','CodigoInterno':'" + CodigoInterno + "'}",
        dataType: "json",
        async: false,
        success: function (obj, status) {
            if (Parametro === '')
                Resultado = obj.d; //si no se le pasa parametro solo pregunta por el listado
            else 
                Resultado = obj.d[0].Valor; //si pasa un parametro pregunta por un valor en especifico

            Espera = true;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            alertify.log(textStatus + ": " + XMLHttpRequest.responseText);
            Espera = true;
            Resultado = "0";
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax
    return Resultado;
}

function F_ContarRowsGrilla(nombreGrilla, nombreCheck, nombreColumna) {
    var chkSi = ''; var colVal = '';
    var cc = 0;

    $('#MainContent_' + nombreGrilla + ' :checkbox').each(function () {
        chkSi = '#' + this.id;
        colVal = chkSi.replace(nombreCheck, nombreColumna);
        if ($(colVal).val() === "" & $(colVal).text() === "") { } else {
            cc++;
        }
    });

    return cc;
}

function F_GraficosJsonACartesiano_DATA(d) {

    let data = []
    for (let j = 0; j < d.length; j++) {

        var DatosXYs = new Object();
        DatosXYs["x"] = d[j].X;
        
        //creo los periodos
        for (let ii = 0; ii < d[j].Ys.length; ii++) { 
            DatosXYs[d[j].Ys[ii].Titulo] = d[j].Ys[ii].Valor;
        }

        data.push(DatosXYs)
        DatosXYs = {};
    };

    return data;
}

function F_GraficosJsonACartesiano_YKEYS(d) {
    let yKeys = []
    var pass = false;
    for (let j = 0; j < d.length; j++) {
        
        //creo los periodos
        for (let ii = 0; ii < d[j].Ys.length; ii++) { 
            if (pass === false)
                yKeys.push(d[j].Ys[ii].Titulo);
        };
    pass = true;
    }
    return yKeys;
}

function F_Numerar_Grilla(NombreGrilla,NombreLabel) { 
    if (NombreLabel.substring(0, 3)=='lbl')      
        var Control = $('#MainContent_' + NombreGrilla + '_' + NombreLabel + '_0').text();
    else
        var Control = $('#MainContent_' + NombreGrilla + '_' + NombreLabel + '_0').val();

    var C=0;
    $('#MainContent_' + NombreGrilla + ' .detallesart').each(function () {
        C++;
    });
    if (C==1 & Control=='')
        C=0;
    return C;
}


function F_Numerar_Grilla2(NombreGrilla, NombreLabel) { 
    if (NombreLabel.substring(0, 3)=='lbl')      
        var Control = $('#MainContent_' + NombreGrilla + '_' + NombreLabel + '_0').text();
    else
        var Control = $('#MainContent_' + NombreGrilla + '_' + NombreLabel + '_0').val();

    var C=0;

    $('#MainContent_' + NombreGrilla + ' .detallesart').each(function () {
        var texto = $.trim($(this).text());
        if (texto !== '' && texto !== '&nbsp;') {//vacio
            C++;
        }
    });

    return C;
}

function F_Estados_Grilla(NombreGrilla,Numero,Estado) {       
    $('#MainContent_' + NombreGrilla + ' .detallesart').each(function () {
            var Fila= '#' + this.id; 
            var lblEstado=Fila.replace(Numero,Estado);     
            switch ($(lblEstado).text()) {
                    case 'ANULADO':
                    $(lblEstado).css("color","black");
                    break;
                    case 'PENDIENTE':
                    $(lblEstado).css("color","red");
                    break;
                    case 'CANCELADO':
                    $(lblEstado).css("color","green");
                    break;
                    case 'FACTURADO':
                    $(lblEstado).css("color","green");
                    break;
                    case 'APROBADO':
                    $(lblEstado).css("color","Blue");
                    case 'CONFIRMADO':
                    $(lblEstado).css("color","green");
                    break;
           }
    });
    return false;
}

function F_Fecha_Formato(Fecha,Tipo)
{
     var FechaFormato = new Date(Fecha);
     var Dia =  '';
     var Mes =  '';
     var Año =  '';
     var FechaFinal =  '';
     
     switch(Tipo) {
         case 'ISO':
               Dia =  Fecha.substring(0, 2);;
               Mes =  Fecha.substring(3, 5);;
               Año =  Fecha.substring(Fecha.length - 4, Fecha.length);
               FechaFinal = Año + Mes + Dia;
         break;
     }
     return FechaFinal;
}

function justNumbers(e) {
            var keynum = window.event ? window.event.keyCode : e.which;
            if ((keynum == 8 || keynum == 48))
                return true;
            if (keynum <= 47 || keynum >= 58) return false;
            return /\d/.test(String.fromCharCode(keynum));
}

 function onKeyDecimal(e, thix) {
            var keynum = window.event ? window.event.keyCode : e.which;
            if (document.getElementById(thix.id).value.indexOf('.') != -1 && keynum == 46)
                return false;
            if ((keynum == 8 || keynum == 48 || keynum == 46))
                return true;
            if (keynum <= 47 || keynum >= 58) return false;
            return /\d/.test(String.fromCharCode(keynum));
}

function Validacionguia(SerieGuia,NumeroGuia,FechaTraslado,Destino,Transportista,RUCTransportista,placa,Licencia,NuBultos,Peso,Conductor,DniConductor
,CodtipoTransportista,Direccion,CodConductor)
{
var cadenavalidacionguia  = 'Ingresar los sgtes. Datos DE LA GUIA:'; 

    if (RUCTransportista=='11111111' |RUCTransportista=='55555555555')
                        cadenavalidacionguia=cadenavalidacionguia + '<p></p>' + 'CLIENTE VARIOS NO PUEDE TENER GUIA REMISION';

                 if (NumeroGuia=='')
                        cadenavalidacionguia=cadenavalidacionguia + '<p></p>' + 'Numero de Guia';

                 if (FechaTraslado=='')
                        cadenavalidacionguia=cadenavalidacionguia + '<p></p>' + 'Fecha de Traslado';
        
                 if (Destino==null)
                        cadenavalidacionguia=cadenavalidacionguia + '<p></p>' + 'Llegada'; 
if ( (SerieGuia).substr(0, 1)=='T'){
 if (CodtipoTransportista == 2){
    if(placa==''){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'Placa'
    }
    if(Licencia==''){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'Licencia'
    }

         if (!(placa.length >= 6 && placa.length <= 7)) {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Placa Invalida';
            }

            if (!(Licencia.length >= 9 && Licencia.length <= 10)) {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Licencia Invalida';
            }

    if(Peso=='' || Peso==0){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'Peso'
    } 
    if(NuBultos=='' || NuBultos==0){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'NuM Bultos'
    } 
    if(Conductor==''){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'Conductor'
    }
    if(DniConductor==''){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'Dni Conductor'
    }
    if(CodConductor==0){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'Conductor'
    }
    }
    else if(CodtipoTransportista == 1)
    {
  
     if(RUCTransportista==''){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'RUC Transportista'
    } 
       if(Transportista==''){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'Razon social Transportista'
    }
     if(Direccion==null){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'Direccion Transportista'
    }
        if(Peso=='' || Peso==0){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'Peso'
    } 
     if(NuBultos=='' || NuBultos==0){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'NuM Bultos'
    } 
                                                                        
    }
    else 
    {
    if(placa==''){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'Placa'
    } 
        if(Peso=='' || Peso==0){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'Peso'
    } 
     if(NuBultos=='' || NuBultos==0){
    cadenavalidacionguia=cadenavalidacionguia+'<p></p>'+'NuM Bultos'
    } 
    }
    }
    if (cadenavalidacionguia  != 'Ingresar los sgtes. Datos DE LA GUIA:')
             {   
                  return  '<p></p>'  +cadenavalidacionguia;
             } else{
             cadenavalidacionguia='' 
             } 
 return cadenavalidacionguia;
}

function BloqueoTipoTransportista(SerieGuia,NumeroGuia,FechaTraslado,Destino,Transportista,RUCTransportista,placa,Licencia,NuBultos,Peso,Conductor,DniConductor
,CodtipoTransportista,Direccion,CodConductor,Marca,botondestino,botontransportista,chkguia,CodTransportista)
{

if ( (SerieGuia).substr(0, 1)=='T'){
 if (CodtipoTransportista == 2 && $(chkguia).is(':checked') ){
    $(RUCTransportista).prop("disabled", true);
    $(Transportista).prop("disabled", true);
    $(Direccion).prop("disabled", true);
    $(placa).prop("disabled", false);
    $(Licencia).prop("disabled", false);
    $(Conductor).prop("disabled", false);
    $(DniConductor).prop("disabled", false);
    $(Marca).prop("disabled", false); 
    $(botondestino).prop("disabled", false);  
    $(botontransportista).prop("disabled", false);  
     //
     $(RUCTransportista).val('');
    $(Transportista).val('');
    $(placa).val('');
    $(Licencia).val('');
    $(Conductor).val('');
    $(Marca).val('');
    $(DniConductor).val(''); 
     $(Direccion).empty();
    $(CodConductor).val(0); 
    $(CodTransportista).val(0); 
    }
    else if(CodtipoTransportista == 1 && $(chkguia).is(':checked'))
    {
    $(RUCTransportista).prop("disabled", false);
    $(Transportista).prop("disabled", false);
    $(Direccion).prop("disabled", false);
    $(placa).prop("disabled", false);
    $(Licencia).prop("disabled", false);
    $(Conductor).prop("disabled", true);
    $(DniConductor).prop("disabled", true);  
    $(Marca).prop("disabled", false); 
    $(botondestino).prop("disabled", false);  
    $(botontransportista).prop("disabled", false);   
    //
     $(RUCTransportista).val('');
    $(Transportista).val('');
    $(placa).val('');
    $(Marca).val('');
    $(Licencia).val('');
    $(Conductor).val('');
     $(Direccion).empty();
    $(DniConductor).val(''); 
    $(CodConductor).val(0);                                                         
    }
    else 
    {
    $(RUCTransportista).prop("disabled", true);
    $(Transportista).prop("disabled", true);
    $(Direccion).prop("disabled", true);
    $(placa).prop("disabled", false);
    $(Licencia).prop("disabled", true);
    $(Conductor).prop("disabled", true);
    $(DniConductor).prop("disabled", true);  
    $(Marca).prop("disabled", true);  
    $(botondestino).prop("disabled", true);  
    $(botontransportista).prop("disabled", true); 
     //
     $(RUCTransportista).val('');
    $(Transportista).val('');
    $(Marca).val('');
    $(placa).val('');
    $(Licencia).val('');
    $(Conductor).val('');
     $(Direccion).empty();
    $(DniConductor).val(''); 
    $(CodConductor).val(0); 
    }
    }    else 
    {
    $(RUCTransportista).prop("disabled", true);
    $(Transportista).prop("disabled", true);
    $(Direccion).prop("disabled", true);
    $(placa).prop("disabled", false);
    $(Licencia).prop("disabled", true);
    $(Conductor).prop("disabled", true);
    $(DniConductor).prop("disabled", true);  
    $(Marca).prop("disabled", true);  
    $(botondestino).prop("disabled", true);  
    $(botontransportista).prop("disabled", true); 
     //
     $(RUCTransportista).val('');
    $(Transportista).val('');
    $(Marca).val('');
    $(placa).val('');
    $(Licencia).val('');
    $(Conductor).val('');
     $(Direccion).empty();
    $(DniConductor).val(''); 
    $(CodConductor).val(0); 
    } 
  return false;
}

function F_GuardarDireccion(Ruc,CodDocumentoVenta,CodCtacte,Razonsocial,FlagTraslado,Ubigeo,Direccion,ddldireccion,ddldireccionDestino,Codtipodoc) {
     if ($(Razonsocial).val()==''){
         $(ddldireccion).empty();
                $(ddldireccionDestino).empty();
            return false
            }

            if(FlagTraslado!=1)
                FlagTraslado=0

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarTemporal',
         data: "{'NroRuc':'"+Ruc+"','CodDocumentoVenta':'" + $(CodDocumentoVenta).val() + "','CodCtacte':'" + CodCtacte 
        + "','Razonsocial':'" + $(Razonsocial).val().replace("'",'').replace("-",'')  
        + "','FlagTraslado':'" + FlagTraslado + "','Ubigeo':'"+ Ubigeo + "','Direccion':'"+ Direccion + "','Codtipodoc':'"+ Codtipodoc + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $(ddldireccion).empty();
                $(ddldireccionDestino).empty();
                $.each(data.rows, function (index, item) {
                    $(ddldireccion).append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                    $(ddldireccionDestino).append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                });

                $(CodDocumentoVenta).val(data.rows[0].Temporal);              
                
            }
            
            catch (x) { }
            MostrarEspera(false);
        },
        complete: function () {
           

        },
        error: function (response) {
         //   alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

function F_GuardarDireccion_Proforma(Ruc,CodDocumentoVenta,CodCtacte,Razonsocial,FlagTraslado,Ubigeo,Direccion,ddldireccion,ddldireccionDestino,Codtipodoc) {
     if ($(Razonsocial).val()==''){
         $(ddldireccion).empty();
                $(ddldireccionDestino).empty();
            return false
            }

            if(FlagTraslado!=1)
                FlagTraslado=0

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarTemporal_Proforma',
         data: "{'NroRuc':'"+Ruc+"','CodDocumentoVenta':'" + $(CodDocumentoVenta).val() + "','CodCtacte':'" + CodCtacte 
        + "','Razonsocial':'" + $(Razonsocial).val().replace("'",'').replace("-",'')  
        + "','FlagTraslado':'" + FlagTraslado + "','Ubigeo':'"+ Ubigeo + "','Direccion':'"+ Direccion + "','Codtipodoc':'"+ Codtipodoc + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $(ddldireccion).empty();
                $(ddldireccionDestino).empty();
                $.each(data.rows, function (index, item) {
                    $(ddldireccion).append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                    $(ddldireccionDestino).append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                });

                $(CodDocumentoVenta).val(data.rows[0].Temporal);              
                
            }
            
            catch (x) { }
            MostrarEspera(false);
        },
        complete: function () {
           

        },
        error: function (response) {
         //   alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

function F_ListaDireccionTemporal(CodDocumentoVenta,ddldireccion,ddldireccionDestino,FlagTraslado) {
       

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccionTemporal_Listar',
        data: "{'CodDocumentoVenta':'"+$(CodDocumentoVenta).val()+"','FlagTraslado':'" + FlagTraslado +"'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $(ddldireccion).empty();
                $(ddldireccionDestino).empty();
                $.each(data.rows, function (index, item) {
                    $(ddldireccion).append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                    $(ddldireccionDestino).append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                });


                $(CodDocumentoVenta).val(data.rows[0].Temporal);
  
            }
            
            catch (x) { alertify.log('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        complete: function () {
           

        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

function F_GrabarDireccion(CodDocumentoVenta,coddepartamento,codprovincia,coddistrito,direccion,correo1,correo2,codcliente,ddldireccion,hfCodDireccionTemporal,txtDistrito,
ddldireccionDestino,FlagTraslado,NroRuc,RazonSocial) {

    try {
        var Contenedor = '#MainContent_';
      
        var objParams = {
            Filtro_CodTemporal: $(CodDocumentoVenta).val(),
            Filtro_CodDepartamento: $(coddepartamento).val(),
            Filtro_CodProvincia: $(codprovincia).val(),
            Filtro_CodDistrito: $(coddistrito).val(),
            Filtro_Direccion: $(direccion).val(),
            Filtro_correo1: $(correo1).val(),
            Filtro_correo2: $(correo2).val(),
            Filtro_codCliente: $(codcliente).val(),
            Filtro_CodDireccionTemporal: $(hfCodDireccionTemporal).val(),
            Filtro_RazonSocial: $(RazonSocial).val(),
            Filtro_NroRuc: $(NroRuc).val(),
            Filtro_FlagTraslado: FlagTraslado
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDireccionTemporal_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Grabo Correctamente') {
                    F_Update_Division_HTML('div_DireccionTemporal', result.split('~')[2]);
                  
                    $(coddepartamento).val('0');
                    $(hfCodDireccionTemporal).val('0');
                    $(codprovincia).val('0');
                    $(coddistrito).val('0');
                    $(direccion).val('');
                    $(correo1).val('');
                    $(correo2).val('');
                    $(txtDistrito).val('');
                    $(CodDocumentoVenta).val(result.split('~')[5])
                    $('#div_DireccionMultiple').dialog('close');
                    F_ListaDireccionTemporal(CodDocumentoVenta,ddldireccion,ddldireccionDestino, result.split('~')[4]);
                    $(ddldireccion).val( result.split('~')[3]);
                       alertify.log('Se Grabo Correctamente.');
                }
                else
                    alertify.log(result.split('~')[1]);

            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_EliminarDireccion(CodDocumentoVenta,CodDocumentoVentaDireccion,ddldireccion,txtDistrito) {

    try {
      
        var objParams = {
        Filtro_CodTemporal: $(CodDocumentoVenta).val(),
            Filtro_CodDireccionTemporal: $(CodDocumentoVentaDireccion).val()
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarDireccionTemporal_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Elimino Correctamente') {
                    F_Update_Division_HTML('div_DireccionTemporal', result.split('~')[2]);
                    alertify.log('Se Elimino Correctamente.');
                    $(coddepartamento).val('0');
                    $(CodDocumentoVentaDireccion).val('0');
                    $(codprovincia).val('0');
                    $(coddistrito).val('0');
                    $(direccion).val('');
                    $(correo1).val('');
                    $(correo2).val('');
                    $(txtDistrito).val('');

                    F_ListaDireccionTemporal(CodDocumentoVenta,ddldireccion);
 
                }
                else
                    alertify.log(result.split('~')[1]);

            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function BuscarDireccionCotizacion(CodDocumentoVenta,CodDireccion,ddldireccion,ddldireccionDestino,Codtipodoc) {

    try {
        var Contenedor = '#MainContent_';
      
        var objParams = {
            Filtro_CodTemporal: $(CodDocumentoVenta).val(),
            Filtro_CodDireccion: CodDireccion,
            Filtro_Codtipodoc: Codtipodoc
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_BuscarDireccionCotizacion_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Grabo Correctamente') {
                 
                     $(ddldireccion).val( result.split('~')[3]);
                     $(ddldireccionDestino).val( result.split('~')[3]);
 
                }
                else
                    alertify.log(result.split('~')[1]);

            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function BloqueoGuiaInterna(TipoDocumento,TipoTransportista,Proveedor,MotivoTrabajo,botondestino,NroRucTransportista
,Tranpostista,direccionTransportista,botontransportista,nrobulto,peso,dniconducto,conductor,placa,licencia)
{

if ( (TipoDocumento)==4){
 
    $(TipoTransportista).prop("disabled", true);
    $(Proveedor).prop("disabled", true);
    $(MotivoTrabajo).prop("disabled", true);
    $(botondestino).prop("disabled", true);
    $(NroRucTransportista).prop("disabled", true);
    $(Tranpostista).prop("disabled", true);
    $(direccionTransportista).prop("disabled", true);
    $(botontransportista).prop("disabled", true); 
    $(nrobulto).prop("disabled", true);  
    $(peso).prop("disabled", true);  
    $(dniconducto).prop("disabled", true);  
    $(conductor).prop("disabled", true);  
    $(placa).prop("disabled", true);  
    $(licencia).prop("disabled", true);  
     //
    
    $(MotivoTrabajo).val('7');
    $(Tranpostista).val('');
    $(direccionTransportista).empty();
    $(nrobulto).val('');
    $(peso).val(''); 
    $(dniconducto).val(''); 
    $(conductor).val('');  
    $(placa).val('');
    $(licencia).val(''); 

    
    }
    else 
    {
     $(TipoTransportista).prop("disabled", false);
    $(Proveedor).prop("disabled", false);
    $(MotivoTrabajo).prop("disabled", false);
    $(botondestino).prop("disabled", false);
    $(NroRucTransportista).prop("disabled", false);
    $(Tranpostista).prop("disabled", false);
    $(direccionTransportista).prop("disabled", false);
    $(botontransportista).prop("disabled", false); 
    $(nrobulto).prop("disabled", false);  
    $(peso).prop("disabled", false);  
    $(dniconducto).prop("disabled", false);  
    $(conductor).prop("disabled", false);  
    $(placa).prop("disabled", false);  
    $(licencia).prop("disabled", false);  
     //
      

    }
     
  return false;
}

function F_BuscarDatosPorRucDniENTERONBLUR(RucDni,CodTipoCtaCte) {
var data;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCCUENTACORRIENTE_ENTER_ONBLUR',
        data:  "{'NroRuc':'"+RucDni+"','CodTipoCtaCte':'" + CodTipoCtaCte +"'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            data = dbObject.d;
            if (data.length > 0) {
                try {
                    return data;
                }
                catch (x) { alertify.log(x); }           
        }
        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });
return data;
}

function F_BuscarDatosPorRucDniENTERONBLUR_PROFORMA(RucDni,CodTipoCtaCte) {
var data;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCCUENTACORRIENTE_ENTER_ONBLUR_PROFORMA',
        data:  "{'NroRuc':'"+RucDni+"','CodTipoCtaCte':'" + CodTipoCtaCte +"'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            data = dbObject.d;
            if (data.length > 0) {
                try {
                    return data;
                }
                catch (x) { alertify.log(x); }           
        }
        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });
return data;
}

function F_APISUNAT (urlapisunat,NroRuc,tokenapisunat){
var data;

        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url:  urlapisunat + NroRuc + tokenapisunat,
            dataType: "json",
            async: true,
            success: function (dbObject) {
                MostrarEspera(true);
                data = dbObject.d;    
               return data;
            },
            error: function (response) {
                toastr.warning(response.responseText);
            },
            failure: function (response) {
                toastr.warning(response.responseText);
            }
        });

        return data;
}

// esta funcion se encarga de busca la url y el token del api para la busque en la parte de padronsunat
function F_API_RUC_Buscar_Global() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_API_RUC_Buscar',
        data: "{}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            $('#hfurlapisunat').val(data[0].split(',')[0]);
            $('#hftokenapisunat').val(data[0].split(',')[1]);            
            return true;
        },
        complete: function () {         
        },
        error: function (response) {
            toastr.warning(response.responseText);
        },
        failure: function (response) {
            toastr.warning(response.responseText);
        }
    });
    return false;
}

//#region autocomplete
//function F_AUTOCOMPLETENRORUC ()
//{
//   $('#MainContent_txtNroRuc').autocomplete(   
//    {
//        source: function (request, response) {
//            $.ajax({
//                type: "POST",
//                contentType: "application/json; charset=utf-8",
//                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
//                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + $('#hfCodTipoCliente').val() + "'}",
//                dataType: "json",
//                async: true,
//                success: function (data) {
//                  if (data.d.length > 0) {
//                  response($.map(data.d, function (item) {
//                        return {
//                            label: item.split(',')[1],
//                            val: item.split(',')[0],
//                            NroRuc: item.split(',')[8],
//                            ApePaterno: item.split(',')[9],
//                            ApeMaterno: item.split(',')[10],
//                            Nombres: item.split(',')[11],
//                            Cliente: item.split(',')[1],
//                            SaldoCreditoFavor: item.split(',')[12]
//                        }
//                    }))
//                  }else
//                  { 
//                  response(''//$.map(1,function () 
////                        return {''
//////                            label: '',
//////                            val: 0,
//////                            NroRuc: '',
//////                            ApePaterno: '',
//////                            ApeMaterno: '',
//////                            Nombres: '',
//////                            Cliente: '',
//////                            SaldoCreditoFavor:0
////                        }
//                    //)
//                    )
//                    return false;
//                  }
////                    
//                },
//                error: function (response) {
//                    alertify.log(response.responseText);
//                },
//                failure: function (response) {
//                    alertify.log(response.responseText);
//                }
//            });
//        },
//        select: function (e, i) {
//            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
//            $('#hfNroRuc').val(i.item.NroRuc);
//            $('#hfCodCtaCte').val(i.item.val);
//            $('#hfCliente').val(i.item.Nombres);
//            $('#MainContent_txtCliente').val(i.item.Nombres);
//            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
//            $('#hfFlagRuc').val("1");
//            $('#txtSaldoCreditoFavor').text(i.item.SaldoCreditoFavor);
//            $('#hfSaldoCreditoFavor').val(i.item.SaldoCreditoFavor.replace("S/", "").replace(" ", ""));

//            if ($('#hfNotaPedido').val() == '5' & $('#hfCodCtaCte').val() != $('#hfCodCtaCteNP').val())
//                F_EliminarTodos();

//            F_GuardarDireccion($('#MainContent_txtNroRuc').val(),'#hfCodigoTemporal',$('#hfCodCtaCte').val(),'#MainContent_txtCliente'
//            ,0,Ubigeo,Direccion,'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',1);         
//        },
//          close: function () {
//            $('#MainContent_txtNroRuc').val($('#hfNroRuc').val());
//            $('#MainContent_txtCliente').focus();
//        },
//        minLength: 3
//    });

//}

function F_AUTOCOMPLETENRORUC_PROFORMA ()
{
   $('#MainContent_txtNroRuc').autocomplete(   
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete_Proforma',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + $('#hfCodTipoCliente').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                  response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            NroRuc: item.split(',')[8],
                            ApePaterno: item.split(',')[9],
                            ApeMaterno: item.split(',')[10],
                            Nombres: item.split(',')[11],
                            Cliente: item.split(',')[1],
                            SaldoCreditoFavor: item.split(',')[12]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
            $('#hfNroRuc').val(i.item.NroRuc);
            $('#hfCodCtaCte').val(i.item.val);
            $('#hfCliente').val(i.item.Nombres);
            $('#MainContent_txtCliente').val(i.item.Nombres);
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
            $('#hfFlagRuc').val("1");
            $('#txtSaldoCreditoFavor').text(i.item.SaldoCreditoFavor);
            $('#hfSaldoCreditoFavor').val(i.item.SaldoCreditoFavor.replace("S/", "").replace(" ", ""));

            if ($('#hfNotaPedido').val() == '5' & $('#hfCodCtaCte').val() != $('#hfCodCtaCteNP').val())
                F_EliminarTodos();

            F_GuardarDireccion_Proforma($('#MainContent_txtNroRuc').val(),'#hfCodigoTemporal',$('#hfCodCtaCte').val(),'#MainContent_txtCliente'
            ,0,Ubigeo,Direccion,'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',1);         
        },
          close: function () {
            if ($('#hfCodCtaCte').val()>0)
            {
                $('#MainContent_txtNroRuc').val($('#hfNroRuc').val());
                $('#MainContent_txtCliente').focus();
            }
        },
        minLength: 3
    });

}

function F_AUTOCOMPLETECLIENTECONSULTA_PROFORMA()
{
  $('#MainContent_txtClienteConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete_Proforma',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + 0 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodCtaCteConsulta').val(i.item.val);
        },
        minLength: 3
    });

}

function F_AUTOCOMPLETEPLACA_1()
{
        $('#MainContent_txtPlaca1').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#MainContent_txtPlaca1').val(i.item.label);
        },
        minLength: 1
    });
}

function F_AUTOCOMPLETEPLACA_CONSULTA()
{
        $('#MainContent_txtPlacaConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + 0 + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#MainContent_txtPlacaConsulta').val(i.item.label);
        },
        minLength: 1
    });
}

function F_AUTOCOMPLETENRORUC ()
{
   $('#MainContent_txtNroRuc').autocomplete(   
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + $('#hfCodTipoCliente').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                  response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            NroRuc: item.split(',')[8],
                            ApePaterno: item.split(',')[9],
                            ApeMaterno: item.split(',')[10],
                            Nombres: item.split(',')[11],
                            Cliente: item.split(',')[1],
                            SaldoCreditoFavor: item.split(',')[12],
                            Placa: item.split(',')[19]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
            $('#hfNroRuc').val(i.item.NroRuc);
            $('#hfCodCtaCte').val(i.item.val);
            $('#hfCliente').val(i.item.Nombres);
            $('#MainContent_txtCliente').val(i.item.Nombres);
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
            $('#MainContent_txtPlaca1').val(i.item.Placa);
            $('#hfFlagRuc').val("1");
            $('#txtSaldoCreditoFavor').text(i.item.SaldoCreditoFavor);
            $('#hfSaldoCreditoFavor').val(i.item.SaldoCreditoFavor.replace("S/", "").replace(" ", ""));

            if ($('#hfNotaPedido').val() == '5' & $('#hfCodCtaCte').val() != $('#hfCodCtaCteNP').val())
                F_EliminarTodos();

            F_GuardarDireccion($('#MainContent_txtNroRuc').val(),'#hfCodigoTemporal',$('#hfCodCtaCte').val(),'#MainContent_txtCliente'
            ,0,Ubigeo,Direccion,'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',1);         
        },
          close: function () {
            if ($('#hfCodCtaCte').val()>0)
            {
                $('#MainContent_txtNroRuc').val($('#hfNroRuc').val());
                $('#MainContent_txtCliente').focus();
            }
        },
        minLength: 3
    });

}

function F_AUTOCOMPLETECLIENTECONSULTA()
{
  $('#MainContent_txtClienteConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + 0 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodCtaCteConsulta').val(i.item.val);
        },
        minLength: 3
    });

}

function F_AUTOCOMPLETETRANSPORTISTA()
{
 $('#MainContent_txtTransportista').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'2'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodTransportista').val(i.item.val);
        },
        minLength: 3
    });
}

function F_AUTOCOMPLETETRANSPORTISTAEDICION()
{
 $('#MainContent_txtTransportistaEdicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'2','CodTipoCliente':'2'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodTransportista').val(i.item.val);
        },
        minLength: 3
    });
}

function F_AUTOCOMPLETEPLACA()
{
$('#MainContent_txtPlaca').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#MainContent_txtPlaca').val(i.item.label);
        },
        minLength: 1
    });
}

function F_AUTOCOMPLETEPLACA2()
{
  $('#MainContent_txtPlaca2').autocomplete({

        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#MainContent_txtPlaca2').val(i.item.label);
        },
        minLength: 1
    });
}

function F_AUTOCOMPLETEPLACA3()
{
  $('#MainContent_txtPlaca3').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#MainContent_txtPlaca3').val(i.item.label);
        },
        minLength: 1
    });
}

function F_AUTOCOMPLETEPLACA4()
{
   $('#MainContent_txtPlaca4').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_DocumentoVentaCab_Placas_AutoComplete',
                data: "{'CodCtaCte':'" + $('#hfCodCtaCte').val() + "','Placa':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[0],
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#MainContent_txtPlaca4').val(i.item.label);
        },
        minLength: 1
    });

}

function F_AUTOCOMPLETECONDUCTORDNI()
{
 $('#MainContent_txtConductorDNI').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 2 + "','CodTipoCliente':'" + 4 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2],
                            Nombre: item.split(',')[11],
                            RUC: item.split(',')[8],
                            Placa: item.split(',')[19],
                            Licencia: item.split(',')[20]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodConductor').val(i.item.val);
            $('#hfDniConductor').val(i.item.RUC);
            $('#hfNombreConductor').val(i.item.Nombre);
            $('#MainContent_txtConductorDNI').val(i.item.RUC);
            $('#MainContent_txtConductorRazonSocial').val(i.item.Nombre);
            $('#MainContent_txtPlacaTraslado').val(i.item.Placa);
            $('#MainContent_txtLicenciaGuia').val(i.item.Licencia);
        }, 
        complete: function () {
            $('#MainContent_txtConductorDNI').val($('#hfDniConductor').val());
            $('#MainContent_txtConductorRazonSocial').focus();
        },
        minLength: 3
    });

}

function F_AUTOCOMPLETECONDUCTORDNIEDICION()
{
 $('#MainContent_txtConductorDNIEdicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 2 + "','CodTipoCliente':'" + 4 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2],
                            Nombre: item.split(',')[11],
                            RUC: item.split(',')[8],
                            Placa: item.split(',')[19],
                            Licencia: item.split(',')[20]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodConductor').val(i.item.val);
            $('#hfDniConductor').val(i.item.RUC);
            $('#hfNombreConductor').val(i.item.Nombre);
            $('#MainContent_txtConductorDNIEdicion').val(i.item.RUC);
            $('#MainContent_txtConductorRazonSocialEdicion').val(i.item.Nombre);
            $('#MainContent_txtPlacaTrasladoEdicion').val(i.item.Placa);
            $('#MainContent_txtLicenciaGuiaEdicion').val(i.item.Licencia);
        }, 
        complete: function () {
            $('#MainContent_txtConductorDNIEdicion').val($('#hfDniConductor').val());
            $('#MainContent_txtConductorRazonSocialEdicion').focus();
        },
        minLength: 3
    });
}

function F_AUTOCOMPLETENRORUCTRANSPORTISTA()
{
     $('#MainContent_txtNroRucTransportista').autocomplete(   
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'2','CodTipoCliente':'0'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            NroRuc: item.split(',')[8],
                            Nombres: item.split(',')[11],
                            Cliente: item.split(',')[1],
                            SaldoCreditoFavor: item.split(',')[12]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodTransportista').val(i.item.val);
            $('#MainContent_txtNroRucTransportista').val(i.item.NroRuc);
            $('#hfNroRucTransportista').val(i.item.NroRuc);
            $('#hfCodCtaCteTransportista').val(i.item.val);
            $('#hfTransportista').val(i.item.Nombres);
            $('#hfnombretransportista').val(i.item.Nombres);
            $('#MainContent_txtTransportista').val(i.item.Nombres);
            $('#MainContent_txtNroRucTransportista').val(i.item.NroRuc);
             F_GuardarDireccion($('#MainContent_txtNroRucTransportista').val(),'#hfCodigoTemporal',$('#hfCodCtaCteTransportista').val()
            ,'#MainContent_txtTransportista',1,Ubigeo,Direccion,'#MainContent_ddldireccionNuevaTransportista','',1);
        },
      close: function () {
            $('#MainContent_txtNroRucTransportista').val($('#hfNroRucTransportista').val());
            $('#MainContent_txtTransportista').val($('#hfnombretransportista').val());
        },
        minLength: 3
    });
}

function F_AUTOCOMPLETENRORUCTRANSPORTISTAEDICION()
{
 $('#MainContent_txtNroRucTransportistaEdicion').autocomplete(   
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'2','CodTipoCliente':'2'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            NroRuc: item.split(',')[8],
                            Nombres: item.split(',')[11],
                            Cliente: item.split(',')[1],
                            SaldoCreditoFavor: item.split(',')[12]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodTransportistaEdicion').val(i.item.val);
            $('#MainContent_txtNroRucTransportistaEdicion').val(i.item.NroRuc);
            $('#hfNroRucTransportistaEdicion').val(i.item.NroRuc);
            $('#hfCodCtaCteTransportistaEdicion').val(i.item.val);
            $('#hfTransportistaEdicion').val(i.item.Nombres);
            $('#MainContent_txtTransportistaEdicion').val(i.item.Nombres);
            $('#MainContent_txtNroRucTransportistaEdicion').val(i.item.NroRuc);
              F_GuardarDireccion($('#MainContent_txtNroRucTransportistaEdicion').val(),'#hfCodigoTemporalEdicion',$('#hfCodTransportistaEdicion').val()
            ,'#MainContent_txtTransportistaEdicion',1,Ubigeo,Direccion,'#MainContent_ddldireccionNuevaTransportistaEdicion','',1);
        },
        close: function () {
            $('#MainContent_txtNroRucTransportistaEdicion').val($('#hfNroRucTransportistaEdicion').val());
            $('#MainContent_txtTransportistaEdicion').focus();
        },
        minLength: 3
    });
}

function F_AUTOCOMPLETEDISTRITOMULTIPLE()
{
   $('#MainContent_txtDistritoMultiple').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCDistrito_Listar',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[3],
                            val: item.split(',')[0],
                            CodProvincia: item.split(',')[1],
                            CodDistrito: item.split(',')[2]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfDepartamento').val(i.item.val);
            $('#hfProvincia').val(i.item.CodProvincia);
            $('#hfDistrito').val(i.item.CodDistrito);
        },
        minLength: 3
    });
}

function F_AUTOCOMPLETENRORUC_POVIS()
{
   $('#MainContent_txtNroRuc').autocomplete(   
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + $('#hfCodTipoCliente').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            NroRuc: item.split(',')[8],
                            ApePaterno: item.split(',')[9],
                            ApeMaterno: item.split(',')[10],
                            Nombres: item.split(',')[11],
                            Cliente: item.split(',')[1],
                            SaldoCreditoFavor: item.split(',')[12],
                            CodVendedor: item.split(',')[15],
                            CodCategoria: item.split(',')[16],
                            NombreComercial: item.split(',')[17]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
            $('#hfNroRuc').val(i.item.NroRuc);
            $('#hfCodCtaCte').val(i.item.val);
            $('#hfCliente').val(i.item.Nombres);
            $('#MainContent_txtCliente').val(i.item.Nombres);
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
            $('#hfFlagRuc').val("1");
            $('#txtSaldoCreditoFavor').text(i.item.SaldoCreditoFavor);
            $('#hfSaldoCreditoFavor').val(i.item.SaldoCreditoFavor.replace("S/", "").replace(" ", ""));
            $('#MainContent_ddlVendedor').val(i.item.CodVendedor);
            $('#lblNombreComercial').text(i.item.NombreComercial);  

             if((i.item.CodCategoria)==1) 
             {
                   $('#lblTipoCliente').text('CALLE');
                   $('#lblTipoClienteDetalle').text('CALLE');
             }                
             else {
                   $('#lblTipoCliente').text('MINORISTA');        
                   $('#lblTipoClienteDetalle').text('MINORISTA');
             }                     

            if ($('#hfNotaPedido').val() == '5' & $('#hfCodCtaCte').val() != $('#hfCodCtaCteNP').val())
                F_EliminarTodos();

                if ($('#hfNotaPedido').val() != '0'  & ($('#MainContent_ddlTipoDoc').val() == '5' | $('#MainContent_ddlTipoDoc').val() == '15' | $('#MainContent_ddlTipoDoc').val() == '16'))
                F_EliminarTodos();

            F_GuardarDireccion($('#MainContent_txtNroRuc').val(),'#hfCodigoTemporal',$('#hfCodCtaCte').val(),'#MainContent_txtCliente'
            ,0,Ubigeo,Direccion,'#MainContent_ddldireccionNueva','#MainContent_ddldireccionNuevaDestino',1);         
        },
          close: function () {
          if ($('#hfCodCtaCte').val()>0)
            {
                $('#MainContent_txtNroRuc').val($('#hfNroRuc').val());
                $('#MainContent_txtCliente').focus();
            }
        },
        minLength: 3
    });

}

//#endregion autocomplete

function F_VisualizarImagen(CodProducto,CodigoInterno){
 var arrImg = new Array();
    $.ajax({
        async: true,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: "../Digitalizacion/FileDocDB.ashx?CodProducto=" + CodProducto + "&CodigoInterno="+CodigoInterno+"&Flag=1&tipo=1" + "&otro=" + Math.round(Math.random()) * 100,
        success: function (data) {
            MostrarEspera(true);
            try
            {
                var obj = $.parseJSON(data);
                $.each(obj, function (index, item) {
                    arrImg.push(item.img);
                });
                F_ArmarListaImagenes(arrImg);
            } catch (x) { toastr.warning('El Producto no tiene Imagenes');   $('#divVisualizarImagen').dialog('close'); }
            MostrarEspera(false);
        },
        error: function () {
            toastr.warning('Ha ocurrido un error interno, por favor intentelo nuevamente.');
        }
    });
}

function F_ArmarListaImagenes(arrImg) {
    var lu = $('#luImagenes'); lu.empty();
    
    //imagenes dinamicas por cuadricula
    var med_li = ""; var med_img = "";
    switch (arrImg.length) {
        case 1: med_li = "width:900px; height:450px"; med_img = "max-width:850px; max-height:450px;"; break;
        case 2: med_li = "width:450px; height:450px"; med_img = "max-width:450px; max-height:450px;"; break;
        case 3: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
        case 4: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
        case 5: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
        case 6: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
        case 7: med_li = "width:225px; height:200px"; med_img = "max-width:175px; max-height:200px;"; break;
        case 8: med_li = "width:225px; height:200px"; med_img = "max-width:175px; max-height:200px;"; break;
        case 9: med_li = "width:225px; height:135px"; med_img = "max-width:175px; max-height:135px;"; break;
        case 10: med_li = "width:225px; height:105px"; med_img = "max-width:175px; max-height:105px;"; break;
        case 11: med_li = "width:225px; height:105px"; med_img = "max-width:175px; max-height:105px;"; break;
        case 12: med_li = "width:225px; height:105px"; med_img = "max-width:175px; max-height:105px;"; break;
        default: med_li = "width:300px; height:200px"; med_img = "max-width:250px; max-height:200px;"; break;
    }

    $.each(arrImg, function (key, value) {

        var CodFoto = value.split("-")[1].replace('.jpg', '');

        var fmt = ' <li class="li-float" style="' + med_li + '"> <button id="btnEliminarImagen" style="position:absolute; border:none" onClick="F_EliminarImagenProducto(' + CodFoto + ');"><img src="../../Asset/images/EliminarBtn.png" /></button> <div> ' +
                    '     <a href=' + value + '  ' +
                    '         target="_blank" ' +
                    '         rel="nofollow"  ' +
                    '         style="background-image: url(' + value + ');"> ' +
                    '         <img src="' + value + '" class="li-img" style="' + med_img + ' margin: 0 auto" alt="Imagen 1"/> ' +
                    '      </a> ' +
                    '   </div>  ' +
                    ' </li> ';
        lu.append(fmt)
    });

    $("#divVisualizarImagen").dialog({
        resizable: false,
        modal: true,
        title: "Visualización del Artículo",
        title_html: true,
        width: 1100,
        height: 650,
        autoOpen: false
    });

    $('#divVisualizarImagen').dialog('open');
}

function F_ValidarFacturaVenta_General(NroRuc,Cliente,CodCliente,CodTipoDoc,TC,CodVendedor,Numero,Emision,NroOperacion,CodFormaPago,
         Total,Correo,CodDireccion,CodMoneda)
{
             var Cadena = 'Ingresar los sgtes. Datos:'; 

             if (CodTipoDoc==null)
                    Cadena=Cadena + '<p></p>' + 'Tipo Documento';

             if ($.trim(Cliente)  =='' && CodCliente==0)
                    Cadena=Cadena + '<p></p>' + 'Cliente';

             if (Cliente.indexOf('NUEVO CLIENTE') >= 0 | Cliente.indexOf('CLIENTE NUEVO') >= 0)
                Cadena=Cadena + '<p></p>' + 'Cliente No Valido';

             if ($.trim(Cliente) =='')
                    Cadena=Cadena + '<p></p>' + 'Cliente';
        
             if (parseFloat(TC) == 0)
                    Cadena=Cadena + '<p></p>' + 'Tipo de Cambio';

             if (CodVendedor==null)
                    Cadena=Cadena + '<p></p>' + 'Vendedor';

             if ($.trim(Emision)=='' )
                    Cadena=Cadena + '<p></p>' + 'Fecha de Emision';            
                    
             if ($.trim(NroOperacion)==''  & (CodFormaPago== 10 | CodFormaPago ==6 ))
                    Cadena=Cadena + '<p></p>' + 'NUMERO OPERACION';
         
             if (parseFloat(Total)==0)
                    Cadena=Cadena + '<p></p>' + 'No ha ingresado ningun producto';
                    
             if (!F_ValidarCorreo($.trim(Correo)))
                   Cadena = Cadena + '<p></p>' + 'Correo';

             if (CodDireccion == null )
                   Cadena = Cadena + '<p></p>' + 'DIRECCION';

             switch(parseInt(CodTipoDoc)) {
                case 1: //FACTURA
                    if (!ValidarRuc(NroRuc))
                            Cadena = Cadena + '<p></p>' + "Ruc Invalido"; 

                    if (NroRuc.length != 11 || NroRuc == '11111111')
                            Cadena=Cadena + '<p></p>' + 'LAS FACTURAS SOLAMENTE SE PUEDEN CREAR CON NRO RUC';
                    break;
                case 2: //BOLETA                
                     //if (!ValidarRuc(NroRuc))
                     //       Cadena = Cadena + "\n" + "Ruc Invalido"; 

                     if ($.trim(NroRuc).length != 8)
                         Cadena=Cadena + '<p></p>' + 'NUMERO DE DNI INVALIDO';

                    //valida el monto no superior a 700 Soles
                    if ($.trim(NroRuc) == '11111111')
                    {
                        var TotalSoles = Total;
                        if (CodMoneda == 2) TotalSoles = Total * TC;   
                        
                        if (TotalSoles > 700) 
                            Cadena=Cadena + '<p></p>' + 'El monto es Mayor a 700 Soles, debe ingresar un DNI'; //valida 
                    }
                    break;
            }

  return Cadena;
}
    
function F_Habilitar_Controles_Edicion_Guia(result)
{
                        $('#MainContent_txtEmisionEdicion').val(result.split('~')[2]);                 
                        $('#MainContent_ddlFormaPagoEdicion').val(result.split('~')[4]);
                        $('#MainContent_txtVencimientoEdicion').val(result.split('~')[3]);
                        $('#MainContent_txtPlaca1Editar').val(result.split('~')[5]);
                        $('#MainContent_txtPlaca2Edicion').val(result.split('~')[6]);
                        $('#MainContent_txtPlaca3Edicion').val(result.split('~')[7]);
                        $('#MainContent_txtPlaca4Edicion').val(result.split('~')[8]);
                        $('#hfCodTraslado').val(result.split('~')[9]);
                        if (result.split('~')[10] !='')
                          $("#MainContent_ddlSerieGuiaEdicion option:selected").text(result.split('~')[10]);
                        $('#MainContent_txtNumeroGuiaEdicion').val(result.split('~')[11]);
                  
                        if (result.split('~')[12] === "")
                            $('#MainContent_txtFechaTrasladoEdicion').val(result.split('~')[2]);

                        $('#MainContent_txtDestinoEdicion').val(result.split('~')[13]);
                        $('#MainContent_txtDireccionTransportistaEdicion').val(result.split('~')[14]);
                        $('#hfDireccionTransportista').val(result.split('~')[14]);
                        $('#hfCodTransportista').val(result.split('~')[15]);
                        $('#MainContent_txtTransportistaEdicion').val(result.split('~')[16]);
                        $('#hfDireccionFacturaEditar').val(result.split('~')[17]);
                        $('#hfCodDireccionTransportista').val(result.split('~')[18]);
                        $('#MainContent_txtKMEdicion').val(result.split('~')[19]);
                        $('#MainContent_txtNroOCEdicion').val(result.split('~')[20]);
                        $('#MainContent_txtRecepcion').val(result.split('~')[21]);
                        $('#hfCodCtaCteEdicion').val(result.split('~')[23]);              
                        $('#MainContent_txtDistritoTransportistaEdicion').val(result.split('~')[25]);
                        $('#MainContent_txtPlacaTrasladoEdicion').val(result.split('~')[26]);
                        $('#MainContent_txtMarcaGuiaEdicion').val(result.split('~')[27]);
                        $('#MainContent_txtLicenciaGuiaEdicion').val(result.split('~')[28]);
                        $('#MainContent_txtNuBultosEdicion').val(result.split('~')[29]);
                        $('#MainContent_txtPesoEdicion').val(result.split('~')[30]);
                        $('#MainContent_txtConductorDNIEdicion').val(result.split('~')[31]);
                        $('#MainContent_txtConductorRazonSocialEdicion').val(result.split('~')[32]);
                        $('#hfCodConductor').val(result.split('~')[33]);
                        $('#MainContent_ddlVendedorEdicion').val(result.split('~')[35]);
                        $('#MainContent_txtNombreAgencia').val(result.split('~')[36]);
                        $('#MainContent_txtGuiaAgencia').val(result.split('~')[37]);
                        $('#MainContent_txtClaveAgencia').val(result.split('~')[38]);
                        $('#MainContent_txtNroRucTransportistaEdicion').val(result.split('~')[42]);
                        $('#MainContent_txtObservacionGuiaEdicion').val(result.split('~')[43]);
                        $('#MainContent_ddlVendedorEdicion').val(result.split('~')[45]);
                        $('#MainContent_txtClaveAgencia').val(result.split('~')[38]);
                        $('#MainContent_txtObservacionFacturaEdicion').val(result.split('~')[44]);
                        
                        if (result.split('~')[22] == "1")
                            $('#MainContent_chkComisionableEdicion').prop('checked',true);
                        else
                            $('#MainContent_chkComisionableEdicion').prop('checked',false);

                        if (result.split('~')[24] == "1")
                            $('#MainContent_chkMotorizadoEdicion').prop('checked',true);
                        else
                            $('#MainContent_chkMotorizadoEdicion').prop('checked',false);

                        $('#MainContent_txtNroOperacionEdicion').val('');
                    
                        if (Number($('#hfCodTraslado').val()) == 0)
                        {
                         $('#MainContent_chkGuiaEdicion').prop('checked', false);
                          var date = new Date();  
                          $('#MainContent_txtFechaTrasladoEdicion').val(date.format("dd/MM/yyyy"));
                        }                           
                        else
                        {
                         $('#MainContent_chkGuiaEdicion').prop('checked', true);
                         $('#MainContent_txtFechaTrasladoEdicion').val(result.split('~')[12]);
                        }
                           

                        if (result.split('~')[40] == "1")
                            $('#MainContent_chkConCodigoEdicion').prop('checked',true);
                        else
                            $('#MainContent_chkConCodigoEdicion').prop('checked',false);

                        $('#hfCodCtaCteEdicion').val(result.split('~')[23]);     
                        $('#hfCodTransportistaEdicion').val(result.split('~')[15]);   
                        $('#hfCodigoTemporalEdicion').val(0); 
                        CodDirecionDestinoEdicion= result.split('~')[41];
                        CodDirecionTransportistaEdicion = result.split('~')[18];
                        
                         if ($('#MainContent_ddlSerieGuiaEdicion option:selected').text().substring(0,1)=="T" && $('#hfCodTraslado').val() != 0){
                         $("#MainContent_ddlSerieGuiaEdicion option:selected").text(result.split('~')[10]);
                         $('#MainContent_chkGuiaEdicion').prop('checked', true);
                         $('#MainContent_chkGuiaEdicion').prop('disabled',true);
                         $('#MainContent_ddlSerieGuiaEdicion').prop('disabled',true);
                         $('#MainContent_txtNumeroGuiaEdicion').prop('disabled',true);
                         $('#MainContent_txtFechaTrasladoEdicion').prop('disabled',true);      
                         $('#MainContent_txtNroRucTransportistaEdicion').prop('disabled',true);
                         $('#MainContent_txtTransportistaEdicion').prop('disabled',true);              
                         $('#MainContent_txtPlacaTrasladoEdicion').prop('disabled',true);
                         $('#MainContent_txtMarcaGuiaEdicion').prop('disabled',true);
                         $('#MainContent_txtLicenciaGuiaEdicion').prop('disabled',true);
                         $('#MainContent_txtNuBultosEdicion').prop('disabled',true);
                         $('#MainContent_txtPesoEdicion').prop('disabled',true);
                         $('#MainContent_txtConductorDNIEdicion').prop('disabled',true);
                         $('#MainContent_txtConductorRazonSocialEdicion').prop('disabled',true);   
                         $('#MainContent_ddlTipoTransportistaEdicion').prop('disabled',true); 
                         $('#MainContent_ddlcodunidadpesoedicion').prop('disabled',true);   
                         $('#MainContent_ddldireccionNuevaDestinoEdicion').prop('disabled',true);  
                         $('#MainContent_ddldireccionNuevaTransportistaEdicion').prop('disabled',true); 
                         $('#MainContent_ImageButton3').prop("disabled", true);  
                         $('#MainContent_ImageButton4').prop("disabled", true);              
                        }else
                        {
                         $('#MainContent_ddlSerieGuiaEdicion').prop('disabled',false);
                         $('#MainContent_chkGuiaEdicion').prop('checked', false);
                         $('#MainContent_chkGuiaEdicion').prop('disabled',false);
                         $('#MainContent_txtNumeroGuiaEdicion').prop('disabled',false);
                         $('#MainContent_txtFechaTrasladoEdicion').prop('disabled',false);          
                         $('#MainContent_txtTransportistaEdicion').prop('disabled',false);                
                         $('#MainContent_txtPlacaTrasladoEdicion').prop('disabled',false);
                         $('#MainContent_txtMarcaGuiaEdicion').prop('disabled',false);
                         $('#MainContent_txtLicenciaGuiaEdicion').prop('disabled',false);
                         $('#MainContent_txtNuBultosEdicion').prop('disabled',false);
                         $('#MainContent_txtPesoEdicion').prop('disabled',false);
                         $('#MainContent_txtConductorDNIEdicion').prop('disabled',false);
                         $('#MainContent_txtConductorRazonSocialEdicion').prop('disabled',false);
                         $('#MainContent_ddlTipoTransportistaEdicion').prop('disabled',false);
                         $('#MainContent_ddlcodunidadpesoedicion').prop('disabled',false); 
                        }

                        $('#MainContent_txtObservacionEdicion').val(result.split('~')[44]);
                        return false;
}

//function F_WhatsAppHabilitado(codDocumentoVenta) {
//    var resultado = "0";

//    $.ajax({
//        type: "POST",
//        url: "../Servicios/Servicios.asmx/F_WhatsAppHabilitado",
//        data: JSON.stringify({ codDocumentoVenta: codDocumentoVenta }),
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        async: false,
//        success: function (response) {
//            resultado = response.d;
//        },
//        error: function (xhr, status, error) {
//            console.error("Error al verificar WhatsApp:", error);
//        }
//    });

//    return resultado;
//}

function F_WhatsAppHabilitado() {
    var resultado = "0";

    $.ajax({
        type: "POST",
        url: "../Servicios/Servicios.asmx/F_WhatsAppHabilitado",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            resultado = response.d;
        }
    });

    return resultado;
}



function F_Establecer_Fecha_103() {
    $('.Jq-ui-dtp').each(function () {
        
        if ($(this).hasClass('hasDatepicker')) {
            $(this).datepicker('destroy');
        }

      
        $(this).datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'dd/mm/yy',
            regional: 'es'
        });

       
        if ($(this).val().trim() === '') {
            $(this).datepicker('setDate', new Date());
        }
    });

    return false;
}

function F_EnviarWhatsApp_Por_Codigo(Codigo) {
    $.ajax({
        type: "POST",
        url: "../Servicios/Servicios.asmx/EnviarFacturaWhatsAppDesdeGrilla",
        data: "{'codDocumentoVenta':'" + Codigo + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alertify.success("Factura enviada por WhatsApp");
        },
        error: function (xhr, status, error) {
            
            try {
                var json = JSON.parse(xhr.responseText);
                if (json && json.Message) {
                    alertify.error(json.Message);
                } else {
                    alertify.error("Error al enviar WhatsApp.");
                }
            } catch (e) {
               
                if (xhr.responseText.includes("CELULAR")) {
                    alertify.error("EL CLIENTE NO TIENE NÚMERO DE CELULAR REGISTRADO");
                } else {
                    alertify.error("Error al enviar WhatsApp.");
                }
            }
        }
    });
}

function F_Grilla_Estado_Color(NombreGrilla,LabelNumero,LabelEstado,Detalle) { 
        var Control = '#MainContent_' + NombreGrilla + Detalle;
        
        $(Control).each(function () {
        var Fila= '#' + this.id;                         
        var lblEstado=Fila.replace(LabelNumero,LabelEstado);    
                  
        switch($(lblEstado).text().toUpperCase()) {
            case "PENDIENTE":
                  $(lblEstado).css("color","red"); 
              break;
            case "CANCELADO":
                  $(lblEstado).css("color","green"); 
              break;
            case "FACTURADO":
                  $(lblEstado).css("color","blue"); 
              break;
            default:
                  $(lblEstado).css("color","black"); 
            }
        });      

        return false;
}


function F_Grilla_Stock_Color(NombreGrilla,lblProducto,lblStock,Detalle) { 
        var Control = '#MainContent_' + NombreGrilla + Detalle;
        
        $(Control).each(function () {
        var Fila= '#' + this.id;                         
        var lblStock=Fila.replace(lblProducto,lblStock);    
                  
        if (parseFloat($(lblStock).text()) <= 0)
           $(lblStock).css("color","red"); 
        else
           $(lblStock).css("color","black"); 
        })

        return false;
}

 function F_MostrarTotalesConExonerado() {
    var lblimporte = '';
    var hfCategoriaIgv = '';
    var chkDel = '';
    var TotalAfecto = 0;
    var Subtotal = 0;
    var Igv = 0;
    var Exonerado = 0;
    var Cuerpo = '#MainContent_';
    var tasa = parseFloat($("#MainContent_ddlIgv option:selected").text());

    
    $('#MainContent_grvDetalleArticulo .chkDelete :checkbox').each(function () {
        chkDel = '#' + this.id;
        
        lblimporte = chkDel.replace('chkEliminar', 'lblimporte');
        hfCategoriaIgv = chkDel.replace('chkEliminar', 'hfCodCategoriaIgvGR');

        var importe = parseFloat($(lblimporte).text());
        var categoria = $(hfCategoriaIgv).val();

        if (isNaN(importe)) importe = 0;

      
        if (categoria == "3") {
            Exonerado += importe;
        } else {
           TotalAfecto += importe;
        }
    });

    if (isNaN(TotalAfecto)) TotalAfecto = 0;
    if (isNaN(Exonerado)) Exonerado = 0;


    if ($('#MainContent_chkConIgvMaestro').is(':checked')) {
        Subtotal = TotalAfecto / (1 + tasa);
        Igv = TotalAfecto - Subtotal;
    } else {
        Subtotal = TotalAfecto;
        Igv = 0;
    }

    
    var TotalGeneral = Subtotal + Igv + Exonerado;

    $(Cuerpo + 'txtSubTotal').val(Subtotal.toFixed(2));
    $(Cuerpo + 'txtIgv').val(Igv.toFixed(2));
    $(Cuerpo + 'txtExonerada').val(Exonerado.toFixed(2));
    $(Cuerpo + 'txtTotal').val(TotalGeneral.toFixed(2));

      if ($('#MainContent_ddlFormaPago').val() == "1" | $('#MainContent_ddlFormaPago').val() == "5" | $('#MainContent_ddlFormaPago').val() == "6" | $('#MainContent_ddlFormaPago').val() == "10" |  $('#MainContent_ddlFormaPago').val() == "15")
         $('#MainContent_txtAcuenta').val(parseFloat($('#MainContent_txtTotal').val()) - parseFloat($('#MainContent_txtAcuentaNV').val()).toFixed(2));

    if ($(Cuerpo + 'ddlFormaPago').val()==10)
        $(Cuerpo + 'txtComisionTarjeta').val(parseFloat($(Cuerpo + 'txtTotal').val() * (1 + ComisionTarjeta/100)).toFixed(2));
    else
        $(Cuerpo + 'txtComisionTarjeta').val('0.00');
}
