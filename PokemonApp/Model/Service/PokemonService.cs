using Newtonsoft.Json;
using PokemonApp.Model.Database;
using PokemonApp.Model.Entity;
using PokemonApp.Utilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonApp.Model.Service
{
    public class PokemonService
    {
        private PokemonQueries _pokemonQueries;

        public PokemonService()
        {
            _pokemonQueries = new PokemonQueries();
        }

        public async Task<List<Pokemon>> GetPokemons()
        {
            //var pokemonModelList = new List<Pokemon>();

            // LocalMachine is the local SQLite database in your application
            // var cachedPokemons = BlobCache.LocalMachine.GetAndFetchLatest(
            //    "Pokemons",
            //    () => GetPokemonsFromService(),
            //    offset =>
            //    {
            //        TimeSpan elapsed = DateTimeOffset.Now - offset;
            //        return elapsed > new TimeSpan(hours: 24, minutes: 0, seconds: 0);
            //});

            //cachedPokemons.Subscribe(x => {
            //    pokemonModelList = x;
            //});

            var pokemonModelList = await GetPokemonsFromService();

            return pokemonModelList;
        }

        private async Task<List<Pokemon>> GetPokemonsFromService()
        {
            var pokemonModelList = new List<Pokemon>();
            PokemonDetail pokemonModel = null;

            var pokemonList = await GetPokemonSummaryInfo(); //await _pokemonQueries.GetPokemons();

            foreach (var pokemon in pokemonList)
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(Constants.baseUrl + string.Format(Constants.pokemonResourceUrl, pokemon.Name));

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        pokemonModel = JsonConvert.DeserializeObject<PokemonDetail>(content);
                        pokemon.Details = pokemonModel;

                        // for the moment images are presaved in Resources/drawable folder
                        pokemonModel.Image_Resource = "pokemon_" + pokemon.Name;
                    }
                }
            }

            return pokemonList;
        }

        private async Task<List<Pokemon>> GetPokemonSummaryInfo(int pageNo = 0)
        {
            var pokemonModelList = new List<Pokemon>();

            using (var client = new HttpClient())
            {
                var url = Constants.baseUrl + string.Format(Constants.pokemonResourceUrl, "?limit=20&offset=" + pageNo);
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var item = JsonConvert.DeserializeObject<PokemonApi>(content);
                    pokemonModelList = item.Results as List<Pokemon>;
                }
            }

            return pokemonModelList;
        }

    }
}