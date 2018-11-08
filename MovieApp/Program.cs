using HomemadeIoCController;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace MovieApp
{
    internal static class Program
    {
        public static void Main()
        {
            var config = GetConfig("config");
            IIoCContainer container = new IoCContainer();
            container.Config(config, typeof(Program).Assembly);

            //container.RegisterTransientType<IMovieFinder, MovieFinderTxt>();
            //container.RegisterTransientType<IMovieFinder, MovieFinderJson>();
            //container.RegisterSingletonType<IMovieLister, MovieLister>();

            var obj = container.Resolve<IMovieLister>();
            obj.ListMoviesFromDirector("Director1");

            Console.ReadKey();
        }

        public static JObject GetConfig(string taxReturnName)
        {
            using (StreamReader r = new StreamReader($"{taxReturnName}.json"))
            {
                string json = r.ReadToEnd();
                return JObject.Parse(json);
            }
        }
    }
}
