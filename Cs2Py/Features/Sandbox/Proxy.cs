using System;

namespace Cs2Py.Sandbox
{
    public class Proxy : AssemblySandbox
    {
        public Proxy(AssemblySandbox sandbox)
            : base(null)
        {
            OnAssemblyResolve += (s, a) =>
            {
                Console.WriteLine("I am in proxy");
                RaiseOnAssemblyResolve(sandbox);
                return null;
            };
        }
    }
}