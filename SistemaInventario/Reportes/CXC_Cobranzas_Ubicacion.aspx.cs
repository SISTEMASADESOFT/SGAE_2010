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
    public partial class CXC_Cobranzas_Ubicacion : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
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
            String str_ddlDepartamento_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;
            String str_ddlSucursales_html = "";

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlVendedor, ref ddlMoneda, ref ddlDepartamento, ref ddlSucursales);

                str_ddlVendedor_html = Mod_Utilitario.F_GetHtmlForControl(ddlVendedor);
                str_ddl_moneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);
                str_ddlDepartamento_html = Mod_Utilitario.F_GetHtmlForControl(ddlDepartamento);
                str_ddlSucursales_html = Mod_Utilitario.F_GetHtmlForControl(ddlSucursales);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +//0
                str_mensaje_operacion + "~" +//1
                str_ddlEmpresa_html + "~" +//2
                str_ddlRuta_html + "~" +//3
                str_ddlVendedor_html + "~" +//4
                str_ddl_moneda_html + "~" +//5
                str_ddlDepartamento_html + "~" +//6
                str_ddlSucursales_html;//7

            return str_resultado;
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_empleado, ref DropDownList ddl_combomoneda, ref DropDownList ddl_combodepartamento
            , ref DropDownList ddl_ComboSucursales)        
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

            dta_consulta = (new EmpleadoCN()).F_TCDEPARTAMENTO_LISTAR();
            ddl_combodepartamento.Items.Clear();

            ddl_combodepartamento.DataSource = dta_consulta;
            ddl_combodepartamento.DataTextField = "DscDepartamento";
            ddl_combodepartamento.DataValueField = "CodDepartamento";
            ddl_combodepartamento.DataBind();
            
            ddl_combodepartamento.Items.Insert(0, new ListItem() { Text = "--TODOS--", Value = "0" });

            TCAlmacenCN objOperacionAlmacen = new TCAlmacenCN();
            TCAlmacenCE objEntidadAlmacen = new TCAlmacenCE();

            objEntidadAlmacen.CodEstado = 1;

            dta_consulta = null;
            dta_consulta = (new TCAlmacenCN()).F_TCALMACEN_LISTAR_TODOS(objEntidadAlmacen);

            ddl_ComboSucursales.Items.Clear();
            ddl_ComboSucursales.DataSource = dta_consulta;
            ddl_ComboSucursales.DataTextField = "DscAlmacen";
            ddl_ComboSucursales.DataValueField = "CodAlmacen";
            ddl_ComboSucursales.DataBind();

            if (Session["CodSede"] != null)
            {
                ddl_ComboSucursales.SelectedValue = Session["CodSede"].ToString();
            }
        }

    }
}