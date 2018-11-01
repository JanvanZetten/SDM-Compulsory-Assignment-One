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
    public class GetMoviesWithAverageHighestGrade_XunitTest
    {
        private Mock<IReader> mockReader = new Mock<IReader>();
        private int movieOne = 1;
        private int movieTwo = 2;

        IMovieRatingService movieRatingService;

        public GetMoviesWithAverageHighestGrade_XunitTest()
        {
            //Setup
            mockReader.Setup(x => x.GetAllMovieRatings()).Returns(() => new List<MovieRating>() {
                new MovieRating(){
                    Reviewer = 1,
                    Movie = movieOne,
                    Date = DateTime.Now,
                    Grade = 5
                },

                new MovieRating(){
                    Reviewer = 2,
                    Movie = movieOne,
                    Date = DateTime.Now,
                    Grade = 4
                },

                new MovieRating(){
                    Reviewer = 1,
                    Movie = movieTwo,
                    Date = DateTime.Now,
                    Grade = 3
                }
            });

            movieRatingService = new MovieRatingService(mockReader.Object);
        }

        [Fact]
        public void GetMoviesWithAverageHighestGradeValidTest()
        {
            var result = movieRatingService.GetMoviesWithAverageHighestGrade(1);
            var expectedResult = new List<int>()
            {
                movieOne
            };

            Assert.Equal(expectedResult, result);

            result = movieRatingService.GetMoviesWithAverageHighestGrade(2);
            expectedResult = new List<int>()
            {
                movieOne,
                movieTwo
            };

            Assert.Equal(expectedResult, result);
            
            // Expects the first two because the movieThree has no ratings.
            result = movieRatingService.GetMoviesWithAverageHighestGrade(3);
            expectedResult = new List<int>()
            {
                movieOne,
                movieTwo
            };

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetMoviesWithAverageHighestGradeValidEmptyTest()
        {
            Mock<IReader> mockReaderEmpty = new Mock<IReader>();
            mockReaderEmpty.Setup(x => x.GetAllMovieRatings()).Returns(() => new List<MovieRating>());
            MovieRatingService movieRatingServiceEmpty = new MovieRatingService(mockReaderEmpty.Object);
            var result = movieRatingServiceEmpty.GetMoviesWithAverageHighestGrade(1);

            Assert.Empty(result);
        }

        [Fact]
        public void GetMoviesWithAverageHighestGradeInvalidTest()
        {
            List<int> result = null;
            Assert.Throws<ArgumentException>(() =>
            {
                result = movieRatingService.GetMoviesWithAverageHighestGrade(0);
            });
            Assert.Null(result);

            Assert.Throws<ArgumentException>(() =>
            {
                result = movieRatingService.GetMoviesWithAverageHighestGrade(-1);
            });
            Assert.Null(result);
        }
    }
}
