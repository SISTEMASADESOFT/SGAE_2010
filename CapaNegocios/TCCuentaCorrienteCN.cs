using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
    public class TCCuentaCorrienteCN
    {
        TCCuentaCorrienteCD obj = new TCCuentaCorrienteCD();

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Insert(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCuentaCorriente_Insert(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
       }

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Insert_Povis(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCuentaCorriente_Insert_Povis(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Insert_Alvarado(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCuentaCorriente_Insert_Alvarado(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Insert_Pymes(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCuentaCorriente_Insert_Pymes(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Update(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Update_Povis(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_Update_Povis(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Update_Alvarado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_Update_Alvarado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_ListarClientes(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_ListarClientes(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_ListarClientes_Proforma_Alvarado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_ListarClientes_Proforma_Alvarado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_Ruc_ListarClientes(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_Ruc_ListarClientes(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public DataTable F_ValidarClienteCambioPrecio(string NroRuc)
        {

            try
            {

                return obj.F_ValidarClienteCambioPrecio(NroRuc);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_PadronSunat(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_PadronSunat(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCDistritoBuscarXUbigeo(string CodigoUbigeo)
        {

            try
            {

                return obj.F_TCDistritoBuscarXUbigeo(CodigoUbigeo);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_BuscarDatosPorRucDni(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_BuscarDatosPorRucDni(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_Listar(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_LGFamilias_Insert(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_LGFamilias_Update(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGFamilias_Listado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Listado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGFamilias_Listar()
        {

            try
            {

                return obj.F_LGFamilias_Listar();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_LGFamilias_Delete(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Delete(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public TCCuentaCorrienteCE F_ClientesSaldos_AZURE(string NroRuc)
        {

            try
            {

                DataTable dtSaldos = obj.F_ClientesSaldos_AZURE(NroRuc);
                TCCuentaCorrienteCE tcSaldos = new TCCuentaCorrienteCE(); ;
                foreach (DataRow r in dtSaldos.Rows)
                {
                    tcSaldos = (new TCCuentaCorrienteCE()
                    {
                        Saldo = Convert.ToDecimal(r["Saldo"].ToString())
                    });
                }

                return tcSaldos;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public TCCuentaCorrienteCE F_Linea_Insertar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Insertar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Linea_Actualizar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Actualizar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Linea_Listado(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Listado(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Linea_Listar()
        {
            try
            {
                return obj.F_Linea_Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Linea_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LINEA_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_LINEA_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public TCCuentaCorrienteCE F_Modelo_Insertar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Modelo_Insertar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Modelo_Actualizar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Modelo_Actualizar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Modelo_Listado(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Modelo_Listado(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Modelo_Listar()
        {
            try
            {
                return obj.F_Modelo_Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Modelo_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Modelo_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable F_MODELOVEHICULO_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_MODELOVEHICULO_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_MARCAPRODUCTO_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_MARCAPRODUCTO_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_TCContactos_Listar(ContactosCE objEntidadBE)
        {

            try
            {

                return obj.F_TCContactos_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ContactosCE F_Contactos_Insert(ContactosCE objEntidadBE)
        {

            try
            {

                return obj.F_Contactos_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ContactosCE F_Contactos_Update(ContactosCE objEntidadBE)
        {

            try
            {

                return obj.F_Contactos_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_SaldosLineaCredito_Cliente(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCuentaCorriente_SaldosLineaCredito_Cliente(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //joel 20/02/21
        public TCCuentaCorrienteCE F_TCAlmacen_Insert(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCAlmacen_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //joel 20/02/21
        public DataTable F_TCAlmacen_Listado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCAlmacen_Listado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //joel 20/02/21
        public TCCuentaCorrienteCE F_TCAlmacen_Update(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCAlmacen_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_TCAlmacen_Delete(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCAlmacen_Delete(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_Usuario_Update(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Usuario_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public TCCuentaCorrienteCE F_ActualizarDescuento(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {

                return obj.F_ActualizarDescuento(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Procedencia_Insertar_Salcedo(TCCuentaCorrienteCE objEntidad)
        {
            try
            {
                return obj.F_Procedencia_Insertar_Salcedo(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Procedencia_Listado_Salcedo(TCCuentaCorrienteCE objEntidad)
        {
            try
            {
                return obj.F_Procedencia_Listado_Salcedo(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Procedencia_Actualizar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Procedencia_Actualizar_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Procedencia_Eliminar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Procedencia_Eliminar_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Linea_Insertar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Insertar_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Linea_Listado_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Listado_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Linea_Eliminar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Eliminar_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Linea_Actualizar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Actualizar_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Marca_Insertar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Marca_Insertar_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Marca_Listado_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Marca_Listado_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Marca_Eliminar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Marca_Eliminar_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Marca_Actualizar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Marca_Actualizar_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public TCCuentaCorrienteCE F_LGFamilias_Insert_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Insert_Salcedo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_LGFamilias_Update_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Update_Salcedo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGFamilias_Listado_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Listado_Salcedo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGFamilias_Listar_Salcedo()
        {

            try
            {

                return obj.F_LGFamilias_Listar_Salcedo();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_LGFamilias_Delete_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Delete_Salcedo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_Familia_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Familia_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Familia_AUTOCOMPLETE_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Familia_AUTOCOMPLETE_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Procedencia_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Procedencia_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Valores_AUTOCOMPLETE_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Valores_AUTOCOMPLETE_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable F_Procedencia_Listar()
        {
            try
            {
                return obj.F_Procedencia_Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_listar_EmpleadosxCargo(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_listar_EmpleadosxCargo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_BuscarMotivo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCuentaCorriente_BuscarMotivo(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public object F_CORREO_DIRECCION(TCCuentaCorrienteCE objEntidad)
        {
            try
            {

                return obj.F_CORREO_DIRECCION(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ContactosCE F_Contactos_Eliminar(ContactosCE objEntidadBE)
        {

            try
            {

                return obj.F_Contactos_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_Insert_ProductoMarca(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Insert_ProductoMarca(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TCCuentaCorrienteCE F_Insert_Pais(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Insert_Pais(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Insert_Marca(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Insert_Marca(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TCCuentaCorrienteCE F_Insert_Modelo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Insert_Modelo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TCCuentaCorrienteCE F_Insert_Motor(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Insert_Motor(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TCCuentaCorrienteCE F_Actualizar_LGMarcas(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Actualizar_LGMarcas(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TCCuentaCorrienteCE F_Actualizar_LGProductoMarcas(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Actualizar_LGProductoMarcas(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TCCuentaCorrienteCE F_Editar_LGMarca_Pais(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Editar_LGMarca_Pais(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TCCuentaCorrienteCE F_Editar_LGMarca_Modelo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Editar_LGMarca_Modelo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TCCuentaCorrienteCE F_Editar_LGMarca_Modelo_Motor(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Editar_LGMarca_Modelo_Motor(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_LGMarca_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_LGMarca_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TCCuentaCorrienteCE F_LGProductoMarca_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductoMarca_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TCCuentaCorrienteCE F_LGMarcas_Pais_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_LGMarcas_Pais_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TCCuentaCorrienteCE F_LGMarcas_Modelo_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_LGMarcas_Modelo_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TCCuentaCorrienteCE F_LGMarca_Motor_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_LGMarca_Motor_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LGMarca_Listado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGMarca_Listado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataTable F_LGProductoMarca_Listado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductoMarca_Listado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataTable F_LGPais_Listado()
        {
            try
            {
                return obj.F_LGPais_Listado();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGModelo_Listado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGModelo_Listado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataTable LGMarca_TipoMotor_Listado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.LGMarca_TipoMotor_Listado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataTable F_Listar_Modelo_Combo(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Listar_Modelo_Combo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public DataTable F_LGProducto_Listado_prueba(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProducto_Listado_prueba(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGFamilia_Listado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilia_Listado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGCategoria_Listado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGCategoria_Listado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_Listar_Categoria_Combo(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Listar_Categoria_Combo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_Listar_Categoria_Combo_Edicion(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Listar_Categoria_Combo_Edicion(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_Listar_TipoProducto_Combo(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Listar_TipoProducto_Combo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable LGFamilia_TipoProducto_Listado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.LGFamilia_TipoProducto_Listado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_LGFamilias_Categoria_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Categoria_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_LGFamilias_Producto_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Producto_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_Insert_Familia(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Insert_Familia(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_LGFamilias_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_FamiliaTipoProducto_Insert(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_FamiliaTipoProducto_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_Insert_Categoria(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Insert_Categoria(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_Actualizar_LGFamilias(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Actualizar_LGFamilias(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public TCCuentaCorrienteCE F_Editar_LGFamilia_Categoria(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Editar_LGFamilia_Categoria(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public TCCuentaCorrienteCE F_Editar_LGFamilia_Categoria_Producto(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Editar_LGFamilia_Categoria_Producto(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_VehiculoMotor_Listado_Combo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_VehiculoMotor_Listado_Combo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LGFamiliasTipoProducto_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamiliasTipoProducto_AUTOCOMPLETE(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_Marca_Insertar_Reeim(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Marca_Insertar_Reeim(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Marca_Listado_Reeim(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Marca_Listado_Reeim(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Marca_Actualizar_Reeim(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Marca_Actualizar_Reeim(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Marca_Eliminar_Reeim(TCCuentaCorrienteCE objEntidad)
        {
            try
            {
                return obj.F_Marca_Eliminar_Reeim(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable F_TCCUENTACORRIENTE_ENTER_ONBLUR(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCUENTACORRIENTE_ENTER_ONBLUR(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCUENTACORRIENTE_ENTER_ONBLUR_PROFORMA(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCUENTACORRIENTE_ENTER_ONBLUR_PROFORMA(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public DataTable F_REFERENCIA_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_REFERENCIA_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_CODPRODUCTO_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_CODPRODUCTO_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_FamiliaPRODUCTO_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_FamiliaPRODUCTO_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Bancos_Insert(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Bancos_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_Grabar_Bancos(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Grabar_Bancos(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_Bancos_Obtener(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Bancos_Obtener(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_Bancos_Update(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Bancos_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public TCCuentaCorrienteCE F_Cuentas_Delete(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Cuentas_Delete(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public TCCuentaCorrienteCE F_TCCuentaCorriente_Insert_Almacen(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCuentaCorriente_Insert_Almacen(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
        public TCCuentaCorrienteCE F_Bancos_Update_Banco(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Bancos_Update_Banco(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public DataTable ObtenerCredencialesWhatsApp(int codAlmacen)
        {
            try
            {

                return obj.ObtenerCredencialesWhatsApp(codAlmacen);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void RegistrarMensajeWhatsApp(int codUsuario, int codDocumentoVenta, int codCategoria, string observacion, int codAlmacen)
        {
            try
            {

                obj.RegistrarMensajeWhatsApp(codUsuario, codDocumentoVenta, codCategoria, observacion, codAlmacen);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ValidarCredencialesWhatsApp2(int CodAlmacen, int codDocumentoVenta)
        {
            try
            {

                return obj.ValidarCredencialesWhatsApp2(CodAlmacen, codDocumentoVenta);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ValidarCredencialesWhatsAppBasico(int CodEmpresa, int CodAlmacen)
        {
             

            try
            {

                return obj.ValidarCredencialesWhatsAppBasico(CodEmpresa, CodAlmacen);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
