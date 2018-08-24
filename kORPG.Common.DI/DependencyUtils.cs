using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using kORPG.Common.DI.Attributes;
using System.Reflection;

namespace kORPG.Common.DI
{
    public static class DependencyUtils
    {
        public static Type[] GetTypes(Type type, DependencyBinderOptions options)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var types = new HashSet<Type>();

            if ((options & DependencyBinderOptions.Class) == DependencyBinderOptions.Class && type.IsClass)
                types.Add(type);

            if ((options & DependencyBinderOptions.Classes) == DependencyBinderOptions.Classes && type.IsClass)
            {
                var it = type;

                while (it != typeof(object) && it.IsClass) 
                {
                    types.Add(it);

                    it = it.BaseType;
                }
            }

            if ((options & DependencyBinderOptions.Interfaces) == DependencyBinderOptions.Interfaces)
            {
                var it = type;

                while (it != typeof(object))
                {
                    foreach (var iface in it.GetInterfaces())
                        types.Add(iface);

                    it = it.BaseType;
                }
            }

            return types.ToArray();
        }

        public static bool ConstructUsingInitializer(Type type, IDependencyLocator locator, out object value)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (locator == null)
                throw new ArgumentNullException(nameof(locator));

            value = null;

            var initializer = type.GetMethods()
                                  .FirstOrDefault(m => m.GetCustomAttribute<BindingMethodAttribute>() != null);

            if (initializer != null)
            {
                var parameters = initializer.GetParameters()
                                            .Select(t => t.ParameterType)
                                            .ToArray();

                var arguments = new object[parameters.Length];

                for (var i = 0; i < arguments.Length; i++)
                {
                    if (!locator.Exists(parameters[i])) return false;

                    arguments[i] = locator.Get(parameters[i]);
                }

                value = Activator.CreateInstance(type);

                initializer.Invoke(value, arguments);

                return true;
            }

            return false;
        }

        public static bool ConstructUsingProperties(Type type, IDependencyLocator locator, out object value)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (locator == null)
                throw new ArgumentNullException(nameof(locator));

            value = null;

            var properties = type.GetProperties(BindingFlags.SetProperty |
                                                BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.Static |
                                                BindingFlags.Instance)
                                 .Where(p => p.GetCustomAttributes<BindingPropertyAttribute>() != null)
                                 .ToArray();

            var tuples = new List<Tuple<PropertyInfo, object>>();

            foreach (var property in properties)
            {
                if (!locator.Exists(property.PropertyType)) return false;

                tuples.Add(new Tuple<PropertyInfo, object>(property, locator.Get(property.PropertyType)));
            }

            value = Activator.CreateInstance(type);

            foreach (var tuple in tuples)
            {
                var property   = tuple.Item1;
                var dependency = tuple.Item2;

                property.SetValue(value, dependency);
            }

            return true;
        }

        public static bool ConstructUsingConstructor(Type type, IDependencyLocator locator, out object value)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (locator == null)
                throw new ArgumentNullException(nameof(locator));
        }

        public static bool TryConstruct(Type type, IDependencyLocator locator, out object value)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (locator == null)
                throw new ArgumentNullException(nameof(locator));
        }
    }
}
