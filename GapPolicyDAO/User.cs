using System;

namespace GapPolicyDAO
{
    public class User
    {
        public string Identification { set; get; }
        public string Name { set; get; }
        public string Password { set; get; }
        public string Mail { set; get; }
        public string ModificationUser { set; get; }
        public DateTime ModificationDate { set; get; }
    }
}
