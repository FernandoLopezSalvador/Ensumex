using Ensumex.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ensumex.Models
{
    public static class CotizacionRepository
    {
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
            //string notaprincipal,
            DataGridView tablaCotizacion)
        {
            using (var conn = ConnectionToSql.GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {

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

                        foreach (DataGridViewRow row in tablaCotizacion.Rows)   
                        {
                            if (row.IsNewRow) continue;

                            var cmdDetalle = new SqlCommand(@"
                                INSERT INTO CotizacionDetalle
                                (IdCotizacion, ClaveProducto, Descripcion, Unidad, PrecioUnitario, Cantidad, Subtotal, AplicaDescuento)
                                VALUES (@IdCotizacion, @ClaveProducto, @Descripcion, @Unidad, @PrecioUnitario, @Cantidad, @Subtotal, @AplicaDescuento);", conn, tran);

                            cmdDetalle.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                            cmdDetalle.Parameters.AddWithValue("@ClaveProducto", row.Cells["CLAVE"].Value ?? "");
                            cmdDetalle.Parameters.AddWithValue("@Descripcion", row.Cells["DESCRIPCIÓN"].Value ?? "");
                            cmdDetalle.Parameters.AddWithValue("@Unidad", row.Cells["UNIDAD"].Value ?? "");
                            cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", row.Cells["PRECIO"].Value ?? 0);
                            cmdDetalle.Parameters.AddWithValue("@Subtotal", row.Cells["Subtotal"].Value ?? 0);
                            cmdDetalle.Parameters.AddWithValue("@Cantidad", row.Cells["CANTIDAD"].Value ?? 0);
                            cmdDetalle.Parameters.AddWithValue("@AplicaDescuento",int.TryParse(row.Cells["Descuento"]?.Value?.ToString(), out int desc) ? desc : 0); cmdDetalle.ExecuteNonQuery();
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

        public static void GuardarCotizacionTablas(
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
            List<List<object[]>> tablas
        )
        {
            using (var conn = ConnectionToSql.GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
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
                        foreach (var tabla in tablas)
                        {
                            foreach (var row in tabla)
                            {
                                var cmdDetalle = new SqlCommand(@"
                                    INSERT INTO CotizacionDetalle
                                    (IdCotizacion, ClaveProducto, Descripcion, Unidad, PrecioUnitario, Cantidad, Subtotal, AplicaDescuento)
                                    VALUES (@IdCotizacion, @ClaveProducto, @Descripcion, @Unidad, @PrecioUnitario, @Cantidad, @Subtotal, @AplicaDescuento);", conn, tran);

                                cmdDetalle.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                                cmdDetalle.Parameters.AddWithValue("@ClaveProducto", row[1] ?? "");
                                cmdDetalle.Parameters.AddWithValue("@Descripcion", row[2] ?? "");
                                cmdDetalle.Parameters.AddWithValue("@Unidad", row[3] ?? "");
                                cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", row[4] ?? 0);
                                cmdDetalle.Parameters.AddWithValue("@Cantidad", row[5] ?? 0);
                                cmdDetalle.Parameters.AddWithValue("@Subtotal", row.Length > 6 ? row[6] ?? 0 : 0);
                                cmdDetalle.Parameters.AddWithValue("@AplicaDescuento",int.TryParse(row[0]?.ToString(), out int desc) ? desc : 0); cmdDetalle.ExecuteNonQuery();
                            }
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
                using (var conn = ConnectionToSql.GetConnection())
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
                MessageBox.Show("Error al obtener cotizaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public static DataTable ObtenerDetallePorId(int idCotizacion)
        {
            var dt = new DataTable();
            try
            {
                using (var conn = ConnectionToSql.GetConnection())
                {
                    string query = @"
                    SELECT ClaveProducto, Descripcion, Unidad, PrecioUnitario, 
                    Cantidad, Subtotal, AplicaDescuento
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
                using (var conn = ConnectionToSql.GetConnection())
                {
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
                using (var conn = ConnectionToSql.GetConnection())
                {
                    string query = @"
                    SELECT IdCotizacion, NumeroCotizacion, Fecha, NombreCliente, NumeroCliente, 
                    CostoInstalacion, CostoFlete, Subtotal, Descuento, Total, Notas, Estado
                    FROM Cotizacion
                    WHERE NombreCliente LIKE @SearchText OR NumeroCliente LIKE @SearchText
                    ORDER BY Fecha DESC";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (string.IsNullOrWhiteSpace(searchText))
                            searchText = ""; 
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

        public static void GuardarSiNoExisteCliente(string numeroCliente, string nombreCliente)
        {
            if (string.IsNullOrWhiteSpace(nombreCliente))
                return;

            using (var conn = ConnectionToSql.GetConnection())
            {
                conn.Open();

                // Verificar si ya existe por CLAVE o por NOMBRE
                using (var cmdCheck = new SqlCommand(@"
                    SELECT COUNT(*) 
                    FROM CLIE01 
                    WHERE (CLAVE = @NumeroCliente AND @NumeroCliente <> '') OR (NOMBRE = @NombreCliente)", conn))
                {
                    cmdCheck.Parameters.AddWithValue("@NumeroCliente", (object)numeroCliente ?? DBNull.Value);
                    cmdCheck.Parameters.AddWithValue("@NombreCliente", nombreCliente);
                    int exists = Convert.ToInt32(cmdCheck.ExecuteScalar() ?? 0);
                    if (exists > 0)
                        return; // ya existe, nada que hacer
                }

                // Si no se proporcionó numeroCliente, generar uno nuevo numérico seguro
                if (string.IsNullOrWhiteSpace(numeroCliente))
                {
                    using (var cmdNewKey = new SqlCommand(@"
                        SELECT ISNULL(MAX(TRY_CAST(CLAVE AS INT)), 0) + 1 
                        FROM CLIE01", conn))
                    {
                        var newKeyObj = cmdNewKey.ExecuteScalar();
                        numeroCliente = (newKeyObj != null) ? newKeyObj.ToString() : "1";
                    }
                }

                // Insertar
                using (var cmdInsert = new SqlCommand(@"
                    INSERT INTO CLIE01 (CLAVE, STATUS, NOMBRE)
                    VALUES (@NumeroCliente, @Status, @NombreCliente);", conn))
                {
                    cmdInsert.Parameters.AddWithValue("@NumeroCliente", numeroCliente);
                    cmdInsert.Parameters.AddWithValue("@Status", "A");
                    cmdInsert.Parameters.AddWithValue("@NombreCliente", nombreCliente);
                    cmdInsert.ExecuteNonQuery();
                }
            }
        }

        public static string ObtenerUltimoFolioPorPrefijo(string prefijo)
        {
            {
                string folio = "";
                using (SqlConnection conn = ConnectionToSql.GetConnection())
                {
                    conn.Open();
                    string query = @"
            SELECT TOP 1 NumeroCotizacion
            FROM Cotizacion
            WHERE NumeroCotizacion LIKE @prefijo + '%'
            ORDER BY
                TRY_CAST(SUBSTRING(NumeroCotizacion, LEN(@prefijo) + 1, 10) AS INT) DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@prefijo", prefijo);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                            folio = result.ToString();
                    }
                }
                return folio;
            }
        }

        public static DataRow ObtenerCotizacionPorId(int idCotizacion)
        {
            var dt = new DataTable();
            using (var conn = ConnectionToSql.GetConnection())
            {
                string query = @"
                    SELECT IdCotizacion, NumeroCotizacion, Fecha, NombreCliente, NumeroCliente,
                           CostoInstalacion, CostoFlete, Subtotal, Descuento, Total, Notas, Estado
                    FROM Cotizacion
                    WHERE IdCotizacion = @IdCotizacion";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dt);
                    }
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static void ActualizarCotizacion(
            int idCotizacion,
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
            using (var conn = ConnectionToSql.GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Actualizar encabezado
                        using (var cmdUpd = new SqlCommand(@"
                            UPDATE Cotizacion
                            SET NumeroCotizacion = @NumeroCotizacion,
                                Fecha = @Fecha,
                                NombreCliente = @NombreCliente,
                                NumeroCliente = @NumeroCliente,
                                CostoInstalacion = @CostoInstalacion,
                                CostoFlete = @CostoFlete,
                                Subtotal = @Subtotal,
                                Descuento = @Descuento,
                                Total = @Total,
                                Notas = @Notas
                            WHERE IdCotizacion = @IdCotizacion;", conn, tran))
                        {
                            cmdUpd.Parameters.AddWithValue("@NumeroCotizacion", numeroCotizacion);
                            cmdUpd.Parameters.AddWithValue("@Fecha", fecha);
                            cmdUpd.Parameters.AddWithValue("@NombreCliente", nombreCliente ?? (object)DBNull.Value);
                            cmdUpd.Parameters.AddWithValue("@NumeroCliente", numeroCliente ?? (object)DBNull.Value);
                            cmdUpd.Parameters.AddWithValue("@CostoInstalacion", costoInstalacion);
                            cmdUpd.Parameters.AddWithValue("@CostoFlete", costoFlete);
                            cmdUpd.Parameters.AddWithValue("@Subtotal", subtotal);
                            cmdUpd.Parameters.AddWithValue("@Descuento", descuento);
                            cmdUpd.Parameters.AddWithValue("@Total", total);
                            cmdUpd.Parameters.AddWithValue("@Notas", notas ?? (object)DBNull.Value);
                            cmdUpd.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                            int affected = cmdUpd.ExecuteNonQuery();
                            if (affected == 0)
                                throw new InvalidOperationException("No se encontró la cotización a actualizar.");
                        }

                        // Borrar detalles anteriores
                        using (var cmdDel = new SqlCommand("DELETE FROM CotizacionDetalle WHERE IdCotizacion = @IdCotizacion;", conn, tran))
                        {
                            cmdDel.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                            cmdDel.ExecuteNonQuery();
                        }

                        // Insertar nuevos detalles
                        foreach (DataGridViewRow row in tablaCotizacion.Rows)
                        {
                            if (row.IsNewRow) continue;

                            using (var cmdDetalle = new SqlCommand(@"
                                INSERT INTO CotizacionDetalle
                                (IdCotizacion, ClaveProducto, Descripcion, Unidad, PrecioUnitario, Cantidad, Subtotal, AplicaDescuento)
                                VALUES (@IdCotizacion, @ClaveProducto, @Descripcion, @Unidad, @PrecioUnitario, @Cantidad, @Subtotal, @AplicaDescuento);", conn, tran))
                            {
                                cmdDetalle.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                                cmdDetalle.Parameters.AddWithValue("@ClaveProducto", row.Cells["CLAVE"].Value ?? "");
                                cmdDetalle.Parameters.AddWithValue("@Descripcion", row.Cells["DESCRIPCIÓN"].Value ?? "");
                                cmdDetalle.Parameters.AddWithValue("@Unidad", row.Cells["UNIDAD"].Value ?? "");
                                cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", row.Cells["PRECIO"].Value ?? 0);
                                cmdDetalle.Parameters.AddWithValue("@Subtotal", row.Cells["Subtotal"].Value ?? 0);
                                cmdDetalle.Parameters.AddWithValue("@Cantidad", row.Cells["CANTIDAD"].Value ?? 0);
                                cmdDetalle.Parameters.AddWithValue("@AplicaDescuento", int.TryParse(row.Cells["Descuento"]?.Value?.ToString(), out int d) ? d : 0);
                                cmdDetalle.ExecuteNonQuery();
                            }
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

        public static void ActualizarCotizacionTablas(
            int idCotizacion,
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
            List<List<object[]>> tablas)
        {
            using (var conn = ConnectionToSql.GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Actualizar encabezado
                        using (var cmdUpd = new SqlCommand(@"
                            UPDATE Cotizacion
                            SET NumeroCotizacion = @NumeroCotizacion,
                                Fecha = @Fecha,
                                NombreCliente = @NombreCliente,
                                NumeroCliente = @NumeroCliente,
                                CostoInstalacion = @CostoInstalacion,
                                CostoFlete = @CostoFlete,
                                Subtotal = @Subtotal,
                                Descuento = @Descuento,
                                Total = @Total,
                                Notas = @Notas
                            WHERE IdCotizacion = @IdCotizacion;", conn, tran))
                        {
                            cmdUpd.Parameters.AddWithValue("@NumeroCotizacion", numeroCotizacion);
                            cmdUpd.Parameters.AddWithValue("@Fecha", fecha);
                            cmdUpd.Parameters.AddWithValue("@NombreCliente", nombreCliente ?? (object)DBNull.Value);
                            cmdUpd.Parameters.AddWithValue("@NumeroCliente", numeroCliente ?? (object)DBNull.Value);
                            cmdUpd.Parameters.AddWithValue("@CostoInstalacion", costoInstalacion);
                            cmdUpd.Parameters.AddWithValue("@CostoFlete", costoFlete);
                            cmdUpd.Parameters.AddWithValue("@Subtotal", subtotal);
                            cmdUpd.Parameters.AddWithValue("@Descuento", descuento);
                            cmdUpd.Parameters.AddWithValue("@Total", total);
                            cmdUpd.Parameters.AddWithValue("@Notas", notas ?? (object)DBNull.Value);
                            cmdUpd.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                            int affected = cmdUpd.ExecuteNonQuery();
                            if (affected == 0)
                                throw new InvalidOperationException("No se encontró la cotización a actualizar.");
                        }

                        // Borrar detalles anteriores
                        using (var cmdDel = new SqlCommand("DELETE FROM CotizacionDetalle WHERE IdCotizacion = @IdCotizacion;", conn, tran))
                        {
                            cmdDel.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                            cmdDel.ExecuteNonQuery();
                        }

                        // Insertar nuevos detalles desde las tablas
                        foreach (var tabla in tablas)
                        {
                            foreach (var row in tabla)
                            {
                                using (var cmdDetalle = new SqlCommand(@"
                                    INSERT INTO CotizacionDetalle
                                    (IdCotizacion, ClaveProducto, Descripcion, Unidad, PrecioUnitario, Cantidad, Subtotal, AplicaDescuento)
                                    VALUES (@IdCotizacion, @ClaveProducto, @Descripcion, @Unidad, @PrecioUnitario, @Cantidad, @Subtotal, @AplicaDescuento);", conn, tran))
                                {
                                    cmdDetalle.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                                    cmdDetalle.Parameters.AddWithValue("@ClaveProducto", row.Length > 1 ? row[1] ?? "" : "");
                                    cmdDetalle.Parameters.AddWithValue("@Descripcion", row.Length > 2 ? row[2] ?? "" : "");
                                    cmdDetalle.Parameters.AddWithValue("@Unidad", row.Length > 3 ? row[3] ?? "" : "");
                                    cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", row.Length > 4 ? row[4] ?? 0 : 0);
                                    cmdDetalle.Parameters.AddWithValue("@Cantidad", row.Length > 5 ? row[5] ?? 0 : 0);
                                    cmdDetalle.Parameters.AddWithValue("@Subtotal", row.Length > 6 ? row[6] ?? 0 : 0);
                                    cmdDetalle.Parameters.AddWithValue("@AplicaDescuento", int.TryParse(row.Length > 0 ? row[0]?.ToString() : "0", out int d) ? d : 0);
                                    cmdDetalle.ExecuteNonQuery();
                                }
                            }
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
    }
}