using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI
{
    public enum DependencyInjectionOptions : byte
    {
        None                   = 0,
        ConstructorInitializer = (1 << 0),
        PropertyInitializer    = (1 << 1),
        MethodInitializer      = (1 << 2),
        Proxy                  = (1 << 3),
        Class                  = (1 << 4),
        Classes                = (1 << 5),
        Interfaces             = (1 << 6),
        ClassAndInterfaces     = Class | Interfaces,
        ClassesAndInterfaces   = Class | Interfaces
    }
}
