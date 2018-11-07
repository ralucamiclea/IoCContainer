using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HomemadeIoCController
{
    public class IoCContainer : IIoCContainer
    {
        // registered interfaces with concrete types
        Dictionary<Type, RegistrationModel> _registeredInstances = new Dictionary<Type, RegistrationModel>();

        public void RegisterTransientType<I, C>()
            where I : class
            where C : class
        {
            RegisterType<I, C>(REG_TYPE.TRANSIENT);
        }

        public void RegisterSingletonType<I, C>()
            where I : class
            where C : class
        {
            RegisterType<I, C>(REG_TYPE.SINGLETON);
        }

        public I Resolve<I>()
        {
            return (I)Resolve(typeof(I));
        }

        // register interface with concrete type
        private void RegisterType<I, C>(REG_TYPE type)
        {
            // check if interface already registered
            if (_registeredInstances.ContainsKey(typeof(I)) == true)
            {
                _registeredInstances.Remove(typeof(I));
            }

            // register interface with concrete type
            _registeredInstances.Add(
                typeof(I),
                    new RegistrationModel
                    {
                        RegType = type,
                        ObjectType = typeof(C)
                    }
                );
        }


        // retrieve concrete type for the interface
        private object Resolve(Type t)
        {
            object obj = null;

            if (_registeredInstances.ContainsKey(t) == true)
            {
                RegistrationModel model = _registeredInstances[t];

                if (model != null)
                {
                    Type typeToCreate = model.ObjectType;
                    ConstructorInfo[] constructors = typeToCreate.GetConstructors();

                    var dependentCtor = constructors.FirstOrDefault(
                        item => item.CustomAttributes.FirstOrDefault(
                            att => att.AttributeType == typeof(NestedDependency)) != null);


                    if (dependentCtor == null)
                    {
                        // use the default constructor to create
                        obj = CreateInstance(model);
                    }
                    else
                    {
                        ParameterInfo[] parameters = dependentCtor.GetParameters();

                        if (parameters.Count() == 0)
                        {
                            // no parameters so the default constructor can be used
                            obj = CreateInstance(model);
                        }
                        else
                        {
                            // create dependencies and pass them in the constructor
                            List<object> arguments = new List<object>();

                            foreach (var param in parameters)
                            {
                                Type type = param.ParameterType;
                                arguments.Add(this.Resolve(type));
                            }

                            obj = CreateInstance(model, arguments.ToArray());
                        }
                    }
                }
            }

            return obj;
        }

        private object CreateInstance(RegistrationModel model, object[] arguments = null)
        {
            object returnedObj = null;
            Type typeToCreate = model.ObjectType;

            if (model.RegType == REG_TYPE.TRANSIENT)
            {
                returnedObj = AddTransientInstance.GetInstance().GetNewObject(typeToCreate, arguments);
            }
            else if (model.RegType == REG_TYPE.SINGLETON)
            {
                returnedObj = AddSingletonInstance.GetInstance().GetSingleton(typeToCreate, arguments);
            }

            return returnedObj;
        }
    }
}

