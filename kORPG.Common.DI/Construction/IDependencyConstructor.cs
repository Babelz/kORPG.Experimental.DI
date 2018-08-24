using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Construction
{
    public interface IDependencyConstructor
    {
        bool Construct(out IDependency dependency);
    }
}
