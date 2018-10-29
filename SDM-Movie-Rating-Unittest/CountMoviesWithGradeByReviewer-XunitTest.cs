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
    public class CountMoviesWithGradeByReviewer_XunitTest
    {
        private Mock<IReader> mockReader = new Mock<IReader>();
        private int ReviewerOne;
        private int ReviewerTwo;
        private int GradeOne;
        private int GradeTwo;
        IMovieRatingService movieRatingService;

        public CountMoviesWithGradeByReviewer_XunitTest()
        {
            //Setup
            ReviewerOne = 1;
            ReviewerTwo = 2;
            GradeOne = 1;
            GradeTwo = 5;

            mockReader.Setup(x => x.GetAllMovieRatings()).Returns(() => new List<MovieRating>() {
                new MovieRating(){
                    Reviewer = ReviewerOne,
                    Movie = 1,
                    Date = DateTime.Now,
                    Grade = GradeOne
                },

                new MovieRating(){
                    Reviewer = ReviewerOne,
                    Movie = 2,
                    Date = DateTime.Now,
                    Grade = GradeOne
                },

                new MovieRating(){
                    Reviewer = ReviewerOne,
                    Movie = 3,
                    Date = DateTime.Now,
                    Grade = GradeTwo
                },

                new MovieRating(){
                    Reviewer = ReviewerTwo,
                    Movie = 1,
                    Date = DateTime.Now,
                    Grade = GradeTwo
                }
            });

            movieRatingService = new MovieRatingService(mockReader.Object);
        }

        [Fact]
        public void CountMoviesWithGradeByReviewerValidTest()
        {
            var result = movieRatingService.CountMoviesWithGradeByReviewer(ReviewerOne, GradeOne);

            Assert.Equal(2, result); 

            result = movieRatingService.CountMoviesWithGradeByReviewer(ReviewerOne, GradeTwo);

            Assert.Equal(1, result); 

            result = movieRatingService.CountMoviesWithGradeByReviewer(ReviewerTwo, GradeTwo);

            Assert.Equal(1, result); 

            result = movieRatingService.CountMoviesWithGradeByReviewer(ReviewerTwo, GradeOne);

            Assert.Equal(0, result);
        }
    }
}
