using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RLCSTeamsAPI.Models;

namespace RLCSTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private readonly RlcsContext _context;
        public CoachesController(RlcsContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCoaches()
        {
            var coaches = await _context.Coaches
                .Include(coach => coach.Team)
                .ToArrayAsync();

            return Ok(coaches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCoach(int id)
        {
            var coach = await _context.Coaches
                .Include(c => c.Team)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (coach == null) return NotFound();
            return Ok(coach);
        }

        [HttpPost]
        public async Task<ActionResult<CoachDTO>> PostCoach(CoachDTO coachDTO)
        {
            var team = await _context.Teams.SingleAsync(team => team.Name == coachDTO.TeamName);
            var coach = new Coach()
            {
                Id = coachDTO.Id,
                Name = coachDTO.Name,
                GamerTag = coachDTO.GamerTag,
                Nationality = coachDTO.Nationality,
                DateOfBirth = coachDTO.DateOfBirth,
                TeamId = team.Id
            };

            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCoach),
                new { id = coach.Id },
                coach
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditCoach(int id, CoachDTO coachDTO)
        {
            if (id != coachDTO.Id) return BadRequest();

            var coach = await _context.Coaches.FindAsync(id);
            var team = await _context.Teams.SingleAsync(team => team.Name == coachDTO.TeamName);

            if (coach == null) return NotFound();

            coach.Id = coachDTO.Id;
            coach.Name = coachDTO.Name;
            coach.GamerTag = coachDTO.GamerTag;
            coach.Nationality = coachDTO.Nationality;
            coach.DateOfBirth = coachDTO.DateOfBirth;
            coach.TeamId = team.Id;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!CoachExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Coach>> DeleteCoach(int id)
        {
            var coach = await _context.Coaches.FindAsync(id);
            if (coach == null) return NotFound();

            _context.Coaches.Remove(coach);
            await _context.SaveChangesAsync();
            return coach;
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> DeleteMultipleCoaches([FromQuery] int[] ids)
        {
            var coaches = new List<Coach>();
            foreach (int id in ids)
            {
                var coach = await _context.Coaches.FindAsync(id);
                if (coach == null) return NotFound();
                coaches.Add(coach);
            }

            _context.Coaches.RemoveRange(coaches);
            await _context.SaveChangesAsync();
            return Ok(coaches);
        }

        private bool CoachExists(int id) => _context.Coaches.Any(coach => coach.Id == id);

        private static CoachDTO ItemToDTO(Coach coach) =>
            new()
            {
                Id = coach.Id,
                Name = coach.Name,
                GamerTag = coach.GamerTag,
                Nationality = coach.Nationality,
                DateOfBirth = coach.DateOfBirth,
                TeamName = coach.Team != null ? coach.Team.Name : "None"
            };

    }
}
