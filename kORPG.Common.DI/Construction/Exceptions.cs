using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Construction
{
    public sealed class ProxyDependencyConstructorException : Exception
    {
        #region Properties
        public object Value
        {
            get;
        }

        public Type Proxy
        {
            get;
        }
        #endregion

        public ProxyDependencyConstructorException(object value, Type proxy)
            : base($"proxy for type {proxy.Name} not assignable from type {value.GetType().Name}")
        {
            Value = value;
            Proxy = proxy;
        }
    }
}
