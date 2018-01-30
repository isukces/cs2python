using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace Cs2Py.Compilation
{
    internal class RoslynTypeResolver
    {
        public RoslynTypeResolver(Type[] knownTypes, Func<ITypeSymbol, Type> resolveCached,
            Lazy<ITypeSymbol[]>          roslynAllNamedTypeSymbols)
        {
            _roslynAllNamedTypeSymbols = roslynAllNamedTypeSymbols;
            _knownTypes                = knownTypes;
            _resolveCached             = resolveCached;
        }

        public Type Resolve(ITypeSymbol type)
        {
            // throw new NotSupportedException(type.ToString());

            // var aaaa = roslynCompilation.GetSpecialType(type.SpecialType);
            switch (type.SpecialType)
            {
                case SpecialType.System_String:
                    return typeof(string);
                case SpecialType.System_Double:
                    return typeof(double);
                case SpecialType.System_Decimal:
                    return typeof(decimal);
                case SpecialType.System_Int16:
                    return typeof(short);
                case SpecialType.System_Int32:
                    return typeof(int);
                case SpecialType.System_Int64:
                    return typeof(long);
                case SpecialType.System_Object:
                    return typeof(object);
                case SpecialType.System_Boolean:
                    return typeof(bool);
                case SpecialType.System_Char:
                    return typeof(char);
                case SpecialType.System_Void:
                    return typeof(void);
                case SpecialType.System_Array:
                    return typeof(Array);
                case SpecialType.System_DateTime:
                    return typeof(DateTime);
                case SpecialType.System_Enum:
                    return typeof(Enum);
                case SpecialType.None:
                    return Resolve_None(type);
                default:
                    throw new NotSupportedException(type.ToString());
            }
        }

        private Type[] FindTypeArguments(INamedTypeSymbol typeSymbol, Type type)
        {
            var parameterByName = new Dictionary<string, Type>();
            var ts              = typeSymbol;
            while (ts != null)
            {
                var tsGenericDef = ts.ConstructedFrom;
                for (var index = 0; index < ts.TypeArguments.Length; index++)
                {
                    var arg               = ts.TypeArguments[index];
                    var argGenericDef     = tsGenericDef.TypeArguments[index];
                    var resolvedParameter = _resolveCached(arg);
                    if (resolvedParameter == null)
                        throw new Exception($"Unable to resolve type {arg} for {argGenericDef.Name}");
                    parameterByName[argGenericDef.Name] = resolvedParameter;
                }

                ts = ts.ContainingType;
            }

            var expected      = type.GetGenericArguments();
            var typeArguments = new Type[expected.Length];
            for (var index = 0; index < expected.Length; index++)
            {
                var ex               = expected[index];
                var t                = parameterByName[ex.Name];
                typeArguments[index] = t;
            }

            return typeArguments;
        }

        private Type Resolve_None(ITypeSymbol type)
        {
            switch (type.TypeKind)
            {
                case TypeKind.Array:
                    return Resolve_None_Array(type);
                case TypeKind.Error:
                    return null;
                case TypeKind.TypeParameter:
                    return Resolve_None_TypeParameter(type);
            }

            if (type is INamedTypeSymbol namedTypeSymbol)
                return Resolve_None_NamedTypeSymbol(namedTypeSymbol);

            throw new NotSupportedException(type.ToString());
        }

        private Type Resolve_None_Array(ITypeSymbol type)
        {
            var arrayTypeSymbol = type as IArrayTypeSymbol;
            var elementType     = _resolveCached(arrayTypeSymbol.ElementType);
            var result          = arrayTypeSymbol.Rank == 1
                ? elementType.MakeArrayType()
                : elementType.MakeArrayType(arrayTypeSymbol.Rank);
            return result;
        }

        private Type Resolve_None_NamedTypeSymbol(INamedTypeSymbol symbol)
        {
            if (symbol.IsGenericType)
                return Resolve_None_NamedTypeSymbol_Generic(symbol);

            if (symbol.ContainingType != null)
            {
                var ct               = _resolveCached(symbol.ContainingType);
                var kt               = _knownTypes.Where(i => i.DeclaringType == ct).ToArray();
                var reflectionSearch =
                    symbol.ContainingType.ToDisplayString() + "+" + symbol.Name;
                var reflected = _knownTypes.Single(i => i.FullName == reflectionSearch);
                return reflected;
            }
            else
            {
                var reflectionSearch = symbol.ToDisplayString();
                var reflected        = _knownTypes.Single(i => i.FullName == reflectionSearch);
                return reflected;
            }
        }

        private Type Resolve_None_NamedTypeSymbol_Generic(INamedTypeSymbol symbol)
        {
            var reflectionSearch           = symbol.ToDisplayString();
            var reflectionSearchGenericDef = symbol.ConstructedFrom.ToDisplayString();
            if (!string.Equals(reflectionSearch, reflectionSearchGenericDef, StringComparison.Ordinal))
                reflectionSearch = reflectionSearchGenericDef;

            reflectionSearch = GenericTypeName.MakeGenericName(reflectionSearch);

            var type = _knownTypes.SingleOrDefault(i => i.FullName == reflectionSearch);
            if (type == null)
                throw new Exception("Unable to find type " + reflectionSearch);
            var typeArguments = FindTypeArguments(symbol, type);
            var type2         = type.MakeGenericType(typeArguments);
            return type2;
        }

        private Type Resolve_None_TypeParameter(ITypeSymbol type)
        {
            var parameterSymbol = (ITypeParameterSymbol)type;
            var dm              = parameterSymbol.DeclaringMethod;
            var typeName        = parameterSymbol.Name;
            var a               = _knownTypes.Where(i => i.Name == typeName && i.IsGenericParameter)
                .ToArray();
            var methodName = dm.Name;
            var b          = a.Where(i => i.DeclaringMethod?.Name == methodName).ToArray();

            if (b.Length == 1)
                return b[0];
            var whereToSearchMethod  = dm.ContainingType;
            var whereToSearchMethod2 = _resolveCached(whereToSearchMethod);
            var reqParameter         = string.Join(",",
                dm.Parameters.Select(q => /*q.Type.Name+" "+ */ q.Name));
            var mes = whereToSearchMethod2.GetMethods(
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static |
                    BindingFlags.Instance).Where(q =>
                {
                    if (q.Name != methodName || !q.IsGenericMethod)
                        return false;
                    var parameters = q.GetParameters();
                    var compare    = string.Join(",",
                        parameters.Select(w => /*w.ParameterType.Name + " " +*/ w.Name));
                    return reqParameter == compare;
                })
                .ToArray();
            if (mes.Length != 1)
                throw new Exception($"Unable to find method {dm}");
            var mesT  = mes[0].GetGenericArguments().ToArray();
            var mesT1 = mesT.Where(q => q.Name == typeName).ToArray();
            if (mesT1.Length == 1)
                return mesT1[0];
            throw new Exception($"Unable to find type {typeName} method {dm}");
        }

        private readonly Func<ITypeSymbol, Type> _resolveCached;
        private          Lazy<ITypeSymbol[]>     _roslynAllNamedTypeSymbols;
        private readonly Type[]                  _knownTypes;
    }
}