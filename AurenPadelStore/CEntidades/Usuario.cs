public class Usuario
{
    public int id_Usuario { get; set; }
    public int Dni_Usuario { get; set; }
    public string Nombre_Usuario { get; set; }
    public string Apellido_Usuario { get; set; }
    public string Contraseña_Usuario { get; set; }
    public string Rol_Usuario { get; set; }
    public bool Estado_Usuario { get; set; } = true;

    public string NombreMostrar;

    public Usuario() { }

    public Usuario(int dni, string nombre, string apellido, string contrasena, string rol, bool estado = true)
    {
        Dni_Usuario = dni;
        Nombre_Usuario = nombre;
        Apellido_Usuario = apellido;
        Contraseña_Usuario = contrasena;
        Rol_Usuario = rol;
        Estado_Usuario = estado;
    }
}