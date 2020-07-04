using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapPolicyDAO
{
   public class SqlQueryObject
   {
        public string JSonObject { get; set; }
        public string SPName { get; set; }
        public string TypeSP { get; set; }
        public string SqlQuery { get; set; }
        public DataSet Result { get; set; }
        public DataTable Table { get; set; }
        public List<SpParameter> ParameterList { get; set; }
        public bool HasResult { get; set; }
        public SqlDataReader DataReader { get; set; }

    }
}
