using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using PokemonApp.Model.Entity;
using System.Collections.Generic;
using System.Net;

namespace PokemonApp.AndroidExtensions
{
    public class CustomImageAdapter : ArrayAdapter<Pokemon>, IFilterable
    {
        private Activity _activity;
        public IList<Pokemon> _pokemonItems;
        public IList<Pokemon> _pokemons;
        private int _resourceLayoutId;

        public CustomImageAdapter(Activity activity, int resourceLayoutId, IList<Pokemon> pokemons)
            : base(activity, resourceLayoutId, pokemons)
        {
            _activity = activity;
            _resourceLayoutId = resourceLayoutId;
            _pokemons = pokemons;

            Filter = new SearchFilter(this);
        }

        public override Filter Filter { get; }

        public override int Count
        {
            get
            {
                return _pokemons.Count;
            }
        }

        public Pokemon GetItemAtPosition(int position)
        {
            return _pokemons[position];
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _activity.LayoutInflater.Inflate(_resourceLayoutId, parent, false);

            var pokemonImageIcon = view.FindViewById<ImageView>(Resource.Id.pokemonIcon);
            var pokemonText = view.FindViewById<TextView>(Resource.Id.pokemonName);

            pokemonText.Text = _pokemons[position].Name;

            var resourceId = (int)typeof(Resource.Drawable).GetField(_pokemons[position].Details.Image_Resource).GetValue(null);
            pokemonImageIcon.SetImageBitmap(BitmapFactory.DecodeResource(_activity.Resources, resourceId));

            return view;
        }

        // This will load the image from a Url
        //public override View GetView2(int position, View convertView, ViewGroup parent)
        //{
        //    var view = convertView ?? _activity.LayoutInflater.Inflate(_resourceLayoutId, parent, false);

        //    var pokemonImageIcon = view.FindViewById<ImageView>(Resource.Id.pokemonIcon);
        //    var pokemonText = view.FindViewById<TextView>(Resource.Id.pokemonName);

        //    pokemonText.Text = _pokemons[position].name;

        //    var imgPath = _pokemons[position].Details.sprites.front_default;
        //    var bitmap = GetImageBitmapFromUrl(imgPath);
        //    pokemonImageIcon.SetImageBitmap(bitmap);

        //    return view;
        //}

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}