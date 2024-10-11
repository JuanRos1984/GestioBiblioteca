# GestionBiblioteca

Este repositorio contiene una API para la gestión de libros, autores y categorías en una biblioteca. La API está desarrollada utilizando Web API con .NET 8 y Entity Framework 8.

**Tecnologías Utilizadas**
.NET 8 para la API.
Entity Framework 8 para la interacción con la base de datos.

**Manejo de Datos**
Se ha implementado la aproximación Database First en Entity Framework 8, donde se trabajó en las tablas y las relaciones entre ellas, y también se crearon varios procedimientos almacenados.

**Diagrama de la Base de Datos**
Puedes consultar el diagrama de la base de datos en este enlace: 
![image](https://github.com/user-attachments/assets/6f01f245-c5ee-40d9-9be8-ba650f5664c8)


**Enfoques Usados en Entity Framework**
Catálogos
Para las entidades que funcionan como catálogos, se codificaron clases y se utilizó el patrón Repository para las operaciones CRUD. Las entidades son:
-Usuario
-Categoría
-Autor
-Roles

Libro y Relaciones
Para las entidades relacionadas con los libros, se utilizaron procedimientos almacenados para la inserción, actualización y eliminación. La API maneja transacciones para asegurar la integridad de los datos, es decir, cuando se inserta o edita un libro, también se afectan las tablas Libro_Autor y Libro_Categoria.

Las entidades manejadas por procedimientos almacenados son:

-Libro
-Libro_Autor
-Libro_Categoria

Nota: La eliminación de cualquier entidad en la base de datos se realiza a través de eliminaciones lógicas. Esto implica que, en lugar de eliminar el registro físicamente, el campo Activo se actualiza a false.

**Autenticación y Roles de Usuario**
La API cuenta con autenticación basada en JWT. Las acciones y permisos dentro de la API están controlados por los roles de los usuarios.

**Acciones Disponibles por Rol**
Público General
Buscar un libro por filtros a través de un endpoint público.

Bibliotecario
El rol de Bibliotecario tiene acceso a las siguientes acciones:
-Obtener el listado de todos los libros.
-Crear nuevos libros.
-Editar libros.
-Eliminar libros (marcar como inactivos).
Además, el bibliotecario también tiene control sobre la **gestión de autores**.

Administrador
El rol de Administrador tiene acceso a las siguientes acciones adicionales:
-Gestión completa de usuarios.
-Gestión de categorías.

**Generación del JWT**
El token JWT se genera cuando el usuario inicia sesión a través del endpoint de Login.
