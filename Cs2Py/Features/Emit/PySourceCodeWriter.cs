﻿using System;
using System.Text;

namespace Cs2Py.Emit
{
    public class PySourceCodeWriter
    {
        public PySourceCodeWriter()
        {
            code.AppendLine("<?php");
            IntentString = "";
        }

        // Public Methods 

        public void AppendLastLine(string x)
        {
            code = new StringBuilder(code.ToString().TrimEnd() + x);
        }

        public void Clear()
        {
            code.Clear();
        }

        public void CloseLn(string x)
        {
            DecIndent();
            Write(x + "\r\n");
        }

        public void DecIndent()
        {
            Intent--;
        }

        public void Direct(Func<string, string> a)
        {
            var txt = a(code.ToString());
            code    = new StringBuilder(txt);

        }

        public string GetCode(bool pure = false)
        {
            if (pure)
                return code.ToString();
            return code + "?>";
        }

        public void IncIndent()
        {
            Intent++;
        }

        public void OpenLn(string x)
        {
            Write(x + "\r\n");
            IncIndent();
        }

        public void OpenLnF(string x, params object[] p)
        {
            Write(string.Format(x, p) + "\r\n");
            IncIndent();
        }

        public override string ToString()
        {
            return GetCode();
        }

        public void WriteF(string x, params object[] p)
        {
            Write(string.Format(x, p));
        }

        public void WriteLn(string x)
        {
            Write(x + "\r\n");
        }

        public void WriteLnF(string x, params object[] p)
        {
            Write(string.Format(x, p) + "\r\n");
        }
        // Protected Methods 

        protected void OnIntentChange()
        {
            IntentString = new string(' ', intent * 4);
        }
        // Private Methods 

        public void Write(string x)
        {
            if (SkipIndent)
                code.Append(x);
            else
                code.Append(IntentString + x);
            SkipIndent = false;
        }

        protected StringBuilder code = new StringBuilder();
        int                     intent;
        public bool             SkipIndent;

        public int Intent
        {
            get
            {
                return intent;
            }
            set
            {
                if (intent == value) return;
                if (value < 0)
                    throw new ArgumentException();
                intent = value;
                OnIntentChange();
            }
        }

        public string IntentString { get; set; }

        public int Length => code.Length;
    }
}