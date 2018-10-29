using Moq;
using SDM_Movie_Rating.Application;
using SDM_Movie_Rating.Application.Impl;
using SDM_Movie_Rating.Domain;
using SDM_Movie_Rating_Core_Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SDM_Movie_Rating_Unittest
{
    public class WhichReviewersMostReviews_XunitTest
    {
        private List<MovieRating> list;
        private Mock<IReader> reader = new Mock<IReader>();

        MovieRating i1;
        MovieRating i2;
        MovieRating i3;
        MovieRating i4;

        public WhichReviewersMostReviews_XunitTest()
        {
            reader.Setup(x => x.GetAllMovieRatings()).Returns(() => list);
        }
        [Fact]
        public void GetReviewersWithMostReviews()
        {
            list = new List<MovieRating>();

            i1 = new MovieRating
            {
                Reviewer = 10,
                Movie = 1,
                Grade = 1
            };
            i2 = new MovieRating
            {
                Reviewer = 11,
                Movie = 1,
                Grade = 1
            };
            i3 = new MovieRating
            {
                Reviewer = 11,
                Movie = 2,
                Grade = 5
            };
            i4 = new MovieRating
            {
                Reviewer = 12,
                Movie = 1,
                Grade = 2
            };
            list.Add(i1);
            list.Add(i2);
            list.Add(i3);
            list.Add(i4);

            IMovieRatingService movieRating = new MovieRatingService(reader.Object);

        }

        [Fact]
        public void GetReviewersWithMostReviewsWithOneResult()
        {
             list = new List<MovieRating>();

            i1 = new MovieRating
            {
                Reviewer = 10,
                Movie = 1,
                Grade = 1
            };
            i2 = new MovieRating
            {
                Reviewer = 11,
                Movie = 1,
                Grade = 1
            };
            i3 = new MovieRating
            {
                Reviewer = 12,
                Movie = 2,
                Grade = 5
            };
            i4 = new MovieRating
            {
                Reviewer = 12,
                Movie = 1,
                Grade = 2
            };
            list.Add(i1);
            list.Add(i2);
            list.Add(i3);
            list.Add(i4);

            IMovieRatingService movieRating = new MovieRatingService(reader.Object);
            List<int> reviewerId = new List<int>();
            int expected = 12;

            Assert.True(expected == movieRating.GetReviewersWithMostReviewsDone()[0]);
      
        }
    }
}
