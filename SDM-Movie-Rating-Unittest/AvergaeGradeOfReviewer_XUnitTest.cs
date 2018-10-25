using Moq;
using SDM_Movie_Rating.Application;
using SDM_Movie_Rating.Application.Impl;
using SDM_Movie_Rating_Core_Entity;
using System.Collections.Generic;
using Xunit;

namespace SDM_Movie_Rating_Unittest
{
    public class AvergaeGradeOfReviewer_XUnitTest
    {
        //private Mock<> productsRepoMock = new Mock<IProductRepository>();

        [Fact]
        public void test()
        {
            IMovieRatingService movieService = new MovieRatingService();

            List<MovieRating> list = new List<MovieRating>();
            MovieRating i1 = new MovieRating
            {
                Reviewer = 1,
                Movie = 1,
                Grade = 2
            };
            MovieRating i2 = new MovieRating
            {
                Reviewer = 1,
                Movie = 2,
                Grade = 4
            };
            MovieRating i3 = new MovieRating
            {
                Reviewer = 1,
                Movie = 3,
                Grade = 5
            };
            list.Add(i1);
            list.Add(i2);
            list.Add(i3);

            double average = movieService.AverageGradeOfReviewer(1);

            
        }
    }
}
