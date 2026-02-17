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

namespace SistemaInventario.Inventario
{
    public partial class CargaProductoMasivo_Chiquito : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
        }

        private string _menu = "3000"; private string _opcion = "6";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
        }
        
        protected void btnImport_Click(object sender, EventArgs e)
        {
            string Mensaje = ""; int CodMovimiento = 0;
            Label1.Text = "";
            HiddenField1.Value = DateTime.Now.ToString("yyyyMMddHHmmss");
            long IdExcel = long.Parse(HiddenField1.Value.ToString());
            MSG = "";
            dtValidacionesProductos = null;
            if (!f_Validacion())
            {               
                Label3.Text = MSG;             
                return;
            }

            btnImport.Enabled = false;
            FileUpload1.Enabled = false;

            string MensajeErrorCarga;
            ImportarExcel_EPPLUS(out MensajeErrorCarga);

            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();
            dtValidacionesProductos = objOperacion.F_RegistroAjustes_VALIDACIONES_EXCEL2(Convert.ToInt64(HiddenField1.Value));
            if (dtValidacionesProductos.Rows.Count > 0)
            {
                grvDetalleArticulo.DataSource = dtValidacionesProductos;
                grvDetalleArticulo.DataBind();

                Label3.Text = "SE ENCONTRARON DIFERENTES ERRORES";
                Label3.BackColor = Color.Black;
                Label3.BackColor = Color.Orange;

                return;
            }

            if (MensajeErrorCarga == "")
            {
                ProcedimientoTrasladar(ref Mensaje, ref CodMovimiento);
                Label1.Text = Mensaje;

                if (Mensaje.ToUpper() == "SE GRABO CORRECTAMENTE")
                {
                    HiddenField1.Value = "0";
                    Label1.Text = Mensaje;      
                }
            }
            btnImport.Enabled = true;
            FileUpload1.Enabled = true;
            return;
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
                        var worksheet = package.Workbook.Worksheets["Hoja1"]; // El índice Inventario representa la primera hoja del archivo Excel

                        string sqlConnectionString = ConfigurationManager.ConnectionStrings["AZURE"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                        {
                            connection.Open();

                            for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                            {
                                // Obtener los valores de las celdas
                                string Modelo = worksheet.Cells[row, 1].Text;
                                string ModeloAbreviado = worksheet.Cells[row, 2].Text;
                                string Descripcion = worksheet.Cells[row, 3].Text;
                                string Abreviatura = worksheet.Cells[row, 4].Text;
                                string Stock1 = worksheet.Cells[row, 5].Text;
                                string CodigoBarra = worksheet.Cells[row, 6].Text;
                                string Precio = worksheet.Cells[row, 7].Text;
                                string Precio2 = worksheet.Cells[row, 8].Text;
                                string Compatibilidad = worksheet.Cells[row, 9].Text;
                                string Opcion1 = worksheet.Cells[row, 10].Text;                                
                                string Stock2 = worksheet.Cells[row, 11].Text;

                                // Realizar la inserción en la base de datos
                                string insertQuery = "INSERT INTO CargaMasivaProducto (MODELO, MODELO_ABREBIADO, DESCRIPCION, ABREBIATURA, CODIGO_DE_BARRA, PRECIO, COMPATIBILIDAD, OPCION_1,Stock1,Stock2,CodCargaMasivaCab,Precio2)" +
                                           "VALUES (@Modelo,@ModeloAbreviado,@Descripcion,@Abreviatura,@CodigoBarra,@Precio,@Compatibilidad,@Opcion1,@Stock1,@Stock2,@CodCargaMasivaCab,@Precio2)";

                                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                                {
                                    cmd.Parameters.AddWithValue("@Modelo", Modelo);
                                    cmd.Parameters.AddWithValue("@ModeloAbreviado", ModeloAbreviado);
                                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                                    cmd.Parameters.AddWithValue("@Abreviatura", Abreviatura);
                                    cmd.Parameters.AddWithValue("@CodigoBarra", CodigoBarra);
                                    cmd.Parameters.AddWithValue("@Precio", Precio);
                                    cmd.Parameters.AddWithValue("@Compatibilidad", Compatibilidad);
                                    cmd.Parameters.AddWithValue("@Opcion1", Opcion1);
                                    cmd.Parameters.AddWithValue("@Stock1", Stock1);
                                    cmd.Parameters.AddWithValue("@Stock2", Stock2);
                                    cmd.Parameters.AddWithValue("@CodCargaMasivaCab", HiddenField1.Value);
                                    cmd.Parameters.AddWithValue("@Precio2", Precio2);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MensajeError = "Error en la lectura del excel. <p></p> " +
                                    "Descripción: " + ex.Message.ToString() + " <p></p>  <p></p> " +
                                    "Debe tener en cuenta que el documento debe tener las siguientes especificaciones:  <p></p> " +
                                    " <b>Hoja: Inventario</b>" +
                                    " Columnas: <p></p>" +
                                    " <b>[A]=Codigo, [B]=Inventario, [C]=Observacion</b>";
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
        private bool f_Validacion()
        {
            bool resp = true;

            int countVal = 0;
            MSG = "ERRORES:   ";

            if (FileUpload1.FileName.ToString() == "") {
                countVal++;
                MSG += "NO HAY ARCHIVO SELECCIONADO";
            }


            if (countVal > 0)
            {
                Label1.Text = MSG;
                resp = false;
            }


            DataTable dta_existe = (new DocumentoVentaCabCN()).F_RegistroAjustes_VerificaExcel(FileUpload1.FileName.ToString());
            if (dta_existe.Rows.Count > 0)
            {
                MSG += "|    EL DOCUMENTO YA FUE PROCESADO EL " + dta_existe.Rows[0]["FECHA2"].ToString() + " POR EL USUARIO " + dta_existe.Rows[0]["NOMBREUSUARIO"].ToString();
                countVal++;
                resp = false;
            }


            return resp;
        }

        private void ProcedimientoTrasladar(ref string Mensaje, ref int CodMovimiento)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.IDPruebasExcelCab = Convert.ToInt64(HiddenField1.Value);
            objEntidad.CodEmpresa = 3;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_RegistroAjustes_Excel_GRABAR(objEntidad);

            Mensaje = objEntidad.MsgError;
            CodMovimiento = objEntidad.CodDocumentoVenta;
        }        
    }
}
