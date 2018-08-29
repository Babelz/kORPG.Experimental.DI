using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using kORPG.Common.DI.Binding;

namespace kORPG.Common.DI
{
    public sealed class Kernel : IKernel
    {
        #region Fields
        private readonly List<DependencyBinder> binders;
        private readonly List<Dependency> dependencies;
        #endregion

        #region Properties
        public DependencyBindingOptions BindingOptions
        {
            get;
            set;
        }
        public DependencyBindingOptions ProxyBindingOptions
        {
            get;
            set;
        }
        #endregion

        public Kernel()
        {
            BindingOptions      = DependencyBindingOptions.ClassesAndInterfaces;
            ProxyBindingOptions = DependencyBindingOptions.ClassesAndInterfaces;

            binders      = new List<DependencyBinder>();
            dependencies = new List<Dependency>();
        }

        private DependencyBinder ConstructBinder(Type type, Type proxy, object instance, DependencyBindingOptions options)
        {
            var binder = default(DependencyBinder);

            if (type != null && instance != null)
                throw new InvalidOperationException("both type and instance can't have a value");

            if      (instance != null) binder = new DependencyBinder(options, instance);
            else if (type != null)     binder = new DependencyBinder(options, type);
            else                       throw new InvalidOperationException("construction requires type of instance to continue");
            
            var resolver = new DependencyBindingResolver(this);

            if (proxy != null) binder.AsProxy(proxy);

            if (instance == null)
            {
                if (!resolver.ResolveActivator(type ?? instance?.GetType(), out var activator))
                    throw new InvalidOperationException($"no activator for type {type.Name} could be created");

                binder.BindWith(activator);
            }

            if (resolver.ResolveBindings(type ?? instance?.GetType(), out var bindings))
            {
                for (var i = 0; i < bindings.Count; i++)
                    binder.BindWith(bindings[i]);
            }

            return binder;
        }

        private bool ConstructDependency(DependencyBinder binder, out Dependency dependency)
        {
            dependency = null;

            if (!binder.Bind()) return false;

            if (binder.Proxy != null)
                dependency = new Dependency(binder.Instance, DependencyTypeMapper.Map(binder.Proxy, binder.Options));
            else 
                dependency = new Dependency(binder.Instance, DependencyTypeMapper.Map(binder.Type, binder.Options));

            return true;
        }

        private void UpdateBinders()
        {
            var i = 0;

            while (i < binders.Count)
            {
                if (ConstructDependency(binders[i], out var dependency))
                {
                    binders.RemoveAt(i);

                    dependencies.Add(dependency);

                    continue;
                }

                i++;
            }
        }

        public IEnumerable<object> All(Predicate<object> predicate)
            => dependencies.Where(d => predicate(d.Cast<object>()));

        public IEnumerable<object> All()
            => dependencies.Select(d => d.Cast<object>());

        public IEnumerable<T> All<T>(Predicate<T> predicate)
            => dependencies.Where(d => d.Castable<T>() && predicate(d.Cast<T>()))
                           .Cast<T>();

        public IEnumerable<T> All<T>()
            => dependencies.Where(d => d.Castable<T>())
                           .Cast<T>();

        public void Bind(Type type, DependencyBindingOptions options)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var binder = ConstructBinder(type, null, null, options);

            if (ConstructDependency(binder, out var dependency))
                dependencies.Add(dependency);
            else
                binders.Add(binder);

            UpdateBinders();
        }

        public void Bind(Type type)
            => Bind(type, BindingOptions);

        public void Bind<T>(DependencyBindingOptions options)
            => Bind(typeof(T), options);

        public void Bind<T>()
            => Bind(typeof(T), BindingOptions);

        public void Bind(object instance, DependencyBindingOptions options)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var binder = ConstructBinder(null, null, instance, options);

            if (ConstructDependency(binder, out var dependency))
                dependencies.Add(dependency);
            else
                binders.Add(binder);

            UpdateBinders();
        }

        public void Bind(object instance)
            => Bind(instance, BindingOptions);

        public void Proxy(Type actual, Type proxy, DependencyBindingOptions options)
        {
            if (actual == null)
                throw new ArgumentNullException(nameof(actual));

            if (proxy == null)
                throw new ArgumentNullException(nameof(proxy));

            var binder = ConstructBinder(actual, proxy, null, options);

            if (ConstructDependency(binder, out var dependency))
                dependencies.Add(dependency);
            else
                binders.Add(binder);

            UpdateBinders();
        }

        public void Proxy<T>(Type proxy, DependencyBindingOptions options)
            => Proxy(proxy, typeof(T), options);

        public void Proxy(object instance, Type proxy, DependencyBindingOptions options)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            if (proxy == null)
                throw new ArgumentNullException(nameof(proxy));

            var binder = ConstructBinder(null, proxy, instance, options);

            if (ConstructDependency(binder, out var dependency))
                dependencies.Add(dependency);
            else
                binders.Add(binder);

            UpdateBinders();
        }

        public void Proxy<T>(object instance, DependencyBindingOptions options)
            => Proxy(instance, typeof(T), options);

        public void Proxy(object instance, Type proxy)
            => Proxy(instance, proxy, ProxyBindingOptions);

        public void Proxy<T>(object instance)
            => Proxy(instance, typeof(T), ProxyBindingOptions);

        public void Proxy(Type actual, Type proxy)
            => Proxy(actual, proxy, ProxyBindingOptions);

        public void Proxy<T>(Type proxy)
            => Proxy(proxy, typeof(T), ProxyBindingOptions);

        public bool Exists(Type type, Predicate<object> predicate)
            => dependencies.FirstOrDefault(d => d.Castable(type) && predicate(d.Cast<object>())) != null;

        public bool Exists(Type type)
            => dependencies.FirstOrDefault(d => d.Castable(type)) != null;

        public bool Exists<T>(Predicate<T> prediacte)
            => dependencies.FirstOrDefault(d => d.Castable<T>() && prediacte(d.Cast<T>())) != null;

        public bool Exists<T>()
            => dependencies.FirstOrDefault(d => d.Castable<T>()) != null;

        public object Get(Type type, Predicate<object> predicate)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var dependency = dependencies.FirstOrDefault(d => d.Castable(type) && predicate(d.Cast<object>()));

            if (dependency == null)
                throw new DependencyNotFoundException(type);

            return dependency.Cast<object>();
        }

        public object Get(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var dependency = dependencies.FirstOrDefault(d => d.Castable(type));

            if (dependency == null)
                throw new DependencyNotFoundException(type);

            return dependency.Cast<object>();
        }

        public T Get<T>(Predicate<T> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            var dependency = dependencies.FirstOrDefault(d => d.Castable<T>() && predicate(d.Cast<T>()));

            if (dependency == null)
                throw new DependencyNotFoundException(typeof(T));

            return dependency.Cast<T>();
        }

        public T Get<T>()
        {
            var dependency = dependencies.FirstOrDefault(d => d.Castable<T>());

            if (dependency == null)
                throw new DependencyNotFoundException(typeof(T));

            return dependency.Cast<T>();
        }
    }
}
