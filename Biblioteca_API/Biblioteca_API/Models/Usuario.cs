namespace BibliotecaAPI.Models
{
    public abstract class Usuario
    {
        public string Nombre { get; set; }
        public string IdUsuario { get; set; }
        public List<Libro> LibrosPrestados { get; set; }

        public Usuario(string nombre, string idUsuario)
        {
            Nombre = nombre;
            IdUsuario = idUsuario;
            LibrosPrestados = new List<Libro>();
        }

        public abstract void PrestarMaterial(Libro libro);
        public abstract void DevolverMaterial(Libro libro);
    }

    public class Estudiante : Usuario
    {
        private const int LimiteLibros = 3;

        public Estudiante(string nombre, string idUsuario) : base(nombre, idUsuario) { }

        public override void PrestarMaterial(Libro libro)
        {
            if (LibrosPrestados.Count < LimiteLibros)
            {
                LibrosPrestados.Add(libro);
                libro.Disponible = false;
            }
        }

        public override void DevolverMaterial(Libro libro)
        {
            if (LibrosPrestados.Contains(libro))
            {
                LibrosPrestados.Remove(libro);
                libro.Disponible = true;
            }
        }
    }

    public class Profesor : Usuario
    {
        private const int LimiteLibros = 5;

        public Profesor(string nombre, string idUsuario) : base(nombre, idUsuario) { }

        public override void PrestarMaterial(Libro libro)
        {
            if (LibrosPrestados.Count < LimiteLibros)
            {
                LibrosPrestados.Add(libro);
                libro.Disponible = false;
            }
        }

        public override void DevolverMaterial(Libro libro)
        {
            if (LibrosPrestados.Contains(libro))
            {
                LibrosPrestados.Remove(libro);
                libro.Disponible = true;
            }
        }
    }
}
