# REF-005

# Objetivo

Reducir las responsabilidades de los formularios trasladando la lógica de negocio al `ShoppingController` y reorganizando el flujo de trabajo de creación y edición de productos.

# Problema

Los formularios realizaban operaciones directamente sobre el modelo (`ListaCompra` y `Producto`), mezclando código de interfaz con lógica de negocio y dificultando el mantenimiento del proyecto.

# ¿Quién lo necesita?

- FormMenuPrincipal
- FormAnyadir

# ¿Qué datos necesito?

- ShoppingController
- Producto
- ListaCompra
- Seccion

# ¿Qué clases cambian?

- ShoppingController
- ListaCompra

# ¿Qué formularios cambian?

- FormMenuPrincipal
- FormAnyadir

# ¿Qué métodos cambian?

## FormAnyadir

### Eliminados

- LeerProducto()

### Añadidos

- LeerDatos()

## ShoppingController

### Añadidos

- CrearProducto()
- BuscarProducto()
- ModificarProducto()
- BorrarProducto()
- BorrarTodo()
- ObtenerProductos()

# Casos de prueba

- Crear un producto desde el formulario.
- Editar un producto existente.
- Detectar productos duplicados.
- Modificar un producto existente tras la confirmación del usuario.
- Validar datos incorrectos.
- Comprobar que el formulario únicamente interactúa con el Controller.

# Posibles problemas

- Mantener referencias directas a `ListaCompra` desde los formularios.
- Duplicar validaciones entre Vista y Controller.
- No actualizar correctamente la interfaz tras las operaciones.

# Resultado esperado

Los formularios quedan limitados a leer datos de la interfaz, mostrar mensajes al usuario e invocar operaciones del `ShoppingController`, concentrando la lógica de negocio en una única clase.

# Notas

Este refactor aplica el principio **Single Responsibility Principle (SRP)** al separar la lógica de negocio de la interfaz de usuario. Además, prepara la arquitectura para futuras capas como un `Repository`, mejorando la escalabilidad del proyecto.