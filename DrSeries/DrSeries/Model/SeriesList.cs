using System.Collections.Generic;
using System.ComponentModel;

namespace DrSeries.Model
{
    public class SeriesList : INotifyPropertyChanged
    {
        private string _name;

        private int _oid;

        private List<Series> _selectedSeriesList;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public List<Series> SelectedSeriesList
        {
            get => _selectedSeriesList;
            set
            {
                _selectedSeriesList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedSeriesList)));
            }
        }

        public int Oid
        {
            get => _oid;
            set
            {
                _oid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Oid)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}