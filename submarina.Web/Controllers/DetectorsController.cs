using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using submarina.Data;
using submarina.Entities;

namespace submarina.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetectorsController : ControllerBase
    {
        private readonly DbContextSystem _context;

        public DetectorsController(DbContextSystem context)
        {
            _context = context;
        }

        // GET: api/Detectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detector>>> GetDetectors()
        {
            return await _context.Detectores.ToListAsync();
        }

        // GET: api/Detectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detector>> GetDetector(int id)
        {
            var detector = await _context.Detectores.FindAsync(id);

            if (detector == null)
            {
                return NotFound();
            }

            return detector;
        }

        // PUT: api/Detectors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetector(int id, Detector detector)
        {
            if (id != detector.iddetector)
            {
                return BadRequest();
            }

            _context.Entry(detector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetectorExists(id))
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

        // POST: api/Detectors
        [HttpPost]
        public async Task<ActionResult<Detector>> PostDetector(Detector detector)
        {
            _context.Detectores.Add(detector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetector", new { id = detector.iddetector }, detector);
        }

        // DELETE: api/Detectors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Detector>> DeleteDetector(int id)
        {
            var detector = await _context.Detectores.FindAsync(id);
            if (detector == null)
            {
                return NotFound();
            }

            _context.Detectores.Remove(detector);
            await _context.SaveChangesAsync();

            return detector;
        }

        private bool DetectorExists(int id)
        {
            return _context.Detectores.Any(e => e.iddetector == id);
        }
    }
}
