using HomemadeIoCController;
using System;

namespace MovieApp
{
    internal static class Program
    {
        public static void Main()
        {
            IIoCContainer container = new IoCContainer();

            container.RegisterTransientType<IMovieFinder, MovieFinderTxt>();
            //container.RegisterTransientType<IMovieFinder, MovieFinderJson>();
            container.RegisterSingletonType<IMovieLister, MovieLister>();

            var obj = container.Resolve<IMovieLister>();
            obj.ListMoviesFromDirector("Director1");

            Console.ReadKey();
        }
    }
}
