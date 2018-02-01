namespace Lang.Python.Numpy
{
    public enum NumpyArrayOrder
    {
        K,
        A,
        C,
        F
        /*
        order : {‘K’, ‘A’, ‘C’, ‘F’}, optional
    
    Specify the memory layout of the array. If object is not an array, the newly created array will be in C order (row major) unless ‘F’ is specified, in which case it will be in Fortran order (column major). If object is an array the following holds.
    
    order	no copy	copy=True
    ‘K’	unchanged	F & C order preserved, otherwise most similar order
    ‘A’	unchanged	F order if input is F and not C, otherwise C order
    ‘C’	C order	C order
    ‘F’	F order	F order
    */
    }
}