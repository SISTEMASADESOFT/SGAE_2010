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
    public partial class CargaProductoMasivo_TEK : System.Web.UI.Page
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
            //if (!f_Validacion())
            //{               
            //    Label3.Text = MSG;             
            //    return;
            //}

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

                if (Mensaje.ToUpper() == "SE GRABO CORRECTAMENTE")
                {
                    HiddenField1.Value = "0";
                    Label1.Text = Mensaje;
                }

                return;
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
                        var worksheet = package.Workbook.Worksheets["LGProductos"]; //hoja del archivo Excel

                        string sqlConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                        {
                            connection.Open();

                            for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                            {
                                // Obtener los valores de las celdas
                                string CODIGO = worksheet.Cells[row, 1].Text;
                                string DESCRIPCION = worksheet.Cells[row, 2].Text;
                                string MARCA = worksheet.Cells[row, 3].Text;
                                string MODELO = worksheet.Cells[row, 4].Text;
                                string STOCK = worksheet.Cells[row, 5].Text;
                                string COSTO = worksheet.Cells[row, 6].Text;
                                string PRECIO = worksheet.Cells[row, 7].Text;
                                string FAMILIA = worksheet.Cells[row, 8].Text;
                                string CODDETRACCION = worksheet.Cells[row, 9].Text;


                                // Realizar la inserción en la base de datos
                                string insertQuery = "INSERT INTO CargaMasivaProducto (CODIGO, DESCRIPCION, MARCA,MODELO, STOCK, COSTO, PRECIO, FAMILIA,CODMAESTRODETRACCIONES,IDCargaMasivaExcelCab)" +
                                           "VALUES (@CODIGO,@DESCRIPCION,@MARCA,@MODELO,@STOCK,@COSTO,@PRECIO,@FAMILIA,@CODMAESTRODETRACCIONES,@CodCargaMasivaCab)";

                                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                                {
                                    cmd.Parameters.AddWithValue("@CODIGO", CODIGO);
                                    cmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION);
                                    cmd.Parameters.AddWithValue("@MARCA", MARCA);
                                    cmd.Parameters.AddWithValue("@MODELO", MODELO);
                                    cmd.Parameters.AddWithValue("@STOCK", STOCK);
                                    cmd.Parameters.AddWithValue("@COSTO", COSTO);
                                    cmd.Parameters.AddWithValue("@PRECIO", PRECIO);
                                    cmd.Parameters.AddWithValue("@FAMILIA", FAMILIA);
                                    cmd.Parameters.AddWithValue("@CODMAESTRODETRACCIONES", CODDETRACCION);
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



//        private void ImportarExcel_EPPLUS(out string MensajeError)
//        {
//            MensajeError = "";
//            string path;

//            if (FileUpload1.HasFile)
//            {
//                path = Path.Combine(Server.MapPath("~/Temporales/"), FileUpload1.FileName);
//                FileUpload1.SaveAs(path);

//                try
//                {
//                    FileInfo fileInfo = new FileInfo(path);

//                    using (var package = new ExcelPackage(fileInfo))
//                    {
//                        var worksheet = package.Workbook.Worksheets["LGProductos"];  

//                        string sqlConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
//                        using (SqlConnection connection = new SqlConnection(sqlConnectionString))
//                        {
//                            connection.Open();

//                            for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
//                            {
                                 
//                                string CodProducto = worksheet.Cells[row, 1].Text; //
//                                string CodAlterno = worksheet.Cells[row, 2].Text;
//                                string IDFamilia = worksheet.Cells[row, 5].Text;
//                                string CodTipoProducto = worksheet.Cells[row, 6].Text;
//                                string DscProducto = worksheet.Cells[row, 7].Text;
//                                string CodUnidadVenta = worksheet.Cells[row, 8].Text;
//                                string CodUsuario = worksheet.Cells[row, 12].Text;
//                                string FechaRegistro = worksheet.Cells[row, 13].Text;
//                                string CodUsuarioModificacion = worksheet.Cells[row, 14].Text;
//                                string FechaModificacion = worksheet.Cells[row, 15].Text;//
//                                string CodigoInterno = worksheet.Cells[row, 18].Text;
//                                string Precio = worksheet.Cells[row, 19].Text;
//                                string Precio2 = worksheet.Cells[row, 21].Text;
//                                string Precio3 = worksheet.Cells[row, 22].Text;
//                                string CodMoneda = worksheet.Cells[row, 23].Text;
//                                string Marca = worksheet.Cells[row, 26].Text;
//                                string Ubicacion = worksheet.Cells[row, 25].Text;
//                                string IdImagenProducto1 = worksheet.Cells[row, 30].Text;
//                                string IPRegistro = worksheet.Cells[row, 31].Text;
//                                string IPModificacion = worksheet.Cells[row, 32].Text;
//                                string CodMaestroDetracciones = worksheet.Cells[row, 28].Text;
//                                string CodEstado = worksheet.Cells[row, 33].Text;
//                                string FlagServicios = worksheet.Cells[row, 34].Text;
//                                string CantidadMayorista = worksheet.Cells[row, 35].Text;
//                                string Exclusivo = worksheet.Cells[row, 36].Text;
//                                string FlagBloqueoExclusivo = worksheet.Cells[row, 37].Text;
//                                string FlagBloqueoMayorista = worksheet.Cells[row, 39].Text;
//                                string Observacion = worksheet.Cells[row, 38].Text;

//                                if (string.IsNullOrWhiteSpace(CodProducto)) continue;

//                                string insertQuery = @"
//                            INSERT INTO CargaMasivaProducto (
//                                CodProducto, CodAlterno, IDFamilia, CodTipoProducto, DscProducto, CodUnidadVenta,
//                                CodUsuario, FechaRegistro, CodUsuarioModificacion, FechaModificacion, CodigoInterno,
//                                Precio, Precio2, Precio3, CodMoneda, Marca, Ubicacion, IdImagenProducto1,
//                                IPRegistro, IPModificacion, CodMaestroDetracciones, CodEstado, FlagServicios,
//                                CantidadMayorista, Exclusivo, FlagBloqueoExclusivo, FlagBloqueoMayorista, Observacion,
//                                IDCargaMasivaExcelCab
//                            ) VALUES (
//                                @CodProducto, @CodAlterno, @IDFamilia, @CodTipoProducto, @DscProducto, @CodUnidadVenta,
//                                @CodUsuario, @FechaRegistro, @CodUsuarioModificacion, @FechaModificacion, @CodigoInterno,
//                                @Precio, @Precio2, @Precio3, @CodMoneda, @Marca, @Ubicacion, @IdImagenProducto1,
//                                @IPRegistro, @IPModificacion, @CodMaestroDetracciones, @CodEstado, @FlagServicios,
//                                @CantidadMayorista, @Exclusivo, @FlagBloqueoExclusivo, @FlagBloqueoMayorista, @Observacion,
//                                @CodCargaMasivaCab
//                            )";

//                                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
//                                {
//                                    cmd.Parameters.AddWithValue("@CodProducto", CodProducto);
//                                    cmd.Parameters.AddWithValue("@CodAlterno", CodAlterno);
//                                    cmd.Parameters.AddWithValue("@IDFamilia", IDFamilia);
//                                    cmd.Parameters.AddWithValue("@CodTipoProducto", CodTipoProducto);
//                                    cmd.Parameters.AddWithValue("@DscProducto", DscProducto);
//                                    cmd.Parameters.AddWithValue("@CodUnidadVenta", CodUnidadVenta);
//                                    cmd.Parameters.AddWithValue("@CodUsuario", CodUsuario);
//                                    cmd.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
//                                    cmd.Parameters.AddWithValue("@CodUsuarioModificacion", CodUsuarioModificacion);
//                                    cmd.Parameters.AddWithValue("@FechaModificacion", FechaModificacion);
//                                    cmd.Parameters.AddWithValue("@CodigoInterno", CodigoInterno);
//                                    cmd.Parameters.AddWithValue("@Precio", Precio);
//                                    cmd.Parameters.AddWithValue("@Precio2", Precio2);
//                                    cmd.Parameters.AddWithValue("@Precio3", Precio3);
//                                    cmd.Parameters.AddWithValue("@CodMoneda", CodMoneda);
//                                    cmd.Parameters.AddWithValue("@Marca", Marca);
//                                    cmd.Parameters.AddWithValue("@Ubicacion", Ubicacion);
//                                    cmd.Parameters.AddWithValue("@IdImagenProducto1", IdImagenProducto1);
//                                    cmd.Parameters.AddWithValue("@IPRegistro", IPRegistro);
//                                    cmd.Parameters.AddWithValue("@IPModificacion", IPModificacion);
//                                    cmd.Parameters.AddWithValue("@CodMaestroDetracciones", CodMaestroDetracciones);
//                                    cmd.Parameters.AddWithValue("@CodEstado", CodEstado);
//                                    cmd.Parameters.AddWithValue("@FlagServicios", FlagServicios);
//                                    cmd.Parameters.AddWithValue("@CantidadMayorista", CantidadMayorista);
//                                    cmd.Parameters.AddWithValue("@Exclusivo", Exclusivo);
//                                    cmd.Parameters.AddWithValue("@FlagBloqueoExclusivo", FlagBloqueoExclusivo);
//                                    cmd.Parameters.AddWithValue("@FlagBloqueoMayorista", FlagBloqueoMayorista);
//                                    cmd.Parameters.AddWithValue("@Observacion", Observacion);
//                                    cmd.Parameters.AddWithValue("@CodCargaMasivaCab", HiddenField1.Value);

//                                    cmd.ExecuteNonQuery();
//                                }
//                            }
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MensajeError = "Error al importar el Excel:<br/>" + ex.Message;
//                    Label1.Text = MensajeError;
//                    Label1.BackColor = Color.Orange;
//                    btnImport.Enabled = false;
//                    FileUpload1.Enabled = false;
//                }
//            }
//        }




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
