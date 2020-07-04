using GapPolicyDAO;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GapPolicyDAL
{
    public class Manager
    {
        //SqlConnection conexion = new SqlConnection(@"server=(localdb)\JoseAbarcaServer; database=Gap_BD; integrated security = true");
        readonly string conexionString = @"server=(localdb)\JoseAbarcaServer; database=Gap_BD; integrated security = true";

        public string ExeDBQuery<T>(T Obj, string SpName) {
            try {
                SqlQueryObject sqlObj = new SqlQueryObject
                {
                    ParameterList = new List<SpParameter>(Obj.GetType().GetProperties().Where(x => x.GetValue(Obj) != null
                            && !string.IsNullOrEmpty(x.GetValue(Obj).ToString())).Select(x =>
                            new SpParameter
                            {
                                Name = x.Name,
                                Value = x.GetValue(Obj).ToString()
                            }))
                };

                using (SqlConnection connection = new SqlConnection(conexionString))
                {
                    SqlCommand command = new SqlCommand(SpName, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    foreach (SpParameter param in sqlObj.ParameterList) {
                        SqlParameter parameterSql = new SqlParameter
                        {
                            ParameterName = "@" + param.Name,
                            Value = param.Value
                        };
                        command.Parameters.Add(parameterSql);
                    }

                    command.Connection.Open();
                    sqlObj.DataReader = command.ExecuteReader();
                    if (sqlObj.DataReader.HasRows)
                        sqlObj.JSonObject = ToJson(sqlObj.DataReader);
                    else
                        sqlObj.JSonObject = "";
                }

                return sqlObj.JSonObject;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public string ExeDBNonQuery<T>(T Obj, string SpName)
        {
            try
            {
                SqlQueryObject sqlObj = new SqlQueryObject
                {
                    ParameterList = new List<SpParameter>(Obj.GetType().GetProperties().Where(x => x.GetValue(Obj) != null
                            && !string.IsNullOrEmpty(x.GetValue(Obj).ToString())).Select(x =>
                            new SpParameter
                            {
                                Name = x.Name,
                                Value = x.GetValue(Obj).ToString()
                            }))
                };

                using (SqlConnection connection = new SqlConnection(conexionString))
                {
                    SqlCommand command = new SqlCommand(SpName, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    foreach (SpParameter param in sqlObj.ParameterList)
                    {
                        SqlParameter parameterSql = new SqlParameter
                        {
                            ParameterName = "@" + param.Name,
                            Value = param.Value
                        };
                        command.Parameters.Add(parameterSql);
                    }

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                return "Complete";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public string ToJson(SqlDataReader rdr)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.WriteStartArray();

                while (rdr.Read())
                {
                    jsonWriter.WriteStartObject();

                    int fields = rdr.FieldCount;

                    for (int i = 0; i < fields; i++)
                    {
                        jsonWriter.WritePropertyName(rdr.GetName(i));
                        jsonWriter.WriteValue(rdr[i]);
                    }

                    jsonWriter.WriteEndObject();
                }

                jsonWriter.WriteEndArray();

                return sw.ToString();
            }
        }
    }

}
