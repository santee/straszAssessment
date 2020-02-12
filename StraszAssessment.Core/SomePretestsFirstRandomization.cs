using System;
using System.Collections.Generic;
using System.Linq;

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
            //create a copy
            var result = source.ToList();

            //shuffle
            for (var i = result.Count - 1; i > 0; i--)
            {
                var j = this.random.Next(0, i + 1);
                var temp = result[i];
                result[i] = result[j];
                result[j] = temp;
            }

            return result;
        }
    }
}