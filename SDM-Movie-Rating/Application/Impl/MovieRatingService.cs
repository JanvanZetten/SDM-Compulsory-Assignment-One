﻿using System;
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
            if(movieId < 0)
            {
                throw new ArgumentException("May not be under 0");
            }
            return _Reader.GetAllMovieRatings().Count(m => m.Movie == movieId);
        }

        public int CountReviewsOfReviewer(int reviewerId)
        {
            return _Reader.GetAllMovieRatings().Count(m => m.Reviewer == reviewerId);
        }

        public int CountWhereMovieHasGrade(int movieId, int grade)
        {
            int count = 0;
            foreach(var item in _Reader.GetAllMovieRatings())
            {
                if(item.Movie == movieId && item.Grade == grade)
                {
                    count++;
                }
            }
            return count;
        }

        public List<int> GetMoviesReviewedByReviewer(int reviewerId)
        {
            List<MovieRating> list = _Reader.GetAllMovieRatings().Where(r => r.Reviewer.Equals(reviewerId)).ToList();

            List<MovieRating> SortedList = list.OrderByDescending(g => g.Grade).ThenByDescending(d => d.Date).ToList();

            List<int> MovieIdList = new List<int>();

            foreach (var item in SortedList)
            {
                MovieIdList.Add(item.Movie);
            }

            return MovieIdList;
            
        }

        public List<int> GetMoviesWithAverageHighestGrade(int amount)
        {
            if(amount < 1)
            {
                throw new ArgumentException("Amount cannot be less than 1!");
            }

            var GradeFiveItems = _Reader.GetAllMovieRatings().ToList();


            if (GradeFiveItems == null || GradeFiveItems.Count == 0)
            {
                return new List<int>();
            }

            var MoviesAndSums = new Dictionary<int, double[]>();

            foreach (var movieItem in GradeFiveItems)
            {
                if (MoviesAndSums.ContainsKey(movieItem.Movie))
                {
                    MoviesAndSums[movieItem.Movie][0] += movieItem.Grade;
                    MoviesAndSums[movieItem.Movie][1]++;
                }
                else
                {
                    MoviesAndSums.Add(movieItem.Movie, new double[] { movieItem.Grade, 1});
                }
            }

            var MoviesAndAverage = new Dictionary<int, double>();

            foreach (var movieAndSum in MoviesAndSums)
            {
                MoviesAndAverage.Add(movieAndSum.Key, movieAndSum.Value[0] / movieAndSum.Value[1]);
            }
            
            return MoviesAndAverage.OrderByDescending(m => m.Value).Select(m => m.Key).Take(amount).ToList();
        }

        public List<int> GetMoviesWithMostGradesOfFive()
        {
            var GradeFiveItems = _Reader.GetAllMovieRatings().Where(m => m.Grade.Equals(5)).ToList();


            if (GradeFiveItems == null || GradeFiveItems.Count == 0){
                return new List<int>();
            }

            var GradeFiveNumberOnMovie = new Dictionary<int, int>();

            foreach (var movieItem in GradeFiveItems)
            {
                if (GradeFiveNumberOnMovie.ContainsKey(movieItem.Movie)){
                    GradeFiveNumberOnMovie[movieItem.Movie]++;
                }
                else
                {
                    GradeFiveNumberOnMovie.Add(movieItem.Movie, 1);
                }
            }

            var MovieWithHighestNumber = new List<int>();
            int higestNumber = 0;

            foreach (var movie in GradeFiveNumberOnMovie)
            {

                if (movie.Value > higestNumber){
                    higestNumber = movie.Value;
                    MovieWithHighestNumber.Clear();
                    MovieWithHighestNumber.Add(movie.Key);
                } else if (movie.Value == higestNumber)
                {
                    MovieWithHighestNumber.Add(movie.Key);
                }
            }

            return MovieWithHighestNumber;

        }

        public List<int> GetReviewersWithMostReviewsDone()
        {
            //Old solution
            /**int count = 0;
            int highestNumberOfReviews = 0;
            int reviewerId = 0;
            MovieRating movie = null;
            for(int i = 0; i<_Reader.GetAllMovieRatings().Count(); i++)
            {
                count = 1;
                reviewerId = _Reader.GetAllMovieRatings().ToList()[i].Reviewer;
           

                for(int y = 0; y<_Reader.GetAllMovieRatings().Count(); y++)
                {
                    if(_Reader.GetAllMovieRatings().ToList()[y].Reviewer == reviewerId)
                    {
                        count++;
                    }
                }
                if(highestNumberOfReviews < count)
                {
                    highestNumberOfReviews = count;
                    movie = _Reader.GetAllMovieRatings().ToList()[i];
                }
            }
            List<int> reviewer = new List<int>();
            reviewer.Add(movie.Reviewer);
            return reviewer;**/
            
            //New solution
            List<int> HighestReviewerId = new List<int>();
            Dictionary<int, int> reviews = new Dictionary<int, int>();

            foreach (var item in _Reader.GetAllMovieRatings())
            {
                if (reviews.ContainsKey(item.Reviewer))
                {
                    reviews[item.Reviewer]++;
                }
                else
                {
                    reviews.Add(item.Reviewer, 1);
                }
            }

            int HighestValueReferenceKey = reviews.FirstOrDefault(x => x.Value == reviews.Values.Max()).Value;

            foreach (KeyValuePair<int, int> item in reviews)
            {
                if (item.Value == HighestValueReferenceKey)
                {
                     HighestReviewerId.Add(item.Key);
                }
            }

            return HighestReviewerId;

        }

        public List<int> GetReviewerWhoReviewedMovie(int movieId)
        {

            return _Reader.GetAllMovieRatings()
                          .Where(m => m.Movie == movieId)
                          .OrderByDescending(m => m.Grade)
                          .ThenByDescending(m => m.Date)
                          .Select(m => m.Reviewer)
                          .ToList();
        }
    }
}
