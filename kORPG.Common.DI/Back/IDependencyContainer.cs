using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Back
{
    public interface IDependencyContainer
    {
        void Add(IDependency dependency);
        void Remove(IDependency dependency);
    }
}
