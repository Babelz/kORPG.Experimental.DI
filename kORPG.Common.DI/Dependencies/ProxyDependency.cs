using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Dependencies
{
    public sealed class ProxyDependency : IDependency
    {
        #region Fields
        private readonly object value;
        private readonly Type type;
        #endregion

        public ProxyDependency(object value, Type type)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
            this.type  = type ?? throw new ArgumentNullException(nameof(type));
        }

        public T Cast<T>() 
            => (T)value;

        public bool Castable<T>() 
            => typeof(T) == type;

        public bool ReferenceEquals(object other) 
            => ReferenceEquals(value, other);
}
}
