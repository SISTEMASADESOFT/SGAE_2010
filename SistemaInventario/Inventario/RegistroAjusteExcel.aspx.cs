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
    public partial class RegistroAjusteExcel : System.Web.UI.Page
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
            dtValidacionesProductos = objOperacion.F_RegistroAjustes_VALIDACIONES_EXCEL(Convert.ToInt64(HiddenField1.Value));
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
                        Cadena = string.Format("Select [CodProducto],[Inventario],0 AS Codigo," + HiddenField1.Value + " AS IDPruebasExcelCab,'" + FileUpload1.FileName + "' AS NombreArchivo, " + Convert.ToInt32(Session["CodSede"]).ToString() + " as CodAlmacen FROM [{0}] ", "Inventario$");

                        using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
                        {
                            OleDbCommand command = new OleDbCommand(Cadena, connection);

                            connection.Open();

                            using (DbDataReader dr = command.ExecuteReader())
                            {
                                string sqlConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString))
                                {
                                    bulkCopy.DestinationTableName = "RegistroAjusteExcel";
                                    bulkCopy.ColumnMappings.Add("[CodAlmacen]", "CodAlmacen");
                                    bulkCopy.ColumnMappings.Add("[CodProducto]", "CodProducto");
                                    bulkCopy.ColumnMappings.Add("[Inventario]", "Cantidad");
                                    //bulkCopy.ColumnMappings.Add("[Codigo]", "Codigo");
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
                                            " <b>Hoja: Inventario</b>" +
                                            " Columnas: <p></p>" +
                                            " <b>[A]=CodProducto, [B]=Inventario</b>";
                            Label1.Text = MensajeError;
                            Label1.BackColor = Color.Black;
                            Label1.BackColor = Color.Orange;

                            btnImport.Enabled = false;
                            FileUpload1.Enabled = false;
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
                        var worksheet = package.Workbook.Worksheets["Inventario"]; // El índice Inventario representa la primera hoja del archivo Excel

                        string sqlConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                        {
                            connection.Open();

                            for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                            {
                                // Obtener los valores de las celdas
                                string CodProducto = worksheet.Cells[row, 1].Text;
                                string Inventario = worksheet.Cells[row, 2].Text;
                                string Observacion = worksheet.Cells[row, 3].Text;
                                string Codigo = "";
                       
                                // Realizar la inserción en la base de datos
                                string insertQuery = "INSERT INTO RegistroAjusteExcel (CodAlmacen,CodProducto,Cantidad,Observacion,Codigo,IDPruebasExcelCab,NombreArchivo) " +
                                                     "VALUES (@CodAlmacen,@CodProducto,@Inventario,@Observacion,@Codigo,@IDPruebasExcelCab,@NombreArchivo)";

                                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                                {
                                    cmd.Parameters.AddWithValue("@CodAlmacen", Convert.ToInt32(Session["CodSede"].ToString()));
                                    cmd.Parameters.AddWithValue("@CodProducto", CodProducto); // El valor 0 como se especifica en el código original
                                    cmd.Parameters.AddWithValue("@Inventario", Inventario);
                                    cmd.Parameters.AddWithValue("@Observacion", Observacion);
                                    cmd.Parameters.AddWithValue("@Codigo", Codigo);       
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
                                    "Descripción: " + ex.Message.ToString() + " <p></p>  <p></p> " +
                                    "Debe tener en cuenta que el documento debe tener las siguientes especificaciones:  <p></p> " +
                                    " <b>Hoja: Inventario</b>" +
                                    " Columnas: <p></p>" +
                                    " <b>[A]=Codigo, [B]=Inventario</b>, [C]=OBSERVACION</b>";
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
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_RegistroAjustes_Excel_GRABAR(objEntidad);

            Mensaje = objEntidad.MsgError;
            CodMovimiento = objEntidad.CodDocumentoVenta;
        }        
    }
}
