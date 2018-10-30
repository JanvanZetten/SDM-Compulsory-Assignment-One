using SDM_Movie_Rating.Application;
using SDM_Movie_Rating.Application.Impl;
using SDM_Movie_Rating.Domain;
using SDM_Movie_Rating_JsonReader;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDM_Movie_Rating_SpeedTest
{
    public class DisposableMovieRating : IDisposable
    {
        private IReader _reader;
        private IMovieRatingService _movieRatingService;

        public DisposableMovieRating()
        {
            _reader = new JsonFileAccessObject();
            _movieRatingService = new MovieRatingService(_reader);
        }

        public IMovieRatingService GetMovieRatingService()
        {
            return _movieRatingService;
        }

        public void Dispose()
        {
        }
    }
}
