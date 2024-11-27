public class Usuario
{
    public string Nombre { get; set; }
    public string Id { get; set; }
    public List<Libro> LibrosPrestados { get; set; } = new List<Libro>();

    public Usuario(string nombre, string id)
    {
        Nombre = nombre;
        Id = id;
    }
}
