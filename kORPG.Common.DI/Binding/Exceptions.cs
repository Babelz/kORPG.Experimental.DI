using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Binding
{
    public sealed class DependencyBinderException : Exception
    {
        public DependencyBinderException(string message)
            : base(message)
        {
        }
    }
}
