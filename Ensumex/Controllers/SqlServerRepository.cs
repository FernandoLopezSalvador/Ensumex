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
        private static readonly string connSqlServer = "Server=192.168.1.206;Database=Ensumex;User Id=appuser;Password=ensumex;";

        public static void LimpiarTablas(SqlConnection conn, SqlTransaction transaction)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM INVE01", conn, transaction))
                cmd.ExecuteNonQuery();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM CLIE01", conn, transaction))
                cmd.ExecuteNonQuery();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM PRECIO_X_PROD01", conn, transaction))
                cmd.ExecuteNonQuery();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Mantenimientos", conn, transaction))
                cmd.ExecuteNonQuery();
        }

        public static void InsertarProducto(DataRow row, SqlConnection conn, SqlTransaction transaction)
        {
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

        public static void InsertarCliente(DataRow row, SqlConnection conn, SqlTransaction transaction)
        {
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

        public static void InsertarPrecio(DataRow row, SqlConnection conn, SqlTransaction transaction)
        {
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO PRECIO_X_PROD01 (CVE_ART, CVE_PRECIO, PRECIO)
                  VALUES (@CVE_ART, @CVE_PRECIO, @PRECIO)", conn, transaction))
            {
                cmd.Parameters.AddWithValue("@CVE_ART", row["CVE_ART"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CVE_PRECIO", row["CVE_PRECIO"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PRECIO", row["PRECIO"] ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        } 

        // Obtiene todos los mantenimientos desde la BD local
        public static DataTable GetMantenimientos()
        {
            var dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Mantenimientos";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // Inserta un nuevo mantenimiento
        public static void InsertarMantenimiento(DataRow row, SqlConnection conn, SqlTransaction transaction)
        {
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Mantenimientos 
                    (FolioVenta, Cliente, Telefono, Producto, FechaVenta, NumeroServicios, Estatus)
                    VALUES (@folio, @cliente, @telefono, @producto, @fecha, @servicios, @estatus)", conn, transaction))
            {
                cmd.Parameters.AddWithValue("@folio", row["FOLIO"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cliente", row["CLIENTE"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", row["TELEFONO"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@producto", row["PRODUCTO"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fecha", row["FECHA_VENTA"] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@servicios", 0); 
                cmd.Parameters.AddWithValue("@estatus", "Pendiente");
                cmd.ExecuteNonQuery();
            }
        }

        // Actualiza estatus y número de servicios
        public static void ActualizarMantenimiento(int id, string estatus, int numeroServicios, DateTime fechaServicio)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE Mantenimientos SET Estatus = @estatus, NumeroServicios = @num WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estatus", estatus);
                    cmd.Parameters.AddWithValue("@num", numeroServicios);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertarDetalleMantenimiento(int idMantenimiento, DateTime fechaServicio, string estatus, string observaciones)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO DetallesMantenimientos (IdMantenimiento, FechaServicio, Estatus, Observaciones)
                                 VALUES (@idMantenimiento, @fechaServicio, @estatus, @observaciones)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idMantenimiento", idMantenimiento);
                    cmd.Parameters.AddWithValue("@fechaServicio", fechaServicio);
                    cmd.Parameters.AddWithValue("@estatus", estatus);
                    cmd.Parameters.AddWithValue("@observaciones", observaciones ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connSqlServer);
        }
    }   
}
