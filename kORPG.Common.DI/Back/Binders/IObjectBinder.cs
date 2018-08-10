using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Back.Binders
{
    public interface IObjectBinder
    {
        #region Events
        event ObjectBinderEventHandler Constructed;
        #endregion

        void Construct(IDependencyObserver observer, IDependencyLocator locator);
    }

    public delegate void ObjectBinderEventHandler(IObjectBinder sender, object value);
}
