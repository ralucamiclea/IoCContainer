using System;
using System.Collections.Generic;
using System.Text;

namespace HomemadeIoCController
{
    //creates singleton objects and returns them to the caller
    internal class AddSingletonInstance
    {
        static AddSingletonInstance instance = null;
        static Dictionary<string, object> objectPool = new Dictionary<string, object>();

        static AddSingletonInstance()
        {
            instance = new AddSingletonInstance();
        }

        private AddSingletonInstance()
        { }

        public static AddSingletonInstance GetInstance()
        {
            return instance;
        }

        public object GetSingleton(Type t, object[] arguments = null)
        {
            object obj = null;

            try
            {
                if (objectPool.ContainsKey(t.Name) == false)
                {
                    obj = AddTransientInstance.GetInstance().GetNewObject(t, arguments);
                    objectPool.Add(t.Name, obj);
                }
                else
                {
                    obj = objectPool[t.Name];
                }
            }
            catch
            {
                // log it maybe
            }

            return obj;
        }
    }
}
