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

            var constructor = type.GetType()
                                  .GetConstructor(Type.EmptyTypes);

            if (constructor == null)
                throw new InvalidOperationException("type does not have default constructor");

            instance = constructor.Invoke(null);

            return true;
        }
    }
}
