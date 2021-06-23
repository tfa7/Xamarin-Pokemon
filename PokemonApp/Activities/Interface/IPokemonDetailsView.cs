namespace PokemonApp.Views
{
    public interface IPokemonDetailsView
    {
        void SetPokemonMainDetails();
        string GetPokemonStringValue(string constant);
        int GetPokemonImageResource(string key);
    }
}