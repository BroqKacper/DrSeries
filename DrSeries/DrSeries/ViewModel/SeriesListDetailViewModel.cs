using System.Collections.ObjectModel;
using DrSeries.Model;

namespace DrSeries.ViewModel
{
    public class SeriesListDetailViewModel : CoreViewModel
    {
        #region Load methods

        public void LoadSeriesListDetail(SeriesList seriesList)
        {
            SeriesListDetail.Clear();
            if (seriesList.SelectedSeriesList != null)
                foreach (var series in seriesList.SelectedSeriesList)
                    SeriesListDetail.Add(series);
        }

        #endregion

        #region Properties

        private ObservableCollection<Series> _seriesListDetail;

        public SeriesListDetailViewModel()
        {
            SeriesListDetail = new ObservableCollection<Series>();
        }

        public ObservableCollection<Series> SeriesListDetail
        {
            get => _seriesListDetail ?? (_seriesListDetail = new ObservableCollection<Series>());
            set
            {
                _seriesListDetail = value;
                OnPropertyChanged();
            }
        }

        public bool IsVisiblee { get; set; }

        #endregion
    }
}