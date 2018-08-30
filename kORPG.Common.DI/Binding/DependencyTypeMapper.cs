using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace kORPG.Common.DI.Binding
{
    public sealed class DependencyTypeMapper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type[] Map(Type type, DependencyBindingOptions options)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var types = new List<Type>();

            if ((options & DependencyBindingOptions.Classes) == DependencyBindingOptions.Classes && type.IsClass)
            {
                var it = type;

                while (it != null && it != typeof(object))
                {
                    types.Add(it);

                    it = it.BaseType;
                }
            }
            else if ((options & DependencyBindingOptions.Class) == DependencyBindingOptions.Class && type.IsClass)
            {
                types.Add(type);
            }

            if ((options & DependencyBindingOptions.Interfaces) == DependencyBindingOptions.Interfaces)
            {
                if (type.IsInterface) types.Add(type);

                types.AddRange(type.GetInterfaces());
            }

            return types.ToArray();
        }
    }
}
