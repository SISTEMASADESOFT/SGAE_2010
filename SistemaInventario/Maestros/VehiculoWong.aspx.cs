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
    public partial class VehiculoWong : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_LlenarGridModelo_NET);
            CallbackManager.Register(F_EliminarMarca_NET);
            CallbackManager.Register(F_EliminarModelo_NET);
            CallbackManager.Register(F_EliminarTipoMotor_NET);
            CallbackManager.Register(F_GrabarMarca_NET);
            CallbackManager.Register(F_EdicionRegistro_NET);
            CallbackManager.Register(F_EdicionModelo_NET);
            CallbackManager.Register(F_GrabarModelo_NET);
            CallbackManager.Register(F_GrabarTipoMotor_NET);
            CallbackManager.Register(F_LlenarGridDetalle_NET);
            CallbackManager.Register(F_EdicionTipoMotor_NET);
            CallbackManager.Register(F_ListarComboModels_NET);
            CallbackManager.Register(F_ListarComboMarca_NET);
        }

        private string _menu = "1000"; private string _opcion = "7";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_Marca();
            P_Inicializar_GrillaVacia_Modelo();
            Session["datos"] = true;
        }
        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlEstadoVehiculo_html = "";
            String str_ddlEstadoEdicion_html = "";
            String str_ddlAlmacen_html = "";
            String str_ddlEstadoMotor_html = "";
            String str_ddlModeloMotor_html = "";
            String str_ddlEstadoModelo_html = "";
            String str_ddlMarcaMotor_html = "";

            int int_resultado_operacion = 0;


            String str_ddlEstadoMarcaModelo_html = "";

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlEstadoVehiculo, ref ddlEstadoMarcaModelo, ref ddlModeloMotor, ref ddlEstadoMotor,
                                           ref ddlEstadoModelo, ref ddlMarcaMotor);
                
                str_ddlEstadoVehiculo_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoVehiculo);
                str_ddlModeloMotor_html = Mod_Utilitario.F_GetHtmlForControl(ddlModeloMotor);          
                str_ddlEstadoMotor_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoMotor);
                str_ddlEstadoMarcaModelo_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoMarcaModelo);
                str_ddlEstadoModelo_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoModelo);
                str_ddlMarcaMotor_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarcaMotor);
                
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
            str_ddlEstadoVehiculo_html + "~" + //2
            str_ddlEstadoEdicion_html + "~" + //3
            str_ddlEstadoMarcaModelo_html + "~" + //4
            str_ddlModeloMotor_html + "~" + //5
            str_ddlAlmacen_html + "~" + //6
            str_ddlEstadoMotor_html + "~" +  //7

            str_ddlEstadoModelo_html + "~" +   //8
            str_ddlMarcaMotor_html; //9
            return str_resultado;
        }
        public String F_ListarComboModels_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_ddlModeloMotor_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ListarNroCuenta(obj_parametros, ref ddlModeloMotor);

                str_ddlModeloMotor_html = Mod_Utilitario.F_GetHtmlForControl(ddlModeloMotor);

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
                str_ddlModeloMotor_html;

            return str_resultado;

        }

        public String F_ListarComboMarca_NET(String arg)
        { //FUNCION QUE ACTUALIZA EL COMBO MARCA
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_ddlEstadoMarcaModelo_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ListarNroCuenta_Marca(obj_parametros, ref ddlEstadoMarcaModelo);

                str_ddlEstadoMarcaModelo_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoMarcaModelo);

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
                str_ddlEstadoMarcaModelo_html;

            return str_resultado;
        }

        public void P_ListarNroCuenta_Marca(Hashtable objTablaFiltro, //FUNCION ENCARGADA DE HACER EL SELECT DEL COMBO MARCA, PROCEDIMIENTO ALMACENADO REUTILIZADO DE P_Controles_Inicializar
          ref DropDownList ddlEstadoMarcaModelo)
        {
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
            DataTable dta_consulta = null;

            objOperacionConceptosDet = new TCConceptosDetCN();

            dta_consulta = null;

            dta_consulta = objOperacionConceptosDet.F_Marca_Combo();

            ddlEstadoMarcaModelo.Items.Clear();

            ddlEstadoMarcaModelo.DataSource = dta_consulta;
            ddlEstadoMarcaModelo.DataTextField = "Descripcion";
            ddlEstadoMarcaModelo.DataValueField = "CodVehiculo";
            ddlEstadoMarcaModelo.DataBind();

        }

        public void P_ListarNroCuenta(Hashtable objTablaFiltro,
          ref DropDownList ddlModeloMotor)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;
            DataTable dta_consulta = null;
            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculo"]);


            objOperacion = new TCCuentaCorrienteCN();

            dta_consulta = null;

            dta_consulta = objOperacion.F_Listar_Modelo_Combo(objEntidad);

            ddlModeloMotor.Items.Clear();

            ddlModeloMotor.DataSource = dta_consulta;
            ddlModeloMotor.DataTextField = "Descripcion";
            ddlModeloMotor.DataValueField = "CodModelo";
            ddlModeloMotor.DataBind();

        }


        public String F_Buscar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;
            int CodMarcaVehiculo = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar(obj_parametros, ref grvConsulta, ref CodMarcaVehiculo);
                if (grvConsulta.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Marca();
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
                str_grvConsulta_html
                 + "~" +
                CodMarcaVehiculo.ToString() ;


            return str_resultado;

        }

        public String F_LlenarGridModelo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsultaModelo_html = "";


            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                int z = grvConsulta.Rows.Count;
                P_Buscar_Modelo(obj_parametros, ref grvConsultaModelo);
                if (grvConsultaModelo.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Modelo();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                {

                    str_mensaje_operacion = "";
                }

                str_grvConsultaModelo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaModelo);

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
                str_grvConsultaModelo_html;


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

                GridView grvTipoMotor = (GridView)grvConsultaModelo.Rows[0].FindControl("grvTipoMotor");
                //Codigo = 0;
                if (Codigo > 0)
                {


                    TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
                    TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();

                    objEntidad.CodModelo = Codigo;
                    grvTipoMotor.DataSource = objOperacion.LGMarca_TipoMotor_Listado(objEntidad);



                    grvTipoMotor.DataBind();
                }

                if (grvTipoMotor.Rows.Count == 0)
                {
                    //grvTipoMotor = (GridView)grvConsultaModelo.Rows[0].FindControl("grvTipoMotor");
                    str_mensaje_operacion = "No se encontraron registros.";


                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;

                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Item", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodMotor", typeof(string));
                    dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
                    dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
                    dta_consultaarticulo.Columns.Add("Almacen", typeof(string));
                    dta_consultaarticulo.Columns.Add("Estado", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodAlmacen", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodModelo", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodVehiculo", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";

                    dta_consultaarticulo.Rows.Add(dtr_consultafila);
                    grvTipoMotor.DataSource = dta_consultaarticulo;
                    grvTipoMotor.DataBind();
                    //grvConsulta.DataBind();
                }





                str_grv_Correo_html = Mod_Utilitario.F_GetHtmlForControl(grvTipoMotor);
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
            int CodMarcaVehiculo = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EditarRegistro(obj_parametros, ref MsgError);
                P_Buscar(obj_parametros, ref grvConsulta, ref CodMarcaVehiculo);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Marca();
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

        public String F_EdicionModelo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";

            int int_resultado_operacion = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EditarModelo(obj_parametros, ref MsgError);

                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Marca();

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

        public String F_EdicionTipoMotor_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";

            int int_resultado_operacion = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EditarMotor(obj_parametros, ref MsgError);

                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Marca();

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

        public String F_GrabarMarca_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarMarca(obj_parametros, ref str_mensaje_operacion);
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

        public String F_GrabarModelo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarModelo(obj_parametros, ref str_mensaje_operacion);
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

        public String F_GrabarTipoMotor_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarTipoMotor(obj_parametros, ref str_mensaje_operacion);
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

        public String F_EliminarMarca_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;
            int CodMarcaVehiculo = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarMarca(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta, ref CodMarcaVehiculo);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Marca();

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

        public String F_EliminarModelo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;
            int CodMarcaVehiculo = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarModelo(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta, ref CodMarcaVehiculo);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Marca();

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

        public String F_EliminarTipoMotor_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;
            int CodMarcaVehiculo = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarTipoMotor(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta, ref CodMarcaVehiculo);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Marca();

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

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddlEstadoVehiculo, ref DropDownList ddlEstadoMarcaModelo,                                                  ref DropDownList ddlModeloMotor, ref DropDownList ddlEstadoMotor,ref DropDownList ddlEstadoModelo, ref DropDownList ddlMarcaMotor)                    
        {
            DataTable dta_consulta = null;

            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();

            objEntidadConceptosDet.CodConcepto = 27;

            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddlEstadoVehiculo.Items.Clear();

            ddlEstadoVehiculo.DataSource = dta_consulta;
            ddlEstadoVehiculo.DataTextField = "DscAbvConcepto";
            ddlEstadoVehiculo.DataValueField = "CodConcepto";
            ddlEstadoVehiculo.DataBind();

            ddlEstadoMotor.Items.Clear();

            ddlEstadoMotor.DataSource = dta_consulta;
            ddlEstadoMotor.DataTextField = "DscAbvConcepto";
            ddlEstadoMotor.DataValueField = "CodConcepto";
            ddlEstadoMotor.DataBind();

            ddlEstadoModelo.Items.Clear();

            ddlEstadoModelo.DataSource = dta_consulta;
            ddlEstadoModelo.DataTextField = "DscAbvConcepto";
            ddlEstadoModelo.DataValueField = "CodConcepto";
            ddlEstadoModelo.DataBind();

            ddlEstadoMarcaModelo.Items.Clear();

            dta_consulta = objOperacionConceptosDet.F_Marca_Combo();

            ddlEstadoMarcaModelo.Items.Clear();

            ddlEstadoMarcaModelo.DataSource = dta_consulta;
            ddlEstadoMarcaModelo.DataTextField = "Descripcion";
            ddlEstadoMarcaModelo.DataValueField = "CodVehiculo";
            ddlEstadoMarcaModelo.DataBind();

            ddlMarcaMotor.Items.Clear();

            dta_consulta = objOperacionConceptosDet.F_Marca_Combo();

            ddlMarcaMotor.Items.Clear();

            ddlMarcaMotor.DataSource = dta_consulta;
            ddlMarcaMotor.DataTextField = "Descripcion";
            ddlMarcaMotor.DataValueField = "CodVehiculo";
            ddlMarcaMotor.DataBind();
                     
            ddlModeloMotor.Items.Clear();

            dta_consulta = objOperacionConceptosDet.F_Modelo_Combo();

            ddlModeloMotor.Items.Clear();

            ddlModeloMotor.DataSource = dta_consulta;
            ddlModeloMotor.DataTextField = "DscModelo";
            ddlModeloMotor.DataValueField = "CodModelo";
            ddlModeloMotor.DataBind();
        }

        public void P_GrabarMarca(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();


            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Insert_Marca(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_GrabarModelo(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculo"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Insert_Modelo(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_GrabarTipoMotor(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.IDModelo = Convert.ToInt32(objTablaFiltro["Filtro_IDModelo"]);
            objEntidad.DescripcionMotor = Convert.ToString(objTablaFiltro["Filtro_DescripcionMotor"]);
            objEntidad.EstadoMotor = Convert.ToInt32(objTablaFiltro["Filtro_EstadoMotor"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Insert_Motor(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar, ref Int32 CodMarcaVehiculo)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            DataTable dta_consulta = null;

            CodMarcaVehiculo = 0;

            objOperacion = new TCCuentaCorrienteCN();
            objEntidad = new TCCuentaCorrienteCE();

            dta_consulta = objOperacion.F_LGMarca_Listado(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                CodMarcaVehiculo = Convert.ToInt32(dta_consulta.Rows[0]["CodVehiculo"]);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_Buscar_Modelo(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            DataTable dta_consulta = null;

            objOperacion = new TCCuentaCorrienteCN();
            objEntidad = new TCCuentaCorrienteCE();
            objEntidad.CodVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculo"]);

            dta_consulta = objOperacion.F_LGModelo_Listado(objEntidad);
            
            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_EditarRegistro(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculo"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Actualizar_LGMarcas(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_EditarModelo(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodModelo = Convert.ToInt32(objTablaFiltro["Filtro_CodModelo"]);
            objEntidad.CodVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculo"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Editar_LGMarca_Modelo(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_EditarMotor(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodMotor = Convert.ToInt32(objTablaFiltro["Filtro_CodMotor"]);
            objEntidad.CodModelo = Convert.ToInt32(objTablaFiltro["Filtro_CodModelo"]);   
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);    
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Editar_LGMarca_Modelo_Motor(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_Inicializar_GrillaVacia_Marca()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            //dta_consultaarticulo.Columns.Add("CodFamilia", typeof(string));
            dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
            dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
            dta_consultaarticulo.Columns.Add("Estado", typeof(string));
            dta_consultaarticulo.Columns.Add("CodVehiculo", typeof(string));
            dta_consultaarticulo.Columns.Add("Item", typeof(string));


            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";
            dtr_consultafila[3] = "";
            //dtr_consultafila[4] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);
            grvConsulta.DataSource = dta_consultaarticulo;
            grvConsulta.DataBind();

        }

        public void P_Inicializar_GrillaVacia_Modelo()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();


            dta_consultaarticulo.Columns.Add("Item", typeof(string));
            dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
            dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
            dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
            dta_consultaarticulo.Columns.Add("Estado", typeof(string));
            dta_consultaarticulo.Columns.Add("CodModelo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodVehiculo", typeof(string));
            //DescripcionMarca, es el alias que se le es definido a la columna Descripcion de la tabla VehiculoMarca en el procedimiento almacenado 'pa_LGModelo_Listado' para que no halla repeticion con la descripcion de Modelo,
            dta_consultaarticulo.Columns.Add("DescripcionMarca", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsultaModelo.DataSource = dta_consultaarticulo;
            grvConsultaModelo.DataBind();
        }

        public void P_EliminarMarca(Hashtable objTablaFiltro, ref String Mensaje)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculo"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_LGMarca_Eliminar(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_EliminarModelo(Hashtable objTablaFiltro, ref String Mensaje)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodModelo = Convert.ToInt32(objTablaFiltro["Filtro_CodModelo"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_LGMarcas_Modelo_Eliminar(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_EliminarTipoMotor(Hashtable objTablaFiltro, ref String Mensaje)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodMotor = Convert.ToInt32(objTablaFiltro["Filtro_CodMotor"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_LGMarca_Motor_Eliminar(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        protected void grvConsultaDetalle_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                GridView grvTipoMotor = null;

                grvTipoMotor = (GridView)(e.Row.FindControl("grvTipoMotor"));


                DataTable dta_consultaarticulo = null;
                DataRow dtr_consultafila = null;
                dta_consultaarticulo = new DataTable();
                dta_consultaarticulo.Columns.Add("Item", typeof(string));
                dta_consultaarticulo.Columns.Add("CodMotor", typeof(string));
                dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
                dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
                dta_consultaarticulo.Columns.Add("Almacen", typeof(string));
                dta_consultaarticulo.Columns.Add("Estado", typeof(string));
                dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
                dta_consultaarticulo.Columns.Add("CodAlmacen", typeof(string));
                dta_consultaarticulo.Columns.Add("CodModelo", typeof(string));
                dta_consultaarticulo.Columns.Add("CodVehiculo", typeof(string));


                dtr_consultafila = dta_consultaarticulo.NewRow();

                dtr_consultafila[0] = "";
                dta_consultaarticulo.Rows.Add(dtr_consultafila);

                grvTipoMotor.DataSource = dta_consultaarticulo;
                grvTipoMotor.DataBind();

            }


        }

    }
}