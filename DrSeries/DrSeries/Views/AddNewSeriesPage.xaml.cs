using System;
using DrSeries.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrSeries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewSeriesPage : ContentPage
    {
        private readonly AddNewSeriesViewModel _viewModel;

        public AddNewSeriesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _viewModel = new AddNewSeriesViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadSeriesKind();
            await _viewModel.LoadSeriesRate();
        }

        #region Buttons

        private async void AddNewSeries_OnClicked(object sender, EventArgs e)
        {
            //await _viewModel.AddNewSeriesKind();
            var isAdded = await _viewModel.AddNewSeries();
            if (isAdded.Equals(true)) await Navigation.PopAsync(true);
        }

        private void InputNameEntry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.SetInputErrorToFalse();
        }

        private async void ArrowLeft_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }

        #endregion
    }
}