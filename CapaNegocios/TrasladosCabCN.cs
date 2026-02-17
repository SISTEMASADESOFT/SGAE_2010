using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
  public class TrasladosCabCN
    {
        TrasladosCabCD obj = new TrasladosCabCD();

        public DataTable F_TrasladosCab_Impresion(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Impresion(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Impresion_Electronica(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Impresion_Electronica(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Impresion_Factura(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Impresion_Factura(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_GuiaInterna_Insert(TrasladosCabCE objEntidadBE)
        {

            try
            {

                return obj.F_TrasladosCab_GuiaInterna_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Listar_GuiaInterna(TrasladosCabCE objEntidadBE)
        {

            try
            {

                return obj.F_TrasladosCab_Listar_GuiaInterna(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_Insert(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_Insert_Alvarado(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Insert_Alvarado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_Insert_Reeim(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Insert_Reeim(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Listar(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_Anulacion(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Anulacion(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TrasladosCabCE F_TrasladosCab_Eliminacion(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Eliminacion(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TrasladosCabCE F_TrasladosCab_Eliminacion_Inventario(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Eliminacion_Inventario(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TrasladosCabCE F_TrasladosCab_Devolucion(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Devolucion(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable F_TrasladosCab_FacturarGuia(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_FacturarGuia(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
      
        public TrasladosCabCE F_Transferencias_Insert(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Transferencias_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_Transferencias_Insert_Reeim(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Transferencias_Insert_Reeim(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_Transferencias_Insert_Alvarado(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Transferencias_Insert_Alvarado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_NotaIngresoInventarioCab_Insert_Alvarado(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_NotaIngresoInventarioCab_Insert_Alvarado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Reemplazar(TrasladosCabCE objEntidadBE)
        {

            try
            {

                return obj.F_TrasladosCab_Reemplazar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_Validar_Guia(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Validar_Guia(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public DataTable F_GUIAREMISION_OBSERVACION(TrasladosCabCE objEntidadBE)
        {

            try
            {
                return obj.F_GUIAREMISION_OBSERVACION(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_GUIAREMISION_AUDITORIA(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_GUIAREMISION_AUDITORIA(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public TrasladosCabCE F_Transferencias_Insert_Salcedo(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Transferencias_Insert_Salcedo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_Insert_Salcedo(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Insert_Salcedo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_Abrir(TrasladosCabCE objEntidadBE)
        {

            try
            {

                return obj.F_TrasladosCab_Abrir(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public TrasladosCabCE F_TrasladosCab_ObtenerXNumero(TrasladosCabCE objEntidad)
        {

            try
            {
                DataTable dtDatos = obj.F_TrasladosCab_ObtenerXNumero(objEntidad);
                if (dtDatos.Rows.Count > 0)
                {
                    try
                    {
                        foreach (DataRow i in dtDatos.Rows)
                        {
                            objEntidad.CodTraslado = Convert.ToInt32(i["CodTraslado"]);
                            objEntidad.SerieDoc = i["SerieDoc"].ToString();
                            objEntidad.NumeroDoc = i["NumeroDoc"].ToString();
                            objEntidad.FechaEmision = DateTime.Parse(i["Emision"].ToString());
                            objEntidad.EmisionStr = objEntidad.FechaEmision.ToString("dd/MM/yyyy");
                            objEntidad.Observacion2 = i["Observacion2"].ToString();
                            objEntidad.CodMotivoTraslado = Convert.ToInt32(i["CodMotivoTraslado"]);
                            objEntidad.CodigoSucursalPartida = Convert.ToInt32(i["CodigoSucursalPartida"]);
                            objEntidad.NroRucPartida = i["NroRucPartida"].ToString();

                            objEntidad.ltrasladosDet = new List<TrasladosCabCE>();
                            dtDatos = (new TrasladosCabCN()).F_TrasladosCab_ListarXCodigo_Traslado_Interno_Externo(objEntidad);
                    
                            if (dtDatos.Rows.Count > 0)
                            {
                                foreach (DataRow r in dtDatos.Rows)
                                {
                                    objEntidad.ltrasladosDet.Add(new TrasladosCabCE()
                                    {
                                        CodTraslado = Convert.ToInt32(r["CodTraslado"]),
                                        CodProducto = Convert.ToInt32(r["CodArticulo"]),
                                        Cantidad = Convert.ToInt32(r["Cantidad"]),
                                        Descripcion = r["Descripcion"].ToString(),
                                        CodUnidadVenta = Convert.ToInt32(r["CodUnidadVenta"]),
                                        CodigoInterno = r["CodigoInterno"].ToString(),
                                    });
                                }
                            }
                            else
                            {
                                objEntidad.Observacion2 = "NO SE ENCONTRO NINGUNA DETALLE DE LA GUIA";
                            };

                        }
                    }

                    catch (Exception ex)
                    {
                        objEntidad.Observacion2 = "NO SE ENCONTRO NINGUNA 1";
                    }

                    finally
                    {
                    }
                }
                else
                {
                    objEntidad.Observacion2 = "NO SE ENCONTRO NINGUNA CABECERA DE LA NOTA DE INGRESO";
                };
                return objEntidad;

            }
            catch (Exception ex)
            {
                objEntidad.MsgError = ex.ToString();
                objEntidad.Observacion2 = ex.ToString();
                throw ex;
            }

        }


        public DataTable F_TrasladosCab_ListarXCodigo(TrasladosCabCE objEntidad)
        {

            try
            {

                return obj.F_TrasladosCab_ListarXCodigo(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_ListarXCodigo_Traslado_Interno_Externo(TrasladosCabCE objEntidad)
        {

            try
            {

                return obj.F_TrasladosCab_ListarXCodigo_Traslado_Interno_Externo(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_NotaingresoCab_ListarXCodigo_Traslado_Interno_Externo(TrasladosCabCE objEntidad)
        {

            try
            {

                return obj.F_NotaingresoCab_ListarXCodigo_Traslado_Interno_Externo(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public TrasladosCabCE F_TrasladosCab_Insert_Roman(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Insert_Roman(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public TrasladosCabCE F_TrasladosCab_Insert_Povis(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Insert_Povis(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public TrasladosCabCE F_TrasladosCab_Insert_Karina(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Insert_Karina(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_NotaIngresoInventarioCab_Insert_Karina(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_NotaIngresoInventarioCab_Insert_Karina(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
