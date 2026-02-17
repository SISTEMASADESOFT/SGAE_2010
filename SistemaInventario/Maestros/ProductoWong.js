var AppSession = "../Maestros/ProductoWong.aspx";

var CodigoMenu = 1000;
var CodigoInterno = 7;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }
    $('#divTabs').tabs();
    
    $('#MainContent_txtProveedor').autocomplete({
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
                            val: item.split(',')[0]                           
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
            $('#hfCodCtaCte').val(i.item.val);         
        },
        minLength: 3
});
    
    $('#MainContent_txtProveedorEdicion').autocomplete({
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
                            val: item.split(',')[0]                           
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
            $('#hfCodCtaCteEdicion').val(i.item.val);         
        },
        minLength: 3
});
    
    $('#MainContent_txtTipoProducto').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_LGFamiliasTipoProducto_AUTOCOMPLETE',
                data: "{'TipoProducto':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {                            
                            val: item.split(',')[0], 
                            label: item.split(',')[1],                         
                            TipoProducto: item.split(',')[2],
                            Codigo: item.split(',')[3]
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
            $('#hfCodTipoProducto').val(i.item.val);         
            $('#hfTipoProducto').val(i.item.TipoProducto); 
            $('#hfCodigo').val(i.item.Codigo); 
            $('#MainContent_txtCodigoInterno').val(i.item.Codigo); 
            $('#MainContent_txtCodigoBarra').val(i.item.Codigo); 
            F_ConcatenarDescripcionSistemaFactura();
        },
        minLength: 3
});
    
    $('#MainContent_txtTipoProductoEdicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_LGFamiliasTipoProducto_AUTOCOMPLETE',
                data: "{'TipoProducto':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {                            
                            val: item.split(',')[0], 
                            label: item.split(',')[1],                         
                            TipoProducto: item.split(',')[2],
                            Codigo: item.split(',')[3]
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
            $('#hfCodTipoProductoEdicion').val(i.item.val);         
            $('#hfTipoProductoEdicion').val(i.item.TipoProducto); 
            $('#hfCodigoEdicion').val(i.item.Codigo); 
            $('#MainContent_txtCodigoInternoEdicion').val(i.item.Codigo); 
            $('#MainContent_txtCodigoBarraEdicion').val(i.item.Codigo); 
            F_ConcatenarDescripcionSistemaFacturaEdicion();
        },
        minLength: 3
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
    
    $('#MainContent_ddlTipoProducto, #MainContent_ddlMarca1, #MainContent_txtTipoMotor1,#MainContent_ddlMarcaFab,#MainContent_txtDescripcionModelo').blur(function () {
     F_ConcatenarDescripcionSistemaFactura();
    return false;
  });

    $('#MainContent_ddlTipoProductoEdicion, #MainContent_ddlMarca1Edicion, #MainContent_txtTipoMotor1Edicion,#MainContent_ddlMarcaFabEdicion,#MainContent_txtDescripcionModeloEdicion').blur(function () {
     F_ConcatenarDescripcionSistemaFacturaEdicion();
    return false;
  });
    
    $("#MainContent_txtM1").blur(function () {
    F_ValidaMonto("MainContent_txtM1");
    return true;
});

    $("#MainContent_txtM2").blur(function () {
    F_ValidaMonto("MainContent_txtM2");
    return true;
});

    $("#MainContent_txtM1").keydown(function (e) {
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        (e.keyCode == 65 && e.ctrlKey === true) ||
        (e.keyCode >= 35 && e.keyCode <= 39)) {
        return;
    }
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
        e.preventDefault();
});

    $("#MainContent_txtM2").keydown(function (e) {
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        (e.keyCode == 65 && e.ctrlKey === true) ||
        (e.keyCode >= 35 && e.keyCode <= 39)) {
        return;
    }
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
        e.preventDefault();
});

    $('#MainContent_btnGrabarProducto').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarGrabarProductoWong())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR EL PRODUCTO"))
                F_GrabarDocumento();

            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnLimpiar').click(function () {        
        try {
            F_Nuevo()
            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnGrabarDetalle').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
       

            if (confirm("ESTA SEGURO DE GRABAR EL DETALLE"))
                F_GrabarDetalle();

            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });
    
    $('#MainContent_btnEditarDetalle').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
       

            if (confirm("ESTA SEGURO DE EDITAR EL DETALLE"))
                F_EditarDetalle();

            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnEdicion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
       // if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarEditarProductoWong())
                return false;

            if (confirm("ESTA SEGURO DE EDITAR EL PRODUCTO"))
                F_EdicionRegistro();

            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });
    
    F_Css_Cajatextos();  
    
    F_Controles_Inicializar();  
  });

$(document).on("change", "select[id $= 'MainContent_ddlFamilia']",function () {
      var Cuerpo = '#MainContent_';
    
       $(Cuerpo + 'txtCodigoInterno').val('');
       $(Cuerpo + 'txtCodigoBarra').val('');

      F_ListarComboCategoriar($(Cuerpo + 'ddlFamilia').val());     
      
} );

$(document).on("change", "select[id $= 'MainContent_ddlFamiliaEdicion']",function () {
      var Cuerpo = '#MainContent_';
    
      $(Cuerpo + 'txtCodigoInternoEdicion').val('');
      $(Cuerpo + 'txtCodigoBarraEdicion').val('');

      F_ListarComboCategoriar_Edicion();    
} );

$(document).on("change", "select[id $= 'MainContent_ddlCategoria']",function () {
//      var Cuerpo = '#MainContent_';
//      var  CodCategoria=$('#MainContent_ddlCategoria').val().split('-')[0];
      F_ListarComboTipoProducto();
  
      
} );

$(document).on("change", "select[id $= 'MainContent_ddlTipoProducto']",function () {
F_ConcatenarDescripcionSistemaFactura();

    return false;
      
} );

$(document).on("change", "select[id $= 'MainContent_ddlMarcaFab']",function () {
F_ConcatenarDescripcionSistemaFactura();

    return false;
      
} );

$(document).on("change", "select[id $= 'MainContent_ddlTipoProductoEdicion']",function () {
F_ConcatenarDescripcionSistemaFacturaEdicion();
    return false;      
} );

$(document).on("change", "select[id $= 'MainContent_ddlMarcaFabEdicion']",function () {
F_ConcatenarDescripcionSistemaFacturaEdicion();
    return false;      
} );

$(document).on("change", "select[id $= 'MainContent_ddlMarcaAplicaciones']",function () {
F_ListarComboModelo($('#MainContent_ddlMarcaAplicaciones').val());
    return false;      
} );

$(document).on("change", "select[id $= 'MainContent_ddlModeloAplicaciones']",function () {
F_ListarComboMotor($('#MainContent_ddlModeloAplicaciones').val());
    return false;      
} );

