using System.Collections.Generic;

namespace Lang.Python.Numpy
{
    public struct NdArrayShapeInfo
    {
        public NdArrayShapeInfo(params int[] dimensions)
        {
            Dimensions = dimensions;
            Muls = MakeMultiplicators(dimensions);
        }

        private static int[] MakeMultiplicators(IReadOnlyList<int> dimensions)
        {
            var result = new int[dimensions.Count - 1];
            var m = 1;
            for (var i = 0; i < result.Length; i++)
            {
                m *= dimensions[i];
                result[i] = m;
            }

            return result;
        }

        public IReadOnlyList<int> Muls { get; }

        public IReadOnlyList<int> Dimensions { get; }
    }
}