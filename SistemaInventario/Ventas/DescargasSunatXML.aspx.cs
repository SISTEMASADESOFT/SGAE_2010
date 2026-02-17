using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using CapaNegocios;
using CapaEntidad;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;
using System.Web.Services;
using System.Net;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Linq;

namespace SistemaInventario.Ventas
{
    public partial class DescargasSunatXML : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_NET);
        }

        private string _menu = "4000"; private string _opcion = "10";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"];
            String Opcion = Request.QueryString["Op"];

            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_Consulta();
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEstadoSunat = (Label)(e.Row.FindControl("lblEstadoSunat"));
                HiddenField hfEstadoSunat = (HiddenField)(e.Row.FindControl("hfEstadoSunat"));
                ImageButton DownloadCDR = (ImageButton)(e.Row.FindControl("imgDownloadFT"));


                switch (hfEstadoSunat.Value)
                {
                    case "APROBADO":
                        lblEstadoSunat.ForeColor = System.Drawing.Color.Green;
                        DownloadCDR.Visible = true;
                        DownloadCDR.Enabled = true;
                        break;
                    default:
                        lblEstadoSunat.ForeColor = System.Drawing.Color.Gray;
                        DownloadCDR.Visible = false;
                        DownloadCDR.Enabled = false;
                        break;
                }
            }
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            Int32 Usuario = 0;
            decimal TC = 0;
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;
            String str_ddlSerieConsulta_html = "";
            String str_ddlEstado_html = "";
            String str_ddlEmpleadoConsulta_html = "";
            String str_ddlTipoDocConsulta_html = "";

            try
            {
                Usuario = Convert.ToInt32(Session["CodUsuario"]);

                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlSerieConsulta, ref ddlTipoDocConsulta, ref ddlEmpleadoConsulta, ref ddlEstado);

                str_ddlSerieConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);    
                str_ddlEstado_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstado);      
                str_ddlEmpleadoConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpleadoConsulta);
                str_ddlTipoDocConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDocConsulta);
                            
                int_resultado_operacion = 1;
                str_mensaje_operacion = "";
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" + //0
                str_mensaje_operacion + "~" + //1
                Usuario.ToString() + "~" + //2
                Session["CodSede"].ToString() + "~" + //3
                Session["CodEmpleado"].ToString() + "~" + //4
                Session["IdAlmacen"].ToString() + "~" +  //5
                str_ddlSerieConsulta_html + "~" + //6
                str_ddlEstado_html + "~" + //7
                str_ddlEmpleadoConsulta_html + "~" + //8
                str_ddlTipoDocConsulta_html ; //9

            return str_resultado;
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
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Consulta();
                    str_mensaje_operacion = "No se encontraron registros";
                }
                else
                {
                    str_mensaje_operacion = "";
                }

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
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
                str_mensaje_operacion
                + "~" +
                str_grvConsulta_html;


            return str_resultado;

        }

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();

            dta_consulta.Columns.Add("CodDocumentoVenta", typeof(string));
            dta_consulta.Columns.Add("EMPRESA", typeof(string));
            dta_consulta.Columns.Add("TD", typeof(string));
            dta_consulta.Columns.Add("Numero", typeof(string));
            dta_consulta.Columns.Add("Cliente", typeof(string));
            dta_consulta.Columns.Add("Emision", typeof(string));
            dta_consulta.Columns.Add("Vencimiento", typeof(string));
            dta_consulta.Columns.Add("Moneda", typeof(string));
            dta_consulta.Columns.Add("TC", typeof(string));
            dta_consulta.Columns.Add("Total", typeof(string));
            dta_consulta.Columns.Add("Condicion", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("Deuda", typeof(string));
            dta_consulta.Columns.Add("Saldo", typeof(string));
            dta_consulta.Columns.Add("CodCtaCte", typeof(string));
            dta_consulta.Columns.Add("Usuario", typeof(string));
            dta_consulta.Columns.Add("CodArchivoSunatXML", typeof(string));
            dta_consulta.Columns.Add("EstadoSunat", typeof(string));
            dta_consulta.Columns.Add("Año", typeof(string));
            dta_consulta.Columns.Add("CodTraslado_GuiaRemision", typeof(string));
            dta_consulta.Columns.Add("Numero_GuiaRemision", typeof(string));
            dta_consulta.Columns.Add("CodArchivoSunatXMLTraslado_GuiaRemision", typeof(string));
            dta_consulta.Columns.Add("EstadoTraslado_GuiaRemision", typeof(string));

            dtr_filaconsulta = dta_consulta.NewRow();

            dtr_filaconsulta[0] = "";
            dtr_filaconsulta[1] = "";
            dtr_filaconsulta[2] = "";
            dtr_filaconsulta[3] = "";
            dtr_filaconsulta[4] = "";
            dtr_filaconsulta[5] = "";
            dtr_filaconsulta[6] = "";
            dtr_filaconsulta[7] = "";
            dtr_filaconsulta[8] = "";
            dtr_filaconsulta[9] = "";
            dtr_filaconsulta[10] = "";
            dtr_filaconsulta[11] = "";
            dtr_filaconsulta[12] = "";
            dtr_filaconsulta[13] = "";
            dtr_filaconsulta[14] = "";
            dtr_filaconsulta[15] = "";
            dtr_filaconsulta[16] = "";
            dtr_filaconsulta[17] = "";
            dtr_filaconsulta[18] = "";
            dtr_filaconsulta[19] = "";
            dtr_filaconsulta[20] = "";
            dtr_filaconsulta[21] = "";
            dtr_filaconsulta[22] = "";

            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta.DataSource = dta_consulta;
            grvConsulta.DataBind();
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkFecha"]) == 1)
            {
                objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
                objEntidad.Hasta = Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]);
            }
            else
            {
                objEntidad.Desde = Convert.ToDateTime("01/01/1990");
                objEntidad.Hasta = Convert.ToDateTime("01/01/1990");
            }

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkCliente"]) == 1)
                objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            else
                objEntidad.CodCliente = 0;

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkNumero"]) == 1)
                objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);
            else
                objEntidad.NumeroDoc = "";

            objEntidad.CodEmpleado = Convert.ToInt32(objTablaFiltro["Filtro_CodEmpleado"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);

            objOperacion = new DocumentoVentaCabCN();

            dta_consulta = objOperacion.F_DocumentoVentaCab_Listar_DescargarXML(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        private string GetIP()
        {
            string visitorIPAddress = "";
            string IPHost = Dns.GetHostName();
            string IP = Dns.GetHostByName(IPHost).AddressList[0].ToString();
            return IP;
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_comboSerieConsulta,ref DropDownList ddl_comboTipoDocConsulta,ref DropDownList ddl_comboEmpleadoConsulta, ref DropDownList ddl_EstadoConsulta)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodEstado = 0;

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select_Factura_Boleta(objEntidad);

            ddl_comboSerieConsulta.Items.Clear();
            
            ddl_comboSerieConsulta.DataSource = dta_consulta;
            ddl_comboSerieConsulta.DataTextField = "SerieDoc";
            ddl_comboSerieConsulta.DataValueField = "CodSerie";
            ddl_comboSerieConsulta.DataBind();
            
            TCDocumentosCN objOperacionTCDocumentos = new TCDocumentosCN();
            TCDocumentosCE objEntidadTCDocumentos = new TCDocumentosCE();
            dta_consulta = objOperacionTCDocumentos.F_TCDocumentos_ListarFacturacion();

            ddl_comboTipoDocConsulta.Items.Clear();
            ddl_comboTipoDocConsulta.DataSource = dta_consulta;
            ddl_comboTipoDocConsulta.DataTextField = "Descripcion";
            ddl_comboTipoDocConsulta.DataValueField = "CodTipoDoc";
            ddl_comboTipoDocConsulta.DataBind();

            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();

            dta_consulta = null;
            objEntidadConceptosDet.Flag = 1;
            dta_consulta = objOperacionConceptosDet.F_TCConceptosDet_ListarEstadoFactura(objEntidadConceptosDet);

            ddl_EstadoConsulta.Items.Clear();
            
            ddl_EstadoConsulta.DataSource = dta_consulta;
            ddl_EstadoConsulta.DataTextField = "Descripcion";
            ddl_EstadoConsulta.DataValueField = "Codigo";
            ddl_EstadoConsulta.DataBind();
            ddl_EstadoConsulta.Items.Insert(0, new ListItem("TODOS", "0"));

            //VENDEDORES
            EmpleadoCE objEmpleado = new EmpleadoCE();

            objEmpleado.CodCargo = Convert.ToInt32(objTablaFiltro["Filtro_CodCargo"]);
            objEmpleado.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            dta_consulta = (new EmpleadoCN()).F_Empleado_Listar(objEmpleado);
          
            ddl_comboEmpleadoConsulta.Items.Clear();

            ddl_comboEmpleadoConsulta.DataSource = dta_consulta;
            ddl_comboEmpleadoConsulta.DataTextField = "NombreCompleto";
            ddl_comboEmpleadoConsulta.DataValueField = "CodEmpleado";
            ddl_comboEmpleadoConsulta.DataBind();
            ddl_comboEmpleadoConsulta.Items.Insert(0, new ListItem("TODOS", "0"));
        }
    }
}
