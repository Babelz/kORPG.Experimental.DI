using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public sealed class BindingConstructorAttribute : Attribute
    {
        private BindingConstructorAttribute()
            : base()
        {
        }
    }
}
