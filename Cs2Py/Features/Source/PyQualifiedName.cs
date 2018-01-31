using System;
using System.Globalization;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public struct PyQualifiedName : IEquatable<PyQualifiedName>
    {
        private          string _forceName;
        [Obsolete]
        public const     string ClassnameParent  = "parent";
        [Obsolete]
        public const     string ClassnameSelf    = "self";
        public const     char   TokenNsSeparator = '\\';

        /// <summary>
        /// Własność jest tylko do odczytu.
        /// </summary>
        public string EmitName => string.IsNullOrEmpty(_forceName) ? FullName : _forceName;

        public static PyQualifiedName Empty => new PyQualifiedName(null);

        /// <summary>
        /// nazwa dostępna w obecnym kontekście, np. self
        /// </summary>
        public string ForceName
        {
            get => _forceName;
            set => _forceName = (value ?? string.Empty).Trim();
        }

        /// <summary>
        /// pełna nazwa
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Przestrzeń nazw; własność jest tylko do odczytu.
        /// </summary>
        public PyNamespace Namespace => GetNamespace();

        /// <summary>
        /// nazwa krótka; własność jest tylko do odczytu.
        /// </summary>
        public string ShortName => GetShortName();

        /// <summary>
        /// Realizuje operator !=
        /// </summary>
        /// <param name="left">lewa strona porównania</param>
        /// <param name="right">prawa strona porównania</param>
        /// <returns><c>true</c> jeśli obiekty są różne</returns>
        public static bool operator !=(PyQualifiedName left, PyQualifiedName right)
        {
            return left.FullName != right.FullName;
        }

        /// <summary>
        /// Realizuje operator ==
        /// </summary>
        /// <param name="left">lewa strona porównania</param>
        /// <param name="right">prawa strona porównania</param>
        /// <returns><c>true</c> jeśli obiekty są równe</returns>
        public static bool operator ==(PyQualifiedName left, PyQualifiedName right)
        {
            return left.FullName == right.FullName;
        }

        /// <summary>
        /// Sprawdza, czy wskazany obiekt jest równy bieżącemu
        /// </summary>
        /// <param name="other">obiekt do porównania z obiektem bieżącym</param>
        /// <returns><c>true</c> jeśli wskazany obiekt jest równy bieżącemu; w przeciwnym wypadku<c>false</c></returns>
        public bool Equals(PyQualifiedName other)
        {
            return other == this;
        }

        /// <summary>
        /// Sprawdza, czy wskazany obiekt jest równy bieżącemu
        /// </summary>
        /// <param name="other">obiekt do porównania z obiektem bieżącym</param>
        /// <returns><c>true</c> jeśli wskazany obiekt jest równy bieżącemu; w przeciwnym wypadku<c>false</c></returns>
        public override bool Equals(object other)
        {
            if (!(other is PyQualifiedName)) return false;
            return Equals((PyQualifiedName)other);
        }

        /// <summary>
        /// Zwraca kod HASH obiektu
        /// </summary>
        /// <returns>kod HASH obiektu</returns>
        public override int GetHashCode()
        {
            return (FullName ?? "").GetHashCode();
        }

        private string GetNameRelatedTo(PyQualifiedName other)
        {
            return other.FullName == FullName ? ClassnameSelf : FullName;
        }

        PyNamespace GetNamespace()
        {
            var a = FullName.LastIndexOf(TokenNsSeparator);
            if (a < 0) return PyNamespace.Root;
            return (PyNamespace)FullName.Substring(0, a);
        }

        string GetShortName()
        {
            var a = FullName.LastIndexOf(TokenNsSeparator);
            return a < 0 ? FullName : FullName.Substring(a + 1);
        }

        public bool IsEmpty => string.IsNullOrEmpty(FullName);

        /// <summary>
        /// Tworzy nazwę absolutną (bez skrótów typu self lub parent)
        /// </summary>
        /// <returns></returns>
        public PyQualifiedName MakeAbsolute()
        {
            var clone       = this;
            clone.ForceName = "";
            return clone;
        }

        public string NameForEmit(PyEmitStyle style)
        {
            if (style == null)
                return EmitName;
            

            if (this == style.CurrentClass)
            {
                if (style.CurrentMethod == null) 
                    return EmitName;
                var alias = style.CurrentMethod.GetCurrentClassAlias();
                if (alias != null)
                    return alias;
                return EmitName;
            }

            if (style.CurrentNamespace == null)
                return FullName;
            {
                if ((FullName + TokenNsSeparator).StartsWith(style.CurrentNamespace.Name + TokenNsSeparator))
                    return FullName.Substring(style.CurrentNamespace.Name.Length + 1);
            }
            if (style.CurrentNamespace == Namespace)
                return ShortName;
            if (style.CurrentNamespace == null)
                return EmitName;
            if (Namespace == null && !FullName.StartsWith(TokenNsSeparator.ToString(CultureInfo.InvariantCulture)))
                return TokenNsSeparator + FullName;

            return EmitName;
        }

        private PyQualifiedName(string fullName)
            : this()
        {
            if (fullName != null)
                fullName = fullName.Trim();
            if (fullName == "")
                fullName = null;
            FullName    = fullName;
        }

        public static explicit operator PyQualifiedName(string fullName)
        {
            return new PyQualifiedName(fullName);
        }

        /// <summary>
        /// Not yet finished
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string SanitizePyName(string n)
        {
            n      = n.Trim();
            var nl = n.ToLower();
            if (nl == "namespace")
                return "_" + n;
            return n;
        }

        public void SetEffectiveNameRelatedTo(PyQualifiedName other)
        {
            var effectiveNameCandidate = GetNameRelatedTo(other);
            ForceName                  = effectiveNameCandidate != FullName ? effectiveNameCandidate : "";
        } 

        /// <summary>
        /// Zwraca tekstową reprezentację obiektu
        /// </summary>
        /// <returns>Tekstowa reprezentacja obiektu</returns>
        public override string ToString()
        {
            return string.Format("PyClassName = {0}", EmitName);
        }
    }
}