## ISSUE #

# Objetivo
Eliminar la duplicación de los botones de filtrado y hacerlo con un solo método.

# Problema
Repetición masiva de código para filtrar las diferentes secciones.

# ¿Quién lo necesita?
FormMenuPrincipal

# ¿Qué datos necesito?
Las secciones alojadas en el Enum Seccion

# ¿Qué clases cambian?
Ninguna

# ¿Qué formularios cambian?
FormMenuPrincipal

# ¿Qué métodos cambian?
InicializarBotonesSeccion()
BotonSeccion_Click()
FormMenuPrincipal_Load()

# Casos de prueba
- Cuando cambiemos de sección.
    En la aplicación se cambia la pantalla de la sección seleccionada.
- Al pulsar cualquier botón se muestra únicamente esa sección.
- El botón "Ver Todo" sigue mostrando todos los productos.
- Añadir un producto y comprobar que sigue apareciendo en la sección correcta.

# Posibles problemas
- Que el botón seleccionado no se corresponda con la sección correcta.
- Que la pantalla deje de actualizar la variable _seccionActual.

# Resultado esperado
Funcionamiento correcto al cambiar de pantallas de seccion dentro de la aplicación como hasta ahora pero simplificando el código.

# Notas
Se elimina la duplicación de los eventos Click de los botones de sección
mediante un único manejador utilizando sender y Tag.
Los Tag se inicializan por código para almacenar el enum Seccion.