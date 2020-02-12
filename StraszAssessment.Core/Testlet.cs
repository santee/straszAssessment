using System.Collections.Generic;

namespace StraszAssessment.Core
{
    public class Testlet
    {
        public string TestletId;
        private List<TestletItem> Items;
        public Testlet(string testletId, List<TestletItem> items)
        {
            TestletId = testletId;
            Items = items;
        }
        public List<TestletItem> Randomize()
        {
            //Items private collection has 6 Operational and 4 Pretest Items. Randomize the order of these items as per the requirement (with TDD)
            //The assignment will be reviewed on the basis of – Tests written first, Correct logic, Well structured & clean readable code.
            return null;
        }
    }
}