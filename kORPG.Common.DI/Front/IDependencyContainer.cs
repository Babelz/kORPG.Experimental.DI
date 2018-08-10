using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Front
{
    public interface IDependencyContainer
    {
        void AutoBind(object value, BindingOptions options);
        void AutoBind(Type type, BindingOptions options);
        void ProxyBind(Type type, object value, BindingOptions options);

        IDependencyContainer Get<T>(out T value);
        IDependencyContainer Get<T>(out T value, Predicate<T> predicate);

        IDependencyContainer All<T>(out IEnumerable<T> value);
        IDependencyContainer All<T>(out IEnumerable<T> value, Predicate<T> predicate);

        T Get<T>();
        T Get<T>(Predicate<T> predicate);

        IEnumerable<T> All<T>();
        IEnumerable<T> All<T>(Predicate<T> predicate);
    }
}
