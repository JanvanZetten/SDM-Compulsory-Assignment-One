using SDM_Movie_Rating.Application;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace SDM_Movie_Rating_SpeedTest
{
    [Collection("SpeedTest")]
    public class _7_GetMoviesWithMostGradesOfFive_XUnitTest
    {
        private IMovieRatingService _movieRatingService;
        private readonly ITestOutputHelper _outputHelper;

        public _7_GetMoviesWithMostGradesOfFive_XUnitTest(ITestOutputHelper outputHelper, 
            DisposableMovieRating disposeableMovieRating)
        {
            _outputHelper = outputHelper;
            _movieRatingService = disposeableMovieRating.GetMovieRatingService();
        }

        [Fact]
        public void SpeedTest()
        {
            Assert.True(Timer.GetUserCPUTime(() =>
            {
                _movieRatingService.GetMoviesWithMostGradesOfFive();

            }, _outputHelper) < 4000);
        }
    }
}
