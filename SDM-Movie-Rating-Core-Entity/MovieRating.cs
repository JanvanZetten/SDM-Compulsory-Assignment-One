using System;

namespace SDM_Movie_Rating_Core_Entity
{
    public class MovieRating
    {
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public double Grade { get; set; }
        public DateTime Date { get; set; }
    }
}
