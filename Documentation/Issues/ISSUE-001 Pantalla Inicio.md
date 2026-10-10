## ISSUE #01

# OBJETIVO
Aplicar automáticamente la pantalla inicial seleccionada por el usuario al iniciar la aplicación.


# PROBLEMA
Actualmente la aplicación siempre se inicia mostrando la pantalla por defecto, sin tener en cuenta la configuración guardada por el usuario.


# ¿Quién lo necesita?
FormMenuPrincipal


# ¿Qué datos necesito?
_config.InicioPantalla (string)


# ¿Qué clases cambian?
Ninguna


# ¿Qué formularios cambian?
FormMenuPrincipal


# ¿Qué métodos cambian?
FormMenuPrincipal_Load()

No crear nuevos métodos si no es necesario.
Buscar si ya existe algún método que permita cargar la pantalla correspondiente.


# Casos de prueba
✔ Inicio configurado en "VerTodo"
Debe abrir mostrando toda la lista.

✔ Inicio configurado en "Supermercado"
Debe abrir mostrando únicamente los productos del supermercado.

✔ Inicio configurado en "Farmacia"
Debe abrir mostrando únicamente los productos de farmacia.

✔ Se modifica la configuración y se reinicia la aplicación
Debe abrir con la nueva pantalla seleccionada.


# Posibles problemas
- Que _pantallaActual no se inicialice correctamente.
- Que el valor de InicioPantalla no coincida con ninguna sección válida.
- Que se duplique código en lugar de reutilizar los métodos existentes.


# Resultado esperado
Cuando el usuario elija la pantalla de inicio:
    La aplicación se iniciará en esta.

# Notas
