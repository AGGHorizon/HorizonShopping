# ROADMAP

## Estado actual

- [x] Aplicación funcional en Windows Forms.
- [x] Gestión de productos.
- [x] Gestión de secciones.
- [x] Configuración de la aplicación.
- [x] Persistencia mediante JSON.
- [x] Arquitectura basada en Models, Controllers y Repositories.
- [x] Core independiente de la interfaz Windows Forms.
- [x] Core preparado para ser reutilizado desde diferentes interfaces.
- [x] Interfaz principal desarrollada mediante .NET MAUI.
- [x] Gestión dinámica de productos y secciones en MAUI.
- [x] Temas visuales y configuración de apariencia.
- [x] Integración de Supabase y PostgreSQL.
- [x] Vinculación de dispositivos mediante códigos temporales.
- [x] Sincronización de productos y secciones entre dispositivos.
- [x] Gestión de modificaciones y eliminaciones.
- [x] Resolución de conflictos mediante fechas de modificación.
- [x] Pruebas funcionales en un dispositivo Android físico y en el emulador.

---

# v3.1 - Introducción del ShoppingController

## Arquitectura

- [x] Crear la capa `ShoppingController`.
- [x] Separar la lógica de negocio de los formularios.
- [x] Centralizar las operaciones relacionadas con productos.
- [x] Reducir el acceso directo de los formularios a los Models.

## Código

- [x] Centralizar la búsqueda de productos.
- [x] Centralizar el borrado de productos.
- [x] Centralizar el borrado por sección.
- [x] Centralizar la obtención de productos.

## Estado

✔ Primera fase del patrón Controller completada.

---

# v3.2 - Consolidación del ShoppingController

## Arquitectura

- [x] Completar la migración de la lógica de negocio al Controller.
- [x] Centralizar el ciclo de vida de los productos.
- [x] Reducir el acoplamiento entre los formularios y los Models.

## Código

- [x] Centralizar la creación de productos.
- [x] Centralizar la modificación de productos.
- [x] Centralizar las validaciones de creación y modificación.
- [x] Eliminar `LeerProducto()` de `FormAnyadir`.
- [x] Incorporar `LeerDatos()` para separar la lectura de controles de la lógica de negocio.

## Preparación

- [x] Preparar la arquitectura para introducir la capa Repository.

## Estado

✔ ShoppingController consolidado.

---

# v3.3 - Introducción del ShoppingRepository

## Arquitectura

- [x] Crear la capa `ShoppingRepository`.
- [x] Desacoplar `ShoppingController` de `ListaCompra`.
- [x] Centralizar el acceso a los datos.
- [x] Establecer Repository como responsable del acceso a `ListaCompra`.

## Código

- [x] Mover las operaciones CRUD al Repository.
- [x] `ShoppingController` trabaja exclusivamente mediante `ShoppingRepository`.
- [x] Los formularios dejan de conocer directamente `ListaCompra`.
- [x] `Program` construye la arquitectura Controller + Repository.

## Estado

✔ Introducción del patrón Repository completada.

---

# v3.4 - Persistencia

## JSON

- [x] Centralizar el guardado de `lista.json` en `ShoppingRepository`.
- [x] Centralizar la carga de `lista.json` en `ShoppingRepository`.
- [x] Eliminar el conocimiento del almacenamiento JSON desde `ListaCompra`.
- [x] Mantener la persistencia compatible con la arquitectura Controller + Repository.

## Arquitectura

- [x] Desacoplar completamente la persistencia del Model.
- [x] Mantener `ShoppingController` independiente del sistema de almacenamiento.
- [x] Preparar la sustitución futura de JSON por otro sistema de almacenamiento.
- [x] Mantener la posibilidad de utilizar SQLite, Supabase u otra solución sin modificar el Controller.

## Estado

✔ Persistencia JSON centralizada y desacoplada.

---

# v3.5 - Consolidación del Core

## Arquitectura

- [x] Crear la solución `AGG Horizon`.
- [x] Separar `HorizonShopping.Core` de `HorizonShopping.WinForms`.
- [x] Centralizar la gestión de productos mediante Controller + Repository.
- [x] Centralizar la gestión de configuración mediante Controller + Repository.
- [x] Mantener los Models independientes del sistema de almacenamiento.
- [x] Preparar el Core para ser reutilizado desde diferentes interfaces.

