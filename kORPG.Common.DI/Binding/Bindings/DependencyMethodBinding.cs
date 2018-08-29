using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using kORPG.Common.DI.Attributes;

namespace kORPG.Common.DI.Binding.Bindings
{
    public sealed class DependencyMethodBinding : IDependencyBinding
    {
        #region Fields
        private readonly IDependencyInjectionLocator locator;
        #endregion

        public DependencyMethodBinding(IDependencyInjectionLocator locator)
            => this.locator = locator ?? throw new ArgumentNullException(nameof(locator));

        private bool CanBindToMethod(MethodInfo method)
        {
            var parameters = method.GetParameters();

            for (var i = 0; i < parameters.Length; i++)
                if (!locator.Exists(parameters[i].ParameterType)) return false;

            return true;
        }

        private void BindToMethod(object instance, MethodInfo method)
        {
            var parameters = method.GetParameters();
            var arguments  = new object[parameters.Length];

            for (var i = 0; i < parameters.Length; i++)
                arguments[i] = locator.Get(parameters[i].ParameterType);

            method.Invoke(instance, arguments);
        }
        
        public bool Bind(object instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            if (!DependencyBindingUtils.HasBindingMethods(instance.GetType()))
                throw new InvalidOperationException($"type {instance.GetType().Name} does not contain any methods annotated with {nameof(BindingMethodAttribute)}");

            var methods = instance.GetType()
                                  .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                                  .Where(p => p.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(BindingMethodAttribute)) != null)
                                  .ToArray();

            for (var i = 0; i < methods.Length; i++)
                if (!CanBindToMethod(methods[i])) return false;

            for (var i = 0; i < methods.Length; i++)
                BindToMethod(instance, methods[i]);

            return true;
        }
    }
}
