using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Binding
{
    public sealed class DependencyBindingResolver
    {
        #region Fields
        private readonly bool instantiated;

        private readonly Type type;
        #endregion

        public DependencyBindingResolver(bool instantiated, Type type)
        {
            this.instantiated = instantiated;
            this.type         = type ?? throw new ArgumentNullException(nameof(type));
        }
    }
}