## Configuración

- [x] Crear `ConfigurationRepository`.
- [x] Crear `ConfigurationController`.
- [x] Trasladar la persistencia de `Configuracion` al Repository.
- [x] Centralizar la carga de `configuracion.json`.
- [x] Centralizar el guardado de `configuracion.json`.
- [x] Crear `ObtenerConfiguracion()`.
- [x] Eliminar los métodos individuales para obtener propiedades de configuración.
- [x] Mantener `Configuracion` como Model.

## Calidad

- [x] Revisar las dependencias entre Models, Controllers y Repositories.
- [x] Aplicar `readonly` en las dependencias que no cambian.
- [x] Comprobar el funcionamiento del Core desde Windows Forms.
- [x] Comprobar la carga y guardado de productos.
- [x] Comprobar la carga y guardado de configuración.
- [x] Dejar el Core preparado para su reutilización en .NET MAUI.

## Estado

✔ Core consolidado y preparado para MAUI.

---

# v4.0 - Primera versión MAUI

## Proyecto

- [x] Crear el proyecto `HorizonShopping.Maui`.
- [x] Añadir el proyecto MAUI a la solución `AGG Horizon`.
- [x] Referenciar `HorizonShopping.Core` desde MAUI.
- [x] Reutilizar Models.
- [x] Reutilizar Controllers.
- [x] Reutilizar Repositories.
- [x] Mantener la lógica de negocio fuera de la interfaz.
- [x] Adaptar la interfaz a XAML.

## Interfaz

- [x] Crear la pantalla principal.
- [x] Crear la pantalla para añadir productos.
- [x] Crear la pantalla para editar productos.
- [x] Crear la pantalla para añadir secciones.
- [x] Crear la pantalla para editar secciones.
- [x] Crear la pantalla de configuración.
- [x] Crear la pantalla de apariencia.
- [x] Crear la pantalla "Acerca de".
- [x] Crear la pantalla de sincronización.
- [x] Implementar navegación entre pantallas.
- [x] Adaptar la gestión de secciones.
- [x] Adaptar la edición de productos.
- [x] Adaptar el borrado de productos.
- [x] Adaptar la finalización de compra.
- [x] Implementar persistencia local mediante JSON.

## Android

- [x] Configurar el entorno Android.
- [x] Crear/configurar el emulador Android.
- [x] Ejecutar la aplicación en Android.
- [x] Comprobar la carga de `lista.json`.
- [x] Comprobar el guardado de `lista.json`.
- [x] Comprobar la configuración.
- [x] Comprobar la navegación.
- [x] Comprobar el funcionamiento de la interfaz.

## Estado

✔ Primera versión MAUI funcional completada.

---

# v4.1 - Experiencia de usuario MAUI

## Productos

- [x] Añadir varios productos desde una misma pantalla.
- [x] Crear filas de productos dinámicamente.
- [x] Eliminar filas individualmente antes de guardar.
- [x] Cantidad por defecto `1`.
- [x] Validar cantidades.
- [x] Ignorar filas vacías.
- [x] Añadir todos los productos de una operación de una sola vez.
- [x] Enfocar automáticamente el campo de nombre al añadir otra fila de producto.

## Secciones

- [x] Crear secciones dinámicamente.
- [x] Mostrar secciones dinámicamente.
- [x] Seleccionar sección activa.
- [x] Mostrar todos los productos.
- [x] Editar secciones.
- [x] Eliminar secciones.
- [x] Eliminar productos asociados al eliminar una sección.
- [x] Implementar pulsación prolongada.

## Iconos

- [x] Crear `ProductoIconService`.
- [x] Crear `ProductIconConverter`.
- [x] Detectar iconos según el nombre del producto.
- [x] Añadir variantes de nombres.
- [x] Añadir icono genérico.

## Apariencia

- [x] Crear `ThemeService`.
- [x] Crear `TemaColor`.
- [x] Tema Lila.
- [x] Tema Rojo.
- [x] Tema Verde.
- [x] Tema Rosa.
- [x] Tema Amarillo.
- [x] Guardar tema seleccionado.
- [x] Recuperar tema al iniciar.
- [x] Cambiar colores de la interfaz.
- [x] Cambiar logotipo según el tema.
- [x] Añadir indicador de selección mediante tick.

