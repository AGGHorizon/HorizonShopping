# REF-007 Centralizar la gestión de la configuración

# Objetivo

Aplicar la misma arquitectura utilizada para la gestión de productos a la configuración de la aplicación, separando la lógica de acceso a datos del modelo `Configuracion`.

# Problema

Actualmente la clase `Configuracion` sigue siendo responsable de guardar y cargar sus propios datos mediante JSON. Esto rompe la arquitectura establecida, ya que el resto de la persistencia de la aplicación se encuentra centralizada en `ShoppingRepository`.

# ¿Quién lo necesita?

- Configuracion
- FormOpciones
- Program

# ¿Qué datos necesito?

- Objeto `Configuracion`.
- Archivo `configuracion.json`.

# ¿Qué clases cambian?

- Configuracion
- Nuevo `ConfigurationRepository`
- Nuevo `ConfigurationController`

# ¿Qué formularios cambian?

- FormOpciones
- Program

# ¿Qué métodos cambian?

## Eliminados

- `Configuracion.Guardar()`
- `Configuracion.Cargar()`

## Añadidos

### ConfigurationRepository

- `Guardar()`
- `Cargar()`

### ConfigurationController

- `Guardar()`
- `Cargar()`

# Casos de prueba

- La configuración se carga correctamente al iniciar la aplicación.
- La configuración se guarda correctamente al modificar cualquier opción.
- La interfaz continúa funcionando sin acceder directamente al modelo.
- La aplicación mantiene exactamente el mismo comportamiento que antes del refactor.

# Posibles problemas

- Olvidar actualizar las llamadas desde `Program`.
- Que `FormOpciones` siga utilizando directamente `Configuracion.Guardar()`.
- Duplicar lógica entre Repository y Controller.

# Resultado esperado

Toda la persistencia de la aplicación queda centralizada en la capa Repository, manteniendo una arquitectura homogénea entre productos y configuración.

# Notas

Se unifica completamente la arquitectura del proyecto aplicando el patrón Repository también a la configuración. Esto facilita el futuro reemplazo del almacenamiento JSON por SQLite o Supabase sin modificar la interfaz.