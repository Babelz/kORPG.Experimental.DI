using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Back
{
    public interface IDependencyLocator
    {
        IDependency Get(Predicate<IDependency> predicate);

        IEnumerable<IDependency> All(Predicate<IDependency> predicate);

        bool Exists(Predicate<IDependency> predicate);
    }
}
