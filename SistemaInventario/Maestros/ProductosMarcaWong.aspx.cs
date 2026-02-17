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
    public partial class ProductosMarcaWong : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_LlenarGridPais_NET);
            CallbackManager.Register(F_EliminarProductoMarca_NET);
            CallbackManager.Register(F_EliminarPais_NET);
            CallbackManager.Register(F_GrabarProductoMarca_NET);
            CallbackManager.Register(F_EdicionRegistro_NET);
            CallbackManager.Register(F_EdicionPais_NET);
            CallbackManager.Register(F_GrabarPais_NET);
            //CallbackManager.Register(F_ListarComboProductoMarca_NET);
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
            String str_ddlEstadoMarca_html = "";
            String str_ddlEstadoEdicion_html = "";
            String str_ddlEstadoPais_html = "";

            int int_resultado_operacion = 0;


            String str_ddlEstadoMarcaPPais_html = "";

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlEstadoMarca, ref ddlEstadoPais);
                                          
                str_ddlEstadoMarca_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoMarca);             
                str_ddlEstadoPais_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoPais);

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
            str_ddlEstadoMarca_html + "~" + //2   
            str_ddlEstadoPais_html;//3
            return str_resultado;
        }

        //public String F_ListarComboProductoMarca_NET(String arg)
        //{ //FUNCION QUE ACTUALIZA EL COMBO PRODUCTOMARCA
        //    String str_resultado = "";
        //    String str_mensaje_operacion = "";
        //    int int_resultado_operacion = 0;
        //    String str_ddlEstadoMarcaPPais_html = "";
        //    Hashtable obj_parametros = null;

        //    try
        //    {
        //        obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
        //        P_ListarNroCuenta_ProductoMarca(obj_parametros, ref ddlEstadoMarcaPPais);

        //        str_ddlEstadoMarcaPPais_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoMarcaPPais);

        //        int_resultado_operacion = 1;
        //        str_mensaje_operacion = "";
        //    }
        //    catch (Exception ex)
        //    {

        //        str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
        //        int_resultado_operacion = 0;

        //    }

        //    str_resultado =
        //        Convert.ToString(int_resultado_operacion)
        //        + "~" +
        //        str_mensaje_operacion
        //        + "~" +
        //        str_ddlEstadoMarcaPPais_html;

        //    return str_resultado;
        //}

        public void P_ListarNroCuenta_ProductoMarca(Hashtable objTablaFiltro, //FUNCION ENCARGADA DE HACER EL SELECT DEL COMBO PRODUCTOMARCA, PROCEDIMIENTO ALMACENADO REUTILIZADO DE P_Controles_Inicializar
          ref DropDownList ddlEstadoMarcaPPais)
        {
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
            DataTable dta_consulta = null;

            objOperacionConceptosDet = new TCConceptosDetCN();

            dta_consulta = null;

            dta_consulta = objOperacionConceptosDet.F_ProductoMarca_Combo();

            ddlEstadoMarcaPPais.Items.Clear();

            ddlEstadoMarcaPPais.DataSource = dta_consulta;
            ddlEstadoMarcaPPais.DataTextField = "Descripcion";
            ddlEstadoMarcaPPais.DataValueField = "CodMarca";
            ddlEstadoMarcaPPais.DataBind();

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
                str_grvConsulta_html;


            return str_resultado;

        }

        public String F_LlenarGridPais_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsultaPais_html = "";


            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                int z = grvConsulta.Rows.Count;
                P_Buscar_Pais(obj_parametros, ref grvConsultaPais);
                if (grvConsultaPais.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Modelo();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                {

                    str_mensaje_operacion = "";
                }

                str_grvConsultaPais_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaPais);

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
                str_grvConsultaPais_html;


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

        public String F_EdicionPais_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";

            int int_resultado_operacion = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EditarPais(obj_parametros, ref MsgError);

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

        public String F_GrabarProductoMarca_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarProductoMarca(obj_parametros, ref str_mensaje_operacion);
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

        public String F_GrabarPais_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarPais(obj_parametros, ref str_mensaje_operacion);
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

        public String F_EliminarProductoMarca_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarProductoMarca(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
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

        public String F_EliminarPais_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarPais(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
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

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddlEstadoMarca, ref DropDownList ddlEstadoPais)               {
            DataTable dta_consulta = null;

            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
                        
            objEntidadConceptosDet.CodConcepto = 27;

            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddlEstadoMarca.Items.Clear();

            ddlEstadoMarca.DataSource = dta_consulta;
            ddlEstadoMarca.DataTextField = "DscAbvConcepto";
            ddlEstadoMarca.DataValueField = "CodConcepto";
            ddlEstadoMarca.DataBind();


            ddlEstadoPais.Items.Clear();


            ddlEstadoPais.DataSource = dta_consulta;
            ddlEstadoPais.DataTextField = "DscAbvConcepto";
            ddlEstadoPais.DataValueField = "CodConcepto";
            ddlEstadoPais.DataBind();
        }

        public void P_GrabarProductoMarca(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();


            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Insert_ProductoMarca(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_GrabarPais(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();
                    
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Insert_Pais(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            DataTable dta_consulta = null;

            objOperacion = new TCCuentaCorrienteCN();
            objEntidad = new TCCuentaCorrienteCE();


            dta_consulta = objOperacion.F_LGProductoMarca_Listado(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_Buscar_Pais(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {           
            TCCuentaCorrienteCN objOperacion = null;

            DataTable dta_consulta = null;

            objOperacion = new TCCuentaCorrienteCN();  

            dta_consulta = objOperacion.F_LGPais_Listado();

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_EditarRegistro(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodMarca = Convert.ToInt32(objTablaFiltro["Filtro_CodMarca"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Actualizar_LGProductoMarcas(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_EditarPais(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodPais = Convert.ToInt32(objTablaFiltro["Filtro_CodPais"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_Editar_LGMarca_Pais(objEntidad);

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
            dta_consultaarticulo.Columns.Add("CodMarca", typeof(string));
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
            dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
            dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
            dta_consultaarticulo.Columns.Add("Estado", typeof(string));
            dta_consultaarticulo.Columns.Add("CodPais", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsultaPais.DataSource = dta_consultaarticulo;
            grvConsultaPais.DataBind();
        }

        public void P_EliminarProductoMarca(Hashtable objTablaFiltro, ref String Mensaje)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodMarca = Convert.ToInt32(objTablaFiltro["Filtro_CodMarca"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_LGProductoMarca_Eliminar(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_EliminarPais(Hashtable objTablaFiltro, ref String Mensaje)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodPais = Convert.ToInt32(objTablaFiltro["Filtro_CodPais"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_LGMarcas_Pais_Eliminar(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

    }
}