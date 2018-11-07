using System.Collections.Generic;

namespace MovieApp
{
    public interface IMovieFinder
    {
        IEnumerable<IMovie> FindByDirector(string director);
        IEnumerable<IMovie> FindAll();
    }
}