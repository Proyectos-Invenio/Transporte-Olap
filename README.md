# Documentación del Proyecto OLAP para transporte

## Diseño y Construcción de la Base de Datos y el Cubo OLAP
- **Base de Datos Transaccional:** Diseñada en SQL Server con tablas para clientes, vehículos, conductores, rutas y servicios de transporte.
- **Cubo OLAP:** Facilita el análisis multidimensional con dimensiones como Cliente, Vehículo, Conductor, Ruta y Fecha/Hora.

## Arquitectura del Portal Web
- Desarrollado en HTML, CSS, JavaScript y C#, ofrece diferentes vistas basadas en el rol del usuario, integrando análisis a través del cubo OLAP.

## Funcionalidades por Tipo de Usuario
- **Administradores:** acceso completo al cubo y poder modificar o actualizar datos.
- **Gerente:** consultas predefinidas, visualizar reportes gráficos y descargar informes.
- **Analista de datos:** Acceso a crear sus propios análisis, generar nuevos reportes y exportar datos.

## Respaldos y Configuraciones TCP/IP
- Regular backup via SQL Server scripts. TCP/IP settings optimized for performance and security.

## Problemas y Soluciones
- **Desafío:** Errores al construir el cubo OLAP y dificultades para integrarlo con el portal web debido a falta de experiencia técnica.
- **Solución:** Incrementamos nuestra investigación en técnicas de OLAP y utilizamos recursos educativos especializados para fortalecer nuestro entendimiento y habilidades en la integración de tecnologías, lo que resultó en una implementación exitosa y optimizada.
