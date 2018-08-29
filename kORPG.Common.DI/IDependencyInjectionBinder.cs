using kORPG.Common.DI.Binding;
using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI
{
    public interface IDependencyInjectionBinder
    {
        void Bind(Type type, DependencyBindingOptions options);
        void Bind(Type type);

        void Bind<T>(DependencyBindingOptions options);
        void Bind<T>();

        void Bind(object instance, DependencyBindingOptions options);
        void Bind(object instance);

        void Proxy(Type actual, Type proxy, DependencyBindingOptions options);
        void Proxy(Type actual, Type proxy);

        void Proxy<T>(Type proxy, DependencyBindingOptions options);
        void Proxy<T>(Type proxy);
        
        void Proxy(object instance, Type proxy, DependencyBindingOptions options);
        void Proxy(object instance, Type proxy);

        void Proxy<T>(object instance, DependencyBindingOptions options);
        void Proxy<T>(object instance);
    }
}
