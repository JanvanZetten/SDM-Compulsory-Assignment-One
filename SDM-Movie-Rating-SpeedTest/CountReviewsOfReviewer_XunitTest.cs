using SDM_Movie_Rating.Application;
using SDM_Movie_Rating.Application.Impl;
using SDM_Movie_Rating.Domain;
using SDM_Movie_Rating_JsonReader;
using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

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
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Process p = Process.GetCurrentProcess();
            double startUserProcessorTm = p.UserProcessorTime.TotalMilliseconds;

            _movieRatingService.CountReviewsOfReviewer(movieId);

            double endUserProcessorTm = p.UserProcessorTime.TotalMilliseconds;
            watch.Stop();

            _outputHelper.WriteLine(endUserProcessorTm - startUserProcessorTm + "");
            _outputHelper.WriteLine(watch.Elapsed.TotalMilliseconds + "");

            Assert.True((endUserProcessorTm - startUserProcessorTm) < 4000);
        }
    }
}
