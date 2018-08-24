using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI
{
    public sealed class ObjectDependency : IDependency
    {
        #region Fields
        private readonly Typelist typelist;
        private readonly object value;
        #endregion

        public ObjectDependency(object value, Type[] types)
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
