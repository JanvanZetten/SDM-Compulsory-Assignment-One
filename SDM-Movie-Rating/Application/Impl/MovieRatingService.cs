using System;
using System.Collections.Generic;

namespace SDM_Movie_Rating.Application.Impl
{
    public class MovieRatingService: IMovieRatingService
    {

        public double AverageGradeOfMovie(int movieId)
        {
            throw new NotImplementedException();
        }

        public double AverageGradeOfReviewer(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public int CountMoviesWithGradeByReviewer(int reviewerId, int grade)
        {
            throw new NotImplementedException();
        }

        public int CountReviewersOfMovie(int movieId)
        {
            throw new NotImplementedException();
        }

        public int CountReviewsOfReviewer(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public int CountWhereMovieHasGrade(int movieId, int grade)
        {
            throw new NotImplementedException();
        }

        public List<int> GetMoviesReviewedByReviewer(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public List<int> GetMoviesWithAverageHighestGrade(int amount)
        {
            throw new NotImplementedException();
        }

        public List<int> GetMoviesWithMostGradesOfFive()
        {
            throw new NotImplementedException();
        }

        public List<int> GetReviewersWithMostReviewsDone()
        {
            throw new NotImplementedException();
        }

        public List<int> GetReviewerWhoReviewedMovie(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
