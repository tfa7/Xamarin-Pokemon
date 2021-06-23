using PokemonApp.Utilities;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PokemonApp.Model.Database
{
    public class PokemonQueries
    {
        private SQLiteAsyncConnection _sqliteConnection;

        public PokemonQueries()
        {
            var dbPath = Path.Combine(Constants.DB_DIRECTORY, Constants.DB_FILENAME);

            _sqliteConnection = new SQLiteAsyncConnection(dbPath);
            _sqliteConnection.CreateTableAsync<PokemonTable>();
        }

        public async Task<List<PokemonTable>> GetPokemons()
        {
            return await _sqliteConnection.Table<PokemonTable>().ToListAsync();
        }

        // For testing
        //public async Task<List<PokemonTable>> GetPokemons()
        //{
        //    var tempPokemons = new List<PokemonTable>();
        //    tempPokemons.Add(new PokemonTable() { Id = 1, PokemonName = "bulbasaur", ImagePath = "pokemon_bulbasaur" });
        //    tempPokemons.Add(new PokemonTable() { Id = 2, PokemonName = "ivysaur", ImagePath = "pokemon_ivysaur" });
        //    tempPokemons.Add(new PokemonTable() { Id = 3, PokemonName = "venusaur", ImagePath = "pokemon_venusaur" });
        //    tempPokemons.Add(new PokemonTable() { Id = 4, PokemonName = "charmander", ImagePath = "pokemon_charmander" });

        //    return tempPokemons;
        //}

        public async Task<string> GetPokemonEvolution(string pokemonName)
        {
            return await _sqliteConnection.ExecuteScalarAsync<string>($"SELECT ImagePath FROM PokemonTable WHERE PokemonName = '{pokemonName.ToLower()}'");
        }
    }
}