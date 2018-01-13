namespace Cs2Py
{
    public interface IPyClassMember
    {
        Visibility Visibility { get; }
        bool       IsStatic   { get; }
    }
}