$(document).on("change", "select[id $= 'MainContent_ddlMarcaAplicacionesEdicion']",function () {
F_ListarComboModeloEdicion($('#MainContent_ddlMarcaAplicacionesEdicion').val());
    return false;      
} );

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

                        F_Update_Division_HTML('div_UndVenta', result.split('~')[2]);
                        F_Update_Division_HTML('div_NombreMed', result.split('~')[3]);
                        F_Update_Division_HTML('div_Tipo', result.split('~')[4]);
                        F_Update_Division_HTML('div_MarcaFab', result.split('~')[5]);
                        F_Update_Division_HTML('div_PaisOrigen', result.split('~')[6]);
                        F_Update_Division_HTML('div_Familia', result.split('~')[7]);
                        F_Update_Division_HTML('div_Categoria', result.split('~')[8]);
                        F_Update_Division_HTML('div_TipoProducto', result.split('~')[9]);
                        F_Update_Division_HTML('div_Marca1', result.split('~')[10]);
                        F_Update_Division_HTML('div_Marca2', result.split('~')[11]);
                        F_Update_Division_HTML('div_Marca3', result.split('~')[12]);
                        //Edicion combo
                        F_Update_Division_HTML('div_UndVentaEdicion', result.split('~')[13]);
                        F_Update_Division_HTML('div_NombreMedEdicion', result.split('~')[14]);
                        F_Update_Division_HTML('div_TipoEdicion', result.split('~')[15]);
                        F_Update_Division_HTML('div_MarcaFabEdicion', result.split('~')[16]);
                        F_Update_Division_HTML('div_PaisOrigenEdicion', result.split('~')[17]);
                        F_Update_Division_HTML('div_FamiliaEdicion', result.split('~')[18]);
                        F_Update_Division_HTML('div_CategoriaEdicion', result.split('~')[19]);
                        F_Update_Division_HTML('div_TipoProductoEdicion', result.split('~')[20]);
                        F_Update_Division_HTML('div_Marca1Edicion', result.split('~')[21]);
                        F_Update_Division_HTML('div_Marca2Edicion', result.split('~')[22]);
                        F_Update_Division_HTML('div_Marca3Edicion', result.split('~')[23]);
                        F_Update_Division_HTML('div_MarcaAplicaciones', result.split('~')[24]);
                        F_Update_Division_HTML('div_MarcaAplicacionesEdicion', result.split('~')[25]);           
                        $('#MainContent_ddlTipo').css('background', '#FFFFE0');
                        $('#MainContent_ddlUndVenta').css('background', '#FFFFE0');
                        $('#MainContent_ddlNombreMed').css('background', '#FFFFE0');
                        $('#MainContent_ddlMarcaFab').css('background', '#FFFFE0');
                        $('#MainContent_ddlPaisOrigen').css('background', '#FFFFE0');
                        $('#MainContent_ddlFamilia').css('background', '#FFFFE0');
                        $('#MainContent_ddlCategoria').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoProducto').css('background', '#FFFFE0');
                        $('#MainContent_ddlMarca1').css('background', '#FFFFE0');
                        $('#MainContent_ddlMarca2').css('background', '#FFFFE0');
                        $('#MainContent_ddlMarca3').css('background', '#FFFFE0');
                        $('#MainContent_ddlMarca1').val(0);
                        $('#MainContent_ddlMarca2').val(0);
                        $('#MainContent_ddlMarca3').val(0);
                        $('#MainContent_ddlMarcaFab').val(0);
                        $('#MainContent_ddlPaisOrigen').val(0);
                        $('#MainContent_ddlUndVenta').val(22);
                        //Edicion
                        $('#MainContent_ddlTipoEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlUndVentaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlNombreMedEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlMarcaFabEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlPaisOrigenEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlFamiliaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlCategoriaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoProductoEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlMarca1Edicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlMarca2Edicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlMarca3Edicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlMarcaAplicaciones').css('background', '#FFFFE0');
                        $('#MainContent_ddlMarcaAplicacionesEdicion').css('background', '#FFFFE0');  
                        return false;               
                    }
                    else {
                        toastr.warning(str_mensaje_operacion);
                        return false;
                    }
                }
            );
    } catch (mierror) {
        MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);
        return false;
    }
}

