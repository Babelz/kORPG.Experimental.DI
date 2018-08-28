using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Binding.Activators
{
    public interface IDependencyActivator
    {
        bool Activate(Type type, out object instance);
    }
}
