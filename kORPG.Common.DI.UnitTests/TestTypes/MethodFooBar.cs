using kORPG.Common.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kORPG.Common.DI.UnitTests.TestTypes
{
    public sealed class MethodFooBar : FooBar
    {
        public MethodFooBar()
        {
        }

        [BindingMethod()]
        private void Deps0(Dep0 dep)
        {
            if (dep == null) throw new ArgumentNullException(nameof(dep));
        }

        [BindingMethod()]
        public void Deps1(Dep1 dep)
        {
            if (dep == null) throw new ArgumentNullException(nameof(dep));
        }

        [BindingMethod()]
        public void Deps2(Dep2 dep)
        {
            if (dep == null) throw new ArgumentNullException(nameof(dep));
        }
    }
}
