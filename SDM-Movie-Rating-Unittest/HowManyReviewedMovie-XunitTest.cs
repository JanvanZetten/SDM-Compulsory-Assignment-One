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
    public class HowManyReviewedMovie
    {
        private List<MovieRating> list = new List<MovieRating>();
        private Mock<IReader> reader = new Mock<IReader>();

        MovieRating i1;
        MovieRating i2;
        MovieRating i3;


       public HowManyReviewedMovie()
       {
            i1 = new MovieRating
            {
                Reviewer = 1,
                Movie = 1,
                Grade = 2
            };
            i2 = new MovieRating
            {
                Reviewer = 10,
                Movie = 2,
                Grade = 4
            };
            i3 = new MovieRating
            {
                Reviewer = 11,
                Movie = 2,
                Grade = 5
            };
            list.Add(i1);
            list.Add(i2);
            list.Add(i3);

            reader.Setup(x => x.GetAllMovieRatings()).Returns(() => list);
        }

        [Fact]
        public void GetCountReviewedMovie()
        {
            IMovieRatingService movieService = new MovieRatingService(reader.Object);

            int id = 2;

            int count = movieService.CountReviewersOfMovie(id);
            Assert.True(count == 2);

        }
        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-30)]
        public void AssertThrowsExceptionOnInvalidID(int id)
        {
            IMovieRatingService movieService = new MovieRatingService(reader.Object);

            try
            {
                movieService.CountReviewersOfMovie(id);
                Assert.True(false);
            }
            catch (ArgumentException)
            {
                
            }

         }

    }
}
