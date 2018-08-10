using kORPG.Common.DI.Back.Binders;
using kORPG.Common.DI.Front;
using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Back.Factories
{
    public interface IObjectBinderFactory
    {
        IObjectBinder Create(BindingOptions options);
    }
}
