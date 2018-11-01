using SDM_Movie_Rating.Application;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace SDM_Movie_Rating_SpeedTest
{
    [assembly: CollectionBehavior(DisableTestParallelization = true)]
    public class CountWhereMovieHasGrade : IClassFixture<DisposableMovieRating>
    {
        private IMovieRatingService _movieRatingService;
        private readonly ITestOutputHelper _outputHelper;

        public CountWhereMovieHasGrade(DisposableMovieRating DisposableMovieRating, 
            ITestOutputHelper outputHelper)
        {
            _movieRatingService = DisposableMovieRating.GetMovieRatingService();
            _outputHelper = outputHelper;
        }
        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        public void SpeedTest(int movieId)
        {
            Assert.True(Timer.GetUserCPUTime(() =>
            {
                _movieRatingService.CountWhereMovieHasGrade(movieId, 1);

            },_outputHelper) < 4000);
        }

    }
}
