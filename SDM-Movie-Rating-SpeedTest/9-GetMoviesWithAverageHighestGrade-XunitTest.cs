using SDM_Movie_Rating.Application;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace SDM_Movie_Rating_SpeedTest
{
    [Collection("SpeedTest")]
    public class _9_GetMoviesWithAverageHighestGrade_XunitTest
    {
        private IMovieRatingService _movieRating;
        private readonly ITestOutputHelper _outputhelper;

        public _9_GetMoviesWithAverageHighestGrade_XunitTest
            (DisposableMovieRating disposableMovieRating, ITestOutputHelper outputHelper)
        {
            _movieRating = disposableMovieRating.GetMovieRatingService();
            _outputhelper = outputHelper;
        }
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        public void SpeedTest(int amount)
        {
            Assert.True(Timer.GetUserCPUTime(() =>
            {
                _movieRating.GetMoviesWithAverageHighestGrade(amount);
            }, _outputhelper) < 4000);
        }
            
    }
}
