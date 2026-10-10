# Arquitectura de Horizon Shopping

## 1. Objetivo

Horizon Shopping está diseñado para separar la interfaz de usuario, la lógica de negocio y el acceso a los datos.

Los principales objetivos de esta arquitectura son:

- Separar responsabilidades para facilitar el mantenimiento.
- Reutilizar la lógica de negocio desde diferentes interfaces.
- Centralizar el acceso a los datos.
- Facilitar la evolución del sistema de almacenamiento.
- Permitir la sincronización de listas de la compra entre dispositivos.
- Mantener una estructura preparada para incorporar nuevas funcionalidades.

La solución comenzó con Windows Forms y posteriormente evolucionó hacia .NET MAUI, que constituye actualmente la interfaz principal de desarrollo.

## 2. Estructura de la solución

La solución de Visual Studio se denomina `AGG Horizon` y contiene tres proyectos:

- `HorizonShopping.Core`: modelos, lógica de gestión y acceso a datos compartidos.
- `HorizonShopping.Maui`: interfaz actual de la aplicación mediante .NET MAUI.
- `HorizonShopping.WinForms`: interfaz de la primera etapa del proyecto, conservada como versión Legacy.

La documentación general del proyecto se mantiene en la carpeta `Documentation`, situada en la raíz de la solución.

## 3. Separación de responsabilidades

### 3.1. Models

Los modelos representan los datos utilizados por la aplicación.

Entre ellos se encuentran los relacionados con productos, listas de la compra, secciones y configuración.

Su objetivo es representar la información del dominio sin depender directamente de los controles de la interfaz.

### 3.2. Controllers

Los Controllers centralizan las operaciones de gestión y sirven como intermediarios entre la interfaz y las capas de datos.

Entre las responsabilidades implementadas se encuentran:

- Gestionar las operaciones relacionadas con los productos.
- Gestionar las secciones.
- Gestionar la configuración.
- Reducir el acceso directo de la interfaz a los modelos y a los detalles de persistencia.

### 3.3. Repositories

Los Repositories centralizan las operaciones de acceso y persistencia de los datos.

La arquitectura se inició utilizando archivos JSON locales. Posteriormente se incorporó Supabase para almacenar y sincronizar la información entre dispositivos.

La finalidad de esta separación es evitar que la interfaz tenga que gestionar directamente los detalles de almacenamiento.

## 4. Interfaz principal: .NET MAUI

`HorizonShopping.Maui` es el proyecto principal de la aplicación.

Está desarrollado con C#, XAML y .NET MAUI, utilizando Android como plataforma principal de ejecución y pruebas.

La interfaz permite gestionar productos, cantidades, secciones y opciones de apariencia, además de acceder a la configuración y a las funciones de vinculación y sincronización.

El proyecto reutiliza la lógica compartida de `HorizonShopping.Core`.

## 5. Persistencia local

La aplicación utiliza almacenamiento local mediante archivos JSON para conservar los datos en el dispositivo.

La persistencia local permite que la aplicación disponga de una copia de los datos independientemente de las operaciones de sincronización remota.

La configuración visual se conserva mediante las preferencias de la aplicación.

Los detalles concretos de almacenamiento deben mantenerse separados de la interfaz para facilitar futuras modificaciones de la arquitectura.

## 6. Backend y sincronización

Horizon Shopping utiliza Supabase como backend, con PostgreSQL para almacenar los datos remotos.

La solución contempla la gestión de listas, dispositivos vinculados, secciones y productos.

La sincronización permite compartir los cambios entre diferentes dispositivos vinculados a una misma lista.

### 6.1. Vinculación de dispositivos

Los dispositivos se pueden vincular mediante un código temporal de seis dígitos, con una validez de diez minutos.

El sistema permite que varios dispositivos trabajen con una misma lista sin depender de un único dispositivo propietario que deba permanecer conectado.

### 6.2. Sincronización de productos y secciones

La aplicación sincroniza las operaciones de creación, modificación y eliminación de productos y secciones.

La sincronización automática se ejecuta periódicamente mientras la pantalla principal está activa.

### 6.3. Resolución de conflictos

Los registros utilizan fechas de modificación para determinar qué versión de los datos debe prevalecer cuando existen cambios realizados desde distintos dispositivos.

La comparación de fechas debe realizarse de forma coherente con las zonas horarias para evitar que una versión anterior sobrescriba una modificación más reciente.

### 6.4. Eliminaciones

Las eliminaciones se representan mediante marcas de borrado lógico (*tombstones*), en lugar de depender exclusivamente de la eliminación física inmediata del registro remoto.

Este mecanismo permite comunicar las eliminaciones a otros dispositivos y evitar que los elementos eliminados reaparezcan durante la sincronización.

### 6.5. Seguridad

El acceso a los datos remotos está sujeto a las políticas de seguridad configuradas en Supabase.

Las operaciones de vinculación y acceso a las listas se apoyan en funciones y políticas del backend.

La seguridad debe seguir revisándose antes de distribuir públicamente la aplicación.

## 7. Funcionamiento sin conexión

La aplicación mantiene datos locales en el dispositivo. Las modificaciones realizadas sin conexión pueden entrar en conflicto con cambios efectuados desde otros dispositivos.

La sincronización utiliza las fechas de modificación para resolver los conflictos contemplados en la implementación actual.

Este comportamiento se ha probado en escenarios de modificación desde dos dispositivos, incluida la reconexión después de realizar cambios sin conexión.

No debe interpretarse como una garantía de sincronización instantánea ni como una solución para cualquier conflicto imaginable.

## 8. Estado actual de la arquitectura

Actualmente, Horizon Shopping dispone de:

- Interfaz principal desarrollada con .NET MAUI.
- Proyecto compartido `HorizonShopping.Core`.
- Gestión de productos y secciones dinámicas.
- Persistencia local mediante JSON.
- Backend remoto con Supabase y PostgreSQL.
- Vinculación de dispositivos mediante códigos temporales.
- Sincronización de productos y secciones.
- Gestión de eliminaciones mediante marcas de borrado lógico.
- Resolución de conflictos basada en fechas de modificación.
- Temas visuales y preferencias de configuración.

Las funciones principales de gestión y sincronización se han probado en un dispositivo Android físico y en el emulador.

## 9. Evolución futura

Las próximas mejoras arquitectónicas se centrarán en:

- Revisar y documentar las responsabilidades de cada capa.
- Mejorar la gestión de errores y los casos límite de sincronización.
- Revisar la seguridad del backend antes de una distribución pública.
- Preparar la aplicación para una versión de lanzamiento.
- Mantener la documentación técnica alineada con la implementación real.

Las futuras funcionalidades deberán incorporarse respetando la separación de responsabilidades y evitando modificaciones innecesarias en las partes estables del sistema.

## 10. Proyectos de la solución

### HorizonShopping.Core

Contiene la lógica compartida y las capas de gestión y acceso a datos.

### HorizonShopping.Maui

Contiene la interfaz actual de la aplicación y su implementación para Android.

### HorizonShopping.WinForms

Contiene la interfaz histórica desarrollada durante la primera etapa del proyecto.

Su presencia en la solución no significa que sea la interfaz principal de desarrollo actual.