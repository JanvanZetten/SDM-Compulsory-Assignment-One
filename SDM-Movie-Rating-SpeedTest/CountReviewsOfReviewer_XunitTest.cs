using SDM_Movie_Rating.Application;
using SDM_Movie_Rating.Application.Impl;
using SDM_Movie_Rating.Domain;
using SDM_Movie_Rating_JsonReader;
using System;
using System.Diagnostics;
using Xunit.Abstractions;
using Xunit;

// Disable Parrallelization for more accurate time test.
[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SDM_Movie_Rating_SpeedTest
{
    public class CountReviewsOfReviewer_XunitTest : IClassFixture<DisposableMovieRating>
    {
        private IMovieRatingService _movieRatingService;
        private readonly ITestOutputHelper _outputHelper;
        
        public CountReviewsOfReviewer_XunitTest(ITestOutputHelper outputHelper, DisposableMovieRating disposeableMovieRating)
        {
            _outputHelper = outputHelper;
            _movieRatingService = disposeableMovieRating.GetMovieRatingService();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Test(int movieId)
        {
            Assert.True(Timer.GetUserCPUTime(() => { _movieRatingService.CountReviewsOfReviewer(movieId); }, _outputHelper) < 4000);
        }
    }
}
