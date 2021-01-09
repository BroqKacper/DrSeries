using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DrSeries.Database.Firebase;
using DrSeries.Model;

namespace DrSeries.ViewModel
{
    public class CoreViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        #region Properties

        private readonly FirebaseHelper _firebaseHelper = new FirebaseHelper();
        private ObservableCollection<string> _seriesKind;

        public ObservableCollection<string> SeriesKind
        {
            get => _seriesKind ?? (_seriesKind = new ObservableCollection<string>());
            set
            {
                _seriesKind = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _seriesRate;

        public ObservableCollection<string> SeriesRate
        {
            get => _seriesRate ?? (_seriesRate = new ObservableCollection<string>());
            set
            {
                _seriesRate = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Series> _seriesList;

        public ObservableCollection<Series> SeriesList
        {
            get => _seriesList ?? (_seriesList = new ObservableCollection<Series>());
            set
            {
                _seriesList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SeriesList> _mySelectedSeriesListCollection;

        public ObservableCollection<SeriesList> MySelectedSeriesListCollection
        {
            get => _mySelectedSeriesListCollection ??
                   (_mySelectedSeriesListCollection = new ObservableCollection<SeriesList>());
            set
            {
                _mySelectedSeriesListCollection = value;
                OnPropertyChanged();
            }
        }

        private bool _inputNameIsRequired;

        public bool InputNameIsRequired
        {
            get => _inputNameIsRequired;
            set
            {
                _inputNameIsRequired = value;
                OnPropertyChanged();
            }
        }

        private bool _inputTitleIsRequired;

        public bool InputTitleIsRequired
        {
            get => _inputTitleIsRequired;
            set
            {
                _inputTitleIsRequired = value;
                OnPropertyChanged();
            }
        }

        private string _title;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region Load methods

        public async Task LoadSeriesKind()
        {
            SeriesKind.Clear();
            var list = await _firebaseHelper.GetAllSerieKinds();
            foreach (var seriesKind in list) SeriesKind.Add(seriesKind.Name);
        }

        public async Task LoadSeriesRate()
        {
            SeriesRate.Clear();
            var rates = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            foreach (var rate in rates) SeriesRate.Add(rate.ToString());
        }

        public async Task LoadSeries()
        {
            SeriesList.Clear();
            var list = await _firebaseHelper.GetAllSeries();
            foreach (var series in list) SeriesList.Add(series);
        }

        public async Task LoadSeriesWithFilter(SeriesList seriesList)
        {
            SeriesList.Clear();
            var list = await _firebaseHelper.GetAllSeries();
            var result = list.Where(p => !seriesList.SelectedSeriesList.Any(p2 => p2.Oid == p.Oid));

            foreach (var series in result) SeriesList.Add(series);
        }

        public async Task LoadMySelectedSeriesList()
        {
            MySelectedSeriesListCollection.Clear();
            var list = await _firebaseHelper.GetAllSeriesList();
            foreach (var seriesList in list) MySelectedSeriesListCollection.Add(seriesList);
        }

        #endregion


        #region Save methods

        public async Task SaveSeriesItemsListToDatabase(ObservableCollection<object> selectedItems, string listName)
        {
            var selectedSeriesList =
                new ObservableCollection<Series>(selectedItems.Cast<Series>().ToList());
            var dbSeriesList = CreateDbSeriesListObject(listName, selectedSeriesList);
            await _firebaseHelper.AddSeriesList(dbSeriesList.Oid, dbSeriesList.Name, dbSeriesList.SelectedSeriesList);
        }

        private static SeriesList CreateDbSeriesListObject(string listName,
            ObservableCollection<Series> selectedSeriesList)
        {
            var seriesList = new SeriesList();
            seriesList.Name = listName;
            seriesList.SelectedSeriesList = new List<Series>(selectedSeriesList);
            return seriesList;
        }

        #endregion


        #region Remove methods

        public async Task RemoveSeriesFromSeriesListDatabase(Series series)
        {
            await _firebaseHelper.DeleteSeries(series.Oid);
        }

        public async Task RemoveMySeriesListFromDatabase(int oid)
        {
            await _firebaseHelper.DeleteSeriesList(oid);
        }

        public async Task UpdateSeriesList(SeriesList seriesList)
        {
            await _firebaseHelper.UpdateSeriesList(seriesList.Oid, seriesList.Name, seriesList.SelectedSeriesList);
        }

        #endregion

        //public async Task AddNewSeriesKind()
        //{
        //    var series1 = new SeriesKind() {Name = "Film", Oid = 1};
        //    var series2 = new SeriesKind() {Name = "Serial", Oid = 2};

        //    await firebaseHelper.AddSeriesKind(series1.Oid, series1.Name);
        //    await firebaseHelper.AddSeriesKind(series2.Oid, series2.Name);
        //}
    }
}