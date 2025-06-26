using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Models
{
    public static class CotizacionRepository
    {
        // Usa tu cadena de conexión centralizada
        private static readonly string connSqlServer = "Server=localhost;Database=Ensumex;Trusted_Connection=True;";

        public static void GuardarCotizacion(
            string numeroCotizacion,
            DateTime fecha,
            string nombreCliente,
            string numeroCliente,
            decimal costoInstalacion,
            decimal costoFlete,
            decimal subtotal,
            decimal descuento,
            decimal total,
            string notas,
            DataGridView tablaCotizacion)
        {
            using (var conn = new SqlConnection(connSqlServer))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar encabezado
                        var cmdEncabezado = new SqlCommand(@"
                            INSERT INTO Cotizacion
                            (NumeroCotizacion, Fecha, NombreCliente, NumeroCliente, CostoInstalacion, CostoFlete, Subtotal, Descuento, Total, Notas, Estado)
                            VALUES (@NumeroCotizacion, @Fecha, @NombreCliente, @NumeroCliente, @CostoInstalacion, @CostoFlete, @Subtotal, @Descuento, @Total, @Notas, @Estado);
                            SELECT SCOPE_IDENTITY();", conn, tran);

                        cmdEncabezado.Parameters.AddWithValue("@NumeroCotizacion", numeroCotizacion);
                        cmdEncabezado.Parameters.AddWithValue("@Fecha", fecha);
                        cmdEncabezado.Parameters.AddWithValue("@NombreCliente", nombreCliente);
                        cmdEncabezado.Parameters.AddWithValue("@NumeroCliente", numeroCliente); 
                        cmdEncabezado.Parameters.AddWithValue("@CostoInstalacion", costoInstalacion);
                        cmdEncabezado.Parameters.AddWithValue("@CostoFlete", costoFlete);
                        cmdEncabezado.Parameters.AddWithValue("@Subtotal", subtotal);
                        cmdEncabezado.Parameters.AddWithValue("@Descuento", descuento);
                        cmdEncabezado.Parameters.AddWithValue("@Total", total);
                        cmdEncabezado.Parameters.AddWithValue("@Notas", notas ?? (object)DBNull.Value);
                        cmdEncabezado.Parameters.AddWithValue("@Estado", "Vigente");
                        int idCotizacion = Convert.ToInt32(cmdEncabezado.ExecuteScalar());
                        // 2. Insertar detalle
                        foreach (DataGridViewRow row in tablaCotizacion.Rows)   
                        {
                            if (row.IsNewRow) continue;

                            var cmdDetalle = new SqlCommand(@"
                                INSERT INTO CotizacionDetalle
                                (IdCotizacion, ClaveProducto, Descripcion, Unidad, PrecioUnitario, Cantidad, TasaCambio, Subtotal, AplicaDescuento)
                                VALUES (@IdCotizacion, @ClaveProducto, @Descripcion, @Unidad, @PrecioUnitario, @Cantidad, @TasaCambio, @Subtotal, @AplicaDescuento);", conn, tran);

                            cmdDetalle.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                            cmdDetalle.Parameters.AddWithValue("@ClaveProducto", row.Cells["CLAVE"].Value ?? "");
                            cmdDetalle.Parameters.AddWithValue("@Descripcion", row.Cells["DESCRIPCIÓN"].Value ?? "");
                            cmdDetalle.Parameters.AddWithValue("@Unidad", row.Cells["UNIDAD"].Value ?? "");
                            cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", row.Cells["PRECIO"].Value ?? 0);
                            cmdDetalle.Parameters.AddWithValue("@Cantidad", row.Cells["CANTIDAD"].Value ?? 0);
                            cmdDetalle.Parameters.AddWithValue("@TasaCambio", row.Cells["TasaCambio"].Value ?? 1);
                            cmdDetalle.Parameters.AddWithValue("@Subtotal", row.Cells["Subtotal"].Value ?? 0);
                            cmdDetalle.Parameters.AddWithValue("@AplicaDescuento", row.Cells["AplicarDescuento"].Value ?? false);
                            cmdDetalle.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
        public static DataTable ObtenerCotizaciones()
        {
            var dt = new DataTable();

            try
            {
                using (var conn = new SqlConnection(connSqlServer))
                {
                    string query = @"
                SELECT IdCotizacion, NumeroCotizacion, Fecha, NombreCliente, NumeroCliente, 
                       CostoInstalacion, CostoFlete, Subtotal, Descuento, Total, Notas
                FROM Cotizacion
                ORDER BY Fecha DESC";

                    using (var cmd = new SqlCommand(query, conn))
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes registrar el error o mostrar un mensaje
                MessageBox.Show("Error al obtener cotizaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        public static DataTable ObtenerDetallePorId(int idCotizacion)
        {
            var dt = new DataTable();

            try
            {
                using (var conn = new SqlConnection(connSqlServer))
                {
                    string query = @"
                SELECT ClaveProducto, Descripcion, Unidad, PrecioUnitario, 
                       Cantidad, TasaCambio, Subtotal, AplicaDescuento
                FROM CotizacionDetalle
                WHERE IdCotizacion = @IdCotizacion";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@IdCotizacion", SqlDbType.Int).Value = idCotizacion;

                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            conn.Open();
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el detalle de cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        public static DataTable ObtenerCotizacionesPorLimite(int limite)
        {
            var dt = new DataTable();

            try
            {
                using (var conn = new SqlConnection(connSqlServer))
                {
                    // IMPORTANTE: Aquí se concatena el valor en la cadena, ya que no se puede usar @param en TOP directamente
                    string query = $@"
                SELECT TOP {limite} IdCotizacion, NumeroCotizacion, Fecha, NombreCliente, NumeroCliente, 
                       CostoInstalacion, CostoFlete, Subtotal, Descuento, Total, Notas, Estado
                FROM Cotizacion
                ORDER BY Fecha DESC";

                    using (var cmd = new SqlCommand(query, conn))
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las cotizaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        public static DataTable ObtenerCotizacionesFiltradas(string searchText)
        {
            var dt = new DataTable();

            try
            {
                using (var conn = new SqlConnection(connSqlServer))
                {
                    string query = @"
                SELECT IdCotizacion, NumeroCotizacion, Fecha, NombreCliente, NumeroCliente, 
                       CostoInstalacion, CostoFlete, Subtotal, Descuento, Total, Notas, Estado
                FROM Cotizacion
                WHERE NombreCliente LIKE @SearchText OR NumeroCliente LIKE @SearchText
                ORDER BY Fecha DESC";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        // Validar entrada
                        if (string.IsNullOrWhiteSpace(searchText))
                            searchText = ""; // Si viene vacío, no filtra

                        cmd.Parameters.Add("@SearchText", SqlDbType.NVarChar).Value = $"%{searchText}%";

                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            conn.Open();
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cotizaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
    }
}
