using System.Collections.Generic;

namespace Cs2Py.CSharp
{
    public interface IClassOrInterface
    {
        IClassMember[] Members { get; }
    }
}