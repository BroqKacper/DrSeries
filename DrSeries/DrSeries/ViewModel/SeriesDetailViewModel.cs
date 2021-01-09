using System;
using System.Collections.Generic;
using System.Text;
using DrSeries.Model;

namespace DrSeries.ViewModel
{
    public class SeriesDetailViewModel : CoreViewModel
    {

        public SeriesDetailViewModel()
        {
        }
        private Series _currentSeries;

        public Series CurrentSeries
        {
            get => _currentSeries ?? (_currentSeries = new Series());
            set
            {
                _currentSeries = value;
                OnPropertyChanged();
            }
        }

        public void LoadSeriesDetail(Series series)
        {
            CurrentSeries = series;
            Title = series.Name;
        }

    }
}
