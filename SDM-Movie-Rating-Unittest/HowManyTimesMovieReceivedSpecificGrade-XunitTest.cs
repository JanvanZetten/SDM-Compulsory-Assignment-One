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
    public class HowManyTimesMovieReceivedSpecificGrade_XunitTest
    {
        private List<MovieRating> list = new List<MovieRating>();
        private Mock<IReader> reader = new Mock<IReader>();

        MovieRating i1;
        MovieRating i2;
        MovieRating i3;
        MovieRating i4;


        public HowManyTimesMovieReceivedSpecificGrade_XunitTest()
        {
            i1 = new MovieRating
            {
                Reviewer = 1,
                Movie = 1,
                Grade = 1
            };
            i2 = new MovieRating
            {
                Reviewer = 10,
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

            reader.Setup(x => x.GetAllMovieRatings()).Returns(() => list);
        }

        [Fact]
        public void GetMoviesSpecificGradeCount()
        {
            IMovieRatingService movieService = new MovieRatingService(reader.Object);
            int grade = 1;
            int movieid = 1;

            int expectedAmount = 2;
            Assert.True(expectedAmount == movieService.CountWhereMovieHasGrade(movieid, grade));
        }

    }
}
