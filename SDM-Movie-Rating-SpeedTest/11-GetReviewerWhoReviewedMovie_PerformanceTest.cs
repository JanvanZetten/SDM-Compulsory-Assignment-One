using SDM_Movie_Rating.Application;
using SDM_Movie_Rating.Application.Impl;
using SDM_Movie_Rating.Domain;
using SDM_Movie_Rating_JsonReader;
using System;
using System.Diagnostics;
using Xunit.Abstractions;
using Xunit;

// Disable Parrallelization for more accurate time test.
namespace SDM_Movie_Rating_SpeedTest
{
    [Collection("SpeedTest")]
    public class _11_GetReviewerWhoReviewedMovie_PerformanceTest
    {
        private IMovieRatingService _movieRatingService;
        private readonly ITestOutputHelper _outputHelper;

        public _11_GetReviewerWhoReviewedMovie_PerformanceTest(ITestOutputHelper outputHelper, DisposableMovieRating disposeableMovieRating)
        {
            _outputHelper = outputHelper;
            _movieRatingService = disposeableMovieRating.GetMovieRatingService();
        }

        [Theory]
        [InlineData(2066490)]
        [InlineData(2519299)]
        [InlineData(2425137)]
        [InlineData(305344)]
        public void Test(int reviewerId)
        {
            Assert.True(Timer.GetUserCPUTime(() => { _movieRatingService.GetReviewerWhoReviewedMovie(reviewerId); }, _outputHelper) < 4000);
        }
    }
}