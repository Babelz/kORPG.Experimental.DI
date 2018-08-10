using kORPG.Common.DI.Back.Binders;
using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Back.Factories
{
    public interface ITypeBinderFactory
    {
        ITypeBinder Create(BindingOptions options);
    }
}
