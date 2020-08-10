using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coba.model;

namespace Coba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KelasItemsController : ControllerBase
    {
        private readonly KelasContext _context;

        public KelasItemsController(KelasContext context)
        {
            _context = context;
        }

        // GET: api/KelasItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KelasItem>>> GetKelasItems()
        {
            return await _context.KelasItems.ToListAsync();
        }

        // GET: api/KelasItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KelasItem>> GetKelasItem(long id)
        {
            var kelasItem = await _context.KelasItems.FindAsync(id);

            if (kelasItem == null)
            {
                return NotFound();
            }

            return kelasItem;
        }

        // PUT: api/KelasItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKelasItem(long id, KelasItem kelasItem)
        {
            if (id != kelasItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(kelasItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KelasItemExists(id))
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

        // POST: api/KelasItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<KelasItem>> PostKelasItem(KelasItem kelasItem)
        {
            _context.KelasItems.Add(kelasItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction( nameof(GetKelasItem), new { id = kelasItem.Id }, kelasItem);
        }

        // DELETE: api/KelasItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KelasItem>> DeleteKelasItem(long id)
        {
            var kelasItem = await _context.KelasItems.FindAsync(id);
            if (kelasItem == null)
            {
                return NotFound();
            }

            _context.KelasItems.Remove(kelasItem);
            await _context.SaveChangesAsync();

            return kelasItem;
        }

        private bool KelasItemExists(long id)
        {
            return _context.KelasItems.Any(e => e.Id == id);
        }
    }
}
