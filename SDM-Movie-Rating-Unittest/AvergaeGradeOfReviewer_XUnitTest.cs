using Moq;
using SDM_Movie_Rating.Application;
using SDM_Movie_Rating.Application.Impl;
using SDM_Movie_Rating.Domain;
using SDM_Movie_Rating_Core_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SDM_Movie_Rating_Unittest
{
    public class AvergaeGradeOfReviewer_XUnitTest
    {
        List<MovieRating> list = new List<MovieRating>();
        private Mock<IReader> reader = new Mock<IReader>();
        MovieRating i1;
        MovieRating i2;
        MovieRating i3;

        public AvergaeGradeOfReviewer_XUnitTest()
        {
            i1 = new MovieRating
            {
                Reviewer = 1,
                Movie = 1,
                Grade = 2
            };
            i2 = new MovieRating
            {
                Reviewer = 1,
                Movie = 2,
                Grade = 4
            };
            i3 = new MovieRating
            {
                Reviewer = 1,
                Movie = 3,
                Grade = 5
            };
            list.Add(i1);
            list.Add(i2);
            list.Add(i3);

            reader.Setup(x => x.GetAllMovieRatings()).Returns(() => list);
        }

        [Fact]
        public void AssertAverageGradeIsCorrect()
        {
            IMovieRatingService movieService = new MovieRatingService(reader.Object);

            double average = movieService.AverageGradeOfReviewer(1);
            double average2 = (i1.Grade + i2.Grade + i3.Grade) / list.Count();
            Assert.True(average2 == average);
        }
    }
}
