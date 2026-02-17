var AppSession = "../Reportes/Estadistico_Ventas_General_Karina.aspx";

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    
    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;



    }



    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    }).datepicker($.datepicker.regional['es'])
      .datepicker('setDate', new Date());

    
    $('.MesAnioPicker').datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: 'yymm',
        onClose: function (dateText, inst) {
            var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
            var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
            $(this).val($.datepicker.formatDate('yymm', new Date(year, month, 1)));
        }
    }).datepicker($.datepicker.regional['es'])
      .datepicker('setDate', new Date());

    $('.MesAnioPicker').focus(function () {
        $('.ui-datepicker-calendar').hide();
        $('#ui-datepicker-div').position({
            my: 'center top',
            at: 'center bottom',
            of: $(this)
        });
    });



  
    var fechaHasta = new Date();

    
    var fechaDesde = new Date();
    fechaDesde.setMonth(fechaDesde.getMonth() - 6);

 
    function formatYYYYMM(fecha) {
        var year = fecha.getFullYear();
        var month = (fecha.getMonth() + 1).toString().padStart(2, '0'); 
        return year.toString() + month;
    }

 
    $('#MainContent_txtDesde').val(formatYYYYMM(fechaDesde));
    $('#MainContent_txtHasta').val(formatYYYYMM(fechaHasta));

    
    $('#MainContent_txtDesde').datepicker('setDate', fechaDesde);
    $('#MainContent_txtHasta').datepicker('setDate', fechaHasta);


    $('#MainContent_btnReporte').click(function () {
        cargarGraficoGeneral();
        cargarGraficoVendedor();
        cargarGraficoProducto();
        cargarGraficoSucursal();
        return false;
    });

    $('#MainContent_btnBuscarVendedor').click(function () {
        cargarGraficoVendedor();
        return false;
    });

     $('#MainContent_btnBuscarProductos').click(function () {
        cargarGraficoProducto();
        return false;
    });

    $('#MainContent_btnBuscarSucursales').click(function () {
    cargarGraficoSucursal();
    return false;
    });

 
    F_Controles_Inicializar();
    F_Derecha();



});

 

 
function F_Controles_Inicializar() {
    var arg;

    try {
        var objParams =
            {
                Filtro_CodSerie: 67
            };

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
                        $('#hfCodSede').val(result.split('~')[2]);
                        F_Update_Division_HTML('div_Sucursal', result.split('~')[3]);
                        $('#MainContent_ddlSucursal').css('background', '#FFFFE0');
                        $('#MainContent_txtDesde').css('background', '#FFFFE0');
                        $('#MainContent_txtHasta').css('background', '#FFFFE0');
                        $('#MainContent_ddlSucursal').val('0');

                        cargarGraficoGeneral();
                        cargarGraficoVendedor();
                        cargarGraficoProducto();
                        cargarGraficoSucursal();
                    }
                    else {
                        alertify.log(str_mensaje_operacion);
                    }
                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);
    }
}



$().ready(function () {
    $(document).everyTime(900000, function () {
        if (!F_ValidaSesionActiva(AppSession)) return false;
    });
});



  
var chartVentas = null;
var chartVendedor = null;
var charProducto = null;
var charSucursal = null;
var chartPie = null;


function cargarGraficoGeneral() {
    var GraficoDesde = $("#MainContent_txtDesde").val();
    var GraficoHasta = $("#MainContent_txtHasta").val();

    $.ajax({
        type: "POST",
        url: "../Servicios/Servicios.asmx/F_GRAFICO_ESTADISTICO_NET",
        data: "{'GraficoDesde':'" + GraficoDesde + "','GraficoHasta':'" + GraficoHasta + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var data = response.d;
            var labels = data.map(function (x) { return x.Meses; });
            var values = data.map(function (x) { return x.Venta; });
            renderChartVentas(labels, values);
            renderChartPie(labels, values);   
        },
        error: function (xhr, status, error) {
            alertify.log("Error: " + error);
        }
    });
}



function cargarGraficoVendedor() {
    var GraficoDesde = $("#MainContent_txtDesde").val();
    var GraficoHasta = $("#MainContent_txtHasta").val();

    $.ajax({
        type: "POST",
        url: "../Servicios/Servicios.asmx/F_GRAFICO_ESTADISTICO_VENDEDOR_NET",
        data: "{'GraficoDesde':'" + GraficoDesde + "','GraficoHasta':'" + GraficoHasta + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var data = response.d;
            var labels = data.map(function(x) { return x.Meses; });
            var values = data.map(function(x) { return x.Venta; });
            renderChartVendedor(labels, values);
           
        },
        error: function (xhr, status, error) {
            alertify.log("Error: " + error);
        }
    });
}

