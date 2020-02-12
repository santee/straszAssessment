using System.Collections.Generic;

namespace StraszAssessment.Core
{
    public interface IRandomizationAlgorithm
    {
        List<T> Randomize<T>(IReadOnlyList<T> source);
    }
}