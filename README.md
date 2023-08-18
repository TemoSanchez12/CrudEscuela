¡Bienvenido al proyecto Blazor WebAssembly con ASP.NET API REST y Entity Framework! En este proyecto, exploraremos cómo construir una aplicación web moderna utilizando Blazor WebAssembly para la interfaz de usuario, ASP.NET para la creación de una API REST y Entity Framework para la persistencia de datos.

## Descripción

Este proyecto es una aplicación de ejemplo que demuestra la integración de tecnologías clave para construir una aplicación web completa. Utilizamos Blazor WebAssembly para crear la interfaz de usuario del lado del cliente, ASP.NET para desarrollar una API RESTful que maneja las solicitudes del cliente y Entity Framework para acceder y gestionar la base de datos.

## Estructura del Proyecto

El repositorio se organiza en las siguientes carpetas:

Client: Contiene el proyecto Blazor WebAssembly. Aquí se encuentra la interfaz de usuario y la lógica del cliente.
Server: Contiene el proyecto ASP.NET. Aquí se define y se implementa la API REST utilizando controladores, servicios y modelos.
Shared: Contiene archivos compartidos entre el cliente y el servidor, como modelos de datos que se utilizan en ambos lados.

## Configuración

Clona este repositorio en tu máquina local.

Abre la solución en tu entorno de desarrollo (Visual Studio, Visual Studio Code, etc.).

Configura la cadena de conexión de la base de datos en el archivo appsettings.Development.json del proyecto Server para que coincida con tu base de datos.

Abre la consola del Administrador de Paquetes (Package Manager Console) y ejecuta las migraciones de Entity Framework para crear la base de datos:

`Update-Database -Context GlobalDbContext`

Inicia el proyecto Server para ejecutar la aplicación. El proyecto Blazor WebAssembly se comunicará con la API REST para obtener y enviar datos.

## Uso

Una vez que la aplicación esté en funcionamiento, podrás explorar diferentes funcionalidades, como la creación, lectura, actualización y eliminación de elementos a través de la interfaz de usuario de Blazor.

Recursos Adicionales
Te dejo la documentación de algunas de las tecnologias que utilice

> [Documentación de Blazor](https://docs.microsoft.com/es-es/aspnet/core/blazor)

> [Documentación de ASP.NET](https://learn.microsoft.com/es-es/aspnet/core/?view=aspnetcore-7.0)

> [Documentación de Entity Framework](https://learn.microsoft.com/es-es/ef/)

_Proyecto realizado por Cuauhtémoc Alejandro Sánchez Carrillo_

**Proximamente se agregara proyecto de testing**
