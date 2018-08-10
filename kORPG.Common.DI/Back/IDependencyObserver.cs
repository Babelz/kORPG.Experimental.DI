using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Back
{
    public interface IDependencyObserver
    {
        #region Events
        event DependencyLocatorEventHandler Added;
        event DependencyLocatorEventHandler Removed;
        #endregion
    }

    public delegate void DependencyLocatorEventHandler(IDependencyObserver sender, IDependency dependency);
}
