using System;
using System.Collections.Generic;
using Moq;
using SDM_Movie_Rating.Application;
using SDM_Movie_Rating.Application.Impl;
using SDM_Movie_Rating.Domain;
using SDM_Movie_Rating_Core_Entity;
using Xunit;

namespace SDM_Movie_Rating_Unittest
{
    public class GetMoviesWithMostGradesOfFive_XUnitTest
    {

        private Mock<IReader> mockReader = new Mock<IReader>();
        private int MovieOne = 1;
        private int MovieTwo = 2;
        private int MovieThree = 3;
        private int MovieFour = 4;

        private readonly int gradeFive = 5;
        private readonly int notGradeFive = 4;

        IMovieRatingService movieRatingService;


        [Fact]
        public void GetMoviesWithMostGradesOfFiveValidTestSingleMovie(){
            //setup
            mockReader.Setup(x => x.GetAllMovieRatings()).Returns(() => new List<MovieRating>() {
                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieOne,
                    Date = DateTime.Now,
                    Grade = gradeFive
                },
                new MovieRating(){
                    Reviewer = 2,
                    Movie = MovieOne,
                    Date = DateTime.Now,
                    Grade = gradeFive
                },

                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieTwo,
                    Date = DateTime.Now,
                    Grade = notGradeFive

                },
                new MovieRating(){
                    Reviewer = 2,
                    Movie = MovieTwo,
                    Date = DateTime.Now,
                    Grade = gradeFive

                },

                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieThree,
                    Date = DateTime.Now,
                    Grade = notGradeFive

                }
            });

            movieRatingService = new MovieRatingService(mockReader.Object);

            //Test

            var result = movieRatingService.GetMoviesWithMostGradesOfFive();
            
            Assert.Single(result);
            Assert.Equal(MovieOne, result[0]);
        }


        [Fact]
        public void GetMoviesWithMostGradesOfFiveValidTestMultipleMovies()
        {
            //setup
            mockReader.Setup(x => x.GetAllMovieRatings()).Returns(() => new List<MovieRating>() {
                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieOne,
                    Date = DateTime.Now,
                    Grade = gradeFive
                },
                new MovieRating(){
                    Reviewer = 2,
                    Movie = MovieOne,
                    Date = DateTime.Now,
                    Grade = gradeFive
                },

                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieTwo,
                    Date = DateTime.Now,
                    Grade = gradeFive

                },
                new MovieRating(){
                    Reviewer = 2,
                    Movie = MovieTwo,
                    Date = DateTime.Now,
                    Grade = gradeFive

                },
                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieThree,
                    Date = DateTime.Now,
                    Grade = notGradeFive
                },
                new MovieRating(){
                    Reviewer = 2,
                    Movie = MovieFour,
                    Date = DateTime.Now,
                    Grade = gradeFive
                },

                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieFour,
                    Date = DateTime.Now,
                    Grade = gradeFive

                }


            });

            movieRatingService = new MovieRatingService(mockReader.Object);

            //Test

            var result = movieRatingService.GetMoviesWithMostGradesOfFive();

            Assert.Equal(3, result.Count);
            Assert.Equal(MovieOne, result[0]);
            Assert.Equal(MovieTwo, result[1]);
            Assert.Equal(MovieFour, result[2]);
        }



        [Fact]
        public void GetMoviesWithMostGradesOfFiveNoMoviesWithFive()
        {
            //setup
            mockReader.Setup(x => x.GetAllMovieRatings()).Returns(() => new List<MovieRating>() {
                new MovieRating(){
                    Reviewer = 1,
                    Movie = MovieOne,
                    Date = DateTime.Now,
                    Grade = notGradeFive
                },
                new MovieRating(){
                    Reviewer = 2,
                    Movie = MovieOne,
                    Date = DateTime.Now,
                    Grade = notGradeFive
                }


            });

            movieRatingService = new MovieRatingService(mockReader.Object);

            //Test

            var result = movieRatingService.GetMoviesWithMostGradesOfFive();

            Assert.Empty(result);
        }
    }
}
