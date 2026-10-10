# CHANGELOG

---

## v1.0

* Primera versión funcional.
* Gestión de productos.
* Organización por secciones.
* Diseño inicial.

---

## v1.1

* Mejora de la interfaz.
* Edición de productos.
* Confirmaciones.
* Búsqueda.

---

# v2.0 y v2.1 - Persistencia JSON y experiencia de usuario

## Añadido

* Persistencia de datos mediante JSON.
* Carga automática al iniciar la aplicación.
* Guardado automático al cerrar.
* Edición de productos.
* Búsqueda de productos.
* Confirmación al finalizar una compra.

## Mejorado

* Validaciones con `TryParse`.
* Cantidad opcional (`nullable`).
* Excepciones personalizadas.
* Eliminación de todos los warnings del compilador.
* Mejor organización del código.
* Desactivación de botones cuando corresponde.

---

# v2.2 - Configuración

## Añadido

* Nueva clase `Configuracion`.
* Persistencia de la configuración mediante `configuracion.json`.
* Carga automática de la configuración al iniciar la aplicación.
* Guardado automático de la configuración al modificar las opciones.
* Nuevo formulario `FormOpciones`.
* Configuración del tema de la aplicación.
* Configuración de la confirmación al finalizar una compra.
* Configuración de la pantalla inicial de la aplicación.

## Mejorado

* Preparada la aplicación para incorporar nuevas opciones de configuración.
* Separación entre la configuración de la aplicación y la gestión de la lista de la compra.
* Inicialización de la configuración desde `Program`.
* Paso de la configuración entre formularios mediante inyección por constructor.
* La aplicación respeta la configuración elegida por el usuario.

---

# v3.0 - Refactorización y Arquitectura

## Refactorizado

* Sustituidos los strings mágicos de las secciones por el enum `Seccion`.
* Creado el tipo `Seccion` como modelo centralizado de la aplicación.
* Adaptadas las clases `Producto`, `Configuracion` y `ListaCompra` para utilizar el enum.
* Actualizados los formularios para trabajar con `Seccion` en lugar de `string`.
* Eliminadas comparaciones de texto para identificar secciones.
* Centralizada la carga de las secciones en los `ComboBox` mediante `FuncionesInterfaz.RellenarComboBoxSecciones()`.
* Eliminado código duplicado entre `FormAnyadir` y `FormOpciones`.
* Unificados todos los botones de cambio de sección en un único manejador de eventos (`BotonSeccion_Click`).
* Inicialización centralizada de los `Tag` de los botones mediante `InicializarBotonesSeccion()`.
* Eliminada la duplicación entre `CargarLista()` y `CargarSecciones()`.
* Separada la obtención de productos de su representación en la interfaz.
* Incorporados los métodos `ObtenerProductos()` y `CargarProductos()` para centralizar la carga de productos.

## Mejorado

* Mayor seguridad de tipos (Type Safety).
* Eliminación del riesgo de errores por escritura de strings.
* Reducción de código duplicado en `FormMenuPrincipal`.
* Mayor mantenibilidad en la gestión de las secciones.
* Mayor separación de responsabilidades en `FormMenuPrincipal`.
* Arquitectura preparada para continuar la migración hacia .NET MAUI.

---

# v3.1.0 - Introducción del ShoppingController

## Nuevas funcionalidades
- Se ha incorporado la clase `ShoppingController` como primera capa intermedia entre la interfaz y el modelo.

## Refactorizaciones
- La búsqueda de productos ya no se realiza directamente desde `ListaCompra`, sino a través del `ShoppingController`.
- El borrado de un producto seleccionado pasa a gestionarse mediante el `ShoppingController`.
- La eliminación de todos los productos de una sección se centraliza en el `ShoppingController`.
- La obtención de productos por sección deja de depender directamente de `ListaCompra` y pasa a realizarse mediante el `ShoppingController`.

