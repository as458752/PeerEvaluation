using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;

namespace PeerEvaluation
{
    public class XMLUtility
    {
        public static void storeResult(String fID,String erID,String erName,String edID,String edName, Boolean f, String s,Result re)
        {
            string xmlString = null;
            XmlSerializer xmlSerializer = new XmlSerializer(re.GetType());
            using (MemoryStream memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, re);
                memoryStream.Position = 0;
                xmlString = new StreamReader(memoryStream).ReadToEnd();
            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

            string insertQuery = "insert into [Results] ([FormID],[EvaluatorID],[EvaluatorName],[EvaluatedID], [EvaluatedName], [Finished], [AveScore],[Result]) values (@FormID,@EvaluatorID,@EvaluatorName,@EvaluatedID, @EvaluatedName, @Finished, @AveScore,@Result)";
            SqlCommand comm = new SqlCommand(insertQuery, conn);

            comm.Parameters.Add("@FormID", SqlDbType.NChar);
            comm.Parameters.Add("@EvaluatorID", SqlDbType.NChar);
            comm.Parameters.Add("@EvaluatorName", SqlDbType.NChar);
            comm.Parameters.Add("@EvaluatedID", SqlDbType.NChar);
            comm.Parameters.Add("@EvaluatedName", SqlDbType.NChar);
            comm.Parameters.Add("@Finished", SqlDbType.Bit);
            comm.Parameters.Add("@AveScore", SqlDbType.NChar);
            comm.Parameters.Add("@Result", SqlDbType.Xml);

            comm.Parameters["@FormID"].Value = fID;
            comm.Parameters["@EvaluatorID"].Value = erID;
            comm.Parameters["@EvaluatorName"].Value = erName;
            comm.Parameters["@EvaluatedID"].Value = edID;
            comm.Parameters["@EvaluatedName"].Value = edName;
            comm.Parameters["@Finished"].Value = f;
            comm.Parameters["@AveScore"].Value = s;
            comm.Parameters["@Result"].Value = xmlString;

            comm.ExecuteNonQuery();

            conn.Close();
        }
        public static List<Result> getResult(string searchQuery)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand(searchQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            List<Result> re = new List<Result>();
            while (reader.Read())
            {
                string xmlValue = reader[0].ToString();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Result));
                using (StringReader stringReader = new StringReader(xmlValue))
                {
                    re.Add((Result)xmlSerializer.Deserialize(stringReader));
                }

            }
            conn.Close();
            return re;
        }
    }
}