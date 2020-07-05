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
        public string TypeDescrip { set; get; }
        public string Client { set; get; }
        public int Percentage { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public int Period { set; get; }
        public decimal Cost { set; get; }
        public string RiskType { set; get; }
        public string ModificationUser { set; get; }
        public DateTime ModificationDate { set; get; }
        public bool Status { set; get; }
    }
}
