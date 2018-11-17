using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nodo1.Models;

namespace Nodo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private readonly Nodo1Context _context;

        public BlockController(Nodo1Context context)
        {
            _context = context;
        }

        // GET: api/Block
        [HttpGet]
        public IEnumerable<Block> GetBlock()
        {
            return _context.Block;
        }

        // GET: api/Block/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlock([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var block = await _context.Block.FindAsync(id);

            if (block == null)
            {
                return NotFound();
            }

            return Ok(block);
        }

      

        // PUT: api/Block/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlock([FromRoute] int id, [FromBody] Block block)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != block.Id)
            {
                return BadRequest();
            }

            _context.Entry(block).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlockExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Block
        [HttpPost]
        public async Task<IActionResult> PostBlock([FromBody] Block block)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Block.Add(block);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlock", new { id = block.Id }, block);
        }

        // DELETE: api/Block/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlock([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var block = await _context.Block.FindAsync(id);
            if (block == null)
            {
                return NotFound();
            }

            _context.Block.Remove(block);
            await _context.SaveChangesAsync();

            return Ok(block);
        }

        private bool BlockExists(int id)
        {
            return _context.Block.Any(e => e.Id == id);
        }
    }
}