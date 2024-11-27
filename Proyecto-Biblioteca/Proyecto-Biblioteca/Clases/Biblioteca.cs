public class Biblioteca
{
    public List<Libro> Libros { get; set; } = new List<Libro>();
    public List<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public void AgregarLibro(string titulo, string autor, string isbn)
    {
        Libros.Add(new Libro(titulo, autor, isbn));
        Console.WriteLine("Libro agregado exitosamente.");
    }

    public void RegistrarUsuario(string nombre, string id)
    {
        Usuarios.Add(new Usuario(nombre, id));
        Console.WriteLine("Usuario registrado exitosamente.");
    }

    public void PrestarLibro(string isbn, string usuarioId)
    {
        var libro = Libros.FirstOrDefault(l => l.ISBN == isbn && l.Disponible);
        var usuario = Usuarios.FirstOrDefault(u => u.Id == usuarioId);

        if (libro == null)
        {
            Console.WriteLine("El libro no está disponible o no existe.");
            return;
        }

        if (usuario == null)
        {
            Console.WriteLine("Usuario no encontrado.");
            return;
        }

        libro.Disponible = false;
        usuario.LibrosPrestados.Add(libro);
        Console.WriteLine($"El libro '{libro.Titulo}' fue prestado a {usuario.Nombre}.");
    }

    public void DevolverLibro(string isbn, string usuarioId)
    {
        var usuario = Usuarios.FirstOrDefault(u => u.Id == usuarioId);

        if (usuario == null)
        {
            Console.WriteLine("Usuario no encontrado.");
            return;
        }

        var libro = usuario.LibrosPrestados.FirstOrDefault(l => l.ISBN == isbn);

        if (libro == null)
        {
            Console.WriteLine("El usuario no tiene este libro prestado.");
            return;
        }

        libro.Disponible = true;
        usuario.LibrosPrestados.Remove(libro);
        Console.WriteLine($"El libro '{libro.Titulo}' fue devuelto por {usuario.Nombre}.");
    }

    public void VerEstadoLibros()
    {
        foreach (var libro in Libros)
        {
            string estado = libro.Disponible ? "Disponible" : "Prestado";
            Console.WriteLine($"Título: {libro.Titulo}, Autor: {libro.Autor}, ISBN: {libro.ISBN}, Estado: {estado}");
        }
    }

    public void VerLibrosPrestadosUsuario(string usuarioId)
    {
        var usuario = Usuarios.FirstOrDefault(u => u.Id == usuarioId);

        if (usuario == null)
        {
            Console.WriteLine("Usuario no encontrado.");
            return;
        }

        if (usuario.LibrosPrestados.Count == 0)
        {
            Console.WriteLine("El usuario no tiene libros prestados.");
            return;
        }

        Console.WriteLine($"Libros prestados a {usuario.Nombre}:");
        foreach (var libro in usuario.LibrosPrestados)
        {
            Console.WriteLine($"- {libro.Titulo} (ISBN: {libro.ISBN})");
        }
    }
}
