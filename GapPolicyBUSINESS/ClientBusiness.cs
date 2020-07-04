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
    public class ClientBusiness
    {
        Manager manager = new Manager();
        public List<Client> getClients() {
            dynamic DynamicObj = new
            {
                Identification = string.Empty,
                Name = string.Empty,
                PhoneNumber = string.Empty,
                Mail = string.Empty,
                Address = string.Empty,
                ModificationUser = string.Empty,
                Action = "INFO"
            };

            string resultJson = manager.ExeDBQuery(DynamicObj, "sp_Cliente_Manager");
            List<Client> result;
            if (resultJson != "")
                result = JsonConvert.DeserializeObject<List<Client>>(resultJson);
            else
                result = new List<Client>();
            return result;
        }
    }
}
