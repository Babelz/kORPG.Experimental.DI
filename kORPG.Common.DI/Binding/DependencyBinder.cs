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
        private DependencyActivator activator;

        private List<IDependencyBinding> binders;

        private object instance;
        #endregion

        #region Properties
        public Type Type
        {
            get;
        }
        #endregion

        public DependencyBinder(object instance)
        {
            this.instance = instance ?? throw new ArgumentNullException(nameof(instance));

            Type = instance.GetType();

            binders = new List<IDependencyBinding>();
        }

        public DependencyBinder(Type type)
        {
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

        public bool Bind()
        {
            if (activator != null && instance == null)
            {
                if (!activator.Activate(out instance))
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
