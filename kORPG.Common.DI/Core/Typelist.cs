using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Core
{
    public sealed class Typelist
    {
        #region Fields
        private readonly HashSet<Type> types;
        #endregion

        public Typelist(Type[] types)
            => this.types = types != null ? new HashSet<Type>(types) : throw new ArgumentNullException(nameof(types));

        public bool Contains(Type type) 
            => type != null ? types.Contains(type) : throw new ArgumentNullException(nameof(type));

        public bool Contains<T>() 
            => types.Contains(typeof(T));

        public bool Equals(Typelist other)
        {
            throw new NotImplementedException();
        }

        public sealed override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public sealed override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Typelist lhs, Typelist rhs)
        {
            throw new NotImplementedException();
        }
        public static bool operator !=(Typelist lhs, Typelist rhs)
        {
            throw new NotImplementedException();
        }
    }
}
