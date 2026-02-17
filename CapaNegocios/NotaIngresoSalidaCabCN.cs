using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;
namespace CapaNegocios
{
  public  class NotaIngresoSalidaCabCN
    {
      NotaIngresoSalidaCabCD obj = new NotaIngresoSalidaCabCD();

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_FacturacionOC(NotaIngresoSalidaCabCE objEntidadBE)
        {

            try
            {

                return obj.F_NotaIngresoSalidaCab_FacturacionOC(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

      public DataTable F_NotaIngresoSalidaCab_Select_Compras(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Select_Compras(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoInventarioCab_Listar_Alvarado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoInventarioCab_Listar_Alvarado(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_SUNAT_EstadoDocumentos(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_SUNAT_EstadoDocumentos(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_Anulacion_NotaIngreso(NotaIngresoSalidaCabCE objEntidadBE)
      {
        try
          {
              return obj.F_Anulacion_NotaIngreso(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }
      
      public NotaIngresoSalidaCabCE F_Anulacion_NotaIngreso_Importacion(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_Anulacion_NotaIngreso_Importacion(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NotaIngresoSalidaCab_Letras(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NotaIngresoSalidaCab_Letras(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NotaIngresoSalidaCab_ConsultaPagos(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NotaIngresoSalidaCab_ConsultaPagos(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_Pagos_RegistroPagos(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_Pagos_RegistroPagos(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_Pagos_Listar(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_Pagos_Listar(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_Pagos_Anulacion(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_Pagos_Anulacion(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_InsertGastos(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_InsertGastos(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoSalidaCab_VistaPreliminar(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NotaIngresoSalidaCab_VistaPreliminar(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NotaIngesoSalidaCab_FacturaPercepcion(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NotaIngesoSalidaCab_FacturaPercepcion(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Insert(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaPedido_Insert_Alvarado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaPedido_Insert_Alvarado(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_Salcedo(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Insert_Salcedo(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_Tractos(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Insert_Tractos(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_Sanli(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Insert_Sanli(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_Roy(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Insert_Roy(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public DataTable F_NotaIngresoSalidaCab_OCXFacturar(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NotaIngresoSalidaCab_OCXFacturar(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_DevolucionOC(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {

              return obj.F_NotaIngresoSalidaCab_DevolucionOC(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_CompraCorporativa_Insert(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {

              return obj.F_NotaIngresoSalidaCab_CompraCorporativa_Insert(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_OC_Devolucion(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {

              return obj.F_NotaIngresoSalidaCab_OC_Devolucion(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_TrasladosCab_GuiaInterna_Devolucion(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {

              return obj.F_TrasladosCab_GuiaInterna_Devolucion(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_DocumentoVentaCab_OC_NV_Devolucion(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
               return obj.F_DocumentoVentaCab_OC_NV_Devolucion(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NotaIngresoSalidaCab_ConsultaPago(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NotaIngresoSalidaCab_ConsultaPago(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NotaIngresoSalidaCab_Compras(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NotaIngresoSalidaCab_Compras(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NOTAINGRESOSALIDACAB_REPORTE_VENTA_TIPODOCUMENTO(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NOTAINGRESOSALIDACAB_REPORTE_VENTA_TIPODOCUMENTO(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NotaIngresoSalidaCab_Compras_Detallado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Compras_Detallado(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_FacturasXPagar_Reporte(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_FacturasXPagar_Reporte(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_NotaCredito_Insert(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_NotaCredito_Insert(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_NotaCredito_Insert_Proforma(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_NotaCredito_Insert_Proforma(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoSalidaCab_ListarXCodigo_NotaCredito(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NotaIngresoSalidaCab_ListarXCodigo_NotaCredito(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NotaIngresoSalidaCab_ListarXCodigo_NotaCredito_Alvarado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NotaIngresoSalidaCab_ListarXCodigo_NotaCredito_Alvarado(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaDet_InsertTemporal(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaDet_InsertTemporal(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaDet_InsertTemporal_Alvarado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaDet_InsertTemporal_Alvarado(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_DocumentoVentaCab_NV_Devolucion(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_DocumentoVentaCab_NV_Devolucion(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NotaIngresoSalidaCab_Select_Compras_OC(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {

              return obj.F_NotaIngresoSalidaCab_Select_Compras_OC(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_ORDENCOMPRA_LISTAR(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {

              return obj.F_ORDENCOMPRA_LISTAR(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_Eliminacion_NotaIngreso(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_Eliminacion_NotaIngreso(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_Eliminacion_NotaCompra(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_Eliminacion_NotaCompra(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_OrdenCompra_Historial(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_OrdenCompra_Historial(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Update(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NotaIngresoSalidaCab_Update(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NotaIngresoSalidaCab_HistorialCompraSunat(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NotaIngresoSalidaCab_HistorialCompraSunat(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_ComprobanteCaja_Insert(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_ComprobanteCaja_Insert(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_ComprobanteCaja_Listar(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_ComprobanteCaja_Listar(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_ComprobanteCaja_Listar_Egresos(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_ComprobanteCaja_Listar_Egresos(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_ComprobanteCaja_ActualizarSaldo(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_ComprobanteCaja_ActualizarSaldo(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_ComprobanteCaja_BuscarFactura(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_ComprobanteCaja_BuscarFactura(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_ComprobanteCaja_BuscarFactura_Compras(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_ComprobanteCaja_BuscarFactura_Compras(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_ComprobanteCaja_ActualizarSaldo_Compras(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_ComprobanteCaja_ActualizarSaldo_Compras(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_ComprobanteCaja_Anulacion(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_ComprobanteCaja_Anulacion(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Anulacion_NotaCredito(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Anulacion_NotaCredito(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Anulacion_NotaCredito_Proforma(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Anulacion_NotaCredito_Proforma(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_Movimientos_CierreMensual(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_Movimientos_CierreMensual(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Validar_Edicion(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Validar_Edicion(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoSalidaCab_Reemplazar(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Reemplazar(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoSalidaCab_Reemplazar_Alvarado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Reemplazar_Alvarado(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoInventarioCab_Reemplazar_ALVARADO(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoInventarioCab_Reemplazar_ALVARADO(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Validar_Factura(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Validar_Factura(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Validar_Factura_Alvarado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Validar_Factura_Alvarado(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Validar_OC_COMPRA(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Validar_OC_COMPRA(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }

      public DataTable F_NotaIngresoSalidaCab_Impresion_Factura(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Impresion_Factura(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoSalidaCab_ComprobanteEgreso_Imprimir(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_ComprobanteEgreso_Imprimir(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_Pagos_Reporte_Pagados(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_Pagos_Reporte_Pagados(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_MOVIMIENTOS_ELIMINARAJUSTES(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_MOVIMIENTOS_ELIMINARAJUSTES(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }

      public DataTable F_NotaIngresoSalida_Documentos(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalida_Documentos(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_GuiaRemision_Documentos_Listar(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_GuiaRemision_Documentos_Listar(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_GuiaRemision_GI_NI_Documentos_Listar(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_GuiaRemision_GI_NI_Documentos_Listar(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NOTAINGRESOSALIDACAB_REPORTE_COMPRAS(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NOTAINGRESOSALIDACAB_REPORTE_COMPRAS(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoSalidaCab_Select_IMPORTACION(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Select_IMPORTACION(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NOTAINGRESOSALIDACAB_IMPRESION_TICKET(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NOTAINGRESOSALIDACAB_IMPRESION_TICKET(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoSalidaCab_ComprobanteEgreso_VistaPreliminar(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_ComprobanteEgreso_VistaPreliminar(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_Convergentes(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Insert_Convergentes(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }
      
      public bool F_SUNAT_MarcaDocumento(NotaIngresoSalidaCabCE objEntidadBE)
      {
          bool valor = false;
          try
          {
              var Datos = obj.F_SUNAT_MarcaDocumento(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return valor;
      }

      public bool F_SUNAT_ActualizarToken(NotaIngresoSalidaCabCE objEntidadBE)
      {
          bool valor = false;
          try
          {
              var Datos = obj.F_SUNAT_ActualizarToken(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return valor;
      }
      
      public DataTable F_SUNAT_ListarParametros(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_SUNAT_ListarParametros(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_Eliminacion_NotaIngreso_Gastos(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_Eliminacion_NotaIngreso_Gastos(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public object F_COMPROBANTEDEINGRESO_OBSERVACION(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {

              return obj.F_COMPROBANTEDEINGRESO_OBSERVACION(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public object F_COMPROBANTEDEEGRESO_OBSERVACION(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {

              return obj.F_COMPROBANTEDEEGRESO_OBSERVACION(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public object F_Auditoria(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {

              return obj.F_Auditoria(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public object F_AUDITORIA_EGRESO(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {

              return obj.F_AUDITORIA_EGRESO(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public object F_AUDITORIA_INGRESO(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {

              return obj.F_AUDITORIA_INGRESO(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_Anulacion_NotaIngreso_Inventario(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_Anulacion_NotaIngreso_Inventario(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_Anulacion_NotaIngresoInventarioCab(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_Anulacion_NotaIngresoInventarioCab(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_Confirmacion_NotaIngreso_Inventario(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_Confirmacion_NotaIngreso_Inventario(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_ComprobanteCaja_Actualizar(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_ComprobanteCaja_Actualizar(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public object F_AUDITORIA_NOTAINGRESO(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {

              return obj.F_AUDITORIA_NOTAINGRESO(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public object F_AUDITORIA_NOTACOMPRA(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {
              return obj.F_AUDITORIA_NOTACOMPRA(objEntidad);
          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public object F_NOTADEINGRESO_OBSERVACION(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {

              return obj.F_NOTADEINGRESO_OBSERVACION(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_ORDENCOMPRA_OBSERVACION(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {
              return obj.F_ORDENCOMPRA_OBSERVACION(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_ORDENCOMPRA_AUDITORIA(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_ORDENCOMPRA_AUDITORIA(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }
      
      public DataTable F_FACTURACOMPRA_OBSERVACION(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {
              return obj.F_FACTURACOMPRA_OBSERVACION(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_FACTURACOMPRA_AUDITORIA(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_FACTURACOMPRA_AUDITORIA(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NOTAINGRESO_OBSERVACION(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NOTAINGRESO_OBSERVACION(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoInventarioCab_Observacion_Alvarado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoInventarioCab_Observacion_Alvarado(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NOTAINGRESO_AUDITORIA(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NOTAINGRESO_AUDITORIA(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoInventarioCab_AUDITORIA_Alvarado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoInventarioCab_AUDITORIA_Alvarado(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NOTACREDITOCOMPRA_OBSERVACION(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NOTACREDITOCOMPRA_OBSERVACION(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NOTACREDITOCOMPRA_AUDITORIA(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NOTACREDITOCOMPRA_AUDITORIA(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NOTACREDITOCOMPRA_OBSERVACION_Alvarado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NOTACREDITOCOMPRA_OBSERVACION_Alvarado(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NOTACREDITOCOMPRA_AUDITORIA_Alvarado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NOTACREDITOCOMPRA_AUDITORIA_Alvarado(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA_CONCAR(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
                return obj.F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA_CONCAR(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoSalidaCab_Select_Compras_FACTURA(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Select_Compras_FACTURA(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_Confirmacion_NotaIngreso_Traslados(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_Confirmacion_NotaIngreso_Traslados(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_ORDENCOMPRA(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Insert_ORDENCOMPRA(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_Eliminacion_NotaIngreso_Inventario(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_Eliminacion_NotaIngreso_Inventario(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NOTAINGRESOSALIDACAB_REPORTE_EXCEL(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NOTAINGRESOSALIDACAB_REPORTE_EXCEL(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NOTAINGRESOSALIDACAB_ABRIR(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NOTAINGRESOSALIDACAB_ABRIR(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_DOCUMENTOVENTACAB_LISTAR_CP(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_DOCUMENTOVENTACAB_LISTAR_CP(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_PromedioVentas(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {

              return obj.F_PromedioVentas(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Validar_Factura_Salcedo(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Validar_Factura_Salcedo(objEntidad);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Update_Salcedo(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {

              return obj.F_NotaIngresoSalidaCab_Update_Salcedo(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NotaIngresoSalidaCab_Select_Compras_OC_Salcedo(NotaIngresoSalidaCabCE objEntidad)
      {

          try
          {

              return obj.F_NotaIngresoSalidaCab_Select_Compras_OC_Salcedo(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NotaIngresoSalidaCab_Reemplazar_Salcedo(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Reemplazar_Salcedo(objEntidad);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_ORDENCOMPRA_Salcedo(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Insert_ORDENCOMPRA_Salcedo(objEntidad);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_Eliminacion_NotaIngreso_Salcedo(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {

              return obj.F_Eliminacion_NotaIngreso_Salcedo(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_Anulacion_NotaIngreso_Salcedo(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {

              return obj.F_Anulacion_NotaIngreso_Salcedo(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      //salcedo
      public NotaIngresoSalidaCabCE F_MOVIMIENTOS_ELIMINARAJUSTES_SALCEDO(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_MOVIMIENTOS_ELIMINARAJUSTES_SALCEDO(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }

      public DataTable F_Utilidad_Bruta(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_Utilidad_Bruta(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }
      
      public List<NotaIngresoSalidaCabCE> F_Notaingreso_ListarXEstado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          List<NotaIngresoSalidaCabCE> lNotaIngresoSalidaCab = new List<NotaIngresoSalidaCabCE>();

          try
          {
              DataTable dtDatos = obj.F_Notaingreso_ListarXEstado(objEntidadBE);
              foreach (DataRow i in dtDatos.Rows)
              {
                  NotaIngresoSalidaCabCE newpr = new NotaIngresoSalidaCabCE()
                  {
                      CodMovimiento = int.Parse(i["CodMovimiento"].ToString()),
                      Serie = i["SerieDoc"].ToString(),
                      NumeroDoc = i["NumeroDoc"].ToString(),
                      NroRuc = i["NroRuc"].ToString(),
                      Cliente = i["Cliente"].ToString(),
                      Vendedor = i["Vendedor"].ToString(),
                      Observacion = i["Observacion"].ToString(),
                      FechaEmision = DateTime.Parse(i["Emision"].ToString()),
                      EmisionStr = i["Emision"].ToString(),
                      Vencimiento = DateTime.Parse(i["Vencimiento"].ToString()),
                      VencimientoStr = i["Vencimiento"].ToString(),
                      CodCtaCte = int.Parse(i["CodCtaCte"].ToString()),
                      CodFormaPago = int.Parse(i["CodFormaPago"].ToString()),
                      CodMoneda = int.Parse(i["CodMoneda"].ToString()),
                      TipoCambio = decimal.Parse(i["TC"].ToString()),
                      SubTotal = decimal.Parse(i["SubTotal"].ToString()),
                      Igv = decimal.Parse(i["Igv"].ToString()),
                      Total = decimal.Parse(i["Total"].ToString()),
                      Notaingreso_HOY = int.Parse(i["Notaingreso_HOY"].ToString()),
                      FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString()),
                      CodDepartamento = int.Parse(i["CodDepartamento"].ToString()),
                      CodProvincia = int.Parse(i["CodProvincia"].ToString()),
                      CodDistrito = int.Parse(i["CodDistrito"].ToString()),
                      Distrito = i["Distrito"].ToString(),
                      Direccion = i["Direccion"].ToString(),
                      FlagIgv = int.Parse(i["FlagCSIgv"].ToString()),
                      NroOperacion = i["NroOperacion"].ToString(),
                      CodEmpleado = int.Parse(i["CodEmpleado"].ToString()),
                      Placa = i["Placa"].ToString(),
                      KM = i["KM"].ToString(),
                      AlmacenOrigen = i["CodAlmacenPartida"].ToString(),
                      DscAlmacen = i["DscAlmacen"].ToString(),
                  };
                  lNotaIngresoSalidaCab.Add(newpr);
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return lNotaIngresoSalidaCab;
      }

      public List<NotaIngresoSalidaCabCE> F_Notaingreso_ListarXEstado_Reeim(NotaIngresoSalidaCabCE objEntidadBE)
      {
          List<NotaIngresoSalidaCabCE> lNotaIngresoSalidaCab = new List<NotaIngresoSalidaCabCE>();

          try
          {
              DataTable dtDatos = obj.F_Notaingreso_ListarXEstado(objEntidadBE);
              foreach (DataRow i in dtDatos.Rows)
              {
                  NotaIngresoSalidaCabCE newpr = new NotaIngresoSalidaCabCE()
                  {
                      CodMovimiento = int.Parse(i["CodMovimiento"].ToString()),
                      Serie = i["SerieDocSust"].ToString(),
                      NumeroDoc = i["NumeroDocSust"].ToString(),
                      NroRuc = i["NroRuc"].ToString(),
                      Cliente = i["Cliente"].ToString(),
                      Vendedor = i["Vendedor"].ToString(),
                      Observacion = i["Observacion"].ToString(),
                      FechaEmision = DateTime.Parse(i["Emision"].ToString()),
                      EmisionStr = i["Emision"].ToString(),
                      Vencimiento = DateTime.Parse(i["Vencimiento"].ToString()),
                      VencimientoStr = i["Vencimiento"].ToString(),
                      CodCtaCte = int.Parse(i["CodCtaCte"].ToString()),
                      CodFormaPago = int.Parse(i["CodFormaPago"].ToString()),
                      CodMoneda = int.Parse(i["CodMoneda"].ToString()),
                      TipoCambio = decimal.Parse(i["TC"].ToString()),
                      SubTotal = decimal.Parse(i["SubTotal"].ToString()),
                      Igv = decimal.Parse(i["Igv"].ToString()),
                      Total = decimal.Parse(i["Total"].ToString()),
                      Notaingreso_HOY = int.Parse(i["Notaingreso_HOY"].ToString()),
                      FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString()),
                      CodDepartamento = int.Parse(i["CodDepartamento"].ToString()),
                      CodProvincia = int.Parse(i["CodProvincia"].ToString()),
                      CodDistrito = int.Parse(i["CodDistrito"].ToString()),
                      Distrito = i["Distrito"].ToString(),
                      Direccion = i["Direccion"].ToString(),
                      FlagIgv = int.Parse(i["FlagCSIgv"].ToString()),
                      NroOperacion = i["NroOperacion"].ToString(),
                      CodEmpleado = int.Parse(i["CodEmpleado"].ToString()),
                      Placa = i["Placa"].ToString(),
                      KM = i["KM"].ToString(),
                      CodAlmacenLlegada = int.Parse(i["CodAlmacenLlegada"].ToString()),
                      Almacen = i["Almacen"].ToString(),
                  };
                  lNotaIngresoSalidaCab.Add(newpr);
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return lNotaIngresoSalidaCab;
      }

      public NotaIngresoSalidaCabCE F_NotaingresoCab_ObtenerXNumero(NotaIngresoSalidaCabCE objEntidad)
      {

          try
          {
              DataTable dtDatos = obj.F_NotaingresoCab_ObtenerXNumero(objEntidad);
              if (dtDatos.Rows.Count > 0)
              {
                  try
                  {
                      foreach (DataRow i in dtDatos.Rows)
                      {
                          objEntidad.CodMovimiento = Convert.ToInt32(i["CodMovimiento"]);
                          objEntidad.SerieDocSust = i["SerieDocSust"].ToString();
                          objEntidad.NumeroDocSust = i["NumeroDocSust"].ToString();
                          objEntidad.FechaEmision = DateTime.Parse(i["Emision"].ToString());
                          objEntidad.EmisionStr = objEntidad.FechaEmision.ToString("dd/MM/yyyy");
                          objEntidad.Vencimiento = DateTime.Parse(i["Vencimiento"].ToString());
                          objEntidad.VencimientoStr = objEntidad.Vencimiento.ToString();
                          objEntidad.Observacion2 = i["Observacion2"].ToString();
                          objEntidad.NroRucDestino = i["NroRucDestino"].ToString();
                          objEntidad.CodigoSucursalDestino = Convert.ToInt32(i["CodigoSucursalDestino"]);

                          objEntidad.lNotaingresoDet = new List<NotaIngresoSalidaCabCE>();
                          //dtDatos = (new NotaIngresoSalidaCabCN()).F_NotaingresoCab_ListarXCodigo(objEntidad);
                          dtDatos = (new NotaIngresoSalidaCabCN()).F_NotaingresoCab_ListarXCodigo_Traslado_Interno_Externo(objEntidad);
                          if (dtDatos.Rows.Count > 0)
                          {
                              foreach (DataRow r in dtDatos.Rows)
                              {
                                  objEntidad.lNotaingresoDet.Add(new NotaIngresoSalidaCabCE()
                                  {

                                      CodMovimiento = Convert.ToInt32(r["CodMovimiento"]),
                                      CodProducto = Convert.ToInt32(r["CodArticulo"]),
                                      Cantidad = Convert.ToInt32(r["Cantidad"]),
                                      Descripcion = r["Descripcion"].ToString(),
                                      CodUnidadVenta = Convert.ToInt32(r["CodUnidadVenta"]),
                                      CodigoInterno = r["CodigoInterno"].ToString()
                                  });
                              }
                          }
                          else
                          {
                              objEntidad.Observacion2 = "NO SE ENCONTRO NINGUNA DETALLE DE LA NOTA DE INGRESO";
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
      
      public NotaIngresoSalidaCabCE F_NotaingresoCab_ObtenerXIDCompra(NotaIngresoSalidaCabCE objEntidad)
      {

          try
          {
              DataTable dtDatos = obj.F_NotaingresoCab_ObtenerXIDCompra(objEntidad);
              if (dtDatos.Rows.Count > 0)
              {
                  try
                  {
                      foreach (DataRow i in dtDatos.Rows)
                      {
                          objEntidad.CodMovimiento = int.Parse(i["CodMovimiento"].ToString());


                          objEntidad.lNotaingresoDet = new List<NotaIngresoSalidaCabCE>();
                          dtDatos = (new NotaIngresoSalidaCabCN()).F_NotaingresoCab_ListarXCodigoCompra(objEntidad);
                          if (dtDatos.Rows.Count > 0)
                          {
                              foreach (DataRow r in dtDatos.Rows)
                              {
                                  objEntidad.lNotaingresoDet.Add(new NotaIngresoSalidaCabCE()
                                  {

                                      CodMovimiento = int.Parse(r["CodMovimiento"].ToString()),
                                      CodProducto = int.Parse(r["CodArticulo"].ToString()),
                                      Cantidad = int.Parse(r["Cantidad"].ToString()),
                                      Descripcion = r["Descripcion"].ToString(),
                                      CodUnidadVenta = int.Parse(r["CodUnidadVenta"].ToString()),
                                      CodigoInterno = r["CodigoInterno"].ToString(),
                                  });
                              }
                          }
                          else
                          {
                              objEntidad.Observacion2 = "NO SE ENCONTRO NINGUNA FACTURA DE COMPRA";
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
      
      public DataTable F_NotaingresoCab_ListarXCodigo(NotaIngresoSalidaCabCE objEntidad)
      {

          try
          {

              return obj.F_NotaingresoCab_ListarXCodigo(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_NotaingresoCab_ListarXCodigo_Traslado_Interno_Externo(NotaIngresoSalidaCabCE objEntidad)
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

      public DataTable F_NotaingresoCab_ListarXCodigoCompra(NotaIngresoSalidaCabCE objEntidad)
      {

          try
          {

              return obj.F_NotaingresoCab_ListarXCodigoCompra(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_NotaingresosalidaCab_ObtenerXNumero(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {
              DataTable dtDatos = obj.F_NotaingresosalidaCab_ObtenerXNumero(objEntidadBE);
              try
              {
                  foreach (DataRow i in dtDatos.Rows)
                  {
                      objEntidadBE.CodMovimiento = int.Parse(i["CodMovimiento"].ToString());
                      objEntidadBE.Serie = i["SerieDoc"].ToString();
                      objEntidadBE.NumeroDoc = i["NumeroDoc"].ToString();
                      objEntidadBE.NroRuc = i["NroRuc"].ToString();
                      objEntidadBE.Cliente = i["Cliente"].ToString();
                      objEntidadBE.Vendedor = i["Vendedor"].ToString();
                      objEntidadBE.FechaEmision = DateTime.Parse(i["Emision"].ToString());
                      objEntidadBE.EmisionStr = objEntidadBE.FechaEmision.ToString();
                      objEntidadBE.Vencimiento = DateTime.Parse(i["Vencimiento"].ToString());
                      objEntidadBE.VencimientoStr = objEntidadBE.Vencimiento.ToString();
                      objEntidadBE.CodCtaCte = int.Parse(i["CodCtaCte"].ToString());
                      objEntidadBE.CodFormaPago = int.Parse(i["CodFormaPago"].ToString());
                      objEntidadBE.CodMoneda = int.Parse(i["CodMoneda"].ToString());
                      objEntidadBE.TipoCambio = decimal.Parse(i["TC"].ToString());
                      objEntidadBE.SubTotal = decimal.Parse(i["SubTotal"].ToString());
                      objEntidadBE.Igv = decimal.Parse(i["Igv"].ToString());
                      objEntidadBE.Total = decimal.Parse(i["Total"].ToString());
                      objEntidadBE.Notaingreso_HOY = int.Parse(i["Notaingreso_HOY"].ToString());
                      objEntidadBE.FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString());
                      objEntidadBE.NroRuc = i["NroRuc"].ToString();
                      objEntidadBE.Cliente = i["Cliente"].ToString();
                      objEntidadBE.CodDireccion = int.Parse(i["CodDireccion"].ToString());
                      objEntidadBE.CodDepartamento = int.Parse(i["CodDepartamento"].ToString());
                      objEntidadBE.CodProvincia = int.Parse(i["CodProvincia"].ToString());
                      objEntidadBE.CodDistrito = int.Parse(i["CodDistrito"].ToString());
                      objEntidadBE.Distrito = i["Distrito"].ToString();
                      objEntidadBE.Direccion = i["Direccion"].ToString();
                      objEntidadBE.FlagIgv = int.Parse(i["FlagCSIgv"].ToString());
                      objEntidadBE.NroOperacion = i["NroOperacion"].ToString();
                      objEntidadBE.CodEmpleado = int.Parse(i["CodEmpleado"].ToString());
                      objEntidadBE.Placa = i["Placa"].ToString();
                      objEntidadBE.CodCategoria = int.Parse(i["CodCategoria"].ToString());
                      objEntidadBE.KM = i["KM"].ToString();
                      objEntidadBE.Observacion = i["Observacion"].ToString();
                      objEntidadBE.CodAlmacenOrigen = int.Parse(i["CodAlmacenOrigen"].ToString());
                      objEntidadBE.CodAlmacenDestino = int.Parse(i["CodAlmacenDestino"].ToString());




                      objEntidadBE.lnotaingresosalidaDet = new List<NotaIngresoSalidaDetCE>();
                      dtDatos = (new NotaIngresoSalidaCabCN()).F_NotaingresosalidaDet_ListarXCodigo(objEntidadBE);
                      foreach (DataRow r in dtDatos.Rows)
                      {
                          objEntidadBE.lnotaingresosalidaDet.Add(new NotaIngresoSalidaDetCE()
                          {

                              CodMovimiento = int.Parse(r["CodMovimiento"].ToString()),
                              CodArticulo = int.Parse(r["CodArticulo"].ToString()),
                              Cantidad = int.Parse(r["Cantidad"].ToString()),
                              Descripcion = r["Descripcion"].ToString(),
                              CodUndMedida = int.Parse(r["CodUnidadVenta"].ToString())
                          });
                      }
                  }
              }
              catch (Exception ex)
              { }
              finally
              { }

              return objEntidadBE;

          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaingresosalidaCab_ObtenerXNumero_Reeim(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {
              DataTable dtDatos = obj.F_NotaingresosalidaCab_ObtenerXNumero(objEntidadBE);
              try
              {
                  foreach (DataRow i in dtDatos.Rows)
                  {
                      objEntidadBE.CodMovimiento = int.Parse(i["CodMovimiento"].ToString());
                      objEntidadBE.Serie = i["SerieDoc"].ToString();
                      objEntidadBE.NumeroDoc = i["NumeroDoc"].ToString();
                      objEntidadBE.NroRuc = i["NroRuc"].ToString();
                      objEntidadBE.Cliente = i["Cliente"].ToString();
                      objEntidadBE.Vendedor = i["Vendedor"].ToString();
                      objEntidadBE.FechaEmision = DateTime.Parse(i["Emision"].ToString());
                      objEntidadBE.EmisionStr = objEntidadBE.FechaEmision.ToString();
                      objEntidadBE.Vencimiento = DateTime.Parse(i["Vencimiento"].ToString());
                      objEntidadBE.VencimientoStr = objEntidadBE.Vencimiento.ToString();
                      objEntidadBE.CodCtaCte = int.Parse(i["CodCtaCte"].ToString());
                      objEntidadBE.CodFormaPago = int.Parse(i["CodFormaPago"].ToString());
                      objEntidadBE.CodMoneda = int.Parse(i["CodMoneda"].ToString());
                      objEntidadBE.TipoCambio = decimal.Parse(i["TC"].ToString());
                      objEntidadBE.SubTotal = decimal.Parse(i["SubTotal"].ToString());
                      objEntidadBE.Igv = decimal.Parse(i["Igv"].ToString());
                      objEntidadBE.Total = decimal.Parse(i["Total"].ToString());
                      objEntidadBE.Notaingreso_HOY = int.Parse(i["Notaingreso_HOY"].ToString());
                      objEntidadBE.FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString());
                      objEntidadBE.NroRuc = i["NroRuc"].ToString();
                      objEntidadBE.Cliente = i["Cliente"].ToString();
                      objEntidadBE.CodDireccion = int.Parse(i["CodDireccion"].ToString());
                      objEntidadBE.CodDepartamento = int.Parse(i["CodDepartamento"].ToString());
                      objEntidadBE.CodProvincia = int.Parse(i["CodProvincia"].ToString());
                      objEntidadBE.CodDistrito = int.Parse(i["CodDistrito"].ToString());
                      objEntidadBE.Distrito = i["Distrito"].ToString();
                      objEntidadBE.Direccion = i["Direccion"].ToString();
                      objEntidadBE.FlagIgv = int.Parse(i["FlagCSIgv"].ToString());
                      objEntidadBE.NroOperacion = i["NroOperacion"].ToString();
                      objEntidadBE.CodEmpleado = int.Parse(i["CodEmpleado"].ToString());
                      objEntidadBE.Placa = i["Placa"].ToString();
                      objEntidadBE.CodCategoria = int.Parse(i["CodCategoria"].ToString());
                      objEntidadBE.KM = i["KM"].ToString();
                      objEntidadBE.Observacion = i["Observacion"].ToString();
                      objEntidadBE.CodAlmacenOrigen = int.Parse(i["CodAlmacenOrigen"].ToString());
                      objEntidadBE.CodAlmacenDestino = int.Parse(i["CodAlmacenDestino"].ToString());
                      objEntidadBE.CodDireccionDestino = int.Parse(i["CodDireccionDestino"].ToString());




                      objEntidadBE.lnotaingresosalidaDet = new List<NotaIngresoSalidaDetCE>();
                      dtDatos = (new NotaIngresoSalidaCabCN()).F_NotaingresosalidaDet_ListarXCodigo(objEntidadBE);
                      foreach (DataRow r in dtDatos.Rows)
                      {
                          objEntidadBE.lnotaingresosalidaDet.Add(new NotaIngresoSalidaDetCE()
                          {

                              CodMovimiento = int.Parse(r["CodMovimiento"].ToString()),
                              CodArticulo = int.Parse(r["CodArticulo"].ToString()),
                              Cantidad = int.Parse(r["Cantidad"].ToString()),
                              Descripcion = r["Descripcion"].ToString(),
                              CodUndMedida = int.Parse(r["CodUnidadVenta"].ToString())
                          });
                      }
                  }
              }
              catch (Exception ex)
              { }
              finally
              { }

              return objEntidadBE;

          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      private DataTable F_NotaingresosalidaDet_ListarXCodigo(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_NotaingresosalidaDet_ListarXCodigo(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_DesConfirmacion_NotaIngreso_Inventario_Reeim(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_DesConfirmacion_NotaIngreso_Inventario_Reeim(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_OrdenCompraCab_Insert(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_OrdenCompraCab_Insert(objEntidadBE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public DataTable F_OrdenCompraCab_Select_Compras(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {

              return obj.F_OrdenCompraCab_Select_Compras(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_Eliminacion_OrdenCompra(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_Eliminacion_OrdenCompra(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_OrdenCompraCab_Reemplazar(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_OrdenCompraCab_Reemplazar(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_OrdenCompra_Validar_Factura(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_OrdenCompra_Validar_Factura(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }
      
      public DataTable F_OrdenCompraCab_Impresion_Factura(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_OrdenCompraCab_Impresion_Factura(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public object F_AUDITORIA_ORDENCOMPRA(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {

              return obj.F_AUDITORIA_ORDENCOMPRA(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_Anulacion_OrdenCompra(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_Anulacion_OrdenCompra(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_MOVIMIENTOS_ELIMINARAJUSTES_Roman(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_MOVIMIENTOS_ELIMINARAJUSTES_Roman(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }

      public NotaIngresoSalidaCabCE F_MOVIMIENTOS_LISTAR_AJUSTE_MASIVO_ELIMINAR(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_MOVIMIENTOS_LISTAR_AJUSTE_MASIVO_ELIMINAR(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_Confirmacion_NotaIngreso_Traslados_Karina(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_Confirmacion_NotaIngreso_Traslados_Karina(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_Movimientos_Inventario(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_Movimientos_Inventario(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public DataTable F_NOTAINGRESO_REPORTE_ESTADOS(NotaIngresoSalidaCabCE objNotaIngresoSalidaCabCE)
      {
          try
          {
              return obj.F_NOTAINGRESO_REPORTE_ESTADOS(objNotaIngresoSalidaCabCE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public DataTable F_TRASLADOSCAB_REPORTE(NotaIngresoSalidaCabCE objNotaIngresoSalidaCabCE)
      {
          try
          {
              return obj.F_TRASLADOSCAB_REPORTE(objNotaIngresoSalidaCabCE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public DataTable F_DOCUMENTOVENTACAB_NOTAINGRESOINVENTARIOCAB_SALIDAS_ALMACEN(NotaIngresoSalidaCabCE objNotaIngresoSalidaCabCE)
      {
          try
          {
              return obj.F_DOCUMENTOVENTACAB_NOTAINGRESOINVENTARIOCAB_SALIDAS_ALMACEN(objNotaIngresoSalidaCabCE);
          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_Movimientos_Modulo(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {

              return obj.F_Movimientos_Modulo(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_PasaraNuevoSistema(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_PasaraNuevoSistema(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoSalidaCab_Select_Compras_FACTURA_ANTIGUO(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_NotaIngresoSalidaCab_Select_Compras_FACTURA_ANTIGUO(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }



      public List<NotaIngresoSalidaCabCE> F_OrdenCompraCab_ListarXEstado(NotaIngresoSalidaCabCE objEntidadBE)
      {
          List<NotaIngresoSalidaCabCE> lOrdenCompraCab = new List<NotaIngresoSalidaCabCE>();

          try
          {
              DataTable dtDatos = obj.F_OrdenCompraCab_ListarXEstado(objEntidadBE);
              foreach (DataRow i in dtDatos.Rows)
              {
                  NotaIngresoSalidaCabCE newpr = new NotaIngresoSalidaCabCE()
                  {
                      CodOrdenCompra = int.Parse(i["CodOrdenCompraCab"].ToString()),
                      Serie = i["SerieDoc"].ToString(),
                      NumeroC = i["NumeroDoc"].ToString(),
                      NroRuc = i["NroRuc"].ToString(),
                      Cliente = i["Cliente"].ToString(),
                      Vendedor = i["Vendedor"].ToString(),
                      //Observacion = i["Observacion"].ToString(),
                      FechaEmision = DateTime.Parse(i["Emision"].ToString()),
                      EmisionStr = i["Emision"].ToString(),
                      Vencimiento = DateTime.Parse(i["Vencimiento"].ToString()),
                      VencimientoStr = i["Vencimiento"].ToString(),
                      CodCtaCte = int.Parse(i["CodCtaCte"].ToString()),
                      CodFormaPago = int.Parse(i["CodFormaPago"].ToString()),
                      CodMoneda = int.Parse(i["CodMoneda"].ToString()),
                      TipoCambio = decimal.Parse(i["TC"].ToString()),
                      SubTotal = decimal.Parse(i["SubTotal"].ToString()),
                      Igv = decimal.Parse(i["Igv"].ToString()),
                      Total = decimal.Parse(i["Total"].ToString()),
                      ORDENESCOMPRAHOY = int.Parse(i["ORDENESCOMPRA_HOY"].ToString()),
                      FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString()),
                      CodDepartamento = int.Parse(i["CodDepartamento"].ToString()),
                      CodProvincia = int.Parse(i["CodProvincia"].ToString()),
                      CodDistrito = int.Parse(i["CodDistrito"].ToString()),
                      Distrito = i["Distrito"].ToString(),
                      Direccion = i["Direccion"].ToString(),
                      FlagIgv = int.Parse(i["FlagCSIgv"].ToString()),
                      NroOperacion = i["NroOperacion"].ToString(),
                      CodEmpleado = int.Parse(i["CodEmpleado"].ToString()),
                      Placa = i["Placa"].ToString(),
                      KM = i["KM"].ToString(),
                  };
                  lOrdenCompraCab.Add(newpr);
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return lOrdenCompraCab;
      }


      public NotaIngresoSalidaCabCE F_Obtener_Orden_PorNumero(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              DataTable dtDatos = obj.F_OrdenCompraCab_ObtenerXNumero(objEntidadBE);
              try
              {
                  foreach (DataRow i in dtDatos.Rows)
                  {
                      objEntidadBE.CodOrdenCompra = int.Parse(i["CodOrdenCompraCab"].ToString());
                      objEntidadBE.Serie = i["SerieDoc"].ToString();
                      objEntidadBE.NumeroDoc = i["NumeroDoc"].ToString();
                      objEntidadBE.NroRuc = i["NroRuc"].ToString();
                      objEntidadBE.Cliente = i["Cliente"].ToString();
                      objEntidadBE.Vendedor = i["Vendedor"].ToString();
                      objEntidadBE.FechaEmision = DateTime.Parse(i["Emision"].ToString());
                      objEntidadBE.EmisionStr = objEntidadBE.FechaEmision.ToString();
                      objEntidadBE.Vencimiento = DateTime.Parse(i["Vencimiento"].ToString());
                      objEntidadBE.VencimientoStr = objEntidadBE.Vencimiento.ToString();
                      objEntidadBE.CodCtaCte = int.Parse(i["CodCtaCte"].ToString());
                      objEntidadBE.CodFormaPago = int.Parse(i["CodFormaPago"].ToString());
                      objEntidadBE.CodMoneda = int.Parse(i["CodMoneda"].ToString());
                      objEntidadBE.TipoCambio = decimal.Parse(i["TC"].ToString());
                      objEntidadBE.SubTotal = decimal.Parse(i["SubTotal"].ToString());
                      objEntidadBE.Igv = decimal.Parse(i["Igv"].ToString());
                      objEntidadBE.Total = decimal.Parse(i["Total"].ToString());
                      //  objEntidadBE.COTIZACIONES_HOY = int.Parse(i["COTIZACIONES_HOY"].ToString());
                      objEntidadBE.FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString());
                      objEntidadBE.NroRuc = i["NroRuc"].ToString();
                      objEntidadBE.Cliente = i["Cliente"].ToString();
                      objEntidadBE.CodDireccion = int.Parse(i["CodDireccion"].ToString());
                      objEntidadBE.CodDepartamento = int.Parse(i["CodDepartamento"].ToString());
                      objEntidadBE.CodProvincia = int.Parse(i["CodProvincia"].ToString());
                      objEntidadBE.CodDistrito = int.Parse(i["CodDistrito"].ToString());
                      objEntidadBE.Distrito = i["Distrito"].ToString();
                      objEntidadBE.Direccion = i["Direccion"].ToString();
                      objEntidadBE.FlagIgv = int.Parse(i["FlagCSIgv"].ToString());

                      objEntidadBE.CodEmpleado = int.Parse(i["CodEmpleado"].ToString());

                      objEntidadBE.CodCategoria = int.Parse(i["CodCategoria"].ToString());
                      //  objEntidadBE.NombreComercial = i["NombreComercial"].ToString();

                      //    objEntidadBE.FlagComisionable = int.Parse(i["FlagComisionable"].ToString());
                      objEntidadBE.Observacion = i["Observacion"].ToString();
                      //  objEntidadBE.FPago = i["FPago"].ToString();
                      //objEntidadBE.FEntrega = i["FEntrega"].ToString();
                      //objEntidadBE.Atencion = i["Atencion"].ToString();
                      //objEntidadBE.FlagConCodigo = int.Parse(i["FlagConCodigo"].ToString());
                      //try
                      //{
                      //    objEntidadBE.CodigoPedidoApp = i["CodigoPedidoApp"].ToString();
                      //}
                      //catch (Exception)
                      //{

                      //}

                      objEntidadBE.OrdenCompraDet = new List<NotaIngresoSalidaDetCE>();
                      dtDatos = (new NotaIngresoSalidaCabCN()).F_OrdenCompraDet_ListarXCodigo(objEntidadBE);
                      foreach (DataRow r in dtDatos.Rows)
                      {
                          objEntidadBE.OrdenCompraDet.Add(new NotaIngresoSalidaDetCE()
                          {
                              CodDetalle = int.Parse(r["CodOrdenCompraDet"].ToString()),
                              CodMovimiento = int.Parse(r["CodOrdenCompraCab"].ToString()),
                              CodArticulo = int.Parse(r["CodArticulo"].ToString()),
                              Cantidad2 = decimal.Parse(r["Cantidad"].ToString()),
                              CantidadEntregada = decimal.Parse(r["CantidadEntregada"].ToString()),
                              Precio = decimal.Parse(r["Precio"].ToString()),
                              ValorVenta = decimal.Parse(r["ValorVenta"].ToString()),
                              Descripcion = r["Descripcion"].ToString(),
                              CodUnidadMedida = int.Parse(r["CodUnidadVenta"].ToString()),
                              Descuento = decimal.Parse(r["Descuento"].ToString()),
                              Comentario = r["Comentario"].ToString(),
                              Exclusivo = decimal.Parse(r["Exclusivo"].ToString()),
                              OC = r["OC"].ToString(),
                              Fecha = r["Fecha"] == DBNull.Value || r["Vencimiento"] == null
                                    ? new DateTime(2050, 1, 1)
                                     : Convert.ToDateTime(r["Vencimiento"])
                          });
                      }
                  }
              }
              catch (Exception ex)
              { }
              finally
              { }

              return objEntidadBE;

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      private DataTable F_OrdenCompraDet_ListarXCodigo(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {

              return obj.F_OrdenCompraDet_ListarXCodigo(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_DocumentoCompra_Impresion_Factura(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              return obj.F_DocumentoCompra_Impresion_Factura(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_Obtener_Pedido_PorNumero(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              DataTable dtDatos = obj.F_Obtener_Pedido_PorNumero(objEntidadBE);
              try
              {
                  foreach (DataRow i in dtDatos.Rows)
                  {
                      objEntidadBE.Codtraslado = int.Parse(i["CodTraslado"].ToString());
                      objEntidadBE.Serie = i["SerieDoc"].ToString();
                      objEntidadBE.NumeroDoc = i["NumeroDoc"].ToString();
                      objEntidadBE.NroRuc = i["NroRuc"].ToString();
                      objEntidadBE.Cliente = i["Cliente"].ToString();
                      objEntidadBE.Vendedor = i["Vendedor"].ToString();
                      objEntidadBE.FechaEmision = DateTime.Parse(i["Emision"].ToString());
                      objEntidadBE.EmisionStr = objEntidadBE.FechaEmision.ToString();
                      objEntidadBE.Vencimiento = DateTime.Parse(i["Vencimiento"].ToString());
                      objEntidadBE.VencimientoStr = objEntidadBE.Vencimiento.ToString();
                      objEntidadBE.CodCtaCte = int.Parse(i["CodCtaCte"].ToString());
                      objEntidadBE.CodFormaPago = int.Parse(i["CodFormaPago"].ToString());
                      objEntidadBE.CodMoneda = int.Parse(i["CodMoneda"].ToString());
                      objEntidadBE.TipoCambio = decimal.Parse(i["TC"].ToString());
                      objEntidadBE.SubTotal = decimal.Parse(i["SubTotal"].ToString());
                      objEntidadBE.Igv = decimal.Parse(i["Igv"].ToString());
                      objEntidadBE.Total = decimal.Parse(i["Total"].ToString());
                      //  objEntidadBE.COTIZACIONES_HOY = int.Parse(i["COTIZACIONES_HOY"].ToString());
                      objEntidadBE.FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString());
                      objEntidadBE.NroRuc = i["NroRuc"].ToString();
                      objEntidadBE.Cliente = i["Cliente"].ToString();
                      objEntidadBE.CodDireccion = int.Parse(i["CodDireccion"].ToString());
                      objEntidadBE.CodDepartamento = int.Parse(i["CodDepartamento"].ToString());
                      objEntidadBE.CodProvincia = int.Parse(i["CodProvincia"].ToString());
                      objEntidadBE.CodDistrito = int.Parse(i["CodDistrito"].ToString());
                      objEntidadBE.Distrito = i["Distrito"].ToString();
                      objEntidadBE.Direccion = i["Direccion"].ToString();
                      objEntidadBE.FlagIgv = int.Parse(i["FlagCSIgv"].ToString());

                      objEntidadBE.CodEmpleado = int.Parse(i["CodEmpleado"].ToString());

                      objEntidadBE.CodCategoria = int.Parse(i["CodCategoria"].ToString());
                      //  objEntidadBE.NombreComercial = i["NombreComercial"].ToString();

                      //    objEntidadBE.FlagComisionable = int.Parse(i["FlagComisionable"].ToString());
                      objEntidadBE.Observacion = i["Observacion"].ToString();
                      //  objEntidadBE.FPago = i["FPago"].ToString();
                      //objEntidadBE.FEntrega = i["FEntrega"].ToString();
                      //objEntidadBE.Atencion = i["Atencion"].ToString();
                      //objEntidadBE.FlagConCodigo = int.Parse(i["FlagConCodigo"].ToString());
                      //try
                      //{
                      //    objEntidadBE.CodigoPedidoApp = i["CodigoPedidoApp"].ToString();
                      //}
                      //catch (Exception)
                      //{

                      //}

                      objEntidadBE.TrasladoDet = new List<NotaIngresoSalidaDetCE>();
                      dtDatos = (new NotaIngresoSalidaCabCN()).F_TrasladoDetDet_ListarXCodigo(objEntidadBE);
                      foreach (DataRow r in dtDatos.Rows)
                      {
                          objEntidadBE.TrasladoDet.Add(new NotaIngresoSalidaDetCE()
                          {
                              CodDetalle = int.Parse(r["CodTrasladoDet"].ToString()),
                              CodTraslado = int.Parse(r["CodTraslado"].ToString()),
                              CodArticulo = int.Parse(r["CodArticulo"].ToString()),
                              Cantidad2 = decimal.Parse(r["Cantidad"].ToString()),
                              CantidadEntregada = decimal.Parse(r["CantidadEntregada"].ToString()),
                              Precio = decimal.Parse(r["Precio"].ToString()),
                              ValorVenta = decimal.Parse(r["ValorVenta"].ToString()),
                              Descripcion = r["Descripcion"].ToString(),
                              CodUnidadMedida = int.Parse(r["CodUnidadVenta"].ToString()),
                              Descuento = decimal.Parse(r["Descuento"].ToString()),
                              Comentario = r["Comentario"].ToString(),
                              Exclusivo = decimal.Parse(r["Exclusivo"].ToString()),
                              OC = r["OC"].ToString(),
                              Fecha = r["Fecha"] == DBNull.Value || r["Vencimiento"] == null
                                    ? new DateTime(2050, 1, 1)
                                     : Convert.ToDateTime(r["Vencimiento"])
                          });
                      }
                  }
              }
              catch (Exception ex)
              { }
              finally
              { }

              return objEntidadBE;

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }


      private DataTable F_TrasladoDetDet_ListarXCodigo(NotaIngresoSalidaCabCE objEntidadBE)
      {

          try
          {

              return obj.F_TrasladoDetDet_ListarXCodigo(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }


      public List<NotaIngresoSalidaCabCE> F_Consulta_Pedido_Pendientes_NET(NotaIngresoSalidaCabCE objEntidadBE)
      {
          List<NotaIngresoSalidaCabCE> lOrdenCompraCab = new List<NotaIngresoSalidaCabCE>();

          try
          {
              DataTable dtDatos = obj.F_Pedido_ListarXEstado(objEntidadBE);
              foreach (DataRow i in dtDatos.Rows)
              {
                  NotaIngresoSalidaCabCE newpr = new NotaIngresoSalidaCabCE()
                  {
                      CodOrdenCompra = int.Parse(i["CodTraslado"].ToString()),
                      Serie = i["SerieDoc"].ToString(),
                      NumeroC = i["NumeroDoc"].ToString(),
                      NroRuc = i["NroRuc"].ToString(),
                      Cliente = i["Cliente"].ToString(),
                      Vendedor = i["Vendedor"].ToString(),
                      //Observacion = i["Observacion"].ToString(),
                      FechaEmision = DateTime.Parse(i["Emision"].ToString()),
                      EmisionStr = i["Emision"].ToString(),
                      Vencimiento = DateTime.Parse(i["Vencimiento"].ToString()),
                      VencimientoStr = i["Vencimiento"].ToString(),
                      CodCtaCte = int.Parse(i["CodCtaCte"].ToString()),
                      CodFormaPago = int.Parse(i["CodFormaPago"].ToString()),
                      CodMoneda = int.Parse(i["CodMoneda"].ToString()),
                      TipoCambio = decimal.Parse(i["TC"].ToString()),
                      SubTotal = decimal.Parse(i["SubTotal"].ToString()),
                      Igv = decimal.Parse(i["Igv"].ToString()),
                      Total = decimal.Parse(i["Total"].ToString()),
                      //   ORDENESCOMPRAHOY = int.Parse(i["ORDENESCOMPRA_HOY"].ToString()),
                      FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString()),
                      CodDepartamento = int.Parse(i["CodDepartamento"].ToString()),
                      CodProvincia = int.Parse(i["CodProvincia"].ToString()),
                      CodDistrito = int.Parse(i["CodDistrito"].ToString()),
                      Distrito = i["Distrito"].ToString(),
                      Direccion = i["Direccion"].ToString(),
                      FlagIgv = int.Parse(i["FlagCSIgv"].ToString()),
                      NroOperacion = i["NroOperacion"].ToString(),
                      CodEmpleado = int.Parse(i["CodEmpleado"].ToString()),
                      Placa = i["Placa"].ToString(),
                      KM = i["KM"].ToString(),
                  };
                  lOrdenCompraCab.Add(newpr);
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return lOrdenCompraCab;
      }

      public DataTable F_ObtenerFormatoImportacion()
      {

          try
          {
              return obj.F_ObtenerFormatoImportacion();
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }
    }
}
