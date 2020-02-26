using Caliburn.Micro;
using Microsoft.Win32;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using TSD_Comp_Tabulator.Models;

namespace TSD_Comp_Tabulator.ViewModels
{
    public class DataViewModel : Screen
    {
        private RoutineModel _selectedRoutine;
        private BindableCollection<RoutineModel> _routines;
        public double J1Technique;
        private RoutineModel _currentRoutine;

        public DataViewModel()
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
                }
                else
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

        public void LoadReports()
        {
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
