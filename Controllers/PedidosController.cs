using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PedidosController : ControllerBase
{
  private readonly AppContext _db;

  public PedidosController(AppContext db)
  {
    _db = db;
  }


  [HttpGet()]
  public async Task<IActionResult> GetAll()
  {
    var pedidos = await _db.pedidos.Include(p => p.Cliente).Include(p => p.Producto).ToListAsync();
    return Ok(pedidos);
  }

  [HttpPost()]
  public async Task<IActionResult> Create([FromBody] PedidosDTO pedidos)
  {
    if (!ModelState.IsValid)
      return BadRequest("Datos Invalidos!");

    var newPedido = new Pedidos
    {
      ProductoID = pedidos.ProductoID,
      ClienteID = pedidos.ClienteID,
      Cantidad = pedidos.Cantidad,
      Fecha = pedidos.Fecha
    };

    await _db.pedidos.AddAsync(newPedido);
    await _db.SaveChangesAsync();
    return Ok("Pedido creado correctamente!");
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete([FromRoute] int id)
  {
    var pedido = await _db.pedidos.FindAsync(id);

    if(pedido == null)
      return BadRequest("El pedido no existe!");

    _db.pedidos.Remove(pedido);
    await _db.SaveChangesAsync();
    return Ok("Pedido eliminado correctamente!");
  }
}
