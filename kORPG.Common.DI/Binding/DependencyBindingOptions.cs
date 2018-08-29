using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Binding
{
    public enum DependencyBindingOptions : byte
    {
        None                   = 0,
        Class                  = (1 << 1),
        Classes                = (1 << 2),
        Interfaces             = (1 << 3),
        ClassAndInterfaces     = Class | Interfaces,
        ClassesAndInterfaces   = Class | Interfaces
    }
}
