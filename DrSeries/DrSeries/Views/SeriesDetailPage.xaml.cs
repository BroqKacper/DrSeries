using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrSeries.Model;
using DrSeries.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrSeries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeriesDetailPage : ContentPage
    {
        private readonly SeriesDetailViewModel _viewModel;
        public SeriesDetailPage(Series series)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _viewModel = new SeriesDetailViewModel();
            _viewModel.LoadSeriesDetail(series);
        }

        private async void ArrowLeft_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }
    }
}