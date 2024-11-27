El sistema de biblioteca permitirá registrar libros, usuarios y gestionar el préstamo y devolución de los libros. Todo debe manejarse en memoria y a través de un menú de consola que ofrezca las siguientes funcionalidades:

**Funcionalidades**  
-Agregar Libro: Permite agregar un nuevo libro a la biblioteca ingresando el título, autor e ISBN. Al agregar un libro, debe quedar marcado como disponible para ser prestado.  
-Registrar Usuario: Permite registrar un nuevo usuario en la biblioteca ingresando su nombre e identificador de usuario. Cada usuario tendrá una lista de libros prestados.  
-Prestar Libro: Permite a un usuario tomar prestado un libro disponible. Se pedirá el ISBN del libro y el ID del usuario. El sistema debe verificar que el libro esté disponible antes de prestarlo. Si el libro está disponible, debe actualizarse su estado a no disponible.  
-Devolver Libro: Permite a un usuario devolver un libro prestado. Se solicitará el ISBN del libro y el ID del usuario. El sistema debe verificar que el usuario realmente tenga el libro antes de permitir la devolución.  
-Ver Estado de Todos los Libros: Muestra una lista de todos los libros en la biblioteca, indicando si están disponibles o prestados.  
-Ver Libros Prestados de un Usuario: Permite ver los libros actualmente prestados por un usuario específico, solicitando el ID del usuario.  
-Salir: Finaliza la aplicación.  

**Requisitos Técnicos**  
-Implementar las clases Libro, Usuario y Biblioteca.  
-La clase Libro debe contener propiedades como título, autor, ISBN y si está disponible o no.  
-La clase Usuario debe contener el nombre del usuario, su ID y una lista de libros prestados.  
-La clase Biblioteca debe contener listas de libros y usuarios, y métodos para cada funcionalidad descrita.  
-Implementar un menú de consola que permita al usuario interactuar con cada funcionalidad. El menú debe mostrarse en cada iteración y actualizarse según la opción seleccionada.  
