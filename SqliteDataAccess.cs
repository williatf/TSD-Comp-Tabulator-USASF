using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD_Comp_Tabulator.Models;

namespace TSD_Comp_Tabulator
{
    public class SqliteDataAccess
    {
        public static List<RoutineModel> LoadRoutines()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RoutineModel>("SELECT * FROM MasterTable ORDER BY EntryID ASC", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SubmitRoutineScores(RoutineModel routine)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE MasterDataReport SET (" +
                    "J1Technique," +
                    "J1Choreography," +
                    "J1Execution," +
                    "J1Artistry," +
                    "J1Showmanship," +
                    "J1Appearance," +
                    "J2Technique," +
                    "J2Choreography," +
                    "J2Execution," +
                    "J2Artistry," +
                    "J2Showmanship," +
                    "J2Appearance," +
                    "J3Technique," +
                    "J3Choreography," +
                    "J3Execution," +
                    "J3Artistry," +
                    "J3Showmanship," +
                    "J3Appearance" +
                    ") = (" +
                    "@J1Technique," +
                    "@J1Choreography," +
                    "@J1Execution," +
                    "@J1Artistry," +
                    "@J1Showmanship," +
                    "@J1Appearance," +
                    "@J2Technique," +
                    "@J2Choreography," +
                    "@J2Execution," +
                    "@J2Artistry," +
                    "@J2Showmanship," +
                    "@J2Appearance," +
                    "@J3Technique," +
                    "@J3Choreography," +
                    "@J3Execution," +
                    "@J3Artistry," +
                    "@J3Showmanship," +
                    "@J3Appearance" +
                    ")" +
                    "WHERE EntryID = @EntryID", routine);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static void LoadNewRoutinesFromDataset(DataSet ds)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                // open the connection
                cnn.Open();

                // empty the table
                cnn.Execute("DELETE FROM MasterDataReport");

                // Create an SQLite command
                SQLiteCommand cmd = new SQLiteCommand(cnn);

                // create an SQLite adaptor
                SQLiteDataAdapter adaptor = new SQLiteDataAdapter("SELECT * from MasterDataReport", cnn);

                // create the insert command
                adaptor.InsertCommand = new SQLiteCommand("INSERT INTO MasterDataReport VALUES (" +
                    ":startTime, " +
                    ":entryId, " +
                    ":entryType, " +
                    ":category, " +
                    ":class, " +
                    ":participants, " +
                    ":studioName, " +
                    ":routineTitle," +
                    "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)",
                    cnn
                );

                // add the parameters
                adaptor.InsertCommand.Parameters.Add("startTime", DbType.String, 0, "StartTime");
                adaptor.InsertCommand.Parameters.Add("entryId", DbType.Int16, 0, "EntryID");
                adaptor.InsertCommand.Parameters.Add("entryType", DbType.String, 0, "EntryType");
                adaptor.InsertCommand.Parameters.Add("category", DbType.String, 0, "Category");
                adaptor.InsertCommand.Parameters.Add("class", DbType.String, 0, "Class");
                adaptor.InsertCommand.Parameters.Add("participants", DbType.String, 0, "Participants");
                adaptor.InsertCommand.Parameters.Add("studioName", DbType.String, 0, "StudioName");
                adaptor.InsertCommand.Parameters.Add("routineTitle", DbType.String, 0, "Routine Title");
                
                // the update command adds the rows in the dataset to the database
                adaptor.Update(ds);

            }
        }
    }
}
