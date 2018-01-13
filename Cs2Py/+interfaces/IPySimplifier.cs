namespace Cs2Py
{
    public interface IPySimplifier:IPyExpressionSimplifier
    {
     
        IPyStatement Simplify(IPyStatement src);
    }
}