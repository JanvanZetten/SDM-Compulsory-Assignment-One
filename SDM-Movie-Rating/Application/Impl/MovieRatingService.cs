using System;
using System.Linq;
using System.Collections.Generic;
using SDM_Movie_Rating.Domain;
using SDM_Movie_Rating_Core_Entity;

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
            List<MovieRating> ratings = _Reader.GetAllMovieRatings().Where(m => m.Movie == movieId).ToList();

            double sum = 0;
            double count = 0.0;
            ratings.ForEach(r =>
            {
                if (r.Grade >= 1.0 && r.Grade <= 5.0)
                {
                    sum += r.Grade;
                    count++;
                }
            });
            
            if(count > 0)
            {
                return (sum / count);
            }
            else
            {
                throw new NullReferenceException("No grades for movie found!");
            }
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
            return _Reader.GetAllMovieRatings().Count(m => m.Reviewer == reviewerId && m.Grade == grade);
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
