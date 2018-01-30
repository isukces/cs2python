using Cs2Py.Compilation;
using Xunit;

namespace Lang.Python.Tests
{
    public class GenericTypeNameTests
    {
        private static void Check(GenericTypeName a, string name, int genericArguments = 0)
        {
            CheckNested(a, name, genericArguments);
            Assert.Null(a.DeclaredIn);
        }

        private static void CheckNested(GenericTypeName a, string name, int genericArguments = 0)
        {
            Assert.NotNull(a);
            Assert.Equal(name,             a.Name);
            Assert.Equal(genericArguments, a.Args.Length);
        }

        [Theory]
        [InlineData("int")]
        [InlineData("int ")]
        [InlineData(" int ")]
        public void T01_Should_parse_simple_name(string x)
        {
            var a = GenericTypeName.FromString(x);
            Check(a, "int");
            Assert.Null(a.DeclaredIn);
        }

        [Theory]
        [InlineData("List<int>")]
        [InlineData(" List < int >  ")]
        public void T02_Should_parse_generic_list_name(string x)
        {
            var a = GenericTypeName.FromString(x);
            Check(a,         "List", 1);
            Check(a.Args[0], "int");
            Assert.Null(a.DeclaredIn);
            Assert.Equal("List`1", a.GetGenericName());
        }

        [Theory]
        [InlineData("Dictionary<int,string>")]
        [InlineData(" Dictionary < int , string >  ")]
        [InlineData(" Dictionary < int , string>  ")]
        public void T03_Should_parse_generic_dictionary_name(string x)
        {
            var a = GenericTypeName.FromString(x);

            Check(a,         "Dictionary", 2);
            Check(a.Args[0], "int");
            Check(a.Args[1], "string");
            Assert.Equal("Dictionary`2", a.GetGenericName());
        }
        
        [Theory]
        [InlineData("System.Collections.Generic.Dictionary<int,string>")]
        [InlineData(" System.Collections.Generic.Dictionary < int , string >  ")]
        [InlineData(" System.Collections . Generic.Dictionary < int , string>  ")]
        public void T04_Should_parse_generic_dictionary_name_with_full_name(string x)
        {
            var a = GenericTypeName.FromString(x);

            Check(a,         "System.Collections.Generic.Dictionary", 2);
            Check(a.Args[0], "int");
            Check(a.Args[1], "string");
            Assert.Equal("System.Collections.Generic.Dictionary`2", a.GetGenericName());
        }

        [Theory]
        [InlineData("Master.Nested")]
        [InlineData(" Master. Nested ")]
        [InlineData(" Master .Nested ")]
        [InlineData(" Master . Nested ")]
        public void T05_Should_parse_nested_name(string x)
        {
            var a = GenericTypeName.FromString(x);
            Check(a, "Master.Nested");
            Assert.Equal("Master.Nested", a.GetGenericName());
        }

        [Theory]
        [InlineData("System.Collections.Generic.Dictionary<int, string>.KeyCollection")]
        [InlineData("System .Collections.Generic.Dictionary<int, string>.KeyCollection")]
        [InlineData("System . Collections.Generic.Dictionary<int, string>.KeyCollection")]
        [InlineData("System . Collections.Generic.Dictionary<int,string>.KeyCollection")]
        [InlineData("System . Collections.Generic.Dictionary<int,string> .KeyCollection")]
        [InlineData("System . Collections.Generic.Dictionary<int,string> . KeyCollection")]
        [InlineData("System . Collections.Generic.Dictionary<int,string > . KeyCollection")]
        public void T06_Should_parse_nested_generic_name(string x)
        {
            var a = GenericTypeName.FromString(x);
            CheckNested(a, "KeyCollection");
            Check(a.DeclaredIn, "System.Collections.Generic.Dictionary", 2);
            Check(a.DeclaredIn.Args[0], "int");
            Check(a.DeclaredIn.Args[1], "string");
            Assert.Equal("System.Collections.Generic.Dictionary`2+KeyCollection", a.GetGenericName());
        }
    }
}