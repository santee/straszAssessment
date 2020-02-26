using System;
using System.Collections.Generic;
using System.Linq;

namespace StraszAssessment.Core
{
    /// <summary>
    /// Randomizes the list that it puts N pretests in the beginning. O(N)
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

            //create a shuffled copy
            var result = this.ShuffleList(source);
            this.PutPretestsInTheBeginning(result);

            return result;
        }

        private void PutPretestsInTheBeginning(List<TestletItem> result)
        {
            var pretestIds = FindPretestsIndices(result);

            if (pretestIds.Count < startWithNPretests)
            {
                throw new InvalidOperationException(NotEnoughPretestsError);
            }

            //put pretests in the beginning
            for (var i = 0; i < startWithNPretests; i++)
            {
                //take a pretest id from a tail
                var pretestId = pretestIds.Pop();
                if (result[i].TestletItemType != TestletItemTypeEnum.Pretest)
                {
                    Swap(result, i, pretestId);
                }
            }
        }

        private static Stack<int> FindPretestsIndices(IReadOnlyList<TestletItem> source)
        {
            var result = new Stack<int>(source.Count);
            for (var i = 0; i < source.Count; i++)
            {
                if (source[i].TestletItemType == TestletItemTypeEnum.Pretest)
                {
                    result.Push(i);
                }
            }

            return result;
        }

        private List<TestletItem> ShuffleList(IReadOnlyList<TestletItem> source)
        {
            var result = source.ToList();
            for (var i = result.Count - 1; i >= 0; i--)
            {
                var j = this.random.Next(0, i + 1);
                Swap(result, i, j);
            }

            return result;
        }

        private static void Swap<T>(IList<T> source, int index0, int index1)
        {
            var temp = source[index0];
            source[index0] = source[index1];
            source[index1] = temp;
        }
    }
}