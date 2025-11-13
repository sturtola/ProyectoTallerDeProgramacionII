using AurenPadelStore.CEntidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace AurenPadelStore.CDatos
{
    public class UsuarioDatos
    {
        private readonly string connectionString =
            "Server=DESKTOP-CBNOHGE;Database=AurenPadelBD;Encrypt=False;TrustServerCertificate=True;Trusted_Connection=True;";

        // Lista de DNIs (por si querés poblar combos)
        public List<int> ListarUsuarios()
        {
            var dnis = new List<int>();
            using var cn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(
                "SELECT Dni_Usuario FROM dbo.Usuario ORDER BY Dni_Usuario;", cn);
            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
                dnis.Add(dr.GetInt32(0));
            return dnis;
        }

        public List<Usuario> ObtenerTodos()
        {
            var lista = new List<Usuario>();
            using var cn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(@"
                SELECT id_Usuario,
                       Dni_Usuario,
                       Nombre_Usuario,
                       Apellido_Usuario,
                       [Contraseña_Usuario],
                       Rol_Usuario,
                       Estado_Usuario
                FROM dbo.Usuario
                ORDER BY Apellido_Usuario, Nombre_Usuario;", cn);

            cn.Open();
            using var dr = cmd.ExecuteReader();

            int oId = dr.GetOrdinal("id_Usuario");
            int oDni = dr.GetOrdinal("Dni_Usuario");
            int oNom = dr.GetOrdinal("Nombre_Usuario");
            int oApe = dr.GetOrdinal("Apellido_Usuario");
            int oPass = dr.GetOrdinal("Contraseña_Usuario");
            int oRol = dr.GetOrdinal("Rol_Usuario");
            int oEst = dr.GetOrdinal("Estado_Usuario");

            while (dr.Read())
            {
                lista.Add(new Usuario
                {
                    id_Usuario = dr.GetInt32(oId),
                    Dni_Usuario = dr.GetInt32(oDni),
                    Nombre_Usuario = dr.GetString(oNom),
                    Apellido_Usuario = dr.GetString(oApe),
                    Contraseña_Usuario = dr.GetString(oPass),
                    Rol_Usuario = dr.GetString(oRol),
                    Estado_Usuario = dr.GetBoolean(oEst)
                });
            }
            return lista;
        }

        public Usuario ObtenerPorDni(int dni)
        {
            using var cn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(@"
                SELECT id_Usuario,
                       Dni_Usuario,
                       Nombre_Usuario,
                       Apellido_Usuario,
                       [Contraseña_Usuario],
                       Rol_Usuario,
                       Estado_Usuario
                FROM dbo.Usuario
                WHERE Dni_Usuario = @dni;", cn);
            cmd.Parameters.Add("@dni", System.Data.SqlDbType.Int).Value = dni;

            cn.Open();
            using var dr = cmd.ExecuteReader();
            if (!dr.Read()) return null;

            return new Usuario
            {
                id_Usuario = dr.GetInt32(dr.GetOrdinal("id_Usuario")),
                Dni_Usuario = dr.GetInt32(dr.GetOrdinal("Dni_Usuario")),
                Nombre_Usuario = dr.GetString(dr.GetOrdinal("Nombre_Usuario")),
                Apellido_Usuario = dr.GetString(dr.GetOrdinal("Apellido_Usuario")),
                Contraseña_Usuario = dr.GetString(dr.GetOrdinal("Contraseña_Usuario")),
                Rol_Usuario = dr.GetString(dr.GetOrdinal("Rol_Usuario")),
                Estado_Usuario = dr.GetBoolean(dr.GetOrdinal("Estado_Usuario"))
            };
        }

        /// <summary>
        /// Retorna:
        ///  - null si no existe
        ///  - "" si la contraseña es incorrecta
        ///  - "#INACTIVO" si Estado_Usuario = 0
        ///  - el Rol si login correcto y activo
        /// </summary>
        public string? ValidarUsuario(int dni, string contraseña)
        {
            using var cn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(@"
                SELECT [Contraseña_Usuario], Rol_Usuario, Estado_Usuario
                FROM dbo.Usuario
                WHERE Dni_Usuario = @dni;", cn);
            cmd.Parameters.Add("@dni", System.Data.SqlDbType.Int).Value = dni;

            cn.Open();
            using var dr = cmd.ExecuteReader();
            if (!dr.Read()) return null;

            string passBD = dr.GetString(0);
            bool activo = dr.GetBoolean(2);
            if (!activo) return "#INACTIVO";
            if (!string.Equals(passBD, contraseña, StringComparison.Ordinal)) return "";
            return dr.GetString(1); // Rol_Usuario
        }

        public bool ExisteDni(int dni)
        {
            using var cn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(
                "SELECT COUNT(1) FROM dbo.Usuario WHERE Dni_Usuario = @dni;", cn);
            cmd.Parameters.Add("@dni", System.Data.SqlDbType.Int).Value = dni;

            cn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        public void Insertar(Usuario u)
        {
            using var cn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(@"
                INSERT INTO dbo.Usuario
                    (Dni_Usuario, Nombre_Usuario, Apellido_Usuario, [Contraseña_Usuario], Rol_Usuario, Estado_Usuario)
                VALUES
                    (@dni, @nombre, @apellido, @pass, @rol, @estado);", cn);

            cmd.Parameters.Add("@dni", System.Data.SqlDbType.Int).Value = u.Dni_Usuario;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar, 100).Value = u.Nombre_Usuario;
            cmd.Parameters.Add("@apellido", System.Data.SqlDbType.NVarChar, 100).Value = u.Apellido_Usuario;
            cmd.Parameters.Add("@pass", System.Data.SqlDbType.NVarChar, 200).Value = u.Contraseña_Usuario;
            cmd.Parameters.Add("@rol", System.Data.SqlDbType.NVarChar, 20).Value = u.Rol_Usuario;
            cmd.Parameters.Add("@estado", System.Data.SqlDbType.Bit).Value = u.Estado_Usuario;

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Usuario u, int dniOriginal)
        {
            using var cn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(@"
                UPDATE dbo.Usuario
                SET Dni_Usuario=@dni,
                    Nombre_Usuario=@nombre,
                    Apellido_Usuario=@apellido,
                    [Contraseña_Usuario]=@pass,
                    Rol_Usuario=@rol,
                    Estado_Usuario=@estado
                WHERE Dni_Usuario=@dniOriginal;", cn);

            cmd.Parameters.Add("@dni", System.Data.SqlDbType.Int).Value = u.Dni_Usuario;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar, 100).Value = u.Nombre_Usuario;
            cmd.Parameters.Add("@apellido", System.Data.SqlDbType.NVarChar, 100).Value = u.Apellido_Usuario;
            cmd.Parameters.Add("@pass", System.Data.SqlDbType.NVarChar, 200).Value = u.Contraseña_Usuario;
            cmd.Parameters.Add("@rol", System.Data.SqlDbType.NVarChar, 20).Value = u.Rol_Usuario;
            cmd.Parameters.Add("@estado", System.Data.SqlDbType.Bit).Value = u.Estado_Usuario;
            cmd.Parameters.Add("@dniOriginal", System.Data.SqlDbType.Int).Value = dniOriginal;

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public void CambiarEstado(int dni, bool activar)
        {
            using var cn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(
                "UPDATE dbo.Usuario SET Estado_Usuario = @estado WHERE Dni_Usuario = @dni;", cn);

            cmd.Parameters.Add("@estado", System.Data.SqlDbType.Bit).Value = activar;
            cmd.Parameters.Add("@dni", System.Data.SqlDbType.Int).Value = dni;

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int dni)
        {
            using var cn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(
                "DELETE FROM dbo.Usuario WHERE Dni_Usuario=@dni;", cn);

            cmd.Parameters.Add("@dni", System.Data.SqlDbType.Int).Value = dni;

            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