function cargarGraficoProducto() {
    var GraficoDesde = $("#MainContent_txtDesde").val();
    var GraficoHasta = $("#MainContent_txtHasta").val();

    $.ajax({
        type: "POST",
        url: "../Servicios/Servicios.asmx/F_GRAFICO_ESTADISTICO_PRODUCTOS_NET",
        data: "{'GraficoDesde':'" + GraficoDesde + "','GraficoHasta':'" + GraficoHasta + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var data = response.d;
             var labels = data.map(function(x) { return x.Meses; });
            var values = data.map(function(x) { return x.Venta; });
            renderChartProductos(labels, values);

           
        },
        error: function (xhr, status, error) {
            alertify.log("Error: " + error);
        }
    });
}


function cargarGraficoSucursal() {
    var GraficoDesde = $("#MainContent_txtDesde").val();
    var GraficoHasta = $("#MainContent_txtHasta").val();

    $.ajax({
        type: "POST",
        url: "../Servicios/Servicios.asmx/F_GRAFICO_ESTADISTICO_SUCURSAL_NET",
        data: "{'GraficoDesde':'" + GraficoDesde + "','GraficoHasta':'" + GraficoHasta + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var data = response.d;
            var labels = data.map(function(x) { return x.Meses; });
            var values = data.map(function(x) { return x.Venta; });
            renderChartSucursal(labels, values);
        },
        error: function (xhr, status, error) {
            alertify.log("Error: " + error);
        }
    });
}




function renderChartVentas(labels, values) {
    if (chartVentas) chartVentas.destroy();
    chartVentas = new Chart(document.getElementById("canvasVentas").getContext("2d"), {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Ventas Generales (S/.)',
                data: values,
                backgroundColor: 'rgba(54,162,235,0.6)',
                borderColor: 'rgba(54,162,235,1)',
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                datalabels: {
                    anchor: 'end',
                    align: 'top',
                    color: '#000',
                    font: {
                        weight: 'bold',
                        size: 10
                    },
                    formatter: function (value) {
                       return 'S/. ' + value.toLocaleString('es-PE', {
                            minimumFractionDigits: 0,
                            maximumFractionDigits: 2
                        });
                    }
                }
            }
        },
        plugins: [ChartDataLabels]
    });
}



//function renderChartVendedor(labels, values) {
//    
//    const canvas = document.getElementById("canvasVentasHorizontal");
//    canvas.height = labels.length * 28;

//    if (chartVendedor) chartVendedor.destroy();
////    chartVendedor = new Chart(document.getElementById("canvasVentasHorizontal").getContext("2d"), {
//    chartVendedor = new Chart(canvas.getContext("2d"), {
//        type: 'bar',
//        data: {
//            labels: labels,
//            datasets: [{
//                label: 'Ventas por Vendedor (S/.)',
//                data: values,
//                backgroundColor: 'rgba(255,99,132,0.6)',
//                borderColor: 'rgba(255,99,132,1)',
//                borderWidth: 2
//            }]
//        },
//        options: {
//            indexAxis: 'y',
//            responsive: true,
//            maintainAspectRatio: false,
//            layout: {
//                padding: {
//                    right: 80  
//                }
//            },
//            plugins: {
//                datalabels: {
//                    anchor: 'end',
//                    align: 'right',
//                    color: '#000',
//                    font: {
//                        size: 9
//                    },
//                    formatter: function (value) {
//                        return 'S/.' + value.toLocaleString('es-PE', {
//                            minimumFractionDigits: 0,
//                            maximumFractionDigits: 2
//                        });
//                    }
//                }
//            },
//            scales: {
//                x: {
//                    beginAtZero: true
//                }
//            }
//        },
//        plugins: [ChartDataLabels]
//    });
//}



function renderChartVendedor(labels, values) {

    const canvas = document.getElementById("canvasVentasHorizontal");
    canvas.height = labels.length * 28;

    if (chartVendedor) chartVendedor.destroy();

    chartVendedor = new Chart(canvas.getContext("2d"), {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Ventas por Vendedor (S/.)',
                data: values,
                backgroundColor: 'rgba(255,99,132,0.6)',
                borderColor: 'rgba(255,99,132,1)',
                borderWidth: 2
            }]
        },
        options: {
            indexAxis: 'y',
            responsive: true,
            maintainAspectRatio: false,
            layout: {
                padding: {
                    right: 80
                }
            },
            plugins: {
                datalabels: {
                    anchor: 'end',
                    align: 'right',
                    color: '#000',
                    font: {
                        size: 9
                    },
                    formatter: function (value) {
                        return 'S/.' + value.toLocaleString('es-PE', {
                            minimumFractionDigits: 0,
                            maximumFractionDigits: 2
                        });
                    }
                }
            },
            scales: {
                x: {
                    beginAtZero: true
                },
                y: {
                    ticks: {
                        autoSkip: false,
                        font: {
                            size: 10
                        }
                    }
                }
            }
        },
        plugins: [ChartDataLabels]
    });
}















