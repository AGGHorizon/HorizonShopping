## ISSUE #02

# OBJETIVO
Aplicar la configuración de confirmación al finalizar la compra.

# PROBLEMA
Actualmente la aplicación siempre muestra un cuadro de confirmación al finalizar una compra, independientemente de la configuración elegida por el usuario.


# ¿Quién lo necesita?
FormMenuPrincipal


# ¿Qué datos necesito?
config.ConfirmacionFinalizar (bool)


# ¿Qué clases cambian?
Ninguna


# ¿Qué formularios cambian?
FormMenuPrincipal


# ¿Qué métodos nuevos necesito?
Modificación del metodo en el FormMenuPrincipal : private void btnDeleteAll_Click(object sender, EventArgs e)


# Casos de prueba
Confirmación activada
    Debe preguntar antes de borrar.

Confirmación desactivada
    Debe borrar directamente.

Lista vacía
    No debe producir errores.

Usuario pulsa "No"
    No debe borrar nada.


# Posibles problemas
- Olvidar comprobar el valor de _config.ConfirmacionFinalizar.
- Que se siga mostrando el MessageBox aunque la opción esté desactivada.
- Duplicar código innecesariamente.


# Resultado esperado

Si la confirmación está activada:
    Mostrar MessageBox.

Si está desactivada:
    Eliminar directamente los productos.

# Notas
