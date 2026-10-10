# REF-004 Eliminar la duplicación al cargar productos

# Objetivo
Eliminar la duplicación existente entre los métodos encargados de cargar los productos en el `ListBox`, separando la obtención de datos de su representación en la interfaz.

# Problema
Existían dos métodos (`CargarLista()` y `CargarSecciones()`) que realizaban prácticamente el mismo trabajo.

La única diferencia era el origen de los productos, provocando duplicación de código y dificultando futuras modificaciones.

# ¿Quién lo necesita?
FormMenuPrincipal

# ¿Qué datos necesito?
- Enum `Seccion`.
- Lista de productos (`ListaCompra`).

# ¿Qué clases cambian?
Ninguna.

# ¿Qué formularios cambian?
FormMenuPrincipal

# ¿Qué métodos cambian?

## Eliminados
- `CargarLista()`
- `CargarSecciones()`

## Añadidos
- `ObtenerProductos(Seccion seccion)`
- `CargarProductos(Seccion seccion)`

# Casos de prueba
- La opción **Ver Todo** muestra todos los productos.
- Cada sección muestra únicamente los productos correspondientes.
- Al añadir un producto sigue apareciendo en la sección correcta.
- Cuando no existen productos se sigue mostrando el mensaje correspondiente.

# Posibles problemas
- Mostrar productos de una sección incorrecta.
- No actualizar correctamente el `ListBox`.
- No mostrar correctamente la lista vacía.

# Resultado esperado
La obtención de productos queda separada de la representación de los mismos en la interfaz, eliminando código duplicado y facilitando futuras modificaciones.

# Notas
Se aplica el principio **DRY (Don't Repeat Yourself)** separando la obtención de datos de su representación en la interfaz.

Se mejora la responsabilidad de los métodos haciendo que cada uno tenga una única función claramente definida.