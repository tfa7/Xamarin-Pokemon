using PokemonApp.Model.Entity;
using PokemonApp.Model.Service;
using PokemonApp.Presenter.Interface;
using PokemonApp.Utilities;
using PokemonApp.Views;
using System.Collections.Generic;
using System.Linq;

namespace PokemonApp.Presenter.Implementation
{
    public class DisplayPokemonPresenter : IDisplayPokemonPresenter
    {
        private IDisplayPokemonView _displayPokemonView;
        private PokemonService _pokemonService;
        private List<Pokemon> _pokemons;

        public DisplayPokemonPresenter(IDisplayPokemonView displayPokemonView)
        {
            _displayPokemonView = displayPokemonView;
            _pokemonService = new PokemonService();
        }

        public async void FillGridWithPokemon()
        {
            _displayPokemonView.SetProgressDialogMessage();
            _pokemons = await _pokemonService.GetPokemons();
            _displayPokemonView.HideProgressDialogMessage();
            _displayPokemonView.SetImageAdapter();
        }

        public List<Pokemon> GetPokemons()
        {
            return _pokemons;
        }

        public void SetPokemonDetails(Pokemon selectedPokemon)
        {
            _displayPokemonView.SetIntent();
            _displayPokemonView.SetIntentValue(Constants.pokemonName, selectedPokemon.Details.Name);
            _displayPokemonView.SetIntentValue(Constants.pokemonId, selectedPokemon.Details.Id);
            _displayPokemonView.SetIntentValue(Constants.pokemonWeight, selectedPokemon.Details.Weight);
            _displayPokemonView.SetIntentValue(Constants.pokemonHeight, selectedPokemon.Details.Height);
            _displayPokemonView.SetIntentValue(Constants.pokemonType, selectedPokemon.Details.Types.Select(x => x.Type.Name).ToList());
            _displayPokemonView.SetIntentValue(Constants.pokemonIcon, "pokemon_" + selectedPokemon.Details.Name);
            _displayPokemonView.NavigateToPokemonDetailsScreen();
        }
    }
}