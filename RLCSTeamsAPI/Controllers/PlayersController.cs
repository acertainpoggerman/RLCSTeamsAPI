using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RLCSTeamsAPI.Models;
using System.Xml.Linq;

namespace RLCSTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly RlcsContext _context;

        public PlayersController(RlcsContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPlayers()
        {
            var players = await _context.Players
                .Include(plyr => plyr.Team)
                .Include(plyr => plyr.CarPreset)
                .ToArrayAsync();

            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPlayer(int id)
        {
            var player = await _context.Players
                .Include(plyr => plyr.Team)
                .Include(plyr => plyr.CarPreset)
                .FirstOrDefaultAsync(plyr => plyr.Id == id);

            if (player == null) return NotFound();
            return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult<PlayerDTO>> PostPlayer(PlayerDTO playerDTO)
        {
            var team = await _context.Teams.SingleAsync(team => team.Name == playerDTO.TeamName);
            var player = new Player()
            {
                Id = playerDTO.Id,
                Name = playerDTO.Name,
                GamerTag = playerDTO.GamerTag,
                Nationality = playerDTO.Nationality,
                DateOfBirth = playerDTO.DateOfBirth,
                TeamId = team.Id,
                CarPresetId = playerDTO.CarPresetId
            };

            _context.Players.Add(player);
            await _context.SaveChangesAsync();



            return CreatedAtAction(
                nameof(GetPlayer),
                new { id = player.Id },
                await _context.Players
                    .Include(plyr => plyr.CarPreset)
                    .SingleOrDefaultAsync(plyr => plyr.Id == player.Id)
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditPlayer(int id, PlayerDTO playerDTO)
        {
            if (id != playerDTO.Id) return BadRequest();

            var player = await _context.Players.FindAsync(id);
            var team = await _context.Teams.SingleAsync(team => team.Name == playerDTO.TeamName);

            if (player == null) return NotFound();

            player.Id = playerDTO.Id;
            player.Name = playerDTO.Name;
            player.GamerTag = playerDTO.GamerTag;
            player.Nationality = playerDTO.Nationality;
            player.DateOfBirth = playerDTO.DateOfBirth;
            player.TeamId = team.Id;
            player.CarPresetId = playerDTO.CarPresetId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!PlayerExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Player>> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return NotFound();

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return player;
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> DeleteMultiplePlayers([FromQuery] int[] ids)
        {
            var players = new List<Player>();
            foreach (int id in ids)
            {
                var player = await _context.Players.FindAsync(id);
                if (player == null) return NotFound();
                players.Add(player);
            }

            _context.Players.RemoveRange(players);
            await _context.SaveChangesAsync();
            return Ok(players);
        }

        private bool PlayerExists(int id) => _context.Players.Any(player => player.Id == id);

        private static PlayerDTO ItemToDTO(Player player) =>
            new()
            {
                Id = player.Id,
                Name = player.Name,
                GamerTag = player.GamerTag,
                Nationality = player.Nationality,
                DateOfBirth = player.DateOfBirth,
                TeamName = player.Team != null ? player.Team.Name : "None",
                CarPresetId = player.CarPresetId
            };
    }
}