## Configuración

- [x] Crear menú de configuración.
- [x] Crear apartado Apariencia.
- [x] Crear apartado Acerca de.
- [x] Crear apartado Sincronización.
- [x] Implementar navegación entre apartados.

## Estado

✔ Interfaz y experiencia de usuario MAUI consolidadas.

---

# v4.2 - Preparación para nube

## Arquitectura

- [x] Revisar la arquitectura existente antes de introducir acceso remoto.
- [x] Mantener la lógica de gestión separada de la interfaz.
- [x] Mantener la persistencia local durante la transición.
- [x] Diseñar la estrategia de almacenamiento remoto y sincronización.

## Modelo de datos

- [x] Definir la estructura de listas de compra.
- [x] Definir la estructura de dispositivos vinculados.
- [x] Definir las secciones y los productos.
- [x] Definir las relaciones entre las entidades.
- [x] Incorporar identificadores para relacionar los registros.
- [x] Utilizar fechas de modificación.
- [x] Incorporar marcas de eliminación lógica.

## Backend

- [x] Crear el proyecto en Supabase.
- [x] Utilizar PostgreSQL como base de datos.
- [x] Crear las tablas necesarias.
- [x] Definir las relaciones.
- [x] Configurar la autenticación interna utilizada por la aplicación.
- [x] Configurar políticas de seguridad RLS.
- [x] Probar la conexión desde C#.
- [x] Implementar funciones remotas para las operaciones de vinculación y gestión de dispositivos.

## Estado

✔ Infraestructura remota implementada y utilizada por la aplicación.

---

# v5.0 - Sincronización

## Usuarios y dispositivos

- [x] Gestionar la identidad interna del dispositivo mediante autenticación.
- [x] Vincular dispositivos mediante códigos temporales.
- [x] Establecer una lista compartida entre dispositivos vinculados.
- [x] Permitir que varios dispositivos trabajen con la misma lista.
- [x] Implementar operaciones de desvinculación.
- [ ] Evaluar cuentas de usuario e inicio de sesión tradicional, si se incorpora esta funcionalidad.

## Listas compartidas

- [x] Crear y asociar listas a los dispositivos.
- [x] Vincular otro dispositivo mediante un código.
- [x] Compartir los datos de una lista entre dispositivos vinculados.
- [x] Mantener la lista disponible aunque uno de los dispositivos se desvincule.
- [ ] Evaluar mecanismos adicionales de invitación y gestión de miembros.

## Sincronización

- [x] Sincronizar productos.
- [x] Sincronizar secciones.
- [x] Sincronizar modificaciones.
- [x] Sincronizar eliminaciones.
- [x] Detectar y resolver conflictos mediante fechas de modificación.
- [x] Actualizar los cambios entre dispositivos.
- [x] Mantener la persistencia local.
- [x] Implementar sincronización automática periódica mientras la pantalla principal está activa.
- [x] Probar cambios sin conexión y sincronización posterior.
- [ ] Evaluar sincronización en tiempo real mediante mecanismos de notificación remota.

## Estado

✔ Sincronización funcional implementada y probada entre un dispositivo Android físico y el emulador.

---

# v6.0 - Funcionalidades avanzadas

- [ ] Código de barras.
- [ ] Productos favoritos.
- [ ] Productos frecuentes.
- [ ] Precio de productos.
- [ ] Total de la compra.
- [ ] Comparación de precios.
- [ ] Compartir mediante QR.
- [ ] Exportar PDF.
- [ ] Exportar Excel.
- [ ] Widgets Android.
- [ ] Recetas y generación de listas de ingredientes.

---

# Publicación

- [ ] Revisar la configuración de la versión Release.
- [ ] Revisar el nombre, identificador y versión de la aplicación.
- [ ] Revisar el icono definitivo de la aplicación.
- [ ] Revisar la seguridad del backend y la configuración de acceso.
- [ ] Comprobar que no se incluyen secretos privados en el repositorio.
- [ ] Preparar la firma de Android.
- [ ] Generar un APK de prueba.
- [ ] Generar un AAB si se decide distribuir mediante Google Play.
- [ ] Instalar y probar la compilación Release.
- [ ] Realizar las pruebas finales.
- [ ] Preparar la distribución.
- [ ] Publicar una versión estable.