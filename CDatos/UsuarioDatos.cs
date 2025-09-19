using AurenPadelStore.CEntidades;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace AurenPadelStore.CDatos
{
    public class UsuarioDatos
    {
        private readonly string connectionString =
            "Server=DESKTOP-1HCDQL3;Database=AurenPadelBD;Encrypt=False;TrustServerCertificate=True;Trusted_Connection=True;";

        // Obtiene todos los DNIs de los usuarios para llenar el ComboBox
        public List<string> ListarUsuarios()
        {
            List<string> usuarios = new List<string>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT DNI FROM Usuario ORDER BY DNI", cn))
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        usuarios.Add(dr.GetString(0));
                }
            }
            return usuarios;
        }

        // Retorna rol si contraseña correcta, "" si contraseña incorrecta, null si usuario no existe
        public string? ValidarUsuario(string dni, string contraseña)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Contraseña, Rol FROM Usuario WHERE DNI = @dni", cn))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read()) return null;           // Usuario no existe
                    string passBD = dr["Contraseña"].ToString();
                    if (!string.Equals(passBD, contraseña))
                        return "";                        // Contraseña incorrecta
                    return dr["Rol"].ToString();           // Login correcto
                }
            }
        }

        // Este método se asume existente según tu código
        public bool ExisteDni(string dni)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Usuario WHERE DNI = @dni", cn))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                cn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // Insertar usuario (ya usado en UsuarioLogica)
        public void Insertar(Usuario u)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Usuario (DNI, Nombre, Apellido, Contraseña, Rol) VALUES (@dni,@nombre,@apellido,@pass,@rol)", cn))
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
    }
}
