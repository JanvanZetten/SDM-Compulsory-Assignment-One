using SDM_Movie_Rating.Application;
using Xunit.Abstractions;
using Xunit;

// Disable Parrallelization for more accurate time test.
namespace SDM_Movie_Rating_SpeedTest
{
    [Collection("SpeedTest")]
    public class _02_AverageGradeOfReviewer_PerformanceTest
    {
        private IMovieRatingService _movieRatingService;
        private readonly ITestOutputHelper _outputHelper;

        public _02_AverageGradeOfReviewer_PerformanceTest(ITestOutputHelper outputHelper, DisposableMovieRating disposeableMovieRating)
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
            Assert.True(Timer.GetUserCPUTime(() => { _movieRatingService.AverageGradeOfReviewer(reviewerId); }, _outputHelper) < 4000);
        }
    }
}