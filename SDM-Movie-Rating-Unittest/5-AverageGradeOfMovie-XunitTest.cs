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
    public class AverageGradeOfMovie_XunitTest
    {
        private Mock<IReader> mockReader = new Mock<IReader>();
        private int MovieOne = 1;
        private int MovieTwo = 2;
        private int MovieThree = 3;
        private int MovieFour = 4;
        IMovieRatingService movieRatingService;

        public AverageGradeOfMovie_XunitTest()
        {
            //Setup
            var gradeOne = 1;
            var gradeFive = 5;

            mockReader.Setup(x => x.GetAllMovieRatings()).Returns(() => new List<MovieRating>() {
                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieOne,
                    Date = DateTime.Now,
                    Grade = gradeOne
                },

                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieOne,
                    Date = DateTime.Now,
                    Grade = gradeFive
                },

                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieOne,
                    Date = DateTime.Now
                },

                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieTwo,
                    Date = DateTime.Now,
                    Grade = gradeFive
                },

                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieTwo,
                    Date = DateTime.Now,
                    Grade = gradeFive
                },

                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieTwo,
                    Date = DateTime.Now,
                    Grade = gradeFive
                },

                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieThree,
                    Date = DateTime.Now
                }
            });

            movieRatingService = new MovieRatingService(mockReader.Object);
        }

        [Fact]
        public void AverageGradeOfMovieValidTest()
        {
            var result = movieRatingService.AverageGradeOfMovie(MovieOne);

            Assert.Equal(3, result);

            result = movieRatingService.AverageGradeOfMovie(MovieTwo);

            Assert.Equal(5, result);
        }

        [Fact]
        public void AverageGradeOfMovieInvalidTest()
        {
            double result = 0.0;

            Assert.Throws<NullReferenceException>(() =>
            {
                result = movieRatingService.AverageGradeOfMovie(MovieThree);
            });

            Assert.Equal(0.0, result, 2);

            Assert.Throws<NullReferenceException>(() =>
            {
                result = movieRatingService.AverageGradeOfMovie(MovieFour);
            });

            Assert.Equal(0.0, result, 2);
        }
    }
}
