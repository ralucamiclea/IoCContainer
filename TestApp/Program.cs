using HomemadeIoCController;
using System;

namespace TestApp
{
    internal static class Program
    {
        public static void Main()
        {
            IIoCContainer container = new IoCContainer();

            container.RegisterTransientType<ITestClass1, TestClass1>();
            container.RegisterSingletonType<ITestClass2, TestClass2>();

            var obj = container.Resolve<ITestClass2>();
            obj.Method2();

            Console.ReadKey();
        }
    }
}
