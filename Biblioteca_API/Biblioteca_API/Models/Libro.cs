﻿namespace BibliotecaAPI.Models
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public bool Disponible { get; set; }

        public Libro(string titulo, string autor, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            Disponible = true;  // Al agregar un libro, por defecto está disponible.
        }
    }
}
