using HomemadeIoCController;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class TestClass1 : ITestClass1
    {
        public void Method1()
        {
            Console.WriteLine("ClassName: {0}", this.GetType().Name);
        }
    }
}
