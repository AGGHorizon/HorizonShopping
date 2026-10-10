# REF-005 Introducción del ShoppingController

# Objetivo
Crear una capa Controller que actúe como intermediaria entre la interfaz y el modelo, reduciendo el acoplamiento existente entre ambos.

# Problema
FormMenuPrincipal realizaba directamente operaciones sobre ListaCompra, mezclando responsabilidades de interfaz con lógica de acceso al modelo.

Esto dificultaba la escalabilidad de la aplicación y complicaba la futura reutilización del código en otras interfaces como .NET MAUI.

# ¿Quién lo necesita?
FormMenuPrincipal

# ¿Qué datos necesito?
- ListaCompra
- Producto
- Seccion

# ¿Qué clases cambian?
- ShoppingController (nueva clase)

# ¿Qué formularios cambian?
FormMenuPrincipal

# ¿Qué métodos cambian?

## Añadidos (ShoppingController)
- BuscarProducto(string nombreProducto)
- BorrarProducto(Producto producto)
- BorrarTodo(Seccion seccion)
- ObtenerProductos(Seccion seccion)

## Modificados (FormMenuPrincipal)
- MostrarProductos()
- ActualizarBotones()
- btnDeleteSelected_Click()
- btnDeleteAll_Click()
- btnBuscar_Click()

# Casos de prueba

- Buscar un producto continúa funcionando correctamente.
- Eliminar un producto sigue actualizando la lista.
- Finalizar compra elimina correctamente los productos de la sección.
- La carga de productos continúa funcionando tanto para una sección como para "Ver Todo".

# Posibles problemas

- Mantener llamadas directas a ListaCompra desde el formulario.
- Duplicar lógica entre FormMenuPrincipal y ShoppingController.
- No actualizar correctamente la interfaz después de una operación.

# Resultado esperado

Las operaciones principales relacionadas con la gestión de productos pasan a realizarse a través de ShoppingController, reduciendo el acoplamiento entre la interfaz y el modelo y facilitando futuras ampliaciones de la arquitectura.

# Notas

Se aplica el principio de **Separación de Responsabilidades (Separation of Concerns)**, introduciendo una capa intermedia encargada de coordinar la comunicación entre la interfaz y el modelo.

Esta refactorización constituye la primera fase de la arquitectura que permitirá reutilizar la lógica de negocio en futuras versiones de Horizon Shopping, como la aplicación desarrollada con .NET MAUI.