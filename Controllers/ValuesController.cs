using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneCompanion.API.Data;
using CapstoneCompanion.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapstoneCompanion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var projects = await _context.Projects.ToListAsync();

            return Ok(projects);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetValue), new { id = project.Id }, project);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(long id, Project project)
            {
                if (id != project.Id)
                {
                    return BadRequest();
                }

                _context.Entry(project).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(long id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
