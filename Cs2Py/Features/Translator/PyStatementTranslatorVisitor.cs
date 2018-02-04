using System;
using System.Collections.Generic;
using System.Linq;
using Cs2Py.CSharp;
using Cs2Py.Source;
using JetBrains.Annotations;

namespace Cs2Py.Translator
{
    public class PyStatementTranslatorVisitor : CSharpBaseVisitor<IPyStatement[]>, IStatementTranslator
    {
        public PyStatementTranslatorVisitor(TranslationState state)
        {
            _state = state;
        }

        private static IPyStatement[] MkArray(IPyStatement x)
        {
            return new[] {x};
        }

        private static IPyStatement[] MkArray(IPyValue x)
        {
            return new IPyStatement[] {new PyExpressionStatement(x)};
        }

        public IPyStatement[] TranslateStatement([NotNull] IStatement x)
        {
            switch (x)
            {
                case null:
                    throw new ArgumentNullException(nameof(x));
                case CSharpBase _:
                    return Visit(x as CSharpBase);
            }

            var trans = new Translator(_state);
            return trans.TranslateStatement(x);
        }


        public IPyValue TransValue(IValue x)
        {
            return new PyValueTranslator(_state).TransValue(x);
        }


        protected override IPyStatement[] VisitAssignExpression(CsharpAssignExpression src)
        {
            var translatedValue = TransValue(src);
            return MkArray(translatedValue);
        }

        protected override IPyStatement[] VisitBreakStatement(BreakStatement src)
        {
            return MkArray(new PyBreakStatement());
        }

        protected override IPyStatement[] VisitCodeBlock(CodeBlock src)
        {
            var res = new PyCodeBlock();
            res.Statements.AddRange(this.TranslateStatements(src.Items));
            return MkArray(res);
        }

        protected override IPyStatement[] VisitContinueStatement(ContinueStatement src)
        {
            return MkArray(new PyContinueStatement());
        }

        protected override IPyStatement[] VisitForEachStatement(ForEachStatement src)
        {
            var                g          = src.VarName;
            var                collection = TransValue(src.Collection);
            var                statement  = this.TranslateStatementOne(src.Statement);
            PyForEachStatement a          = null;
            if (src.ItemType.DotnetType.IsGenericType)
            {
                var gtd = src.ItemType.DotnetType.GetGenericTypeDefinition();
                if (gtd == typeof(KeyValuePair<,>))
                {
                    a = new PyForEachStatement(src.VarName, collection, statement);
                    // $i@Key
                    a.KeyVarname   = src.VarName + "@Key";
                    a.ValueVarname = src.VarName + "@Value";
                }
            }

            if (a == null)
                a = new PyForEachStatement(src.VarName, collection, statement);
            return MkArray(a);
        }

        protected override IPyStatement[] VisitForStatement(ForStatement src)
        {
            var result = new ForTranslator(this).Translate(src);
            return result;
        }

        protected override IPyStatement[] VisitIfStatement(IfStatement src)
        {
            var condition = TransValue(src.Condition);
            var ifTrue    = this.TranslateStatementOne(src.IfTrue);
            var ifFalse   = this.TranslateStatementOne(src.IfFalse);
            var a         = new PyIfStatement(condition, ifTrue, ifFalse);
            return MkArray(a);
        }

        protected override IPyStatement[] VisitIncrementDecrementExpression(IncrementDecrementExpression src)
        {
            var o = TransValue(src.Operand);
            var a = new PyIncrementDecrementExpression(o, src.Increment, src.Pre);
            return MkArray(a);
        }


        protected override IPyStatement[] VisitLocalDeclarationStatement(LocalDeclarationStatement src)
        {
            var s = new List<IPyStatement>();
            foreach (var i in src.Declaration.Declarators)
            {
                // to jest przypadek z c# 'int x;', dla Py można to pominąć
                if (i.Value == null)
                    continue;
                if (i.Value is UnknownIdentifierValue)
                    throw new NotImplementedException();
                var l  = new PyVariableExpression(i.Name, PyVariableKind.Local);
                var r  = TransValue(i.Value);
                var tt = new PyAssignExpression(l, r);
                s.Add(new PyExpressionStatement(tt));

                //var r = new PyAssignVariable( PyVariableExpression.AddDollar(i.Name), false );
                //// r.Name = "$" + i.Name;
                //r.Value = TV(i.Value);
                //s.Add(r);
            }

            return s.ToArray();
        }

