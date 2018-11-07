using HomemadeIoCController;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace TestApp
{
    internal static class Program
    {
        public static void Main()
        {
            var config = GetConfig("config");
            IIoCContainer container = new IoCContainer();
            container.Config(config, typeof(Program).Assembly);

            //container.RegisterTransientType<ITestClass1, TestClass1>();
            //container.RegisterSingletonType<ITestClass2, TestClass2>();

            var obj = container.Resolve<ITestClass2>();
            obj.Method2();

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
