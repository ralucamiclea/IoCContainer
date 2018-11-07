using System;
using System.Collections.Generic;
using System.Text;

namespace HomemadeIoCController
{
    //type lifetime options
    internal enum REG_TYPE
    {
        TRANSIENT,
        SINGLETON
    };

    //keeps track of concrete type and lifetime
    internal class RegistrationModel
    {
        internal Type ObjectType { get; set; }
        internal REG_TYPE RegType { get; set; }
    }
}
