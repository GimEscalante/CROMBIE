using Biblioteca_API.Models;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Services
{
    public class LibroService
    {
        private readonly List<Libro> _libros = new List<Libro>();

        public List<Libro> ObtenerLibros()
        {
            return _libros;
        }

        public Libro ObtenerLibroPorISBN(string isbn)
        {
            return _libros.FirstOrDefault(l => l.ISBN == isbn);
        }

        public void AgregarLibro(Libro libro)
        {
            _libros.Add(libro);
        }
    }
}