using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace firstMVC.Models
{
    public class CodeDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MusicStoreEntities"].ConnectionString;

        //public CodeDB()
        //{

        //}

        public DataTable getAllMusicTypes()
        {
            string strSql = "select * from Genre";
            return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, strSql).Tables[0];
        }

        public IEnumerable<MusicDetails> getAllMusicTypesList()
        {
            string strSql = "select * from Genre";
            return ConvertToTankReadings(SqlHelper.ExecuteDataset(connectionString, CommandType.Text, strSql).Tables[0]);
        }

        private IEnumerable<MusicDetails> ConvertToTankReadings(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                yield return new MusicDetails
                {
                    id = Convert.ToInt32(row["GenreId"]),
                    Name = Convert.ToString(row["Name"]),
                    Description = Convert.ToString(row["Description"])
                };
            }
        }
    }
}