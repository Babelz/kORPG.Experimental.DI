using kORPG.Common.DI.Attributes;

namespace kORPG.Common.DI.UnitTests.TestTypes
{
    public abstract class BaseCtorPropMethodFooBar : FooBar
    {
        #region Properties
        [BindingProperty()]
        public abstract Dep0 Dep0
        {
            set;
        }

        [BindingProperty()]
        public abstract Dep1 Dep1
        {
            set;
        }

        [BindingProperty()]
        public abstract Dep2 Dep2
        {
            set;
        }
        #endregion
        
        [BindingMethod()]
        public abstract void Deps0(Dep0 dep);

        [BindingMethod()]
        public abstract void Deps1(Dep1 dep);

        [BindingMethod()]
        public abstract void Deps2(Dep2 dep);
    }
}