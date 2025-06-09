using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppContext _db;

    public ClientesController(AppContext db)
    {
        _db = db;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var clientes = await _db.clientes.ToListAsync();
        return Ok(clientes);
    }

    [HttpPost()]
    public async Task<IActionResult> Create([FromBody] ClienteDTO cliete)
    {
        if (!ModelState.IsValid)
            return BadRequest("Datos Invalidos!");

        var newClient = new Clientes
        {
            Nombre = cliete.Nombre,
            Ciudad = cliete.Ciudad,
            CorreoElectronico = cliete.CorreoElectronico
        };

        await _db.clientes.AddAsync(newClient);
        await _db.SaveChangesAsync();
        return Ok("Cliente creado correctamente!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var cliente = await _db.clientes.FindAsync(id);

        if (cliente == null)
            return BadRequest("El cliente no existe");

        _db.clientes.Remove(cliente);
        await _db.SaveChangesAsync();
        return Ok("Cliente eliminado correctamente!");
    }
}
