using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI
{
    public sealed class Dependency 
    {
        #region Fields
        private readonly HashSet<Type> types;
        private readonly object value;
        #endregion

        public Dependency(object value, Type[] types)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));

            if (types == null || types.Length == 0)
                throw new ArgumentNullException(nameof(types));

            this.types = new HashSet<Type>(types);
        }

        public T Cast<T>()
            => (T)value;
        
        public bool Castable<T>()
            => Castable(typeof(T));

        public bool Castable(Type type)
            => types.Contains(type);

        public bool ReferenceEquals(object other)
            => ReferenceEquals(value, other);
}
}
