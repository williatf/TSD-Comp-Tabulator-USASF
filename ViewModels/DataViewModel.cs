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
        private RoutineModel _currentRoutine;
        private double _j1Total;
        private double _J2Total;
        private double _J3Total;

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
                NotifyOfPropertyChange(() => J1Appearance);
                NotifyOfPropertyChange(() => J1Technique);
                NotifyOfPropertyChange(() => J1Choreography);
                NotifyOfPropertyChange(() => J1Execution);
                NotifyOfPropertyChange(() => J1Artistry);
                NotifyOfPropertyChange(() => J1Showmanship);
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => J2Appearance);
                NotifyOfPropertyChange(() => J2Technique);
                NotifyOfPropertyChange(() => J2Choreography);
                NotifyOfPropertyChange(() => J2Execution);
                NotifyOfPropertyChange(() => J2Artistry);
                NotifyOfPropertyChange(() => J2Showmanship);
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => J3Appearance);
                NotifyOfPropertyChange(() => J3Technique);
                NotifyOfPropertyChange(() => J3Choreography);
                NotifyOfPropertyChange(() => J3Execution);
                NotifyOfPropertyChange(() => J3Artistry);
                NotifyOfPropertyChange(() => J3Showmanship);
                NotifyOfPropertyChange(() => J3Total);

            }
        }

        public RoutineModel CurrentRoutine
        {
            get { return _currentRoutine; }
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

        public double J1Appearance
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J1Appearance;
                }
            }
            set
            {
                _currentRoutine.J1Appearance = value;
                NotifyOfPropertyChange(() => J1Total);
            }
        }
        public double J1Technique
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J1Technique;
                }
            }
            set
            {
                _currentRoutine.J1Technique = value;
                NotifyOfPropertyChange(() => J1Total);
            }
        }
        public double J1Choreography
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J1Choreography;
                }
            }
            set
            {
                _currentRoutine.J1Choreography = value;
                NotifyOfPropertyChange(() => J1Total);
            }
        }
        public double J1Execution
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J1Execution;
                }
            }
            set
            {
                _currentRoutine.J1Execution = value;
                NotifyOfPropertyChange(() => J1Total);
            }
        }
        public double J1Artistry
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J1Artistry;
                }
            }
            set
            {
                _currentRoutine.J1Artistry = value;
                NotifyOfPropertyChange(() => J1Total);
            }
        }
        public double J1Showmanship
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J1Showmanship;
                }
            }
            set
            {
                _currentRoutine.J1Showmanship = value;
                NotifyOfPropertyChange(() => J1Total);
            }
        }
        public double J1Total
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _j1Total = _currentRoutine.J1Appearance;
                    _j1Total += _currentRoutine.J1Artistry;
                    _j1Total += _currentRoutine.J1Choreography;
                    _j1Total += _currentRoutine.J1Execution;
                    _j1Total += _currentRoutine.J1Showmanship;
                    _j1Total += _currentRoutine.J1Technique;

                    return _j1Total;
                }
            }
        }

        public double J2Appearance
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J2Appearance;
                }
            }
            set
            {
                _currentRoutine.J2Appearance = value;
                NotifyOfPropertyChange(() => J2Total);
            }
        }
        public double J2Technique
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J2Technique;
                }
            }
            set
            {
                _currentRoutine.J2Technique = value;
                NotifyOfPropertyChange(() => J2Total);
            }
        }
        public double J2Choreography
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J2Choreography;
                }
            }
            set
            {
                _currentRoutine.J2Choreography = value;
                NotifyOfPropertyChange(() => J2Total);
            }
        }
        public double J2Execution
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J2Execution;
                }
            }
            set
            {
                _currentRoutine.J2Execution = value;
                NotifyOfPropertyChange(() => J2Total);
            }
        }
        public double J2Artistry
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J2Artistry;
                }
            }
            set
            {
                _currentRoutine.J2Artistry = value;
                NotifyOfPropertyChange(() => J2Total);
            }
        }
        public double J2Showmanship
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J2Showmanship;
                }
            }
            set
            {
                _currentRoutine.J2Showmanship = value;
                NotifyOfPropertyChange(() => J2Total);
            }
        }
        public double J2Total
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _J2Total = _currentRoutine.J2Appearance;
                    _J2Total += _currentRoutine.J2Artistry;
                    _J2Total += _currentRoutine.J2Choreography;
                    _J2Total += _currentRoutine.J2Execution;
                    _J2Total += _currentRoutine.J2Showmanship;
                    _J2Total += _currentRoutine.J2Technique;

                    return _J2Total;
                }
            }
        }

        public double J3Appearance
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J3Appearance;
                }
            }
            set
            {
                _currentRoutine.J3Appearance = value;
                NotifyOfPropertyChange(() => J3Total);
            }
        }
        public double J3Technique
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J3Technique;
                }
            }
            set
            {
                _currentRoutine.J3Technique = value;
                NotifyOfPropertyChange(() => J3Total);
            }
        }
        public double J3Choreography
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J3Choreography;
                }
            }
            set
            {
                _currentRoutine.J3Choreography = value;
                NotifyOfPropertyChange(() => J3Total);
            }
        }
        public double J3Execution
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J3Execution;
                }
            }
            set
            {
                _currentRoutine.J3Execution = value;
                NotifyOfPropertyChange(() => J3Total);
            }
        }
        public double J3Artistry
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J3Artistry;
                }
            }
            set
            {
                _currentRoutine.J3Artistry = value;
                NotifyOfPropertyChange(() => J3Total);
            }
        }
        public double J3Showmanship
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return _currentRoutine.J3Showmanship;
                }
            }
            set
            {
                _currentRoutine.J3Showmanship = value;
                NotifyOfPropertyChange(() => J3Total);
            }
        }
        public double J3Total
        {
            get
            {
                if (_currentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _J3Total = _currentRoutine.J3Appearance;
                    _J3Total += _currentRoutine.J3Artistry;
                    _J3Total += _currentRoutine.J3Choreography;
                    _J3Total += _currentRoutine.J3Execution;
                    _J3Total += _currentRoutine.J3Showmanship;
                    _J3Total += _currentRoutine.J3Technique;

                    return _J3Total;
                }
            }
        }

    }
}
