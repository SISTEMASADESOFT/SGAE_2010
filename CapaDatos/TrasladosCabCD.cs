using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CapaDatos
{
  public  class TrasladosCabCD
    {
      public DataTable F_TrasladosCab_Impresion_Electronica(TrasladosCabCE objEntidadBE)
      {

          DataTable dta_consulta = null;

          try
          {

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Impresion_Electronica";

                      sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;
                  }
              }
          }
          catch (Exception ex)
          {

              throw ex;

          }

          finally { dta_consulta.Dispose(); }

      }
      
      public DataTable F_TrasladosCab_Impresion(TrasladosCabCE objEntidadBE)
      {

          DataTable dta_consulta = null;

          try
          {

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Impresion";

                      sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;
                      sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;

                  }
              }
          }
          catch (Exception ex)
          {

              throw ex;

          }

          finally { dta_consulta.Dispose(); }

      }         

      public DataTable F_TrasladosCab_Impresion_Factura(TrasladosCabCE objEntidadBE)
      {

          DataTable dta_consulta = null;

          try
          {

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Impresion_Factura";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodTraslado;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;

                  }
              }
          }
          catch (Exception ex)
          {

              throw ex;

          }

          finally { dta_consulta.Dispose(); }

      }

      public TrasladosCabCE F_TrasladosCab_GuiaInterna_Insert(TrasladosCabCE objEntidadBE)
      {
          try
          {

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_GuiaInterna_Insert";

                      sql_comando.Parameters.Add("@CodAlmacenPartida", SqlDbType.Int).Value = objEntidadBE.CodAlmacenPartida;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar,50).Value = objEntidadBE.Serie;
                 
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

           
                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      
                      return objEntidadBE;

                  }

              }



          }
          catch (Exception ex)
          {

              throw ex;

          }



      }

      public DataTable F_TrasladosCab_Listar_GuiaInterna(TrasladosCabCE objEntidadBE)
      {
          DataTable dta_consulta = null;

          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Listar_GuiaInterna";

                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodDoc;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacenPartida;
                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }
                      if (objEntidadBE.SerieDoc != "TODOS")
                          sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                      if (objEntidadBE.NumeroDoc != "")
                          sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                      if (objEntidadBE.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;
                  }
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          finally { dta_consulta.Dispose(); }
      }

      public TrasladosCabCE F_TrasladosCab_Insert(TrasladosCabCE objEntidadBE)
      {
          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Insert";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@Partida", SqlDbType.VarChar, 250).Value = objEntidadBE.Partida;                      
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@TC", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                      sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                      sql_comando.Parameters.Add("@CodAlmacenPartida", SqlDbType.Int).Value = objEntidadBE.CodAlmacenPartida;
                      sql_comando.Parameters.Add("@CodAlmacenLlegada", SqlDbType.Int).Value = objEntidadBE.CodAlmacenLlegada;
                      sql_comando.Parameters.Add("@CodTrasladoAnterior", SqlDbType.Int).Value = objEntidadBE.CodTrasladoAnterior;
                      sql_comando.Parameters.Add("@NroReferencia", SqlDbType.VarChar, 20).Value = objEntidadBE.NroReferencia;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@FlagMotorizado", SqlDbType.Int).Value = objEntidadBE.FlagMotorizado;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccion", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccion;
                      sql_comando.Parameters.Add("@CodNotaIngreso_Asociado", SqlDbType.Int).Value = objEntidadBE.CodNotaIngreso;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar,250).Value = objEntidadBE.Destino;

                      //transportista
                      sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                      sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 500).Value = objEntidadBE.Placa;
                      sql_comando.Parameters.Add("@NroBultos", SqlDbType.Int).Value = objEntidadBE.NroBultos;
                      sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 500).Value = objEntidadBE.MarcaVehiculo;
                      sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 500).Value = objEntidadBE.Licencia;
                      sql_comando.Parameters.Add("@Peso", SqlDbType.Decimal).Value = objEntidadBE.Peso;
                      sql_comando.Parameters.Add("@CodUnidadPeso", SqlDbType.Int).Value = objEntidadBE.CodUnidadPeso;
                      sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                      sql_comando.Parameters.Add("@CodTipoTransportista", SqlDbType.Int).Value = objEntidadBE.CodTipoTransportista;
                      sql_comando.Parameters.Add("@RucTransportista", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRucTransportista;
                      sql_comando.Parameters.Add("@RazonSocialTransportista", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocialTransportista;
                      sql_comando.Parameters.Add("@ObservacionGuia", SqlDbType.VarChar, 1000).Value = objEntidadBE.ObservacionGuia; 
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccionDestino", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccionDestino;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccionTransportista", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccionTransportista;
                      

                      SqlParameter CodTraslado = sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int);
                      CodTraslado.Direction = ParameterDirection.Output;

                      SqlParameter CodProforma = sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int);
                      CodProforma.Direction = ParameterDirection.Output;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodTraslado = Convert.ToInt32(CodTraslado.Value);
                      objEntidadBE.CodProforma = Convert.ToInt32(CodProforma.Value);

                      return objEntidadBE;
                  }
              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;   
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;                      
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;   
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;                     
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@CodTrasladoAnterior", SqlDbType.Int).Value = objEntidadBE.CodTrasladoAnterior;
                      sql_comando.Parameters.Add("@FlagMotorizado", SqlDbType.Int).Value = objEntidadBE.FlagMotorizado;
                      sql_comando.Parameters.Add("@CodTipoTransportista", SqlDbType.Int).Value = objEntidadBE.CodTipoTransportista;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccionDestino", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccionDestino;
                      if (objEntidadBE.CodTransportista > 0)
                          sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                      else
                          sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = DBNull.Value;

                      if (objEntidadBE.CodDocumentoVentaDireccionTransportista > 0)
                          sql_comando.Parameters.Add("@CodDocumentoVentaDireccionTransportista", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccionTransportista;
                      else
                          sql_comando.Parameters.Add("@CodDocumentoVentaDireccionTransportista", SqlDbType.Int).Value = DBNull.Value;
                      sql_comando.Parameters.Add("@Peso", SqlDbType.Int).Value = objEntidadBE.Peso;
                      sql_comando.Parameters.Add("@NroBultos", SqlDbType.Int).Value = objEntidadBE.NroBultos;
                      sql_comando.Parameters.Add("@NroRucTransportista", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRucTransportista;
                      sql_comando.Parameters.Add("@RazonSocialTransportista", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocialTransportista;
                      sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 500).Value = objEntidadBE.PlacaTraslado;
                      sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 500).Value = objEntidadBE.MarcaVehiculo;
                      sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 500).Value = objEntidadBE.Licencia;
                      sql_comando.Parameters.Add("@CodUnidadPeso", SqlDbType.Int).Value = objEntidadBE.CodUnidadPeso;
                      if (objEntidadBE.CodConductor>0)
                          sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;     
                      else
                          sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = DBNull.Value;
             
                      sql_comando.Parameters.Add("@ObservacionGuia", SqlDbType.VarChar, 1000).Value = objEntidadBE.ObservacionGuia;
                      
                      SqlParameter CodTraslado = sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int);
                      CodTraslado.Direction = ParameterDirection.Output;
                      
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodTraslado = Convert.ToInt32(CodTraslado.Value);
            
                      return objEntidadBE;
                  }
              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Insert";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@Partida", SqlDbType.VarChar, 250).Value = objEntidadBE.Partida;
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@TC", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                      sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                      sql_comando.Parameters.Add("@CodAlmacenPartida", SqlDbType.Int).Value = objEntidadBE.CodAlmacenPartida;
                      sql_comando.Parameters.Add("@CodAlmacenLlegada", SqlDbType.Int).Value = objEntidadBE.CodAlmacenLlegada;
                      sql_comando.Parameters.Add("@CodTrasladoAnterior", SqlDbType.Int).Value = objEntidadBE.CodTrasladoAnterior;
                      sql_comando.Parameters.Add("@NroReferencia", SqlDbType.VarChar, 20).Value = objEntidadBE.NroReferencia;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@FlagMotorizado", SqlDbType.Int).Value = objEntidadBE.FlagMotorizado;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccion", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccion;
                      sql_comando.Parameters.Add("@CodNotaIngreso_Asociado", SqlDbType.Int).Value = objEntidadBE.CodNotaIngreso;

                      //transportista
                      sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                      sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 500).Value = objEntidadBE.Placa;
                      sql_comando.Parameters.Add("@NroBultos", SqlDbType.Int).Value = objEntidadBE.NroBultos;
                      sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 500).Value = objEntidadBE.MarcaVehiculo;
                      sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 500).Value = objEntidadBE.Licencia;
                      sql_comando.Parameters.Add("@Peso", SqlDbType.Decimal).Value = objEntidadBE.Peso;
                      sql_comando.Parameters.Add("@CodUnidadPeso", SqlDbType.Int).Value = objEntidadBE.CodUnidadPeso;
                      sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                      sql_comando.Parameters.Add("@CodTipoTransportista", SqlDbType.Int).Value = objEntidadBE.CodTipoTransportista;
                      sql_comando.Parameters.Add("@RucTransportista", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRucTransportista;
                      sql_comando.Parameters.Add("@RazonSocialTransportista", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocialTransportista;
                      sql_comando.Parameters.Add("@ObservacionGuia", SqlDbType.VarChar, 1000).Value = objEntidadBE.ObservacionGuia;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccionDestino", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccionDestino;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccionTransportista", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccionTransportista;


                      SqlParameter CodTraslado = sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int);
                      CodTraslado.Direction = ParameterDirection.Output;

                      SqlParameter CodProforma = sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int);
                      CodProforma.Direction = ParameterDirection.Output;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodTraslado = Convert.ToInt32(CodTraslado.Value);
                      objEntidadBE.CodProforma = Convert.ToInt32(CodProforma.Value);

                      return objEntidadBE;
                  }
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_TrasladosCab_Listar(TrasladosCabCE objEntidadBE)
      {
          DataTable dta_consulta = null;

          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Listar";
                      
                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.SerieDoc != "")
                          sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 10).Value = objEntidadBE.SerieDoc;

                      if (objEntidadBE.NumeroDoc != "")
                          sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 10).Value = objEntidadBE.NumeroDoc;

                      if (objEntidadBE.CodCtaCte > 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.CodTipoDoc > 0)
                          sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                      if (objEntidadBE.CodEmpresa > 0)
                          sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                      if (objEntidadBE.CodEstado != 0)
                          sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;

                  }

              }



          }
          catch (Exception ex)
          {

              throw ex;

          }

          finally { dta_consulta.Dispose(); }

      }

      public TrasladosCabCE F_TrasladosCab_Anulacion(TrasladosCabCE objEntidadBE)
      {
          try
          {

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Anulacion";

                      sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar,1000).Value = objEntidadBE.Observacion;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();

                      return objEntidadBE;
                  }

              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Eliminacion";

                      sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();

                      return objEntidadBE;
                  }
              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Eliminacion_Inventario";

                      sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();

                      return objEntidadBE;
                  }
              }
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

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Devolucion";

                      sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                      sql_comando.Parameters.Add("@CodTasaIgv", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();

                      return objEntidadBE;
                  }
              }
          }
          catch (Exception ex)
          {

              throw ex;

          }



      }

      public DataTable F_TrasladosCab_FacturarGuia(TrasladosCabCE objEntidadBE)
      {

          DataTable dta_consulta = null;

          try
          {

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_FacturarGuia";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      if (objEntidadBE.Descripcion != "")
                          sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;

                  }

              }



          }
          catch (Exception ex)
          {

              throw ex;

          }

          finally { dta_consulta.Dispose(); }

      }

      public TrasladosCabCE F_Transferencias_Insert(TrasladosCabCE objEntidadBE)
      {
          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_Transferencias_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;
                      sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar,4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar,8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@Responsable", SqlDbType.VarChar, 1000).Value = objEntidadBE.Responsable;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                    
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodNotaSalida", SqlDbType.Int);
                      MsgError.Direction = ParameterDirection.Output;
                      CodMovimiento.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodDocumentoVenta = Int32.Parse(CodMovimiento.Value.ToString());

                      return objEntidadBE;
                  }

              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_Transferencias_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodAlmacenLlegada", SqlDbType.Int).Value = objEntidadBE.CodAlmacenLlegada;
                      sql_comando.Parameters.Add("@CodAlmacenPartida", SqlDbType.Int).Value = objEntidadBE.CodAlmacenPartida;
                      sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;
                      sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@Responsable", SqlDbType.VarChar, 1000).Value = objEntidadBE.Responsable;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodNotaSalida", SqlDbType.Int);
                      MsgError.Direction = ParameterDirection.Output;
                      CodMovimiento.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodDocumentoVenta = Int32.Parse(CodMovimiento.Value.ToString());

                      return objEntidadBE;
                  }

              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_Transferencias_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;
                      sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@Responsable", SqlDbType.VarChar, 1000).Value = objEntidadBE.Responsable;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@FlagImportacion", SqlDbType.Int).Value = objEntidadBE.FlagImportacion;
                      sql_comando.Parameters.Add("@FlagMotorizado", SqlDbType.Int).Value = objEntidadBE.FlagMotorizado;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodNotaSalida", SqlDbType.Int);
                      MsgError.Direction = ParameterDirection.Output;
                      CodMovimiento.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodMovimiento = Int32.Parse(CodMovimiento.Value.ToString());

                      return objEntidadBE;
                  }

              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Validar_Guia";

                      sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();

                      return objEntidadBE;
                  }
              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_NotaIngresoInventarioCab_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacenLlegada", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@FlagImportacion", SqlDbType.Int).Value = objEntidadBE.FlagImportacion;
                      sql_comando.Parameters.Add("@FlagMotorizado", SqlDbType.Int).Value = objEntidadBE.FlagMotorizado;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodNotaIngresoInventarioCab", SqlDbType.Int);
                      MsgError.Direction = ParameterDirection.Output;
                      CodMovimiento.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodDocumentoVenta = Int32.Parse(CodMovimiento.Value.ToString());

                      return objEntidadBE;
                  }

              }
          }
          catch (Exception ex)
          {

              throw ex;

          }
      }
      
      public DataTable F_TrasladosCab_Reemplazar(TrasladosCabCE objEntidadBE)
      {

          DataTable dta_consulta = null;

          try
          {

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Reemplazar";

                      sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;
                  }
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          finally { dta_consulta.Dispose(); }
      }

      public DataTable F_GUIAREMISION_OBSERVACION(TrasladosCabCE objEntidadBE)
      {
          DataTable dta_consulta = null;
          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_GuiaRemision_Observacion";

                      sql_comando.Parameters.Add("@CodTrasladoCab", SqlDbType.Int).Value = objEntidadBE.CodTraslado;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;
                  }
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          finally { dta_consulta.Dispose(); }
      }

      public DataTable F_GUIAREMISION_AUDITORIA(TrasladosCabCE objEntidadBE)
      {
          DataTable dta_consulta = null;
          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_GuiaRemision_Auditoria";

                      sql_comando.Parameters.Add("@CodTrasladoCab", SqlDbType.Int).Value = objEntidadBE.CodTraslado;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;
                  }
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          finally { dta_consulta.Dispose(); }
      }

      public TrasladosCabCE F_Transferencias_Insert_Salcedo(TrasladosCabCE objEntidadBE)
      {
          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_Transferencias_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;
                      sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@ObservacionNS", SqlDbType.VarChar, 1000).Value = objEntidadBE.ObservacionNS;
                      sql_comando.Parameters.Add("@Responsable", SqlDbType.VarChar, 1000).Value = objEntidadBE.Responsable;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodNotaSalida", SqlDbType.Int);
                      MsgError.Direction = ParameterDirection.Output;
                      CodMovimiento.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodDocumentoVenta = Int32.Parse(CodMovimiento.Value.ToString());

                      return objEntidadBE;
                  }

              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Insert";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@Partida", SqlDbType.VarChar, 250).Value = objEntidadBE.Partida;
                      sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@TC", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                      sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                      sql_comando.Parameters.Add("@CodAlmacenPartida", SqlDbType.Int).Value = objEntidadBE.CodAlmacenPartida;
                      sql_comando.Parameters.Add("@CodAlmacenLlegada", SqlDbType.Int).Value = objEntidadBE.CodAlmacenLlegada;
                      sql_comando.Parameters.Add("@CodTrasladoAnterior", SqlDbType.Int).Value = objEntidadBE.CodTrasladoAnterior;
                      sql_comando.Parameters.Add("@NroReferencia", SqlDbType.VarChar, 20).Value = objEntidadBE.NroReferencia;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;

                      //transportista
                      sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                      sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTrans;
                      sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 500).Value = objEntidadBE.Placa;
                      sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 500).Value = objEntidadBE.NroBultos;
                      sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 500).Value = objEntidadBE.MarcaVehiculo;
                      sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 500).Value = objEntidadBE.Licencia;
                      sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 500).Value = objEntidadBE.Peso;


                      SqlParameter CodTraslado = sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int);
                      CodTraslado.Direction = ParameterDirection.Output;

                      SqlParameter CodProforma = sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int);
                      CodProforma.Direction = ParameterDirection.Output;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodTraslado = Convert.ToInt32(CodTraslado.Value);
                      objEntidadBE.CodProforma = Convert.ToInt32(CodProforma.Value);

                      return objEntidadBE;
                  }
              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "PA_TRASLADOSCAB_ABRIR";

                      sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;
                     
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 150);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                                    
                      return objEntidadBE;
                  }
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_TrasladosCab_ObtenerXNumero(TrasladosCabCE objEntidad)
      {
          DataTable dta_consulta = null;

          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_ObtenerXNumero";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidad.CodAlmacen;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidad.CodDireccion;                  
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidad.CodTipoDoc;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidad.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidad.NumeroDoc;
                                         
                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;
                  }
              }
          }
          catch (Exception ex)
          {

              objEntidad.MsgError = ex.ToString();
              throw ex;

          }

          finally { dta_consulta.Dispose(); }

      }


      public DataTable F_TrasladosCab_ListarXCodigo(TrasladosCabCE objEntidad)
      {
          DataTable dta_consulta = null;

          try
          {

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosDet_ListarXCodigo";

                      sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidad.CodTraslado;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;
                  }
              }
          }
          catch (Exception ex)
          {

              throw ex;

          }

          finally { dta_consulta.Dispose(); }

      }

      public DataTable F_TrasladosCab_ListarXCodigo_Traslado_Interno_Externo(TrasladosCabCE objEntidad)
      {
          DataTable dta_consulta = null;

          try
          {

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "PA_TrasladosCab_ListarXCodigo_Traslado_Interno_Externo";

                      sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidad.CodTraslado;
                      sql_comando.Parameters.Add("@NroRucPartida", SqlDbType.VarChar, 11).Value = objEntidad.NroRucPartida;
                      sql_comando.Parameters.Add("@CodigoSucursalPartida", SqlDbType.Int).Value = objEntidad.CodigoSucursalPartida;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;
                  }
              }
          }
          catch (Exception ex)
          {

              throw ex;

          }

          finally { dta_consulta.Dispose(); }

      }

      public DataTable F_NotaingresoCab_ListarXCodigo_Traslado_Interno_Externo(TrasladosCabCE objEntidad)
      {
          DataTable dta_consulta = null;

          try
          {

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings[objEntidad.Conexion].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "PA_NotaingresoCab_ListarXCodigo_Traslado_Interno_Externo";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidad.CodMovimiento;
                      sql_comando.Parameters.Add("@NroRucPartida", SqlDbType.VarChar,11).Value = objEntidad.NroRucPartida;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;
                  }
              }
          }
          catch (Exception ex)
          {

              throw ex;

          }

          finally { dta_consulta.Dispose(); }

      }

      public TrasladosCabCE F_TrasladosCab_Insert_Roman(TrasladosCabCE objEntidadBE)
      {
          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Insert";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@TC", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@CodTrasladoAnterior", SqlDbType.Int).Value = objEntidadBE.CodTrasladoAnterior;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@FlagMotorizado", SqlDbType.Int).Value = objEntidadBE.FlagMotorizado;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccion", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccion;

                      //transportista
                      sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                      sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 500).Value = objEntidadBE.PlacaTraslado;
                      sql_comando.Parameters.Add("@NroBultos", SqlDbType.Int).Value = objEntidadBE.NroBultos;
                      sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 500).Value = objEntidadBE.MarcaVehiculo;
                      sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 500).Value = objEntidadBE.Licencia;
                      sql_comando.Parameters.Add("@Peso", SqlDbType.Decimal).Value = objEntidadBE.Peso;
                      sql_comando.Parameters.Add("@CodUnidadPeso", SqlDbType.Int).Value = objEntidadBE.CodUnidadPeso;
                      sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                      sql_comando.Parameters.Add("@CodTipoTransportista", SqlDbType.Int).Value = objEntidadBE.CodTipoTransportista;
                      sql_comando.Parameters.Add("@RucTransportista", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRucTransportista;
                      sql_comando.Parameters.Add("@RazonSocialTransportista", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocialTransportista;
                      sql_comando.Parameters.Add("@ObservacionGuia", SqlDbType.VarChar, 1000).Value = objEntidadBE.ObservacionGuia;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccionDestino", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccionDestino;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccionTransportista", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccionTransportista;


                      SqlParameter CodTraslado = sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int);
                      CodTraslado.Direction = ParameterDirection.Output;
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodTraslado = Convert.ToInt32(CodTraslado.Value);

                      return objEntidadBE;
                  }
              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Insert";
                      
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@TC", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@CodTrasladoAnterior", SqlDbType.Int).Value = objEntidadBE.CodTrasladoAnterior;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@FlagMotorizado", SqlDbType.Int).Value = objEntidadBE.FlagMotorizado;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccion", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccion;
                      sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;

                      //transportista
                      sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                      sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 500).Value = objEntidadBE.PlacaTraslado;
                      sql_comando.Parameters.Add("@NroBultos", SqlDbType.Int).Value = objEntidadBE.NroBultos;
                      sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 500).Value = objEntidadBE.MarcaVehiculo;
                      sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 500).Value = objEntidadBE.Licencia;
                      sql_comando.Parameters.Add("@Peso", SqlDbType.Decimal).Value = objEntidadBE.Peso;
                      sql_comando.Parameters.Add("@CodUnidadPeso", SqlDbType.Int).Value = objEntidadBE.CodUnidadPeso;
                      sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                      sql_comando.Parameters.Add("@CodTipoTransportista", SqlDbType.Int).Value = objEntidadBE.CodTipoTransportista;
                      sql_comando.Parameters.Add("@RucTransportista", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRucTransportista;
                      sql_comando.Parameters.Add("@RazonSocialTransportista", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocialTransportista;
                      sql_comando.Parameters.Add("@ObservacionGuia", SqlDbType.VarChar, 1000).Value = objEntidadBE.ObservacionGuia;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccionDestino", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccionDestino;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccionTransportista", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccionTransportista;


                      SqlParameter CodTraslado = sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int);
                      CodTraslado.Direction = ParameterDirection.Output;
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodTraslado = Convert.ToInt32(CodTraslado.Value);

                      return objEntidadBE;
                  }
              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_TrasladosCab_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@CodTrasladoAnterior", SqlDbType.Int).Value = objEntidadBE.CodTrasladoAnterior;
                      sql_comando.Parameters.Add("@FlagMotorizado", SqlDbType.Int).Value = objEntidadBE.FlagMotorizado;
                      sql_comando.Parameters.Add("@CodTipoTransportista", SqlDbType.Int).Value = objEntidadBE.CodTipoTransportista;
                      sql_comando.Parameters.Add("@CodDocumentoVentaDireccionDestino", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccionDestino;
                      if (objEntidadBE.CodTransportista > 0)
                          sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                      else
                          sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = DBNull.Value;

                      if (objEntidadBE.CodDocumentoVentaDireccionTransportista > 0)
                          sql_comando.Parameters.Add("@CodDocumentoVentaDireccionTransportista", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVentaDireccionTransportista;
                      else
                          sql_comando.Parameters.Add("@CodDocumentoVentaDireccionTransportista", SqlDbType.Int).Value = DBNull.Value;
                      sql_comando.Parameters.Add("@Peso", SqlDbType.Int).Value = objEntidadBE.Peso;
                      sql_comando.Parameters.Add("@NroBultos", SqlDbType.Int).Value = objEntidadBE.NroBultos;
                      sql_comando.Parameters.Add("@NroRucTransportista", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRucTransportista;
                      sql_comando.Parameters.Add("@RazonSocialTransportista", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocialTransportista;
                      sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 500).Value = objEntidadBE.PlacaTraslado;
                      sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 500).Value = objEntidadBE.MarcaVehiculo;
                      sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 500).Value = objEntidadBE.Licencia;
                      sql_comando.Parameters.Add("@CodUnidadPeso", SqlDbType.Int).Value = objEntidadBE.CodUnidadPeso;
                      if (objEntidadBE.CodConductor > 0)
                          sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                      else
                          sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = DBNull.Value;

                      sql_comando.Parameters.Add("@ObservacionGuia", SqlDbType.VarChar, 1000).Value = objEntidadBE.ObservacionGuia;
                      sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;

                      SqlParameter CodTraslado = sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int);
                      CodTraslado.Direction = ParameterDirection.Output;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodTraslado = Convert.ToInt32(CodTraslado.Value);

                      return objEntidadBE;
                  }
              }
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
              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_NotaIngresoInventarioCab_Insert";


                      sql_comando.Parameters.Add("@CodAlmacenLlegada", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMotivoTraslado", SqlDbType.Int).Value = objEntidadBE.CodMotivoTraslado;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@FlagImportacion", SqlDbType.Int).Value = objEntidadBE.FlagImportacion;
                      sql_comando.Parameters.Add("@FlagMotorizado", SqlDbType.Int).Value = objEntidadBE.FlagMotorizado;
                      sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodNotaIngresoInventarioCab", SqlDbType.Int);
                      MsgError.Direction = ParameterDirection.Output;
                      CodMovimiento.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodDocumentoVenta = Int32.Parse(CodMovimiento.Value.ToString());

                      return objEntidadBE;
                  }

              }
          }
          catch (Exception ex)
          {

              throw ex;

          }
      }
    }
}
