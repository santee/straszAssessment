using System;
using System.Collections.Generic;

namespace StraszAssessment.Core
{
    /// <summary>
    /// Randomizes the list that it puts N pretests in the beginning
    /// </summary>
    public class SomePretestsFirstRandomization : IRandomizationAlgorithm
    {
        private readonly int startWithNPretests;
        private readonly Random random;

        public SomePretestsFirstRandomization(int startWithNPretests, Random random)
        {
            this.startWithNPretests = startWithNPretests;
            this.random = random;
        }

        public List<TestletItem> Randomize(IReadOnlyList<TestletItem> source)
        {
            throw new System.NotImplementedException();
        }
    }
}