using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using kORPG.Common.DI.Attributes;
using System.Reflection;

namespace kORPG.Common.DI.Binding.Bindings
{
    public sealed class DependencyPropertyBinding : IDependencyBinding
    {
        #region Fields
        private readonly IDependencyInjectionLocator locator;
        #endregion

        public DependencyPropertyBinding(IDependencyInjectionLocator locator)
            => this.locator = locator ?? throw new ArgumentNullException(nameof(locator));
        
        public bool Bind(object instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            if (!DependencyBindingUtils.HasBindingProperties(instance.GetType()))
                throw new InvalidOperationException($"type {instance.GetType().Name} does not contain any properties annotated with {nameof(BindingPropertyAttribute)}");

            var properties = instance.GetType()
                                     .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                                     .Where(p => p.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(BindingPropertyAttribute)) != null)
                                     .ToArray();

            var arguments = new object[properties.Length];

            for (var i = 0; i < properties.Length; i++)
            {
                if (!locator.Exists(properties[i].PropertyType)) return false;

                arguments[i] = locator.Get(properties[i].PropertyType);
            }

            for (var i = 0; i < properties.Length; i++)
                properties[i].SetValue(instance, arguments[i]);
            
            return true;
        }
    }
}
