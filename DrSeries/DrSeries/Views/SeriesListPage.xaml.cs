using System;
using DrSeries.Model;
using DrSeries.ViewModel;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace DrSeries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeriesListPage : ContentPage
    {
        private readonly SeriesListViewModel _viewModel;
        private object SelectedItem;

        public SeriesListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SeriesListViewModel();
            SelectedItem = new object();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadMySelectedSeriesList();
        }

        #region Buttons

        private async void ListOfMySeriesList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            SelectedItem = e.ItemData as SeriesList;
            await Navigation.PushAsync(new SeriesListDetail(SelectedItem as SeriesList), false);
        }

        private async void ArrowLeft_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }

        #endregion

        private async void ListOfMySeriesList_OnItemHolding(object sender, ItemHoldingEventArgs e)
        {
            var item = e.ItemData as Series;
            await Navigation.PushAsync(new SeriesDetailPage(item));
        }
    }
}