## Mejoras de arquitectura
- `FormMenuPrincipal` reduce su dependencia directa de `ListaCompra`.
- Se inicia la separación de responsabilidades siguiendo una arquitectura basada en Controller.
- La lógica relacionada con la gestión de la lista comienza a centralizarse fuera de la interfaz.

## Estado
✔ Primera fase del patrón Controller completada.

---

# v3.2 - Consolidación del ShoppingController

## Nuevas funcionalidades

- El `ShoppingController` incorpora la gestión completa del ciclo de vida de los productos (crear, modificar, buscar, obtener y eliminar).

## Refactorizaciones

- La creación de productos deja de realizarse directamente desde `FormAnyadir` y pasa a gestionarse mediante el `ShoppingController`.
- La modificación de productos se centraliza en el `ShoppingController`.
- Se trasladan las validaciones principales de creación y edición al `ShoppingController`.
- Se elimina el método `LeerProducto()` del formulario `FormAnyadir`.
- Se incorpora el método `LeerDatos()` para separar la lectura de los controles de la lógica de negocio.
- Se reorganiza el flujo de creación y edición de productos, diferenciando claramente ambos procesos.

## Mejoras de arquitectura

- `FormAnyadir` deja de modificar directamente el modelo.
- Se reduce el acoplamiento entre la interfaz y `ListaCompra`.
- Se consolida el patrón Controller como punto único de acceso a la lógica de negocio.
- La arquitectura queda preparada para introducir una futura capa `Repository`.

## Estado

✔ Segunda fase del patrón Controller completada.

---

# v3.3 - Introducción del ShoppingRepository

## Nuevas funcionalidades

- Se incorpora la nueva capa `ShoppingRepository` para centralizar el acceso a los datos de la aplicación.
- El `ShoppingRepository` pasa a gestionar la persistencia mediante archivos JSON.

## Refactorizaciones

- El `ShoppingController` deja de acceder directamente a `ListaCompra` y pasa a trabajar exclusivamente mediante el `ShoppingRepository`.
- Las operaciones CRUD se trasladan al `ShoppingRepository`.
- Las operaciones de carga y guardado JSON se trasladan completamente al `ShoppingRepository`.
- `Program` pasa a construir toda la arquitectura de la aplicación (Controller + Repository).
- Los formularios dejan de conocer la existencia de `ListaCompra`.

## Mejoras de arquitectura

- Se completa la separación entre interfaz, lógica de negocio y acceso a datos.
- La persistencia queda completamente desacoplada de la interfaz.
- La arquitectura queda preparada para sustituir JSON por otro sistema de almacenamiento sin modificar el Controller.
- La aplicación queda preparada para reutilizar la lógica en .NET MAUI.

## Estado

✔ Introducción del patrón Repository completada.

---

# v3.4 - Persistencia

## Refactorizaciones

- Las operaciones de carga y guardado de `lista.json` quedan centralizadas en `ShoppingRepository`.
- Se elimina el conocimiento del almacenamiento JSON desde `ListaCompra`.
- Se mantiene la compatibilidad con el almacenamiento mediante JSON.
- `ShoppingController` deja de conocer los detalles de persistencia.

## Mejoras de arquitectura

- La persistencia queda completamente desacoplada de los Models.
- `ShoppingRepository` se establece como responsable del acceso al almacenamiento.
- La arquitectura queda preparada para sustituir posteriormente JSON por otro sistema de almacenamiento, como SQLite o Supabase.
- Se mantiene la separación entre interfaz, lógica de negocio, acceso a datos y modelos.

## Estado

✔ Persistencia desacoplada del modelo y centralizada en Repository.

---

# v3.5 - Consolidación del Core

## Nuevas funcionalidades

- Se incorpora `ConfigurationRepository` para centralizar la persistencia de la configuración.
- Se incorpora `ConfigurationController` para gestionar el acceso a la configuración desde la interfaz.

## Refactorizaciones

