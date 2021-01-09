using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrSeries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        #region Buttons

        private async void AddSeries_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewSeriesPage(), false);
        }

        private async void CreateSeriesList_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateSeriesList(), false);
        }

        private async void ListReview_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SeriesListPage(), false);
        }

        #endregion
    }
}