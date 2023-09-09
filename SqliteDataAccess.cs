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
            double Score = routine.J1Communication
                + routine.J1Suitability
                + routine.J1Composition
                + routine.J1Staging
                + routine.J1Difficulty
                + routine.J1Synchronization
                + routine.J1Spacing
                + routine.J1Movement
                + routine.J1Dynamics
                + routine.J1Elements
                + routine.J2Communication
                + routine.J2Suitability
                + routine.J2Composition
                + routine.J2Staging
                + routine.J2Difficulty
                + routine.J2Synchronization
                + routine.J2Spacing
                + routine.J2Movement
                + routine.J2Dynamics
                + routine.J2Elements
                + routine.J3Communication
                + routine.J3Suitability
                + routine.J3Composition
                + routine.J3Staging
                + routine.J3Difficulty
                + routine.J3Synchronization
                + routine.J3Spacing
                + routine.J3Movement
                + routine.J3Dynamics
                + routine.J3Elements;

            double Communication = routine.J1Communication + routine.J2Communication + routine.J3Communication;
            double Suitability   = routine.J1Suitability + routine.J2Suitability + routine.J3Suitability;
            double Composition = routine.J1Composition + routine.J2Composition + routine.J3Composition;
            double Staging = routine.J1Staging + routine.J2Staging + routine.J3Staging;
            double Difficulty = routine.J1Difficulty + routine.J2Difficulty + routine.J3Difficulty;
            double Synchronization = routine.J1Synchronization + routine.J2Synchronization + routine.J3Synchronization;
            double Spacing = routine.J1Spacing + routine.J2Spacing + routine.J3Spacing;
            double Movement = routine.J1Movement + routine.J2Movement + routine.J3Movement;
            double Dynamics = routine.J1Dynamics + routine.J2Dynamics + routine.J3Dynamics;
            double Elements = routine.J1Elements + routine.J2Elements + routine.J3Elements;

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE MasterDataReport_USASF SET (" +
                    "J1Synchronization," +
                    "J1Composition," +
                    "J1Staging," +
                    "J1Suitability," +
                    "J1Difficulty," +
                    "J1Communication," +
                    "J1Spacing," +
                    "J1Movement," +
                    "J1Dynamics," +
                    "J1Elements," +
                    "J2Synchronization," +
                    "J2Composition," +
                    "J2Staging," +
                    "J2Suitability," +
                    "J2Difficulty," +
                    "J2Communication," +
                    "J2Spacing," +
                    "J2Movement," +
                    "J2Dynamics," +
                    "J2Elements," +
                    "J3Synchronization," +
                    "J3Composition," +
                    "J3Staging," +
                    "J3Suitability," +
                    "J3Difficulty," +
                    "J3Communication," +
                    "J3Spacing," +
                    "J3Movement," +
                    "J3Dynamics," +
                    "J3Elements," +
                    "Synchronization," +
                    "Composition," +
                    "Staging," +
                    "Suitability," +
                    "Difficulty," +
                    "Communication," +
                    "Spacing," +
                    "Movement," +
                    "Dynamics," +
                    "Elements," +
                    "Score" +
                    ") = (" +
                    "@J1Synchronization," +
                    "@J1Composition," +
                    "@J1Staging," +
                    "@J1Suitability," +
                    "@J1Difficulty," +
                    "@J1Communication," +
                    "@J1Spacing," +
                    "@J1Movement," +
                    "@J1Dynamics," +
                    "@J1Elements," +
                    "@J2Synchronization," +
                    "@J2Composition," +
                    "@J2Staging," +
                    "@J2Suitability," +
                    "@J2Difficulty," +
                    "@J2Communication," +
                    "@J2Spacing," +
                    "@J2Movement," +
                    "@J2Dynamics," +
                    "@J2Elements," +
                    "@J3Synchronization," +
                    "@J3Composition," +
                    "@J3Staging," +
                    "@J3Suitability," +
                    "@J3Difficulty," +
                    "@J3Communication," +
                    "@J3Spacing," +
                    "@J3Movement," +
                    "@J3Dynamics," +
                    "@J3Elements," +
                    Synchronization + "," +
                    Composition + "," +
                    Staging + "," +
                    Suitability + "," +
                    Difficulty + "," +
                    Communication + "," +
                    Spacing + "," +
                    Movement + "," +
                    Dynamics + "," +
                    Elements + "," +
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
                cnn.Execute("DELETE FROM MasterDataReport_USASF");

                // Create an SQLite command
                SQLiteCommand cmd = new SQLiteCommand(cnn);

                // create an SQLite adaptor
                SQLiteDataAdapter adaptor = new SQLiteDataAdapter("SELECT * from MasterDataReport_USASF", cnn);

                // create the insert command
                adaptor.InsertCommand = new SQLiteCommand("INSERT INTO MasterDataReport_USASF (" +
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
        public static List<Individual> getSoloTrophies(string vClass, string category)
        {
            string tbl = "Solos_" + category + "RankByClass";
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Individual>(
                    "SELECT * FROM " + tbl + " " +
                    "WHERE Class='" + vClass + "' " +
                    "AND Rank <= 10 " +
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
        public static List<Individual> getDuetTrophies(string vClass, string category)
        {
            string tbl = "Duets_" + category + "RankByClass";
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Individual>(
                    "SELECT * FROM " + tbl + " " +
                    "WHERE Class LIKE '" + vClass + "%' " +
                    "AND Rank <= 10 " +
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
        public static List<Individual> getTrioTrophies(string vClass, string category)
        {
            string tbl = "Trios_" + category + "RankByClass";
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Individual>(
                    "SELECT * FROM " + tbl + " " +
                    "WHERE Class LIKE '" + vClass + "%' " +
                    "AND Rank <= 10 " +
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
        public static List<string> getEnsembleEntryTypes_new()
        {
            List<string> entryTypes = new List<string>();

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                using (SQLiteCommand fmd = cnn.CreateCommand())
                {
                    fmd.CommandText = @"SELECT DISTINCT t.listOrder, e.EntryType FROM Ensembles e LEFT JOIN Types t ON e.EntryType = t.type ORDER BY t.listOrder";
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
        public static List<Team> getEnsembleTrophies(string vClass, string entryType)
        {
            string tbl = "Ensembles";
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Team>(
                    "SELECT EntryID,StudioName,RoutineTitle,AvgScore,Class,Rank " +
                    "FROM ( SELECT *, rank() OVER ( PARTITION BY Class ORDER BY AvgScore DESC ) Rank FROM " + tbl + " " +
                    "WHERE EntryType = '" + entryType + "' ) " +
                    "WHERE Class = '" + vClass + "' " +
                    "AND Rank <= 10 " +
                    "ORDER BY Rank ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<Team> getEnsembleTrophies_Schools(string vClass, string category, string entryType)
        {
            string tbl = "Ensembles";
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Team>(
                    "SELECT EntryID,StudioName,RoutineTitle,AvgScore,Class,Rank " +
                    "FROM ( SELECT *, rank() OVER ( PARTITION BY Class ORDER BY AvgScore DESC ) Rank FROM " + tbl + " " +
                    "WHERE EntryType = '" + entryType + "' ) " +
                    "WHERE Category = '" + category + "' " +
                    "AND Class LIKE '" + vClass + "%' " +
                    "AND Rank <= 10 " +
                    "ORDER BY Rank ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<string> getSocialClasses()
        {
            List<string> vClasses = new List<string>();

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                using (SQLiteCommand fmd = cnn.CreateCommand())
                {
                    fmd.CommandText = @"SELECT DISTINCT Class FROM Socials ORDER BY listOrder";
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
        public static List<Team> getSocialTrophies(string vClass)
        {
            string tbl = "Socials_SchoolRankByClass";
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Team>(
                    "SELECT EntryID,StudioName,RoutineTitle,AvgScore,Class,Rank " +
                    "FROM " + tbl + " " +
                    "WHERE Class = '" + vClass + "' " +
                    "AND Rank <= 10 " +
                    "ORDER BY Rank ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<TeamAward> getSuperiorAwards(string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TeamAward>(
                    "SELECT StudioName,EntryType,Class,NumRoutines,AvgScore " +
                    "FROM " + db_table + "_Top t " +
                    "JOIN Classes c ON c.className = t.Class " +
                    "WHERE NumRoutines < 3 " +
                    "AND AvgScore >= 85 " +
                    "ORDER BY listOrder ASC, StudioName ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<TeamAward> getSweepstakesAwards(string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TeamAward>(
                    "SELECT StudioName,EntryType,Class,NumRoutines,AvgScore " +
                    "FROM " + db_table + "_Top t " +
                    "JOIN Classes c ON c.className = t.Class " +
                    "WHERE NumRoutines = 3 " +
                    "AND AvgScore >= 85 " +
                    "AND AvgScore < 90 " +
                    "ORDER BY listOrder ASC, StudioName ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<TeamAward> getSuperSweepstakesAwards(string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TeamAward>(
                    "SELECT StudioName,EntryType,Class,NumRoutines,AvgScore " +
                    "FROM " + db_table + "_Top t " +
                    "JOIN Classes c ON c.className = t.Class " +
                    "WHERE NumRoutines = 3 " +
                    "AND AvgScore >= 90 " +
                    "AND AvgScore < 95 " +
                    "ORDER BY listOrder ASC, StudioName ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<TeamAward> getJudgesAwards(string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TeamAward>(
                    "SELECT StudioName,EntryType,Class,NumRoutines,AvgScore " +
                    "FROM " + db_table + "_Top t " +
                    "JOIN Classes c ON c.className = t.Class " +
                    "WHERE NumRoutines = 3 " +
                    "AND AvgScore >= 95 " +
                    "ORDER BY listOrder ASC, StudioName ASC ", new DynamicParameters()
                 );
                return output.ToList();
            }
        }
        public static List<TeamAward> getTechnicalMeritAwards(string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TeamAward>(
                    "SELECT StudioName,EntryType,Class,NumRoutines,AvgTech as AvgScore FROM " +
                    "( SELECT StudioName,EntryType,Class,NumRoutines,AvgTech,rank() OVER (PARTITION BY NumRoutines ORDER BY AvgTech DESC) as rank FROM " + db_table + "_Tech " +
                    "WHERE NumRoutines = 3 " +
                    "AND AvgTech >= 23 ) t " +
                    "JOIN Classes c ON c.className = t.Class " +
                    "WHERE rank > 1 " +
                    "ORDER BY listOrder ASC, StudioName ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<TeamAward> gethighPointSynchronizationAwards(string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TeamAward>(
                    "SELECT StudioName,EntryType,Class,NumRoutines,AvgTech as AvgScore FROM " +
                    "( SELECT StudioName,EntryType,Class,NumRoutines,AvgTech,rank() OVER (PARTITION BY NumRoutines ORDER BY AvgTech DESC) as rank FROM " + db_table + "_Tech " +
                    "WHERE NumRoutines = 3 " +
                    "AND AvgTech >= 22 ) t " +
                    "JOIN Classes c ON c.className = t.Class " +
                    "WHERE rank = 1 " +
                    "ORDER BY listOrder ASC, StudioName ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<TeamAward> getPrecisionMeritAwards(string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TeamAward>(
                    "SELECT StudioName,EntryType,Class,NumRoutines,AvgPrec as AvgScore FROM " +
                    "( SELECT StudioName,EntryType,Class,NumRoutines,AvgPrec,rank() OVER (PARTITION BY NumRoutines ORDER BY AvgPrec DESC) as rank FROM " + db_table + "_Prec " +
                    "WHERE NumRoutines = 3 " +
                    "AND AvgPrec >= 23 ) t " +
                    "JOIN Classes c ON c.className = t.Class " +
                    "WHERE rank > 1 " +
                    "ORDER BY listOrder ASC, StudioName ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<TeamAward> gethighPointPrecisionAwards(string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TeamAward>(
                    "SELECT StudioName,EntryType,Class,NumRoutines,AvgPrec as AvgScore FROM " +
                    "( SELECT StudioName,EntryType,Class,NumRoutines,AvgPrec,rank() OVER (PARTITION BY NumRoutines ORDER BY AvgPrec DESC) as rank FROM " + db_table + "_Prec " +
                    "WHERE NumRoutines = 3 " +
                    "AND AvgPrec >= 22 ) " +
                    "WHERE rank = 1 " +
                    "ORDER BY StudioName ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<ChoreographyAward> getoutstandingChoreographyAwards(string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ChoreographyAward>(
                    "SELECT EntryID, StudioName,EntryType,Category,Class,AvgChor as AvgScore " +
                    "FROM " + db_table + "_Score t " +
                    "JOIN Classes c ON c.className = t.Class " +
                    "WHERE AvgChor >= 23 " +
                    "ORDER BY listOrder ASC, StudioName ASC, EntryType ASC", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<BestInCategoryAward> getBestInCategoryAwards(string vClass,string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<BestInCategoryAward>(
                    "SELECT StudioName,EntryType,EntryID,RoutineTitle,Category,AvgScore " +
                    "FROM " + db_table + "_" + vClass + "BestInCategory " +
                    "WHERE AvgScore >= 90 " +
                    "ORDER BY StudioName ASC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<TeamAward> getBestInClassAwards(string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TeamAward>(
                    "SELECT Class,StudioName,EntryType,AvgScore " +
                    "FROM " + db_table + "_BestInClass ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<TeamAward> getBestInClassEliteAwards(string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TeamAward>(
                    "SELECT Class,StudioName,EntryType,AvgScore " +
                    "FROM " + db_table + "_EliteBestInClass ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<highPointPerformanceAward> getHighPointPerformanceAward()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<highPointPerformanceAward>(
                    "SELECT EntryID,EntryType,RoutineTitle,StudioName,Class,Category,Round(Score/3.0,2) as AvgScore " +
                    "FROM MasterDataReport_USASF WHERE Score = (SELECT MAX(Score) FROM MasterDataReport_USASF)", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<TeamAward> getAwardOfExcellenceAwards(string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TeamAward>(
                    "SELECT StudioName,EntryType,AvgScore " +
                    "FROM " + db_table + "_Top " +
                    "WHERE NumRoutines = 3 " +
                    "ORDER BY AvgScore DESC ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
        public static List<TeamAward> getChampionAwards(string vClass, string db_table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TeamAward>(
                    "SELECT StudioName,EntryType,Class,AvgScore " +
                    "FROM " + db_table + "_" + vClass + "Rank " +
                    "WHERE Rank = 1 ", new DynamicParameters()
                );
                return output.ToList();
            }
        }
    }
}
