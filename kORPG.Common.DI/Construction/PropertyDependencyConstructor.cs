using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Construction
{
    public sealed class PropertyDependencyConstructor : IDependencyConstructor
    {
        #region Fields
        private readonly IDependencyLocator locator;
        private readonly DependencyBinderOptions options;
        private readonly Type type;
        #endregion

        public PropertyDependencyConstructor(Type type, DependencyBinderOptions options, IDependencyLocator locator)
        {
            this.options = options;
            this.type    = type ?? throw new ArgumentNullException(nameof(type));
            this.locator = locator ?? throw new ArgumentNullException(nameof(locator));
        }
        
        public bool Construct(out IDependency dependency)
        {
            dependency = null;

            var value = default(object);
            var types = default(Type[]);



            dependency = new ObjectDependency(value, types);

            return false;
        }
    }
}
