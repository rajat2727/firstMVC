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

        public IEnumerable<MusicDetails> setDataInMusicDetailModel()
        {
            string strSql = "select * from Genre";
            DataTable dataTable = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, strSql).Tables[0];
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

        //public IEnumerable<Album> setDataInAlbumModel()
        //{
        //    string strSql = "select * from Album";
        //    DataTable dataTable = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, strSql).Tables[0];
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        yield return new Album
        //        {
        //            AlbumId = Convert.ToInt32(row["AlbumId"]),
        //            GenreId = Convert.ToInt32(row["GenreId"]),
        //            ArtistId = Convert.ToInt32(row["ArtistId"]),
        //            Title = Convert.ToString(row["Title"]),
        //            Price = Convert.ToString(row["Price"]),
        //            AlbumArtUrl = Convert.ToString(row["AlbumArtUrl"])
        //        };
        //    }
        //}

    }
}