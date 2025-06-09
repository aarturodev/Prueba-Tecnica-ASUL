using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProductosController : ControllerBase
{
  private readonly AppContext _db;

  public ProductosController(AppContext db)
  {
    _db = db;
  }


  [HttpGet()]
  public async Task<IActionResult> GetAll()
  {
    var productos = await _db.productos.ToListAsync();
    return Ok(productos);
  }

  [HttpPost()]
  public async Task<IActionResult> Create([FromBody] ProductoDTO producto)
  {
    if (!ModelState.IsValid)
      return BadRequest("Datos Invalidos!");

    var newProduct = new Productos
    {
      Nombre = producto.Nombre,
      Precio = producto.Precio
    };

    await _db.productos.AddAsync(newProduct);
    await _db.SaveChangesAsync();
    return Ok("Producto creado correctamente!");
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete([FromRoute] int id)
  {
    var producto = await _db.productos.FindAsync(id);
    if (producto == null)
      return BadRequest("El producto no existe");

   _db.productos.Remove(producto);
    await _db.SaveChangesAsync();
    return Ok("Producto eliminado Correctamente!");
  }
}
