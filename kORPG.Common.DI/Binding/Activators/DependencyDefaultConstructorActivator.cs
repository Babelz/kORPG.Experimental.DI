using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace kORPG.Common.DI.Binding.Activators
{
    public sealed class DependencyDefaultConstructorActivator : IDependencyActivator
    {
        public DependencyDefaultConstructorActivator()
        {
        }

        public bool Activate(Type type, out object instance)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (!DependencyBindingUtils.HasDefaultConstructor(type))
                throw new InvalidOperationException("type does not have default constructor");

            var constructor = type.GetType()
                                  .GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                  .First(c => c.GetParameters()?.Length == 0);
            
            instance = constructor.Invoke(null);

            return true;
        }
    }
}
