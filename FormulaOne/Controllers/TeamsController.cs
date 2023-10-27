using FormulaOne.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using FormulaOne.Data;
namespace FormulaOne.Controllers
{
    [ApiController]
    [Route(template:"api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private AppDbContext _context;
        public TeamsController(AppDbContext context)
        {
            _context = context;            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            var teams = await _context.Teams.ToListAsync();
            return Ok(teams);
        }

        [HttpGet(template:"{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null)
            {
                return (BadRequest(error: "Invalid Id"));
            }
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Models.Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", team.Id, value: team);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, string country) 
        {
            var team =  await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null)
            {
                return BadRequest();
            }
            team.Country = country;
            await _context.SaveChangesAsync();
            return NoContent();
        } 

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x =>x.Id == id);
            if (team == null)
            {
                return BadRequest(error: "Invalid Id");
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        

    }
}
