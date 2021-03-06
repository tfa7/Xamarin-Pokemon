using PokemonApp.AndroidExtensions;
using PokemonApp.Presenter.Interface;
using PokemonApp.Views;
using System.Timers;

namespace PokemonApp.Presenter.Implementation
{
    public class HomePresenter : IHomePresenter
    {
        private IHomeView _homeView;
        private Timer _timer;
        private SQLiteHelper _sqLiteHelper;

        public HomePresenter(IHomeView homeView, SQLiteHelper sqliteHelper)
        {
            _homeView = homeView;
            _sqLiteHelper = sqliteHelper;
        }

        public void InitialiseDb()
        {
            _sqLiteHelper.CreateDatabase();
        }

        public void StartApplication()
        {
            _timer = new Timer();
            _timer.Interval = 1000; //splash screen
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            _homeView.NavigateToViewPokemonScreen();
        }
    }
}