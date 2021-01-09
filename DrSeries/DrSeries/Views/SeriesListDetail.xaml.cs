using System;
using DrSeries.Model;
using DrSeries.ViewModel;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrSeries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeriesListDetail : ContentPage
    {
        private readonly SeriesList _seriesListCollection;
        private readonly SeriesListDetailViewModel _viewModel;

        public SeriesListDetail(SeriesList seriesList)
        {
            InitializeComponent();
            _seriesListCollection = new SeriesList();
            _seriesListCollection = seriesList;
            BindingContext = _viewModel = new SeriesListDetailViewModel();
            _viewModel.IsVisiblee = false;
            NavigationPage.SetHasNavigationBar(this, false);
            _viewModel.Title = _seriesListCollection.Name;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadSeriesListDetail(_seriesListCollection);
        }

        #region Buttons

        private void SetListView_OnClicked(object sender, EventArgs e)
        {
            ListOfSeries.IsVisible = true;
            ListOfSeriesPostersView.IsVisible = false;
        }

        private void SetPosterView_OnClicked(object sender, EventArgs e)
        {
            ListOfSeries.IsVisible = false;
            ListOfSeriesPostersView.IsVisible = true;
        }

        private void EditBtn_OnClicked(object sender, EventArgs e)
        {
            addSeries.IsVisible = true;
        }

        private async void DltBtn_OnClicked(object sender, EventArgs e)
        {
            var items = ListOfSeries.SelectedItems;
            if (items != null)
                foreach (var series in items)
                    _seriesListCollection.SelectedSeriesList.Remove(series as Series);

            await _viewModel.UpdateSeriesList(_seriesListCollection);
            _viewModel.LoadSeriesListDetail(_seriesListCollection);
        }

        private async void DeleteSeriesList_OnClicked(object sender, EventArgs e)
        {
            _viewModel.MySelectedSeriesListCollection.Remove(_seriesListCollection);
            await _viewModel.RemoveMySeriesListFromDatabase(_seriesListCollection.Oid);
            await _viewModel.LoadMySelectedSeriesList();
            await Navigation.PopAsync(false);
        }

        private async void AddSeries_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SeriesListToAddToListPage(_seriesListCollection), false);
            addSeries.IsVisible = false;
        }

        private async void ArrowLeft_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }

        private async void ListOfSeries_OnItemHolding(object sender, ItemHoldingEventArgs e)
        {
            var item = e.ItemData as Series;
            await Navigation.PushAsync(new SeriesDetailPage(item));
        }
    }

    #endregion
}