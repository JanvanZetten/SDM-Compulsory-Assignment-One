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
    public class _01_CountReviewsOfReviewer_PerformanceTest
    {
        private IMovieRatingService _movieRatingService;
        private readonly ITestOutputHelper _outputHelper;
        
        public _01_CountReviewsOfReviewer_PerformanceTest(ITestOutputHelper outputHelper, DisposableMovieRating disposeableMovieRating)
        {
            _outputHelper = outputHelper;
            _movieRatingService = disposeableMovieRating.GetMovieRatingService();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(571)]
        [InlineData(1000)]
        public void Test(int reviewerId)
        {
            Assert.True(Timer.GetUserCPUTime(() => { _movieRatingService.CountReviewsOfReviewer(reviewerId); }, _outputHelper) < 4000);
        }
    }
}
