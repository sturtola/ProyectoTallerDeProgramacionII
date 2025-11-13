using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using AurenPadelStore.CEntidades;

namespace AurenPadelStore.CDatos
{
    public class ClienteDatos
    {
        // Usá tu propia cadena o llevala a una clase Conexion centralizada
        private readonly string cs =
            "Server=DESKTOP-CBNOHGE;Database=AurenPadelBD;Encrypt=False;TrustServerCertificate=True;Trusted_Connection=True;";

        // =========================
        // Lecturas
        // =========================

        /// <summary>
        /// Todos los clientes (activos e inactivos). Útil para ABM.
        /// </summary>
        public List<Cliente> ObtenerTodos()
        {
            var lista = new List<Cliente>();
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                SELECT id_Cliente, Dni_Cliente, Nombre_Cliente, Apellido_Cliente, Direccion_Cliente,
                       Correo_Cliente, Telefono_Cliente, Estado_Cliente
                FROM dbo.Cliente
                ORDER BY Apellido_Cliente, Nombre_Cliente;", cn);
            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
                lista.Add(MapCliente(dr));

            return lista;
        }

        /// <summary>
        /// Solo clientes activos. Ideal para el combo en Generar Venta.
        /// </summary>
        public List<Cliente> ObtenerTodosActivos()
        {
            var lista = new List<Cliente>();
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                SELECT id_Cliente, Dni_Cliente, Nombre_Cliente, Apellido_Cliente, Direccion_Cliente,
                       Correo_Cliente, Telefono_Cliente, Estado_Cliente
                FROM dbo.Cliente
                WHERE Estado_Cliente = 1
                ORDER BY Apellido_Cliente, Nombre_Cliente;", cn);
            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
                lista.Add(MapCliente(dr));

            return lista;
        }

        /// <summary>
        /// Búsqueda server-side por ID, DNI, Nombre o Apellido (solo activos).
        /// Útil si querés filtrar desde la BD en lugar de cliente.
        /// </summary>
        public List<Cliente> BuscarParaVenta(string texto)
        {
            texto ??= string.Empty;
            var q = texto.Trim();

            // Intento parsear números (ID o DNI)
            int idBuscado = 0;
            int.TryParse(q, out idBuscado);

            var lista = new List<Cliente>();
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                SELECT id_Cliente, Dni_Cliente, Nombre_Cliente, Apellido_Cliente, Direccion_Cliente,
                       Correo_Cliente, Telefono_Cliente, Estado_Cliente
                FROM dbo.Cliente
                WHERE Estado_Cliente = 1 AND (
                      id_Cliente = @id
                   OR Dni_Cliente = @dni
                   OR Nombre_Cliente   LIKE @like
                   OR Apellido_Cliente LIKE @like
                )
                ORDER BY Apellido_Cliente, Nombre_Cliente;", cn);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idBuscado;
            cmd.Parameters.Add("@dni", SqlDbType.Int).Value = idBuscado;
            cmd.Parameters.Add("@like", SqlDbType.NVarChar, 200).Value = $"%{q}%";

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
                lista.Add(MapCliente(dr));

            return lista;
        }

        /// <summary>
        /// Trae un cliente por ID (activo o no).
        /// </summary>
        public Cliente? ObtenerPorId(int id)
        {
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                SELECT id_Cliente, Dni_Cliente, Nombre_Cliente, Apellido_Cliente, Direccion_Cliente,
                       Correo_Cliente, Telefono_Cliente, Estado_Cliente
                FROM dbo.Cliente WHERE id_Cliente=@id;", cn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cn.Open();
            using var dr = cmd.ExecuteReader();
            if (!dr.Read()) return null;
            return MapCliente(dr);
        }

        // =========================
        // Escrituras
        // =========================

        public void Insertar(Cliente c)
        {
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                INSERT INTO dbo.Cliente
                (Dni_Cliente, Nombre_Cliente, Apellido_Cliente, Direccion_Cliente,
                 Correo_Cliente, Telefono_Cliente, Estado_Cliente)
                VALUES (@dni, @nom, @ape, @dir, @correo, @tel, @estado);", cn);

            cmd.Parameters.Add("@dni", SqlDbType.Int).Value = c.Dni_Cliente;
            cmd.Parameters.Add("@nom", SqlDbType.NVarChar, 100).Value = c.Nombre_Cliente;
            cmd.Parameters.Add("@ape", SqlDbType.NVarChar, 100).Value = c.Apellido_Cliente;
            cmd.Parameters.Add("@dir", SqlDbType.NVarChar, 300).Value = c.Direccion_Cliente ?? (object)DBNull.Value;
            cmd.Parameters.Add("@correo", SqlDbType.NVarChar, 150).Value = (object?)c.Correo_Cliente ?? DBNull.Value;
            cmd.Parameters.Add("@tel", SqlDbType.NVarChar, 25).Value = c.Telefono_Cliente ?? (object)DBNull.Value;
            cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = c.Estado_Cliente;

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Cliente c)
        {
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                UPDATE dbo.Cliente
                   SET Dni_Cliente=@dni,
                       Nombre_Cliente=@nom,
                       Apellido_Cliente=@ape,
                       Direccion_Cliente=@dir,
                       Correo_Cliente=@correo,
                       Telefono_Cliente=@tel
                 WHERE id_Cliente=@id;", cn);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = c.id_Cliente;
            cmd.Parameters.Add("@dni", SqlDbType.Int).Value = c.Dni_Cliente;
            cmd.Parameters.Add("@nom", SqlDbType.NVarChar, 100).Value = c.Nombre_Cliente;
            cmd.Parameters.Add("@ape", SqlDbType.NVarChar, 100).Value = c.Apellido_Cliente;
            cmd.Parameters.Add("@dir", SqlDbType.NVarChar, 300).Value = c.Direccion_Cliente ?? (object)DBNull.Value;
            cmd.Parameters.Add("@correo", SqlDbType.NVarChar, 150).Value = (object?)c.Correo_Cliente ?? DBNull.Value;
            cmd.Parameters.Add("@tel", SqlDbType.NVarChar, 25).Value = c.Telefono_Cliente ?? (object)DBNull.Value;

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public void CambiarEstado(int idCliente, bool activar)
        {
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(
                "UPDATE dbo.Cliente SET Estado_Cliente=@estado WHERE id_Cliente=@id;", cn);
            cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = activar;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idCliente;

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        // =========================
        // Helpers
        // =========================

        private static Cliente MapCliente(SqlDataReader dr)
        {
            return new Cliente
            {
                id_Cliente = dr.GetInt32(0),
                Dni_Cliente = dr.GetInt32(1),
                Nombre_Cliente = dr.GetString(2),
                Apellido_Cliente = dr.GetString(3),
                Direccion_Cliente = dr.IsDBNull(4) ? string.Empty : dr.GetString(4),
                Correo_Cliente = dr.IsDBNull(5) ? string.Empty : dr.GetString(5),
                Telefono_Cliente = dr.IsDBNull(6) ? string.Empty : dr.GetString(6),
                Estado_Cliente = dr.GetBoolean(7)
            };
        }
    }
}
