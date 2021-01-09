using System.Collections.ObjectModel;

namespace DrSeries.ViewModel
{
    public class CreateSeriesListViewModel : CoreViewModel
    {
        public CreateSeriesListViewModel()
        {
            SelectedItems = new ObservableCollection<object>();
        }


        public void SetInputTitleErrorToFalse()
        {
            InputTitleIsRequired = false;
        }

        #region Properties

        private string _inputTitle;

        private object _selectedItem;


        public bool TitleIsNotNullOrEmpty => !string.IsNullOrWhiteSpace(InputTitle);

        public ObservableCollection<object> SelectedItems { get; set; }

        public string InputTitle
        {
            get => _inputTitle;
            set
            {
                _inputTitle = value;
                OnPropertyChanged();
            }
        }

        public object SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}