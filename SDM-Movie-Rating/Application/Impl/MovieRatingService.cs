using System;
using System.Linq;
using System.Collections.Generic;
using SDM_Movie_Rating.Domain;

namespace SDM_Movie_Rating.Application.Impl
{
    public class MovieRatingService: IMovieRatingService
    {
        private IReader _Reader;
        public MovieRatingService(IReader reader)
        {
            _Reader = reader;
        }

        public double AverageGradeOfMovie(int movieId)
        {
            throw new NotImplementedException();
        }

        public double AverageGradeOfReviewer(int reviewerId)
        {
            double CombinedRatings = 0;
            double AmountOfRatings = 0;

            foreach (var item in _Reader.GetAllMovieRatings())
            {
                if (item.Reviewer == reviewerId)
                {
                    CombinedRatings += item.Grade;
                    AmountOfRatings++;
                }
            }

            return CombinedRatings / AmountOfRatings;
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
            return _Reader.GetAllMovieRatings().Count(m => m.Reviewer == reviewerId);
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
