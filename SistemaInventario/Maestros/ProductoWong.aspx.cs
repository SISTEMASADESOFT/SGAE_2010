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
    public partial class ProductoWong : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Buscar_Detalle_NET);
            CallbackManager.Register(F_EdicionRegistro_NET);
            CallbackManager.Register(F_ListarComboModelo_NET);
            CallbackManager.Register(F_ListarComboMotor_NET);
            CallbackManager.Register(F_ListarComboModeloEdicion_NET);
            CallbackManager.Register(F_ListarComboMotorEdicion_NET);
            CallbackManager.Register(F_GrabarDetalle_NET);
            CallbackManager.Register(F_EliminarDetalle_NET);
            CallbackManager.Register(F_EditarDetalle_NET);
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
        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";           
            int int_resultado_operacion = 0;  
            //combos//
            String str_ddlUndVenta_html="";
            String str_ddlNombreMed_html = "";
            String str_ddlTipo_html = "";
            String str_ddlMarcaFab_html = "";
            String str_ddlPaisOrigen_html = "";
            String str_ddlFamilia_html = "";
            String str_ddlCategoria_html = "";
            String str_ddlTipoProducto_html = "";
            String str_ddlMarca1_html = "";
            String str_ddlMarca2_html = "";
            String str_ddlMarca3_html = "";
            //Combo Edicion

            String str_ddlUndVentaEdicion_html = "";
            String str_ddlNombreMedEdicion_html = "";
            String str_ddlTipoEdicion_html = "";
            String str_ddlMarcaFabEdicion_html = "";
            String str_ddlPaisOrigenEdicion_html = "";
            String str_ddlFamiliaEdicion_html = "";
            String str_ddlCategoriaEdicion_html = "";
            String str_ddlTipoProductoEdicion_html = "";
            String str_ddlMarca1Edicion_html = "";
            String str_ddlMarca2Edicion_html = "";
            String str_ddlMarca3Edicion_html = "";
            String str_ddlMarcaAplicaciones_html = "";
            String str_ddlMarcaAplicacionesEdicion_html = "";

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlUndVenta, ref ddlMarcaFab, ref ddlPaisOrigen,
                                                        ref ddlMarca1, ref ddlMarca2, ref ddlMarca3, ref ddlUndVentaEdicion, 
                                                        ref ddlMarcaFabEdicion, ref ddlPaisOrigenEdicion, ref ddlMarca1Edicion, ref ddlMarca2Edicion, ref ddlMarca3Edicion, ref ddlMarcaAplicaciones, ref ddlMarcaAplicacionesEdicion);

                str_ddlUndVenta_html = Mod_Utilitario.F_GetHtmlForControl(ddlUndVenta);
     
                str_ddlMarcaFab_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarcaFab);
                str_ddlPaisOrigen_html = Mod_Utilitario.F_GetHtmlForControl(ddlPaisOrigen);
                str_ddlMarca1_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarca1);
                str_ddlMarca2_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarca2);
                str_ddlMarca3_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarca3);

                //Edicion
                str_ddlUndVentaEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlUndVentaEdicion);          
                str_ddlMarcaFabEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarcaFabEdicion);
                str_ddlPaisOrigenEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlPaisOrigenEdicion);
                str_ddlMarca1Edicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarca1Edicion);
                str_ddlMarca2Edicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarca2Edicion);
                str_ddlMarca3Edicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarca3Edicion);

                //Aplicacion

                str_ddlMarcaAplicaciones_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarcaAplicaciones);
                str_ddlMarcaAplicacionesEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarcaAplicacionesEdicion);
                    
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
            str_ddlUndVenta_html + "~" + //2
            str_ddlNombreMed_html + "~" + // 3
            str_ddlTipo_html + "~" + //4
            str_ddlMarcaFab_html + "~" + //5
            str_ddlPaisOrigen_html + "~" +  //6
            str_ddlFamilia_html + "~" + // 7
            str_ddlCategoria_html + "~" + //8
            str_ddlTipoProducto_html + "~" + //9
            str_ddlMarca1_html + "~" + //10
            str_ddlMarca2_html + "~" + //11
            str_ddlMarca3_html + "~" + // 12
            str_ddlUndVentaEdicion_html + "~" + //13
            str_ddlNombreMedEdicion_html + "~" + // 14
            str_ddlTipoEdicion_html + "~" + //15
            str_ddlMarcaFabEdicion_html + "~" + //16
            str_ddlPaisOrigenEdicion_html + "~" +  //17
            str_ddlFamiliaEdicion_html + "~" + // 18
            str_ddlCategoriaEdicion_html + "~" + //19
            str_ddlTipoProductoEdicion_html + "~" + //20
            str_ddlMarca1Edicion_html + "~" + //21
            str_ddlMarca2Edicion_html + "~" + //22
            str_ddlMarca3Edicion_html + "~" +//23
            str_ddlMarcaAplicaciones_html + "~" +//24
            str_ddlMarcaAplicacionesEdicion_html; //25
       
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

        public String F_EdicionRegistro_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EdicionRegistro(obj_parametros, ref str_mensaje_operacion);
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

        public String F_Buscar_Detalle_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar_Detalle(obj_parametros, ref grvProductoDetalle);
                if (grvProductoDetalle.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Detalle();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                {
                    str_mensaje_operacion = "";
                }

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvProductoDetalle);
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

        public String F_ListarComboModelo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_ddlModeloAplicaciones_html = "";

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ListarModeloCombo(obj_parametros, ref ddlModeloAplicaciones);

                str_ddlModeloAplicaciones_html = Mod_Utilitario.F_GetHtmlForControl(ddlModeloAplicaciones);

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
                str_ddlModeloAplicaciones_html;

            return str_resultado;
        }

        public String F_ListarComboMotor_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_ddlMotorAplicaciones_html = "";

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ListarMotorCombo(obj_parametros, ref ddlMotorAplicaciones);

                str_ddlMotorAplicaciones_html = Mod_Utilitario.F_GetHtmlForControl(ddlMotorAplicaciones);

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
                str_ddlMotorAplicaciones_html;

            return str_resultado;
        }

        public String F_ListarComboModeloEdicion_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_ddlModeloAplicaciones_html = "";

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ListarModeloCombo(obj_parametros, ref ddlModeloAplicacionesEdicion);

                str_ddlModeloAplicaciones_html = Mod_Utilitario.F_GetHtmlForControl(ddlModeloAplicacionesEdicion);

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
                str_ddlModeloAplicaciones_html;

            return str_resultado;
        }

        public String F_ListarComboMotorEdicion_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_ddlMotorAplicaciones_html = "";

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ListarMotorCombo(obj_parametros, ref ddlMotorAplicacionesEdicion);

                str_ddlMotorAplicaciones_html = Mod_Utilitario.F_GetHtmlForControl(ddlMotorAplicacionesEdicion);

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
                str_ddlMotorAplicaciones_html;

            return str_resultado;
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_UndVenta,ref DropDownList ddl_MarcaFab, ref DropDownList ddl_PaisOrigen, 
                                          ref DropDownList ddl_Marca1, ref DropDownList ddl_Marca2,ref DropDownList ddl_Marca3, ref DropDownList ddl_UndVentaEdicion, 
                                          ref DropDownList ddl_MarcaFabEdicion, ref DropDownList ddl_PaisOrigenEdicion,ref DropDownList ddl_Marca1Edicion,  
                                          ref DropDownList ddl_Marca2Edicion, ref DropDownList ddl_Marca3Edicion,ref DropDownList ddl_MarcaAplicaciones, 
                                          ref DropDownList ddl_MarcaAplicacionesEdicion)
        {
            DataTable dta_consulta = null;

            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();

            ddl_UndVenta.Items.Clear();
             
            objEntidadConceptosDet.CodConcepto = 6;
             
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);
             
            ddl_UndVenta.Items.Clear();
              
            ddl_UndVenta.DataSource = dta_consulta;
            ddl_UndVenta.DataTextField = "DscAbvConcepto";
            ddl_UndVenta.DataValueField = "CodConcepto";
            ddl_UndVenta.DataBind();

            ddl_UndVentaEdicion.Items.Clear();
                        
            ddl_UndVentaEdicion.DataSource = dta_consulta;
            ddl_UndVentaEdicion.DataTextField = "DscAbvConcepto";
            ddl_UndVentaEdicion.DataValueField = "CodConcepto";
            ddl_UndVentaEdicion.DataBind();
             
            dta_consulta = objOperacionConceptosDet.F_PAIS_LISTAR_COMBO();
            ddl_PaisOrigen.Items.Clear();
             
            ddl_PaisOrigen.DataSource = dta_consulta;
            ddl_PaisOrigen.DataTextField = "Descripcion";
            ddl_PaisOrigen.DataValueField = "CodPais";
            ddl_PaisOrigen.DataBind();

            ddl_PaisOrigenEdicion.Items.Clear();
                          
            ddl_PaisOrigenEdicion.DataSource = dta_consulta;
            ddl_PaisOrigenEdicion.DataTextField = "Descripcion";
            ddl_PaisOrigenEdicion.DataValueField = "CodPais";
            ddl_PaisOrigenEdicion.DataBind();

            ddl_MarcaFab.Items.Clear();

            objEntidadConceptosDet.CodConcepto = 10;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);
            ddl_MarcaFab.Items.Clear();

            ddl_MarcaFab.DataSource = dta_consulta;
            ddl_MarcaFab.DataTextField = "DscAbvConcepto";
            ddl_MarcaFab.DataValueField = "CodConcepto";
            ddl_MarcaFab.DataBind();

            ddl_MarcaFabEdicion.Items.Clear();
                        
            ddl_MarcaFabEdicion.DataSource = dta_consulta;
            ddl_MarcaFabEdicion.DataTextField = "DscAbvConcepto";
            ddl_MarcaFabEdicion.DataValueField = "CodConcepto";
            ddl_MarcaFabEdicion.DataBind();
            
            ddl_Marca1.Items.Clear();

            objEntidadConceptosDet.CodConcepto = 14;

            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_Marca1.Items.Clear();

            ddl_Marca1.DataSource = dta_consulta;
            ddl_Marca1.DataTextField = "Descripcion";
            ddl_Marca1.DataValueField = "CodVehiculo";
            ddl_Marca1.DataBind();

            ddl_Marca1Edicion.Items.Clear();
                      
            ddl_Marca1Edicion.DataSource = dta_consulta;
            ddl_Marca1Edicion.DataTextField = "Descripcion";
            ddl_Marca1Edicion.DataValueField = "CodVehiculo";
            ddl_Marca1Edicion.DataBind();

            ddl_Marca2.Items.Clear();

            ddl_Marca2.DataSource = dta_consulta;
            ddl_Marca2.DataTextField = "Descripcion";
            ddl_Marca2.DataValueField = "CodVehiculo";
            ddl_Marca2.DataBind();

            ddl_Marca2Edicion.Items.Clear();
                      
            ddl_Marca2Edicion.DataSource = dta_consulta;
            ddl_Marca2Edicion.DataTextField = "Descripcion";
            ddl_Marca2Edicion.DataValueField = "CodVehiculo";
            ddl_Marca2Edicion.DataBind();

            ddl_Marca3.Items.Clear();
                     
            ddl_Marca3.DataSource = dta_consulta;
            ddl_Marca3.DataTextField = "Descripcion";
            ddl_Marca3.DataValueField = "CodVehiculo";
            ddl_Marca3.DataBind();

            ddl_Marca3Edicion.Items.Clear();
                      
            ddl_Marca3Edicion.DataSource = dta_consulta;
            ddl_Marca3Edicion.DataTextField = "Descripcion";
            ddl_Marca3Edicion.DataValueField = "CodVehiculo";
            ddl_Marca3Edicion.DataBind();

            ddl_MarcaAplicaciones.Items.Clear();
                      
            ddl_MarcaAplicaciones.DataSource = dta_consulta;
            ddl_MarcaAplicaciones.DataTextField = "Descripcion";
            ddl_MarcaAplicaciones.DataValueField = "CodVehiculo";
            ddl_MarcaAplicaciones.DataBind();

            ddl_MarcaAplicacionesEdicion.Items.Clear();
                                 
            ddl_MarcaAplicacionesEdicion.DataSource = dta_consulta;
            ddl_MarcaAplicacionesEdicion.DataTextField = "Descripcion";
            ddl_MarcaAplicacionesEdicion.DataValueField = "CodVehiculo";
            ddl_MarcaAplicacionesEdicion.DataBind();   
          }

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError)
        {
            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();

            int iCodEmpresa = 3;

            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);
            objEntidad.CodigoInterno = Convert.ToString(objTablaFiltro["Filtro_CodigoInterno"]);
            objEntidad.RefOEM = Convert.ToString(objTablaFiltro["Filtro_RefOEM"]);
            objEntidad.CodigoBarra = Convert.ToString(objTablaFiltro["Filtro_CodigoBarra"]);
            objEntidad.CodigoProveedor = Convert.ToString(objTablaFiltro["Filtro_CodigoProveedor"]);

            objEntidad.CodProveedor = Convert.ToInt32(objTablaFiltro["Filtro_Proveedor"]);
            objEntidad.CodigoFabrica = Convert.ToString(objTablaFiltro["Filtro_CodigoFabricante"]);
            objEntidad.Equivalente = Convert.ToString(objTablaFiltro["Filtro_Equivalente"]);
            objEntidad.CodTipoProducto = Convert.ToInt32(objTablaFiltro["Filtro_TipoProducto"]);

            objEntidad.DescripcionModelo = Convert.ToString(objTablaFiltro["Filtro_DescripcionModelo"]);
            objEntidad.DscProducto = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]);

            objEntidad.DescripcionSistema = Convert.ToString(objTablaFiltro["Filtro_DescSistema"]);
            objEntidad.CodMarca = Convert.ToInt32(objTablaFiltro["Filtro_MarcaFab"]);
            objEntidad.CodPais = Convert.ToInt32(objTablaFiltro["Filtro_PaisOrigen"]);
            objEntidad.UnidadVenta = Convert.ToInt32(objTablaFiltro["Filtro_UndVenta"]);
            objEntidad.PesoTotal = Convert.ToString(objTablaFiltro["Filtro_PesoTotal"]);

            objEntidad.M1 = Convert.ToDecimal(objTablaFiltro["Filtro_M1"]);
            objEntidad.M2 = Convert.ToDecimal(objTablaFiltro["Filtro_M2"]);
            objEntidad.FlagControlStock = Convert.ToInt32(objTablaFiltro["Filtro_ControlStock"]);

            objEntidad.CodTipoMedida = Convert.ToInt32(objTablaFiltro["Filtro_NombreMed"]);
            objEntidad.Medida1 = Convert.ToString(objTablaFiltro["Filtro_Medida1"]);
            objEntidad.Medida2 = Convert.ToString(objTablaFiltro["Filtro_Medida2"]);

            objEntidad.CodTipoUbicacion = Convert.ToInt32(objTablaFiltro["Filtro_Tipo"]);
            objEntidad.Almacen = Convert.ToString(objTablaFiltro["Filtro_Almacen"]);
            objEntidad.Rack = Convert.ToString(objTablaFiltro["Filtro_Rack"]);
            objEntidad.Nivel = Convert.ToString(objTablaFiltro["Filtro_Nivel"]);
            objEntidad.Zona = Convert.ToString(objTablaFiltro["Filtro_Zona"]);
            objEntidad.Caja = Convert.ToString(objTablaFiltro["Filtro_Caja"]);
            objEntidad.Mostrador = Convert.ToString(objTablaFiltro["Filtro_Mostrador"]);

            objEntidad.CodMarca1 = Convert.ToInt32(objTablaFiltro["Filtro_Marca1"]);
            objEntidad.CodMarca2 = Convert.ToInt32(objTablaFiltro["Filtro_Marca2"]);
            objEntidad.CodMarca3 = Convert.ToInt32(objTablaFiltro["Filtro_Marca3"]);

            objEntidad.Modelo1 = Convert.ToString(objTablaFiltro["Filtro_Modelo1"]);
            objEntidad.Modelo2 = Convert.ToString(objTablaFiltro["Filtro_Modelo2"]);
            objEntidad.Modelo3 = Convert.ToString(objTablaFiltro["Filtro_Modelo3"]);
            objEntidad.TipoMotor1 = Convert.ToString(objTablaFiltro["Filtro_TipoMotor1"]);
            objEntidad.TipoMotor2 = Convert.ToString(objTablaFiltro["Filtro_TipoMotor2"]);
            objEntidad.TipoMotor3 = Convert.ToString(objTablaFiltro["Filtro_TipoMotor3"]);
            objEntidad.AñoIT1 = Convert.ToString(objTablaFiltro["Filtro_AñoIT1"]);
            objEntidad.AñoIT2 = Convert.ToString(objTablaFiltro["Filtro_AñoIT2"]);
            objEntidad.AñoIT3 = Convert.ToString(objTablaFiltro["Filtro_AñoIT3"]);

            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodAlmacen"]);

            //try { objEntidad.IdImagenProducto1 = Convert.ToInt32(objTablaFiltro["21321"]); }
            //catch (Exception ex2) { objEntidad.IdImagenProducto1 = 0; }
            //objEntidad.Imagenes = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro[""].ToString());


            objOperacion = new LGProductosCN();

            objOperacion.F_LGProductos_Insert_Wong(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_EdicionRegistro(Hashtable objTablaFiltro, ref String MsgError)
        {
            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();

            int iCodEmpresa = 3;

            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);
            objEntidad.CodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);
            objEntidad.CodigoInterno = Convert.ToString(objTablaFiltro["Filtro_CodigoInterno"]);
            objEntidad.RefOEM = Convert.ToString(objTablaFiltro["Filtro_RefOEM"]);
            objEntidad.CodigoBarra = Convert.ToString(objTablaFiltro["Filtro_CodigoBarra"]);
            objEntidad.CodigoProveedor = Convert.ToString(objTablaFiltro["Filtro_CodigoProveedor"]);

            objEntidad.CodProveedor = Convert.ToInt32(objTablaFiltro["Filtro_Proveedor"]);
            objEntidad.CodigoFabrica = Convert.ToString(objTablaFiltro["Filtro_CodigoFabricante"]);
            objEntidad.Equivalente = Convert.ToString(objTablaFiltro["Filtro_Equivalente"]);
            objEntidad.CodTipoProducto = Convert.ToInt32(objTablaFiltro["Filtro_TipoProducto"]);

            objEntidad.DescripcionModelo = Convert.ToString(objTablaFiltro["Filtro_DescripcionModelo"]);
            objEntidad.DscProducto = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]);

            objEntidad.DescripcionSistema = Convert.ToString(objTablaFiltro["Filtro_DescSistema"]);
            objEntidad.CodMarca = Convert.ToInt32(objTablaFiltro["Filtro_MarcaFab"]);
            objEntidad.CodPais = Convert.ToInt32(objTablaFiltro["Filtro_PaisOrigen"]);
            objEntidad.UnidadVenta = Convert.ToInt32(objTablaFiltro["Filtro_UndVenta"]);
            objEntidad.PesoTotal = Convert.ToString(objTablaFiltro["Filtro_PesoTotal"]);

            objEntidad.M1 = Convert.ToDecimal(objTablaFiltro["Filtro_M1"]);
            objEntidad.M2 = Convert.ToDecimal(objTablaFiltro["Filtro_M2"]);
            objEntidad.FlagControlStock = Convert.ToInt32(objTablaFiltro["Filtro_ControlStock"]);

            objEntidad.CodTipoMedida = Convert.ToInt32(objTablaFiltro["Filtro_NombreMed"]);
            objEntidad.Medida1 = Convert.ToString(objTablaFiltro["Filtro_Medida1"]);
            objEntidad.Medida2 = Convert.ToString(objTablaFiltro["Filtro_Medida2"]);

            objEntidad.CodTipoUbicacion = Convert.ToInt32(objTablaFiltro["Filtro_Tipo"]);
            objEntidad.Almacen = Convert.ToString(objTablaFiltro["Filtro_Almacen"]);
            objEntidad.Rack = Convert.ToString(objTablaFiltro["Filtro_Rack"]);
            objEntidad.Nivel = Convert.ToString(objTablaFiltro["Filtro_Nivel"]);
            objEntidad.Zona = Convert.ToString(objTablaFiltro["Filtro_Zona"]);
            objEntidad.Caja = Convert.ToString(objTablaFiltro["Filtro_Caja"]);
            objEntidad.Mostrador = Convert.ToString(objTablaFiltro["Filtro_Mostrador"]);

            objEntidad.CodMarca1 = Convert.ToInt32(objTablaFiltro["Filtro_Marca1"]);
            objEntidad.CodMarca2 = Convert.ToInt32(objTablaFiltro["Filtro_Marca2"]);
            objEntidad.CodMarca3 = Convert.ToInt32(objTablaFiltro["Filtro_Marca3"]);

            objEntidad.Modelo1 = Convert.ToString(objTablaFiltro["Filtro_Modelo1"]);
            objEntidad.Modelo2 = Convert.ToString(objTablaFiltro["Filtro_Modelo2"]);
            objEntidad.Modelo3 = Convert.ToString(objTablaFiltro["Filtro_Modelo3"]);
            objEntidad.TipoMotor1 = Convert.ToString(objTablaFiltro["Filtro_TipoMotor1"]);
            objEntidad.TipoMotor2 = Convert.ToString(objTablaFiltro["Filtro_TipoMotor2"]);
            objEntidad.TipoMotor3 = Convert.ToString(objTablaFiltro["Filtro_TipoMotor3"]);
            objEntidad.AñoIT1 = Convert.ToString(objTablaFiltro["Filtro_AñoIT1"]);
            objEntidad.AñoIT2 = Convert.ToString(objTablaFiltro["Filtro_AñoIT2"]);
            objEntidad.AñoIT3 = Convert.ToString(objTablaFiltro["Filtro_AñoIT3"]);

            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodAlmacen"]);

            objOperacion = new LGProductosCN();

            objOperacion.F_LGProductos_Update_Wong(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_ListarCategoriaCombo(Hashtable objTablaFiltro, ref DropDownList ddl_Categoria)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;
            DataTable dta_consulta = null;
            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.IDFamilia = Convert.ToInt32(objTablaFiltro["Filtro_IDFamilia"]);

            objOperacion = new TCCuentaCorrienteCN();

            dta_consulta = null;

            dta_consulta = objOperacion.F_Listar_Categoria_Combo(objEntidad);

            ddl_Categoria.Items.Clear();

            ddl_Categoria.DataSource = dta_consulta;
            ddl_Categoria.DataTextField = "Descripcion";
            ddl_Categoria.DataValueField = "CodCategoria";
            ddl_Categoria.DataBind();
        }
        public void P_ListarTipoProducto(Hashtable objTablaFiltro, ref DropDownList ddl_TipoProducto)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;
            DataTable dta_consulta = null;
            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);


            objOperacion = new TCCuentaCorrienteCN();

            dta_consulta = null;

            dta_consulta = objOperacion.F_Listar_TipoProducto_Combo(objEntidad);

            ddl_TipoProducto.Items.Clear();

            ddl_TipoProducto.DataSource = dta_consulta;
            ddl_TipoProducto.DataTextField = "Descripcion";
            ddl_TipoProducto.DataValueField = "CodTipoProducto";
            ddl_TipoProducto.DataBind();

            ddl_TipoProducto.Items.Insert(0, new ListItem("TODOS", "0"));



        }
        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("Item", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoInterno", typeof(string));
            dta_consultaarticulo.Columns.Add("Producto", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoProveedor", typeof(string));
            dta_consultaarticulo.Columns.Add("MarcaVehiculo", typeof(string));
            dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
            dta_consultaarticulo.Columns.Add("TipoMotor1", typeof(string));
            dta_consultaarticulo.Columns.Add("Medida", typeof(string));
            dta_consultaarticulo.Columns.Add("DscMarca1", typeof(string));
            dta_consultaarticulo.Columns.Add("Costo", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio1", typeof(string));
            dta_consultaarticulo.Columns.Add("CodCategoria", typeof(string));
            dta_consultaarticulo.Columns.Add("RedOEM", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoBarra", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoFabrica", typeof(string));
            dta_consultaarticulo.Columns.Add("Proveedor", typeof(string));
            dta_consultaarticulo.Columns.Add("Equivalente", typeof(string));
            dta_consultaarticulo.Columns.Add("TipoProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("DescripcionModelo", typeof(string));
            dta_consultaarticulo.Columns.Add("DscProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("DescripcionSistema", typeof(string));
            dta_consultaarticulo.Columns.Add("CodMarcaProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("CodPais", typeof(string));
            dta_consultaarticulo.Columns.Add("unidadVenta", typeof(string));
            dta_consultaarticulo.Columns.Add("PesoTotal", typeof(string));
            dta_consultaarticulo.Columns.Add("M1", typeof(string));
            dta_consultaarticulo.Columns.Add("M2", typeof(string));
            dta_consultaarticulo.Columns.Add("FlagControlStock", typeof(string));
            dta_consultaarticulo.Columns.Add("CodTitoMedida", typeof(string));
            dta_consultaarticulo.Columns.Add("Medida1", typeof(string));
            dta_consultaarticulo.Columns.Add("Medida2", typeof(string));
            dta_consultaarticulo.Columns.Add("TIpoUbicacion", typeof(string));
            dta_consultaarticulo.Columns.Add("Almacen", typeof(string));
            dta_consultaarticulo.Columns.Add("Rack", typeof(string));
            dta_consultaarticulo.Columns.Add("Nivel", typeof(string));
            dta_consultaarticulo.Columns.Add("Zona", typeof(string));
            dta_consultaarticulo.Columns.Add("Caja", typeof(string));
            dta_consultaarticulo.Columns.Add("Mostrador", typeof(string));
            dta_consultaarticulo.Columns.Add("CodMarca1", typeof(string));
            dta_consultaarticulo.Columns.Add("CodMarca2", typeof(string));
            dta_consultaarticulo.Columns.Add("CodMarca3", typeof(string));
            dta_consultaarticulo.Columns.Add("Modelo1", typeof(string));
            dta_consultaarticulo.Columns.Add("Modelo2", typeof(string));
            dta_consultaarticulo.Columns.Add("Modelo3", typeof(string));
            dta_consultaarticulo.Columns.Add("TipoMotor2", typeof(string));
            dta_consultaarticulo.Columns.Add("TipoMotor3", typeof(string));
            dta_consultaarticulo.Columns.Add("AñoIT1", typeof(string));
            dta_consultaarticulo.Columns.Add("AñoIT2", typeof(string));
            dta_consultaarticulo.Columns.Add("AñoIT3", typeof(string));
            dta_consultaarticulo.Columns.Add("CodProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("IDFamilia", typeof(string));
            dta_consultaarticulo.Columns.Add("CodCtaCte", typeof(string));
            dta_consultaarticulo.Columns.Add("DescripcionAutocomplete", typeof(string));
            dta_consultaarticulo.Columns.Add("DescripcionTipoProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoCategoria", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";
            dtr_consultafila[3] = "";
            dtr_consultafila[4] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsulta.DataSource = dta_consultaarticulo;
            grvConsulta.DataBind();
        }
        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            DataTable dta_consulta = null;

            objOperacion = new TCCuentaCorrienteCN();
            objEntidad = new TCCuentaCorrienteCE();
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);

            dta_consulta = objOperacion.F_LGProducto_Listado_prueba(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_Buscar_Detalle(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new LGProductosCE();

            objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);

            objOperacion = new LGProductosCN();

            dta_consulta = objOperacion.F_ProductoModelo_Listado(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }
        public void P_Inicializar_GrillaVacia_Detalle()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("Item", typeof(string));
            dta_consultaarticulo.Columns.Add("Marca", typeof(string));
            dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
            dta_consultaarticulo.Columns.Add("Motor", typeof(string));
            dta_consultaarticulo.Columns.Add("AñoIT1", typeof(string));
            dta_consultaarticulo.Columns.Add("CodMarca", typeof(string));
            dta_consultaarticulo.Columns.Add("CodModelo", typeof(string));
            dta_consultaarticulo.Columns.Add("Codmotor", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";


            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvProductoDetalle.DataSource = dta_consultaarticulo;
            grvProductoDetalle.DataBind();
        }

        public void P_ListarModeloCombo(Hashtable objTablaFiltro, ref DropDownList ddl_Modelo)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;
            DataTable dta_consulta = null;
            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculo"]);

            objOperacion = new TCCuentaCorrienteCN();

            dta_consulta = null;

            dta_consulta = objOperacion.F_Listar_Modelo_Combo(objEntidad);

            ddl_Modelo.Items.Clear();

            ddl_Modelo.DataSource = dta_consulta;
            ddl_Modelo.DataTextField = "Descripcion";
            ddl_Modelo.DataValueField = "CodModelo";
            ddl_Modelo.DataBind();
        }

        public void P_ListarMotorCombo(Hashtable objTablaFiltro, ref DropDownList ddl_Motor)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;
            DataTable dta_consulta = null;
            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodModelo = Convert.ToInt32(objTablaFiltro["Filtro_CodModelo"]);

            objOperacion = new TCCuentaCorrienteCN();

            dta_consulta = null;

            dta_consulta = objOperacion.F_VehiculoMotor_Listado_Combo(objEntidad);

            ddl_Motor.Items.Clear();

            ddl_Motor.DataSource = dta_consulta;
            ddl_Motor.DataTextField = "Descripcion";
            ddl_Motor.DataValueField = "CodMotor";
            ddl_Motor.DataBind();

        }

        public String F_GrabarDetalle_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDetalle(obj_parametros, ref str_mensaje_operacion);
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

        public void P_GrabarDetalle(Hashtable objTablaFiltro, ref String MsgError)
        {
            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();

            objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);
            objEntidad.MarcaAplicaciones = Convert.ToInt32(objTablaFiltro["Filtro_MarcaAplicaciones"]);
            objEntidad.ModeloAplicaciones = Convert.ToInt32(objTablaFiltro["Filtro_ModeloAplicaciones"]);
            objEntidad.MotorAplicaciones = Convert.ToInt32(objTablaFiltro["Filtro_MotorAplicaciones"]);
            objEntidad.AñoDetalle = Convert.ToString(objTablaFiltro["Filtro_AñoDetalle"]);

            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodAlmacen"]);


            objOperacion = new LGProductosCN();

            objOperacion.F_LGProductosDetalle_Insert_Wong(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public String F_EliminarDetalle_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarDetalle(obj_parametros, ref str_mensaje_operacion);


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

        public void P_EliminarDetalle(Hashtable objTablaFiltro, ref String MsgError)
        {
            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();

            objEntidad.CodProductoDetalle = Convert.ToInt32(objTablaFiltro["Filtro_CodProductoDetalle"]);


            objOperacion = new LGProductosCN();

            objOperacion.F_LGProductosDetalle_Eliminar_Wong(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public String F_EditarDetalle_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EditarDetalle(obj_parametros, ref str_mensaje_operacion);
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

        public void P_EditarDetalle(Hashtable objTablaFiltro, ref String MsgError)
        {
            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();

            objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProductoDetalle"]);
            objEntidad.MarcaAplicaciones = Convert.ToInt32(objTablaFiltro["Filtro_MarcaAplicaciones"]);
            objEntidad.ModeloAplicaciones = Convert.ToInt32(objTablaFiltro["Filtro_ModeloAplicaciones"]);
            objEntidad.MotorAplicaciones = Convert.ToInt32(objTablaFiltro["Filtro_MotorAplicaciones"]);
            objEntidad.AñoDetalle = Convert.ToString(objTablaFiltro["Filtro_AñoDetalle"]);

            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodAlmacen"]);


            objOperacion = new LGProductosCN();

            objOperacion.F_LGProductosDetalle_Editar_Wong(objEntidad);

            MsgError = objEntidad.MsgError;
        }
    }
}