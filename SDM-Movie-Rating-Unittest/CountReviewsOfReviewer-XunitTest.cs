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
    public class CountReviewsOfReviewer_XunitTest
    {
        private Mock<IReader> mockReader = new Mock<IReader>();



        [Fact]
        public void CountReviewsOfReviewerValidTest()
        {
            //Setup
            var ReviewerOne = 1;
            var ReviewerTwo = 2;


            mockReader.Setup(x => x.GetAllMovieRatings()).Returns(() => new List<MovieRating>() {
                new MovieRating(){
                    Reviewer = ReviewerOne,
                    Movie = 1,
                    Date = DateTime.Now,
                    Grade = 5
                },

                new MovieRating(){
                    Reviewer = ReviewerOne,
                    Movie = 2,
                    Date = DateTime.Now,
                    Grade = 5
                },

                new MovieRating(){
                    Reviewer = ReviewerTwo,
                    Movie = 1,
                    Date = DateTime.Now,
                    Grade = 5
                }
            });
            IMovieRatingService movieRatingService = new MovieRatingService(mockReader.Object);

            //Test
            var result = movieRatingService.CountReviewsOfReviewer(ReviewerOne);

            Assert.Equal(2, result); // the reviewer one has two reviews

            result = movieRatingService.CountReviewsOfReviewer(ReviewerTwo);

            Assert.Equal(1, result); // the reviewer one has one reviews

        }
    }
}
