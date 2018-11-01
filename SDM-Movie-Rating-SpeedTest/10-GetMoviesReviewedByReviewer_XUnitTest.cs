using System;
using System.Collections.Generic;
using System.Text;
using SDM_Movie_Rating.Application;
using Xunit;
using Xunit.Abstractions;

namespace SDM_Movie_Rating_SpeedTest
{
    [Collection("SpeedTest")]
    public class _10_GetMoviesReviewedByReviewer_XUnitTest
    {
        private readonly ITestOutputHelper _outputHelper;
        private IMovieRatingService _movieRatingService;

        public _10_GetMoviesReviewedByReviewer_XUnitTest(ITestOutputHelper outputHelper, DisposableMovieRating disposeableMovieRating)
            {
                _outputHelper = outputHelper;
                _movieRatingService = disposeableMovieRating.GetMovieRatingService();
            }

            [Theory]
            [InlineData(2066490)]
            public void SpeedTest(int reviewerId)
            {
                Assert.True(Timer.GetUserCPUTime(() =>
                { _movieRatingService.GetMoviesReviewedByReviewer(reviewerId);
                }, _outputHelper) < 4000);
            }
        }
}
