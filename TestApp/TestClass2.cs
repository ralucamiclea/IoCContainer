using HomemadeIoCController;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class TestClass2 : ITestClass2
    {
        private readonly ITestClass1 _test1;

        [NestedDependency]
        public TestClass2(ITestClass1 test1)
        {
            _test1 = test1;
        }

        public void Method2()
        {
            Console.WriteLine("ClassName: {0}", this.GetType().Name);
            _test1.Method1();
        }
    }
}
