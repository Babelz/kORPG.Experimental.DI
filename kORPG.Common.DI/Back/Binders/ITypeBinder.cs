using System;
using System.Collections.Generic;
using System.Text;

namespace kORPG.Common.DI.Back.Binders
{
    public interface ITypeBinder
    {
        #region Properties
        ITypeBinder Next
        {
            get;
        }
        #endregion

        void Concat(ITypeBinder binder);

        Type[] Bind(Type type);
    }
}
