using System.Collections.Generic;

namespace StraszAssessment.Core
{
    public class Testlet
    {
        public string TestletId { get; }

        private readonly List<TestletItem> items;

        private readonly IRandomizationAlgorithm randomizationAlgorithm;

        public Testlet(string testletId, List<TestletItem> items, IRandomizationAlgorithm randomizationAlgorithm)
        {
            TestletId = testletId;
            this.items = items;
            this.randomizationAlgorithm = randomizationAlgorithm;
        }

        public List<TestletItem> Randomize()
        {
            return this.randomizationAlgorithm.Randomize(this.items);
        }
    }
}