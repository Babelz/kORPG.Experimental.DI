using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Binding.Binders
{
    public interface IDependencyBinder
    {
        bool Bind(object instance);
    }
}
