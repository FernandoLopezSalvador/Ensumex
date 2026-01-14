Sistema de cotizaciones desarrollado en C# con Windows Forms, enfocado en pequeñas y medianas empresas que necesitan generar cotizaciones profesionales en PDF de forma rápida, clara y organizada.

Este proyecto nace como una solución práctica para reemplazar procesos manuales y complementar sistemas administrativos como Aspel SAE, enfocándose únicamente en cotizaciones, productos y clientes, sin incluir facturación ni pagos en esta etapa

Características principales

🔐 Inicio de sesión de usuarios

📦 Gestión de productos

👥 Gestión de clientes

🧾 Generación de cotizaciones (PDF, Modificación)

📊 Consulta de información desde base de datos

🔄 Integración con base de datos de Aspel SAE (lectura de productos y clientes)

🗄️ Base de datos propia en SQL Server

🧩 Arquitectura por capas (Presentación, Lógica de negocio, Acceso a datos)

capas

📄 Generación de PDF

El sistema genera cotizaciones en formato PDF con:

Encabezado con datos del cliente

Tabla de productos

Cálculos automáticos

Diseño profesional

Comportamiento dinámico:

Si ningún producto tiene descuento, la columna DESCUENTO no aparece.

Si al menos uno tiene descuento, la columna se muestra automáticamente.


Tecnologías utilizadas

Lenguaje: C#

Framework: .NET (Windows Forms)

Base de datos: SQL Server

IDE: Visual Studio

ORM / Acceso a datos: ADO.NET

Control de versiones: Git

Autor

Fernando López Salvador
Desarrollador .NET
📍 Oaxaca

C#

SQL Server

Windows Forms

Desarrollo de sistemas administrativos

📄 Licencia

Este proyecto es de uso educativo y empresarial.
Todos los derechos reservados.
