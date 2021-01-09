using DM.MovieApi;
using DrSeries.Views;
using Syncfusion.Licensing;
using Xamarin.Forms;

namespace DrSeries
{
    public partial class App : Application
    {
        public static string seriesUrlPoster = "https://image.tmdb.org/t/p/w300";

        public App()
        {
            InitializeComponent();
            SyncfusionLicenseProvider.RegisterLicense(
                "MzQ0NTY0QDMxMzgyZTMzMmUzMFBhdG5iMWdYZi9ub0s2S1NDSjU2R0NPNldkbVRjTEZOb0hVZTB3OTREdGM9");
            MainPage = new NavigationPage(new MainMenu());
            MovieDbFactory.RegisterSettings("ecd8d0dee8be21728329d88a049cbb85", "https://api.themoviedb.org/3/");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}