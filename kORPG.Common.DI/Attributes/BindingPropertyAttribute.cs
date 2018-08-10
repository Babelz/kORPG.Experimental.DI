using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class BindingPropertyAttribute : Attribute
    {
        private BindingPropertyAttribute()
            : base()
        {
        }
    }
}
