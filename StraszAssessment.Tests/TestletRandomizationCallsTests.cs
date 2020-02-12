using System.Collections.Generic;
using Moq;
using StraszAssessment.Core;
using Xunit;

namespace StraszAssessment.Tests
{
    public class TestletRandomizationCallsTests
    {
        [Fact(DisplayName = "Randomization algorithm is called and used for randomization within a testlet")]
        public void AlgorithmIsCalled()
        {
            var testletMock = new Mock<IRandomizationAlgorithm>();
            var returnValue = new List<TestletItem>();
            testletMock
                .Setup(x => x.Randomize(It.IsAny<IReadOnlyList<TestletItem>>()))
                .Returns(returnValue);

            var testlet = new Testlet("test", new List<TestletItem>(), testletMock.Object);
            var result = testlet.Randomize();

            Assert.Equal(returnValue, result);
            testletMock.Verify(x => x.Randomize(It.IsAny<IReadOnlyList<TestletItem>>()), Times.Once);
        }
    }
}