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
using System.Web.Services;
using CapaNegocios;
using CapaEntidad;
//using System.Web.Helpers;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;

namespace SistemaInventario.Maestros
{
    public partial class CuentasBancarias : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_EliminarRegistro_Net);
            CallbackManager.Register(F_EdicionRegistro_NET);
            CallbackManager.Register(F_EdicionRegistroBanco_NET);
            CallbackManager.Register(F_RegistrarBanco_NET);
            CallbackManager.Register(F_ObtenerDatosBanco_NET);
        }

        private string _menu = "1000"; private string _opcion = "7";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_Consulta();
            Session["datos"] = true;
        }

        //-------------popup
    

        //-----------------

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlEstado_html = "";
            String str_ddlEstadoEdicion_html = "";
            int int_resultado_operacion = 0;
            String str_ddlCuentasBancarias_html = "";
            String str_ddlEmpresaEdicion_html = "";
            String str_ddlEmpresaConsulta_html = "";
            String str_ddlMoneda_html = "";
            String str_ddlEstadoBanco_html = "";
            String str_ddlBancoEdicion_html = "";
            String str_ddlMonedaEdicion_html = "";
            String str_ddlEstadoEdicion2_html = "";
            Hashtable obj_parametros = null;


            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros,ref ddlMoneda, ref ddlEstado, ref ddlEstadoEdicion
                    , ref ddlCuentasBancarias, ref ddlEmpresaEdicion, ref ddlEmpresaConsulta, ref ddlEstadoBanco, ref ddlBancoEdicion, ref ddlMonedaEdicion, ref ddlEstadoEdicion2);

                str_ddlMoneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);
                str_ddlEstado_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstado);
                str_ddlEstadoEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoEdicion);

                str_ddlCuentasBancarias_html = Mod_Utilitario.F_GetHtmlForControl(ddlCuentasBancarias);
                str_ddlEmpresaEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpresaEdicion);
                str_ddlEmpresaConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpresaConsulta);
                str_ddlEstadoBanco_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoBanco);
                str_ddlBancoEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlBancoEdicion);
                str_ddlMonedaEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlMonedaEdicion);
                str_ddlEstadoEdicion2_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoEdicion2);

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
           str_ddlEstado_html + "~" + //2
           str_ddlEstadoEdicion_html + "~" + //3
            str_ddlCuentasBancarias_html + "~" + //4
            str_ddlEmpresaEdicion_html + "~" + //5
            str_ddlEmpresaConsulta_html + "~" + //6
            str_ddlMoneda_html + "~" +//
            str_ddlEstadoBanco_html + "~" +
            str_ddlBancoEdicion_html + "~" +
            str_ddlMonedaEdicion_html + "~" +
            str_ddlEstadoEdicion2_html; //
            

            return str_resultado;
        }

        public string F_RegistrarBanco_NET(string arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarBanco(obj_parametros, ref str_mensaje_operacion);
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

        public void P_BuscarDireccionTemporal(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {

            TCDistritoCE objEntidad = null;
            TCDistritoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCDistritoCE();

            objEntidad.Temporal = Convert.ToInt32(objTablaFiltro["Filtro_CodTemporal"]);
            objEntidad.FlagTraslado = Convert.ToInt32(objTablaFiltro["Filtro_FlagTraslado"]);

            objOperacion = new TCDistritoCN();

            dta_consulta = objOperacion.F_TCDireccion_ListarXDireccionTemporal(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }

        //    ------------------------------
       /* public string F_ObtenerDatosBanco_NET(string arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                F_ObtenerBancoPorCodigo(obj_parametros, ref str_mensaje_operacion);
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
        */

       public string F_ObtenerDatosBanco_NET(string arg)
            {
                String str_resultado = "";
                String str_mensaje_operacion = "";
                int int_resultado_operacion = 0;

                Hashtable obj_parametros = null;
                TCCuentaCorrienteCE detallesBanco = new TCCuentaCorrienteCE();

                try
                {
                   
                    obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                   
                    if (obj_parametros == null || !obj_parametros.ContainsKey("Filtro_CodBanco"))
                    {
                        str_mensaje_operacion = "El parámetro 'Filtro_CodBanco' es obligatorio.";
                        int_resultado_operacion = 0;
                    }
                    else
                    {
                        F_ObtenerBancoPorCodigo(obj_parametros, ref detallesBanco, ref str_mensaje_operacion);

                       
                        if (string.IsNullOrEmpty(str_mensaje_operacion))
                        {
                            int_resultado_operacion = 1; // Éxito
                        }
                        else
                        {
                            int_resultado_operacion = 0; // Error
                        }
                    }
                }
                catch (Exception ex)
                {
                   
                    str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                    int_resultado_operacion = 0;
                }

              
                str_resultado =
                    Convert.ToString(int_resultado_operacion) + "~" +
                    str_mensaje_operacion + "~" +
                    (detallesBanco != null ? JsonConvert.SerializeObject(new
                    {
                        DscBanco = detallesBanco.Descripcion,
                        DescripcionCorta = detallesBanco.DescripcionCorta,
                        Orden = detallesBanco.Orden,
                        CodEstado = detallesBanco.CodEstado
                    }) : "{}");

                return str_resultado;
            }


       public void P_Inicializar_GrillaVacia_Banco()
       {
           DataTable dta_consultaarticulo = null;
           DataRow dtr_consultafila = null;

           dta_consultaarticulo = new DataTable();

           dta_consultaarticulo.Columns.Add("banco", typeof(string));
           dta_consultaarticulo.Columns.Add("moneda", typeof(string));
           dta_consultaarticulo.Columns.Add("Cci", typeof(string));
           dta_consultaarticulo.Columns.Add("NumeroCuenta", typeof(string));
           dta_consultaarticulo.Columns.Add("estado", typeof(string));
 
           dtr_consultafila = dta_consultaarticulo.NewRow();

           dtr_consultafila["banco"] = "";
           dtr_consultafila["moneda"] = "";
           dtr_consultafila["Cci"] = "";
           dtr_consultafila["NumeroCuenta"] = "";
           dtr_consultafila["estado"] = "";

           dta_consultaarticulo.Rows.Add(dtr_consultafila);

           grvConsulta.DataSource = dta_consultaarticulo;
           grvConsulta.DataBind();
       }

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvFactura_html = "";
            String str_grvLetra_html = "";
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                //str_grvFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);
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
                str_grvLetra_html
                + "~" +
                str_grvFactura_html;


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
                    str_mensaje_operacion = "No se encontraron registros.";
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

     /*   public String F_EliminarRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarRegistro(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Consulta();

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
        */
        public String F_EliminarRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarRegistro(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Consulta();

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

        public String F_EdicionRegistro_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EditarRegistro(obj_parametros, ref MsgError);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Consulta();
                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
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
                str_grvConsulta_html;


            return str_resultado;

        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro,ref DropDownList ddl_combomoneda  , ref DropDownList ddl_comboestado, ref DropDownList ddl_comboestadoedicion,
                ref DropDownList ddl_CuentasBancarias, ref DropDownList ddl_comboempresaedicion, ref DropDownList ddl_comboempresaconsulta, ref DropDownList  ddl_comboEstadoBanco, ref DropDownList ddl_comoBancoEdicion, ref DropDownList ddl_ComboMonedaEdicion, ref DropDownList ddl_EstadoEdicion2)
        {
            DataTable dta_consulta = null;
            
            //TCCorrelativoCN objOperacion = null;

            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();

            ddl_comboestado.Items.Clear();

                                           //--- 27
            objEntidadConceptosDet.CodConcepto = 27;
            objEntidadConceptosDet.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objEntidadConceptosDet.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_comboestado.Items.Clear();

            ddl_comboestado.DataSource = dta_consulta;
            ddl_comboestado.DataTextField = "DscAbvConcepto";
            ddl_comboestado.DataValueField = "CodConcepto";
            ddl_comboestado.DataBind();

            //---------estadobanco
            ddl_comboEstadoBanco.Items.Clear();

            ddl_comboEstadoBanco.DataSource = dta_consulta;
            ddl_comboEstadoBanco.DataTextField = "DscAbvConcepto";
            ddl_comboEstadoBanco.DataValueField = "CodConcepto";
            ddl_comboEstadoBanco.DataBind();

            //---
            ddl_comboestadoedicion.Items.Clear();

            ddl_comboestadoedicion.DataSource = dta_consulta;
            ddl_comboestadoedicion.DataTextField = "DscAbvConcepto";
            ddl_comboestadoedicion.DataValueField = "CodConcepto";
            ddl_comboestadoedicion.DataBind();

            ddl_EstadoEdicion2.Items.Clear();

            ddl_EstadoEdicion2.DataSource = dta_consulta;
            ddl_EstadoEdicion2.DataTextField = "DscAbvConcepto";
            ddl_EstadoEdicion2.DataValueField = "CodConcepto";
            ddl_EstadoEdicion2.DataBind();

            //---------abajo combo moneda

            objEntidadConceptosDet.CodConcepto = 4;
            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_combomoneda.Items.Clear();

            ddl_combomoneda.DataSource = dta_consulta;
            ddl_combomoneda.DataTextField = "DscAbvConcepto";
            ddl_combomoneda.DataValueField = "CodConcepto";
            ddl_combomoneda.DataBind();


            objEntidadConceptosDet.CodConcepto = 4;
            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_ComboMonedaEdicion.Items.Clear();

            ddl_ComboMonedaEdicion.DataSource = dta_consulta;
            ddl_ComboMonedaEdicion.DataTextField = "DscAbvConcepto";
            ddl_ComboMonedaEdicion.DataValueField = "CodConcepto";
            ddl_ComboMonedaEdicion.DataBind();
            
//------------- abajo combo banco 
            BancosCN objOperacionBancos = new BancosCN();

            dta_consulta = null;

            dta_consulta = objOperacionBancos.F_Listar_Bancos();

            ddl_CuentasBancarias.Items.Clear();

            ddl_CuentasBancarias.DataSource = dta_consulta;
            ddl_CuentasBancarias.DataTextField = "DscBanco";
            ddl_CuentasBancarias.DataValueField = "CodBanco";
            ddl_CuentasBancarias.DataBind();


            ddl_comoBancoEdicion.Items.Clear();

            ddl_comoBancoEdicion.DataSource = dta_consulta;
            ddl_comoBancoEdicion.DataTextField = "DscBanco";
            ddl_comoBancoEdicion.DataValueField = "CodBanco";
            ddl_comoBancoEdicion.DataBind();


            //------------
            ddl_comboempresaedicion.Items.Clear();

            ddl_comboempresaedicion.DataSource = dta_consulta;
            ddl_comboempresaedicion.DataTextField = "DscBanco";
            ddl_comboempresaedicion.DataValueField = "CodBanco";
            ddl_comboempresaedicion.DataBind();

            ddl_comboempresaconsulta.Items.Clear();

            ddl_comboempresaconsulta.DataSource = dta_consulta;
            ddl_comboempresaconsulta.DataTextField = "DscBanco";
            ddl_comboempresaconsulta.DataValueField = "CodBanco";
            ddl_comboempresaconsulta.DataBind();




            ddl_comboempresaconsulta.Items.Insert(0, new ListItem("TODOS", "0"));
        }

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();


            dta_consultaarticulo.Columns.Add("CodCuenta", typeof(string));
            dta_consultaarticulo.Columns.Add("banco", typeof(string));
            dta_consultaarticulo.Columns.Add("Observacion", typeof(string));
            dta_consultaarticulo.Columns.Add("Cci", typeof(string));
            dta_consultaarticulo.Columns.Add("moneda", typeof(string));
            dta_consultaarticulo.Columns.Add("NumeroCuenta", typeof(string));
            dta_consultaarticulo.Columns.Add("estado", typeof(string));
            dta_consultaarticulo.Columns.Add("Detraccion", typeof(string));
            dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
            dta_consultaarticulo.Columns.Add("CodMoneda", typeof(string));
            dta_consultaarticulo.Columns.Add("TD", typeof(string));
            dta_consultaarticulo.Columns.Add("Anexo", typeof(string));
            dta_consultaarticulo.Columns.Add("CuentaContable", typeof(string));
           

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila["banco"] = "";
            dtr_consultafila["moneda"] = "";
            dtr_consultafila["Cci"] = "";
            dtr_consultafila["NumeroCuenta"] = "";
            dtr_consultafila["estado"] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsulta.DataSource = dta_consultaarticulo;
            grvConsulta.DataBind();
        }

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodBanco = Convert.ToInt32(objTablaFiltro["Filtro_CodBanco"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.Cuenta = Convert.ToString(objTablaFiltro["Filtro_Cuenta"]);
            objEntidad.Cci = Convert.ToString(objTablaFiltro["Filtro_Cci"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);
            objEntidad.CuentaContable = Convert.ToString(objTablaFiltro["Filtro_CuentaContable"]);
            objEntidad.Td = Convert.ToString(objTablaFiltro["Filtro_Td"]);
            objEntidad.CodigoAnexo = Convert.ToString(objTablaFiltro["Filtro_CodigoAnexo"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);

            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Grabar_Bancos(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_GrabarBanco(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.DescripcionCorta = Convert.ToString(objTablaFiltro["Filtro_DescripcionCorta"]);
            objEntidad.Orden = Convert.ToInt32(objTablaFiltro["Filtro_Orden"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_Estado"]);
            objEntidad.FlagPrincipal = Convert.ToInt32(objTablaFiltro["Filtro_BancoInterno"]);

            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Bancos_Insert(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            BancosCE objEntidad = null;
            BancosCN objOperacion = null;

            DataTable dta_consulta = null;

            objOperacion = new BancosCN();
            objEntidad = new BancosCE();
            objEntidad.DscBanco = Convert.ToString(objTablaFiltro["Filtro_DscBanco"]);

            dta_consulta = objOperacion.F_Banco_Crud_Listado(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_EliminarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.IDFamilia = Convert.ToInt32(objTablaFiltro["Filtro_IDcuenta"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Cuentas_Delete(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_EditarRegistro(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodCuenta = Convert.ToInt32(objTablaFiltro["Filtro_CodCuenta"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacionon"]);
            objEntidad.Cci = Convert.ToString(objTablaFiltro["Filtro_Cci"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_Moneda"]);
            objEntidad.NumCuenta = Convert.ToString(objTablaFiltro["Filtro_NumeroCuenta"]); 
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_Estado"]);
            objEntidad.FlagDetraccion = Convert.ToInt32(objTablaFiltro["Filtro_FlagDetraccion"]);
            objEntidad.Td = Convert.ToString(objTablaFiltro["Filtro_Td"]);
            objEntidad.CodigoAnexo = Convert.ToString(objTablaFiltro["Filtro_Anexo"]);
            objEntidad.CuentaContable = Convert.ToString(objTablaFiltro["Filtro_CuentaContable"]);
            

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Bancos_Update(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void F_ObtenerBancoPorCodigo(Hashtable objTablaFiltro, ref TCCuentaCorrienteCE objEntidad, ref string MsgError)
        {
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            try
            {
                if (objTablaFiltro == null || !objTablaFiltro.ContainsKey("Filtro_CodBanco"))
                {
                    MsgError = "El parámetro 'Filtro_CodBanco' es obligatorio.";
                    return;
                }

                if (objEntidad == null)
                {
                    objEntidad = new TCCuentaCorrienteCE();
                }
                int codBanco;
                if (!int.TryParse(objTablaFiltro["Filtro_CodBanco"].ToString(), out codBanco) || codBanco <= 0)
                {
                    MsgError = "El parámetro 'Filtro_CodBanco' debe ser un número válido y mayor que cero.";
                    return;
                }

                objEntidad.CodBanco = codBanco;


                objOperacion.F_Bancos_Obtener(objEntidad);


                MsgError = objEntidad.MsgError;
            }
            catch (Exception ex)
            {

                MsgError = objEntidad.MsgError;
            }
        }
 
        public String F_EdicionRegistroBanco_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EditarRegistroBanco(obj_parametros, ref MsgError);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Consulta();
                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
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
                str_grvConsulta_html;


            return str_resultado;

        }

     
        public void P_EditarRegistroBanco(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodBanco = Convert.ToInt32(objTablaFiltro["Filtro_CodBanco"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_DescripcionEdicion"]);
            objEntidad.DescripcionCorta = Convert.ToString(objTablaFiltro["Filtro_DescripcionCorta"]);
            objEntidad.NumeroOrden = Convert.ToString(objTablaFiltro["Filtro_NumeroOrden"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_Estado"]);
   
 
            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Bancos_Update_Banco(objEntidad);

            MsgError = objEntidad.MsgError;
        }
    }
}