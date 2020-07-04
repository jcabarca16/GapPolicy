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
        public List<Client> GetClients() {
            try {
                dynamic DynamicObj = new
                {
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
            catch (Exception ex) { throw new Exception(ex.Message); }          
        }
        public List<Client> GetClientIdentification(string Identification)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    Identification,
                    Action = "INFO-ID"
                };

                string resultJson = manager.ExeDBQuery(DynamicObj, "sp_Cliente_Manager");
                List<Client> result;
                if (resultJson != "")
                    result = JsonConvert.DeserializeObject<List<Client>>(resultJson);
                else
                    result = new List<Client>();
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public string DeleteClients(string Identification)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    Identification,
                    Action = "DELETE"
                };

                return manager.ExeDBNonQuery(DynamicObj, "sp_Cliente_Manager"); ;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public string InsertClients(Client client)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    client.Identification,
                    client.Name,
                    client.PhoneNumber,
                    client.Mail,
                    client.Address,
                    ModificationUser = "206480980",
                    Action = "INSERT"
                };

                return manager.ExeDBNonQuery(DynamicObj, "sp_Cliente_Manager"); ;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public string UpdateClients(Client client)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    client.Identification,
                    client.Name,
                    client.PhoneNumber,
                    client.Mail,
                    client.Address,
                    ModificationUser = "206480980",
                    Action = "UPDATE"
                };

                return manager.ExeDBNonQuery(DynamicObj, "sp_Cliente_Manager"); ;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
