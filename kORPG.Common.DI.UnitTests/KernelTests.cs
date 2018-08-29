using kORPG.Common.DI;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using kORPG.Common.DI.UnitTests.TestTypes;
using kORPG.Common.DI.Binding;

namespace kORPG.Common.DI.Tests
{
    [TestClass()]
    public class KernelTests
    {
        [TestMethod()]
        public void KernelTest()
        {
            try
            {
                new Kernel();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void BindWithInstanceTest()
        {
            var kernel = new Kernel();

            kernel.Bind(new FooBar());

            Assert.IsTrue(kernel.Exists<FooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsTrue(kernel.Exists<IBar>());
        }
        [TestMethod()]
        public void BindWithTypeTest()
        {
            var kernel = new Kernel();

            kernel.Bind(typeof(FooBar));

            Assert.IsTrue(kernel.Exists<FooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsTrue(kernel.Exists<IBar>());
        }

        [TestMethod()]
        public void BindWithInstanceAndOptionsTest()
        {
            var kernel = new Kernel();

            kernel.Bind(new FooBar(), DependencyBindingOptions.Class);

            Assert.IsTrue(kernel.Exists<FooBar>());
            Assert.IsFalse(kernel.Exists<IFoo>());
            Assert.IsFalse(kernel.Exists<IBar>());
        }
        [TestMethod()]
        public void BindWithTypeAndOptionsTest()
        {
            var kernel = new Kernel();

            kernel.Bind(typeof(FooBar), DependencyBindingOptions.Interfaces);

            Assert.IsFalse(kernel.Exists<FooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsTrue(kernel.Exists<IBar>());
        }

        [TestMethod()]
        public void BindWithTypeGenericTest()
        {
            var kernel = new Kernel();

            kernel.Bind<FooBar>();

            Assert.IsTrue(kernel.Exists<FooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsTrue(kernel.Exists<IBar>());
        }
        [TestMethod()]
        public void BindWithTypeGenericAndOptionsTest()
        {
            var kernel = new Kernel();

            kernel.Bind<FooBar>(DependencyBindingOptions.Interfaces);

            Assert.IsFalse(kernel.Exists<FooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsTrue(kernel.Exists<IBar>());
        }

        [TestMethod()]
        public void BindWithInstanceProxyTests()
        {
            var kernel = new Kernel();

            kernel.Proxy(new FooBar(), typeof(IFoo));

            Assert.IsFalse(kernel.Exists<FooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsFalse(kernel.Exists<IBar>());
        }

        [TestMethod()]
        public void BindWithTypeProxyTests()
        {
            var kernel = new Kernel();

            kernel.Proxy(typeof(FooBar), typeof(IFoo));

            Assert.IsFalse(kernel.Exists<FooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsFalse(kernel.Exists<IBar>());
        }
    }
}
