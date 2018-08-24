using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI
{
    public interface IDependencyBinder
    {
        void Bind(object value, Type proxy, DependencyBinderOptions options);
        void Bind(object value, Type proxy);

        void Bind<T>(object value, DependencyBinderOptions options);
        void Bind<T>(object value);

        void Bind(object value, DependencyBinderOptions options);
        void Bind(object value);
    }
}
