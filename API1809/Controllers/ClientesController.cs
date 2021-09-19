using API1809.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1809.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController:ControllerBase
    {
        private readonly ApplicationDBContext context;

        public ClientesController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet("cliented")]
        [Route("getAllClients")]
        public async Task<ActionResult<List<Cliente>>> GetAll()
        {
            return await context.Cliente.ToListAsync();
        }

        [HttpGet("{id:int}")]
        [Route("getClient/{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            return await context.Cliente.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        [Route("saveClient")]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            await context.Cliente.AddAsync(cliente);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("updateClient/{id:int}")]
        public async Task<ActionResult> Put(int id, Cliente cliente)
        {
            var existe = await context.Cliente.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound("El cliente no existe");
            if (id != cliente.Id)
                return BadRequest("Los id no coinciden");

            context.Cliente.Update(cliente);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [Route("deleteClient/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Cliente.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound("El cliente no existe");
            context.Cliente.Remove(new Cliente { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
