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

        private const string NotEnoughPretestsError = "Not enough pretests in the data provided";

        public SomePretestsFirstRandomization(int startWithNPretests, Random random)
        {
            this.startWithNPretests = startWithNPretests;
            this.random = random;
        }

        public List<TestletItem> Randomize(IReadOnlyList<TestletItem> source)
        {
            if (source.Count < startWithNPretests)
            {
                throw new InvalidOperationException(NotEnoughPretestsError);
            }

            //create a copy
            var result = source.ToList();
            var pretestIds = new Queue<int>(source.Count);

            //shuffle
            for (var i = result.Count - 1; i >= 0; i--)
            {
                var j = this.random.Next(0, i + 1);
                var temp = result[i];
                result[i] = result[j];
                result[j] = temp;

                if (result[i].TestletItemType == TestletItemTypeEnum.Pretest)
                {
                    //store pretest id for a future use
                    pretestIds.Enqueue(i);
                }
            }

            if (pretestIds.Count < startWithNPretests)
            {
                throw new InvalidOperationException(NotEnoughPretestsError);
            }

            //put pretests in the beginning
            for (var i = 0; i < startWithNPretests; i++)
            {
                var pretestId = pretestIds.Dequeue();
                if (result[i].TestletItemType != TestletItemTypeEnum.Pretest)
                {
                    var temp = result[i];
                    result[i] = result[pretestId];
                    result[pretestId] = temp;
                }
            }

            return result;
        }
    }
}