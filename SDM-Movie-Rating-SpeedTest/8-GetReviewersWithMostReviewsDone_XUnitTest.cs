using SDM_Movie_Rating.Application;
using Xunit.Abstractions;
using Xunit;

// Disable Parrallelization for more accurate time test.
namespace SDM_Movie_Rating_SpeedTest
{
    [Collection("SpeedTest")]
    public class GetReviewersWithMostReviewsDone_XunitTest
    {
        private IMovieRatingService _movieRatingService;
        private readonly ITestOutputHelper _outputHelper;

        public GetReviewersWithMostReviewsDone_XunitTest(ITestOutputHelper outputHelper, DisposableMovieRating disposeableMovieRating)
        {
            _outputHelper = outputHelper;
            _movieRatingService = disposeableMovieRating.GetMovieRatingService();
        }

        [Fact]
        public void Test()
        {
            Assert.True(Timer.GetUserCPUTime(() => { _movieRatingService.GetReviewersWithMostReviewsDone(); }, _outputHelper) < 4000);
        }
    }
}