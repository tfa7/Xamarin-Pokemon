using System.Collections.Generic;

namespace PokemonApp.Model.Entity
{
    public class PokemonApi
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }

        public IList<Pokemon> Results { get; set; }
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public PokemonDetail Details { get; set; }
    }

    public class PokemonDetail
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public IList<PokemonType> Types { get; set; }
        public PokemonSprite Sprites { get; set; }
        public string Image_Resource { get; set; }
    }

    public class PokemonSprite
    {
        public string Front_Default { get; set; }
    }

    public class PokemonType
    {
        public int Slot { get; set; }
        public TypeDetail Type { get; set; }
    }

    public class TypeDetail
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}