using System;
using System.Collections.Generic;
using System.Text;

namespace HomemadeIoCController
{
    public interface IIoCContainer
    {
        void RegisterTransientType<I, C>()
            where I : class
            where C : class;

        void RegisterSingletonType<I, C>()
            where I : class
            where C : class;

        T Resolve<T>();
    }
}