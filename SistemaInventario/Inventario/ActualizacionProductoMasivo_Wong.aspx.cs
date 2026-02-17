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
    public partial class ActualizacionProductoMasivo_Wong : System.Web.UI.Page
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

            //DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();
            //dtValidacionesProductos = objOperacion.F_RegistroAjustes_VALIDACIONES_EXCEL2(Convert.ToInt64(HiddenField1.Value));
            //if (dtValidacionesProductos.Rows.Count > 0)
            //{
            //    grvDetalleArticulo.DataSource = dtValidacionesProductos;
            //    grvDetalleArticulo.DataBind();

            //    Label3.Text = "SE ENCONTRARON DIFERENTES ERRORES";
            //    Label3.BackColor = Color.Black;
            //    Label3.BackColor = Color.Orange;

            //    return;
            //}

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

        protected void btnFormato_Click(object sender, EventArgs e)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;
            objOperacion = new DocumentoVentaCabCN();
            objEntidad = new DocumentoVentaCabCE();
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_ObtenerFormatoActualizacionMasiva();

            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("PRODUCTO");

                if (dtTabla.Rows.Count == 0)
                {
                    DataRow dr = dtTabla.NewRow();
                    for (int i = 0; i < dtTabla.Columns.Count; i++)
                    {
                        dr[i] = "";
                    }
                    dtTabla.Rows.Add(dr);
                }
                else
                {
                    ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
                    ws.Cells[ws.Dimension.Address].AutoFitColumns();
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    pck.SaveAs(ms);
                    ms.Position = 0;

                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=ActualizacionMasivaFormato.xlsx");
                    Response.BinaryWrite(ms.ToArray());
                    Response.Flush();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
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
                        var worksheet = package.Workbook.Worksheets["PRODUCTO"]; // El índice Inventario representa la primera hoja del archivo Excel

                        Dictionary<string, int> indiceColumnas = new Dictionary<string, int>();

                        for (int columna = worksheet.Dimension.Start.Column;
                                 columna <= worksheet.Dimension.End.Column; columna++)
                        {
                            string titulo = worksheet.Cells[1, columna].Text.Trim().ToUpper();

                            if (!string.IsNullOrEmpty(titulo))
                            {
                                indiceColumnas[titulo] = columna;
                            }
                        }



                        string sqlConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                        {
                            connection.Open();

                            for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                            {
                                // Obtener los valores de las celdas
                                //string CODIGOUNICO = worksheet.Cells[row, 1].Text;
                                //string DESCRIPCION = worksheet.Cells[row, 2].Text;
                                //string OBSERVACION = worksheet.Cells[row, 13].Text;
                                //string MEDIDA = worksheet.Cells[row, 22].Text;
                                //string CodigoOem = worksheet.Cells[row, 24].Text;
                                //string CodigoFabrica = worksheet.Cells[row, 25].Text;
                                //string CodigoProveedor = worksheet.Cells[row, 26].Text;
                                //string Observacion2 = worksheet.Cells[row, 27].Text;


                                string CODIGOUNICO = worksheet.Cells[row, indiceColumnas["CODIGO UNICO"]].Text;
                                string DESCRIPCION = worksheet.Cells[row, indiceColumnas["DESCRIPCION"]].Text;
                                string OBSERVACION = worksheet.Cells[row, indiceColumnas["OBSERVACION"]].Text;
                                string MEDIDA = worksheet.Cells[row, indiceColumnas["MEDIDA"]].Text;
                                string CodigoOem = worksheet.Cells[row, indiceColumnas["CODIGO OEM"]].Text;
                                string CodigoFabrica = worksheet.Cells[row, indiceColumnas["CODIGO FABRICA"]].Text;
                                string CodigoProveedor = worksheet.Cells[row, indiceColumnas["CODIGO PROVEEDOR"]].Text;
                                string Observacion2 = worksheet.Cells[row, indiceColumnas["OBSERVACION 2"]].Text;


                                
                                //string MARCA = worksheet.Cells[row, 9].Text; 
                                //string UBICACION = worksheet.Cells[row, 10].Text;
                                //string FAMILIA = worksheet.Cells[row, 11].Text;
                                //string CATEGORIA = worksheet.Cells[row, 12].Text;
                                //string TIPOPRODUCTO = worksheet.Cells[row, 13].Text;
                                //string PRECIO = worksheet.Cells[row, 14].Text;
                                //string PRECIO2 = worksheet.Cells[row, 15].Text;
                                //string PRECIO3 = worksheet.Cells[row, 16].Text;
                                //string MONEDAPRECIO = worksheet.Cells[row, 17].Text;
                                //string COSTO = worksheet.Cells[row, 18].Text;
                                //string MONEDACOSTO = worksheet.Cells[row, 19].Text;
                                //string STOCK = worksheet.Cells[row, 20].Text;
                                
                              
                                //// Realizar la inserción en la base de datos
                                //string insertQuery = "INSERT INTO CargaMasivaProducto (CODIGOUNICO,DESCRIPCION,MARCA,OBSERVACION,UBICACION,FAMILIA,CATEGORIA,TIPOPRODUCTO,PRECIO,PRECIO2,PRECIO3,CODMONEDAPRECIO,COSTO,CODMONEDACOSTO,STOCK,MEDIDA,CODIGOOEM,CODIGOFABRICA,CODIGOPROVEEDOR,OBSERVACION2,IDCargaMasivaExcelCab)" +
                                //           "VALUES (@CODIGOUNICO,@DESCRIPCION,@MARCA,@OBSERVACION,@UBICACION,@FAMILIA,@CATEGORIA,@TIPOPRODUCTO,@PRECIO,@PRECIO2,@PRECIO3,@MONEDAPRECIO,@COSTO,@MONEDACOSTO,@STOCK,@MEDIDA,@CODIGOOEM,@CODIGOFABRICA,@CODIGOPROVEEDOR,@OBSERVACION2,@CodCargaMasivaCab)";

                                // Realizar la inserción en la base de datos
                                string insertQuery = "INSERT INTO CargaMasivaProducto (CODIGOUNICO,DESCRIPCION,OBSERVACION,MEDIDA,CodigoOem,CodigoFabrica,CodigoProveedor,Observacion2,IDCargaMasivaExcelCab)" +
                                           "VALUES (@CODIGOUNICO,@DESCRIPCION,@OBSERVACION,@MEDIDA,@CODIGOOEM,@CODIGOFABRICA,@CODIGOPROVEEDOR,@OBSERVACION2,@CodCargaMasivaCab)";


                                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                                {
                                    cmd.Parameters.AddWithValue("@CODIGOUNICO", CODIGOUNICO);
                                    cmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION);
                                  //  cmd.Parameters.AddWithValue("@MARCA", MARCA);
                                    cmd.Parameters.AddWithValue("@OBSERVACION", OBSERVACION);
                                  //  cmd.Parameters.AddWithValue("@UBICACION", UBICACION);
                                 //   cmd.Parameters.AddWithValue("@FAMILIA", FAMILIA);
                                   // cmd.Parameters.AddWithValue("@CATEGORIA", CATEGORIA);
                               //     cmd.Parameters.AddWithValue("@TIPOPRODUCTO", TIPOPRODUCTO);
                                    //cmd.Parameters.AddWithValue("@PRECIO", PRECIO);
                                    //cmd.Parameters.AddWithValue("@PRECIO2", PRECIO2);
                                    //cmd.Parameters.AddWithValue("@PRECIO3", PRECIO3);
                                //    cmd.Parameters.AddWithValue("@MONEDAPRECIO", MONEDAPRECIO);
                                    //cmd.Parameters.AddWithValue("@COSTO", COSTO);
                                    //cmd.Parameters.AddWithValue("@MONEDACOSTO", MONEDACOSTO);
                                    //cmd.Parameters.AddWithValue("@STOCK", STOCK);
                                    cmd.Parameters.AddWithValue("@MEDIDA", MEDIDA);
                                    cmd.Parameters.AddWithValue("@CODIGOOEM", CodigoOem);
                                    cmd.Parameters.AddWithValue("@CODIGOFABRICA", CodigoFabrica);
                                    cmd.Parameters.AddWithValue("@CODIGOPROVEEDOR", CodigoProveedor);
                                    cmd.Parameters.AddWithValue("@OBSERVACION2", Observacion2);
                                    cmd.Parameters.AddWithValue("@CodCargaMasivaCab", HiddenField1.Value);

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

            objEntidad.CodCargaMasivaCab = Convert.ToInt64(HiddenField1.Value);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]); 
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_LGPRODUCTOS_ACTUALIZACIONMASIVA_KARINA(objEntidad);

            Mensaje = objEntidad.MsgError;
            CodMovimiento = objEntidad.CodDocumentoVenta;
        }        
    }
}
