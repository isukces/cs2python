﻿using System;
using System.Collections.Generic;
using Cs2Py.Emit;
using JetBrains.Annotations;

namespace Cs2Py.Source
{
    public class PyImportStatement : PySourceBase, IPyStatement
    {
        public PyImportStatement([NotNull] string module, string alias)
        {
            Module = module ?? throw new ArgumentNullException(nameof(module));
            Alias  = alias;
        }

        public void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            writer.WriteLn(GetPyCode());
        }

        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return new ICodeRequest[0];
        }

        public string GetPyCode()
        {
            return string.IsNullOrEmpty(Alias)
                ? $"import {Module}"
                : $"import {Module} as {Alias}";
        }

        public StatementEmitInfo GetStatementEmitInfo(PyEmitStyle style)
        {
            return StatementEmitInfo.Empty;
        }

        public string Module { get; }
        public string Alias  { get; }
    }
}