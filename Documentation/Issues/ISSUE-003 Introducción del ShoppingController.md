## ISSUE #03

# OBJETIVO
Introducir la capa `ShoppingController` para comenzar a separar la lógica de negocio de la interfaz gráfica.

# PROBLEMA
Actualmente `FormMenuPrincipal` accede directamente a `ListaCompra` para realizar operaciones como buscar productos, obtener listas o eliminar productos.

Esto provoca un fuerte acoplamiento entre la interfaz y el modelo, dificultando el mantenimiento y la futura reutilización del código en otras plataformas como .NET MAUI.

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

# ¿Qué métodos nuevos necesito?

## ShoppingController
- BuscarProducto(string nombreProducto)
- BorrarProducto(Producto producto)
- BorrarTodo(Seccion seccion)
- ObtenerProductos(Seccion seccion)

## FormMenuPrincipal
Modificar los métodos para utilizar el ShoppingController en lugar de acceder directamente a ListaCompra.

# Casos de prueba

Buscar producto
    Debe encontrar correctamente un producto existente.

Eliminar producto
    Debe eliminar únicamente el producto seleccionado.

Finalizar compra
    Debe eliminar todos los productos de la sección correspondiente.

Mostrar productos
    Debe seguir mostrando correctamente la lista filtrada por sección.

# Posibles problemas

- Mantener llamadas directas a ListaCompra desde el formulario.
- Duplicar lógica entre el formulario y el Controller.
- No actualizar correctamente la interfaz tras realizar una operación.

# Resultado esperado

FormMenuPrincipal deja de depender directamente de ListaCompra para las operaciones principales de gestión de productos.

La lógica de acceso al modelo comienza a centralizarse en ShoppingController, preparando la arquitectura para futuras ampliaciones.

# Notas

Esta es la primera fase de la refactorización hacia una arquitectura basada en Controller.