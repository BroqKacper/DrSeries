using System.ComponentModel;

namespace DrSeries.Model
{
    public class SeriesKind : INotifyPropertyChanged
    {
        private string _name;

        private int _oid;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
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