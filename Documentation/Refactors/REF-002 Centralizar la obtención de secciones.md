## REF-002 #

# Objetivo
Centralizar el código necesario para cargar las secciones en los controles de la interfaz.

# Problema
Código para obtener las secciones duplicado en FormAnyadir y FormOpciones

# ¿Quién lo necesita?
FormAnyadir
FormOpciones

# ¿Qué datos necesito?
El enum Seccion

# ¿Qué clases cambian?
FuncionesInterfaz, en ella hemos implementado la nueva función para rellenar el combobox.

# ¿Qué formularios cambian?
FormAnyadir
FormOpciones

# ¿Qué métodos cambian?
private void FormOpciones_Load(object sender, EventArgs e)
private void CargarSecciones()

# Casos de prueba
- El ComboBox de FormAñadir muestra todas las secciones.
- El ComboBox de FormOpciones muestra todas las secciones.
- Al añadir una nueva sección al enum, aparece automáticamente en ambos formularios.
- No existen bucles foreach duplicados para cargar las secciones.

# Posibles problemas
- Que los ComboBox no se rellenen correctamente.
- Que algún formulario siga utilizando el foreach antiguo.
- Que aparezcan secciones duplicadas.
- Que una modificación futura vuelva a introducir código duplicado.

# Resultado esperado


# Notas
