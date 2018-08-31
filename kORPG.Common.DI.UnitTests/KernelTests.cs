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

        [TestMethod()]
        public void BindWithInstanceProxyAndOptionsTest()
        {
            var kernel = new Kernel();

            kernel.Proxy(new FooBar(), typeof(IFoo), DependencyBindingOptions.Interfaces);

            Assert.IsFalse(kernel.Exists<FooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsFalse(kernel.Exists<IBar>());
        }

        [TestMethod()]
        public void BindWithTypeProxyAndOptionsTests()
        {
            var kernel = new Kernel();

            kernel.Proxy(typeof(FooBarSuper), typeof(FooBar), DependencyBindingOptions.Class);

            Assert.IsTrue(kernel.Exists<FooBar>());
            Assert.IsFalse(kernel.Exists<IFoo>());
            Assert.IsFalse(kernel.Exists<IBar>());
        }

        [TestMethod()]
        public void BindingConstructorTest()
        {
            var kernel = new Kernel();

            kernel.Bind<CtroFooBar>();

            Assert.IsFalse(kernel.Exists<CtroFooBar>());

            kernel.Bind(new Dep0());
            Assert.IsFalse(kernel.Exists<CtroFooBar>());

            kernel.Bind(new Dep1());
            Assert.IsFalse(kernel.Exists<CtroFooBar>());

            kernel.Bind(new Dep2());

            Assert.IsTrue(kernel.Exists<CtroFooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsTrue(kernel.Exists<IBar>());
        }

        [TestMethod()]
        public void BindingPropertyTest()
        {
            var kernel = new Kernel();

            kernel.Bind<PropFooBar>();

            Assert.IsFalse(kernel.Exists<PropFooBar>());

            kernel.Bind(new Dep0());
            Assert.IsFalse(kernel.Exists<PropFooBar>());

            kernel.Bind(new Dep1());
            Assert.IsFalse(kernel.Exists<PropFooBar>());

            kernel.Bind(new Dep2());

            Assert.IsTrue(kernel.Exists<PropFooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsTrue(kernel.Exists<IBar>());
        }

        [TestMethod()]
        public void BindingMethodTest()
        {
            var kernel = new Kernel();

            kernel.Bind<MethodFooBar>();

            Assert.IsFalse(kernel.Exists<MethodFooBar>());

            kernel.Bind(new Dep0());
            Assert.IsFalse(kernel.Exists<MethodFooBar>());

            kernel.Bind(new Dep1());
            Assert.IsFalse(kernel.Exists<MethodFooBar>());

            kernel.Bind(new Dep2());

            Assert.IsTrue(kernel.Exists<MethodFooBar>());
            Assert.IsTrue(kernel.Exists<FooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsTrue(kernel.Exists<IBar>());
        }

        [TestMethod()]
        public void BindingConstructorPropertyAndMethodTest()
        {
            var kernel = new Kernel();

            kernel.Bind<CtorPropMethodFooBar>();

            Assert.IsFalse(kernel.Exists<CtorPropMethodFooBar>());

            kernel.Bind(new Dep0());
            Assert.IsFalse(kernel.Exists<CtorPropMethodFooBar>());

            kernel.Bind(new Dep1());
            Assert.IsFalse(kernel.Exists<CtorPropMethodFooBar>());

            kernel.Bind(new Dep2());

            Assert.IsTrue(kernel.Exists<CtorPropMethodFooBar>());
            Assert.IsTrue(kernel.Exists<FooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsTrue(kernel.Exists<IBar>());
        }

        [TestMethod()]
        public void BindingConstructorVirtualPropertyAndMethodTest()
        {
            var kernel = new Kernel();

            kernel.Bind<BaseCtorPropMethodFooBarImpl>();

            Assert.IsFalse(kernel.Exists<BaseCtorPropMethodFooBarImpl>());

            kernel.Bind(new Dep0());
            Assert.IsFalse(kernel.Exists<BaseCtorPropMethodFooBarImpl>());

            kernel.Bind(new Dep1());
            Assert.IsFalse(kernel.Exists<BaseCtorPropMethodFooBarImpl>());

            kernel.Bind(new Dep2());

            Assert.IsTrue(kernel.Exists<BaseCtorPropMethodFooBarImpl>());
            Assert.IsTrue(kernel.Exists<BaseCtorPropMethodFooBar>());
            Assert.IsTrue(kernel.Exists<FooBar>());
            Assert.IsTrue(kernel.Exists<IFoo>());
            Assert.IsTrue(kernel.Exists<IBar>());
        }

        [TestMethod()]
        public void CantBindToInterfaceTest()
        {
            var kernel = new Kernel();

            Assert.ThrowsException<DependencyBinderException>(() => kernel.Bind<IFoo>());
        }

        [TestMethod()]
        public void CantBindToAbstractClassTest()
        {
            var kernel = new Kernel();

            Assert.ThrowsException<DependencyBinderException>(() => kernel.Bind<BaseCtorPropMethodFooBar>());
        }
    }
}
