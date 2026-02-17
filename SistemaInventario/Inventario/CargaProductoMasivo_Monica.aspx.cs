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
    public partial class CargaProductoMasivo_Monica : System.Web.UI.Page
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
            dtValidacionesProductos = objOperacion.F_RegistroAjustes_VALIDACIONES_CARGA_MASIVA(Convert.ToInt64(HiddenField1.Value));
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
                ProcedimientoMasivo(ref Mensaje, ref CodMovimiento);
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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            HiddenField1.Value = "0";
            Label1.Text = "";
            Label3.Text = "";
            btnImport.Enabled = true;
            FileUpload1.Enabled = true;
           
            Response.Redirect(Request.RawUrl);
        }
        
        protected void btnFormato_Click(object sender, EventArgs e)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;
            objOperacion = new DocumentoVentaCabCN();
            objEntidad = new DocumentoVentaCabCE();
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_ObtenerFormatoCargaMasiva();

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
                    Response.AddHeader("Content-Disposition", "attachment; filename=CargaMasivaFormato.xlsx");
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

                        string sqlConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                        {
                            connection.Open();

                            for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                            {
                                // Obtener los valores de las celdas
                                string CODIGOUNICO = worksheet.Cells[row, 1].Text;
                                string FAMILIA = worksheet.Cells[row, 2].Text;
                                string CODIGO = worksheet.Cells[row, 3].Text;
                                string DESCRIPCION = worksheet.Cells[row, 4].Text;
                                string MARCA = worksheet.Cells[row, 5].Text;
                                string UBICACION = worksheet.Cells[row, 6].Text;
                                string CODMONEDAPRECIO = worksheet.Cells[row, 7].Text;
                                string PRECIO1 = worksheet.Cells[row, 8].Text;
                                string PRECIO2 = worksheet.Cells[row, 9].Text;
                                string PRECIO3 = worksheet.Cells[row, 10].Text;
                                string CODMONEDACOSTO = worksheet.Cells[row, 11].Text;
                                string COSTO = worksheet.Cells[row, 12].Text;
                                string UM = worksheet.Cells[row, 13].Text;
                                string STOCK = worksheet.Cells[row, 14].Text;
                                string CATEGORIAIGV = worksheet.Cells[row, 15].Text;
                                string DESTRACCION = worksheet.Cells[row, 16].Text;
                                

                                //string CODIGOUNICO = worksheet.Cells[row, 1].Text;
                                //string Descripcion = worksheet.Cells[row, 2].Text;
                                //string Marca = worksheet.Cells[row, 3].Text;
                                //string CANTIDAD = worksheet.Cells[row, 4].Text;
                                //string Costo = worksheet.Cells[row, 5].Text.Replace("S/", "").Replace("$", "").Trim();

                                ////string Costo = worksheet.Cells[row, 5].Text;
                                //string CODMONEDACOSTO = worksheet.Cells[row, 6].Text;
                                //string Precio = worksheet.Cells[row, 7].Text;
                                //string CODMONEDAPRECIO = worksheet.Cells[row, 8].Text;
                                //string Familia = worksheet.Cells[row, 9].Text;



                                string insertQuery = @"INSERT INTO CargaMasivaProducto (
                            CODIGOUNICO, FAMILIA, CODIGO,  DESCRIPCION,
                            MARCA, UBICACION, CODMONEDAPRECIO, PRECIO, PRECIO2, PRECIO3,
                            CODMONEDACOSTO, COSTO, UM, STOCK,CodCategoriaIgv,CodDetraccion, IDCargaMasivaExcelCab)
                            VALUES (
                            @CODIGOUNICO, @FAMILIA, @CODIGO, @DESCRIPCION,
                            @MARCA, @UBICACION, @CODMONEDAPRECIO, @PRECIO, @PRECIO2, @PRECIO3,
                            @CODMONEDACOSTO, @COSTO, @UM, @STOCK,@CodCategoriaIgv,@CodDetraccion, @CodCargaMasivaCab)";

//                                string insertQuery = @"INSERT CargaMasivaProducto(CODIGOUNICO, 
//                                 Descripcion,Marca,STOCK,Costo,CODMONEDACOSTO,PRECIO,CODMONEDAPRECIO,Familia,IDCargaMasivaExcelCab)
//  
//                 VALUES (@CODIGOUNICO,@Descripcion,@Marca,@STOCK,@Costo,@CODMONEDACOSTO,@PRECIO,@CODMONEDAPRECIO,@Familia,@CodCargaMasivaCab)";


                                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                                {
                                    cmd.Parameters.AddWithValue("@CODIGOUNICO", CODIGOUNICO);
                                    cmd.Parameters.AddWithValue("@FAMILIA", FAMILIA);
                                    cmd.Parameters.AddWithValue("@CODIGO", CODIGO);
                                    cmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION);
                                    cmd.Parameters.AddWithValue("@Marca", MARCA);
                                    cmd.Parameters.AddWithValue("@UBICACION", UBICACION);
                                    cmd.Parameters.AddWithValue("@CODMONEDAPRECIO", CODMONEDAPRECIO);
                                    cmd.Parameters.AddWithValue("@PRECIO", PRECIO1);
                                    cmd.Parameters.AddWithValue("@PRECIO2", PRECIO2);
                                    cmd.Parameters.AddWithValue("@PRECIO3", PRECIO3);
                                    cmd.Parameters.AddWithValue("@CODMONEDACOSTO", CODMONEDACOSTO);
                                    cmd.Parameters.AddWithValue("@COSTO", COSTO);
                                    cmd.Parameters.AddWithValue("@UM", UM);
                                    cmd.Parameters.AddWithValue("@STOCK", STOCK);
                                    cmd.Parameters.AddWithValue("@CodCategoriaIgv", CATEGORIAIGV);
                                    cmd.Parameters.AddWithValue("@CodDetraccion", DESTRACCION);
                                    cmd.Parameters.AddWithValue("@CodCargaMasivaCab", HiddenField1.Value);




                                    //string CODIGOUNICO = worksheet.Cells[row, 1].Text;
                                    //string FAMILIA = worksheet.Cells[row, 2].Text;
                                    //string CODIGO = worksheet.Cells[row, 3].Text;
                                    //string DESCRIPCION = worksheet.Cells[row, 4].Text;
                                    //string MARCA = worksheet.Cells[row, 5].Text;
                                    //string UBICACION = worksheet.Cells[row, 6].Text;
                                    //string CODMONEDAPRECIO = worksheet.Cells[row, 7].Text;
                                    //string PRECIO1 = worksheet.Cells[row, 8].Text;
                                    //string PRECIO2 = worksheet.Cells[row, 9].Text;
                                    //string PRECIO3 = worksheet.Cells[row, 10].Text;
                                    //string CODMONEDACOSTO = worksheet.Cells[row, 11].Text;
                                    //string COSTO = worksheet.Cells[row, 12].Text;
                                    //string UM = worksheet.Cells[row, 13].Text;
                                    //string STOCK = worksheet.Cells[row, 14].Text;
                                    //string CATEGORIAIGV = worksheet.Cells[row, 15].Text;
                                    //string DESTRACCION = worksheet.Cells[row, 16].Text;
                                
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
        
        private void ProcedimientoMasivo(ref string Mensaje, ref int CodMovimiento)
        {
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodCargaMasivaCab = Convert.ToInt64(HiddenField1.Value);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_LGPRODUCTOS_CARGAMASIVA_KARINA(objEntidad);

            Mensaje = objEntidad.MsgError;
            CodMovimiento = objEntidad.CodDocumentoVenta;
        }         
    }
}
