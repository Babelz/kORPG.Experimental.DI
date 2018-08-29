using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI
{
    public sealed class DependencyNotFoundException : Exception
    {
        public DependencyNotFoundException(Type type)
            : base($"dependency of type {type.Name} was not found")
        {
        }
    }

    public sealed class DependencyBinderException : Exception
    {
        public DependencyBinderException(string message)
            : base(message)
        {
        }
    }
}
