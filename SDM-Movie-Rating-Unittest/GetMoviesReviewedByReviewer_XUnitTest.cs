
using System;
using Xunit;
using Moq;
using SDM_Movie_Rating.Domain;
using System.Collections.Generic;
using SDM_Movie_Rating_Core_Entity;
using SDM_Movie_Rating.Application;
using SDM_Movie_Rating.Application.Impl;

namespace SDM_Movie_Rating_Unittest
{
    public class GetMoviesReviewedByReviewer_XUnitTest
    {
        private Mock<IReader> mockReader = new Mock<IReader>();
        List<MovieRating> list;
        IMovieRatingService movieRatingService;

        public GetMoviesReviewedByReviewer_XUnitTest()
        {
        }

        [Fact]
        public void AssertMethodGetsCorrectNumberOfReviewsAndCorrectMovies()
        {
            movieRatingService = new MovieRatingService(mockReader.Object);
            List<MovieRating> list = new List<MovieRating>();
            mockReader.Setup(x => x.GetAllMovieRatings()).Returns(() => list);
            int ReviewerId = 1;
            int MovieOne = 1;
            int MovieTwo = 2;

            //Adding MovieRatings to list
            #region
            MovieRating i1 = new MovieRating
            {
                Reviewer = ReviewerId,
                Movie = MovieOne,
                Grade = 2,
                Date = DateTime.Now
            };
            MovieRating i2 = new MovieRating
            {
                Reviewer = 10,
                Movie = 3,
                Grade = 4,
                Date = DateTime.Now
            };
            MovieRating i3 = new MovieRating
            {
                Reviewer = ReviewerId,
                Movie = MovieTwo,
                Grade = 5,
                Date = DateTime.Now
            };
            list.Add(i1);
            list.Add(i2);
            list.Add(i3);
            #endregion

            List<int> filteredList = movieRatingService.GetMoviesReviewedByReviewer(ReviewerId);

            Assert.True(filteredList.Count == 2);
            Assert.Contains(1, filteredList);
            Assert.Contains(2, filteredList);

        }

        [Fact]
        public void AssertListIsOrderedCorrectly()
        {
            movieRatingService = new MovieRatingService(mockReader.Object);
            List<MovieRating> list = new List<MovieRating>();
            mockReader.Setup(x => x.GetAllMovieRatings()).Returns(() => list);
            int ReviewerId = 3;

            //Supposed position: 4
            int MovieOneId = 79;
            int MovieOneGrade = 2;
            DateTime MovieOneDate = DateTime.Now.AddDays(-4);

            //Supposed position: 2
            int MovieTwoId = 40;
            int MovieTwoGrade = 4;
            DateTime MovieTwoDate = DateTime.Now.AddDays(-5);

            //Supposed position: 1
            int MovieThreeId = 804;
            int MovieThreeGrade = 4;
            DateTime MovieThreeDate = DateTime.Now.AddDays(-2);

            //Supposed position: 3
            int MovieFourId = 2;
            int MovieFourGrade = 3;
            DateTime MovieFourDate = DateTime.Now;

            //Adding MovieRatings to list
            #region
            MovieRating MovieOne = new MovieRating
            {
                Reviewer = ReviewerId,
                Movie = MovieOneId,
                Grade = MovieOneGrade,
                Date = MovieOneDate
            };
            MovieRating MovieZero = new MovieRating
            {
                Reviewer = 10,
                Movie = 3,
                Grade = 4,
                Date = DateTime.Now
            };
            MovieRating MovieTwo = new MovieRating
            {
                Reviewer = ReviewerId,
                Movie = MovieTwoId,
                Grade = MovieTwoGrade,
                Date = MovieTwoDate
            };
            MovieRating MovieThree = new MovieRating
            {
                Reviewer = ReviewerId,
                Movie = MovieThreeId,
                Grade = MovieThreeGrade,
                Date = MovieThreeDate
            };
            MovieRating MovieFour = new MovieRating
            {
                Reviewer = ReviewerId,
                Movie = MovieFourId,
                Grade = MovieFourGrade,
                Date = MovieFourDate
            };
            list.Add(MovieOne);
            list.Add(MovieZero);
            list.Add(MovieTwo);
            list.Add(MovieThree);
            list.Add(MovieFour);
            #endregion

            List<int> FilteredList = movieRatingService.GetMoviesReviewedByReviewer(ReviewerId);

            Assert.True(FilteredList[0] == MovieThreeId);
            Assert.True(FilteredList[1] == MovieTwoId);
            Assert.True(FilteredList[2] == MovieFourId);
            Assert.True(FilteredList[3] == MovieOneId);

        }
    }
}
