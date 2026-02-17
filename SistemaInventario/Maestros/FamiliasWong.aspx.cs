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
    public partial class FamiliasWong : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_LlenarGridCategoria_NET);
            CallbackManager.Register(F_EliminarFamilia_NET);
            CallbackManager.Register(F_EliminarCategoria_NET);
            CallbackManager.Register(F_EliminarTipoProducto_NET);
            CallbackManager.Register(F_GrabarFamilia_NET);
            CallbackManager.Register(F_EdicionRegistro_NET);
            CallbackManager.Register(F_EdicionCategoria_NET);
            CallbackManager.Register(F_GrabarCategoria_NET);
            CallbackManager.Register(F_GrabarTipoProducto_NET);
            CallbackManager.Register(F_LlenarGridDetalle_NET);
            CallbackManager.Register(F_EdicionTipoProducto_NET);
            CallbackManager.Register(F_ListarComboCategoriar_NET);
        }

        private string _menu = "1000"; private string _opcion = "7";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_Familia();
            P_Inicializar_GrillaVacia_Categoria();         
            Session["datos"] = true;
        }
        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlEstadoFamilia_html = "";
            String str_ddlEstadoEdicion_html = "";
            String str_ddlAlmacen_html = "";
            String str_ddlEstadoProducto_html = "";
            String str_ddlCategoriaProducto_html = "";
            String str_ddlEstadoCategoria_html = "";
            String str_ddlFamiliaProducto_html = ""; 

            int int_resultado_operacion = 0;
         
          
            String str_ddlEstadoFamiliaCategoria_html = "";
            
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlEstadoFamilia, ref ddlEstadoFamiliaCategoria, ref ddlAlmacen, ref ddlCategoriaProducto, ref ddlEstadoProducto,
                                           ref ddlEstadoCategoria, ref ddlFamiliaProducto);

        
                str_ddlEstadoFamilia_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoFamilia);
           

                str_ddlCategoriaProducto_html = Mod_Utilitario.F_GetHtmlForControl(ddlCategoriaProducto);
                str_ddlAlmacen_html = Mod_Utilitario.F_GetHtmlForControl(ddlAlmacen);
                str_ddlEstadoProducto_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoProducto);
                str_ddlEstadoFamiliaCategoria_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoFamiliaCategoria);
                str_ddlEstadoCategoria_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoCategoria);
                str_ddlFamiliaProducto_html = Mod_Utilitario.F_GetHtmlForControl(ddlFamiliaProducto);

                
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
            str_ddlEstadoFamilia_html + "~" + //2
            str_ddlEstadoEdicion_html + "~" + //3
            str_ddlEstadoFamiliaCategoria_html + "~" + //4
            str_ddlCategoriaProducto_html + "~" + //5
            str_ddlAlmacen_html + "~" + //6
            str_ddlEstadoProducto_html + "~" +  //7

            str_ddlEstadoCategoria_html + "~" +   //8
            str_ddlFamiliaProducto_html; //9
            return str_resultado;
        }
        public String F_ListarComboCategoriar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_ddlCategoriaProducto_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                ListarComboCategoriar(obj_parametros, ref ddlCategoriaProducto);

                str_ddlCategoriaProducto_html = Mod_Utilitario.F_GetHtmlForControl(ddlCategoriaProducto);
                
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
                str_ddlCategoriaProducto_html;
               
            return str_resultado;

        }

        public void ListarComboCategoriar(Hashtable objTablaFiltro,
          ref DropDownList ddl_CategoriaProducto)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;
            DataTable dta_consulta = null;
            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.IDFamilia = Convert.ToInt32(objTablaFiltro["Filtro_IDFamilia"]);
            
            objOperacion = new TCCuentaCorrienteCN();

            dta_consulta = null;

            dta_consulta = objOperacion.F_Listar_Categoria_Combo_Edicion(objEntidad);

            ddl_CategoriaProducto.Items.Clear();

            ddl_CategoriaProducto.DataSource = dta_consulta;
            ddl_CategoriaProducto.DataTextField = "Descripcion";
            ddl_CategoriaProducto.DataValueField = "CodCategoria";
            ddl_CategoriaProducto.DataBind();
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
                    P_Inicializar_GrillaVacia_Familia();
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

        public String F_LlenarGridCategoria_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsultaCategoria_html = "";
            

            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                int z = grvConsulta.Rows.Count;
                P_Buscar_Categoria(obj_parametros, ref grvConsultaCategoria);
                if (grvConsultaCategoria.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Categoria();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                {

                    str_mensaje_operacion = "";
                }

                str_grvConsultaCategoria_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaCategoria);

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
                str_grvConsultaCategoria_html;


            return str_resultado;

        }
        
        public String F_LlenarGridDetalle_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Correo_html = "";
            int Col = 0;
            int Codigo = 0;
            string Grilla_Indice_Cero = "";
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);
                Grilla_Indice_Cero = grvNombre + '0';
                grvNombre = grvNombre + Col.ToString();
                
                GridView grvTipoProducto = (GridView)grvConsultaCategoria.Rows[0].FindControl("grvTipoProducto");

                if (Codigo > 0)
                { 
                
                   
                TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
                TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();

                objEntidad.CodCategoria = Codigo;
                grvTipoProducto.DataSource = objOperacion.LGFamilia_TipoProducto_Listado(objEntidad);
                grvTipoProducto.DataBind();
                }

                if (grvTipoProducto.Rows.Count == 0)
                {
                     //grvTipoProducto = (GridView)grvConsultaCategoria.Rows[0].FindControl("grvTipoProducto");
                     str_mensaje_operacion = "No se encontraron registros.";


                     DataTable dta_consultaarticulo = null;
                     DataRow dtr_consultafila = null;

                     dta_consultaarticulo = new DataTable();

                     dta_consultaarticulo.Columns.Add("Item", typeof(string));
                     dta_consultaarticulo.Columns.Add("CodTipoProducto", typeof(string));
                     dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
                     dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
                     dta_consultaarticulo.Columns.Add("Almacen", typeof(string));
                     dta_consultaarticulo.Columns.Add("Estado", typeof(string));
                     dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
                     dta_consultaarticulo.Columns.Add("CodAlmacen", typeof(string));
                     dta_consultaarticulo.Columns.Add("CodCategoria", typeof(string));
                     dta_consultaarticulo.Columns.Add("IDFamilia", typeof(string));

                     dtr_consultafila = dta_consultaarticulo.NewRow();

                     dtr_consultafila[0] = "";                    

                     dta_consultaarticulo.Rows.Add(dtr_consultafila);
                     grvTipoProducto.DataSource = dta_consultaarticulo;
                     grvTipoProducto.DataBind();
                }
             




                str_grv_Correo_html = Mod_Utilitario.F_GetHtmlForControl(grvTipoProducto);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Correo_html.Replace(Grilla_Indice_Cero, grvNombre) + "~" +
                grvNombre;

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
                    P_Inicializar_GrillaVacia_Familia();
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

        public String F_EdicionCategoria_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
           
            int int_resultado_operacion = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EditarCategoria(obj_parametros, ref MsgError);
                
                if (grvConsulta.Rows.Count == 0)
                  P_Inicializar_GrillaVacia_Familia();
                
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

        public String F_EdicionTipoProducto_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";

            int int_resultado_operacion = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EditarProducto(obj_parametros, ref MsgError);

                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Familia();

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

        public String F_GrabarFamilia_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarFamilia(obj_parametros, ref str_mensaje_operacion);
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

        public String F_GrabarCategoria_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarCategoria(obj_parametros, ref str_mensaje_operacion);
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

        public String F_GrabarTipoProducto_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarTipoProducto(obj_parametros, ref str_mensaje_operacion);
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

        public String F_EliminarFamilia_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarFamilia(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Familia();

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

        public String F_EliminarCategoria_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarCategoria(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Familia();

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

        public String F_EliminarTipoProducto_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarTipoProducto(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Familia();

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

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_EstadoFamilia, ref DropDownList ddl_EstadoFamiliaC, 
                                                        ref DropDownList ddl_Almacen, ref DropDownList ddl_CategoriaProducto, ref DropDownList ddl_EstadoProducto,
                                                        ref DropDownList ddl_EstadoCategoria, ref DropDownList ddl_FamiliaProducto)
        {
            DataTable dta_consulta = null;

            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
            
            objEntidadConceptosDet.CodConcepto = 27;

            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_EstadoFamilia.Items.Clear();

            ddl_EstadoFamilia.DataSource = dta_consulta;
            ddl_EstadoFamilia.DataTextField = "DscAbvConcepto";
            ddl_EstadoFamilia.DataValueField = "CodConcepto";
            ddl_EstadoFamilia.DataBind();
                        
            ddl_EstadoProducto.Items.Clear();

         
            ddl_EstadoProducto.DataSource = dta_consulta;
            ddl_EstadoProducto.DataTextField = "DscAbvConcepto";
            ddl_EstadoProducto.DataValueField = "CodConcepto";
            ddl_EstadoProducto.DataBind();


            ddl_EstadoCategoria.Items.Clear();


            ddl_EstadoCategoria.DataSource = dta_consulta;
            ddl_EstadoCategoria.DataTextField = "DscAbvConcepto";
            ddl_EstadoCategoria.DataValueField = "CodConcepto";
            ddl_EstadoCategoria.DataBind();

       
            ddl_EstadoFamiliaC.Items.Clear();

            dta_consulta = objOperacionConceptosDet.F_Familia_Combo();

            ddl_EstadoFamiliaC.Items.Clear();

            ddl_EstadoFamiliaC.DataSource = dta_consulta;
            ddl_EstadoFamiliaC.DataTextField = "DscFamilia";
            ddl_EstadoFamiliaC.DataValueField = "IDFamilia";
            ddl_EstadoFamiliaC.DataBind();

            ddl_FamiliaProducto.Items.Clear();

            dta_consulta = objOperacionConceptosDet.F_Familia_Combo();

            ddl_FamiliaProducto.Items.Clear();

            ddl_FamiliaProducto.DataSource = dta_consulta;
            ddl_FamiliaProducto.DataTextField = "DscFamilia";
            ddl_FamiliaProducto.DataValueField = "IDFamilia";
            ddl_FamiliaProducto.DataBind();
                     
            ddl_Almacen.Items.Clear();

            dta_consulta = objOperacionConceptosDet.F_Almacen_Combo();

            ddl_Almacen.Items.Clear();

            ddl_Almacen.DataSource = dta_consulta;
            ddl_Almacen.DataTextField = "DscAlmacen";
            ddl_Almacen.DataValueField = "CodAlmacen";
            ddl_Almacen.DataBind();
            
            ddl_CategoriaProducto.Items.Clear();

            dta_consulta = objOperacionConceptosDet.F_Categoria_Combo();

            ddl_CategoriaProducto.Items.Clear();

            ddl_CategoriaProducto.DataSource = dta_consulta;
            ddl_CategoriaProducto.DataTextField = "DscCategoria";
            ddl_CategoriaProducto.DataValueField = "CodCategoria";
            ddl_CategoriaProducto.DataBind();          
        }

        public void P_GrabarFamilia(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

      
            objEntidad.DscFamilia = Convert.ToString(objTablaFiltro["Filtro_DscFamilia"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Insert_Familia(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_GrabarCategoria(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();
            
            objEntidad.IDFamilia = Convert.ToInt32(objTablaFiltro["Filtro_IDFamilia"]);
            objEntidad.Codigo = Convert.ToString(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Insert_Categoria(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_GrabarTipoProducto(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.IDCategoria = Convert.ToInt32(objTablaFiltro["Filtro_IDCategoria"]);
            objEntidad.CodigoProducto = Convert.ToString(objTablaFiltro["Filtro_CodigoProducto"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]);
            objEntidad.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_Almacen"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_EstadoProducto"]);            
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_FamiliaTipoProducto_Insert(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            DataTable dta_consulta = null;

            objOperacion = new TCCuentaCorrienteCN();
            objEntidad = new TCCuentaCorrienteCE();


            dta_consulta = objOperacion.F_LGFamilia_Listado(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_Buscar_Categoria(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {


            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            DataTable dta_consulta = null;

            objOperacion = new TCCuentaCorrienteCN();
            objEntidad = new TCCuentaCorrienteCE();
            objEntidad.IDFamilia = Convert.ToInt32(objTablaFiltro["Filtro_IDFamilia"]);

            dta_consulta = objOperacion.F_LGCategoria_Listado(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();


            int x = grvConsultaCategoria.Rows.Count;
        }
  
        public void P_EditarRegistro(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.IDFamilia = Convert.ToInt32(objTablaFiltro["Filtro_IDFamilia"]);
            objEntidad.DscFamilia = Convert.ToString(objTablaFiltro["Filtro_DscFamilia"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Actualizar_LGFamilias(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_EditarCategoria(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();       

            objEntidad.CodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);
            objEntidad.IDFamilia = Convert.ToInt32(objTablaFiltro["Filtro_IDFamilia"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.Codigo = Convert.ToString(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Editar_LGFamilia_Categoria(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_EditarProducto(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodTipoProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoProducto"]);
            objEntidad.CodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);
            objEntidad.Codigo = Convert.ToString(objTablaFiltro["Filtro_CodigoProducto"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacen"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Editar_LGFamilia_Categoria_Producto(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_Inicializar_GrillaVacia_Familia()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodFamilia", typeof(string));
            dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
            dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
            dta_consultaarticulo.Columns.Add("Estado", typeof(string));
            dta_consultaarticulo.Columns.Add("IDFamilia", typeof(string));
            dta_consultaarticulo.Columns.Add("Item", typeof(string));


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

        public void P_Inicializar_GrillaVacia_Categoria()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();


            dta_consultaarticulo.Columns.Add("Item", typeof(string));
            dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
            dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
            dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
            dta_consultaarticulo.Columns.Add("Estado", typeof(string));
            dta_consultaarticulo.Columns.Add("CodCategoria", typeof(string));
            dta_consultaarticulo.Columns.Add("IDFamilia", typeof(string));
            dta_consultaarticulo.Columns.Add("DscFamilia", typeof(string));
            
            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
          
            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsultaCategoria.DataSource = dta_consultaarticulo;
            grvConsultaCategoria.DataBind();
        }

        public void P_EliminarFamilia(Hashtable objTablaFiltro, ref String Mensaje)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.IDFamilia = Convert.ToInt32(objTablaFiltro["Filtro_IDFamilia"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_LGFamilias_Eliminar(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_EliminarCategoria(Hashtable objTablaFiltro, ref String Mensaje)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_LGFamilias_Categoria_Eliminar(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_EliminarTipoProducto(Hashtable objTablaFiltro, ref String Mensaje)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodTipoProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_LGFamilias_Producto_Eliminar(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        protected void grvConsultaDetalle_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                GridView grvTipoProducto = null;

                grvTipoProducto = (GridView)(e.Row.FindControl("grvTipoProducto"));
                             

                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();
                    dta_consultaarticulo.Columns.Add("Item", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodTipoProducto", typeof(string));
                    dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
                    dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
                    dta_consultaarticulo.Columns.Add("Almacen", typeof(string));
                    dta_consultaarticulo.Columns.Add("Estado", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodAlmacen", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodCategoria", typeof(string));
                    dta_consultaarticulo.Columns.Add("IDFamilia", typeof(string));
                    
                
                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvTipoProducto.DataSource = dta_consultaarticulo;
                    grvTipoProducto.DataBind();

                }


            }

        }   
}