- La persistencia de `Configuracion` mediante JSON se traslada completamente a `ConfigurationRepository`.
- Se eliminan los métodos de persistencia de la clase `Configuracion`.
- `Configuracion` queda como modelo encargado únicamente de representar los datos de configuración.
- `ConfigurationRepository` centraliza la carga y guardado de `configuracion.json`.
- Se incorpora `ObtenerConfiguracion()` para devolver el objeto de configuración completo.
- Se eliminan los métodos individuales destinados a devolver cada propiedad de configuración.
- `FormMenuPrincipal` y `FormOpciones` trabajan con `ConfigurationController`.
- Los formularios dejan de necesitar acceso a los métodos de persistencia de `Configuracion`.
- Se aplican referencias `readonly` en las dependencias que no cambian durante la ejecución.

## Mejoras de arquitectura

- Se completa la separación entre modelos, Controllers y Repositories.
- La configuración sigue la misma arquitectura por capas que la gestión de productos.
- Los modelos dejan de conocer el sistema de almacenamiento utilizado.
- La persistencia queda centralizada en la capa Repository.
- La solución queda preparada para reutilizar el Core desde diferentes interfaces.
- Se consolida la separación entre `HorizonShopping.Core` y `HorizonShopping.WinForms`.
- El Core queda preparado para ser reutilizado posteriormente desde .NET MAUI.

## Estado

✔ Consolidación del Core completada.

---

# v4.0 - Migración a .NET MAUI

## Nueva plataforma

- Se crea el proyecto `HorizonShopping.Maui`.
- Se incorpora .NET MAUI a la solución `AGG Horizon`.
- Se referencia `HorizonShopping.Core` desde MAUI.
- Se reutilizan Models, Controllers y Repositories.
- La lógica de negocio permanece fuera de la interfaz.

## Interfaz

- Se crea la pantalla principal `MainPage`.
- Se crea la pantalla para añadir productos.
- Se crea la pantalla para editar productos.
- Se crea la pantalla para añadir secciones.
- Se crea la pantalla para editar secciones.
- Se crea la pantalla de configuración.
- Se crea la pantalla de apariencia.
- Se crea la pantalla "Acerca de Horizon Shopping".
- Se crea la pantalla de sincronización.
- Se implementa navegación mediante Shell.

## Android

- Se configura el entorno de desarrollo Android.
- Se configura el emulador Android.
- Se comprueba el funcionamiento de la aplicación en Android.
- Se comprueba la persistencia local de los datos.
- Se comprueba la navegación entre pantallas.

## Estado

✔ Primera versión funcional de Horizon Shopping mediante .NET MAUI.

---

# v4.1 - Interfaz y experiencia de usuario MAUI

## Gestión de productos

- Se implementa la visualización de productos mediante `CollectionView`.
- Se implementa la edición de productos.
- Se implementa el borrado de productos.
- Se implementa la finalización de compra.
- Se incorpora la cantidad de productos.
- Se permite añadir varios productos en una misma operación.
- Se incorpora un botón para añadir dinámicamente nuevas filas de productos.
- Se permite eliminar individualmente una fila antes de guardar los productos.

## Gestión de secciones

- Se abandona la dependencia de botones de sección definidos manualmente.
- Las secciones se generan dinámicamente desde `SeccionController`.
- Se incorpora el botón "Todo".
- Se implementa la selección visual de la sección activa.
- Se incorpora pulsación prolongada sobre las secciones.
- Se implementa la edición de secciones.
- Se implementa la eliminación de secciones.
- Al eliminar una sección se eliminan también sus productos.
- Se mantiene la persistencia independiente de las secciones mediante `SeccionRepository`.

## Iconos de productos

- Se crea `ProductoIconService`.
- Se implementa identificación automática de iconos mediante el nombre del producto.
- Se añaden diferentes variantes de escritura para mejorar la detección.
- Se crea `ProductIconConverter`.
- Se incorpora un icono genérico para productos no reconocidos.

## Apariencia

- Se crea `ThemeService`.
- Se crea el enum `TemaColor`.
- Se incorporan los temas:
  - Lila.
  - Rojo.
  - Verde.
  - Rosa.
  - Amarillo.
