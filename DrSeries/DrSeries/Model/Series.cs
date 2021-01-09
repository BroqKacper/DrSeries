using System.ComponentModel;

namespace DrSeries.Model
{
    public class Series : INotifyPropertyChanged
    {
        private bool _isChecked;
        private bool _isVisible;
        private string _kind;
        private string _name;
        private int _oid;
        private string _originalName;
        private string _overview;
        private string _popularity;
        private string _posterUrl;
        private string _rate;
        private string _review;
        private string _voteAverage;
        private string _voteCount;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsChecked)));
            }
        }

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsVisible)));
            }
        }

        public string Rate
        {
            get => _rate;
            set
            {
                _rate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rate)));
            }
        }


        public string Review
        {
            get => _review;
            set
            {
                _review = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Review)));
            }
        }

        public string Kind
        {
            get => _kind;
            set
            {
                _kind = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Kind)));
            }
        }

        public string PosterUrl
        {
            get => _posterUrl;
            set
            {
                _posterUrl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PosterUrl)));
            }
        }

        public string Popularity
        {
            get => _popularity;
            set
            {
                _popularity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Popularity)));
            }
        }

        public string Overview
        {
            get => _overview;
            set
            {
                _overview = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Overview)));
            }
        }

        public string OriginalName
        {
            get => _originalName;
            set
            {
                _originalName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OriginalName)));
            }
        }

        public string VoteCount
        {
            get => _voteCount;
            set
            {
                _voteCount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VoteCount)));
            }
        }

        public string VoteAverage
        {
            get => _voteAverage;
            set
            {
                _voteAverage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VoteAverage)));
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