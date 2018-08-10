using System;

namespace kORPG.Common.DI.Back
{
    [Flags()]
    public enum BindingOptions : byte
    {
        None                     = 0,
        DefaultConstructor       = (1 << 0),
        AutomaticConstructor     = (1 << 1),
        MarkedConstructor        = (1 << 2),
        AutomaticPropertyBinding = (1 << 3),
        MarkedPropertyBinding    = (1 << 4),
        BindClass                = (1 << 5),
        BindClasses              = (1 << 6),
        BindInterfaces           = (1 << 7),
        BindClassesAndInterfaces = BindClasses | BindInterfaces
    }
}