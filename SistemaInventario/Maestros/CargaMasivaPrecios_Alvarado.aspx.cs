using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using EasyCallback;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using SistemaInventario.Clases;

namespace SistemaInventario.Maestros
{
    public partial class CargaMasivaPrecios_Alvarado : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_TipoCambio_NET);
            CallbackManager.Register(F_ValidarUsuario_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_LlenarGridDetalle_NET);
            CallbackManager.Register(F_ExportarDetalle_NET);
            CallbackManager.Register(F_ImportarDocumento_NET);
            CallbackManager.Register(F_ObservacionImportacion_NET);
            CallbackManager.Register(F_AuditoriaImportacion_NET);
        }

        private string _menu = "3000"; private string _opcion = "6";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];          
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            if (!IsPostBack)
            {
                P_Inicializar_GrillaVacia_ConsultaFactura();
            }
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                NotaIngresoSalidaDetCN objOperacion = new NotaIngresoSalidaDetCN();
                NotaIngresoSalidaDetCE objEntidad = new NotaIngresoSalidaDetCE();

                GridView grvDetalle = null;
                GridView grvDObservacion = null;
                GridView grvAuditoria = null;

                HiddenField lblCodigo = null;
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                grvDObservacion = (GridView)(e.Row.FindControl("grvObservacion"));
                grvAuditoria= (GridView)(e.Row.FindControl("grvAuditoria"));
                lblCodigo = (HiddenField)(e.Row.FindControl("hfCodigo"));
                if (lblCodigo.Value.ToString() != "")
                {
                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("ID", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodigoInterno", typeof(string));
                    dta_consultaarticulo.Columns.Add("Producto", typeof(string));
                    dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
                    dta_consultaarticulo.Columns.Add("Costo", typeof(string));
                    dta_consultaarticulo.Columns.Add("P1", typeof(string));
                    dta_consultaarticulo.Columns.Add("Margen", typeof(string));
                    dta_consultaarticulo.Columns.Add("Marca", typeof(string));
                    dta_consultaarticulo.Columns.Add("Pais", typeof(string));
                    dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
                    dta_consultaarticulo.Columns.Add("Medida", typeof(string));
                    dta_consultaarticulo.Columns.Add("Posicion", typeof(string));
                    dta_consultaarticulo.Columns.Add("Familia", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDetalle.DataSource = dta_consultaarticulo;
                    grvDetalle.DataBind();

                    dta_consultaarticulo = null;
                    dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Observacion", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDObservacion.DataSource = dta_consultaarticulo;
                    grvDObservacion.DataBind();

                    dta_consultaarticulo = null;
                    dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Auditoria", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvAuditoria.DataSource = dta_consultaarticulo;
                    grvAuditoria.DataBind();

                }
            }
        }

        protected void grvDetalleArticulo_RowDataBound2(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label Error = (Label)(e.Row.FindControl("lblError"));
                if (Error.Text.Trim() != "")
                {
                    Label lblDescripcion = (Label)(e.Row.FindControl("lblDescripcion"));
                    Label lblCodigoInterno = (Label)(e.Row.FindControl("lblCodigoInterno"));
                    Label lblCantidad = (Label)(e.Row.FindControl("lblCantidad"));
                    Label lblCosto = (Label)(e.Row.FindControl("lblCosto"));
                    Label lblPrecio = (Label)(e.Row.FindControl("lblP1"));

                    if (Error.Text == "NUEVO SIN DESCRIPCION")
                    {
                        if (lblDescripcion.Text.Trim() == "")
                            lblDescripcion.Text = "--REQUIERE DESCRIPCION--";
                        lblDescripcion.BackColor = Color.Orange;
                    }
                    else if (Error.Text == "DUPLICADO EN EL EXCEL")
                    {
                        lblCodigoInterno.Text = lblCodigoInterno.Text +" (REPETIDO)";
                        lblCodigoInterno.BackColor = Color.Orange;
                    }
                
                }
            }
        }
        //INICIALIZA LA GRILLA VACIA
        public void P_Inicializar_GrillaVacia_ConsultaFactura()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();

            dta_consulta.Columns.Add("Codigo", typeof(string));
            dta_consulta.Columns.Add("RazonSocial", typeof(string));
            dta_consulta.Columns.Add("Documento", typeof(string));
            dta_consulta.Columns.Add("Numero", typeof(string));
            dta_consulta.Columns.Add("Emision", typeof(string));
            dta_consulta.Columns.Add("Vcto", typeof(string));
            dta_consulta.Columns.Add("Moneda", typeof(string));
            dta_consulta.Columns.Add("Dscto", typeof(string));
            dta_consulta.Columns.Add("SubTotal", typeof(string));
            dta_consulta.Columns.Add("Igv", typeof(string));
            dta_consulta.Columns.Add("Total", typeof(string));
            dta_consulta.Columns.Add("TipoCambio", typeof(string));
            dta_consulta.Columns.Add("Anexo", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("Condicion", typeof(string));
            dta_consulta.Columns.Add("Periodo", typeof(string));
            dta_consulta.Columns.Add("FechaCancelacion", typeof(string));
            dta_consulta.Columns.Add("Saldo", typeof(string));
            dta_consulta.Columns.Add("FechaDua", typeof(string));
            dta_consulta.Columns.Add("NroDua", typeof(string));
            dta_consulta.Columns.Add("EstadoImportacion", typeof(string));
            dta_consulta.Columns.Add("FechaLlegada", typeof(string));
            dta_consulta.Columns.Add("Gop", typeof(string));
            

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

        public void P_Inicializar_GrillaVacia_DetalleArticulo()
        {
            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            //dta_consultadetalle.Columns.Add("DESCRIPCION_ERROR", typeof(string));
            //dta_consultadetalle.Columns.Add("CodigoInterno", typeof(string));
            //dta_consultadetalle.Columns.Add("CODIGO", typeof(string));
            //dta_consultadetalle.Columns.Add("DESCRIPCION", typeof(string));
            //dta_consultadetalle.Columns.Add("Cantidad", typeof(string));
            //dta_consultadetalle.Columns.Add("UPrice", typeof(string));
            //dta_consultadetalle.Columns.Add("Total", typeof(string));
            //dta_consultadetalle.Columns.Add("Marca", typeof(string));
            //dta_consultadetalle.Columns.Add("Costo", typeof(string));
            //dta_consultadetalle.Columns.Add("P1", typeof(string));
            //dta_consultadetalle.Columns.Add("P2", typeof(string));
            //dta_consultadetalle.Columns.Add("P3", typeof(string));

            //dtr_filadetalle = dta_consultadetalle.NewRow();

            //dta_consultadetalle.Rows.Add(dtr_filadetalle);

            grvDetalleArticulo.DataSource = dta_consultadetalle;
            grvDetalleArticulo.DataBind();
        }
            
        /// <summary>
        /// Nuevo Procedimiento para consultar detalles
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public String F_LlenarGridDetalle_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            int Codigo = 0;
            int CodTipoDoc = 0;

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                //Necesarios para que busque el sistema
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                NotaIngresoSalidaDetCN objOperacion = new NotaIngresoSalidaDetCN();
                NotaIngresoSalidaDetCE objEntidad = new NotaIngresoSalidaDetCE();
                //Obtengo el Grid para llenarlo y dibujarlo
                GridView grvDetalle = (GridView)grvConsulta.Rows[0].FindControl("grvDetalle");

                objEntidad.CodMovimiento = Convert.ToInt32(Codigo);
                grvDetalle.DataSource = objOperacion.F_NotaIngresoSalidaDet_Select_Importaciones(objEntidad);
                grvDetalle.DataBind();

                //se crea el html a partir del grid llenado
                str_grv_Detalle_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalle);

            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }


            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Detalle_html + "~" +
                grvNombre;

            return str_resultado;
        }

        /// <summary>
        /// Nuevo Procedimiento para consultar detalles
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public String F_ExportarDetalle_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            int Codigo = 0;
            int CodTipoDoc = 0;

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);
                ExportarExcelDetalle(Codigo);

            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }


            str_resultado = "";
            return str_resultado;
        }
        
        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serie_html = "";
            String str_ddl_serieguia_html = "";
            String str_ddl_moneda_html = "";
            String str_ddl_formapago_html = "";
            String str_ddl_TipoDocumento_html = "";
            String str_ddl_Clasificacion_html = "";
            String str_ddl_igv_html = "";
            String str_grvDetalleArticulo = "";
            String str_numerofactura = "";
            decimal TC = 0;
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                //P_Controles_Inicializar(obj_parametro);
                P_Obtener_TipoCambio(obj_parametros, ref TC);
                //P_Inicializar_GrillaVacia_DetalleArticulo();


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
                str_ddl_serie_html + "~" +
                str_ddl_serieguia_html + "~" +
                str_ddl_formapago_html + "~" +
                str_ddl_moneda_html + "~" +
                TC.ToString() + "~" +
                str_numerofactura + "~" +
                str_ddl_igv_html + "~" +
                str_ddl_TipoDocumento_html + "~" +
                str_ddl_Clasificacion_html + "~" +
                str_grvDetalleArticulo;

            return str_resultado;
        }

        public String F_TipoCambio_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            Decimal TipoCambio = 0;
            int int_resultado_operacion = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_TipoCambio(obj_parametros, ref TipoCambio);
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;
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
                TipoCambio.ToString();

            return str_resultado;
        }

        public String F_ValidarUsuario_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;
            int CodUsuarioAuxiliar = 0;
            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ValidarUsuario(obj_parametros, ref MsgError, ref CodUsuarioAuxiliar);
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;
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
                CodUsuarioAuxiliar.ToString();

            return str_resultado;
        }
        
        public String F_AnularRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AnularRegistro(obj_parametros, ref str_mensaje_operacion);
                //P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_ConsultaFactura();
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
        public String F_ImportarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;
            String MsgError = "";

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ImportarDocumento(obj_parametros, ref MsgError);

                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;

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
        public String F_ObservacionImportacion_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Observacion_html = "";
            int Col = 0;
            int Codigo = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvDetalleObservacion = (GridView)grvConsulta.Rows[0].FindControl("grvObservacion");

                DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();
                DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();

                objEntidad.CodDocumentoVenta = Codigo;
                grvDetalleObservacion.DataSource = objOperacion.F_NotaIngresoSalidaCab_Observacion(objEntidad);
                grvDetalleObservacion.DataBind();

                str_grv_Observacion_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleObservacion);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Observacion_html + "~" +
                grvNombre;

            return str_resultado;
        }
        public String F_AuditoriaImportacion_NET(String arg) {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Observacion_html = "";
            int Col = 0;
            int Codigo = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvDetalleAuditoria = (GridView)grvConsulta.Rows[0].FindControl("grvAuditoria");

                DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();
                DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();

                objEntidad.CodDocumentoVenta = Codigo;
                grvDetalleAuditoria.DataSource = objOperacion.F_NotaIngresoSalidaCab_Auditoria(objEntidad);
                grvDetalleAuditoria.DataBind();

                str_grv_Observacion_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleAuditoria);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Observacion_html + "~" +
                grvNombre;

            return str_resultado;
        }
        [WebMethod]
        public static DocumentoVentaCabCE F_ModificarObservacion(int CodMovimiento, string Observacion)
        {
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            objEntidad.CodUsuario = Convert.ToInt32(HttpContext.Current.Session["CodUsuario"].ToString());
            objEntidad.Observacion= Observacion;
            objEntidad.CodDocumentoVenta = CodMovimiento;
            
            return objOperacion.F_NotaIngresoSalidaCab_EditarObservacion(objEntidad);
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
                    P_Inicializar_GrillaVacia_ConsultaFactura();
                    str_mensaje_operacion = "No se encontro registros.";
                }
                else
                    str_mensaje_operacion = "";


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
        
        public void P_Controles_Inicializar(Hashtable objTablaFiltro)
        {

            DataTable dta_consulta = null;


        }

        public void P_Obtener_TipoCambio(Hashtable objTablaFiltro, ref Decimal TipoCambio)
        {
            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;
            DataTable dta_consulta = null;

            objEntidad = new TCTipoCambioCE();
            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Fecha"]);
            objOperacion = new TCTipoCambioCN();
            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                TipoCambio = Convert.ToDecimal(dta_consulta.Rows[0]["TC_Venta"]);
        }

        public void P_TipoCambio(Hashtable objTablaFiltro, ref Decimal TC)
        {
            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            objEntidad = new TCTipoCambioCE();
            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Emision"]);

            objOperacion = new TCTipoCambioCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count == 0)
                TC = 0;
            else
                TC = Convert.ToDecimal(dta_consulta.Rows[0][0]);
        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();


            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_Anulacion_NotaIngreso(objEntidad);

            Mensaje = objEntidad.MsgError;

            if (Mensaje.Trim() == "Se anulo correctamente.")
            {
                LGProductosCE objEntidadProductos = new LGProductosCE();
                objEntidadProductos.CodProducto = 0;
                LGProductosCN objOperacionesProductos = new LGProductosCN();
                objOperacionesProductos.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadProductos);

                LGStockAlmacenCN ActualizacionAzure = new LGStockAlmacenCN();
                ActualizacionAzure.Async_F_LGProductos_ActualizarStocks_Lotes_Azure();
            }
        }
        public void P_ImportarDocumento(Hashtable objTablaFiltro, ref String Mensaje) 
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);           
            objEntidad.FechaLlegada = Convert.ToDateTime(objTablaFiltro["Filtro_FechaLlegada"]);                                              
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);       
            
            objOperacion = new DocumentoVentaCabCN();
            objOperacion.F_NotaIngresoSalidaCab_IngresarImportacion(objEntidad);
            Mensaje = objEntidad.MsgError;

            
        }
        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            int iCodEmpresa = 3;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.FlagImportacion = 1;
            objEntidad.CodTipoOperacion = 2;
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDoc = 7;
            objEntidad.CodTipoDocSust = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDocSust"]);
            objEntidad.CodClasificacion = Convert.ToInt32(objTablaFiltro["Filtro_CodClasificacion"]);
            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkNumero"]) == 1)
                objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_Numero"]);
            else
                objEntidad.NumeroDoc = "";

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
                objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            else
                objEntidad.CodCtaCte = 0;

            objOperacion = new NotaIngresoSalidaCabCN();

            dta_consulta = objOperacion.F_NotaIngresoSalidaCab_Select_IMPORTACION(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }
        
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            HiddenField1.Value = "0";
            FileUpload1 = new FileUpload();
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            string Mensaje = "";
            Label1.Text = ""; int CodMovimiento = 0;
            HiddenField1.Value = DateTime.Now.ToString("yyyyMMddHHmmss");
            long IdExcel = long.Parse(HiddenField1.Value.ToString());
            MSG = "";
            dtValidacionesProductos = null;
         

            string MensajeErrorCarga;
            ImportarExcel_EPPLUS(out MensajeErrorCarga);

            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();
            //validacion
            dtValidacionesProductos = objOperacion.F_CargaMasivaExcel_VALIDACIONES_Precios(Convert.ToInt64(HiddenField1.Value));
            if (dtValidacionesProductos.Rows.Count > 0)
            {
             //llenar grillas
                grvDetalleArticulo.DataSource = dtValidacionesProductos;
                grvDetalleArticulo.DataBind();
                return;
            }
            //todo lo demas no me sirve
            if (MensajeErrorCarga == "")
            {
                ProcedimientoTrasladar(ref Mensaje, ref CodMovimiento);
                Label1.Text = Mensaje;

                if (Mensaje.ToUpper() == "SE GRABO CORRECTAMENTE")
                {
                    HiddenField1.Value = "0";
                    FileUpload1 = new FileUpload();
                    //ExportarExcelNuevo(IdExcel, CodMovimiento);

                }
            }

            btnImport.Enabled = true;
            btnNuevo.Enabled = true;
            FileUpload1.Enabled = true;


            btnNuevo_Click(sender, EventArgs.Empty);
            return;
        }

        private void ImportarExcel(out string MensajeError)
        {
            MensajeError = "";
            string ExcelContentType = "application/vnd.ms-excel";
            string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentType == ExcelContentType || FileUpload1.PostedFile.ContentType == Excel2010ContentType)
                {
                    string path;
                    string excelConnectionString;
                    string Cadena;
                    try
                    {
                        path = string.Concat(Server.MapPath("~/Temporales/"), FileUpload1.FileName);
                        FileUpload1.SaveAs(path);

                        excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                        Cadena = string.Format("Select [CodigoInterno],[Descripcion],[Cantidad],[Costo],[P1],[Margen],[Marca],[Pais],[Modelo],[Medida],[Posicion],[Familia]," + HiddenField1.Value + " AS IDPruebasExcelCab,'" + FileUpload1.FileName + "' AS NombreArchivo FROM [{0}] ", "IMPORTACION$");

                        using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
                        {
                            OleDbCommand command = new OleDbCommand(Cadena, connection);

                            connection.Open();

                            using (DbDataReader dr = command.ExecuteReader())
                            {
                                string sqlConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString))
                                {
                                    bulkCopy.DestinationTableName = "ImportacionExcel";
                                    bulkCopy.ColumnMappings.Add("[CodigoInterno]", "CodigoInterno");
                                    bulkCopy.ColumnMappings.Add("[Descripcion]", "Descripcion");
                                    bulkCopy.ColumnMappings.Add("[Cantidad]", "Cantidad");
                                    bulkCopy.ColumnMappings.Add("[Costo]", "Costo");
                                    bulkCopy.ColumnMappings.Add("[P1]", "P1");
                                    bulkCopy.ColumnMappings.Add("[Margen]", "Margen");
                                    bulkCopy.ColumnMappings.Add("[Marca]", "Marca");
                                    bulkCopy.ColumnMappings.Add("[Pais]", "Pais");
                                    bulkCopy.ColumnMappings.Add("[Modelo]", "Modelo");
                                    bulkCopy.ColumnMappings.Add("[Medida]", "Medida");
                                    bulkCopy.ColumnMappings.Add("[Posicion]", "Posicion");
                                    bulkCopy.ColumnMappings.Add("[Familia]", "Familia");
                                    bulkCopy.ColumnMappings.Add("[IDPruebasExcelCab]", "IDPruebasExcelCab");
                                    bulkCopy.ColumnMappings.Add("[NombreArchivo]", "NombreArchivo");
                                    bulkCopy.WriteToServer(dr);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            MensajeError = "Error en la lectura del excel. <p></p> " +
                                            "Descripción: " + ex.Message.ToString() + " <p></p>  <p></p> " +
                                            " debe tener cuenta que el documento debe tener las siguientes especificaciones:  <p></p> " +
                                            " <b>Hoja: IMPORTACION</b>" +
                                            " Columnas: <p></p>" +
                                            " <b>[A]=CodigoInterno, [B]=Descripcion, [C]=Cantidad, [D]=Costo, [E]=P1, [H]=Margen</b>, [I]=Marca</b>, [J]=Pais</b>, [K]=Modelo</b>, [L]=Medida</b>, [M]=Posicion</b>";
                            Label1.Text = MensajeError;
                        }
                        catch (Exception exx)
                        { }
                    }
                }
            }
        }

        private void ImportarExcel_EPPLUS(out string MensajeError)
        {
            MensajeError = "";
            string path;

            if (FileUpload1.HasFile)
            {
                path = Path.Combine(Server.MapPath("~/Temporales/"), FileUpload1.FileName);
                FileUpload1.SaveAs(path);

                try
                {
                    FileInfo fileInfo = new FileInfo(path);

                    using (var package = new ExcelPackage(fileInfo))
                    {
                        var worksheet = package.Workbook.Worksheets["IMPORTACION"]; // El índice Inventario representa la primera hoja del archivo Excel

                        string sqlConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                        {
                            connection.Open();

                            for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                            {
                                // Obtener los valores de las celdas
                                string CODIGO = worksheet.Cells[row, 1].Text;
                                string P1 = worksheet.Cells[row, 2].Text;
                                string P2 = worksheet.Cells[row, 3].Text;
                                string MAYORISTA = worksheet.Cells[row, 4].Text;
                                string EXCLUSIVO = worksheet.Cells[row, 5].Text;

                                // Realizar la inserción en la base de datos
                                string insertQuery = "INSERT CargaMasivaPreciosExcel(CODIGO,P1,P2,MAYORISTA,EXCLUSIVO,IDCargaMasivaExcelCab,NombreArchivo) " +
                                                     "VALUES (@CODIGO,@P1,@P2,@MAYORISTA,@EXCLUSIVO,@IDPruebasExcelCab,@NombreArchivo)";

                                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                                {
                                    cmd.Parameters.AddWithValue("@CODIGO", CODIGO);
                                    cmd.Parameters.AddWithValue("@P1", P1);
                                    cmd.Parameters.AddWithValue("@P2", P2);
                                    cmd.Parameters.AddWithValue("@MAYORISTA", MAYORISTA);
                                    cmd.Parameters.AddWithValue("@EXCLUSIVO", EXCLUSIVO);
                                    cmd.Parameters.AddWithValue("@IDPruebasExcelCab", HiddenField1.Value);
                                    cmd.Parameters.AddWithValue("@NombreArchivo", FileUpload1.FileName);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MensajeError = "Error en la lectura del excel. <p></p> " +
                                            "Descripción: " + ex.Message.ToString() + " <p></p>  <p></p> ";
                    Label1.Text = MensajeError;
                    Label1.BackColor = Color.Black;
                    Label1.BackColor = Color.Orange;

                    btnImport.Enabled = false;
                    FileUpload1.Enabled = false;
                }
            }
        }


        protected string MSG;
        protected DataTable dtValidacionesProductos;
        

        private void ProcedimientoTrasladar(ref string Mensaje, ref int CodMovimiento)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();


            objEntidad.IDPruebasExcelCab = Convert.ToInt64(HiddenField1.Value);
            objEntidad.CodEmpresa = 3; 
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodClasificacion = 2;            
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_CargaMAsivaExcel_ACTUALIZARPrecios(objEntidad);

            Mensaje = objEntidad.MsgError;
            CodMovimiento = objEntidad.CodDocumentoVenta;
        }

        protected void ExportarExcelNuevo(long IdExcel, int CodMovimiento)
        {
            DocumentoVentaCabCN objOperacion = null;
            objOperacion = new DocumentoVentaCabCN();
            //DataTable ds = objOperacion.F_ListaPreciosExcel_Exportacion(IdExcel, CodMovimiento);

            //if (ds.Rows.Count > 0)
            //{
            //    FileInfo newFile = new FileInfo(Server.MapPath("Xls_Importaciones.xlsx"));

            //    ExcelPackage pck = new ExcelPackage(newFile);
            //    var ws = pck.Workbook.Worksheets["IMPORTACION"];
                                                  
            //    for (int i = 2; i < 5000; i++)
            //        ws.DeleteRow(2);

            //    ws.Cells["A2"].LoadFromDataTable(ds, true);
            //    ws.DeleteRow(2);

            //    for (int i = 2; i < ds.Rows.Count + 2; i++)
            //    {
            //        try
            //        {
            //            var Valor = ws.Cells["J" + i.ToString()].Value.ToString();
            //            if (Valor != "")
            //            {
            //                if (Valor == "1")
            //                {
            //                    ws.Cells["A" + i.ToString() + ":I" + i.ToString()].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //                    ws.Cells["A" + i.ToString() + ":I" + i.ToString()].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
            //                }
            //            }
            //        }
            //        catch (Exception exxxx)
            //        { }
            //    }

            //    ws.DeleteColumn(10); //elimino la columna M que no va...

            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.Charset = "";
            //    Response.ContentType = "application/octet-stream";
            //    Response.AppendHeader("Content-Disposition", "attachment; filename=Xls_Importaciones.xlsx");
 
            //    using (MemoryStream MyMemoryStream = new MemoryStream())
            //    {
            //        pck.SaveAs(MyMemoryStream);
            //        MyMemoryStream.WriteTo(Response.OutputStream);
            //        Response.Flush();
            //        Response.End();
            //    }
            //}
        }

        protected void ExportarExcelDetalle(int CodMovimiento)
        {
            NotaIngresoSalidaDetCN objOperacion = new NotaIngresoSalidaDetCN();
            NotaIngresoSalidaDetCE objEntidad = new NotaIngresoSalidaDetCE();
            objEntidad.CodMovimiento = CodMovimiento;
            DataTable ds = objOperacion.F_NotaIngresoSalidaDet_Select_Importaciones(objEntidad);

            if (ds.Rows.Count > 0)
            {
                FileInfo newFile = new FileInfo(Server.MapPath("Importaciones.xlsx"));

                ExcelPackage pck = new ExcelPackage(newFile);
                var ws = pck.Workbook.Worksheets["IMPORTACION"];

                for (int i = 2; i < 50000; i++)
                    ws.DeleteRow(2);

                ws.Cells["A2"].LoadFromDataTable(ds, true);
                ws.DeleteRow(2);

                //for (int i = 2; i < ds.Rows.Count + 2; i++)
                //{
                //    try
                //    {
                //        var Valor = ws.Cells["H" + i.ToString()].Value.ToString();
                //        if (Valor != "")
                //        {
                //            if (Valor == "1")
                //            {
                //                ws.Cells["A" + i.ToString() + ":G" + i.ToString()].Style.Fill.PatternType = ExcelFillStyle.Solid;
                //                ws.Cells["A" + i.ToString() + ":G" + i.ToString()].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                //            }
                //        }
                //    }
                //    catch (Exception exxxx)
                //    { }
                //}

                ws.DeleteColumn(8); //elimino la columna M que no va...

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Importaciones.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    pck.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        
        public void P_ValidarUsuario(Hashtable objTablaFiltro, ref String MsgError, ref Int32 CodUsuarioAuxiliar)
        {
            UsuarioCE objEntidad = null;
            UsuarioCN objOperacion = null;

            objEntidad = new UsuarioCE();

            objEntidad.NombreUsuario = Convert.ToString(objTablaFiltro["Filtro_Usuario"]);
            objEntidad.Clave = Convert.ToString(objTablaFiltro["Filtro_NvClave"]);
            objEntidad.Pagina = Convert.ToString(objTablaFiltro["Filtro_Pagina"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new UsuarioCN();
            objOperacion.F_Usuario_Login_Modulo(objEntidad);
            MsgError = objEntidad.Mensaje;
            CodUsuarioAuxiliar = objEntidad.CodUsuarioAuxiliar;
        }
    }
}
