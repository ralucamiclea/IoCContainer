using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp
{
    public class Movie : IMovie
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public int Length { get; set; }
    }
}
