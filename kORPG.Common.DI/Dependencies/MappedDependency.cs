using kORPG.Common.DI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Dependencies
{
    public sealed class MappedDependency : IDependency
    {
        #region Fields
        private readonly Typelist typelist;
        private readonly object value;
        #endregion

        public MappedDependency(object value, Type[] types)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));

            typelist = types != null ? new Typelist(types) : throw new ArgumentNullException(nameof(types));
        }

        public T Cast<T>() 
            => (T)value;

        public bool Castable<T>()
            => typelist.Contains(typeof(T));

        public bool ReferenceEquals(object other)
            => ReferenceEquals(value, other);
}
}
