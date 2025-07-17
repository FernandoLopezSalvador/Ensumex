using Ensumex.Clases;
using Ensumex.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Ensumex.Models;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Services
{
    public static class SincronizacionService
    {
            public static void SincronizarDatos(Action<int, int> actualizarProgreso)
            {
                DataTable productos = FirebirdRepository.GetProductos();
                DataTable clientes = FirebirdRepository.GetClientes();
                DataTable precios = FirebirdRepository.GetPrecios();

                int total = productos.Rows.Count + clientes.Rows.Count + precios.Rows.Count;
                int progreso = 0;

                using (SqlConnection conn = SqlServerRepository.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            SqlServerRepository.LimpiarTablas(conn, transaction);

                            foreach (DataRow row in productos.Rows)
                            {
                                SqlServerRepository.InsertarProducto(row, conn, transaction);
                                progreso++;
                                actualizarProgreso(progreso, total);
                            }

                            foreach (DataRow row in clientes.Rows)
                            {
                                SqlServerRepository.InsertarCliente(row, conn, transaction);
                                progreso++;
                                actualizarProgreso(progreso, total);
                            }

                            foreach (DataRow row in precios.Rows)
                            {
                                SqlServerRepository.InsertarPrecio(row, conn, transaction);
                                progreso++;
                                actualizarProgreso(progreso, total);
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
    }
}