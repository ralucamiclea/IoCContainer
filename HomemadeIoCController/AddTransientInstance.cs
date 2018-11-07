using System;
using System.Collections.Generic;
using System.Text;

namespace HomemadeIoCController
{
    //always creates a new instance of the object and returns it to the caller
    internal class AddTransientInstance
    {
        static AddTransientInstance instance = null;

        static AddTransientInstance()
        {
            instance = new AddTransientInstance();
        }

        private AddTransientInstance()
        { }

        public static AddTransientInstance GetInstance()
        {
            return instance;
        }

        public object GetNewObject(Type t, object[] arguments = null)
        {
            object obj = null;

            try
            {
                obj = Activator.CreateInstance(t, arguments);
            }
            catch
            {
                // log it maybe
            }

            return obj;
        }
    }
}