        protected override IPyStatement[] VisitMethodCallExpression(CsharpMethodCallExpression src)
        {
            var a = TransValue(src);
            return MkArray(a);
            //var u = new DotnetMethodCallTranslator(state);

            //PyMethodStatement PyMethod;
            //IPyValue simplaeValue;
            //bool ok = u.TryReplaceByPyDirectCall(src, out PyMethod, out simplaeValue);
            //if (ok)
            //{
            //    if (PyMethod == null)
            //        throw new NotSupportedException("smooth horse");
            //    return MkArray(PyMethod);
            //}
            //var mi = src.MethodInfo;

            //{
            //    if (mi.IsStatic)
            //    {
            //        throw new Exception(src.GetType().FullName);
            //    }
            //    else
            //    {
            //        System.Diagnostics.Debug.Assert(src.TargetObject != null);
            //        var PyTargetObject = TV(src.TargetObject);
            //        var method = new PyMethodStatement(src.MethodInfo.Name);
            //        method.TargetObject = TV(src.TargetObject);
            //        new PyValueTranslator(state).CopyArguments(src.Arguments, method);
            //        return MkArray(method);
            //    }
            //}

            //if (state.CurrentType == src.MethodInfo.ReflectedType)
            //{
            //    var method = new PyMethodStatement(src.MethodInfo.Name);
            //    method.TargetObject = new PyThisExpression();
            //    new PyValueTranslator(state).CopyArguments(src.Arguments, method);
            //    return MkArray(method);
            //}
            //throw new Exception(src.GetType().FullName);
        }

        protected override IPyStatement[] VisitReturnStatement(ReturnStatement src)
        {
            var value  = src.ReturnValue == null ? null : TransValue(src.ReturnValue);
            var result = new PyReturnStatement(value);
            return MkArray(result);
        }

        protected override IPyStatement[] VisitSwitchStatement(CsharpSwitchStatement src)
        {
            var switchStatement = new PySwitchStatement
            {
                Expression = TransValue(src.Expression)
            };
            foreach (var sec in src.Sections)
            {
                var section = new PySwitchSection
                {
                    Labels = sec.Labels.Select(q => new PySwitchLabel
                    {
                        Value     = q.Expression == null ? null : TransValue(q.Expression),
                        IsDefault = q.IsDefault
                    }).ToArray()
                };
                var statements = this.TranslateStatements(sec.Statements);
                var block      = new PyCodeBlock();
                block.Statements.AddRange(statements);
                section.Statement = PyCodeBlock.Reduce(block);
                switchStatement.Sections.Add(section);
            }

            return MkArray(switchStatement);
        }

        protected override IPyStatement[] VisitVariableDeclaration(VariableDeclaration src)
        {
            //throw new Exception("DELETE THIS ??????");
            var s = new List<IPyStatement>();
            foreach (var i in src.Declarators)
            {
                var l  = new PyVariableExpression(i.Name, PyVariableKind.Local);
                var r  = TransValue(i.Value);
                var tt = new PyAssignExpression(l, r);
                s.Add(new PyExpressionStatement(tt));

                //var r = new PyAssignVariable(PyVariableExpression.AddDollar(i.Name), false);
                //r.Value = TV(i.Value);
                //s.Add(r);
            }

            return s.ToArray();
        }


        protected override IPyStatement[] VisitWhileStatement(WhileStatement src)
        {
            var c = TransValue(src.Condition);
            var s = this.TranslateStatementOne(src.Statement);
            var a = new PyWhileStatement(c, s);
            return MkArray(a);
        }

        protected override IPyStatement[] VisitWithStatement(CsharpWithStatement src)
        {
            if (src.Variables.Length == 0)
                throw new NotSupportedException("with statement with no variables");
            PyUsingStatement owner  = null;
            PyUsingStatement result = null;
            for (var index = 0; index < src.Variables.Length; index++)
            {
                var ii        = src.Variables[index];
                var nextLevel = new PyUsingStatement
                {
                    Variable = new PyUsingStatementVariable
                    {
                        Name  = ii.Name,
                        Value = TransValue(ii.Value)
                    }
                };
                if (owner == null)
                    result = nextLevel;
                else
                    owner.Statements.Add(nextLevel);

                owner = nextLevel;
            }

            if (result == null)
                throw new Exception("Internal exception");
            var stats = this.TranslateStatements(src.Statements);
            result.Statements.AddRange(stats);
            /*
            foreach (var i in src.Statements)
            {
                var ii = CastOrThrow<CSharpBase>(i);
                var b  = Visit(ii);
                var bb = CastOrThrow<PyStatementBase>(b);
                result.Statements.Add(bb);
            }
            */

            return new[] {result};
        }

        private readonly TranslationState _state;
    }
}