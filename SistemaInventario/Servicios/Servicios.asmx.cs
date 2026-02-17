using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using CapaEntidad;
using CapaNegocios;
using System.Data;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using KeepAutomation.Barcode.Crystal;

namespace SistemaInventario.App_Code
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]

    public class Servicios : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public UsuarioCE KeepActiveSession()
        {
            bool SesionActiva = true;
            if (HttpContext.Current.Session["datos"] == null | Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]) == 0)
                SesionActiva = false;

            UsuarioCE Usuario = new UsuarioCE();

            if (Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]) > 0)
            {
                Usuario = (new UsuarioCN()).F_Usuario_Obtener(Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]));

                HttpContext.Current.Session["Usuario"] = Usuario.NombreUsuario;
                HttpContext.Current.Session["Apellidos"] = Usuario.Apellidos;
                HttpContext.Current.Session["Nombre"] = Usuario.Nombre;
                HttpContext.Current.Session["Perfil"] = Usuario.Perfil;
                HttpContext.Current.Session["CodCajaFisica"] = Usuario.CodCajaFisica.ToString();

                DataTable dtEmpresa = (new TCAlmacenCN()).F_TCAlmacen_ObtenerDatos(Convert.ToInt32(HttpContext.Current.Session["CodSede"]));

                HttpContext.Current.Session["CodEmpresa"] = Convert.ToInt32(dtEmpresa.Rows[0]["CodEmpresa"]);
                Usuario.CodEmpresa = Convert.ToInt32(dtEmpresa.Rows[0]["CodEmpresa"]);

                HttpContext.Current.Session["Empresa"] = dtEmpresa.Rows[0]["RazonSocial"];
                Usuario.Empresa = dtEmpresa.Rows[0]["RazonSocial"].ToString();

                HttpContext.Current.Session["Almacen"] = dtEmpresa.Rows[0]["DscAlmacen"];
                Usuario.Almacen = dtEmpresa.Rows[0]["DscAlmacen"].ToString();

                if (Usuario.IdImagen > 0)
                {
                    Session["ImagenUsuario"] = Usuario.ImagenUsuario;
                    Utilitarios.Menu.ImagenUsuario = (byte[])Usuario.ImagenUsuario;
                    Utilitarios.Menu.ImagenUsuarioNombre = Usuario.NombreUsuario + ".jpg";
                    Usuario.ImagenNombre = Usuario.NombreUsuario + ".jpg";
                    Utilitarios.Menu.F_ImagenUsuario();
                }
                else
                {
                    Utilitarios.Menu.ImagenUsuario = null;
                    Utilitarios.Menu.ImagenUsuarioNombre = "../Asset/images/mainuser.png";
                }
            }

            Usuario.ImagenUsuario = null; //debido a que el json no acepta una longitud de cadena demasiado grande
            Usuario.SesionActiva = SesionActiva;
            return Usuario;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarClientes_AutoComplete(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}", dtTabla.Rows[i]["CodCtaCte"],
                        dtTabla.Rows[i]["RazonSocial"], dtTabla.Rows[i]["Direccion"],
                        dtTabla.Rows[i]["DireccionEnvio"], dtTabla.Rows[i]["Distrito"], dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"],
                        dtTabla.Rows[i]["CodDistrito"],dtTabla.Rows[i]["NroRuc"], dtTabla.Rows[i]["ApePaterno"], dtTabla.Rows[i]["ApeMaterno"],
                        dtTabla.Rows[i]["Nombres"],dtTabla.Rows[i]["SaldoCreditoFavor"], dtTabla.Rows[i]["CodTipoCtaCte"],
                        dtTabla.Rows[i]["CodDireccion"], dtTabla.Rows[i]["CodVendedor"], dtTabla.Rows[i]["CodCategoria"], dtTabla.Rows[i]["NombreComercial"], 
                        dtTabla.Rows[i]["CodEmpresa"],dtTabla.Rows[i]["Placa"],dtTabla.Rows[i]["Licencia"]));
                }
            }
            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarClientes_AutoComplete_Proforma(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes_Proforma_Alvarado(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}", dtTabla.Rows[i]["CodCtaCte"],
                        dtTabla.Rows[i]["RazonSocial"], dtTabla.Rows[i]["Direccion"],
                        dtTabla.Rows[i]["DireccionEnvio"], dtTabla.Rows[i]["Distrito"], dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"],
                        dtTabla.Rows[i]["CodDistrito"], dtTabla.Rows[i]["NroRuc"], dtTabla.Rows[i]["ApePaterno"], dtTabla.Rows[i]["ApeMaterno"],
                        dtTabla.Rows[i]["Nombres"], dtTabla.Rows[i]["SaldoCreditoFavor"], dtTabla.Rows[i]["CodTipoCtaCte"],
                        dtTabla.Rows[i]["CodDireccion"], dtTabla.Rows[i]["CodVendedor"], dtTabla.Rows[i]["CodCategoria"], dtTabla.Rows[i]["NombreComercial"],
                        dtTabla.Rows[i]["CodEmpresa"], dtTabla.Rows[i]["Placa"], dtTabla.Rows[i]["Licencia"]));
                }
            }
            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarClientes_AutoComplete_Alvarado(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23}", dtTabla.Rows[i]["CodCtaCte"], dtTabla.Rows[i]["RazonSocial"], dtTabla.Rows[i]["Direccion"],
                        dtTabla.Rows[i]["DireccionEnvio"], dtTabla.Rows[i]["Distrito"], dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"],
                        dtTabla.Rows[i]["NroRuc"], dtTabla.Rows[i]["ApePaterno"], dtTabla.Rows[i]["ApeMaterno"], dtTabla.Rows[i]["Nombres"], dtTabla.Rows[i]["SaldoCreditoFavor"], dtTabla.Rows[i]["CodTipoCtaCte"],
                        dtTabla.Rows[i]["CodDireccion"], dtTabla.Rows[i]["CodVendedor"], dtTabla.Rows[i]["CodCategoria"], dtTabla.Rows[i]["NombreComercial"], dtTabla.Rows[i]["CodEmpresa"], dtTabla.Rows[i]["D1"], dtTabla.Rows[i]["D2"]
                        , dtTabla.Rows[i]["D3"], dtTabla.Rows[i]["CATEGORIA"], dtTabla.Rows[i]["CELULAR"]));
                }
            }
            return Lista.ToArray();

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarClientes_AutoComplete2(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", dtTabla.Rows[i]["CodCtaCte"], dtTabla.Rows[i]["RazonSocial"], dtTabla.Rows[i]["Direccion"],
                        dtTabla.Rows[i]["DireccionEnvio"], dtTabla.Rows[i]["Distrito"], dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], 
                        dtTabla.Rows[i]["CodDistrito"],
                        dtTabla.Rows[i]["NroRuc"], dtTabla.Rows[i]["ApePaterno"], dtTabla.Rows[i]["ApeMaterno"], dtTabla.Rows[i]["Nombres"], 
                        dtTabla.Rows[i]["SaldoCreditoFavor"], dtTabla.Rows[i]["CodTipoCtaCte"], dtTabla.Rows[i]["CodDireccion"]));
                }
            }
            return Lista.ToArray();

        }


        //[WebMethod(EnableSession = true)]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string F_WhatsAppHabilitado(int codDocumentoVenta)
        //{
        //    int CodAlmacen = Convert.ToInt32(HttpContext.Current.Session["CodSede"]);
        //    DataTable dt = new TCCuentaCorrienteCN().ValidarCredencialesWhatsApp2(CodAlmacen, codDocumentoVenta);

        //    if (dt.Rows.Count == 0)
        //        return "0";


        //    DataRow filaCredenciales = null;
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if (row["Tipo"].ToString() == "Credenciales")
        //        {
        //            filaCredenciales = row;
        //            break;
        //        }
        //    }

        //    if (filaCredenciales == null)
        //        return "0";

        //    string msgError = filaCredenciales["msgError"].ToString();
        //    if (!string.IsNullOrEmpty(msgError))
        //        return "0";


        //    DataRow filaCliente = null;
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if (row["Tipo"].ToString() == "Cliente" && !string.IsNullOrWhiteSpace(row["CelularCliente"].ToString()))
        //        {
        //            filaCliente = row;
        //            break;
        //        }
        //    }

        //    if (filaCliente == null)
        //        return "0";

        //    return "1";
        //}

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string F_WhatsAppHabilitado()
        {
            int CodAlmacen = Convert.ToInt32(HttpContext.Current.Session["CodSede"]);
            int CodEmpresa = Convert.ToInt32(HttpContext.Current.Session["CodEmpresa"]);


            DataTable dt = new TCCuentaCorrienteCN().ValidarCredencialesWhatsAppBasico(CodEmpresa, CodAlmacen);

            if (dt == null || dt.Rows.Count == 0)
                return "0";

            DataRow row = dt.Rows[0];

          
            string numeroRemitente = row["NumeroRemitente"].ToString();
            if (string.IsNullOrWhiteSpace(numeroRemitente))
                return "0";

        
            string tokenAlmacen = row["TokenWhatsAppAlmacen"].ToString();
            if (string.IsNullOrWhiteSpace(tokenAlmacen))
                return "0";


            string tokenEmpresa = row["UrlApiWhatsApp"].ToString();
            if (string.IsNullOrWhiteSpace(tokenEmpresa))
                return "0";

            return "1";
        }


        
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EnviarFacturaWhatsAppDesdeGrilla(int codDocumentoVenta)
        {
            int codUsuario = Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]);
            int codAlmacen = Convert.ToInt32(HttpContext.Current.Session["CodSede"]);
            DataTable dtCredenciales = new TCCuentaCorrienteCN().ObtenerCredencialesWhatsApp(codAlmacen);

            if (dtCredenciales.Rows.Count == 0)
                throw new Exception("No se encontraron credenciales para WhatsApp.");

            string msgError = dtCredenciales.Rows[0]["msgError"].ToString();
            if (!string.IsNullOrEmpty(msgError))
                throw new Exception(msgError);

            string token = dtCredenciales.Rows[0]["Token"].ToString();
            string remitente = dtCredenciales.Rows[0]["Numero"].ToString();
            string baseUrl = dtCredenciales.Rows[0]["BaseUrl"].ToString();
            string Mensaje = dtCredenciales.Rows[0]["Mensaje"].ToString();
            string NombreDocumento = "";
            
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            objEntidad.CodDocumentoVenta = codDocumentoVenta;
            objEntidad.CodTipoDoc = 1;
            var dt = new DocumentoVentaCabCN().F_DocumentoVentaCab_Impresion_Factura_Electronica(objEntidad);

            NombreDocumento = dt.Rows[0]["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "-" + dt.Rows[0]["T_Codigo_Tipo_Documento_Sunat"].ToString() + '-' + dt.Rows[0]["SerieDoc"].ToString() + '-' + dt.Rows[0]["NumeroDoc"].ToString() + ".pdf";

            if (dt.Rows.Count == 0)
                throw new Exception("No se encontró la factura.");
            var dr = dt.Rows[0];

            // QR
            BarCode qr = new BarCode();
            qr.Symbology = KeepAutomation.Barcode.Symbology.QRCode;
            qr.CodeToEncode = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                dr["RucEmpresa"].ToString().Replace("R.U.C. : ", ""),
                dr["T_Codigo_Tipo_Documento_Sunat"],
                dr["SerieDoc"],
                dr["NumeroDoc"],
                dr["Igv"],
                dr["Total"],
                dr["F_Fecha_Emision"],
                dr["T_Codigo_Doc_Identidad_Sunat"],
                dr["Ruc"]);
            qr.X = 6;
            qr.Y = 6;
            qr.LeftMargin = 6;
            qr.RightMargin = 6;
            qr.TopMargin = 6;
            qr.BottomMargin = 6;
            qr.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
            dt.Columns.Add("QR", typeof(byte[]));
            dr["QR"] = qr.generateBarcodeToByteArray();

            ReportDocument rpt = new ReportDocument();
            dt.TableName = dt.Rows[0]["Datatable"].ToString();
            rpt.Load(Server.MapPath("~/Reportes/" + dt.Rows[0]["FormatoRpt"].ToString()));
            rpt.SetDataSource(dt);

            using (MemoryStream ms = (MemoryStream)rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat))
            {
                var numeros = dr["CelularCliente"].ToString().Split('~');

                foreach (var numero in numeros)
                {
                    string celular = numero.Trim();
                    if (string.IsNullOrEmpty(celular))
                    {
                        throw new Exception("EL CLIENTE NO TIENE NUMERO DE CELULAR REGISTRADO");

                    }
                    if (celular.Length != 11 || !celular.StartsWith("51"))
                    {
                        throw new Exception("NUMERO DE CLIENTE INVALIDO ");
                    }

                    EnviarFacturaPorWhatsApp(ms, celular, token, remitente, baseUrl, Mensaje, NombreDocumento);
                   
                    RegistrarMensajeWhatsApp(codUsuario, codDocumentoVenta, 1, "ENVIADO AL NUMERO: " + celular, codAlmacen);

                }
            }
        }


        private void RegistrarMensajeWhatsApp(int codUsuario, int codDocumentoVenta, int codCategoria, string observacion, int codAlmacen)
        {
            try
            {

                TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();


                objOperacion.RegistrarMensajeWhatsApp(codUsuario, codDocumentoVenta, codCategoria, observacion, codAlmacen);
            }
            catch (Exception ex)
            {

            }
        }


        public void EnviarFacturaPorWhatsApp(MemoryStream msMemoria, string numeroCelular, string token, string remitente, string baseUrl, string Mensaje,string NombreDocumento)
        {
            if (msMemoria == null || msMemoria.Length == 0)
                throw new Exception("El PDF esta vacio o no se genero.");

            if (string.IsNullOrEmpty(numeroCelular))
                throw new Exception("Numero de celular no disponible.");

            //string baseUrl = ConfigurationManager.AppSettings["WHATSAPP_API_URL_BASE"];

            //string token = ConfigurationManager.AppSettings["WHATSAPP_API_TOKEN"];
            //string remitente = ConfigurationManager.AppSettings["WHATSAPP_API_REMITENTE"];

            // URL correcta url + remitente
            string apiUrl = baseUrl + remitente + "/send/file";

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // TLS 1.2 2.2 dabaproblemas

            string boundary = "----Boundary" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] trailer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Headers["Authorization"] = "Bearer " + token;

            using (Stream requestStream = request.GetRequestStream())
            {

                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                string formData = "Content-Disposition: form-data; name=\"phone\"\r\n\r\n" +
                                  numeroCelular + "@s.whatsapp.net";
                byte[] formDataBytes = Encoding.UTF8.GetBytes(formData);
                requestStream.Write(formDataBytes, 0, formDataBytes.Length);


                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                string captionData = "Content-Disposition: form-data; name=\"caption\"\r\n\r\n" +
                    //"Gracias por su compra. Le enviamos su factura en PDF.";
                                     Mensaje;
                byte[] captionDataBytes = Encoding.UTF8.GetBytes(captionData);
                requestStream.Write(captionDataBytes, 0, captionDataBytes.Length);


                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                string forwardedData = "Content-Disposition: form-data; name=\"is_forwarded\"\r\n\r\nfalse";
                byte[] forwardedDataBytes = Encoding.UTF8.GetBytes(forwardedData);
                requestStream.Write(forwardedDataBytes, 0, forwardedDataBytes.Length);

                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                //string fileHeader = "Content-Disposition: form-data; name=\"file\"; filename=\"factura.pdf\"\r\n" +
                //                    "Content-Type: application/pdf\r\n\r\n";



                string fileHeader = "Content-Disposition: form-data; name=\"file\"; filename=\""  + NombreDocumento +  " \"\r\n" +
                      "Content-Type: application/pdf\r\n\r\n";


                byte[] fileHeaderBytes = Encoding.UTF8.GetBytes(fileHeader);
                requestStream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);

                msMemoria.Position = 0;
                msMemoria.CopyTo(requestStream);

                requestStream.Write(trailer, 0, trailer.Length);
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseText = reader.ReadToEnd();

                }
            }
            catch (WebException ex)
            {
                string errorMessage = "Error al enviar WhatsApp: ";
                if (ex.Response != null)
                {
                    using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string responseContent = reader.ReadToEnd();
                        errorMessage += responseContent;


                        if (responseContent.Contains("token expired") || responseContent.Contains("invalid token"))
                        {
                            throw new Exception("Token Expirado");
                        }

                        if (responseContent.Contains("404") || responseContent.Contains("Recurso no encontrado"))
                        {
                            throw new Exception("Ejecute el Programa o Numero Remitente Incorrecto");
                        }

                    }
                }
                else
                {
                    errorMessage += ex.Message;
                }

                throw new Exception(errorMessage);
            }
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<DocumentoVentaCabCE> F_GRAFICO_ESTADISTICO_NET(int GraficoDesde, int GraficoHasta)
        {
            DocumentoVentaCabCN obj = new DocumentoVentaCabCN();
            try
            {
                DataTable dtDatos = obj.F_GRAFICO_ESTADISTICO_NET(GraficoDesde, GraficoHasta);
                List<DocumentoVentaCabCE> lDatos = new List<DocumentoVentaCabCE>();

                foreach (DataRow r in dtDatos.Rows)
                {
                    lDatos.Add(new DocumentoVentaCabCE()
                    {
                        Venta = Convert.ToDecimal(r["Total"].ToString()),
                        Meses = r["Periodo"].ToString(),
                    });
                }


                return lDatos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<DocumentoVentaCabCE> F_GRAFICO_ESTADISTICO_VENDEDOR_NET(int GraficoDesde, int GraficoHasta)
        {
            DocumentoVentaCabCN obj = new DocumentoVentaCabCN();
            try
            {
                DataTable dtDatos = obj.F_GRAFICO_ESTADISTICO_VENDEDOR_NET(GraficoDesde, GraficoHasta);
                List<DocumentoVentaCabCE> lDatos = new List<DocumentoVentaCabCE>();

                foreach (DataRow r in dtDatos.Rows)
                {
                    lDatos.Add(new DocumentoVentaCabCE()
                    {
                        Venta = Convert.ToDecimal(r["Total"].ToString()),
                        Meses = r["Vendedor"].ToString(),
                    });
                }


                return lDatos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<DocumentoVentaCabCE> F_GRAFICO_ESTADISTICO_PRODUCTOS_NET(int GraficoDesde, int GraficoHasta)
        {
            DocumentoVentaCabCN obj = new DocumentoVentaCabCN();
            try
            {
                DataTable dtDatos = obj.F_GRAFICO_ESTADISTICO_PRODUCTOS_NET(GraficoDesde, GraficoHasta);
                List<DocumentoVentaCabCE> lDatos = new List<DocumentoVentaCabCE>();

                foreach (DataRow r in dtDatos.Rows)
                {
                    lDatos.Add(new DocumentoVentaCabCE()
                    {
                        Venta = Convert.ToDecimal(r["MOVIMIENTO"].ToString()),
                        Meses = r["CodigoInterno"].ToString(),
                    });
                }


                return lDatos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<DocumentoVentaCabCE> F_GRAFICO_ESTADISTICO_SUCURSAL_NET(int GraficoDesde, int GraficoHasta)
        {
            DocumentoVentaCabCN obj = new DocumentoVentaCabCN();
            try
            {
                DataTable dtDatos = obj.F_GRAFICO_ESTADISTICO_SUCURSAL_NET(GraficoDesde, GraficoHasta);
                List<DocumentoVentaCabCE> lDatos = new List<DocumentoVentaCabCE>();

                foreach (DataRow r in dtDatos.Rows)
                {
                    lDatos.Add(new DocumentoVentaCabCE()
                    {
                        Venta = Convert.ToDecimal(r["Total"].ToString()),
                        Meses = r["SUCURSAL"].ToString(),
                    });
                }


                return lDatos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }






        //nueva lista de clients para consumir en listas multiples
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TCCuentaCorrienteCE> F_ListarClientes_AutoComplete_toList(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            List<TCCuentaCorrienteCE> lClientes = new List<TCCuentaCorrienteCE>();
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();

            foreach (DataRow r in dtTabla.Rows)
            {
                TCCuentaCorrienteCE nCli = new TCCuentaCorrienteCE();
                nCli.CodCtaCte = Convert.ToInt32(r["CodCtaCte"].ToString());
                nCli.RazonSocial = r["RazonSocial"].ToString();
                nCli.Direccion = r["Direccion"].ToString();
                nCli.DireccionEnvio = r["DireccionEnvio"].ToString();
                nCli.Distrito = r["Distrito"].ToString();
                nCli.CodDepartamento = Convert.ToInt32(r["CodDepartamento"].ToString());
                nCli.CodProvincia = Convert.ToInt32(r["CodProvincia"].ToString());
                nCli.CodDistrito = Convert.ToInt32(r["CodDistrito"].ToString());
                nCli.NroRuc = r["NroRuc"].ToString();
                nCli.CodTipoCtaCte = Convert.ToInt32(r["CodTipoCtaCte"].ToString());
                nCli.CodDireccion = Convert.ToInt32(r["CodDireccion"]);
                lClientes.Add(nCli);
            }
            return lClientes;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarClientes_Ruc_AutoComplete(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_Ruc_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", dtTabla.Rows[i]["CodCtaCte"], dtTabla.Rows[i]["RazonSocial"], dtTabla.Rows[i]["Direccion"],
                    dtTabla.Rows[i]["DireccionEnvio"], dtTabla.Rows[i]["Distrito"], dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"],
                    dtTabla.Rows[i]["NroRuc"], dtTabla.Rows[i]["ApePaterno"], dtTabla.Rows[i]["ApeMaterno"], dtTabla.Rows[i]["Nombres"], dtTabla.Rows[i]["SaldoCreditoFavor"]));
            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ValidacionCliente F_ValidarClienteCambioPrecio(string NroRuc)
        {
            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_ValidarClienteCambioPrecio(NroRuc);
            ValidacionCliente Val = new ValidacionCliente() { Resultado = Convert.ToInt32(dtTabla.Rows[0]["Valor"].ToString()) };

            return Val;
        }
        public class ValidacionCliente
        {
            public int Resultado { get; set; }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCuentaCorriente_PadronSunat(string NroRuc, int CodTipoCtaCte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = CodTipoCtaCte;
                      
            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],R["NroRuc"], R["ApePaterno"],
                R["ApeMaterno"], R["Nombres"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"],R["CodCategoria"], R["NombreComercial"]));                
            }
            return Lista.ToArray();
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCuentaCorriente_PadronSunat_Alvarado(string NroRuc, int CodTipoCtaCte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = CodTipoCtaCte;

            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"], R["NroRuc"], R["ApePaterno"],
                R["ApeMaterno"], R["Nombres"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"], R["CodCategoria"], R["NombreComercial"], R["D1"], R["D2"]
                        , R["D3"]));
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCuentaCorriente_PadronSunat_VersionAntigua(string NroRuc, int CodTipoCtaCte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = CodTipoCtaCte;

            //si es cliente busca saldo en azure
            TCCuentaCorrienteCE dtSaldosAzure = null;
            if (CodTipoCtaCte == 1)
            {
                //dtSaldosAzure = objOperacion.F_ClientesSaldos_AZURE(NroRuc);
                if (dtSaldosAzure != null)
                    if (dtSaldosAzure.Saldo == 0)
                        dtSaldosAzure = null;
            }

            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                if (dtSaldosAzure != null)
                    SaldoCreditoFavor = dtSaldosAzure.Saldo;
                else
                    SaldoCreditoFavor = Convert.ToDecimal(R["SaldoCreditoFavor"].ToString());

                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                R["NroRuc"], R["ApePaterno"], R["ApeMaterno"], R["Nombres"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"]));
            }


            //Si no encuentra nada en la tabla TCCuentaCorriente, prosigue a buscarlo en el padron sunat
            if (dtTabla.Rows.Count == 0)
            {
                dtTabla = objOperacion.F_TCCuentaCorriente_PadronSunat(objEntidad);

                foreach (DataRow R in dtTabla.Rows)
                {
                    if (dtSaldosAzure != null)
                        SaldoCreditoFavor = dtSaldosAzure.Saldo;
                    else
                        SaldoCreditoFavor = 0;

                    //Busca El CodDistrito que corresponde en la base de datos local por medio del UBIGEO
                    //Si no existe debe seguir con el mismo error
                    DataTable dtDistrito = objOperacion.F_TCDistritoBuscarXUbigeo(dtTabla.Rows[0]["CodigoUbigeo"].ToString());
                    string CodDepartamento = "0"; string CodProvincia = "0"; string CodDistrito = "0"; string Distrito = "";
                    if (dtDistrito.Rows.Count > 0)
                    {
                        CodDepartamento = dtDistrito.Rows[0]["CodDepartamento"].ToString();
                        CodProvincia = dtDistrito.Rows[0]["CodProvincia"].ToString();
                        CodDistrito = dtDistrito.Rows[0]["CodDistrito"].ToString();
                        Distrito = dtDistrito.Rows[0]["DscDistrito"].ToString();
                    }

                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", 0, R["RazonSocial"], R["Direccion"],
                        R["Direccion"], Distrito, CodDepartamento, CodProvincia, CodDistrito,
                        R["Ruc"], "", "", "", SaldoCreditoFavor, 0, 0));


                }
            }


            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCuentaCorriente_PadronSunatSinSaldo(string NroRuc, int CodTipoCtaCte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = CodTipoCtaCte;

            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                R["NroRuc"], R["ApePaterno"], R["ApeMaterno"], R["Nombres"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"]));
            }


            //Si no encuentra nada en la tabla TCCuentaCorriente, prosigue a buscarlo en el padron sunat
            if (dtTabla.Rows.Count == 0)
            {
                dtTabla = objOperacion.F_TCCuentaCorriente_PadronSunat(objEntidad);

                foreach (DataRow R in dtTabla.Rows)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", 0, R["RazonSocial"], R["Direccion"],
                        R["Direccion"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                        R["Ruc"], "", "", "", SaldoCreditoFavor, 0, 0));
                }
            }


            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_BuscarDatosPorRucDni(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_BuscarDatosPorRucDni(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], R["SaldoCreditoFavor"]));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_BuscarClientesPorRucDni(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = 1;

            //si es cliente busca saldo en azure
            TCCuentaCorrienteCE dtSaldosAzure = null;
            if (objEntidad.CodTipoCtaCte == 1)
            {
                //dtSaldosAzure = objOperacion.F_ClientesSaldos_AZURE(NroRuc);
                //if (dtSaldosAzure != null && dtSaldosAzure.Saldo == 0)
                dtSaldosAzure = null;
            }

            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_BuscarDatosPorRucDni(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                if (dtSaldosAzure != null)
                    SaldoCreditoFavor = dtSaldosAzure.Saldo;
                else
                    SaldoCreditoFavor = Convert.ToDecimal(R["SaldoCreditoFavor"].ToString());


                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"], R["CodCategoria"], R["NombreComercial"]));

            }

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_BuscarClientesPorRucDniSinSaldo(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = 1;

            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_BuscarDatosPorRucDni(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"]));
            }

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_BuscarProveedoresPorRucDni(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = 2;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_BuscarDatosPorRucDni(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], R["SaldoCreditoFavor"]));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_LGProductos_Select(string Descripcion, int CodAlmacen)
        {
            LGProductosCE objEntidad = new LGProductosCE();

            objEntidad.DscProducto = Descripcion;
            objEntidad.CodAlmacen = CodAlmacen;

            DataTable dtTabla = null;
            LGProductosCN objOperacion = new LGProductosCN();
            dtTabla = objOperacion.F_LGProductos_Select(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6}", dtTabla.Rows[i]["CodAlterno"], dtTabla.Rows[i]["DscProducto"], dtTabla.Rows[i]["StockActual"], dtTabla.Rows[i]["Costo"], dtTabla.Rows[i]["Moneda"], dtTabla.Rows[i]["CodProducto"], dtTabla.Rows[i]["NroSerie"]));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarDepartamento_AutoComplete(string Descripcion)
        {
            TCDepartamentoCE objEntidad = new TCDepartamentoCE();

            objEntidad.DscDepartamento = Descripcion;

            DataTable dtTabla = null;
            TCDepartamentoCN objOperacion = new TCDepartamentoCN();
            dtTabla = objOperacion.F_Departamento_Autocomplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["Codigo"], dtTabla.Rows[i]["Descripcion"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarProvincia_AutoComplete(string Descripcion, int Codigo)
        {
            TCProvinciaCE objEntidad = new TCProvinciaCE();

            objEntidad.CodDepartamento = Codigo;
            objEntidad.DscProvincia = Descripcion;
            DataTable dtTabla = null;
            TCProvinciaCN objOperacion = new TCProvinciaCN();
            dtTabla = objOperacion.F_Provincia_Autocomplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["Codigo"], dtTabla.Rows[i]["Descripcion"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarDistrito_AutoComplete(string Descripcion, int Codigo)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.CodProvincia = Codigo;
            objEntidad.DscDistrito = Descripcion;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_Distrito_Autocomplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["Codigo"], dtTabla.Rows[i]["Descripcion"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDistrito_Listar(string Descripcion)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.Descripcion = Descripcion;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDistrito_Listar(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3}", dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"], dtTabla.Rows[i]["DscDistrito"]));

            return Lista.ToArray();

        }





        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDistrito_ListarXCodDistrito(int CodDistrito)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.CodDistrito = CodDistrito;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDistrito_ListarXCodDistrito(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3}", dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"], dtTabla.Rows[i]["DscDistrito"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDireccion_ListarXCodDistrito(string Descripcion)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.Descripcion = Descripcion;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCodDistrito(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0}", dtTabla.Rows[i]["Direccion"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //'Direccion':'','CodDepartamento':'','CodProvincia':'','CodDistrito':'','CodCtaCte':''}
        public string[] F_TCDireccion_ListarXCodDistrito_AutoComplete(string Direccion, int CodDepartamento, int CodProvincia, int CodDistrito, int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.CodDepartamento = CodDepartamento;
            objEntidad.CodProvincia = CodProvincia;
            objEntidad.CodDistrito = CodDistrito;
            objEntidad.CodCtaCte = CodCtaCte;
            objEntidad.Direccion = Direccion;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCodDistrito_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", dtTabla.Rows[i]["CodDireccion"], dtTabla.Rows[i]["Direccion"]
                                , dtTabla.Rows[i]["CodDistrito"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDepartamento"]
                                , dtTabla.Rows[i]["Email"], dtTabla.Rows[i]["Email2"], dtTabla.Rows[i]["Email3"]
                                , dtTabla.Rows[i]["Email4"], dtTabla.Rows[i]["Email5"], dtTabla.Rows[i]["Email6"]
                                ));

            return Lista.ToArray();

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqProformasResult F_TCDireccion_ListarXCodDistritoCliente_AutoComplete(string Direccion, int CodDepartamento, int CodProvincia, int CodDistrito, int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.CodDepartamento = CodDepartamento;
            objEntidad.CodProvincia = CodProvincia;
            objEntidad.CodDistrito = CodDistrito;
            objEntidad.CodCtaCte = CodCtaCte;
            objEntidad.Direccion = Direccion;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCodDistrito_AutoComplete(objEntidad);

            jqProformasResult data = new jqProformasResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccion = int.Parse(dtTabla.Rows[i]["CodDireccion"].ToString()),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Email = dtTabla.Rows[i]["Email"].ToString()
                    }
                    );

            }

            return data;
        }
        

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqDireccionesClientesResult F_TCDireccion_ListarXCliente_AutoComplete(int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.CodCtaCte = CodCtaCte;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCliente_AutoComplete(objEntidad);

            jqDireccionesClientesResult data = new jqDireccionesClientesResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccion = int.Parse(dtTabla.Rows[i]["CodDireccion"].ToString()),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Email = dtTabla.Rows[i]["Email"].ToString()
                    }
                    );

            }

            return data;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqDireccionesClientesResult F_TCDireccion_ListarXCliente_AutoComplete_Conexion(int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.CodCtaCte = CodCtaCte;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCliente_AutoComplete_Conexion(objEntidad);

            jqDireccionesClientesResult data = new jqDireccionesClientesResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccionConexion = dtTabla.Rows[i]["CodDireccion"].ToString(),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Email = dtTabla.Rows[i]["Email"].ToString()
                    }
                    );

            }

            return data;
        }
        public class jqDireccionesClientesResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCDireccionCE> rows { get; set; }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDireccion_ListarXCodTransportista_AutoComplete(string Direccion, int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.CodCtaCte = CodCtaCte;
            objEntidad.Direccion = Direccion;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCodCtaCte_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodDireccion"], dtTabla.Rows[i]["Direccion"].ToString().Trim()));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDireccion_ObtenerAlmacen(int CodAlmacen)
        {
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            objEntidad.CodEmpresa = 3;
            objEntidad.CodAlmacen = CodAlmacen;
            DataTable dtTabla = null;

            TCAlmacenCN objOperacion = new TCAlmacenCN();
            dtTabla = objOperacion.F_TCAlmacen_Actual(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodAlmacen"], dtTabla.Rows[i]["Direccion"].ToString().Trim()));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_DocumentoVentaCab_Placas_AutoComplete(int CodCtaCte, string Placa)
        {
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            objEntidad.CodCliente = CodCtaCte;
            objEntidad.Placa1 = Placa;

            DataTable dtTabla = null;

            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            dtTabla = objOperacion.F_DocumentoVentaCab_Placas_Listar(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0}", dtTabla.Rows[i]["PLACA"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_Vehiculo_Placas_AutoComplete(string Placa)
        {
            VehiculoCE objEntidad = new VehiculoCE();
            objEntidad.Placa = Placa;

            DataTable dtTabla = null;

            VehiculoCN objOperacion = new VehiculoCN();

            dtTabla = objOperacion.F_Vehiculo_Placas_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();


            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", dtTabla.Rows[i]["PLACA"], dtTabla.Rows[i]["CodVehiculo"], dtTabla.Rows[i]["Cliente"], dtTabla.Rows[i]["Anio"],
                        dtTabla.Rows[i]["Marca"], dtTabla.Rows[i]["Modelo"], dtTabla.Rows[i]["Color"], dtTabla.Rows[i]["CodTipoVehiculo"], dtTabla.Rows[i]["CodCliente"], dtTabla.Rows[i]["CodTipoCliente"], dtTabla.Rows[i]["Chasis"], dtTabla.Rows[i]["CodTipoPlan"]));
                }
            }
            return Lista.ToArray();

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_LINEA_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_LINEA_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodLinea"], dtTabla.Rows[i]["Descripcion"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_MODELOVEHICULO_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_MODELOVEHICULO_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodModeloVehiculo"], dtTabla.Rows[i]["Modelo"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_MARCAPRODUCTO_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_MARCAPRODUCTO_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodMarcaProducto"], dtTabla.Rows[i]["Descripcion"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_Familia_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_Familia_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3}", dtTabla.Rows[i]["IDFamilia"], dtTabla.Rows[i]["DscFamilia"], dtTabla.Rows[i]["CodFamilia"], dtTabla.Rows[i]["Descripcion"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_Familia_AUTOCOMPLETE_Salcedo(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_Familia_AUTOCOMPLETE_Salcedo(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}", dtTabla.Rows[i]["IDFamilia"]
                        , dtTabla.Rows[i]["CodFamilia"], dtTabla.Rows[i]["DscFamilia"], dtTabla.Rows[i]["Descripcion"], dtTabla.Rows[i]["PermisoCodigoProducto"], dtTabla.Rows[i]["PermisoMotor"], dtTabla.Rows[i]["PermisoModeloVehiculo"], dtTabla.Rows[i]["PermisoAño"], dtTabla.Rows[i]["PermisoMarcaVehiculo"], dtTabla.Rows[i]["PermisoOtrosDetalles"], dtTabla.Rows[i]["PermisoPlato"], dtTabla.Rows[i]["PermisoDisco"], dtTabla.Rows[i]["PermisoCollarin"], dtTabla.Rows[i]["PermisoEspesor"], dtTabla.Rows[i]["PermisoMedidaA"], dtTabla.Rows[i]["PermisoMedidaB"], dtTabla.Rows[i]["PermisoMedidaC"], dtTabla.Rows[i]["PermisoMedidaD"], dtTabla.Rows[i]["PermisoPosicion"], dtTabla.Rows[i]["PermisoLado"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_Procedencia_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_Procedencia_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodProcedencia"], dtTabla.Rows[i]["Descripcion"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_Valores_AUTOCOMPLETE_Salcedo(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_Valores_AUTOCOMPLETE_Salcedo(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3}", dtTabla.Rows[i]["IDFamilia"], dtTabla.Rows[i]["CodFamilia"], dtTabla.Rows[i]["DscFamilia"], dtTabla.Rows[i]["Descripcion"]));
                }
            }
            return Lista.ToArray();
        }
        
                
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //'Direccion':'','CodDepartamento':'','CodProvincia':'','CodDistrito':'','CodCtaCte':''}
                   
            //Joel Buscar el distrito del Api
        public string[] F_Direccion_Buscar(string Ubigeo)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.Ubigeo = Ubigeo;
            
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_Direccion_Buscar(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2}", dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"]
                                , dtTabla.Rows[i]["CodDistrito"]
                                ));

            return Lista.ToArray();

        }
                
        //nueva lista de clients para consumir en listas multiples
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<LineaCreditoCE> F_TCCuentaCorriente_SaldosLineaCredito_Cliente(int CodCtaCte, int CodMoneda)
        {

            List<LineaCreditoCE> lParametros = new List<LineaCreditoCE>();
            TCCuentaCorrienteCE par = new TCCuentaCorrienteCE()
            {
                CodCtaCte = CodCtaCte,
                CodMonedaLineaCredito = CodMoneda
            };

            try
            {
                DataTable dtPermisos = (new TCCuentaCorrienteCN()).F_TCCuentaCorriente_SaldosLineaCredito_Cliente(par);

                foreach (DataRow r in dtPermisos.Rows)
                {
                    LineaCreditoCE p = new LineaCreditoCE();
                    p.Tipo = Convert.ToInt32(r["Tipo"].ToString());
                    p.Concepto = r["Concepto"].ToString();
                    p.Moneda = r["Moneda"].ToString();
                    p.Monto = Convert.ToDecimal(r["Monto"].ToString());
                    p.MontoStr = Convert.ToDecimal(r["Monto"].ToString()).ToString("##,####,##0.00");
                    p.CodMonedaLineaCredito = Convert.ToInt32(r["CodMonedaLineaCredito"].ToString());
                    lParametros.Add(p);
                }
            }
            catch (Exception)
            {
            }

            return lParametros;
        }
        
        //nueva lista de clients para consumir en listas multiples
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ParametrosCE> F_ParametrosListar(string Parametro, int CodigoMenu, int CodigoInterno)
        {
            List<ParametrosCE> lParametros = new List<ParametrosCE>();
            DataTable dtPermisos = (new TCEmpresaCN()).F_ParametrosSistemas_Listar(Parametro, CodigoMenu, CodigoInterno);

            foreach (DataRow r in dtPermisos.Rows)
            {
                ParametrosCE p = new ParametrosCE();
                p.Parametro = r["Parametro"].ToString();
                p.Valor = r["Valor"].ToString();
                lParametros.Add(p);
            }
            return lParametros;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqProformasResult F_TCDireccion_ListarTemporal(string NroRuc, string CodDocumentoVenta, int CodCtacte, string Razonsocial, int FlagTraslado, string Ubigeo, string Direccion, int Codtipodoc)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.NroRuc = NroRuc;
            objEntidad.Codtemporal = CodDocumentoVenta;
            objEntidad.CodCLiente = CodCtacte;
            objEntidad.Cliente = Razonsocial;
            objEntidad.FlagTraslado = FlagTraslado;
            objEntidad.CodUsuario = 4; 
            objEntidad.Ubigeo = Ubigeo;
            objEntidad.Direccion = Direccion;
            objEntidad.CodTipoDoc = Codtipodoc;
            //Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]); 
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarTemporal(objEntidad);

            jqProformasResult data = new jqProformasResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccion = int.Parse(dtTabla.Rows[i]["CodDireccion"].ToString()),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Temporal = int.Parse(dtTabla.Rows[i]["CodDocumentoVenta"].ToString())
                    }
                    );

            }

            return data;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqProformasResult F_TCDireccion_ListarTemporal_Proforma(string NroRuc, string CodDocumentoVenta, int CodCtacte, string Razonsocial, int FlagTraslado, string Ubigeo, string Direccion, int Codtipodoc)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.NroRuc = NroRuc;
            objEntidad.Codtemporal = CodDocumentoVenta;
            objEntidad.CodCLiente = CodCtacte;
            objEntidad.Cliente = Razonsocial;
            objEntidad.FlagTraslado = FlagTraslado;
            objEntidad.CodUsuario = 4;
            objEntidad.Ubigeo = Ubigeo;
            objEntidad.Direccion = Direccion;
            objEntidad.CodTipoDoc = Codtipodoc;
            //Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]); 
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarTemporal_Proforma(objEntidad);

            jqProformasResult data = new jqProformasResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccion = int.Parse(dtTabla.Rows[i]["CodDireccion"].ToString()),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Temporal = int.Parse(dtTabla.Rows[i]["CodDocumentoVenta"].ToString())
                    }
                    );

            }

            return data;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqProformasResult F_TCDireccionTemporal_Listar(string CodDocumentoVenta, int FlagTraslado)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.Codtemporal = CodDocumentoVenta;
            objEntidad.FlagTraslado = FlagTraslado;
            //Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]); 
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccionTemporal_Listar(objEntidad);

            jqProformasResult data = new jqProformasResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccion = int.Parse(dtTabla.Rows[i]["CodDireccion"].ToString()),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Temporal = int.Parse(dtTabla.Rows[i]["CodDocumentoVenta"].ToString())
                    }
                    );

            }

            return data;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<BancosCE> F_ListarBancos()
        {
            BancosCN objOperacionBancos = new BancosCN();
            DataTable dtTabla = null;
            dtTabla = objOperacionBancos.F_Listar_Bancos();
            List<BancosCE> bancos = new List<BancosCE>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {
                BancosCE banco = new BancosCE();
                banco.CodBanco = int.Parse(dtTabla.Rows[i]["CodBanco"].ToString());
                banco.DscBanco = dtTabla.Rows[i]["DscBanco"].ToString();
                bancos.Add(banco);
            }
            return bancos;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TCAlmacenCE> F_ListarAlmacenesExternos()
        {
            TCAlmacenCN objN = new TCAlmacenCN();
            DataTable dtTabla = objN.F_ListarAlmacenesExternos();
            List<TCAlmacenCE> almacenes = new List<TCAlmacenCE>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {
                TCAlmacenCE almacen = new TCAlmacenCE();
                almacen.CodAlmacen = int.Parse(dtTabla.Rows[i]["IdAlmacen"].ToString());
                almacen.DBDataBase = dtTabla.Rows[i]["DBDataBase"].ToString();
                almacenes.Add(almacen);
            }
            return almacenes;
        }
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Planilla_CargoCE> F_Listar_Planilla_Cargo()
        {
            Planilla_CargoCN objOperacion = new Planilla_CargoCN();
            DataTable dtTabla = null;
            dtTabla = objOperacion.F_Listar_Planilla_Cargo();
            List<Planilla_CargoCE> cargos = new List<Planilla_CargoCE>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {
                Planilla_CargoCE cargo = new Planilla_CargoCE();
                cargo.CodCargo = int.Parse(dtTabla.Rows[i]["CodCargo"].ToString());
                cargo.DscCargo = dtTabla.Rows[i]["DscCargo"].ToString();
                cargos.Add(cargo);
            }
            return cargos;
        }
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqTCAlmacenStockResult F_Consulta_Stock_Azure_NET(int CodProductoAzure, string CodigoInterno)
        {
            jqTCAlmacenStockResult data = new jqTCAlmacenStockResult();
            data.rows = new List<TCAlmacenCE>();
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            TCAlmacenCN objOperacion = new TCAlmacenCN();

            //primero se buscan los datos de conexion faltantes
            try
            {
                TCAlmacenCE par = new TCAlmacenCE();
                DataTable dtAlmacenes = (new TCAlmacenCN()).F_TCAlmacenesExternos_Listar(0);
                DataTable dtStocksAzure = (new TCAlmacenCN()).F_Consulta_Stock_Azure(CodProductoAzure, CodigoInterno);
                foreach (DataRow i in dtAlmacenes.Rows)
                {
                    if (i["FlagAlmacenLocal"].ToString() == "0")
                    {
                        TCAlmacenCE newpr = new TCAlmacenCE();
                        newpr.Empresa = i["DscEmpresa"].ToString();
                        newpr.Almacen = i["DscAlmacen"].ToString();
                        newpr.Clave = newpr.Empresa.Replace(" ", "") + "_" + newpr.Almacen.Replace(" ", "");
                        newpr.ConsultadoSN = 0;
                        newpr.Stock = 0;
                        if (dtStocksAzure.Rows.Count > 0)
                        {
                            newpr.ConsultadoSN = 1;
                            newpr.Stock = decimal.Parse(dtStocksAzure.Rows[0][i["NombreClaveAzure"].ToString()].ToString());
                        }
                        data.rows.Add(newpr);
                    }
                }


            }
            catch (Exception ex)
            { }
            finally
            { objOperacion = null; }

            return data;
        }
        public class jqTCAlmacenStockResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCAlmacenCE> rows { get; set; }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqTCAlmacenStockResult F_Consulta_Stock_Azure_NET_Salcedo(int CodProductoAzure, string CodigoInterno)
        {
            jqTCAlmacenStockResult data = new jqTCAlmacenStockResult();
            data.rows = new List<TCAlmacenCE>();
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            TCAlmacenCN objOperacion = new TCAlmacenCN();

            //primero se buscan los datos de conexion faltantes
            try
            {
                TCAlmacenCE par = new TCAlmacenCE();
                DataTable dtAlmacenes = (new TCAlmacenCN()).F_TCAlmacenesExternos_Listar(0);
                DataTable dtStocksAzure = (new TCAlmacenCN()).F_Consulta_Stock_Azure_Salcedo(CodProductoAzure, CodigoInterno);
                foreach (DataRow i in dtAlmacenes.Rows)
                {
                    if (i["FlagAlmacenLocal"].ToString() == "0")
                    {
                        TCAlmacenCE newpr = new TCAlmacenCE();
                        newpr.Empresa = i["DscEmpresa"].ToString();
                        newpr.Almacen = i["DscAlmacen"].ToString();
                        newpr.Clave = newpr.Empresa.Replace(" ", "") + "_" + newpr.Almacen.Replace(" ", "");
                        newpr.ConsultadoSN = 0;
                        newpr.Stock = 0;
                        if (dtStocksAzure.Rows.Count > 0)
                        {
                            newpr.ConsultadoSN = 1;
                            newpr.Stock = decimal.Parse(dtStocksAzure.Rows[0][i["NombreClaveAzure"].ToString()].ToString());
                        }
                        data.rows.Add(newpr);
                    }
                }


            }
            catch (Exception ex)
            { }
            finally
            { objOperacion = null; }

            return data;
        }

       
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool F_SUNAT_MarcaDocumento(int CodMovimiento, int CodRespuesta)
        {
            bool hecho = false;

            NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
            objEntidad.CodMovimiento = CodMovimiento;
            objEntidad.CodEstadoSunat = CodRespuesta;

            hecho = (new NotaIngresoSalidaCabCN()).F_SUNAT_MarcaDocumento(objEntidad);

            return hecho;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public OrdenPedidoCabCE F_Aprobar_OrdenPedido(int CodOrdenPedido, string Observacion)
        {
            var CodUsuario = Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]);
            return (new OrdenPedidoCabCN()).F_OrdenPedido_Aprobacion(CodOrdenPedido, Observacion, CodUsuario);
                        
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public OrdenPedidoCabCE F_Aprobar_OrdenPedido_Preparacion(int CodOrdenPedido, string Observacion)
        {
            var CodUsuario = Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]);
            return (new OrdenPedidoCabCN()).F_OrdenPedido_Aprobacion_Preparacion(CodOrdenPedido, Observacion, CodUsuario);

        }


        //nueva lista de clients para consumir en listas multiples
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<FormatoImpresionCE> F_FormatoImpresion_Listar(int CodTipoDoc, string SerieDoc)
        {
            List<FormatoImpresionCE> lParametros = new List<FormatoImpresionCE>();
            FormatoImpresionCE entidadFormatoImpresion = new FormatoImpresionCE();
            entidadFormatoImpresion.CodTipoDoc = CodTipoDoc;
            entidadFormatoImpresion.SerieDoc = SerieDoc;
            DataTable datos = (new FormatoImpresionCN()).F_FormatoImpresion_Listar_X_CodTipoDoc(entidadFormatoImpresion);

            foreach (DataRow r in datos.Rows)
            {
                FormatoImpresionCE p = new FormatoImpresionCE();
                p.Formato = r["Formato"].ToString();
                p.CodFormatoImpresion = Convert.ToInt32(r["CodFormatoImpresion"].ToString());
                p.CodTipoFormato = Convert.ToInt32(r["CodTipoFormato"].ToString());
                p.CodTipoDoc = Convert.ToInt32(r["CodTipoDoc"].ToString());
                p.SerieDoc = r["SerieDoc"].ToString();
                p.NombreArchivo = r["NombreArchivo"].ToString();
                p.Impresora = r["Impresora"].ToString();
                p.DataTable = r["DataTable"].ToString();
                p.NroCopias = Convert.ToInt32(r["NroCopias"].ToString());
                p.FlagDefecto = Convert.ToInt32(r["FlagDefecto"].ToString());
                lParametros.Add(p);
            }
            return lParametros;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<FormatoImpresionCE> F_FormatoImpresion_Listar_NotaIngreso(int CodTipoDoc)
        {
            List<FormatoImpresionCE> lParametros = new List<FormatoImpresionCE>();
            FormatoImpresionCE entidadFormatoImpresion = new FormatoImpresionCE();
            entidadFormatoImpresion.CodTipoDoc = CodTipoDoc;
            DataTable datos = (new FormatoImpresionCN()).F_FormatoImpresion_Listar_X_CodTipoDoc(entidadFormatoImpresion);

            foreach (DataRow r in datos.Rows)
            {
                FormatoImpresionCE p = new FormatoImpresionCE();
                p.Formato = r["Formato"].ToString();
                p.CodFormatoImpresion = Convert.ToInt32(r["CodFormatoImpresion"].ToString());
                p.CodTipoFormato = Convert.ToInt32(r["CodTipoFormato"].ToString());
                p.CodTipoDoc = Convert.ToInt32(r["CodTipoDoc"].ToString());
                p.SerieDoc = r["SerieDoc"].ToString();
                p.NombreArchivo = r["NombreArchivo"].ToString();
                p.Impresora = r["Impresora"].ToString();
                p.DataTable = r["DataTable"].ToString();
                p.NroCopias = Convert.ToInt32(r["NroCopias"].ToString());
                p.FlagDefecto = Convert.ToInt32(r["FlagDefecto"].ToString());
                lParametros.Add(p);
            }
            return lParametros;
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarFamilias_AutoComplete(string DscFamilia)
        {
            LGFamiliasCE objEntidad = new LGFamiliasCE();

            objEntidad.DscFamilia = DscFamilia;


            DataTable dtTabla = null;
            LGFamiliasCN objOperacion = new LGFamiliasCN();
            dtTabla = objOperacion.F_ListarFamilias_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5}",
                    dtTabla.Rows[i]["IDFamilia"], dtTabla.Rows[i]["CodFamilia"], dtTabla.Rows[i]["DscFamilia"],
                    dtTabla.Rows[i]["CodEmpresa"], dtTabla.Rows[i]["CodEstado"], dtTabla.Rows[i]["CodUsuario"]));
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarMarca_AutoComplete(string DescripcionMarcaProducto)
        {
            LGProductosCE objEntidad = new LGProductosCE();

            objEntidad.DescripcionMarcaProducto = DescripcionMarcaProducto;


            DataTable dtTabla = null;
            LGProductosCN objOperacion = new LGProductosCN();
            dtTabla = objOperacion.F_ListarMarca_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3}",
                    dtTabla.Rows[i]["CodMarcaProducto"], dtTabla.Rows[i]["CodigoMarcaProducto"], dtTabla.Rows[i]["Descripcion"],
                    dtTabla.Rows[i]["CodEstado"]));
            return Lista.ToArray();
        }


        //Joel Buscar el url y el token
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_API_RUC_Buscar()
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_API_RUC_Buscar(Convert.ToInt32(HttpContext.Current.Session["CodEmpresa"]));
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["urlapisunat"], dtTabla.Rows[i]["tokenapisunat"]
                                ));

            return Lista.ToArray();
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_Proveedor_Listar(string Descripcion)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.Descripcion = Descripcion;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_Proveedor_Listar(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodCtaCte"], dtTabla.Rows[i]["RazonSocial"]));

            return Lista.ToArray();

        }

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string[] F_LGFamiliasTipoProducto_AUTOCOMPLETE(string TipoProducto)
        //{
        //    TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
                      
        //    objEntidad.TipoProducto = TipoProducto;
         
        //    DataTable dtTabla = null;
        //    TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
        //    dtTabla = objOperacion.F_LGFamiliasTipoProducto_AUTOCOMPLETE(objEntidad);
        //    List<string> Lista = new List<string>();

        //    if (dtTabla.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dtTabla.Rows.Count; i++)
        //        {
        //            Lista.Add(string.Format("{0},{1},{2},{3}", dtTabla.Rows[i]["CodTipoProducto"], dtTabla.Rows[i]["Descripcion"], dtTabla.Rows[i]["TipoProducto"],
        //                dtTabla.Rows[i]["Codigo"]));
        //        }
        //    }
        //    return Lista.ToArray();

        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_LGFamiliasTipoProducto_AUTOCOMPLETE(string TipoProducto)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            objEntidad.TipoProducto = TipoProducto;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_LGFamiliasTipoProducto_AUTOCOMPLETE(objEntidad);

            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4}",
                        dtTabla.Rows[i]["CodTipoProducto"],    
                        dtTabla.Rows[i]["Descripcion"],        
                        dtTabla.Rows[i]["Codigo"],             
                        dtTabla.Rows[i]["IDFamilia"],
                        dtTabla.Rows[i]["TipoProducto"]
                    ));
                }
            }
            return Lista.ToArray();
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqProformasResult F_DestinoGuiaInterna(int CodTipoDoc)
        {
            TCAlmacenCN objOperacion = new TCAlmacenCN();
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            objEntidad.CodTipoDoc = Convert.ToInt32(CodTipoDoc);
            objEntidad.CodEstado = 1;
            objEntidad.CodAlmacen = Convert.ToInt32(HttpContext.Current.Session["CodSede"]);
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DestinoGuiaIntera(objEntidad);

            jqProformasResult data2 = new jqProformasResult();
            data2.rows2 = new List<TCAlmacenCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data2.rows2.Add(
                    new TCAlmacenCE()
                    {
                        CodCtaCte = int.Parse(dtTabla.Rows[i]["CodCtaCte"].ToString()),
                        Proveedor = dtTabla.Rows[i]["Proveedor"].ToString(),
                        NroRuc = dtTabla.Rows[i]["NroRuc"].ToString()
                    }
                    );

            }

            return data2;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCUENTACORRIENTE_ENTER_ONBLUR(string NroRuc, int CodTipoCtaCte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = CodTipoCtaCte;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCUENTACORRIENTE_ENTER_ONBLUR(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {


                Lista.Add(string.Format("{0},{1}", R["CodCtaCte"], R["RazonSocial"]));

            }

            return Lista.ToArray();
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCUENTACORRIENTE_ENTER_ONBLUR_PROFORMA(string NroRuc, int CodTipoCtaCte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = CodTipoCtaCte;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCUENTACORRIENTE_ENTER_ONBLUR_PROFORMA(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {


                Lista.Add(string.Format("{0},{1}", R["CodCtaCte"], R["RazonSocial"]));

            }

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_REFERENCIA_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_REFERENCIA_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodReferencia"], dtTabla.Rows[i]["Descripcion"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_CODPRODUCTO_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_CODPRODUCTO_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5}", dtTabla.Rows[i]["CodProducto"], dtTabla.Rows[i]["Descripcion"], dtTabla.Rows[i]["CodMarca"]
                        , dtTabla.Rows[i]["Marca"], dtTabla.Rows[i]["IDFamilia"], dtTabla.Rows[i]["Familia"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_FamiliaPRODUCTO_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_FamiliaPRODUCTO_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["IDFamilia"], dtTabla.Rows[i]["DscFamilia"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ReturnXML DescargarXML(long CodArchivoSunatXML)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string uBase = appSettings["API_URL_SUNAT_DOWNLOAD_XML"];
            string uEndp = "api/DownloadXML?CodArchivoSunatXML=" + CodArchivoSunatXML.ToString() + "&tipo=rpta&parte=0";

            string urlWAPI = string.Format("{0}{1}", uBase, uEndp);
            string result = "";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlWAPI);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            string strJSON = ""; // Asegúrate de proporcionar tu JSON aquí

            // Convertir el JSON a bytes
            byte[] data = Encoding.UTF8.GetBytes(strJSON);

            // Establecer la longitud de los datos en el encabezado
            httpWebRequest.ContentLength = data.Length;

            using (Stream stream = httpWebRequest.GetRequestStream())
            {
                // Escribir los datos en el cuerpo de la solicitud
                stream.Write(data, 0, data.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string responseString = reader.ReadToEnd();
                            result = responseString;
                            // Ahora puedes trabajar con el contenido de la respuesta (responseString).
                        }
                    }
                }
            }

            ReturnXML returnXML = JsonConvert.DeserializeObject<ReturnXML>(result);

            return returnXML;
        }
        
        public class ReturnXML
        {
            public int ArchivoPartes { get; set; }
            public int Parte { get; set; }
            public string ArchivoEnvB64 { get; set; }
            public string ArchivoRptaB64 { get; set; }
            public string NombreArchivo { get; set; }
            public bool IsOK { get; set; }
        }

        public class jqProformasResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCDireccionCE> rows { get; set; }
            public List<TCAlmacenCE> rows2 { get; set; }
        }
    }
}
