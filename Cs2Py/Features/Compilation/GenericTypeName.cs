using System;
using System.Collections.Generic;
using System.Linq;
using Lang.Python;

namespace Cs2Py.Compilation
{
    public class GenericTypeName
    {
        private GenericTypeName(string name, GenericTypeName[] args = null)
        {
            Name = name.Trim();
            Args = args ?? new GenericTypeName[0];
        }

        public string GetGenericName()
        {
            var txt = Args.Length > 0 ? $"{Name}`{Args.Length}" : Name;
            if (DeclaredIn == null)
                return txt;
            txt = DeclaredIn?.GetGenericName() + "." + txt;
            return txt;
        }

        public static GenericTypeName FromString(string x)
        {
            if (string.IsNullOrEmpty(x))
                return null;
            var parser = new Parser(x);
            return parser.Parse();
        }


        public string            Name       { get; }
        public GenericTypeName[] Args       { get; }
        public GenericTypeName   DeclaredIn { get; set; }

        private enum States
        {
            ReadyForTypeName,
            CollectingName,
            NameCollected,
            TypeCompleted
        }

        private class Parser
        {
            public Parser(string text)
            {
                _text  = text;
                _state = States.ReadyForTypeName;
                _stack = new Stack<C>();
            }

            public GenericTypeName Parse()
            {
                if (string.IsNullOrEmpty(_text))
                    return null;
                _current = new C();
                for (_index = 0; _index < _text.Length; _index++)
                {
                    _c = _text[_index];
                    switch (_state)
                    {
                        case States.ReadyForTypeName:
                            ParseReadyForTypeName();
                            break;
                        case States.CollectingName:
                            ParseCollectingName();
                            break;
                        case States.NameCollected:
                            ParseNameCollected();
                            break;
                        case States.TypeCompleted:
                            ParseTypeCompleted();
                            break;
                        default:
                            throw new NotImplementedException(_state.ToString());
                    }
                }

                if (_stack.Count == 0)
                {
                    if (_state == States.CollectingName || _state == States.TypeCompleted || _state ==
                        States.NameCollected)
                        return _current.GetGenericTypeName();
                    throw new NotImplementedException($"Final state {_state}, EMPTY STACK");
                }

                throw new NotImplementedException($"Final state {_state}, stack count {_stack.Count}");
            }

            private void _CloseBracket()
            {
                if (_stack.Count == 0)
                    throw new Exception($"'{_c}' not expected here");
                var owner = _stack.Pop();
                owner.Args.Add(_current);
                _current = owner;
                _state   = States.TypeCompleted;
            }

            private void _OpenBracket()
            {
// otwarcie <
                _stack.Push(_current);
                _current = new C();
                _state   = States.ReadyForTypeName;
            }

            private Exception MakeException(string name)
            {
                return new NotImplementedException($"'{_c}' in {name} at {_index} in '{_text}'");
            }

            private void ParseCollectingName()
            {
                if (_current.AddName(_c))
                    return;
                switch (_c)
                {
                    case '<':
                        _OpenBracket();
                        return;
                    case '>':
                        _CloseBracket();
                        return;
                    case ',':
                        _CloseBracket();
                        _OpenBracket();
                        return;
                }

                throw MakeException(nameof(ParseCollectingName));
            }

            private void ParseNameCollected()
            {
                switch (_c)
                {
                    case '<':
                        _OpenBracket();
                        return;
                    case '>':
                        _CloseBracket();
                        return;
                    case ',':
                        _CloseBracket();
                        _OpenBracket();
                        return;
                }

                throw MakeException(nameof(ParseNameCollected));
            }

            private void ParseReadyForTypeName()
            {
                if (char.IsWhiteSpace(_c))
                    return;
                if (_current.AddName(_c))
                {
                    _state = States.CollectingName;
                    return;
                }

                throw MakeException(nameof(ParseReadyForTypeName));
            }

            private void ParseTypeCompleted()
            {
                if (char.IsWhiteSpace(_c))
                    return;
                if (_c == '.')
                {
                    var n    = new C {DeclaredIn = _current};
                    _current = n;
                    _state   = States.ReadyForTypeName;
                    return;
                }

                throw MakeException(nameof(ParseTypeCompleted));
            }

            private int _index;

            private char _c;

            private readonly string   _text;
            private          States   _state;
            private readonly Stack<C> _stack;
            private          C        _current;
        }

        private class C
        {
            public bool AddName(char c)
            {
                if (char.IsWhiteSpace(c))
                    c = ' ';
                if (string.IsNullOrEmpty(Name) || Name.Trim().Last() == '.')
                {
                    if (char.IsDigit(c))
                        throw new Exception("Type name cannot start from digit");
                    if (c == '.')
                        throw new Exception("Type name cannot start from dot");
                }

                if (c == ' ' || c == '.' || char.IsLetterOrDigit(c) || c == '_')
                {
                    Name += c;
                    return true;
                }

                return false;
            }

            public GenericTypeName GetGenericTypeName()
            {
                var a          = Args.MapToList(q => q.GetGenericTypeName());
                var declaredin = DeclaredIn?.GetGenericTypeName();
                return new GenericTypeName(Name.Replace(" ", ""), a.ToArray())
                {
                    DeclaredIn = declaredin
                };
            }

            public string  Name       { get; set; } = "";
            public List<C> Args       { get; }      = new List<C>();
            public C       DeclaredIn { get; set; }
        }
    }
}