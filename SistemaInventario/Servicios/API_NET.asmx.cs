using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;
using CapaEntidad;
using CapaNegocios;
using System.Data;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.IO;

namespace SistemaInventario.Servicios
{
    /// <summary>
    /// Descripción breve de API_NET
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class API_NET : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string API(string tipo, string controller, string parametros)
        {
            string urlWAPI = "https://localhost:44393/" + controller; //api/Inventario/Consultas/GetKardex
            string result = "";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlWAPI);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = tipo;
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(parametros);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex) { }
            //respuesta = UT.Utilidades.Serializable.sDeserializeArchivoSunatXML(result);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public configuration GET_API_CONFIGURATION()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string uBase = appSettings["API_URL_BASE"];
            string uSegi = appSettings["API_URL_SEGI"];

            configuration con = new configuration();
            con.urlBase = uBase;
            con.urlSegi = uSegi;
            return con;
        }
    }

    public class configuration {
        public string urlBase { get; set; }
        public string urlSegi { get; set; }
    }

}
