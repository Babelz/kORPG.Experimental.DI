using kORPG.Common.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kORPG.Common.DI.UnitTests.TestTypes
{
    public sealed class PropFooBar : FooBar
    {
        #region Properties
        [BindingProperty()]
        private Dep0 Dep0
        {
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }

        [BindingProperty()]
        public Dep1 Dep01
        {
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }

        [BindingProperty()]
        public Dep2 Dep2
        {
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }
        #endregion

        public PropFooBar()
        {
        }
    }
}
