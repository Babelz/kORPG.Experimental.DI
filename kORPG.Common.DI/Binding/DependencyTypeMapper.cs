using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Binding
{
    public sealed class DependencyTypeMapper
    {
        public static Type[] Map(Type type, DependencyBindingOptions options)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var types = new List<Type>();

            if ((options & DependencyBindingOptions.Classes) == DependencyBindingOptions.Classes)
            {

            }
            else if ((options & DependencyBindingOptions.Class) == DependencyBindingOptions.Class)
            {
            }

            if ((options & DependencyBindingOptions.Interfaces) == DependencyBindingOptions.Interfaces)
                types.AddRange(type.GetInterfaces());

            return types.ToArray();
        }
    }
}
