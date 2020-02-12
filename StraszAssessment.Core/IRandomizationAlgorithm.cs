using System.Collections.Generic;

namespace StraszAssessment.Core
{
    public interface IRandomizationAlgorithm
    {
        List<TestletItem> Randomize(IReadOnlyList<TestletItem> source);
    }
}