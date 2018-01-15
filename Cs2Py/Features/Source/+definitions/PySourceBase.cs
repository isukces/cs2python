﻿using System.Collections.Generic;
using Cs2Py.CodeVisitors;

namespace Cs2Py.Source
{
    public abstract class PySourceBase
    {
        public static bool EqualCode<T>(T a, T b) where T : class
        {
            if ((a is IPyValue || a == null) && (b is IPyValue || b == null))
            {
                var codeA = a == null ? "" : (a as IPyValue).GetPyCode(null);
                var codeB = a == null ? "" : (b as IPyValue).GetPyCode(null);
                return codeA == codeB;
            }
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            return a == b;
        }
        public static bool EqualCode_Array<T>(T[] a, T[] b) where T : class
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;
            for (var i = 0; i < a.Length; i++)
                if (!EqualCode(a[i], b[i]))
                    return false;
            return true;
        }
        public static bool EqualCode_List<T>(List<T> a, List<T> b) where T : class
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            if (a.Count != b.Count) return false;
            for (var i = 0; i < a.Count; i++)
                if (!EqualCode(a[i], b[i]))
                    return false;
            return true;
        }
        public PySourceItems Kind
        {
            get
            {
                return PyBaseVisitor<int>.GetKind(this);
            }
        }
    }
}