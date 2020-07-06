using GapPolicyDAL;
using GapPolicyDAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GapPolicyBUSINESS
{
    public class PolicyTypeBusiness
    {
        Manager manager = new Manager();
        public List<PolicyCatalog> GetPolicyType()
        {
            try
            {
                dynamic DynamicObj = new
                {
                    Action = "INFO"
                };

                string resultJson = manager.ExeDBQuery(DynamicObj, "sp_PolicyType_Manager");
                List<PolicyCatalog> result;
                if (resultJson != "")
                    result = JsonConvert.DeserializeObject<List<PolicyCatalog>>(resultJson);
                else
                    result = new List<PolicyCatalog>();
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<PolicyCatalog> GetPolicyTypeId(int Id)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    Id,
                    Action = "INFO-ID"
                };

                string resultJson = manager.ExeDBQuery(DynamicObj, "sp_PolicyType_Manager");
                List<PolicyCatalog> result;
                if (resultJson != "")
                    result = JsonConvert.DeserializeObject<List<PolicyCatalog>>(resultJson);
                else
                    result = new List<PolicyCatalog>();
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public string DeletePolicyType(int Id)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    Id,
                    Action = "DELETE"
                };

                return manager.ExeDBNonQuery(DynamicObj, "sp_PolicyType_Manager"); ;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public string InsertPolicyType(PolicyCatalog policyType)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    policyType.Id,
                    policyType.Description,
                    policyType.Type,
                    ModificationUser = "206480980",
                    Action = "INSERT"
                };

                return manager.ExeDBNonQuery(DynamicObj, "sp_PolicyType_Manager"); ;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public string UpdatePolicyType(PolicyCatalog policyType)
        {
            try
            {
                dynamic DynamicObj = new
                {
                    policyType.Id,
                    policyType.Description,
                    policyType.Type,
                    ModificationUser = "206480980",
                    Action = "UPDATE"
                };

                return manager.ExeDBNonQuery(DynamicObj, "sp_PolicyType_Manager"); ;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
