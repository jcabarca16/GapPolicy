using System;

namespace GapPolicyDAO
{
    public class PolicyCatalog
    {
        public int Id { set; get; }
        public string Description { set; get; }
        public string Type { set; get; }
        public string ModificationUser { set; get; }
        public DateTime ModificationDate { set; get; }
    }
}
