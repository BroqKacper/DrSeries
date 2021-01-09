using System;
using System.Threading.Tasks;
using DM.MovieApi;
using DM.MovieApi.MovieDb.TV;
using DrSeries.Database.Firebase;
using DrSeries.Model;

namespace DrSeries.ViewModel
{
    public class AddNewSeriesViewModel : CoreViewModel
    {
        #region Properties

        private string _inputName;
        private string _inputReview;
        private object _selectedKind;
        private object _selectedRate;
        private readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        private bool NameIsNotNullOrEmpty => !string.IsNullOrWhiteSpace(InputName);

        public string InputName
        {
            get => _inputName;
            set
            {
                _inputName = value;
                OnPropertyChanged();
            }
        }

        public string InputReview
        {
            get => _inputReview;
            set
            {
                _inputReview = value;
                OnPropertyChanged();
            }
        }

        public object SelectedSeriesRate
        {
            get => _selectedRate;
            set
            {
                _selectedRate = value;
                OnPropertyChanged();
            }
        }

        public object SelectedSeriesKind
        {
            get => _selectedKind;
            set
            {
                _selectedKind = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Add methods

        public async Task<bool> AddNewSeries()
        {
            var series = await CreateSeries();
            try
            {
                await firebaseHelper.AddSeries(series);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task<Series> CreateSeries()
        {
            var series = new Series();
            var isError = CheckInputValidation(series);
            if (isError.Equals(true))
            {
                var movieApi = MovieDbFactory.Create<IApiTVShowRequest>().Value;
                try
                {
                    var posterUrl = App.seriesUrlPoster;
                    var response = await movieApi.SearchByNameAsync(InputName, 1, "pl");
                    foreach (var info in response.Results)
                    {
                        posterUrl += info.PosterPath;
                        SetAnotherInformationAboutSeries(series, info);
                    }

                    series.PosterUrl = posterUrl;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return series;
        }

        private static void SetAnotherInformationAboutSeries(Series series, TVShowInfo info)
        {
            series.Overview = info.OriginalName;
            series.Overview = info.Overview;
            series.Popularity = info.Popularity.ToString();
            series.VoteAverage = info.VoteAverage.ToString();
            series.VoteCount = info.VoteCount.ToString();
            series.Name = info.OriginalName;
        }

        #endregion

        #region Validation input

        private bool CheckInputValidation(Series dbSeries)
        {
            if (NameIsNotNullOrEmpty)
            {
                dbSeries.Name = InputName;
            }
            else
            {
                InputNameIsRequired = true;
                return false;
            }

            if (!string.IsNullOrEmpty(InputReview))
                dbSeries.Review = InputReview;
            else
                dbSeries.Review = "";

            if (!string.IsNullOrEmpty(SelectedSeriesKind.ToString()))
                dbSeries.Kind = SelectedSeriesKind.ToString();
            else
                dbSeries.Kind = "";

            if (!string.IsNullOrEmpty(SelectedSeriesRate.ToString()))
                dbSeries.Rate = SelectedSeriesRate.ToString();
            else
                dbSeries.Rate = "";

            return true;
        }

        public void SetInputErrorToFalse()
        {
            InputNameIsRequired = false;
        }

        #endregion
    }
}