function renderChartProductos(labels, values) {
    if (charProducto) charProducto.destroy(); 
    charProducto = new Chart(document.getElementById("canvasVentasProducto").getContext("2d"), {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Productos Mas Vendidos (UND)',
                data: values,
                backgroundColor: 'rgba(255, 206, 86, 0.6)',
                borderColor: 'rgba(255, 206, 86, 1)',
                borderWidth: 2
            }]
        },
        options: {
            indexAxis: 'y',
            responsive: true,
            maintainAspectRatio: false,
            layout: {
                padding: {
                    right: 80
                }
            },
            plugins: {
                datalabels: {
                    anchor: 'end',
                    align: 'right',
                    color: '#000',
                    font: {
                        size: 9
                    },
                    formatter: function (value) {
                        return value.toLocaleString('es-PE', {
                            minimumFractionDigits: 0,
                            maximumFractionDigits: 2
                        }) + ' UND';
                    }

                }
            },
            scales: {
                x: {
                    beginAtZero: true
                }
            }
        },
        plugins: [ChartDataLabels]
    });
}



//function renderChartSucursal(labels, values) {
//    if (charSucursal) charSucursal.destroy();
//    charSucursal = new Chart(document.getElementById("canvasVentasSucursal").getContext("2d"), {
//        type: 'bar',
//        data: {
//            labels: labels,
//            datasets: [{
//                label: 'Ventas Por Sucursal',
//                data: values,
//                backgroundColor: 'rgba(75, 192, 192, 0.6)',   
//                borderColor: 'rgba(75, 192, 192, 1)',        
//                borderWidth: 2
//            }]
//        },
//        options: {
//            responsive: true,
//            maintainAspectRatio: false
//        }
//    });
//}

function renderChartSucursal(labels, values) {
    if (charSucursal) charSucursal.destroy();
    charSucursal = new Chart(document.getElementById("canvasVentasSucursal").getContext("2d"), {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                label: 'Distribucion Ventas',
                data: values,
                backgroundColor: [
                'rgba(54, 162, 235, 0.7)',
                'rgba(255, 99, 132, 0.7)',
                'rgba(255, 206, 86, 0.7)',
                'rgba(75, 192, 192, 0.7)',
                'rgba(153, 102, 255, 0.7)',
                'rgba(255, 159, 64, 0.7)',
                'rgba(255, 99, 71, 0.7)',
                'rgba(0, 128, 128, 0.7)',
                'rgba(128, 0, 128, 0.7)',
                'rgba(255, 215, 0, 0.7)',
                'rgba(0, 191, 255, 0.7)',
                'rgba(220, 20, 60, 0.7)'
            ],
                borderColor: '#fff',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
              datalabels: {
                anchor: 'end',
                align: 'end',
                offset: 0,
                color: '#000',
                  font: {
                  weight: 'bold',
                  size: 10
                },
                formatter: function (value) {
                  return 'S/. ' + value.toLocaleString('es-PE')+ '  ';
                }
              }
            }
 

        },
        plugins: [ChartDataLabels]
    });
}


// 
function renderChartPie(labels, values) {
    if (chartPie) chartPie.destroy();
    chartPie = new Chart(document.getElementById("canvasVentasPie").getContext("2d"), {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                label: 'Distribucion Ventas',
                data: values,
           backgroundColor: [
                'rgba(54, 162, 235, 0.7)',  
                'rgba(255, 99, 132, 0.7)',  
                'rgba(255, 206, 86, 0.7)',  
                'rgba(75, 192, 192, 0.7)',  
                'rgba(153, 102, 255, 0.7)', 
                'rgba(255, 159, 64, 0.7)',  
                'rgba(255, 99, 71, 0.7)',   
                'rgba(0, 128, 128, 0.7)',   
                'rgba(128, 0, 128, 0.7)',   
                'rgba(255, 215, 0, 0.7)',   
                'rgba(0, 191, 255, 0.7)',   
                'rgba(220, 20, 60, 0.7)'    
            ],
                borderColor: '#fff',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false
        }
    });
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