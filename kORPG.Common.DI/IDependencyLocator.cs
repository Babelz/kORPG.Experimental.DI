using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI
{
    public interface IDependencyLocator
    {
        IEnumerable<object> All(Predicate<object> predicate);
        IEnumerable<object> All();

        IEnumerable<T> All<T>(Predicate<T> predicate);
        IEnumerable<T> All<T>();

        object Get(Type type, Predicate<object> predicate);
        object Get(Type type);

        T Get<T>(Predicate<T> predicate);
        T Get<T>();

        bool Exists(Type type, Predicate<object> predicate);
        bool Exists(Type type);

        bool Exists<T>(Predicate<T> prediacte);
        bool Exists<T>();
    }
}
