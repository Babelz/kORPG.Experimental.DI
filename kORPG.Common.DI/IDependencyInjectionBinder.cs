using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI
{
    public interface IDependencyInjectionBinder
    {
        void Bind(object value, Type proxy, DependencyInjectionOptions options);
        void Bind(object value, Type proxy);

        void Bind<T>(object value, DependencyInjectionOptions options);
        void Bind<T>(object value);

        void Bind(object value, DependencyInjectionOptions options);
        void Bind(object value);
    }
}
