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
    public class PolicyBusiness
    {
        Manager manager = new Manager();
        public List<Policy> GetPolicy()
        {
            try
            {
                dynamic DynamicObj = new
                {
                    Action = "INFO"
                };

                string resultJson = manager.ExeDBQuery(DynamicObj, "sp_Policy_Manager");
                List<Policy> result;
                if (resultJson != "")
                    result = JsonConvert.DeserializeObject<List<Policy>>(resultJson);
                else
                    result = new List<Policy>();
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<Policy> GetPolicyId(string Id)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    Id,
                    Action = "INFO-ID"
                };

                string resultJson = manager.ExeDBQuery(DynamicObj, "sp_Policy_Manager");
                List<Policy> result;
                if (resultJson != "")
                    result = JsonConvert.DeserializeObject<List<Policy>>(resultJson);
                else
                    result = new List<Policy>();
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public string DeletePolicy(int Id)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    Id,
                    Action = "DELETE"
                };

                return manager.ExeDBNonQuery(DynamicObj, "sp_Policy_Manager"); ;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public string InsertPolicy(Policy Policy)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    Policy.Id,
                    Policy.Type,
                    Policy.Client,
                    Policy.Percentage,
                    Policy.StartDate,
                    Policy.EndDate,
                    Policy.Period,
                    Policy.Cost,
                    Policy.RiskType,
                    ModificationUser = "206480980",
                    Action = "INSERT"
                };

                return manager.ExeDBNonQuery(DynamicObj, "sp_Policy_Manager"); ;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public string UpdatePolicy(Policy Policy)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    Policy.Id,
                    Policy.Type,
                    Policy.Client,
                    Policy.Percentage,
                    Policy.StartDate,
                    Policy.EndDate,
                    Policy.Period,
                    Policy.Cost,
                    Policy.RiskType,
                    ModificationUser = "206480980",
                    Action = "UPDATE"
                };

                return manager.ExeDBNonQuery(DynamicObj, "sp_Policy_Manager"); ;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<Client> GetClients()
        {
            try
            {
                dynamic DynamicObj = new
                {
                    Action = "GETCLIENTS"
                };

                string resultJson = manager.ExeDBQuery(DynamicObj, "sp_Policy_Manager");
                List<Client> result;
                if (resultJson != "")
                    result = JsonConvert.DeserializeObject<List<Client>>(resultJson);
                else
                    result = new List<Client>();
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<PolicyCatalog> GetPolicyTypes()
        {
            try
            {
                dynamic DynamicObj = new
                {
                    Action = "GETTYPES"
                };

                string resultJson = manager.ExeDBQuery(DynamicObj, "sp_Policy_Manager");
                List<PolicyCatalog> result;
                if (resultJson != "")
                    result = JsonConvert.DeserializeObject<List<PolicyCatalog>>(resultJson);
                else
                    result = new List<PolicyCatalog>();
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
