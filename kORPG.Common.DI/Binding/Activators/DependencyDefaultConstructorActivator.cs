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

            try
            {
                instance = Activator.CreateInstance(type);
            }
            catch
            {
                throw new DependencyBinderException($"could not create instance of {type.Name} using default parameterless constructor, please check that the " +
                                                     "type has a public parameterless default constructor available");
            }

            return true;
        }
    }
}
