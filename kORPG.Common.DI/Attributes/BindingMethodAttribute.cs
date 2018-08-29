using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class BindingMethodAttribute : Attribute
    {
        public BindingMethodAttribute()
            : base()
        {
        }
    }
}
