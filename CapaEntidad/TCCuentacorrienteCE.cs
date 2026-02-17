using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class TCCuentaCorrienteCE
{

    public int CodEmpresa { get; set; }
    public int CodCtaCte { get; set; }
    public int CodTipoCtaCte { get; set; }
    public int CodTipoCliente { get; set; }
    public int CodClaseCliente { get; set; }
    public string ApePaterno { get; set; }
    public string ApeMaterno { get; set; }
    public string Nombres { get; set; }
    public string RazonSocial { get; set; }
    public string NroRuc { get; set; }
    public string NroDni { get; set; }
    public int CodDepartamento { get; set; }
    public int CodProvincia { get; set; }
    public int CodDistrito { get; set; }
    public string Direccion { get; set; }
    public string Referencia { get; set; }
    public string NroTelefono { get; set; }
    public string Email { get; set; }
    public string PaginaWeb { get; set; }
    public DateTime FechaUltCompra { get; set; }
    public string Estado { get; set; }
    public string DspPosterior { get; set; }
    public int CodUsuario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int CodUsuarioMod { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CodCargo { get; set; }
    public int CodUsuarioAnul { get; set; }
    public DateTime FechaAnulacion { get; set; }
    public string TipoDocumento { get; set; }
    public string NumCuenta { get; set; }
    public string DireccionEnvio { get; set; }
    public string MsgError { get; set; }
    public int FlagCliente { get; set; }
    public int FlagProveedor { get; set; }
    public string DscFamilia { get; set; }
    public string Descripcion { get; set; }
    public int CodEstado { get; set; }
    public int IDFamilia { get; set; }
    public decimal LineaCredito { get; set; }
    public decimal Saldo { get; set; }
    public int CodMonedaLineaCredito { get; set; }
    public int CodCategoria { get; set; }
    public int CodLinea { get; set; }
    public int CodModeloVehiculo { get; set; }
    public string IPModificacion { get; set; }
    public string IPRegistro { get; set; }
    public string Distrito { get; set; }
    public int CodDireccion { get; set; }
    public string DscAlmacen { get; set; }
    public int FlagPrincipal { get; set; }
    public int IDAlmacen { get; set; }
    public int CodAlmacen { get; set; }
    public string Usuario { get; set; }
    public string Contraseña { get; set; }
    public string Confirmacion { get; set; }
    public string ContraseñaNueva { get; set; }
    public string NombreComercial { get; set; }
    public int FlagBloqueoCredito { get; set; }
    public int CodZona { get; set; }
    public string DatosPersonales { get; set; }
    public string Telefono { get; set; }
    public string Area { get; set; }
    public string Correo1 { get; set; }
    public string Correo2 { get; set; }
    public string Correo3 { get; set; }
    public string Celular1 { get; set; }
    public string Celular2 { get; set; }
    public string Celular3 { get; set; }
    public int FlagRetencion { get; set; }
    public int Flag_MostrarEnReporte { get; set; }
    public int FlagExclusivo { get; set; }
    public int FlagMayorista { get; set; }
    public int CodVendedor { get; set; }
    public int CodTipoProducto { get; set; }
    public object categoria { get; set; }
    public int IDCategoria { get; set; }
    public decimal D1 { get; set; }
    public int EstadoProducto { get; set; }
    public decimal D2 { get; set; }
    public string CodigoProducto { get; set; }
    public decimal D3 { get; set; }
    public string CodigoFamilia { get; set; }
    public string TipoProducto { get; set; }
    public string Placa { get; set; }
    public string Codigolinea { get; set; }
    public string Licencia { get; set; }
    public int CodMarca { get; set; }
    public string CodigoMarca { get; set; }
    public string Ciudad { get; set; }

    public int CodProcedencia { get; set; }

    public string CodigoProcedencia { get; set; }

    public decimal GpsLong { get; set; }

    public decimal GpsLat { get; set; }

    public string Codigo { get; set; }

     public int IDModelo { get; set; }

    public string CodigoMotor { get; set; }

    public string DescripcionMotor { get; set; }

    public int EstadoMotor { get; set; }

    public int CodVehiculo { get; set; }

    public int CodModelo { get; set; }

    public int CodMotor { get; set; }

    public int CodPais { get; set; }


    public int ChkAño { get; set; }

    public int ChkCodigoProducto { get; set; }

    public int ChkMotor { get; set; }

    public int ChkModeloVehiculo { get; set; }

    public int ChkMarcaVehiculo { get; set; }

    public int ChkOtroDetalles { get; set; }

    public int ChkPlato { get; set; }

    public int Chkespesor { get; set; }

    public int ChkMedidasB { get; set; }

    public int ChkLado { get; set; }

    public int ChkPosicion { get; set; }

    public int ChkMedidasD { get; set; }

    public int ChkMedidasC { get; set; }

    public int ChkMedidasA { get; set; }

    public int ChkCollarin { get; set; }

    public int ChkDisco { get; set; }

    public int CodBanco { get; set; }

    public int CodMoneda { get; set; }

    public string Cci { get; set; }

    public string Cuenta { get; set; }

    public string Observacion { get; set; }

    public string CuentaContable { get; set; }

    public string Td { get; set; }

    public string CodigoAnexo { get; set; }

    public string DescripcionCorta { get; set; }

    public int Orden { get; set; }

    public string NombreClaveAzure { get; set; }

    public string CodigoEstablecimientoSunat { get; set; }

    public string SerieAntiguo { get; set; }

    public string SerieNuevo { get; set; }

    public int FlagRelacionado { get; set; }

    public string NombreCorto { get; set; }

    public int Detraccion { get; set; }

    public int FlagDetraccion { get; set; }

    public int CodCuenta { get; set; }

    public string NumeroOrden { get; set; }
}
