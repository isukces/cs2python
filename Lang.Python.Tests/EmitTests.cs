using Cs2Py;
using Cs2Py.Emit;
using Cs2Py.Source;
using Xunit;

namespace Lang.Python.Tests
{
    public class EmitTests
    {
        private static void WriteCode(IEmitable emitable, string expected)
        {
            var writer = new PySourceCodeWriter();
            emitable.Emit(new PySourceCodeEmiter(), writer, new PyEmitStyle());
            var code = writer.GetCode();
            Assert.Equal(expected.Trim(), code.Trim());
        }

        private static string WriteCode(IPyValue pyConstValue)
        {
            return pyConstValue.GetPyCode(new PyEmitStyle());
        }

        [Fact]
        public void T01_Should_emit_const_values()
        {
            var code = WriteCode(new PyConstValue(123));
            Assert.Equal("123", code);
            code = WriteCode(new PyConstValue(123.2230));
            Assert.Equal("123.223", code);
            code = WriteCode(new PyConstValue("Hello"));
            Assert.Equal("'Hello'", code);
        }

        [Fact]
        public void T02_Should_sum()
        {
            var code = WriteCode(new PyBinaryOperatorExpression("+", new PyConstValue(123), new PyConstValue(321)));
            Assert.Equal("123 + 321", code);
        }

        [Fact]
        public void T51_Should_emit_instance_class_method()
        {
            var method = new PyClassMethodDefinition("Foo")
            {
                Kind   = PyMethodKind.ClassInstance,
                Visibility = Visibility.Public
            };
            method.Statements.Add(new PyReturnStatement(new PyConstValue(123)));
            method.Arguments.Add(new PyMethodArgument {Name = "x"});
            WriteCode(method, @"
def Foo(self, x):
    return 123");
        }

        [Fact]
        public void T52_Should_emit_static_class_method()
        {
            var method = new PyClassMethodDefinition("Foo")
            {
                Kind = PyMethodKind.ClassStatic,
                Visibility = Visibility.Public
            };
            method.Statements.Add(new PyReturnStatement(new PyConstValue(123)));
            method.Arguments.Add(new PyMethodArgument {Name = "x"});
            WriteCode(method, @"
@staticmethod
def Foo(cls, x):
    return 123");
        }
    }
}