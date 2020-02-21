using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TSD_Comp_Tabulator.Models;

namespace TSD_Comp_Tabulator.ViewModels
{
    public class ShellViewModel : PropertyChangedBase
    {
		private RoutineModel _selectedRoutine;
		private BindableCollection<RoutineModel> _routines;
        public double J1Technique;
        private RoutineModel _currentRoutine;

        public ShellViewModel()
		{
			_routines = new BindableCollection<RoutineModel>(SqliteDataAccess.LoadRoutines());
		}

		public BindableCollection<RoutineModel> Routines
		{
			get { return _routines; }
			set { _routines = value; }
		}

		public RoutineModel SelectedRoutine
		{
			get { return _selectedRoutine; }
			set 
			{
				_selectedRoutine = value;
                if (value != null)
                {
                    _currentRoutine = (RoutineModel)_selectedRoutine.Shallowcopy();
                } else
                {
                    _currentRoutine = null;
                }
                NotifyOfPropertyChange(() => SelectedRoutine);
                NotifyOfPropertyChange(() => CurrentRoutine);
                
			}
		}

        public RoutineModel CurrentRoutine
        {
            get { return _currentRoutine; }
            set { return; }
        }

        public void LoadNewContest(object sender, RoutedEventArgs e)
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
                    conn.Open();
                    var query = "SELECT * FROM [" + System.IO.Path.GetFileName(filename) + "]";
                    using (var adaptr = new OleDbDataAdapter(query, conn))
                    {
                        adaptr.Fill(ds);
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
                Routines = new BindableCollection < RoutineModel >( SqliteDataAccess.LoadRoutines());
                NotifyOfPropertyChange(() => Routines);

            }

        }

        public void Submit(object sender, RoutedEventArgs e)
        {
            SqliteDataAccess.SubmitRoutineScores(CurrentRoutine);
            SelectedRoutine = null;
            NotifyOfPropertyChange(() => SelectedRoutine);
            _routines = new BindableCollection<RoutineModel>(SqliteDataAccess.LoadRoutines());
            NotifyOfPropertyChange(() => Routines);
        }

        public void Cancel(object sender, RoutedEventArgs e)
        {
            _routines = new BindableCollection<RoutineModel>(SqliteDataAccess.LoadRoutines());
            NotifyOfPropertyChange(() => Routines);
        }

    }
}
