using System;
using System.Collections.Generic;
using System.Text;

namespace PO7.Interfaces
{
    public interface ILieutenantGeneral:IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }

        void AddPrivate(IPrivate prPrivate);
    }
}
