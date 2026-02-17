using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Collections;
using System.Configuration;

using CapaNegocios;
using CapaEntidad;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;
using System.Web.Services;

namespace SistemaInventario.Maestros
{
    public partial class CierreModulo : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
        }

        private string _menu = "2000"; private string _opcion = "3";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            Session["datos"] = true;
        }

        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
          

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref str_mensaje_operacion);

                int_resultado_operacion = 1;

            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion;


            return str_resultado;

        }
                 
        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError)
        {

            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();
  
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            objEntidad.FechaOperacion = Convert.ToDateTime(objTablaFiltro["Filtro_Periodo"]);
            objEntidad.CodModulo = Convert.ToInt32(objTablaFiltro["Filtro_Modulo"]);
            objOperacion = new NotaIngresoSalidaCabCN();

            //objOperacion.F_Movimientos_CierreMensual(objEntidad);
            objOperacion.F_Movimientos_Modulo(objEntidad);
            
            MsgError = objEntidad.MsgError;
         
        }


        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
 
            String str_ddl_modulos_html = "";
            int PMayorista = 0;
            decimal TC = 0;
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlModulos);
   

                
                str_ddl_modulos_html = Mod_Utilitario.F_GetHtmlForControl(ddlModulos);
 

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_ddl_modulos_html;


            return str_resultado;

        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combomodulos
                                             )
        {

            DataTable dta_consulta = null;

            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();

            objEntidadConceptosDet.CodConcepto = 36;

            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_combomodulos.Items.Clear();

            ddl_combomodulos.DataSource = dta_consulta;
            ddl_combomodulos.DataTextField = "DscAbvConcepto";
            ddl_combomodulos.DataValueField = "CodConcepto";
            ddl_combomodulos.DataBind();

            
             

        }

    }
}