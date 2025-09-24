using AurenPadelStore.CEntidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace AurenPadelStore.CDatos
{
    public class UsuarioDatos
    {
        private readonly string connectionString =
            "Server=DESKTOP-1HCDQL3;Database=AurenPadelBD;Encrypt=False;TrustServerCertificate=True;Trusted_Connection=True;";

        public List<string> ListarUsuarios()
        {
            var usuarios = new List<string>();
            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT DNI FROM Usuario ORDER BY DNI", cn))
            {
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                    while (dr.Read())
                        usuarios.Add(dr.GetString(0));
            }
            return usuarios;
        }

        public List<Usuario> ObtenerTodos()
        {
            var lista = new List<Usuario>();
            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "SELECT DNI, Nombre, Apellido, [Contraseña], Rol, Estado FROM Usuario ORDER BY Apellido, Nombre", cn))
            {
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario
                        {
                            DNI = dr["DNI"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Contrasena = dr["Contraseña"].ToString(),
                            Rol = dr["Rol"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"])
                        });
                    }
                }
            }
            return lista;
        }

        public Usuario ObtenerPorDni(string dni)
        {
            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "SELECT DNI, Nombre, Apellido, [Contraseña], Rol, Estado FROM Usuario WHERE DNI = @dni", cn))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.Read()) return null;
                    return new Usuario
                    {
                        DNI = dr["DNI"].ToString(),
                        Nombre = dr["Nombre"].ToString(),
                        Apellido = dr["Apellido"].ToString(),
                        Contrasena = dr["Contraseña"].ToString(),
                        Rol = dr["Rol"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"])
                    };
                }
            }
        }

        /// <summary>
        /// Retorna:
        ///  - null si no existe el usuario (DNI no encontrado)
        ///  - "" (cadena vacía) si la contraseña es incorrecta
        ///  - "#INACTIVO" si el usuario existe pero Estado = 0 (inactivo)
        ///  - el Rol ("Administrador", "Gerente", "Vendedor") si login correcto y activo
        /// </summary>
        public string? ValidarUsuario(string dni, string contraseña)
        {
            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "SELECT [Contraseña], Rol, Estado FROM Usuario WHERE DNI = @dni", cn))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.Read()) return null; // no existe
                    string passBD = dr["Contraseña"].ToString();
                    bool activo = Convert.ToBoolean(dr["Estado"]);
                    if (!activo) return "#INACTIVO";
                    if (!string.Equals(passBD, contraseña)) return "";
                    return dr["Rol"].ToString();
                }
            }
        }

        public bool ExisteDni(string dni)
        {
            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Usuario WHERE DNI = @dni", cn))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                cn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public void Insertar(Usuario u)
        {
            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "INSERT INTO Usuario (DNI, Nombre, Apellido, [Contraseña], Rol, Estado) " +
                "VALUES (@dni,@nombre,@apellido,@pass,@rol,@estado)", cn))
            {
                cmd.Parameters.AddWithValue("@dni", u.DNI);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@apellido", u.Apellido);
                cmd.Parameters.AddWithValue("@pass", u.Contrasena);
                cmd.Parameters.AddWithValue("@rol", u.Rol);
                cmd.Parameters.AddWithValue("@estado", u.Estado);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Usuario u, string dniOriginal)
        {
            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "UPDATE Usuario SET DNI=@dni, Nombre=@nombre, Apellido=@apellido, [Contraseña]=@pass, Rol=@rol " +
                "WHERE DNI=@dniOriginal", cn))
            {
                cmd.Parameters.AddWithValue("@dni", u.DNI);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@apellido", u.Apellido);
                cmd.Parameters.AddWithValue("@pass", u.Contrasena);
                cmd.Parameters.AddWithValue("@rol", u.Rol);
                cmd.Parameters.AddWithValue("@dniOriginal", dniOriginal);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CambiarEstado(string dni, bool activar)
        {
            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("UPDATE Usuario SET Estado = @estado WHERE DNI = @dni", cn))
            {
                cmd.Parameters.AddWithValue("@estado", activar);
                cmd.Parameters.AddWithValue("@dni", dni);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Si querés eliminación física (no recomendada para históricos)
        public void Eliminar(string dni)
        {
            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("DELETE FROM Usuario WHERE DNI=@dni", cn))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
