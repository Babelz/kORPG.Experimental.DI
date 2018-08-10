using kORPG.Common.DI.Back.Binders;
using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Back.Builders
{
    public interface IDependencyBuilder
    {
        void ConstructWithMarkedConstructor();
        void ConstructWithDefaultConstructor();
        void ConstructWithAutomaticConstructor();

        void ConstructWithMarkedPropertyBinding();
        void ConstructWithAutomaticPropertyBinding();

        void BindWithClass();
        void BindWithClasses();
        void BindWithInterfaces();
    }
}
