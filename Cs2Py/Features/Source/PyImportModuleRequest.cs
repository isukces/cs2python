using System;
using JetBrains.Annotations;

namespace Cs2Py.Source
{
    public sealed class PyImportModuleRequest : IEquatable<PyImportModuleRequest>
    {
        public PyImportModuleRequest([NotNull] string relativeModulePath, string alias = null)
        {
            RelativeModulePath = relativeModulePath ?? throw new ArgumentNullException(nameof(relativeModulePath));
            Alias = alias;
        }

        public static bool operator ==(PyImportModuleRequest left, PyImportModuleRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PyImportModuleRequest left, PyImportModuleRequest right)
        {
            return !Equals(left, right);
        }

        public bool Equals(PyImportModuleRequest other)
        {
            if (ReferenceEquals(null,    other)) return false;
            return ReferenceEquals(this, other) || string.Equals(RelativeModulePath, other.RelativeModulePath);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((PyImportModuleRequest)obj);
        }

        public override int GetHashCode()
        {
            return RelativeModulePath.GetHashCode();
        }

        [NotNull]
        public string RelativeModulePath { get; }

        public string Alias { get; }
    }
}