## ISSUE #004

# OBJETIVO

Centralizar la lógica de negocio de la aplicación en una nueva clase `ShoppingController`, reduciendo las responsabilidades de los formularios.

# PROBLEMA

Actualmente los formularios contienen parte de la lógica de negocio, realizando operaciones directamente sobre `ListaCompra`. Esto provoca un mayor acoplamiento entre la interfaz y el modelo, dificultando el mantenimiento y futuras ampliaciones.

# ¿Quién lo necesita?

- ShoppingController
- FormMenuPrincipal
- FormAnyadir

# ¿Qué datos necesito?

- ListaCompra
- Producto
- Seccion

# ¿Qué clases cambian?

- ShoppingController (Nueva)
- ListaCompra

# ¿Qué formularios cambian?

- FormMenuPrincipal
- FormAnyadir

# ¿Qué métodos nuevos necesito?

## ShoppingController

- CrearProducto()
- BuscarProducto()
- ModificarProducto()
- BorrarProducto()
- BorrarTodo()
- ObtenerProductos()

## FormAnyadir

- LeerDatos()

# Casos de prueba

- Crear un producto correctamente.
- Editar un producto existente.
- Buscar un producto existente.
- Eliminar un producto.
- Finalizar una compra.
- Detectar productos duplicados antes de crearlos.
- Validar nombres vacíos.
- Validar cantidades menores o iguales a cero.

# Posibles problemas

- Que algún formulario siga modificando directamente `ListaCompra`.
- Duplicar validaciones entre la vista y el Controller.
- No controlar correctamente los parámetros nulos.
- Que los formularios dependan simultáneamente del Controller y del modelo.

# Resultado esperado

Toda la lógica de negocio queda centralizada en `ShoppingController`, mientras que los formularios únicamente gestionan la interacción con el usuario.

# Notas

Este cambio supone el primer paso hacia una arquitectura por capas, separando la Vista del Modelo mediante un Controller.