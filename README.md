# API de Gestión de Tareas - Etapa 1: Conceptos Preliminares

[cite_start]Esta es una Web API desarrollada en C# con .NET 6 o posterior, creada como parte de la Etapa 1 del curso de C# Avanzado del ITLA. [cite: 1] [cite_start]El objetivo es sentar las bases de una API de Gestión de Tareas, implementando funcionalidades esenciales para gestionar tareas de manera estructurada y funcional. [cite: 3]

## Propósito de la API
[cite_start]La API permite realizar operaciones CRUD (crear, leer, actualizar y eliminar) sobre tareas, utilizando un modelo genérico que puede adaptarse a diferentes tipos de datos. [cite: 6] [cite_start]Además, maneja posibles errores y mejora la fluidez de las operaciones mediante llamadas asíncronas. [cite: 7]

## Funcionalidades Implementadas
* **Gestión CRUD de Tareas:**
    * [cite_start]Crear nuevas tareas proporcionando datos básicos como descripción, fecha de vencimiento y estado inicial. [cite: 12]
    * [cite_start]Consultar todas las tareas existentes o buscar tareas específicas mediante filtros como el estado o la fecha de vencimiento. [cite: 13]
    * [cite_start]Actualizar los datos de una tarea existente (descripción, estado). [cite: 14]
    * [cite_start]Eliminar tareas que ya no sean necesarias. [cite: 15]
* [cite_start]**Manejo de Excepciones:** Se ha implementado un sistema robusto de manejo de excepciones para garantizar la confiabilidad de la API, capturando errores y proporcionando respuestas estructuradas al cliente. [cite: 20, 91] [cite_start]Se valida la entrada de datos, como asegurar que la descripción no esté vacía, la fecha de vencimiento sea válida y el identificador no esté duplicado. [cite: 21, 132]
* [cite_start]**Modelo Genérico `Task<T>`:** Se utiliza un modelo genérico `Task<T>` que permite manejar tareas con diferentes tipos de datos asociados, proporcionando flexibilidad para personalizar la información adicional a través del tipo `T`. [cite: 32, 38, 40] [cite_start]Incluye atributos básicos como `Id`, `Description`, `DueDate` y `Status`. [cite: 39]
* [cite_start]**Programación Asíncrona:** Todas las operaciones están implementadas de manera asíncrona utilizando el patrón `async/await`, lo que mejora la responsividad de la API. [cite: 22, 23]

## Estructura del Proyecto
[cite_start]El proyecto sigue una arquitectura en capas (`ApplicationLayer`, `DomainLayer`, `InfrastructureLayer`, `TaskManager`) para mantener el código limpio, organizado y alineado con las mejores prácticas de desarrollo, facilitando el mantenimiento y la expansión futura. [cite: 126]

## Configuración del Entorno
1.  **Requisitos:**
    * .NET SDK 6.0 o superior.
    * Visual Studio 2022 o Visual Studio Code con la extensión C#.
    * SQL Server LocalDB (o cualquier otra base de datos compatible con Entity Framework Core).

2.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/sceballov/TrabajoFinalITLASmailyn.git](https://github.com/sceballov/TrabajoFinalITLASmailyn.git)
    cd TrabajoFinalITLASmailyn
    ```

3.  **Configuración de la Base de Datos:**
    * Abre el archivo `appsettings.json` en la raíz de tu proyecto `TaskManager` (dentro de la carpeta `src/` si usaste esa estructura).
    * Asegúrate de que la cadena de conexión apunte a tu instancia de base de datos.
    * Si realizaste cambios en el modelo de datos (ej. al adaptar `Tareas` a `Task<T>`) y usas Migraciones de EF Core, ejecuta las migraciones para crear o actualizar la base de datos:
        ```bash
        dotnet ef database update --project InfrastructureLayer --startup-project TaskManager
        ```

## Cómo Ejecutar la API
1.  Abre la solución `TrabajoFinalITLASmailyn.sln` en Visual Studio (se encuentra dentro de la carpeta `src/` si seguiste esa estructura).
2.  Establece el proyecto `TaskManager` como proyecto de inicio.
3.  Presiona `F5` para ejecutar la API. Se abrirá la interfaz de Swagger UI en tu navegador (normalmente en `https://localhost:7xxx/swagger`, donde `7xxx` es un puerto asignado).
4.  Alternativamente, puedes ejecutar la API desde la línea de comandos navegando a la carpeta de tu proyecto `TaskManager` y usando:
    ```bash
    dotnet run
    ```

## Cómo Probar la API
Puedes usar Swagger UI, que se abrirá automáticamente al ejecutar la API:
1.  Navega a la URL de Swagger (ej. `https://localhost:7xxx/swagger`).
2.  **Endpoints de Tareas:**
    * [cite_start]**`GET /api/Tareas`**: Para consultar todas las tareas existentes. [cite: 13]
    * [cite_start]**`GET /api/Tareas/{id}`**: Para consultar una tarea específica por su ID. [cite: 13]
    * **`POST /api/Tareas`**: Para crear una nueva tarea. [cite_start]Proporciona un cuerpo de solicitud JSON con `description`, `dueDate`, `status` y `additionalData` (de cualquier tipo, ej. `{ "description": "Tarea de prueba", "dueDate": "2025-08-01T00:00:00", "status": "Pending", "additionalData": { "priority": 1 } }`). [cite: 12]
    * **`PUT /api/Tareas/{id}`**: Para actualizar una tarea existente. [cite_start]Proporciona el ID en la URL y un cuerpo JSON con los datos actualizados. [cite: 14]
    * [cite_start]**`DELETE /api/Tareas/{id}`**: Para eliminar una tarea por su ID. [cite: 15]
3.  **Respuestas Esperadas:**
    * [cite_start]**Éxito (código 2xx):** Las respuestas exitosas incluirán los datos solicitados o la confirmación de la operación. [cite: 114]
    * [cite_start]**Error (código 4xx/5xx):** Las respuestas de error seguirán un formato consistente, por ejemplo: `{"success": false, "message": "Error: No se encontró el recurso solicitado", "errorCode": 404}`. [cite: 115, 121, 122] [cite_start]Proporcionarán información clara sobre el error sin revelar detalles internos del sistema. [cite: 107]

## Preparación para la Expansión Futura
[cite_start]La API está diseñada con una base bien organizada y una estructura modular para facilitar la adición de nuevas funcionalidades y endpoints en las etapas siguientes. [cite: 134]

Etapa 2: Delegados, Funciones Anónimas y Uso de Action y Func

En esta segunda etapa del proyecto, el enfoque principal ha sido enriquecer la flexibilidad y modularidad de la API de Gestión de Tareas. Se han integrado de manera estratégica los conceptos de delegados personalizados, funciones anónimas y los tipos integrados Action y Func de C#. El objetivo primordial fue encapsular y reutilizar la lógica de negocio, simplificando el código y permitiendo una adaptación dinámica del comportamiento de funcionalidades críticas como validaciones de entrada, notificaciones de eventos y cálculos derivados. Esta implementación asegura que el sistema sea más dinámico, robusto y escalable para futuras expansiones.


