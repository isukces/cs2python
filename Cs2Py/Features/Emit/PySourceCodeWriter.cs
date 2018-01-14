using System;
using System.Text;

namespace Cs2Py.Emit
{
    public class PySourceCodeWriter
    {
        public PySourceCodeWriter()
        {
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

        public string GetCode()
        {
            return code.ToString();
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
        // Private Methods 

        public void Write(string x)
        {
            if (SkipIndent)
                code.Append(x);
            else
                code.Append(IntentString + x);
            SkipIndent = false;
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

        public int Intent
        {
            get => intent;
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

        protected StringBuilder code = new StringBuilder();
        private   int           intent;
        public    bool          SkipIndent;
    }
}