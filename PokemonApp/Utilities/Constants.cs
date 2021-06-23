using System;

namespace PokemonApp.Utilities
{
    public class Constants
    {
        public static string DB_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static string DB_FILENAME = "PokemonDB.sqlite";
        public const string baseUrl = "http://pokeapi.co/api/v2/";
        public const string pokemonResourceUrl = "pokemon/{0}";

        public const string pokemonId = "pokemonId";
        public const string pokemonName = "pokemonName";
        public const string pokemonWeight = "pokemonWeight";
        public const string pokemonHeight = "pokemonHeight";
        public const string pokemonType = "pokemonType";
        public const string pokemonIcon = "pokemonIcon";
    }
}