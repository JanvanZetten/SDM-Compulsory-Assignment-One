using System;
using System.Collections.Generic;

namespace SDM_Movie_Rating.Application
{
    public interface IMovieRatingService
    {
        int CountReviewsOfReviewer(int reviewerId);
        double AverageGradeOfReviewer(int reviewerId);
        int CountMoviesWithGradeByReviewer(int reviewerId, int grade);
        int CountReviewersOfMovie(int movieId);
        double AverageGradeOfMovie(int movieId);
        int CountWhereMovieHasGrade(int movieId, int grade);
        List<int> GetMoviesWithMostGradesOfFive();
        List<int> GetReviewersWithMostReviewsDone();
        List<int> GetMoviesWithAverageHighestGrade(int amount);
        List<int> GetMoviesReviewedByReviewer(int reviewerId);
        List<int> GetReviewerWhoReviewedMovie(int movieId);
    }
}
