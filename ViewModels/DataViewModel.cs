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
        private double _j1Total;
        private double _j2Total;
        private double _j3Total;
        private double _appearance;
        private double _technique;
        private double _choreography;
        private double _execution;
        private double _artistry;
        private double _showmanship;
        private double _total;
        private bool _tb_isEnabled = false;

        public DataViewModel()
        {
            Routines = new BindableCollection<RoutineModel>(SqliteDataAccess.LoadRoutines());
        }

        public BindableCollection<RoutineModel> Routines { get; set; }

        public RoutineModel SelectedRoutine
        {
            get { return _selectedRoutine; }
            set
            {
                _selectedRoutine = value;
                if (value != null)
                {
                    CurrentRoutine = (RoutineModel)_selectedRoutine.Shallowcopy();
                    _tb_isEnabled = true;
                }
                else
                {
                    CurrentRoutine = null;
                    _tb_isEnabled = false;
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
                NotifyOfPropertyChange(() => Appearance);
                NotifyOfPropertyChange(() => Technique);
                NotifyOfPropertyChange(() => Choreography);
                NotifyOfPropertyChange(() => Execution);
                NotifyOfPropertyChange(() => Artistry);
                NotifyOfPropertyChange(() => Showmanship);
                NotifyOfPropertyChange(() => Total);
                NotifyOfPropertyChange(() => tb_IsEnabled);
            }
        }

        public RoutineModel CurrentRoutine { get; private set; }

        public bool tb_IsEnabled
        {
            get { return _tb_isEnabled; }
            set
            {
                if ( _tb_isEnabled == value )
                {
                    return;
                }

                _tb_isEnabled = value;
                NotifyOfPropertyChange("tb_IsEnabled");
            }

        }

        public void Submit(object sender, RoutedEventArgs e)
        {
            SqliteDataAccess.SubmitRoutineScores(CurrentRoutine);
            _selectedRoutine.J1Appearance = CurrentRoutine.J1Appearance;
            _selectedRoutine.J1Artistry = CurrentRoutine.J1Artistry;
            _selectedRoutine.J1Choreography = CurrentRoutine.J1Choreography;
            _selectedRoutine.J1Execution = CurrentRoutine.J1Execution;
            _selectedRoutine.J1Showmanship = CurrentRoutine.J1Showmanship;
            _selectedRoutine.J1Technique = CurrentRoutine.J1Technique;
            _selectedRoutine.J2Appearance = CurrentRoutine.J2Appearance;
            _selectedRoutine.J2Artistry = CurrentRoutine.J2Artistry;
            _selectedRoutine.J2Choreography = CurrentRoutine.J2Choreography;
            _selectedRoutine.J2Execution = CurrentRoutine.J2Execution;
            _selectedRoutine.J2Showmanship = CurrentRoutine.J2Showmanship;
            _selectedRoutine.J2Technique = CurrentRoutine.J2Technique;
            _selectedRoutine.J3Appearance = CurrentRoutine.J3Appearance;
            _selectedRoutine.J3Artistry = CurrentRoutine.J3Artistry;
            _selectedRoutine.J3Choreography = CurrentRoutine.J3Choreography;
            _selectedRoutine.J3Execution = CurrentRoutine.J3Execution;
            _selectedRoutine.J3Showmanship = CurrentRoutine.J3Showmanship;
            _selectedRoutine.J3Technique = CurrentRoutine.J3Technique;

            NotifyOfPropertyChange(() => SelectedRoutine);
            SelectedRoutine = null;
            //Routines = new BindableCollection<RoutineModel>(SqliteDataAccess.LoadRoutines());
            NotifyOfPropertyChange(() => Routines);
        }

        public void Cancel(object sender, RoutedEventArgs e)
        {
            Routines = new BindableCollection<RoutineModel>(SqliteDataAccess.LoadRoutines());
            NotifyOfPropertyChange(() => Routines);
        }

        public double J1Appearance
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Appearance;
                }
            }
            set
            {
                CurrentRoutine.J1Appearance = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Appearance);
                NotifyOfPropertyChange(() => Total);

            }
        }
        public double J1Technique
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Technique;
                }
            }
            set
            {
                CurrentRoutine.J1Technique = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Technique);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Choreography
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Choreography;
                }
            }
            set
            {
                CurrentRoutine.J1Choreography = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Choreography);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Execution
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Execution;
                }
            }
            set
            {
                CurrentRoutine.J1Execution = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Execution);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Artistry
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Artistry;
                }
            }
            set
            {
                CurrentRoutine.J1Artistry = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Artistry);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Showmanship
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Showmanship;
                }
            }
            set
            {
                CurrentRoutine.J1Showmanship = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Showmanship);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Total
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _j1Total = CurrentRoutine.J1Appearance;
                    _j1Total += CurrentRoutine.J1Artistry;
                    _j1Total += CurrentRoutine.J1Choreography;
                    _j1Total += CurrentRoutine.J1Execution;
                    _j1Total += CurrentRoutine.J1Showmanship;
                    _j1Total += CurrentRoutine.J1Technique;

                    return _j1Total;
                }
            }
        }

        public double J2Appearance
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Appearance;
                }
            }
            set
            {
                CurrentRoutine.J2Appearance = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Appearance);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Technique
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Technique;
                }
            }
            set
            {
                CurrentRoutine.J2Technique = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Technique);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Choreography
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Choreography;
                }
            }
            set
            {
                CurrentRoutine.J2Choreography = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Choreography);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Execution
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Execution;
                }
            }
            set
            {
                CurrentRoutine.J2Execution = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Execution);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Artistry
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Artistry;
                }
            }
            set
            {
                CurrentRoutine.J2Artistry = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Artistry);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Showmanship
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Showmanship;
                }
            }
            set
            {
                CurrentRoutine.J2Showmanship = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Showmanship);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Total
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _j2Total = CurrentRoutine.J2Appearance;
                    _j2Total += CurrentRoutine.J2Artistry;
                    _j2Total += CurrentRoutine.J2Choreography;
                    _j2Total += CurrentRoutine.J2Execution;
                    _j2Total += CurrentRoutine.J2Showmanship;
                    _j2Total += CurrentRoutine.J2Technique;

                    return _j2Total;
                }
            }
        }

        public double J3Appearance
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Appearance;
                }
            }
            set
            {
                CurrentRoutine.J3Appearance = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Appearance);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Technique
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Technique;
                }
            }
            set
            {
                CurrentRoutine.J3Technique = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Technique);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Choreography
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Choreography;
                }
            }
            set
            {
                CurrentRoutine.J3Choreography = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Choreography);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Execution
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Execution;
                }
            }
            set
            {
                CurrentRoutine.J3Execution = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Execution);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Artistry
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Artistry;
                }
            }
            set
            {
                CurrentRoutine.J3Artistry = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Artistry);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Showmanship
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Showmanship;
                }
            }
            set
            {
                CurrentRoutine.J3Showmanship = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Showmanship);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Total
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _j3Total = CurrentRoutine.J3Appearance;
                    _j3Total += CurrentRoutine.J3Artistry;
                    _j3Total += CurrentRoutine.J3Choreography;
                    _j3Total += CurrentRoutine.J3Execution;
                    _j3Total += CurrentRoutine.J3Showmanship;
                    _j3Total += CurrentRoutine.J3Technique;

                    return _j3Total;
                }
            }
        }

        public double Appearance
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _appearance = CurrentRoutine.J1Appearance;
                    _appearance += CurrentRoutine.J2Appearance;
                    _appearance += CurrentRoutine.J3Appearance;

                    return _appearance;
                }
            }
        }
        public double Technique
        {
            get 
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _technique = CurrentRoutine.J1Technique;
                    _technique += CurrentRoutine.J2Technique;
                    _technique += CurrentRoutine.J3Technique;

                    return _technique;
                }
            }
        }
        public double Choreography
        {
            get 
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _choreography = CurrentRoutine.J1Choreography;
                    _choreography += CurrentRoutine.J2Choreography;
                    _choreography += CurrentRoutine.J3Choreography;

                    return _choreography;
                }
            }
        }
        public double Execution
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _execution = CurrentRoutine.J1Execution;
                    _execution += CurrentRoutine.J2Execution;
                    _execution += CurrentRoutine.J3Execution;

                    return _execution;
                }
            }
        }
        public double Artistry
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _artistry = CurrentRoutine.J1Artistry;
                    _artistry += CurrentRoutine.J2Artistry;
                    _artistry += CurrentRoutine.J3Artistry;

                    return _artistry;
                }
            }
        }
        public double Showmanship
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _showmanship = CurrentRoutine.J1Showmanship;
                    _showmanship += CurrentRoutine.J2Showmanship;
                    _showmanship += CurrentRoutine.J3Showmanship;

                    return _showmanship;
                }
            }
        }
        public double Total
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _total = _j1Total;
                    _total += _j2Total;
                    _total += _j3Total;

                    return _total;
                }
            }
        }
    }
}
