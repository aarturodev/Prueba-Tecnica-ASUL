# 📦 Prueba Técnica - Gestión de Clientes, Productos y Pedidos

Aplicación web desarrollada como parte de una prueba técnica. El sistema permite gestionar clientes, productos y pedidos mediante una API REST en .NET y una interfaz en HTML + JavaScript.

---

## ⚙️ Tecnologías Utilizadas

- **Backend:** ASP.NET Core Web API (.NET 9)
- **Frontend:** HTML + CSS + JavaScript
- **Base de Datos:** SQL Server
- **ORM:** Entity Framework Core
- **Herramientas:** Swagger (NSwag), Fetch API, Visual Studio / VS Code

---

## 🧩 Funcionalidades

### 🔹 Menú principal
- Navegación entre: **Clientes**, **Productos**, **Pedidos**.

### 🔹 Clientes
- Visualiza una tabla con todos los clientes.
- Endpoint: `GET /api/clientes`.

### 🔹 Productos
- Visualiza una tabla con todos los productos.
- Endpoint: `GET /api/productos`.

### 🔹 Pedidos
- Muestra el total de pedidos por cliente.
- Crea pedidos 

---

## 🧪 API - Endpoints REST

| Método | Ruta                   | Descripción                          |
|--------|------------------------|--------------------------------------|
| GET    | `/api/clientes`        | Lista todos los clientes             |
| GET    | `/api/productos`       | Lista todos los productos            |
| GET    | `/api/pedidos`         | Lista total de pedidos por cliente   |
| POST   | `/api/pedidos`         | Inserta un nuevo pedido              |
| DELETE | `/api/pedidos/{id}`    | Elimina un pedido por su ID          |

---

## 🖼️ Interfaz Web

- Estructura HTML con menú de navegación.
- Tablas dinámicas generadas con `JavaScript` y `fetch()`.
- Formulario para registrar nuevos pedidos.
- Comunicación directa con los endpoints de la API REST.

---

## 🛠️ Configuración del Proyecto

### 1. Clonar el repositorio

```bash
git clone https://github.com/aarturodev/Prueba-Tecnica-ASUL.git
cd prueba-tecnica-ASUL
```
### 2. Correr el proyecto
- Configura la conexion a la base de datos
- Ejecuta las migraciones
- Ejecuta el proyecto dotnet run
- Abre el archivo FrontEnd/index.html
