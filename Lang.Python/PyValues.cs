﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lang.Python
{
    public class PyValues
    {
      
 
        private static int _SingleQuoteEscapedCharsCount(string x)
        {
            int i = 0;
            foreach (var c in x)
                if (c == '\\' || c == '\'')
                    i++;
            return i;
        }


        public static string PyStringEmit(string txt)
        {
            if (txt == null)
                return "null";
            if (txt.Length == 0)
                return "''";
            {
                var a1 = _InvisibleCharsCount(txt);
                if (a1 > 0)
                    return EscapeDoubleQuote(txt);
                //if (txt.IndexOf("'")>0)
                //    return EscapeDoubleQuote(txt);
                var a2 = _SingleQuoteEscapedCharsCount(txt);
                var a3 = _DoubleQuoteEscapedCharsCount(txt);
                if (a2 <= a3)
                    return EscapeSingleQuote(txt);
                return EscapeDoubleQuote(txt);
            }



            // http://www.Py.net/manual/en/language.types.string.Py#language.types.string.syntax.single
 
        }
       
        public static bool TryGetPyStringValue(string a, out string x)
        {
            const string bs = "\\";
            x               = null;
            if (a == null) return false;
            a = a.Trim();
            if (a.Length < 2)
                return false;
            if (a.StartsWith("'") && a.EndsWith("'"))
            {
                a = a.Substring(1, a.Length - 2);
                if (a.Length == 0)
                {
                    x = "";
                    return true;
                }
                x = a
                    .Replace(bs + "'", "")
                    .Replace(bs + bs,  "");
                if (a.IndexOf(bs) > 0 || a.IndexOf("'") > 0)
                    return false;
                x = a
                    .Replace(bs + "'", "'")
                    .Replace(bs + bs,  bs);

                return true;

            }
            x = null;
            return false;
        }
        // Private Methods 

        private static int _DoubleQuoteEscapedCharsCount(string x)
        {
            int i = 0;
            foreach (var c in x)
            {
                if (c == '\\' || c == '"' || c == '\n' || c == '\r' || c == '\t' || c == '\v' || c == _ESCchar || c == '\f' || c == '$')
                    i++;
            }
            return i;
        }
        const          char _ESCchar = (char)27;
        private static int  _InvisibleCharsCount(string x)
        {
            return x.Where(i => i < ' ').Count();
        }

        
        public static string Dec2Oct(int number)
        {
            string o = "";
            while (number != 0)
            {
                var b  = number % 8;
                o      = b.ToString() + o;
                number = number / 8;
            }
            return "0" + o;
        }

        private static string EscapeDoubleQuote(string x)
        {
            if (x == null)
                return "null";
            if (x.Length == 0)
                return "\"\"";
            /*
             * \n 	linefeed (LF or 0x0A (10) in ASCII)
\r 	carriage return (CR or 0x0D (13) in ASCII)
\t 	horizontal tab (HT or 0x09 (9) in ASCII)
\v 	vertical tab (VT or 0x0B (11) in ASCII) (since Py 5.2.5)
\e 	escape (ESC or 0x1B (27) in ASCII) (since Py 5.4.0)
\f 	form feed (FF or 0x0C (12) in ASCII) (since Py 5.2.5)
\\ 	backslash
\$ 	dollar sign
\" 	double-quote
\[0-7]{1,3} 	the sequence of characters matching the regular expression is a character in octal notation
\x[0-9A-Fa-f]{1,2} 	the sequence of characters matching the regular expression is a character in hexadecimal notation 
             */
            x = x.Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r")
                .Replace("\t", "\\t")
                .Replace("\v", "\\v")
                .Replace(_ESC, "\\e")
                .Replace("\f", "\\f")
                .Replace("$",  "\\$");
            return "\"" + x + "\"";
        }

        private static string EscapeSingleQuote(string x)
        {
            return "'" + x.Replace("\\", "\\\\").Replace("'", "\\'") + "'";
        }

        static readonly string _ESC = ((char)27).ToString();
    }
}