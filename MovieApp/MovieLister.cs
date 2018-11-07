﻿using HomemadeIoCController;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp
{
    public class MovieLister : IMovieLister
    {
        private readonly IMovieFinder _finder;

        [NestedDependency]
        public MovieLister(IMovieFinder finder)
        {
            _finder = finder;
        }

        public void ListMoviesFromDirector(string director)
        {
            IEnumerable<IMovie> mList = director == null ? _finder.FindAll() : _finder.FindByDirector(director);
            foreach (var movie in mList)
            {
                Console.WriteLine(movie.Name + " by " + movie.Director);
            }
        }
    }
}

