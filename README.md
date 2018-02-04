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
## For loop support

Cs2Python can automatically convert c# for loop into python for loop (similar to c# foreach loop).
```csharp
for(int i=0; i< 10; i++)
    Console.WriteLine(i);
```
is converted into
```python
for i in range(10):
    print(i)   
```
## Numpy support

In order to simulate Numpy module we can use C# classes from `Lang.Python.Numpy` namespace. I.e.


```csharp
using Lang.Python;
using Lang.Python.Numpy;
namespace Foo {
    [IgnoreNamespace]
    public class Demo{
        public Test() {
            var tmp  = Np.Array1(new[] {1.0, 2, 3});
        }
    }
}
```
and the result is
```python
class Demo:
    @staticmethod
    def Test(cls):
        tmp = numpy.array([1., 2, 3])
```

Cs2Python tries to be 'strongly typed'. It provides a lot of classes derived from NdArray. It also provides specialized methods like `Np.Array1`, `Np.Array2`, `Np.Array3`, `Np.Array4` and so on in order to create 1,2,3,4.... dimensional arrays.
