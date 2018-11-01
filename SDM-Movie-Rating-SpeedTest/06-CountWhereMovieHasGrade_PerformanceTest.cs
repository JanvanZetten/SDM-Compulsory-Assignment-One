using SDM_Movie_Rating.Application;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace SDM_Movie_Rating_SpeedTest
{
    [Collection("SpeedTest")]
    public class _06_CountWhereMovieHasGrade_PerformanceTest
    {
        private IMovieRatingService _movieRatingService;
        private readonly ITestOutputHelper _outputHelper;

        public _06_CountWhereMovieHasGrade_PerformanceTest(DisposableMovieRating DisposableMovieRating, 
            ITestOutputHelper outputHelper)
        {
            _movieRatingService = DisposableMovieRating.GetMovieRatingService();
            _outputHelper = outputHelper;
        }
        [Theory]
        [InlineData(2066490, 2)]
        [InlineData(2519299, 3)]
        [InlineData(2425137, 4)]
        [InlineData(305344, 5)]
        [InlineData(305344, 4)]
        [InlineData(305344, 3)]
        [InlineData(305344, 2)]
        [InlineData(305344, 1)]
        public void SpeedTest(int movieId, int grade)
        {
            Assert.True(Timer.GetUserCPUTime(() => {_movieRatingService.CountWhereMovieHasGrade(movieId, grade);},_outputHelper) < 4000);
        }

    }
}
