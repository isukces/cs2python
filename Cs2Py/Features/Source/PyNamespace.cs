using Cs2Py.Compilation;

namespace Cs2Py.Source
{
    public class PyNamespace
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="name"></param>
        /// </summary>
        public PyNamespace(string name)
        {
            Name = name;
        }
        // Public Methods 

        public static bool IsRootNamespace(string name)
        {
            return Prepare(name) == RootName;
        }


        /// <summary>
        ///     Realizuje operator ==
        /// </summary>
        /// <param name="left">lewa strona porównania</param>
        /// <param name="right">prawa strona porównania</param>
        /// <returns><c>true</c> jeśli obiekty są równe</returns>
        public static bool operator ==(PyNamespace left, PyNamespace right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
            return left._name == right._name;
        }

        public static explicit operator PyNamespace(string src)
        {
            return new PyNamespace(src);
        }

        /// <summary>
        ///     Realizuje operator !=
        /// </summary>
        /// <param name="left">lewa strona porównania</param>
        /// <param name="right">prawa strona porównania</param>
        /// <returns><c>true</c> jeśli obiekty są różne</returns>
        public static bool operator !=(PyNamespace left, PyNamespace right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) return false;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return true;
            return left._name != right._name;
        }

        public static string Prepare(string ns)
        {
            ns = ns ?? "";
            ns = PathUtil.MakeWinPath(ns);
            if (!ns.StartsWith(PathUtil.WIN_SEP))
                ns = PathUtil.WIN_SEP + ns;
            return ns;
        }


        /// <summary>
        ///     Sprawdza, czy wskazany obiekt jest równy bieżącemu
        /// </summary>
        /// <param name="obj">obiekt do porównania z obiektem bieżącym</param>
        /// <returns><c>true</c> jeśli wskazany obiekt jest równy bieżącemu; w przeciwnym wypadku<c>false</c></returns>
        public bool Equals(PyNamespace other)
        {
            return other == this;
        }

        /// <summary>
        ///     Sprawdza, czy wskazany obiekt jest równy bieżącemu
        /// </summary>
        /// <param name="obj">obiekt do porównania z obiektem bieżącym</param>
        /// <returns><c>true</c> jeśli wskazany obiekt jest równy bieżącemu; w przeciwnym wypadku<c>false</c></returns>
        public override bool Equals(object other)
        {
            if (!(other is PyNamespace)) return false;
            return Equals((PyNamespace)other);
        }

        /// <summary>
        ///     Zwraca kod HASH obiektu
        /// </summary>
        /// <returns>kod HASH obiektu</returns>
        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        // Public Methods 

        public override string ToString()
        {
            return _name;
        }

        public static PyNamespace Root => new PyNamespace(RootName);


        /// <summary>
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                value = (value ?? string.Empty).Trim();
                value = Prepare(value);
                if (value == _name) return;
                _name  = value;
                IsRoot = IsRootNamespace(_name);
            }
        }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public bool IsRoot { get; private set; } = true;

        private string _name = RootName;

        public const string RootName = PathUtil.WIN_SEP;
    }
}