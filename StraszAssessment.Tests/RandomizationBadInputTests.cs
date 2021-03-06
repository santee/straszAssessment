﻿using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using StraszAssessment.Core;
using Xunit;

namespace StraszAssessment.Tests
{
    public class RandomizationBadInputTests
    {
        public static IEnumerable<object[]> GetNotEnoughPretestsTestData()
        {
            //empty array
            yield return new object[] { new List<TestletItem>(), 1 };

            var noPretestsSet = Enumerable.Range(0, 10)
                .Select(x => new TestletItem(x.ToString(), TestletItemTypeEnum.Operational))
                .ToList();

            //no pretests
            yield return new object[] { noPretestsSet.ToList(), 2 };

            //has pretests, but not enough
            var notEnoughPretestsSet = noPretestsSet.ToList();
            notEnoughPretestsSet[4] = new TestletItem("pretest1", TestletItemTypeEnum.Pretest);

            yield return new object[] { notEnoughPretestsSet.ToList(), 2 };
        }

        [Theory(DisplayName = "Test fails when there are not enough pretests")]
        [MemberData(nameof(GetNotEnoughPretestsTestData))]
        public void NotEnoughPretests(List<TestletItem> items, int startWithNPretests)
        {
            var random = new Random(42);
            var testlet = new SomePretestsFirstRandomization(startWithNPretests, random);
            Assert.Throws<InvalidOperationException>(() => testlet.Randomize(items));
        }
    }
}
