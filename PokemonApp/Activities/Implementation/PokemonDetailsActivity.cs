using Android.App;
using Android.OS;
using Android.Widget;
using PokemonApp.Presenter.Implementation;
using PokemonApp.Presenter.Interface;
using PokemonApp.Utilities;
using PokemonApp.Views;
using System.Linq;
using AndroidX.Preference;

namespace PokemonApp.Activities
{
    [Activity(Label = "Pokemon Details")]
    public class PokemonDetailsActivity : Activity, IPokemonDetailsView
    {
        #region UI Control properties

        private TextView PokemonItemName { get; set; }
        private TextView PokemonId { get; set; }
        private TextView PokemonHeight { get; set; }
        private TextView PokemonWeight { get; set; }
        private TextView PokemonType { get; set; }
        private ImageView PokemonItemImage { get; set; }
        private CheckBox PokemonItemFavourite { get; set; }

        #endregion

        private IPokemonDetailsPresenter _pokemonDetailsPresenter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PokemonDetailsLayout);
            InitialiseControls();

            _pokemonDetailsPresenter = new PokemonDetailsPresenter(this);
            _pokemonDetailsPresenter.ClickPokemon();
        }

        #region Override methods from IPokemonDetailsView

        public void SetPokemonMainDetails()
        {
            var name = GetPokemonStringValue(Constants.pokemonName);
            PokemonItemName.Text = name.First().ToString().ToUpper() + name.Substring(1);
            PokemonId.Text = GetPokemonIntValue(Constants.pokemonId).ToString();
            PokemonHeight.Text = $"{Intent.GetStringExtra(Constants.pokemonHeight)} m";
            PokemonWeight.Text = $"{Intent.GetStringExtra(Constants.pokemonWeight)} kg";
            PokemonType.Text = Intent.GetStringArrayListExtra(Constants.pokemonType).JoinList().ToLower().ToTitleCase();
            PokemonItemImage.SetImageResource(GetPokemonImageResource(Constants.pokemonIcon));

            var preferences = PreferenceManager.GetDefaultSharedPreferences(this);
            PokemonItemFavourite.Checked = preferences.GetBoolean(PokemonId.Text, false);
        }

        public int GetPokemonImageResource(string intentKey)
        {
            var intentValue = Intent.GetStringExtra(intentKey);
            return (int)typeof(Resource.Drawable).GetField(intentValue).GetValue(null);
        }
        public string GetPokemonStringValue(string constant)
        {
            return Intent.GetStringExtra(constant);
        }
        public int GetPokemonIntValue(string constant)
        {
            return Intent.GetIntExtra(constant, 0);
        }

        #endregion

        private void InitialiseControls()
        {
            PokemonItemName = FindViewById<TextView>(Resource.Id.pokemon_item_name);
            PokemonId = FindViewById<TextView>(Resource.Id.pokemon_id);
            PokemonHeight = FindViewById<TextView>(Resource.Id.pokemon_height);
            PokemonWeight = FindViewById<TextView>(Resource.Id.pokemon_weight);
            PokemonType = FindViewById<TextView>(Resource.Id.pokemon_type);
            PokemonItemImage = FindViewById<ImageView>(Resource.Id.pokemon_item_image);

            PokemonItemFavourite = FindViewById<CheckBox>(Resource.Id.pokemon_favourite);
            PokemonItemFavourite.Click += (o, e) => {
                var preferences = PreferenceManager.GetDefaultSharedPreferences(this);
                var editor = preferences.Edit();

                if (PokemonItemFavourite.Checked)
                {
                    editor.PutBoolean(PokemonId.Text, true);
                    Toast.MakeText(this, "Saved as favourite", ToastLength.Short).Show();
                }
                else
                {
                    editor.Remove(PokemonId.Text);
                    Toast.MakeText(this, "Removed as favourite", ToastLength.Short).Show();
                }

                editor.Apply();
            };
        }
    }
}