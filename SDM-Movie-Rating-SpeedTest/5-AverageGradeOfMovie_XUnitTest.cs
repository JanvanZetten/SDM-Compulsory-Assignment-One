using SDM_Movie_Rating.Application;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace SDM_Movie_Rating_SpeedTest
{   [Collection("SpeedTest")]
    public class AverageGradeOfMovie_XUnitTest 
    {
        private IMovieRatingService _movieRatingService;
        private readonly ITestOutputHelper _outputHelper;

        public AverageGradeOfMovie_XUnitTest(DisposableMovieRating disposableMovieRating,
            ITestOutputHelper outputHelper)
        {
            _movieRatingService = disposableMovieRating.GetMovieRatingService();
            _outputHelper = outputHelper;
        }
        [Theory]
        [InlineData(2066490)]
        [InlineData(2519299)]
        [InlineData(2425137)]
        [InlineData(305344)]
        public void SpeedTest(int movieId)
        {
            Assert.True(Timer.GetUserCPUTime(() =>
            {
                _movieRatingService.AverageGradeOfMovie(movieId);
            }, _outputHelper) < 4000);
        }
    }
}
