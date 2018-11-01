using SDM_Movie_Rating.Application;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace SDM_Movie_Rating_SpeedTest
{
    [Collection("SpeedTest")]
    public class _09_GetMoviesWithAverageHighestGrade_PerformanceTest
    {
        private IMovieRatingService _movieRating;
        private readonly ITestOutputHelper _outputhelper;

        public _09_GetMoviesWithAverageHighestGrade_PerformanceTest
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
