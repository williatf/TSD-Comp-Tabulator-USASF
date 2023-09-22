using Caliburn.Micro;
using Microsoft.Win32;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows;
using TSD_Comp_Tabulator_USASF.Models;

namespace TSD_Comp_Tabulator_USASF.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItem(new DataViewModel());
        }

        public void CloseApp()
        {
            System.Windows.Application.Current.Shutdown();
        }
        public void ShowReportsView()
        {
            ActivateItem(new ReportsViewModel());
        }

        public void ShowDataView()
        {
            ActivateItem(new DataViewModel());
        }

        public void LoadNewContest()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;

                // create a dataset to hold the CSV file
                // TODO - verify the file format (check first line for appropriate header fields?
                DataSet ds = new DataSet();

                // create the connection string to connect the OleDb to the CSV file
                var connString = string.Format(
                    @"Provider=Microsoft.Jet.OleDb.4.0; 
                    Data Source={0};
                    Extended Properties=""Text;
                    HDR=YES;
                    FMT=Delimited""",
                    System.IO.Path.GetDirectoryName(filename));

                // connect to the CSV file and fill the data set
                using (var conn = new OleDbConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        var query = "SELECT * FROM [" + System.IO.Path.GetFileName(filename) + "]";
                        using (var adaptr = new OleDbDataAdapter(query, conn))
                        {
                            adaptr.Fill(ds);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error loading " + filename);
                        return;
                    }

                }

                // check to make sure all of the columns exist
                foreach (DataColumn column in ds.Tables[0].Columns)
                {
                    switch (column.ColumnName)
                    {
                        case "StartTime":
                        case "EntryID":
                        case "EntryType":
                        case "Category":
                        case "Class":
                        case "Participants":
                        case "StudioName":
                        case "Routine Title":
                            break;
                        default:
                            MessageBox.Show("Error loading " + filename + "\nMissing Column(s)");
                            return;
                    }
                }


                // set the row status to added for each row in the data set
                // if you don't do this, the rows won't get added to the db in the next step
                // this has to be done before any rows are modified
                // the next step is to delete rows that don't belong, which changes their state to "Deleted"
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    row.SetAdded();
                }

                // delete rows that don't have an EntryID
                var rows = ds.Tables[0].Select("EntryID IS NULL");
                foreach (var row in rows)
                    row.Delete();


                // load the data into the db
                SqliteDataAccess.LoadNewRoutinesFromDataset(ds);

                // update the UI with the new routines
                ActivateItem(new DataViewModel());

            }

        }

        public void ExportDB()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Routines"; // default filename
            saveFileDialog.DefaultExt = ".db"; // default extension
            saveFileDialog.Filter = "Databases (.db)|*.db"; // filters files by extension

            if (saveFileDialog.ShowDialog() == true)
            {
                string filename = saveFileDialog.FileName;
                string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                string dbFile = new System.Uri(
                    System.IO.Path.GetDirectoryName(path)
                    ).LocalPath + @"\Routines.db";
                System.IO.File.Copy(dbFile, filename, true); // overwriting is allowed

            }
        }
    }
}
