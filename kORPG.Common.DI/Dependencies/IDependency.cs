using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Dependencies
{
    public interface IDependency
    {
        bool Castable<T>();

        bool ReferenceEquals(object other);

        T Cast<T>();
    }
}
