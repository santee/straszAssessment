namespace StraszAssessment.Core
{
    public class TestletItem
    {
        public string ItemId { get; set; } 
        public TestletItemTypeEnum TestletItemType { get; set;  }
    }
    public enum TestletItemTypeEnum
    {
        Pretest = 0,
        Operational = 1
    }
}