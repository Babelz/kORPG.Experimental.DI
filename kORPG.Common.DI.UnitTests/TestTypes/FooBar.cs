using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kORPG.Common.DI.UnitTests.TestTypes
{
    public class FooBar : IFoo, IBar
    {
        public FooBar()
        {
        }

        public void Bar()
        {
            throw new NotImplementedException();
        }

        public void Foo()
        {
            throw new NotImplementedException();
        }
    }
}
