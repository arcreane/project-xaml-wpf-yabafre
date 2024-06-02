using MauiHangmanGames.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MauiHangmanGames.Data;

namespace MauiHangmanGames.Services
{
    public class GameService
    {
        private readonly HangmanDbContext _dbContext;

        public GameService(HangmanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Player> AuthenticateOrCreatePlayerAsync(string playerName)
        {
            var player = await _dbContext.Players
                .FirstOrDefaultAsync(p => p.Name == playerName);

            if (player == null)
            {
                player = new Player { Name = playerName };
                _dbContext.Players.Add(player);
                await _dbContext.SaveChangesAsync();
            }

            return player;
        }

        public async Task<List<LeaderboardEntry>> GetLeaderboardAsync()
        {
            return await _dbContext.LeaderboardEntries
                .Include(le => le.Player)
                .ToListAsync();
        }
    }
}
