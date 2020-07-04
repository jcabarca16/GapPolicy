using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
