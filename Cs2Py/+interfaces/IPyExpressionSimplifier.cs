namespace Cs2Py
{
    public interface IPyExpressionSimplifier
    {
        IPyValue Simplify(IPyValue src);
    }
}