﻿using System;
using System.Linq;
using StraszAssessment.Core;
using Xunit;

namespace StraszAssessment.Tests
{
    public class RandomizationTests
    {
        [Theory(DisplayName = "Randomized data starts with proper count of pretests and is actually randomized")]
        [InlineData(10, 4, 2, 42)]
        [InlineData(10, 4, 2, 100)]
        [InlineData(10, 4, 2, 16)]
        [InlineData(10, 4, 2, 60)]
        [InlineData(10, 4, 4, 60)]
        [InlineData(4, 4, 2, 42)]
        [InlineData(4, 4, 4, 42)]
        public void PretestsRandomizationAlgorithm(int totalCount, int pretestsCount, int startWithNPretests, int seed)
        {
            //use seed so tests are not fragile
            var random = new Random(seed);
            var algorithm = new SomePretestsFirstRandomization(startWithNPretests, random);

            var testData = Enumerable.Range(0, totalCount)
                .Select(x => new TestletItem(x.ToString(), TestletItemTypeEnum.Operational))
                .ToList();

            for (var i = pretestsCount - 1; i >= 0; i--)
            {
                testData[i] = new TestletItem("pretest" + i, TestletItemTypeEnum.Pretest);
            }

            var randomized = algorithm.Randomize(testData);

            Assert.Equal(totalCount, randomized.Count);
            Assert.True(totalCount == randomized.Distinct().Count(), "Some values are used more than once");
            Assert.True(randomized.Take(startWithNPretests).All(x => x.TestletItemType == TestletItemTypeEnum.Pretest), "Doesn't start with proper number of pretests");
            Assert.False(randomized.SequenceEqual(testData), "Randomized sequence equals source data");
        }
    }
}