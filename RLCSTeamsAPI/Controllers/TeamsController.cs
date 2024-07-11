using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RLCSTeamsAPI.Models;

namespace RLCSTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly RlcsContext _context;
        public TeamsController(RlcsContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTeams()
        {
            var teams = await _context.Teams
                .Include(team => team.Coach)
                .Include(team => team.Players)
                    .ThenInclude(player => player.CarPreset)
                .ToArrayAsync();

            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTeam(int id)
        {
            var team = await _context.Teams
                .Include(team => team.Coach)
                .Include(team => team.Players)
                    .ThenInclude(player => player.CarPreset)
                .FirstOrDefaultAsync(player => player.Id == id);

            if (team == null) return NotFound();
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<TeamDTO>> PostTeam(TeamDTO teamDTO)
        {
            var team = new Team()
            {
                Id = teamDTO.Id,
                Name = teamDTO.Name,
                Region = teamDTO.Region
            };
            
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTeam),
                new { id = team.Id },
                await _context.Teams
                    .Include(team => team.Coach)
                    .Include(team => team.Players)
                    .SingleOrDefaultAsync()
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditTeam(int id, TeamDTO teamDTO)
        {
            if (id != teamDTO.Id) return BadRequest();

            var team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();

            team.Id = teamDTO.Id;
            team.Name = teamDTO.Name;
            team.Region = teamDTO.Region;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TeamExists(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return team;
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> DeleteMultipleTeams([FromQuery] int[] ids)
        {
            var teams = new List<Team>();
            foreach (int id in ids)
            {
                var team = await _context.Teams.FindAsync(id);
                if (team == null) return NotFound();
                teams.Add(team);
            }

            _context.Teams.RemoveRange(teams);
            await _context.SaveChangesAsync();
            return Ok(teams);
        }

        private bool TeamExists(int id) => _context.Teams.Any(team => team.Id == id);
    }
}
