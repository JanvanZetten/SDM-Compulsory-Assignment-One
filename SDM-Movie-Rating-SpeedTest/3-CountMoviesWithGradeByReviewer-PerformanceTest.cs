using System;
using SDM_Movie_Rating.Application;
using Xunit;
using Xunit.Abstractions;

namespace SDM_Movie_Rating_SpeedTest
{
    [Collection("SpeedTest")]
    public class __CountMoviesWithGradeByReviewer_PerformanceTest: IClassFixture<DisposableMovieRating>
    {

        private IMovieRatingService _movieRatingService;
        private readonly ITestOutputHelper _outputHelper;

        public __CountMoviesWithGradeByReviewer_PerformanceTest(ITestOutputHelper outputHelper, DisposableMovieRating disposeableMovieRating)
        {
            _outputHelper = outputHelper;
            _movieRatingService = disposeableMovieRating.GetMovieRatingService();
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(100, 2)]
        [InlineData(500, 4)]
        [InlineData(999, 5)]
        public void Test(int reviwerId, int grade)
        {
            Assert.True(Timer.GetUserCPUTime(() => { _movieRatingService.CountMoviesWithGradeByReviewer(reviwerId, grade); }, _outputHelper) < 4000);
        }
    }
}
