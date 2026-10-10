# Horizon Shopping

**Desarrollado por AGG Horizon**

## Descripción

Horizon Shopping es una aplicación para gestionar listas de la compra de forma sencilla, rápida y organizada por secciones.

El proyecto comenzó como una aplicación de escritorio desarrollada con C# y Windows Forms y evolucionó hacia una arquitectura por capas que permite reutilizar la lógica de negocio desde diferentes interfaces.

Actualmente, el desarrollo principal se realiza con .NET MAUI, utilizando Android como plataforma principal de ejecución y pruebas.

Horizon Shopping es un proyecto personal desarrollado progresivamente durante la formación en Desarrollo de Aplicaciones Web (DAW), con el objetivo de aplicar conceptos de programación, arquitectura de software, persistencia de datos y desarrollo de aplicaciones multiplataforma.

## Tecnologías utilizadas

- C#
- .NET 8
- .NET MAUI
- XAML
- Android
- Windows Forms
- JSON
- Supabase
- PostgreSQL
- Visual Studio 2022
- Git y GitHub

## Arquitectura

La solución de Visual Studio, denominada `AGG Horizon`, está organizada en tres proyectos:

- **HorizonShopping.Core:** contiene la lógica compartida, los modelos, los Controllers y los Repositories.
- **HorizonShopping.Maui:** contiene la interfaz principal de la aplicación, desarrollada con .NET MAUI.
- **HorizonShopping.WinForms:** conserva la interfaz de la primera etapa del proyecto y se mantiene como versión Legacy.

La arquitectura separa la interfaz de usuario, la gestión de la lógica de negocio y el acceso a los datos.

La documentación técnica del proyecto se encuentra en la carpeta `Documentation`.

## Funcionalidades actuales

### Gestión de productos

- Añadir productos.
- Añadir varios productos en una misma operación.
- Editar productos y cantidades.
- Eliminar productos.
- Finalizar la compra.
- Filtrar productos por sección.
- Asignar automáticamente una cantidad inicial de 1 al añadir productos.

### Gestión de secciones

- Crear secciones personalizadas.
- Editar secciones.
- Eliminar secciones.
- Mostrar todos los productos.
- Filtrar productos por sección.
- Mostrar las secciones dinámicamente.
- Acceder a las opciones de las secciones mediante pulsación prolongada.

### Iconos de productos

La aplicación identifica iconos mediante el nombre del producto.

El sistema contempla variantes de escritura para reconocer diferentes productos y utiliza un icono genérico cuando no existe una coincidencia específica.

### Apariencia y configuración

La aplicación incluye un apartado de configuración con opciones de apariencia, información sobre Horizon Shopping y sincronización.

Los temas disponibles son:

- Lila.
- Rojo.
- Verde.
- Rosa.
- Amarillo.

El tema seleccionado se guarda mediante las preferencias de la aplicación y se recupera al volver a iniciarla. Los logotipos y los colores de los elementos de la interfaz se adaptan al tema seleccionado.

### Persistencia local

La aplicación utiliza archivos JSON para conservar datos localmente en el dispositivo.

La configuración visual se almacena mediante las preferencias de la aplicación.

### Sincronización entre dispositivos

Horizon Shopping utiliza Supabase como backend y PostgreSQL como base de datos remota.

Las funcionalidades implementadas incluyen:

- Vinculación de dispositivos mediante un código temporal de seis dígitos.
- Vinculación con una lista compartida entre dispositivos.
- Sincronización de productos y secciones.
- Propagación de modificaciones y eliminaciones.
- Resolución de conflictos mediante fechas de modificación.
- Gestión de eliminaciones mediante marcas de borrado lógico (*tombstones*).
- Sincronización automática periódica mientras la pantalla principal está activa.

La sincronización se ha probado entre un dispositivo Android físico y el emulador, incluyendo pruebas de modificación de productos y secciones y escenarios de desconexión y reconexión.

La aplicación mantiene almacenamiento local, mientras que Supabase permite compartir los cambios entre dispositivos vinculados.

## Android

La aplicación se desarrolla y prueba mediante .NET MAUI en Android, utilizando Visual Studio 2022 y un emulador, además de un dispositivo físico.

La interfaz incluye la pantalla principal, las pantallas de gestión de productos y secciones, la configuración y las opciones de vinculación y sincronización.

## Estado del proyecto

Horizon Shopping se encuentra en desarrollo activo.

Las funcionalidades principales de gestión de productos, secciones, configuración, persistencia local y sincronización entre dispositivos están implementadas y han sido probadas.

El siguiente objetivo es revisar la calidad final del proyecto, mantener actualizada la documentación, preparar una compilación de lanzamiento y generar el paquete de distribución para Android.

La publicación y distribución definitiva de la aplicación quedan pendientes de preparación y validación.

## Evolución del proyecto

El proyecto ha pasado por varias etapas:

1. Desarrollo inicial mediante Windows Forms.
2. Separación de responsabilidades mediante Models, Controllers y Repositories.
3. Consolidación de `HorizonShopping.Core`.
4. Migración de la interfaz principal a .NET MAUI.
5. Incorporación de funcionalidades de productos, secciones y personalización visual.
6. Integración de Supabase y desarrollo de la sincronización entre dispositivos.
7. Preparación de la aplicación para su futura distribución.

## Próximos objetivos

- Revisar la arquitectura y la calidad del código.
- Comprobar la seguridad y configuración del backend antes de distribuir la aplicación.
- Preparar y validar la compilación Release.
- Generar el paquete APK o AAB según el destino de distribución.
- Completar las pruebas previas al lanzamiento.
- Actualizar la documentación con cada nueva versión.
- Evaluar futuras funcionalidades, como códigos de barras, favoritos, precios y exportación de listas.

## Autor

**AGG Horizon**

Antonio Gómez García

Proyecto personal de aprendizaje desarrollado durante los estudios de Desarrollo de Aplicaciones Web (DAW).