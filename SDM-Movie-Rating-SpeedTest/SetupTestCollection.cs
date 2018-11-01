using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SDM_Movie_Rating_SpeedTest
{
    [CollectionDefinition("SpeedTest")]
    public class SetupTestCollection : ICollectionFixture<DisposableMovieRating>
    {
    }
}
