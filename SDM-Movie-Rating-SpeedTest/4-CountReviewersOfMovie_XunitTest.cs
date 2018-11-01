using SDM_Movie_Rating.Application;
using Xunit.Abstractions;
using Xunit;

// Disable Parrallelization for more accurate time test.
namespace SDM_Movie_Rating_SpeedTest
{
    [Collection("SpeedTest")]
    public class CountReviewersOfMovie_XunitTest : IClassFixture<DisposableMovieRating>
    {
        private IMovieRatingService _movieRatingService;
        private readonly ITestOutputHelper _outputHelper;

        public CountReviewersOfMovie_XunitTest(ITestOutputHelper outputHelper, DisposableMovieRating disposeableMovieRating)
        {
            _outputHelper = outputHelper;
            _movieRatingService = disposeableMovieRating.GetMovieRatingService();
        }
        
        [Theory]
        [InlineData(2066490)]
        [InlineData(2519299)]
        [InlineData(2425137)]
        [InlineData(305344)]
        public void Test(int movieId)
        {
            Assert.True(Timer.GetUserCPUTime(() => { _movieRatingService.CountReviewersOfMovie(movieId); }, _outputHelper) < 4000);
        }
    }
}