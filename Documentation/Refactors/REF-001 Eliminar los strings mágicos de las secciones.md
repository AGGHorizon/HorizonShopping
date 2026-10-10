## REF-001#

# Objetivo
Centralizar la gestión de las secciones de la aplicación utilizando un enum para evitar duplicidad, errores de escritura y facilitar el mantenimiento del proyecto.

# Problema
Actualmente las secciones de la aplicación se representan mediante string. Esto permite escribir valores incorrectos, obliga a repetir los mismos textos en distintos lugares del proyecto y dificulta el mantenimiento cuando se añaden o modifican secciones.

# ¿Quién lo necesita?
Toda la aplicación.

# ¿Qué datos necesito?
Todas las secciones existentes.
El nuevo enum Seccion.

# ¿Qué clases cambian?
Producto
Configuracion
ListaCompra
FuncionesInterfaz
Seccion (nuevo enum).

# ¿Qué formularios cambian?
FormMenuPrincipal
FormAnyadir
FormOpciones

# ¿Qué métodos cambian?
ObtenerPorSeccion()
BorrarTodo()
CargarSecciones()
Cualquier método que reciba o devuelva una sección mediante string.

## Plan de refactorización
- Crear el enum Seccion.
- Sustituir los string por Seccion en los modelos.
- Adaptar la lógica de ListaCompra.
- Adaptar FuncionesInterfaz.
- Adaptar los formularios.
- Probar toda la aplicación.

# Casos de prueba
- Se pueden añadir productos en cualquier sección.
- El filtrado por sección sigue funcionando.
- La pantalla inicial configurada continúa funcionando.
- La eliminación por sección continúa funcionando.
- El ComboBox muestra correctamente todas las secciones.
- La configuración se guarda y carga correctamente.

# Posibles problemas
- Cambiar un string por Seccion puede romper métodos existentes.
- El JSON puede necesitar adaptaciones al serializar o deserializar enums.
- Comparaciones que antes eran con texto dejarán de funcionar.
- Pueden aparecer errores de compilación en varias clases hasta completar el refactor.

# Resultado esperado
Toda la aplicación utiliza el enum Seccion como tipo de dato para representar las secciones, eliminando los strings mágicos y mejorando la seguridad y el mantenimiento del código.

# Notas
Este refactor forma parte de la preparación de la arquitectura para la futura migración a .NET MAUI.