using System;
using System.Collections.Generic;
using SDM_Movie_Rating_Core_Entity;

namespace SDM_Movie_Rating.Domain
{
    public interface IReader
    {
        IEnumerable<MovieRating> GetAllMovieRatings();
    }
}
