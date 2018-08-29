using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Binding.Bindings
{
    public interface IDependencyBinding
    {
        bool Bind(object instance);
    }
}
