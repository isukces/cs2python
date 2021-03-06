﻿using System;
using System.Collections.Generic;
using System.Linq;
using isukces.code;

namespace CodeGenerator
{
    internal class Generator : BaseGenerator
    {
        private static void DefaultNotSupportedException(CSCodeFormatter c)
        {
            c.Writeln("default:");
            c.IncIndent();
            c.Writeln("throw new NotSupportedException();");
            c.DecIndent();
        }


        private static string FirstUpper(string x)
        {
            return x.Substring(0, 1).ToUpper() + x.Substring(1);
        }

        private static bool IsAllowedPair(string left, string right)
        {
            bool IsAllowedPair1(string l, string r)
            {
                switch (l + " " + r)
                {
                    case "int ulong":
                    case "sbyte ulong":
                    case "short ulong":
                    case "long ulong":
                    case "double decimal":
                    case "float decimal":
                        return false;
                }

                return true;
            }

            if (left == "string" && right == "string")
                return true;
            if (left == "string" || right == "string")
                return false;
            return IsAllowedPair1(left, right) && IsAllowedPair1(right, left);
        }

        public void GenerateAll()
        {
            GenerateValueHelper();
            new NumpyGenerator {BasePath = BasePath}.Generate();            
            // new NumpyGenerator {BasePath = BasePath}.Generate();
        }

        private void GenerateValueHelper()
        {
            var file    = CreateFile();
            var subDir  = "Helpers";
            var cl      = file.GetOrCreateClass(Namespace + "." + subDir, "ValueHelper");
            cl.IsStatic = true;

            List<string> GetTypes(bool withString)
            {
                var types = "int,long,short,sbyte,uint,ulong,ushort,byte,double,float,decimal".Split(',').ToList();
                if (withString)
                    types.Add("string");
                return types;
            }

            void MakeBinaryOperator(string name, string op)
            {
                var types = GetTypes(op == "+");
                 
                var c = new CSCodeFormatter();
                c.Open("switch (left)");
                {
                    foreach (var left in types)
                    {
                        var ln = "left" + FirstUpper(left);
                        c.Writeln($"case {left} {ln}:");
                        c.IncIndent();
                        {
                            c.Open("switch (right)");
                            {
                                foreach (var right in types)
                                {
                                    if (!IsAllowedPair(left, right))
                                        continue;
                                    var rn = "right" + FirstUpper(right);
                                    c.Writeln($"case {right} {rn}: return {ln} {op} {rn};");
                                }

                                DefaultNotSupportedException(c);
                            }
                            c.Close();
                        }
                        c.DecIndent();
                    }

                    DefaultNotSupportedException(c);
                }
                c.Close();

                var m = cl.AddMethod(name, "object")
                    .WithBody(c)
                    .WithStatic();
                m.AddParam("left",  "object");
                m.AddParam("right", "object");
            }
            void MakeIsNumericZero(string name, Func<string,string,string> f)
            {                
                    var types = GetTypes(false);
                var c = new CSCodeFormatter();
                c.Open("switch (value)");
                {
                    foreach (var type in types)
                    {
                        var ln = "value" + FirstUpper(type);
                        var result = f(type, ln);
                        c.Writeln($"case {type} {ln}: return {result};");
                    }                    
                }
                c.Close();
                c.Writeln("return null;");

                var m = cl.AddMethod(name, "bool?")
                    .WithBody(c)
                    .WithStatic();
                m.AddParam("value",  "object");
            }
            
            void MakeIsNumericMinus()
            {                
                var types = GetTypes(false);
                var c     = new CSCodeFormatter();
                c.Open("switch (value)");
                {
                    foreach (var type in types)
                    {
                        var ln = "value" + FirstUpper(type);
                        var result = IsUnsigned(type) ? "null" : $"-{ln}";
                        c.Writeln($"case {type} {ln}: return {result};");
                    }                    
                }
                c.Close();
                c.Writeln("return null;");

                var m = cl.AddMethod("Minus", "object")
                    .WithBody(c)
                    .WithStatic();
                m.AddParam("value", "object");
            }

            MakeBinaryOperator("Add", "+");
            MakeBinaryOperator("Sub", "-");
            MakeBinaryOperator("Mul", "*");
            MakeBinaryOperator("Div", "/");
            MakeIsNumericMinus();
            MakeIsNumericZero("EqualsNumericZero", (type, ln) => $"{ln}.Equals({Zero(type)})");
            MakeIsNumericZero("EqualsNumericOne", (type, ln) => $"{ln}.Equals({Number(type, "1")})");
            MakeIsNumericZero("EqualsNumericMinusOne", (type, ln) =>
            {
                if (IsUnsigned(type))
                    return "false";
                return $"{ln}.Equals({Number(type, "-1")})";
            });
            
            MakeIsNumericZero("IsLowerThanZero",        (type, ln) =>
            {
                if (IsUnsigned(type))
                    return "false";
                return $"{ln} < {Zero(type)}";
            });
            MakeIsNumericZero("IsLowerThanZeroOrEqual", (type, ln) => $"{ln} <={Zero(type)}");
            MakeIsNumericZero("IsGreaterThanZero",        (type, ln) => $"{ln} >{Zero(type)}");
            MakeIsNumericZero("IsGreaterThanZeroOrEqual", (type, ln) =>
            {
                if (IsUnsigned(type))
                    return "true";
                return $"{ln} >= {Zero(type)}";
            });
            // is Zero
            
            Save(file, cl, "Cs2Py", "Features", subDir);
        }

        static bool IsUnsigned(string type)
        {
            return type == "uint" || type == "ushort" || type == "ulong" || type == "byte";
        }
        
        
        static string Number(string type, string number)
        {
            switch (type)
            {
                case "decimal": return $"{number}m";
                case "float":   return $"{number}f";
                case "double":  return $"{number}d";
            }
            return $"({type}){number}";
        }
        static string Zero(string type)
        {
            return Number(type, "0");
        }
       

        public string Namespace { get; set; }
    }
}