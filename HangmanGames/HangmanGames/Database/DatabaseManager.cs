using Npgsql;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using HangmanGames.Models;

namespace HangmanGames.Database
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Joueur>> GetAllJoueursAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryAsync<Joueur>("SELECT * FROM joueurs");
        }

        // Plus de méthodes pour gérer la base de données
    }
}
