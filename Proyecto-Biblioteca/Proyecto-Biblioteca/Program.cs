class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();
        int opcion;

        do
        {
            Console.WriteLine("\nMenú del Sistema de Biblioteca");
            Console.WriteLine("1. Agregar Libro");
            Console.WriteLine("2. Registrar Usuario");
            Console.WriteLine("3. Prestar Libro");
            Console.WriteLine("4. Devolver Libro");
            Console.WriteLine("5. Ver Estado de Todos los Libros");
            Console.WriteLine("6. Ver Libros Prestados de un Usuario");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Autor: ");
                    string autor = Console.ReadLine();
                    Console.Write("ISBN: ");
                    string isbn = Console.ReadLine();
                    biblioteca.AgregarLibro(titulo, autor, isbn);
                    break;

                case 2:
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("ID: ");
                    string id = Console.ReadLine();
                    biblioteca.RegistrarUsuario(nombre, id);
                    break;

                case 3:
                    Console.Write("ISBN del libro: ");
                    string isbnPrestar = Console.ReadLine();
                    Console.Write("ID del usuario: ");
                    string usuarioIdPrestar = Console.ReadLine();
                    biblioteca.PrestarLibro(isbnPrestar, usuarioIdPrestar);
                    break;

                case 4:
                    Console.Write("ISBN del libro: ");
                    string isbnDevolver = Console.ReadLine();
                    Console.Write("ID del usuario: ");
                    string usuarioIdDevolver = Console.ReadLine();
                    biblioteca.DevolverLibro(isbnDevolver, usuarioIdDevolver);
                    break;

                case 5:
                    biblioteca.VerEstadoLibros();
                    break;

                case 6:
                    Console.Write("ID del usuario: ");
                    string usuarioIdVer = Console.ReadLine();
                    biblioteca.VerLibrosPrestadosUsuario(usuarioIdVer);
                    break;

                case 7:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 7);
    }
}