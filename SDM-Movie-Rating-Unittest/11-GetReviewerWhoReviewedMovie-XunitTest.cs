using System;
using System.Collections.Generic;
using Moq;
using SDM_Movie_Rating.Application;
using SDM_Movie_Rating.Application.Impl;
using SDM_Movie_Rating.Domain;
using SDM_Movie_Rating_Core_Entity;
using Xunit;

namespace SDM_Movie_Rating_Unittest
{
    public class GetReviewerWhoReviewedMovie_XunitTest
    {

        private Mock<IReader> mockReader = new Mock<IReader>();
        private int movieOne = 1;
        private int movieTwo = 2;
        private int movieThree = 3;
        private int movieFour = 4;

        private int reviwerOne = 1;
        private int reviwerTwo = 2;
        IMovieRatingService movieRatingService;

        public GetReviewerWhoReviewedMovie_XunitTest()
        {
            //Setup
            mockReader.Setup(x => x.GetAllMovieRatings()).Returns(() => new List<MovieRating>() {
                new MovieRating(){
                    Reviewer = reviwerOne,
                    Movie = movieOne,
                    Date = DateTime.Now,
                    Grade = 4
                },

                new MovieRating(){
                    Reviewer = reviwerTwo,
                    Movie = movieOne,
                    Date = DateTime.Now,
                    Grade = 5
                },

                new MovieRating(){
                    Reviewer = reviwerOne,
                    Movie = movieTwo,
                    Date = DateTime.Now,
                    Grade = 3
                },

                new MovieRating(){
                    Reviewer = reviwerOne,
                    Movie = movieThree,
                    Date = DateTime.Now.AddDays(-1),
                    Grade = 3
                },

                new MovieRating(){
                    Reviewer = reviwerTwo,
                    Movie = movieThree,
                    Date = DateTime.Now,
                    Grade = 3
                },

                new MovieRating(){
                    Reviewer = reviwerOne,
                    Movie = movieFour,
                    Date = DateTime.Now.AddDays(-1),
                    Grade = 3
                },

                new MovieRating(){
                    Reviewer = reviwerOne,
                    Movie = movieFour,
                    Date = DateTime.Now,
                    Grade = 3
                }

            });

            movieRatingService = new MovieRatingService(mockReader.Object);
        }


        [Fact]
        public void GetReviewerWhoReviewedMovieValidTest(){

            var result = movieRatingService.GetReviewerWhoReviewedMovie(movieOne);
            var expectedResult = new List<int>()
            {
                reviwerTwo,
                reviwerOne
            };

            Assert.Equal(expectedResult, result);

            result = movieRatingService.GetReviewerWhoReviewedMovie(movieTwo);
            expectedResult = new List<int>()
            {
                reviwerOne
            };

            Assert.Equal(expectedResult, result);

            result = movieRatingService.GetReviewerWhoReviewedMovie(movieThree);
            expectedResult = new List<int>()
            {
                reviwerTwo,
                reviwerOne
            };

            Assert.Equal(expectedResult, result);

            result = movieRatingService.GetReviewerWhoReviewedMovie(movieFour);
            expectedResult = new List<int>()
            {
                reviwerOne,
                reviwerOne
            };

            Assert.Equal(expectedResult, result);

        }


        [Fact]
        public void GetReviewerWhoReviewedMovieValidEmptyTest()
        {
            Mock<IReader> mockReaderEmpty = new Mock<IReader>();
            mockReaderEmpty.Setup(x => x.GetAllMovieRatings()).Returns(() => new List<MovieRating>());
            MovieRatingService movieRatingServiceEmpty = new MovieRatingService(mockReaderEmpty.Object);
            var result = movieRatingServiceEmpty.GetReviewerWhoReviewedMovie(1);

            Assert.Empty(result);
        }
    }
}
