using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using kORPG.Common.DI.Attributes;

namespace kORPG.Common.DI.Binding.Activators
{
    public sealed class DependencyBindingConstructorActivator : IDependencyActivator
    {
        #region Fields
        private readonly IDependencyInjectionLocator locator;
        #endregion

        public DependencyBindingConstructorActivator(IDependencyInjectionLocator locator)
            => this.locator = locator ?? throw new ArgumentNullException(nameof(locator));

        public bool Activate(Type type, out object instance)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (!DependencyBindingUtils.HasBindingConstructor(type))
                throw new InvalidOperationException($"type {type.Name} does not contain constructor annotated with {nameof(BindingConstructorAttribute)}");

            var constructor = type.GetConstructors()
                                  .First(c => c.GetCustomAttribute<BindingConstructorAttribute>() != null);
            
            var parameters = constructor.GetParameters();
            var arguments  = new object[parameters.Length];

            instance = null;

            for (var i = 0; i < parameters.Length; i++)
            {
                if (!locator.Exists(parameters[i].ParameterType)) return false;

                arguments[i] = locator.Get(parameters[i].ParameterType);
            }

            instance = constructor.Invoke(arguments);

            return false;
        }
    }
}
