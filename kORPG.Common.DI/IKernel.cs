using kORPG.Common.DI.Binding;
using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI
{
    public interface IKernel : IDependencyInjectionBinder, IDependencyInjectionLocator 
    {
        #region Properties
        DependencyBindingOptions BindingOptions
        {
            get;
            set;
        }

        DependencyBindingOptions ProxyBindingOptions
        {
            get;
            set;
        }
        #endregion
    }
}
