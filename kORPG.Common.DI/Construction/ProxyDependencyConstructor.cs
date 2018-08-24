using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Construction
{
    public sealed class ProxyDependencyConstructor : IDependencyConstructor
    {
        #region Fields
        private readonly object value;
        private readonly Type proxy;
        #endregion

        public ProxyDependencyConstructor(object value, Type proxy)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
            this.proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }

        public bool Construct(out IDependency dependency)
        {
            if (!proxy.IsAssignableFrom(value.GetType()))
                throw new ProxyDependencyConstructorException(value, proxy);

            dependency = new ProxyDependency(value, proxy);

            return true;
        }
    }
}
