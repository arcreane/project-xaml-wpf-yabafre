using MauiHangmanGames.Data;
using MauiHangmanGames.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiHangmanGames.Services
{
    public class LeaderboardService
    {
        private readonly HangmanDbContext _context;

        public LeaderboardService(HangmanDbContext context)
        {
            _context = context;
        }

        public async Task<List<LeaderboardEntry>> GetTopScores()
        {
            return await _context.LeaderboardEntries
                                 .Include(le => le.Player)
                                 .OrderByDescending(le => le.Score)
                                 .Take(10)
                                 .ToListAsync();
        }
    }
}
