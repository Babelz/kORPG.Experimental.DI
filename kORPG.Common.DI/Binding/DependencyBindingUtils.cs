using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using kORPG.Common.DI.Attributes;

namespace kORPG.Common.DI.Binding
{
    public static class DependencyBindingUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDefaultConstructor(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                       .FirstOrDefault(c => c.GetParameters()?.Length == 0) != null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasBindingConstructor(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                       .FirstOrDefault(c => c.GetCustomAttribute<BindingConstructorAttribute>() != null) != null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasBindingMethods(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            
            return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                       .FirstOrDefault(c => c.GetCustomAttribute<BindingMethodAttribute>() != null) != null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasBindingProperties(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                       .FirstOrDefault(c => c.GetCustomAttribute<BindingPropertyAttribute>() != null) != null;
        }
    }
}
