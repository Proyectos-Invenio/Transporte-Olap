# Documentación del Proyecto OLAP para "Correos de Costa Rica"

## Diseño y Construcción de la Base de Datos y el Cubo OLAP
### Base de Datos Transaccional
- **Estructuración:** Creación de tablas para gestionar clientes, vehículos, conductores, rutas y servicios, asegurando relaciones y restricciones de integridad para mantener la consistencia de los datos.
- **Normalización:** Aplicación de normas de normalización hasta la tercera forma normal para reducir redundancias y mejorar la integridad de los datos.

### Cubo OLAP
- **Desarrollo:** Definición de dimensiones como Cliente, Vehículo, Conductor, Ruta y Tiempo. Configuración de medidas como tiempo de servicio, costos y satisfacción del cliente.
- **Implementación:** Utilización de SQL Server Analysis Services para construir el cubo OLAP, permitiendo análisis complejos y reportes dinámicos.

## Arquitectura del Portal Web
- **Front-end:** Implementación con HTML5, CSS3 y JavaScript para una interfaz responsiva. Uso de frameworks como Bootstrap para el diseño.
- **Back-end:** Desarrollo en C# con ASP.NET para gestionar las solicitudes, procesar datos y conectar con el cubo OLAP.
- **Seguridad:** Implementación de autenticación y autorización para diferentes roles de usuarios, asegurando que cada usuario acceda solo a la información permitida.

## Funcionalidades por Tipo de Usuario
- **Administradores:** Acceso completo al cubo y poder modificar o actualizar datos.
- **Operadores:** Acceso a consultas predefinidas, visualizar reportes gráficos y descargar informes.
- **Clientes:** Acceso a crear sus propios análisis, generar nuevos reportes y exportar datos.

## Respaldos y Configuraciones TCP/IP
- **Respaldos:** Programación de respaldos automáticos diarios y respaldos completos semanales. Estrategias de recuperación ante desastres implementadas para minimizar la pérdida de datos.
- **Configuración de Red:** Detalles sobre la configuración de TCP/IP que incluyen ajustes en el servidor para optimizar la conectividad y la seguridad.

## Problemas y Soluciones
- **Desafío:** Errores durante la implementación del cubo OLAP debido a configuraciones inadecuadas y falta de experiencia en integración con el portal web.
- **Solución:** Se consultaron múltiples fuentes y se realizó un intenso ciclo de pruebas y ajustes que culminó con una implementación exitosa.
