using System;
using DrSeries.Model;
using DrSeries.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrSeries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeriesListToAddToListPage : ContentPage
    {
        private readonly SeriesList _seriesList;
        private readonly CreateSeriesListViewModel _viewModel;

        public SeriesListToAddToListPage(SeriesList seriesListCollection)
        {
            InitializeComponent();
            BindingContext = _viewModel = new CreateSeriesListViewModel();
            _seriesList = seriesListCollection;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadSeriesWithFilter(_seriesList);
        }

        #region Buttons

        private async void AddToSeriesList_OnClicked(object sender, EventArgs e)
        {
            var items = ListOfSeries.SelectedItems;
            foreach (var series in items) _seriesList.SelectedSeriesList.Add(series as Series);
            await _viewModel.UpdateSeriesList(_seriesList);
            await Navigation.PopAsync(false);
        }

        #endregion
    }
}