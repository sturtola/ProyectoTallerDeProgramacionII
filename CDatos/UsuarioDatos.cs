using AurenPadelStore.CEntidades;
using Microsoft.Data.SqlClient;

namespace AurenPadelStore.CDatos
{
    public class UsuarioDatos
    {
        private readonly string connectionString =
            "Server=DESKTOP-1HCDQL3\\SQLEXPRESS;Database=AurenPadelDB;Trusted_Connection=True;";

        public bool ExisteDni(string dni)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(1) FROM Usuario WHERE Dni = @dni", cn))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                cn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public void Insertar(Usuario u)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Usuario (Nombre, Apellido, Dni, Contraseña, Rol)
                  VALUES (@nom, @ape, @dni, @pass, @rol)", cn))
            {
                cmd.Parameters.AddWithValue("@nom", u.Nombre);
                cmd.Parameters.AddWithValue("@ape", u.Apellido);
                cmd.Parameters.AddWithValue("@dni", u.DNI);
                cmd.Parameters.AddWithValue("@pass", u.Contrasena);
                cmd.Parameters.AddWithValue("@rol", u.Rol);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
