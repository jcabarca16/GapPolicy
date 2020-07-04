using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapPolicyDAO
{
    public class Policy
    {
        public int Id { set; get; }
        public int Type { set; get; }
        public string Client { set; get; }
        public int Percentage { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public int Period { set; get; }
        public decimal Cost { set; get; }
        public int RiskType { set; get; }
        public string ModificationUser { set; get; }
        public DateTime ModificationDate { set; get; }
    }
}
