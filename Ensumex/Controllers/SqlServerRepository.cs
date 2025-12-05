using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Controllers
{
    public static class SqlServerRepository
    { 
        private static readonly string connSqlServer = "Server=192.168.1.244;Database=Ensumex;User Id=appuser;Password=ensumex;";

        public static void InsertarProducto(DataRow row, SqlConnection conn, SqlTransaction transaction)
        {
            try
            {
                object? clave = row.Table.Columns.Contains("CVE_ART") ? row["CVE_ART"] : null;
                using (SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(1) FROM INVE01 WHERE CVE_ART = @clave", conn, transaction))
                {
                    checkCmd.Parameters.AddWithValue("@clave", clave ?? DBNull.Value);
                    int existe = (int)checkCmd.ExecuteScalar();

                    if (existe > 0)
                    {
                        using (SqlCommand updateCmd = new SqlCommand(
                            @"UPDATE INVE01
                              SET DESCR = @DESCR,UNI_MED = @UNI_MED,COSTO_PROM = @COSTO_PROM,
                              ULT_COSTO = @ULT_COSTO,EXIST = @EXIST WHERE CVE_ART = @clave
                              AND (DESCR <> @DESCR
                              OR UNI_MED <> @UNI_MED
                              OR COSTO_PROM <> @COSTO_PROM
                              OR ULT_COSTO <> @ULT_COSTO
                              OR EXIST <> @EXIST)", conn, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@clave", clave ?? DBNull.Value);
                            updateCmd.Parameters.AddWithValue("@DESCR", row["DESCR"] ?? DBNull.Value);
                            updateCmd.Parameters.AddWithValue("@UNI_MED", row["UNI_MED"] ?? DBNull.Value);
                            updateCmd.Parameters.AddWithValue("@COSTO_PROM", row["COSTO_PROM"] ?? DBNull.Value);
                            updateCmd.Parameters.AddWithValue("@ULT_COSTO", row["ULT_COSTO"] ?? DBNull.Value);
                            updateCmd.Parameters.AddWithValue("@EXIST", row["EXIST"] ?? DBNull.Value);
                           
                            updateCmd.ExecuteNonQuery();
                        }

                        return;
                    }
                }
                using (SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO INVE01 (CVE_ART, DESCR, UNI_MED, COSTO_PROM, ULT_COSTO, EXIST)
                        VALUES (@CVE_ART, @DESCR, @UNI_MED, @COSTO_PROM, @ULT_COSTO, @EXIST)", conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@CVE_ART", row["CVE_ART"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DESCR", row["DESCR"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UNI_MED", row["UNI_MED"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@COSTO_PROM", row["COSTO_PROM"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ULT_COSTO", row["ULT_COSTO"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EXIST", row["EXIST"] ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error SQL: " + ex.Message);
                throw; 
            }
            catch (Exception ex)
            {   
                Console.WriteLine("Error inesperado: " + ex.Message);
                throw;
            }
        }

        public static void InsertarCliente(DataRow row, SqlConnection conn, SqlTransaction transaction)
        {
            try
            {
                object? clave = row.Table.Columns.Contains("CLAVE") ? row["CLAVE"] : null;

            using (SqlCommand checkCmd = new SqlCommand(
                "SELECT COUNT(1) FROM CLIE01 WHERE CLAVE = @clave", conn, transaction))
            {
                checkCmd.Parameters.AddWithValue("@clave", clave ?? DBNull.Value);
                int existe = (int)checkCmd.ExecuteScalar();

                if (existe > 0)
                {
                    using (SqlCommand updateCmd = new SqlCommand(
                      @"UPDATE CLIE01 SET STATUS = @STATUS,
                      NOMBRE = @NOMBRE,TELEFONO = @TELEFONO, CALLE = @CALLE,
                      COLONIA = @COLONIA, MUNICIPIO = @MUNICIPIO, EMAILPRED = @EMAILPRED
                      WHERE CLAVE = @clave AND (STATUS <> @STATUS
                      OR NOMBRE <> @NOMBRE
                      OR CALLE <> @CALLE
                      OR COLONIA <> @COLONIA
                      OR MUNICIPIO <> @MUNICIPIO
                      OR EMAILPRED <> @EMAILPRED)", conn, transaction))
                    {
                        updateCmd.Parameters.AddWithValue("@clave", clave ?? DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@STATUS", row["STATUS"] ?? DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@NOMBRE", row["NOMBRE"] ?? DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@TELEFONO", row["TELEFONO"] ?? DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@CALLE", row["CALLE"] ?? DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@COLONIA", row["COLONIA"] ?? DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@MUNICIPIO", row["MUNICIPIO"] ?? DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@EMAILPRED", row["EMAILPRED"] ?? DBNull.Value);
                        updateCmd.ExecuteNonQuery();
                    }
                    return; 
                }
            }

            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO CLIE01 (CLAVE, STATUS, NOMBRE, CALLE, COLONIA, MUNICIPIO, EMAILPRED)
                VALUES (@CLAVE, @STATUS, @NOMBRE, @CALLE, @COLONIA, @MUNICIPIO, @EMAILPRED)", conn, transaction))
            {
                cmd.Parameters.AddWithValue("@CLAVE", row["CLAVE"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@STATUS", row["STATUS"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NOMBRE", row["NOMBRE"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CALLE", row["CALLE"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@COLONIA", row["COLONIA"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MUNICIPIO", row["MUNICIPIO"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EMAILPRED", row["EMAILPRED"] ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error SQL: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inesperado: " + ex.Message);
                throw;
            }
        }

        public static void InsertarPrecio(DataRow row, SqlConnection conn, SqlTransaction transaction)
        {
            try
            {
                object? claveProducto = row.Table.Columns.Contains("CVE_ART") ? row["CVE_ART"] : null;
                object? clavePrecio = row.Table.Columns.Contains("CVE_PRECIO") ? row["CVE_PRECIO"] : null;
                using (SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(1) FROM PRECIO_X_PROD01 WHERE CVE_ART = @claveProducto AND CVE_PRECIO = @clavePrecio",
                    conn, transaction))
                    {
                    checkCmd.Parameters.AddWithValue("@claveProducto", claveProducto ?? DBNull.Value);
                    checkCmd.Parameters.AddWithValue("@clavePrecio", clavePrecio ?? DBNull.Value);
                    int existe = (int)checkCmd.ExecuteScalar();
                    if (existe > 0)
                    {
                        using (SqlCommand updateCmd = new SqlCommand(
                            @"UPDATE PRECIO_X_PROD01 SET PRECIO = @PRECIO
                            WHERE CVE_ART = @claveProducto
                            AND CVE_PRECIO = @clavePrecio
                            AND PRECIO <> @PRECIO", conn, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@claveProducto", claveProducto ?? DBNull.Value);
                            updateCmd.Parameters.AddWithValue("@clavePrecio", clavePrecio ?? DBNull.Value);
                            updateCmd.Parameters.AddWithValue("@PRECIO", row["PRECIO"] ?? DBNull.Value);
                            updateCmd.ExecuteNonQuery();
                        }
                        return; 
                    }
                }   
                

            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO PRECIO_X_PROD01 (CVE_ART, CVE_PRECIO, PRECIO)
                VALUES (@CVE_ART, @CVE_PRECIO, @PRECIO)", conn, transaction))
            {
                cmd.Parameters.AddWithValue("@CVE_ART", claveProducto ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CVE_PRECIO", clavePrecio ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PRECIO", row["PRECIO"] ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error SQL: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inesperado: " + ex.Message);
                throw;
            }
        } 

      public static void InsertarMantenimiento(DataRow row, SqlConnection conn, SqlTransaction transaction)
      {
            try
            {
                object? folio = row.Table.Columns.Contains("FOLIO") ? row["FOLIO"] : null;

                using (SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(1) FROM Mantenimientos WHERE FolioVenta = @folio", conn, transaction))
                {
                    checkCmd.Parameters.AddWithValue("@folio", folio ?? DBNull.Value);
                    int existe = (int)checkCmd.ExecuteScalar();

                    if (existe > 0)
                    {
                        return;
                    }
                }
                string clienteNombre = row.Table.Columns.Contains("CLIENTE") ? row["CLIENTE"]?.ToString() : null;
                string productoNombre = row.Table.Columns.Contains("PRODUCTO") ? row["PRODUCTO"]?.ToString() : null;
                string clienteId = !string.IsNullOrEmpty(clienteNombre) ? ObtenerClaveClientePorNombre(clienteNombre, conn, transaction) : null;
                string productoId = !string.IsNullOrEmpty(productoNombre) ? ObtenerClaveProductoPorNombre(productoNombre, conn, transaction) : null;

                using (SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Mantenimientos 
                      (FolioVenta, ClienteId, ProductoId, FechaVenta, FrecuenciaMeses, Estatus)
                      VALUES (@folio, @clienteId, @productoId, @fecha, @frecuencia, @estatus)",
                    conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@folio", folio ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@clienteId", clienteId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@productoId", productoId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@fecha", row.Table.Columns.Contains("FECHA_VENTA") ? row["FECHA_VENTA"] ?? DBNull.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@frecuencia", row.Table.Columns.Contains("FRECUENCIA") ? row["FRECUENCIA"] ?? 12 : 12);
                    cmd.Parameters.AddWithValue("@estatus", "Pendiente");
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error SQL: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inesperado: " + ex.Message);
                throw;
            }
        }

        public static void InsertarDetalleMantenimiento(int mantenimientoId, string realizadoPor, string observaciones)
        {
            try {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    using (SqlCommand checkCmd = new SqlCommand(
                        "SELECT COUNT(1) FROM DetallesMantenimientos WHERE MantenimientoId = @id AND RealizadoPor = @realizado " +
                        "AND Observaciones = @obs", conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id", mantenimientoId);
                        checkCmd.Parameters.AddWithValue("@realizado", realizadoPor ?? "");
                        checkCmd.Parameters.AddWithValue("@obs", observaciones ?? "");
                        int existe = (int)checkCmd.ExecuteScalar();
                        if (existe > 0) return; 
                    }

                    string query = @"
                                    INSERT INTO DetallesMantenimientos (MantenimientoId, FechaMantenimiento, RealizadoPor, Observaciones)
                                    VALUES (@MantenimientoId, GETDATE(), @RealizadoPor, @Observaciones);";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MantenimientoId", mantenimientoId);
                        cmd.Parameters.AddWithValue("@RealizadoPor", realizadoPor ?? "");
                        cmd.Parameters.AddWithValue("@Observaciones", observaciones ?? "");
                        cmd.ExecuteNonQuery();
                    }
                    string update = @"UPDATE Mantenimientos SET Estatus = 'Realizado' WHERE Id = @MantenimientoId;";
                    using (SqlCommand cmd = new SqlCommand(update, conn))
                    {
                        cmd.Parameters.AddWithValue("@MantenimientoId", mantenimientoId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error SQL: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inesperado: " + ex.Message);
                throw;
            }
        }
        public static DataTable GetMantenimientosConDetalles()
        {
            var dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT 
                    M.Id, C.NOMBRE AS Cliente, C.TELEFONO AS Telefono, P.DESCR AS Producto,
                    M.FechaVenta, M.FrecuenciaMeses AS Frecuencia, M.Estatus,
                    ISNULL(MAX(D.FechaMantenimiento), M.FechaVenta) AS UltimoMantenimiento,
                    DATEADD(MONTH, M.FrecuenciaMeses, ISNULL(MAX(D.FechaMantenimiento), M.FechaVenta)) AS ProximoMantenimiento,
                    COUNT(D.Id) AS NumeroServicios FROM Mantenimientos M
                    JOIN CLIE01 C ON M.ClienteId = C.CLAVE
                    JOIN INVE01 P ON M.ProductoId = P.CVE_ART
                    LEFT JOIN DetallesMantenimientos D ON M.Id = D.MantenimientoId
                    GROUP BY M.Id, C.NOMBRE,C.TELEFONO, P.DESCR, M.FechaVenta, M.FrecuenciaMeses, M.Estatus
                    ORDER BY ProximoMantenimiento DESC;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static string ObtenerClaveClientePorNombre(string nombre, SqlConnection conn, SqlTransaction transaction)
        {
            using (var cmd = new SqlCommand("SELECT CLAVE FROM CLIE01 WHERE NOMBRE = @nombre", conn, transaction))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                var result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        public static string ObtenerClaveProductoPorNombre(string nombre, SqlConnection conn, SqlTransaction transaction)
        {
            using (var cmd = new SqlCommand("SELECT CVE_ART FROM INVE01 WHERE DESCR = @nombre", conn, transaction))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                var result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        public static DataTable GetDetallesMantenimiento(int mantenimientoId)
        {
            var dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                D.Id,C.NOMBRE AS Cliente,D.FechaMantenimiento,
                D.RealizadoPor,D.Observaciones  
                FROM DetallesMantenimientos D
                INNER JOIN Mantenimientos M ON D.MantenimientoId = M.Id
                INNER JOIN CLIE01 C ON M.ClienteId = C.CLAVE
                WHERE D.MantenimientoId = @id
                ORDER BY D.FechaMantenimiento DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", mantenimientoId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public static void ActualizarFrecuenciaMantenimiento(int id, int nuevaFrecuencia)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE Mantenimientos SET FrecuenciaMeses = @frecuencia WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@frecuencia", nuevaFrecuencia);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void ActualizarTelefonoCliente(int mantenimientoId, string nuevoTelefono)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string clienteId = null;
                using (var cmd = new SqlCommand("SELECT ClienteId FROM Mantenimientos WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", mantenimientoId);
                    var result = cmd.ExecuteScalar();
                    clienteId = result?.ToString();
                }

                if (!string.IsNullOrEmpty(clienteId))
                {
                    using (var cmd = new SqlCommand("UPDATE CLIE01 SET TELEFONO = @Telefono WHERE CLAVE = @ClienteId", conn))
                    {
                        cmd.Parameters.AddWithValue("@Telefono", nuevoTelefono ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connSqlServer);
        }
    }   
}
