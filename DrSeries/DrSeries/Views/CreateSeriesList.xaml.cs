using System;
using DrSeries.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrSeries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateSeriesList : ContentPage
    {
        private readonly CreateSeriesListViewModel _viewModel;

        public CreateSeriesList()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _viewModel = new CreateSeriesListViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadSeries();
        }

        #region Buttons

        private async void CreateMySeriesList_OnClicked(object sender, EventArgs e)
        {
            var selectedItems = ListOfSeries.SelectedItems;
            if (_viewModel.TitleIsNotNullOrEmpty)
                await _viewModel.SaveSeriesItemsListToDatabase(selectedItems, _viewModel.InputTitle);
            else
                _viewModel.InputTitleIsRequired = true;

            ListOfSeries.SelectedItems.Clear();
            _viewModel.InputTitle = "";
        }

        private void InputView_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.SetInputTitleErrorToFalse();
        }

        private async void ArrowLeft_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }

        #endregion
    }
}