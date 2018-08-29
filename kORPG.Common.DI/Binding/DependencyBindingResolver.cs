using kORPG.Common.DI.Binding.Activators;
using kORPG.Common.DI.Binding.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Binding
{
    public sealed class DependencyBindingResolver
    {
        #region Fields
        private readonly IDependencyInjectionLocator locator;
        #endregion

        public DependencyBindingResolver(IDependencyInjectionLocator locator)
            => this.locator = locator ?? throw new ArgumentNullException(nameof(locator));
        
        public bool ResolveActivator(Type type, out IDependencyActivator activator)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if      (DependencyBindingUtils.HasBindingConstructor(type)) activator = new DependencyBindingConstructorActivator(locator);
            else if (DependencyBindingUtils.HasDefaultConstructor(type)) activator = new DependencyDefaultConstructorActivator();
            else                                                         activator = null;

            return activator != null;
        }

        public bool ResolveBindings(Type type, out List<IDependencyBinding> bindings)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            bindings = new List<IDependencyBinding>();

            if (DependencyBindingUtils.HasBindingProperties(type)) bindings.Add(new DependencyPropertyBinding(locator));
            if (DependencyBindingUtils.HasBindingMethods(type))    bindings.Add(new DependencyMethodBinding(locator));

            return bindings.Count != 0;
        }
    }
}
