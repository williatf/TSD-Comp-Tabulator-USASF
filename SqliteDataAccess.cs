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
            double Score = routine.J1Appearance
                + routine.J1Artistry
                + routine.J1Choreography
                + routine.J1Execution
                + routine.J1Showmanship
                + routine.J1Technique
                + routine.J2Appearance
                + routine.J2Artistry
                + routine.J2Choreography
                + routine.J2Execution
                + routine.J2Showmanship
                + routine.J2Technique
                + routine.J3Appearance
                + routine.J3Artistry
                + routine.J3Choreography
                + routine.J3Execution
                + routine.J3Showmanship
                + routine.J3Technique;

            double Appearance = routine.J1Appearance + routine.J2Appearance + routine.J3Appearance;
            double Artistry   = routine.J1Artistry + routine.J2Artistry + routine.J3Artistry;
            double Choreography = routine.J1Choreography + routine.J2Choreography + routine.J3Choreography;
            double Execution = routine.J1Execution + routine.J2Execution + routine.J3Execution;
            double Showmanship = routine.J1Showmanship + routine.J2Showmanship + routine.J3Showmanship;
            double Technique = routine.J1Technique + routine.J2Technique + routine.J3Technique;

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
                    "J3Appearance," +
                    "Technique," +
                    "Choreography," +
                    "Execution," +
                    "Artistry," +
                    "Showmanship," +
                    "Appearance," +
                    "Score" +
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
                    "@J3Appearance," +
                    Technique + "," +
                    Choreography + "," +
                    Execution + "," +
                    Artistry + "," +
                    Showmanship + "," +
                    Appearance + "," +
                    Score +
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
                adaptor.InsertCommand = new SQLiteCommand("INSERT INTO MasterDataReport (" +
                    "StartTime," +
                    "EntryId," +
                    "EntryType," +
                    "Category," +
                    "Class," +
                    "Participants," +
                    "StudioName," +
                    "RoutineTitle" +
                    ") VALUES (" +
                    ":startTime, " +
                    ":entryId, " +
                    ":entryType, " +
                    ":category, " +
                    ":class, " +
                    ":participants, " +
                    ":studioName, " +
                    ":routineTitle" +
                    ")",
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
        public static List<string> getSoloClasses(string category)
        {
            List<string> vClasses = new List<string>();

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                using (SQLiteCommand fmd = cnn.CreateCommand())
                {
                    fmd.CommandText = @"SELECT DISTINCT Class FROM Solos WHERE Category LIKE '%" + category + "%' ORDER BY listOrder";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        vClasses.Add(Convert.ToString(r["Class"]));
                    }
                }
                return vClasses;
            }
        }
        public static List<Solos> getSoloTrophies(string vClass, string category)
        {
            string tbl = "Solos_" + category + "RankByClass";
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Solos>(
                    "SELECT * FROM " + tbl + " " +
                    "WHERE Class='" + vClass + "' " +
                    "AND Rank <= 5 " +
                    "ORDER BY Rank ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<string> getDuetClasses(string category)
        {
            List<string> vClasses = new List<string>();

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                using (SQLiteCommand fmd = cnn.CreateCommand())
                {
                    fmd.CommandText = @"SELECT DISTINCT Class FROM Duets WHERE Category LIKE '%" + category + "%' ORDER BY listOrder";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        vClasses.Add(Convert.ToString(r["Class"]));
                    }
                }
                return vClasses;
            }
        }
        public static List<Duets> getDuetTrophies(string vClass, string category)
        {
            string tbl = "Duets_" + category + "RankByClass";
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Duets>(
                    "SELECT * FROM " + tbl + " " +
                    "WHERE Class LIKE '" + vClass + "%' " +
                    "AND Rank <= 5 " +
                    "ORDER BY Rank ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<string> getTrioClasses(string category)
        {
            List<string> vClasses = new List<string>();

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                using (SQLiteCommand fmd = cnn.CreateCommand())
                {
                    fmd.CommandText = @"SELECT DISTINCT Class FROM Trios WHERE Category LIKE '%" + category + "%' ORDER BY listOrder";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        vClasses.Add(Convert.ToString(r["Class"]));
                    }
                }
                return vClasses;
            }
        }
        public static List<Trios> getTrioTrophies(string vClass, string category)
        {
            string tbl = "Trios_" + category + "RankByClass";
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Trios>(
                    "SELECT * FROM " + tbl + " " +
                    "WHERE Class LIKE '" + vClass + "%' " +
                    "AND Rank <= 5 " +
                    "ORDER BY Rank ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<string> getEnsembleEntryTypes(string category)
        {
            List<string> entryTypes = new List<string>();

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                using (SQLiteCommand fmd = cnn.CreateCommand())
                {
                    fmd.CommandText = @"SELECT DISTINCT EntryType FROM Ensembles WHERE Category LIKE '%" + category + "%' ORDER BY listOrder";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        entryTypes.Add(Convert.ToString(r["EntryType"]));
                    }
                }
                return entryTypes;
            }
        }
        public static List<string> getEnsembleClasses(string category, string entryType)
        {
            List<string> vClasses = new List<string>();

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                using (SQLiteCommand fmd = cnn.CreateCommand())
                {
                    fmd.CommandText = @"SELECT DISTINCT Class FROM Ensembles WHERE Category LIKE '%" + category + "%' AND EntryType = '" + entryType + "' ORDER BY listOrder";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        vClasses.Add(Convert.ToString(r["Class"]));
                    }
                }
                return vClasses;
            }
        }
        public static List<Ensembles> getEnsembleTrophies(string vClass, string entryType)
        {
            string tbl = "Ensembles";
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Ensembles>(
                    "SELECT EntryID,StudioName,RoutineTitle,AvgScore,Class,Rank " +
                    "FROM ( SELECT *, rank() OVER ( PARTITION BY Class ORDER BY AvgScore DESC ) Rank FROM " + tbl + " " +
                    "WHERE EntryType = '" + entryType + "' ) " +
                    "WHERE Class = '" + vClass + "' " +
                    "AND Rank <= 5 " +
                    "ORDER BY Rank ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
    }
}
