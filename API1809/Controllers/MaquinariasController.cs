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
    public class MaquinariasController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public MaquinariasController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<Maquinaria>>> GetAll()
        {
            return await context.Maquinaria.ToListAsync();
        }

        [HttpGet("{id:int}")]
        [Route("get/{id:int}")]
        public async Task<ActionResult<Maquinaria>> Get(int id)
        {
            return await context.Maquinaria.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        [Route("saveMachinery")]
        public async Task<ActionResult> Post(Maquinaria maquinaria)
        {
            await context.Maquinaria.AddAsync(maquinaria);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        [Route("updateMachinery/{id:int}")]
        public async Task<ActionResult> Put(int id, Maquinaria maquinaria)
        {
            var existe = await context.Maquinaria.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound("La maquinaria no existe");
            if (id != maquinaria.Id)
                return BadRequest("Los id no coinciden");
            context.Update(maquinaria);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        [Route("deleteMachinery/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            context.Maquinaria.Remove(new Maquinaria { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
