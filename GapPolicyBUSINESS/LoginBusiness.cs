using GapPolicyDAL;
using GapPolicyDAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapPolicyBUSINESS
{
    public class LoginBusiness
    {
        Manager manager = new Manager();
        public List<Login> GetCredentials(Login login)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    login.Identification,
                    login.Password
                };

                string resultJson = manager.ExeDBQuery(DynamicObj, "sp_Login_Manager");
                List<Login> result;
                if (resultJson != "")
                    result = JsonConvert.DeserializeObject<List<Login>>(resultJson);
                else
                    result = new List<Login>();
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
