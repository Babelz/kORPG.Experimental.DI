using kORPG.Common.DI.Binding.Activators;
using kORPG.Common.DI.Binding.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Binding
{
    public sealed class DependencyBinder 
    {
        #region Fields
        private IDependencyActivator activator;

        private List<IDependencyBinding> binders;

        private object instance;
        #endregion

        #region Properties
        public object Instance => instance;

        public Type Proxy
        {
            get;
            private set;
        }
        public Type Type
        {
            get;
        }

        public DependencyBindingOptions Options
        {
            get;
        }
        #endregion

        public DependencyBinder(DependencyBindingOptions options, object instance)
        {
            Options = options;

            this.instance = instance ?? throw new ArgumentNullException(nameof(instance));

            Type = instance.GetType();

            binders = new List<IDependencyBinding>();
        }

        public DependencyBinder(DependencyBindingOptions options, Type type)
        {
            Options = options;

            Type = type ?? throw new ArgumentNullException(nameof(type));

            binders = new List<IDependencyBinding>();
        }

        public void BindWith(IDependencyActivator activator)
        {
            if (instance != null)
                throw new InvalidOperationException("already instantiated");

            this.activator = activator ?? throw new ArgumentNullException(nameof(activator));
        }

        public void BindWith(IDependencyBinding binder)
            => binders.Add(binder ?? throw new ArgumentNullException(nameof(binder)));

        public void AsProxy(Type proxy)
        {
            Proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));

            var actual = instance?.GetType() ?? Type;

            if (!proxy.IsAssignableFrom(actual))
                throw new InvalidOperationException("invalid proxy type");
        }

        public bool Bind()
        {
            if (activator != null && instance == null)
            {
                if (!activator.Activate(Type, out instance))
                {
                    instance = null;

                    return false;
                }
            }

            for (var i = 0; i < binders.Count; i++)
                if (!binders[i].Bind(instance)) return false;
            
            return true;
        }
    }
}