- Se implementa cambio dinámico del color principal.
- Se incorporan logotipos específicos para cada tema.
- Se guarda el tema seleccionado mediante `Preferences`.
- El tema seleccionado se recupera automáticamente al iniciar la aplicación.
- Se actualizan dinámicamente los colores de los botones.

## Configuración

- Se crea la pantalla principal de configuración.
- Se incorpora el apartado Apariencia.
- Se incorpora el apartado Acerca de Horizon Shopping.
- Se incorpora el apartado Sincronización.
- Se implementa navegación independiente entre los diferentes apartados.

## Otros

- Se incorpora `LongPressBehavior` para detectar pulsaciones prolongadas en Android.
- Se mejora la separación entre interfaz y lógica de negocio.
- Se mantiene la reutilización del Core desde MAUI.
- Se adapta la aplicación a la interacción táctil.

## Estado

✔ Interfaz MAUI funcional y consolidada.

---

# v4.2 - Preparación para sincronización

## Objetivo

Preparar la aplicación para abandonar progresivamente la persistencia exclusivamente local y permitir la sincronización de listas entre diferentes dispositivos.

## Planificado

- Diseñar el modelo de datos remoto.
- Diseñar las relaciones entre usuarios, listas, secciones y productos.
- Evaluar Supabase como backend.
- Crear una capa de acceso a datos remota.
- Mantener el Controller independiente del sistema de almacenamiento.
- Mantener la posibilidad de conservar la persistencia local durante la transición.

## Estado

⏳ Pendiente de comenzar.


---

# v4.3 - Sincronización entre dispositivos

## Backend y almacenamiento remoto

- Se integra Supabase como backend de la aplicación.
- Se utiliza PostgreSQL para almacenar los datos compartidos.
- Se incorporan las estructuras necesarias para gestionar listas, dispositivos, secciones y productos.
- Se configuran políticas de seguridad para controlar el acceso a los datos.
- Se incorporan funciones remotas para gestionar la vinculación de dispositivos y determinadas operaciones de sincronización.

## Vinculación de dispositivos

- Se implementa la vinculación de dispositivos mediante códigos temporales de seis dígitos.
- Los códigos tienen una validez de diez minutos.
- Se permite vincular varios dispositivos a una misma lista.
- Se evita depender de un único dispositivo para mantener disponible la lista compartida.

## Sincronización

- Se implementa la sincronización de productos entre dispositivos.
- Se implementa la sincronización de secciones.
- Se propagan las modificaciones realizadas desde los dispositivos vinculados.
- Se incorporan mecanismos para comunicar las eliminaciones mediante marcas de borrado lógico (*tombstones*).
- Se implementa una estrategia de resolución de conflictos basada en las fechas de modificación.
- Se incorpora la sincronización automática periódica mientras la pantalla principal está activa.
- Se mantiene el almacenamiento local mediante JSON.

## Resolución de errores

- Se corrige un problema en la comparación de fechas de modificación que podía provocar que una versión anterior de un producto prevaleciera sobre una modificación más reciente.
- Se normalizan las comparaciones de fechas a UTC en las condiciones de sincronización afectadas.
- Se comprueba el comportamiento de la sincronización después de realizar cambios desde distintos dispositivos.

## Interfaz y experiencia de usuario

- Se mejora el flujo de introducción de varios productos en una misma operación.
- Se implementa el enfoque automático del campo de nombre del nuevo producto al añadir otra fila.
- Se facilita la introducción consecutiva de productos desde el teclado del dispositivo.

## Pruebas realizadas

- Pruebas de sincronización entre un dispositivo Android físico y el emulador.
- Comprobación de modificaciones de productos y secciones.
- Comprobación de eliminaciones.
- Pruebas de cambios realizados sin conexión y sincronización posterior.
- Verificación de la persistencia de los cambios después de corregir la comparación de fechas.

## Estado

✔ Funcionalidades principales de sincronización implementadas y probadas en el entorno de desarrollo.

⏳ Pendiente la preparación y validación de la versión de lanzamiento.
