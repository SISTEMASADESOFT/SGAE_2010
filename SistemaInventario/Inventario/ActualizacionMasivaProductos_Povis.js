var AppSession = "../Inventario/ActualizacionMasivaProductos_Povis.aspx";

var CodigoMenu = 2000;
var CodigoInterno = 10;

$(document).ready(function () {
    $('#divTabs').tabs();
});

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

