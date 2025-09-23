using AurenPadelStore.CEntidades;
using Microsoft.Data.SqlClient;
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
                "SELECT DNI, Nombre, Apellido, [Contraseña], Rol FROM Usuario ORDER BY Apellido, Nombre", cn))
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
                            Rol = dr["Rol"].ToString()
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
                "SELECT DNI, Nombre, Apellido, [Contraseña], Rol FROM Usuario WHERE DNI = @dni", cn))
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
                        Rol = dr["Rol"].ToString()
                    };
                }
            }
        }

        public string? ValidarUsuario(string dni, string contraseña)
        {
            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "SELECT [Contraseña], Rol FROM Usuario WHERE DNI = @dni", cn))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.Read()) return null;
                    string passBD = dr["Contraseña"].ToString();
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
                "INSERT INTO Usuario (DNI, Nombre, Apellido, [Contraseña], Rol) " +
                "VALUES (@dni,@nombre,@apellido,@pass,@rol)", cn))
            {
                cmd.Parameters.AddWithValue("@dni", u.DNI);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@apellido", u.Apellido);
                cmd.Parameters.AddWithValue("@pass", u.Contrasena);
                cmd.Parameters.AddWithValue("@rol", u.Rol);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 🔧 Actualiza por DNI original (permite cambiar el DNI)
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
