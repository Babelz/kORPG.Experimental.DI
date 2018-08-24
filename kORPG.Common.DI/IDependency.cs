using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI
{
    public interface IDependency
    {
        bool Castable<T>();

        bool ReferenceEquals(object other);

        T Cast<T>();
    }
}
