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
namespace SistemaInventario.Reportes
{
    public partial class Vencimiento_RegistroVentas : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_NET);
        }

        private string _menu = "10000"; private string _opcion = "400001";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            Session["datos"] = true;
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlEmpresa_html = "";
            String str_ddlRuta_html = "";
            String str_ddlVendedor_html = "";
            String str_ddl_moneda_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlVendedor, ref ddlMoneda);

                str_ddlVendedor_html = Mod_Utilitario.F_GetHtmlForControl(ddlVendedor);
                str_ddl_moneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_ddlEmpresa_html + "~" +
                str_ddlRuta_html + "~" +
                str_ddlVendedor_html + "~" +
                str_ddl_moneda_html;

            return str_resultado;
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_empleado, ref DropDownList ddl_combomoneda)        
        {
            DataTable dta_consulta = null;
            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();

            objEntidadConceptosDet.CodConcepto = 4;

            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_combomoneda.Items.Clear();

            ddl_combomoneda.DataSource = dta_consulta;
            ddl_combomoneda.DataTextField = "DscAbvConcepto";
            ddl_combomoneda.DataValueField = "CodConcepto";
            ddl_combomoneda.DataBind();



            EmpleadoCE objEmpleado = new EmpleadoCE();

            objEmpleado.CodCargo = Convert.ToInt32(objTablaFiltro["Filtro_CodCargo"]);
            objEmpleado.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            dta_consulta = (new EmpleadoCN()).F_Empleado_Listar(objEmpleado);
            ddl_empleado.Items.Clear();

            ddl_empleado.DataSource = dta_consulta;
            ddl_empleado.DataTextField = "NombreCompleto";
            ddl_empleado.DataValueField = "CodEmpleado";
            ddl_empleado.DataBind();

            ddl_empleado.Items.Insert(0, new ListItem() { Text = "--TODOS--", Value = "0" });
        }


        public String F_Buscar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar(obj_parametros, ref grvConsultaArticulo);
                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
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
                str_grvConsulta_html;


            return str_resultado;

        }


        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new DocumentoVentaCabCE();


            objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodVendedor = Convert.ToInt32(objTablaFiltro["Filtro_CodVendedor"]);

            dynamic jArr2;

            //filtros de combos multiples
            objEntidad.XmlDetalle = "";
            jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_Cliente"].ToString());
            foreach (dynamic item in jArr2)
            {
                objEntidad.XmlDetalle = objEntidad.XmlDetalle + "<D ";
                objEntidad.XmlDetalle = objEntidad.XmlDetalle + " CodCtaCte = '" + item.CodCtaCte + "'";
                objEntidad.XmlDetalle = objEntidad.XmlDetalle + " />";
            }
            objEntidad.XmlDetalle = "<R><XmlLC> " + objEntidad.XmlDetalle + "</XmlLC></R>";

            objOperacion = new DocumentoVentaCabCN();

            dta_consulta = objOperacion.F_Cobranzas_Reporte_Vencimiento(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }
    }
}