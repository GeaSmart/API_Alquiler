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
    public class AlquileresController:ControllerBase
    {
        private readonly ApplicationDBContext context;

        public AlquileresController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<Alquiler>>> GetAll()
        {
            return await context.Alquiler.Include(x=>x.cliente).ToListAsync();
        }

        [HttpGet("{id:int}")]
        [Route("get/{id}")]
        public async Task<ActionResult<Alquiler>> Get(int id)
        {
            return await context.Alquiler.Include(x => x.cliente).FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        [Route("addAlquiler")]
        public async Task<ActionResult> Post(Alquiler alquiler)
        {
            context.Alquiler.Add(alquiler);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        [Route("updateAlquiler/{id}")]
        public async Task<ActionResult> Put(int id, Alquiler alquiler)
        {
            var existe = await context.Alquiler.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound("El alquiler no existe");

            if (id != alquiler.Id)
                return BadRequest("Los id no coinciden");

            context.Alquiler.Update(alquiler);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [Route("deleteAlquiler/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            context.Alquiler.Remove(new Alquiler { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
