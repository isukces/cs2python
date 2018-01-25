# cs2python
C# to Python transcompiler. It veary early stage of code. Sample conversion done by cs2python is shown below.

```csharp
using Lang.Python;
namespace Foo {
    [IgnoreNamespace]
    public class Demo{
        public Demo(int i) {
            publicField = 1;
            protectedField = 2;
            privateField = i;
        }
        public int publicField;
        protected int protectedField;
        private int privateField;
    }
}
```

is converted into
```python
class Demo:
    def __init__(self, i):
        self.publicField = 1
        self._protectedField = 2
        self.__privateField = i
```
