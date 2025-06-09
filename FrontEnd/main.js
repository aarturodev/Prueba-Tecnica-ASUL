document.addEventListener("DOMContentLoaded", ()=>{
  mostrarClientes();
})

const mostrarClientes = () => {
  console.log("mostrando clientes!");

  const contenido = document.getElementById("contenido");

  fetch("http://localhost:5294/api/clientes", {
    method: "GET"
  })
    .then(res => {
      if (!res.ok) {
        throw new Error("Error al obtener clientes");
      }
      return res.json();
    })
    .then(data => {
      console.log("data: ", data);

      // Comienza a construir la tabla
      let html = `<br><table border="1">
        <thead>
          <tr>
            <th>ClienteId</th>
            <th>Nombre</th>
            <th>Ciudad</th>
            <th>Correo</th>
          </tr>
        </thead>
        <tbody>`;

      // Agrega cada cliente como fila
      data.forEach(cliente => {
        html += `<tr>
          <td>${cliente.clienteID}</td>
          <td>${cliente.nombre}</td>
          <td>${cliente.ciudad ?? ''}</td>
          <td>${cliente.correoElectronico ?? ''}</td>
        </tr>`;
      });

      html += `</tbody></table>`;

      contenido.innerHTML = html;
    })
    .catch(error => {
      console.error("Error al cargar clientes:", error);
      contenido.innerHTML = `<p style="color:red;">Error al cargar clientes.</p>`;
    });
};

const mostrarProductos = () => {
  console.log("mostrando Productos!");
  const contenido = document.getElementById("contenido");
  contenido.innerHTML = "";
  fetch("http://localhost:5294/api/productos", {
    method: "GET"
  })
    .then(res => {
      if (!res.ok) {
        throw new Error("Error al obtener productos");
      }
      return res.json();
    })
    .then(data => {
      console.log("data: ", data);

      // Comienza a construir la tabla
      let html = `<br><table border="1">
        <thead>
          <tr>
            <th>ProductoId</th>
            <th>Nombre</th>
            <th>Precio</th>
          </tr>
        </thead>
        <tbody>`;

      // Agrega cada cliente como fila
      data.forEach(producto => {
        html += `<tr>
          <td>${producto.productoID}</td>
          <td>${producto.nombre}</td>
          <td>${producto.precio}</td>
        </tr>`;
      });

      html += `</tbody></table>`;

      contenido.innerHTML = html;
    })
    .catch(error => {
      console.error("Error al cargar productos:", error);
      contenido.innerHTML = `<p style="color:red;">Error al cargar productos.</p>`;
    });
};

const mostrarPedidos = () => {
  console.log("mostrando Pedidos!");

  const contenido = document.getElementById("contenido");
  contenido.innerHTML = "";
  fetch("http://localhost:5294/api/pedidos", {
    method: "GET"
  })
    .then(res => {
      if (!res.ok) {
        throw new Error("Error al obtener pedidos");
      }
      return res.json();
    })
    .then(data => {
      console.log("data: ", data);

      // Comienza a construir la tabla
      let html = `<br><table border="1">
        <thead>
          <tr>
            <th>PedidoID</th>
            <th>Nombre Cliente</th>
            <th>Nombre Producto</th>
            <th>Cantidad</th>
            <th>Fecha</th>
          </tr>
        </thead>
        <tbody>`;

      // Agrega cada cliente como fila
      data.forEach(pedido => {
        html += `<tr>
          <td>${pedido.pedidosID}</td>
          <td>${pedido.cliente.nombre}</td>
          <td>${pedido.producto.nombre}</td>
          <td>${pedido.cantidad}</td>
          <td>${pedido.fecha}</td>
        </tr>`;
      });

      html += `</tbody></table>`;
      html += `<br><button onclick='crearPedido()'>Crear pedido</button>`

      contenido.innerHTML = html;
    })
    .catch(error => {
      console.error("Error al cargar pedidos:", error);
      contenido.innerHTML = `<p style="color:red;">Error al cargar pedidos.</p>`;
    });
};

const crearPedido = ()=>{
  console.log("creando pedido")
  const contenido = document.getElementById("contenido");
  contenido.innerHTML = "";

    // Comienza a construir la tabla
      let formulario = `
      <br>
        <form id="formPedido">
        <label for="clienteId">Cliente ID:</label><br>
        <input type="number" id="clienteId" name="clienteId" required><br><br>

        <label for="productoId">Producto ID:</label><br>
        <input type="number" id="productoId" name="productoId" required><br><br>

        <label for="cantidad">Cantidad:</label><br>
        <input type="number" id="cantidad" name="cantidad" required min="1"><br><br>

        <label for="fecha">Fecha:</label><br>
        <input type="datetime-local" id="fecha" name="fecha" required><br><br>

        <button type="submit">Guardar Pedido</button>
        </form>
      
      `;

      contenido.innerHTML = formulario

      document.getElementById("formPedido").addEventListener("submit", function(event) {
      event.preventDefault();

      const pedido = {
        clienteID: parseInt(document.getElementById("clienteId").value),
        productoID: parseInt(document.getElementById("productoId").value),
        cantidad: parseInt(document.getElementById("cantidad").value),
        fecha: new Date(document.getElementById("fecha").value).toISOString()
      };

      fetch("http://localhost:5294/api/pedidos", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(pedido)
      })
      .then(res => {
        if (!res.ok) {
          throw new Error("Error al guardar el pedido");
        }
        return res;
      })
      .then(data => {
        alert("Pedido creado correctamente");
        document.getElementById("formPedido").reset();
        mostrarPedidos();
      })
      .catch(error => {
        console.error("Error:", error);
        alert("Error al crear el pedido");
      });
    });

}
