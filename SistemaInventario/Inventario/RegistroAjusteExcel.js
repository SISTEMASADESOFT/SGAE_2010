var AppSession = "../Inventario/RegistroAjusteExcel.aspx";

var CodigoMenu = 2000;
var CodigoInterno = 3;


$(document).ready(function () {
	$('#MainContent_btnImport').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
       if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
	   //return false;
    });
	
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

