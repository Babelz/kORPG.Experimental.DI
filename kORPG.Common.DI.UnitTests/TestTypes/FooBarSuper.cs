using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kORPG.Common.DI.UnitTests.TestTypes
{
    public sealed class FooBarSuper : FooBar
    {
        public FooBarSuper()
            : base()
        {
        }
        
        public void SuperFooBar()
        {
            throw new NotImplementedException();
        }
    }
}