function F_ListarComboCategoriar_Edicion(CodCategoria,CodTipoProducto) {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;
 
    try {
        var objParams = {
            Filtro_IDFamilia: $('#MainContent_ddlFamiliaEdicion').val()            
        };
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarComboCategoriar_Edicion_NET
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
                     F_Update_Division_HTML('div_CategoriaEdicion', result.split('~')[2]);                    
                     $('#MainContent_ddlCategoriaEdicion').css('background', '#FFFFE0');    
                     $('#MainContent_ddlCategoriaEdicion').val(CodCategoria);                       
                     F_ListarComboTipoProducto_Edicion(CodTipoProducto); 
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
                     F_Update_Division_HTML('div_Categoria', result.split('~')[2]);                    
                     $('#MainContent_ddlCategoria').css('background', '#FFFFE0');    
                     
                      if ($('#MainContent_ddlCategoria').length)
                          $('#MainContent_ddlTipoProducto').empty();                      
                       
                     F_ListarComboTipoProducto(); 
                     var CodCategoria =$('#MainContent_ddlCategoria').val().split('-')[1];
                     $('#MainContent_txtCodigoInterno').val(CodCategoria);
                     $('#MainContent_txtCodigoBarra').val(CodCategoria);                     
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

function F_ListarComboTipoProducto() {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;

    var CodCategoria =$('#MainContent_ddlCategoria').val().split('-')[0];
    var Codigo =$('#MainContent_ddlCategoria').val().split('-')[1]; 
    
    $('#MainContent_txtCodigoInterno').val(Codigo); 
    $('#MainContent_txtCodigoBarra').val(Codigo); 
    try {
        var objParams = {
            Filtro_CodCategoria: CodCategoria            
        };
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarComboTipoProducto_NET
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
                     F_Update_Division_HTML('div_TipoProducto', result.split('~')[2]);                     
                     $('#MainContent_ddlTipoProducto').css('background', '#FFFFE0');                       
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

function F_ListarComboTipoProducto_Edicion(CodTipoProducto) {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;

    var CodCategoria =$('#MainContent_ddlCategoriaEdicion').val().split('-')[0];

    try {
        var objParams = {
            Filtro_CodCategoria: CodCategoria            
        };
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarComboTipoProducto_Edicion_NET
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
                        F_Update_Division_HTML('div_TipoProductoEdicion', result.split('~')[2]);                     
                        $('#MainContent_ddlTipoProductoEdicion').css('background', '#FFFFE0');                       
                        $('#MainContent_ddlTipoProductoEdicion').val(CodTipoProducto);   
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
///////////////////// 
function F_Buscar() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    if ($("#MainContent_txtDescripcionConsulta").val().length<3)
    {
        toastr.warning("MINIMO 3 CARACTERES PARA REALIZAR LA BUSQUEDA");
        return false;
    }
    try {
        var objParams = {
            Filtro_Descripcion:$("#MainContent_txtDescripcionConsulta").val(),
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

function F_GrabarDocumento() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; 
    try {

       var Contenedor = '#MainContent_';
        var FlagControlStock = 0;
       var Codcategoria =$('#MainContent_ddlCategoria').val().split('-')[0]; 

         if ($('#MainContent_chkControlStock').is(':checked'))
            FlagControlStock = 1;
        

        var objParams = {
            Filtro_CodCategoria:Codcategoria,
            Filtro_CodigoInterno: $(Contenedor + 'txtCodigoInterno').val(),
            Filtro_RefOEM: $(Contenedor + 'txtRefOEM').val(),
            Filtro_CodigoBarra: $(Contenedor + 'txtCodigoBarra').val(),
            Filtro_CodigoProveedor: $(Contenedor + 'txtCodigoProveedor').val(),
            Filtro_Proveedor: $('#hfCodCtaCte').val(),
            Filtro_CodigoFabricante: $(Contenedor + 'txtCodigoFabricante').val(),
            Filtro_Equivalente: $(Contenedor + 'txtEquivalente').val(),          
            Filtro_TipoProducto: $('#hfCodTipoProducto').val(),            
            Filtro_DescripcionModelo: $(Contenedor + 'txtDescripcionModelo').val(),
            Filtro_DscProducto: $(Contenedor + 'txtNombreFact').val(),
            Filtro_DescSistema: $(Contenedor + 'txtDescSistema').val(),
            Filtro_MarcaFab: $(Contenedor + 'ddlMarcaFab').val(),
            Filtro_PaisOrigen: $(Contenedor + 'ddlPaisOrigen').val(),
            Filtro_UndVenta: $(Contenedor + 'ddlUndVenta').val(),
            Filtro_PesoTotal: $(Contenedor + 'txtPesoTotal').val(),
            Filtro_M1: $(Contenedor + 'txtM1').val(),
            Filtro_M2: $(Contenedor + 'txtM2').val(),
            Filtro_ControlStock: FlagControlStock,
            //////PRODUCTOS OPCIONALES  
            Filtro_NombreMed: $(Contenedor + 'ddlNombreMed').val(),
            Filtro_Medida1: $(Contenedor + 'txtMedida1').val(),
            Filtro_Medida2: $(Contenedor + 'txtMedida2').val(),
            Filtro_Tipo: $(Contenedor + 'ddlTipo').val(),
            Filtro_Almacen: $(Contenedor + 'txtAlmacen').val(),
            Filtro_Rack: $(Contenedor + 'txtRack').val(),
            Filtro_Nivel: $(Contenedor + 'txtNivel').val(),
            Filtro_Zona: $(Contenedor + 'txtZona').val(),
            Filtro_Caja: $(Contenedor + 'txtCaja').val(),
            Filtro_Mostrador: $(Contenedor + 'txtMostrador').val(),
            Filtro_Marca1: $(Contenedor + 'ddlMarca1').val(),
            Filtro_Marca2: $(Contenedor + 'ddlMarca2').val(),
            Filtro_Marca3: $(Contenedor + 'ddlMarca3').val(),
            Filtro_Modelo1: $(Contenedor + 'txtModelo1').val(),
            Filtro_Modelo2: $(Contenedor + 'txtModelo2').val(),
            Filtro_Modelo3: $(Contenedor + 'txtModelo3').val(),
            Filtro_TipoMotor1: $(Contenedor + 'txtTipoMotor1').val(),
            Filtro_TipoMotor2: $(Contenedor + 'txtTipoMotor2').val(),
            Filtro_TipoMotor3: $(Contenedor + 'txtTipoMotor3').val(),
            Filtro_AñoIT1: $(Contenedor + 'txtAñoIT1').val(),
            Filtro_AñoIT2: $(Contenedor + 'txtAñoIT2').val(),  
            Filtro_AñoIT3: $(Contenedor + 'txtAñoIT3').val(),    
            
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
                     var Cuerpo = '#MainContent_';
                    F_ListarComboCategoriar($(Cuerpo + 'ddlFamilia').val()); 

                   
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

function F_EdicionRegistro() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; 
    try {
       var Contenedor = '#MainContent_';
       var FlagControlStock = 0;
  
       if ($('#MainContent_chkControlStockEdicion').is(':checked'))
            FlagControlStock = 1;
        
        var objParams = {
            Filtro_CodProducto:$('#hfCodProducto').val(),
            Filtro_CodigoInterno: $(Contenedor + 'txtCodigoInternoEdicion').val(),
            Filtro_RefOEM: $(Contenedor + 'txtRefOEMEdicion').val(),
            Filtro_CodigoBarra: $(Contenedor + 'txtCodigoBarraEdicion').val(),
            Filtro_CodigoProveedor: $(Contenedor + 'txtCodigoProveedorEdicion').val(),
            Filtro_Proveedor: $('#hfCodCtaCteEdicion').val(),
            Filtro_CodigoFabricante: $(Contenedor + 'txtCodigoFabricanteEdicion').val(),
            Filtro_Equivalente: $(Contenedor + 'txtEquivalenteEdicion').val(),          
            Filtro_TipoProducto:  $('#hfCodTipoProductoEdicion').val(),   
            Filtro_DescripcionModelo: $(Contenedor + 'txtDescripcionModeloEdicion').val(),
            Filtro_DscProducto: $(Contenedor + 'txtNombreFactEdicion').val(),
            Filtro_DescSistema: $(Contenedor + 'txtDescSistemaEdicion').val(),
            Filtro_MarcaFab: $(Contenedor + 'ddlMarcaFabEdicion').val(),
            Filtro_PaisOrigen: $(Contenedor + 'ddlPaisOrigenEdicion').val(),
            Filtro_UndVenta: $(Contenedor + 'ddlUndVentaEdicion').val(),
            Filtro_PesoTotal: $(Contenedor + 'txtPesoTotalEdicion').val(),
            Filtro_M1: $(Contenedor + 'txtM1Edicion').val(),
            Filtro_M2: $(Contenedor + 'txtM2Edicion').val(),
            Filtro_ControlStock: FlagControlStock,
            //////PRODUCTOS OPCIONALES  
            Filtro_NombreMed: $(Contenedor + 'ddlNombreMedEdicion').val(),
            Filtro_Medida1: $(Contenedor + 'txtMedida1Edicion').val(),
            Filtro_Medida2: $(Contenedor + 'txtMedida2Edicion').val(),
            Filtro_Tipo: $(Contenedor + 'ddlTipoEdicion').val(),
            Filtro_Almacen: $(Contenedor + 'txtAlmacenEdicion').val(),
            Filtro_Rack: $(Contenedor + 'txtRackEdicion').val(),
            Filtro_Nivel: $(Contenedor + 'txtNivelEdicion').val(),
            Filtro_Zona: $(Contenedor + 'txtZonaEdicion').val(),
            Filtro_Caja: $(Contenedor + 'txtCajaEdicion').val(),
            Filtro_Mostrador: $(Contenedor + 'txtMostradorEdicion').val(),
            Filtro_Marca1: $(Contenedor + 'ddlMarca1Edicion').val(),
            Filtro_Marca2: $(Contenedor + 'ddlMarca2Edicion').val(),
            Filtro_Marca3: $(Contenedor + 'ddlMarca3Edicion').val(),
            Filtro_Modelo1: $(Contenedor + 'txtModelo1Edicion').val(),
            Filtro_Modelo2: $(Contenedor + 'txtModelo2Edicion').val(),
            Filtro_Modelo3: $(Contenedor + 'txtModelo3Edicion').val(),
            Filtro_TipoMotor1: $(Contenedor + 'txtTipoMotor1Edicion').val(),
            Filtro_TipoMotor2: $(Contenedor + 'txtTipoMotor2Edicion').val(),
            Filtro_TipoMotor3: $(Contenedor + 'txtTipoMotor3Edicion').val(),
            Filtro_AñoIT1: $(Contenedor + 'txtAñoIT1Edicion').val(),
            Filtro_AñoIT2: $(Contenedor + 'txtAñoIT2Edicion').val(),  
            Filtro_AñoIT3: $(Contenedor + 'txtAñoIT3Edicion').val()   
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
                    toastr.success('Se ACTUALIZO Correctamente');
                    $('#divEdicionRegistro').dialog('close');
//                   F_Nuevo();
//                     var Cuerpo = '#MainContent_';
//                    F_ListarComboCategoriar($(Cuerpo + 'ddlFamilia').val());                    
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

function F_EditarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var hfCodProducto = '#' + imgID.replace('imgEditarRegistro', 'hfCodProducto');      
        var lblRedOEM = '#' + imgID.replace('imgEditarRegistro', 'lblRedOEM');
        var lblCodigoBarra = '#' + imgID.replace('imgEditarRegistro', 'lblCodigoBarra');
        var lblCodigoFabrica = '#' + imgID.replace('imgEditarRegistro', 'lblCodigoFabrica');
        var lblEquivalente = '#' + imgID.replace('imgEditarRegistro', 'lblEquivalente');
        var hfTipoProducto = '#' + imgID.replace('imgEditarRegistro', 'hfTipoProducto');
        var lblDescripcionModelo = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcionModelo');
        var lblDscProducto = '#' + imgID.replace('imgEditarRegistro', 'lblDscProducto');
        var lblDescripcionSistema = '#' + imgID.replace('imgEditarRegistro', 'lblDescripcionSistema');
        var hfCodMarcaProducto = '#' + imgID.replace('imgEditarRegistro', 'hfCodMarcaProducto'); 
        var hfCodPais = '#' + imgID.replace('imgEditarRegistro', 'hfCodPais');           
        var hfunidadVenta = '#' + imgID.replace('imgEditarRegistro', 'hfunidadVenta');
        var lblPesoTotal = '#' + imgID.replace('imgEditarRegistro', 'lblPesoTotal');
        var lblM1 = '#' + imgID.replace('imgEditarRegistro', 'lblM1');
        var lblM2 = '#' + imgID.replace('imgEditarRegistro', 'lblM2');
        var hfFlagControlStock = '#' + imgID.replace('imgEditarRegistro', 'hfFlagControlStock');
        var hfCodTitoMedida = '#' + imgID.replace('imgEditarRegistro', 'hfCodTitoMedida');
        var lblMedida1 = '#' + imgID.replace('imgEditarRegistro', 'lblMedida1');
        var lblMedida2 = '#' + imgID.replace('imgEditarRegistro', 'lblMedida2');
        var hfTIpoUbicacion = '#' + imgID.replace('imgEditarRegistro', 'hfTIpoUbicacion');
        var lblAlmacen = '#' + imgID.replace('imgEditarRegistro', 'lblAlmacen');
        var lblRack = '#' + imgID.replace('imgEditarRegistro', 'lblRack');
        var lblNivel = '#' + imgID.replace('imgEditarRegistro', 'lblNivel');
        var lblZona = '#' + imgID.replace('imgEditarRegistro', 'lblZona');
        var lblCaja = '#' + imgID.replace('imgEditarRegistro', 'lblCaja');
        var lblMostrador = '#' + imgID.replace('imgEditarRegistro', 'lblMostrador');
        var hfCodMarca1 = '#' + imgID.replace('imgEditarRegistro', 'hfCodMarca1');
        var hfCodMarca2 = '#' + imgID.replace('imgEditarRegistro', 'hfCodMarca2');
        var hfCodMarca3 = '#' + imgID.replace('imgEditarRegistro', 'hfCodMarca3');
        var lblModelo1 = '#' + imgID.replace('imgEditarRegistro', 'lblModelo1');
        var hfModelo2 = '#' + imgID.replace('imgEditarRegistro', 'hfModelo2');
        var hfModelo3 = '#' + imgID.replace('imgEditarRegistro', 'hfModelo3');
        var lblTipoMotor2 = '#' + imgID.replace('imgEditarRegistro', 'lblTipoMotor2');
        var lblTipoMotor3 = '#' + imgID.replace('imgEditarRegistro', 'lblTipoMotor3');
        var hfAñoIT1 = '#' + imgID.replace('imgEditarRegistro', 'hfAñoIT1');
        var hfAñoIT2 = '#' + imgID.replace('imgEditarRegistro', 'hfAñoIT2');
        var hfAñoIT3 = '#' + imgID.replace('imgEditarRegistro', 'hfAñoIT3');
        var hfIDFamilia = '#' + imgID.replace('imgEditarRegistro', 'hfIDFamilia');
        var lblCodigoProveedor = '#' + imgID.replace('imgEditarRegistro', 'lblCodigoProveedor');
        var hfProveedor = '#' + imgID.replace('imgEditarRegistro', 'hfProveedor');
        var lblDscMarca1 = '#' + imgID.replace('imgEditarRegistro', 'lblDscMarca1');
        var lblModelo = '#' + imgID.replace('imgEditarRegistro', 'lblModelo');
        var lblTipoMotor1 = '#' + imgID.replace('imgEditarRegistro', 'lblTipoMotor1');
        var lblMedida = '#' + imgID.replace('imgEditarRegistro', 'lblMedida');
        var lblMarca = '#' + imgID.replace('imgEditarRegistro', 'lblMarca');
        var lblCodigoInterno = '#' + imgID.replace('imgEditarRegistro', 'lblCodigoInterno');
        var hfCodCategoria = '#' + imgID.replace('imgEditarRegistro', 'hfCodCategoria');
        var hfCodCtaCte = '#' + imgID.replace('imgEditarRegistro', 'hfCodCtaCte');
        var hfDescripcionAutocomplete = '#' + imgID.replace('imgEditarRegistro', 'hfDescripcionAutocomplete');
        var hfDescripcionTipoProducto = '#' + imgID.replace('imgEditarRegistro', 'hfDescripcionTipoProducto');
        var hfCodigoCategoria = '#' + imgID.replace('imgEditarRegistro', 'hfCodigoCategoria');

        var Cuerpo = '#MainContent_';

        $('#hfCodProducto').val($(hfCodProducto).val());
        $('#hfCodigoEdicion').val($(lblCodigoInterno).text());
        $(Cuerpo + 'txtCodigoInternoEdicion').val($(lblCodigoInterno).text());
        $(Cuerpo + 'txtRefOEMEdicion').val($(lblRedOEM).val());
        $(Cuerpo + 'txtCodigoBarraEdicion').val($(lblCodigoBarra).val());
        $(Cuerpo + 'txtCodigoProveedorEdicion').val($(lblCodigoProveedor).text());        
        $(Cuerpo + 'txtProveedorEdicion').val($(hfProveedor).val());
        $(Cuerpo + 'txtCodigoFabricanteEdicion').val($(lblCodigoFabrica).val());
        $(Cuerpo + 'txtEquivalenteEdicion').val($(lblEquivalente).val());
        $(Cuerpo + 'ddlFamiliaEdicion').val($(hfIDFamilia).val()); 
        $('#hfCodCtaCteEdicion').val($(hfCodCtaCte).val());
        $('#hfCodTipoProductoEdicion').val($(hfTipoProducto).val());
        $(Cuerpo + 'txtDescripcionModeloEdicion').val($(lblDescripcionModelo).text());
        $(Cuerpo + 'txtNombreFactEdicion').val($(lblDscProducto).val());
        $(Cuerpo + 'txtDescSistemaEdicion').val($(lblDescripcionSistema).val());
        $(Cuerpo + 'ddlMarcaFabEdicion').val($(hfCodMarcaProducto).val());
        $(Cuerpo + 'ddlPaisOrigenEdicion').val($(hfCodPais).val());  
        $(Cuerpo + 'txtTipoProductoEdicion').val($(hfDescripcionAutocomplete).val());  
        $(Cuerpo + 'ddlUndVentaEdicion').val($(hfunidadVenta).val());
        $('#hfCodigoEdicion').val($(hfCodigoCategoria).val());
        $('#hfTipoProductoEdicion').val($(hfDescripcionTipoProducto).val());
        $(Cuerpo + 'txtPesoTotalEdicion').val($(lblPesoTotal).val());
        $(Cuerpo + 'txtM1Edicion').val($(lblM1).val());
        $(Cuerpo + 'txtM2Edicion').val($(lblM2).val());
        $(Cuerpo + 'chkControlStockEdicion').val($(hfFlagControlStock).val());

        $(Cuerpo + 'ddlNombreMedEdicion').val($(hfCodTitoMedida).val());
        $(Cuerpo + 'txtMedida1Edicion').val($(lblMedida1).text());
        $(Cuerpo + 'txtMedida2Edicion').val($(lblMedida2).text());

        $(Cuerpo + 'ddlTipoEdicion').val($(hfTIpoUbicacion).val());
        $(Cuerpo + 'txtAlmacenEdicion').val($(lblAlmacen).val());
        $(Cuerpo + 'txtRackEdicion').val($(lblRack).val());
        $(Cuerpo + 'txtNivelEdicion').val($(lblNivel).val());
        $(Cuerpo + 'txtZonaEdicion').val($(lblZona).val());
        $(Cuerpo + 'txtCajaEdicion').val($(lblCaja).val());
        $(Cuerpo + 'txtMostradorEdicion').val($(lblMostrador).val());

        $(Cuerpo + 'ddlMarca1Edicion').val($(hfCodMarca1).val());
        $(Cuerpo + 'ddlMarca2Edicion').val($(hfCodMarca2).val());
        $(Cuerpo + 'ddlMarca3Edicion').val($(hfCodMarca3).val());
        $(Cuerpo + 'txtModelo1Edicion').val($(lblModelo1).text());
        $(Cuerpo + 'txtModelo2Edicion').val($(hfModelo2).val());
        $(Cuerpo + 'txtModelo3Edicion').val($(hfModelo3).val());

        $(Cuerpo + 'txtTipoMotor1Edicion').val($(lblTipoMotor1).text());
        $(Cuerpo + 'txtTipoMotor2Edicion').val($(lblTipoMotor2).val());
        $(Cuerpo + 'txtTipoMotor3Edicion').val($(lblTipoMotor3).val());
        $(Cuerpo + 'txtAñoIT1Edicion').val($(hfAñoIT1).val());
        $(Cuerpo + 'txtAñoIT2Edicion').val($(hfAñoIT2).val());
        $(Cuerpo + 'txtAñoIT3Edicion').val($(hfAñoIT3).val());

        if ($(hfFlagControlStock).val()==1)
            $('#MainContent_chkControlStock').prop('checked',true);
        else 
            $('#MainContent_chkControlStock').prop('checked',false);

        $("#divEdicionRegistro").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Producto",
            title_html: true,
            height: 390,
            width: 1150,
            autoOpen: false
        });

        $('#divEdicionRegistro').dialog('open');

        return false;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}

//////////DETALLE
function F_DetalleProducto(Fila) {

    var imgID = Fila.id;
    var Contenedor = '#MainContent_';
    var hfCodProducto = '#' + imgID.replace('imgDetalleProducto', 'hfCodProducto');

     $('#hfCodProducto').val($(hfCodProducto).val());

    $('#div_DetalleProducto').dialog({
        resizable: false,
        modal: true,
        title: "DETALLE PRODUCTO",
        title_html: true,
        height: 500,
        width: 890,
        autoOpen: false
    });
    $('#div_DetalleProducto').dialog('open');

    F_Buscar_Detalle($(hfCodProducto).val());
    return false;
}

//VALIDACIONES
function F_ValidarEditarProductoWong() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; 
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtCodigoInternoEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'CODIGO INTERNO';     
        if ($('#hfCodTipoProductoEdicion').val() == 0 || $.trim($(Cuerpo + 'txtTipoProductoEdicion').val()) == '') 
            Cadena = Cadena + '<p></p>' + 'TIPO PRODUCTO';          
        if ($(Cuerpo + 'txtNombreFactEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'NOMBRE FACTURA';            
        if ($(Cuerpo + 'ddlUndVentaEdicion').val() == 0 || $(Cuerpo + 'ddlUndVentaEdicion').val() == null)
            Cadena = Cadena + '<p></p>' + 'UND VENTA';
        if ($(Cuerpo + 'txtM1Edicion').val() == '0.00' || $(Cuerpo + 'txtM1Edicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'M1';
            if ($(Cuerpo + 'txtM2Edicion').val() == '0.00' || $(Cuerpo + 'txtM1Edicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'M2';

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

function F_ValidarGrabarProductoWong() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; 
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtCodigoInterno').val() == '')
            Cadena = Cadena + '<p></p>' + 'CODIGO INTERNO';
        if ($(Cuerpo + 'txtProveedor').val() == '')
            Cadena = Cadena + '<p></p>' + 'PROVEEDOR';      
        if ($(Cuerpo + 'ddlCategoria').val() == 0 || $(Cuerpo + 'ddlCategoria').val() == null)
            Cadena = Cadena + '<p></p>' + 'CATEGORIA';
        if ($(Cuerpo + 'ddlTipoProducto').val() == 0 || $(Cuerpo + 'ddlTipoProducto').val() == null) 
            Cadena = Cadena + '<p></p>' + 'TIPO PRODUCTO';          
        if ($(Cuerpo + 'txtNombreFact').val() == '')
            Cadena = Cadena + '<p></p>' + 'NOMBRE FACTURA';            
        if ($(Cuerpo + 'ddlUndVenta').val() == 0 || $(Cuerpo + 'ddlUndVenta').val() == null)
            Cadena = Cadena + '<p></p>' + 'UND VENTA';
        if ($(Cuerpo + 'txtM1').val() == '0.00' || $(Cuerpo + 'txtM1').val() == '')
            Cadena = Cadena + '<p></p>' + 'M1';
            if ($(Cuerpo + 'txtM2').val() == '0.00' || $(Cuerpo + 'txtM1').val() == '')
            Cadena = Cadena + '<p></p>' + 'M2';

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

function F_Css_Cajatextos()
{
    $('#MainContent_txtCodigoInterno').css('background', '#FFFFE0');

    $('#MainContent_txtRefOEM').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoBarra').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoProvincia').css('background', '#FFFFE0');

    $('#MainContent_txtProveedor').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoFabricante').css('background', '#FFFFE0');

    $('#MainContent_txtEquivalente').css('background', '#FFFFE0');

    $('#MainContent_ddlFamilia').css('background', '#FFFFE0');    
    $('#MainContent_ddlTipoProducto').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionModelo').css('background', '#FFFFE0');
    $('#MainContent_txtNombreFact').css('background', '#FFFFE0');
    $('#MainContent_txtDescSistema').css('background', '#FFFFE0');
    $('#MainContent_ddlMarcaFab').css('background', '#FFFFE0');
    $('#MainContent_ddlPaisOrigen').css('background', '#FFFFE0');
    $('#MainContent_ddlUndVenta').css('background', '#FFFFE0');
    $('#MainContent_txtPesoTotal').css('background', '#FFFFE0');
    $('#MainContent_txtM1').css('background', '#FFFFE0');
    $('#MainContent_txtM2').css('background', '#FFFFE0');
    $('#MainContent_chkControlStock').css('background', '#FFFFE0');
    $('#MainContent_ddlNombreMed').css('background', '#FFFFE0');
    $('#MainContent_txtMedida1').css('background', '#FFFFE0');
    $('#MainContent_txtMedida2').css('background', '#FFFFE0');
    $('#MainContent_ddlTipo').css('background', '#FFFFE0');
    $('#MainContent_txtAlmacen').css('background', '#FFFFE0');
    $('#MainContent_txtRack').css('background', '#FFFFE0');
    $('#MainContent_txtNivel').css('background', '#FFFFE0');
    $('#MainContent_txtZona').css('background', '#FFFFE0');
    $('#MainContent_txtCaja').css('background', '#FFFFE0');
    $('#MainContent_txtMostrador').css('background', '#FFFFE0');
    $('#MainContent_ddlMarca3').css('background', '#FFFFE0');
    $('#MainContent_ddlMarca2').css('background', '#FFFFE0');
    $('#MainContent_ddlMarca1').css('background', '#FFFFE0');
    $('#MainContent_txtModelo1').css('background', '#FFFFE0');
    $('#MainContent_txtModelo2').css('background', '#FFFFE0');
    $('#MainContent_txtModelo3').css('background', '#FFFFE0');
    $('#MainContent_txtTipoMotor1').css('background', '#FFFFE0');
    $('#MainContent_txtTipoMotor2').css('background', '#FFFFE0');
    $('#MainContent_txtTipoMotor3').css('background', '#FFFFE0');
    $('#MainContent_txtAñoIT1').css('background', '#FFFFE0');
    $('#MainContent_txtAñoIT2').css('background', '#FFFFE0');
    $('#MainContent_txtAñoIT3').css('background', '#FFFFE0');
    $('#MainContent_ddlCategoria').css('background', '#FFFFE0');
    $('#MainContent_txtCodigoProveedor').css('background', '#FFFFE0');
    $('#MainContent_txtAñoDetalle').css('background', '#FFFFE0');
    $('#MainContent_txtAñoDetalleEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtTipoProducto').css('background', '#FFFFE0');
    $('#MainContent_txtNombreMed').css('background', '#FFFFE0');
    $('#MainContent_txtTipo').css('background', '#FFFFE0');

    //EDICION
     $('#MainContent_txtCodigoInternoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtRefOEMEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoBarraEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoProvinciaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtProveedorEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCodigoFabricanteEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtEquivalenteEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtTipoProductoEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlFamiliaEdicion').css('background', '#FFFFE0');    
    $('#MainContent_ddlTipoProductoEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionModeloEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtNombreFactEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtDescSistemaEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlMarcaFabEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlPaisOrigenEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlUndVentaEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtPesoTotalEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtM1Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtM2Edicion').css('background', '#FFFFE0');
    $('#MainContent_chkControlStockEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlNombreMedEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtMedida1Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtMedida2Edicion').css('background', '#FFFFE0');
    $('#MainContent_ddlTipoEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtAlmacenEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtRackEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtNivelEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtZonaEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtCajaEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtMostradorEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlMarca3Edicion').css('background', '#FFFFE0');
    $('#MainContent_ddlMarca2Edicion').css('background', '#FFFFE0');
    $('#MainContent_ddlMarca1Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtModelo1Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtModelo2Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtModelo3Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtTipoMotor1Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtTipoMotor2Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtTipoMotor3Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtAñoIT1Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtAñoIT2Edicion').css('background', '#FFFFE0');
    $('#MainContent_txtAñoIT3Edicion').css('background', '#FFFFE0');
    $('#MainContent_ddlCategoriaEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtCodigoProveedorEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtNombreMedEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtTipoEdicion').css('background', '#FFFFE0');
    //consulta
    $('#MainContent_ddlCodigoConsulta').css('background', '#FFFFE0');
    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');
    $('#MainContent_txtCodigoBarraConsulta').css('background', '#FFFFE0');
    $('#MainContent_txtCodigoProveedor').css('background', '#FFFFE0');
    $('#MainContent_ddlPRUEBA').css('background', '#FFFFE0');

        //detalle producto
    $('#MainContent_ddlMarcaAplicaciones').css('background', '#FFFFE0');
    $('#MainContent_ddlModeloAplicaciones').css('background', '#FFFFE0');
    $('#MainContent_ddlMotorAplicaciones').css('background', '#FFFFE0');
    $('#MainContent_txtMotorDetalle').css('background', '#FFFFE0');
    return false;
}

function F_ValidaMonto(ControlId) {
    ControlId = '#' + ControlId;
    var $textBox = $(ControlId);

    if ($textBox.val() === '') {
        return false;
    }
    if (isNaN($textBox.val())) {
        $textBox.val('');
        $textBox.select();
        return false;
    }
    $textBox.val(parseFloat($textBox.val()).toFixed(2));


    return true;
}

function F_ValidarGrabarProductoWong() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; 
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtCodigoInterno').val() == '')
            Cadena = Cadena + '<p></p>' + 'CODIGO INTERNO';
        if ($(Cuerpo + 'txtCodigoBarra').val() == '')
            Cadena = Cadena + '<p></p>' + 'CODIGO BARRA';
        if ($(Cuerpo + 'txtProveedor').val() == '')
            Cadena = Cadena + '<p></p>' + 'PROVEEDOR';      
        if ($(Cuerpo + 'ddlCategoria').val() == 0 || $(Cuerpo + 'ddlCategoria').val() == null)
            Cadena = Cadena + '<p></p>' + 'CATEGORIA';
        if ($(Cuerpo + 'ddlTipoProducto').val() == 0 || $(Cuerpo + 'ddlTipoProducto').val() == null) 
            Cadena = Cadena + '<p></p>' + 'TIPO PRODUCTO';  
        if ($(Cuerpo + 'txtDescripcionModelo').val() == '')
            Cadena = Cadena + '<p></p>' + 'DESCRIPCION MODELO';         
        if ($(Cuerpo + 'txtNombreFact').val() == '')
            Cadena = Cadena + '<p></p>' + 'NOMBRE FACTURA';
        if ($(Cuerpo + 'txtDescSistema').val() == '')
            Cadena = Cadena + '<p></p>' + 'DESCRIPCION SISTEAMA';             
        if ($(Cuerpo + 'ddlUndVenta').val() == 0 || $(Cuerpo + 'ddlUndVenta').val() == null)
            Cadena = Cadena + '<p></p>' + 'UND VENTA';
        if ($(Cuerpo + 'txtM1').val() == '0.00' || $(Cuerpo + 'txtM1').val() == '')
            Cadena = Cadena + '<p></p>' + 'M1';
            if ($(Cuerpo + 'txtM2').val() == '0.00' || $(Cuerpo + 'txtM1').val() == '')
            Cadena = Cadena + '<p></p>' + 'M2';

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
    
    $('#hfCodTipoProducto').val('0');   
    $('#hfTipoProducto').val('');   
    $('#hfCodigo').val('');   
    $(Contenedor + 'txtTipoProducto').val('');   
    $(Contenedor + 'txtRefOEM').val('');   
    $(Contenedor + 'txtCodigoProveedor').val('');  
    $(Contenedor + 'txtCodigoFabricante').val('');
    $(Contenedor + 'txtEquivalente').val('');         
    $(Contenedor + 'txtDescripcionModelo').val('');
    $(Contenedor + 'txtNombreFact').val('');
    $(Contenedor + 'txtDescSistema').val('');
    $(Contenedor + 'txtPesoTotal').val('');
    $(Contenedor + 'txtM1').val('');
    $(Contenedor + 'txtM2').val(''); 
    $(Contenedor + 'txtMedida1').val('');
    $(Contenedor + 'txtMedida2').val('');
    $(Contenedor + 'txtAlmacen').val('');
    $(Contenedor + 'txtRack').val('');
    $(Contenedor + 'txtNivel').val('');
    $(Contenedor + 'txtZona').val('');
    $(Contenedor + 'txtCaja').val('');
    $(Contenedor + 'txtMostrador').val('');
    $(Contenedor + 'txtModelo1').val('');
    $(Contenedor + 'txtModelo2').val('');
    $(Contenedor + 'txtModelo3').val('');
    $(Contenedor + 'txtTipoMotor1').val('');
    $(Contenedor + 'txtTipoMotor2').val('');
    $(Contenedor + 'txtTipoMotor3').val('');
    $(Contenedor + 'txtAñoIT1').val('');
    $(Contenedor + 'txtAñoIT2').val('');  
    $(Contenedor + 'txtAñoIT3').val('');  
    $(Contenedor + 'txtNombreMed').val('');  
    $(Contenedor + 'txtAñoIT3').val(''); 
    $(Contenedor + 'txtCodigoProveedor').val('');  
    $(Contenedor + 'txtProveedor').val(''); 
    $(Contenedor + 'ddlEstado').val(0); 
    $('#MainContent_ddlMarca1').val(0);
    $('#MainContent_ddlMarca2').val(0);
    $('#MainContent_ddlMarca3').val(0);
    $('#MainContent_ddlMarcaFab').val(0);
    $('#MainContent_ddlPaisOrigen').val(0);
    $('#MainContent_ddlUndVenta').val(22);    

    return false;
}

function F_ConcatenarDescripcionSistemaFactura(){

var TipoProducto= $.trim($('#hfTipoProducto').val()); 
 var Marca = $.trim($("#MainContent_ddlMarca1 option:selected").text());  
var TipoMotor =$.trim($('#MainContent_txtTipoMotor1').val());
var MarcaFabricante = $.trim($("#MainContent_ddlMarcaFab option:selected").text()); 
var Modelo = $.trim($('#MainContent_txtModelo1').val());
var DscModelo = $.trim($('#MainContent_txtDescripcionModelo').val());

 var cadena = TipoProducto +' '+ Marca +' '+ TipoMotor+ ' '+MarcaFabricante;

 if(TipoProducto=='TODOS')
 {
 TipoProducto= '';
 }

  $('#MainContent_txtDescSistema').val(cadena);

  cadena = TipoProducto +' '+ Marca +' ' + Modelo+' ' + TipoMotor+ ' '+MarcaFabricante + ' '+ DscModelo;

   $('#MainContent_txtNombreFact').val(cadena);

   

return false
}

function F_ConcatenarDescripcionSistemaFacturaEdicion(){

var TipoProducto= $.trim($('#hfTipoProductoEdicion').val()); 
 var Marca = $.trim($("#MainContent_ddlMarca1Edicion option:selected").text());  
var TipoMotor =$.trim($('#MainContent_txtTipoMotor1Edicion').val());
var MarcaFabricante = $.trim($("#MainContent_ddlMarcaFabEdicion option:selected").text()); 
var Modelo = $.trim($('#MainContent_txtModelo1Edicion').val());
var DscModelo = $.trim($('#MainContent_txtDescripcionModeloEdicion').val());

 var cadena = TipoProducto +' '+ Marca +' '+ TipoMotor+ ' '+MarcaFabricante;

 if(TipoProducto=='TODOS')
 {
 TipoProducto= '';
 }

  $('#MainContent_txtDescSistemaEdicion').val(cadena);

  cadena = TipoProducto +' '+ Marca +' ' + Modelo+' ' + TipoMotor+ ' '+MarcaFabricante + ' '+ DscModelo;

   $('#MainContent_txtNombreFactEdicion').val(cadena);

   

return false
}

function F_Buscar_Detalle(CodProducto) {
    try {
        var objParams = {
            Filtro_CodProducto: CodProducto
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Buscar_Detalle_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_ProductoDetalle', result.split('~')[2]);
                F_ListarComboModelo($('#MainContent_ddlMarcaAplicaciones').val());
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
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_ListarComboModeloEdicion(CodVehiculo) {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;
 
    try {
        var objParams = {
            Filtro_CodVehiculo: CodVehiculo            
        };
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarComboModeloEdicion_NET
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
                     F_Update_Division_HTML('div_ModeloAplicacionesEdicion', result.split('~')[2]);                    
                     $('#MainContent_ddlModeloAplicacionesEdicion').css('background', '#FFFFE0');   
                     F_ListarComboMotorEdicion($('#MainContent_ddlModeloAplicacionesEdicion').val());                                   
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

function F_ListarComboMotorEdicion(CodModelo) {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;
 
    try {
        var objParams = {
            Filtro_CodModelo: CodModelo            
        };
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarComboMotorEdicion_NET
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
                     F_Update_Division_HTML('div_MotorAplicaciones', result.split('~')[2]);                    
                     $('#MainContent_ddlMotorAplicaciones').css('background', '#FFFFE0');  
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

function F_ListarComboModelo(CodVehiculo) {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;
 
    try {
        var objParams = {
            Filtro_CodVehiculo: CodVehiculo            
        };
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarComboModelo_NET
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
                     F_Update_Division_HTML('div_ModeloAplicaciones', result.split('~')[2]);                     
                     $('#MainContent_ddlModeloAplicaciones').css('background', '#FFFFE0');        
                     F_ListarComboMotor($('#MainContent_ddlModeloAplicaciones').val());                                   
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

function F_ListarComboMotor(CodModelo) {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;
 
    try {
        var objParams = {
            Filtro_CodModelo: CodModelo            
        };
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarComboMotor_NET
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
                     F_Update_Division_HTML('div_MotorAplicaciones', result.split('~')[2]);   
                     F_Update_Division_HTML('div_MotorAplicaciones', result.split('~')[3]);                    
                     $('#MainContent_ddlMotorAplicaciones').css('background', '#FFFFE0');                     
                     $('#MainContent_ddlMotorAplicacionesEdicion').css('background', '#FFFFE0');  
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

function F_ListarComboMotorEdicion(CodModelo) {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;
 
    try {
        var objParams = {
            Filtro_CodModelo: CodModelo            
        };
        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarComboMotorEdicion_NET
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
                     F_Update_Division_HTML('div_MotorAplicacionesEdicion', result.split('~')[2]);                    
                     $('#MainContent_ddlMotorAplicacionesEdicion').css('background', '#FFFFE0');  
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

function F_GrabarDetalle() {
    try {

       var Contenedor = '#MainContent_';
        

        var objParams = {
            Filtro_CodProducto:$('#hfCodProducto').val(),
            Filtro_MarcaAplicaciones: $(Contenedor + 'ddlMarcaAplicaciones').val(),
            Filtro_ModeloAplicaciones: $(Contenedor + 'ddlModeloAplicaciones').val(),
            Filtro_MotorAplicaciones: $(Contenedor + 'ddlMotorAplicaciones').val(),
            Filtro_AñoDetalle: $(Contenedor + 'txtAñoDetalle').val(),
          
            
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDetalle_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    toastr.success('Se Grabo Correctamente');
                   F_Buscar_Detalle($('#hfCodProducto').val());
                   $(Contenedor + 'txtAñoDetalle').val('')
                     var Cuerpo = '#MainContent_';
//                    F_ListarComboCategoriar($(Cuerpo + 'ddlFamilia').val()); 

                   
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

function F_EliminarDetalleProducto(Fila) {
if (confirm("ESTA SEGURO DE ELIMINAR EL DETALLE"))
    try {
      var imgID = Fila.id;
        var hfCodProductoDetalle = '#' + imgID.replace('imgAnularDocumento', 'lblItem');   

        var objParams = {
            Filtro_CodProductoDetalle: $(hfCodProductoDetalle).text()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_EliminarDetalle_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
               
                   F_Buscar_Detalle($('#hfCodProducto').val());
                   toastr.success('Se Elimino Correctamente');
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
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_EditarDetalleProducto(Fila) {
     var imgID = Fila.id;
    var Contenedor = '#MainContent_';
    var lblItem = '#' + imgID.replace('imgEditarRegistro', 'lblItem');
    var hfCodMarca = '#' + imgID.replace('imgEditarRegistro', 'hfCodMarca');
    var hfCodModelo = '#' + imgID.replace('imgEditarRegistro', 'hfCodModelo');
    var hfCodmotor = '#' + imgID.replace('imgEditarRegistro', 'hfCodmotor');
    var lblAñoIT1 = '#' + imgID.replace('imgEditarRegistro', 'lblAñoIT1');

   


    $('#div_DetalleProductoEdicion').dialog({
        resizable: false,
        modal: true,
        title: "Precio Minimo",
        title_html: true,
        height: 180,
        width: 300,
        autoOpen: false
    });
    $('#MainContent_ddlMarcaAplicacionesEdicion').val($(hfCodMarca).val());
    F_ListarComboModeloEdicion($('#MainContent_ddlMarcaAplicacionesEdicion').val());
    $('#div_DetalleProductoEdicion').dialog('open');
    
     $('#hfCodProductoDetalle').val($(lblItem).text());
    
    
    
    $('#MainContent_ddlModeloAplicacionesEdicion').val($(hfCodModelo).val());
    
    $('#MainContent_ddlMotorAplicacionesEdicion').val($(hfCodmotor).val());
    
    $('#MainContent_txtAñoDetalleEdicion').val($(lblAñoIT1).text());



}

function F_EditarDetalle() {
    try {

       var Contenedor = '#MainContent_';
        

        var objParams = {
            Filtro_CodProductoDetalle:$('#hfCodProductoDetalle').val(),
            Filtro_MarcaAplicaciones: $(Contenedor + 'ddlMarcaAplicacionesEdicion').val(),
            Filtro_ModeloAplicaciones: $(Contenedor + 'ddlModeloAplicacionesEdicion').val(),
            Filtro_MotorAplicaciones: $(Contenedor + 'ddlMotorAplicacionesEdicion').val(),
            Filtro_AñoDetalle: $(Contenedor + 'txtAñoDetalleEdicion').val()
          
            
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EditarDetalle_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE EDITO CORRECTAMENTE') {
                    toastr.success('Se Edito Correctamente');
                    
                   F_Buscar_Detalle($('#hfCodProducto').val());
                    $('#div_DetalleProductoEdicion').dialog('close');
                     var Cuerpo = '#MainContent_';
//                    F_ListarComboCategoriar($(Cuerpo + 'ddlFamilia').val()); 

                   
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