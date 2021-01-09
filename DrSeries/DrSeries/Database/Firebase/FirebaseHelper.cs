using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrSeries.Model;
using Firebase.Database;
using Firebase.Database.Query;

namespace DrSeries.Database.Firebase
{
    public class FirebaseHelper
    {
        private readonly FirebaseClient _firebase =
            new FirebaseClient("https://dr-series-ce317-default-rtdb.europe-west1.firebasedatabase.app/");

        #region Get All methods

        public async Task<List<Series>> GetAllSeries()
        {
            return (await _firebase
                .Child("Series")
                .OnceAsync<Series>()).Select(item => new Series
            {
                Name = item.Object.Name, Kind = item.Object.Kind, OriginalName = item.Object.OriginalName,
                Overview = item.Object.Overview, Popularity = item.Object.Popularity, PosterUrl = item.Object.PosterUrl,
                Rate = item.Object.Rate, Review = item.Object.Review, VoteAverage = item.Object.VoteAverage,
                VoteCount = item.Object.VoteCount, Oid = item.Object.Oid
            }).ToList();
        }

        public async Task<List<SeriesList>> GetAllSeriesList()
        {
            return (await _firebase
                .Child("SeriesList")
                .OnceAsync<SeriesList>()).Select(item => new SeriesList
            {
                Name = item.Object.Name, SelectedSeriesList = item.Object.SelectedSeriesList,
                Oid = item.Object.Oid
            }).ToList();
        }

        public async Task<List<SeriesKind>> GetAllSerieKinds()
        {
            return (await _firebase
                .Child("SeriesKind")
                .OnceAsync<SeriesKind>()).Select(item => new SeriesKind
            {
                Name = item.Object.Name, Oid = item.Object.Oid
            }).ToList();
        }

        #endregion

        #region Add methods

        public async Task AddSeries(Series series)
        {
            var random = new Random();
            await _firebase
                .Child("Series")
                .PostAsync(new Series
                {
                    Name = series.Name,
                    Kind = series.Kind,
                    OriginalName = series.OriginalName,
                    Overview = series.Overview,
                    Popularity = series.Popularity,
                    PosterUrl = series.PosterUrl,
                    Rate = series.Rate,
                    Review = series.Review,
                    VoteAverage = series.VoteAverage,
                    VoteCount = series.VoteCount,
                    Oid = random.Next()
                });
        }

        public async Task AddSeriesList(int oid, string name, List<Series> seriesList)
        {
            var random = new Random();
            await _firebase
                .Child("SeriesList")
                .PostAsync(new SeriesList
                {
                    Name = name, SelectedSeriesList = seriesList,
                    Oid = random.Next()
                });
        }

        public async Task AddSeriesKind(int oid, string name)
        {
            await _firebase
                .Child("SeriesKind")
                .PostAsync(new SeriesKind
                {
                    Name = name,
                    Oid = oid
                });
        }

        #endregion

        #region Update methods

        public async Task UpdateSeries(Series series)
        {
            var updateSeries = (await _firebase
                .Child("Series")
                .OnceAsync<Series>()).FirstOrDefault(a => a.Object.Oid == series.Oid);

            if (updateSeries != null)
                await _firebase
                    .Child("Series")
                    .Child(updateSeries.Key)
                    .PutAsync(new Series
                    {
                        Name = series.Name,
                        Kind = series.Kind,
                        OriginalName = series.OriginalName,
                        Overview = series.Overview,
                        Popularity = series.Popularity,
                        PosterUrl = series.PosterUrl,
                        Rate = series.Rate,
                        Review = series.Review,
                        VoteAverage = series.VoteAverage,
                        VoteCount = series.VoteCount,
                        Oid = series.Oid
                    });
        }

        public async Task UpdateSeriesList(int oid, string name, List<Series> seriesList)
        {
            var updateSeriesList = (await _firebase
                .Child("SeriesList")
                .OnceAsync<SeriesList>()).FirstOrDefault(a => a.Object.Oid == oid);

            if (updateSeriesList != null)
                await _firebase
                    .Child("SeriesList")
                    .Child(updateSeriesList.Key)
                    .PutAsync(new SeriesList
                    {
                        Name = name,
                        SelectedSeriesList = seriesList,
                        Oid = oid
                    });
        }

        #endregion

        #region Delete methods

        public async Task DeleteSeries(int seriesOid)
        {
            var deleteSeries = (await _firebase
                .Child("Series")
                .OnceAsync<Series>()).FirstOrDefault(a => a.Object.Oid == seriesOid);
            await _firebase.Child("Series").Child(deleteSeries.Key).DeleteAsync();
        }

        public async Task DeleteSeriesList(int seriesListOid)
        {
            var deleteSeries = (await _firebase
                .Child("SeriesList")
                .OnceAsync<SeriesList>()).FirstOrDefault(a => a.Object.Oid == seriesListOid);
            await _firebase.Child("SeriesList").Child(deleteSeries.Key).DeleteAsync();
        }

        #endregion
    }
}