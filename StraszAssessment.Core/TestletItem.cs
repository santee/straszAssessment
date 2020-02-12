namespace StraszAssessment.Core
{
    public class TestletItem
    {
        public TestletItem(string itemId, TestletItemTypeEnum testletItemType)
        {
            TestletItemType = testletItemType;
            ItemId = itemId;
        }

        public string ItemId { get; }

        public TestletItemTypeEnum TestletItemType { get; }
    }

    public enum TestletItemTypeEnum
    {
        Pretest = 0,
        Operational = 1
    }
}