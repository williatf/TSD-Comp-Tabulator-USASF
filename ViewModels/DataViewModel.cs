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
        private double _communication;
        private double _suitability;
        private double _composition;
        private double _staging;
        private double _difficulty;
        private double _synchronization;
        private double _spacing;
        private double _movement;
        private double _dynamics;
        private double _elements;
        private double _total;
        private double _grandtotal;
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
                NotifyOfPropertyChange(() => J1Communication);
                NotifyOfPropertyChange(() => J1Suitability);
                NotifyOfPropertyChange(() => J1Composition);
                NotifyOfPropertyChange(() => J1Staging);
                NotifyOfPropertyChange(() => J1Difficulty);
                NotifyOfPropertyChange(() => J1Synchronization);
                NotifyOfPropertyChange(() => J1Spacing);
                NotifyOfPropertyChange(() => J1Movement);
                NotifyOfPropertyChange(() => J1Dynamics);
                NotifyOfPropertyChange(() => J1Elements);
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => J2Communication);
                NotifyOfPropertyChange(() => J2Suitability);
                NotifyOfPropertyChange(() => J2Composition);
                NotifyOfPropertyChange(() => J2Staging);
                NotifyOfPropertyChange(() => J2Difficulty);
                NotifyOfPropertyChange(() => J2Synchronization);
                NotifyOfPropertyChange(() => J2Spacing);
                NotifyOfPropertyChange(() => J2Movement);
                NotifyOfPropertyChange(() => J2Dynamics);
                NotifyOfPropertyChange(() => J2Elements);
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => J3Communication);
                NotifyOfPropertyChange(() => J3Suitability);
                NotifyOfPropertyChange(() => J3Composition);
                NotifyOfPropertyChange(() => J3Staging);
                NotifyOfPropertyChange(() => J3Difficulty);
                NotifyOfPropertyChange(() => J3Synchronization);
                NotifyOfPropertyChange(() => J3Spacing);
                NotifyOfPropertyChange(() => J3Movement);
                NotifyOfPropertyChange(() => J3Dynamics);
                NotifyOfPropertyChange(() => J3Elements);
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Communication);
                NotifyOfPropertyChange(() => Suitability);
                NotifyOfPropertyChange(() => Composition);
                NotifyOfPropertyChange(() => Staging);
                NotifyOfPropertyChange(() => Difficulty);
                NotifyOfPropertyChange(() => Synchronization);
                NotifyOfPropertyChange(() => Spacing);
                NotifyOfPropertyChange(() => Movement);
                NotifyOfPropertyChange(() => Dynamics);
                NotifyOfPropertyChange(() => Elements);
                NotifyOfPropertyChange(() => Total);
                NotifyOfPropertyChange(() => GrandTotal);
                NotifyOfPropertyChange(() => TeamPenalty);
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
            // update the record in the database
            SqliteDataAccess.SubmitRoutineScores(CurrentRoutine);

            // update the properties in the datatable
            // uses INotifyPropertyChanged in the model
            _selectedRoutine.J1Communication = CurrentRoutine.J1Communication;
            _selectedRoutine.J1Suitability = CurrentRoutine.J1Suitability;
            _selectedRoutine.J1Composition = CurrentRoutine.J1Composition;
            _selectedRoutine.J1Staging = CurrentRoutine.J1Staging;
            _selectedRoutine.J1Difficulty = CurrentRoutine.J1Difficulty;
            _selectedRoutine.J1Synchronization = CurrentRoutine.J1Synchronization;
            _selectedRoutine.J1Spacing = CurrentRoutine.J1Spacing;
            _selectedRoutine.J1Movement = CurrentRoutine.J1Movement;
            _selectedRoutine.J1Dynamics = CurrentRoutine.J1Dynamics;
            _selectedRoutine.J1Elements = CurrentRoutine.J1Elements;

            _selectedRoutine.J2Communication = CurrentRoutine.J2Communication;
            _selectedRoutine.J2Suitability = CurrentRoutine.J2Suitability;
            _selectedRoutine.J2Composition = CurrentRoutine.J2Composition;
            _selectedRoutine.J2Staging = CurrentRoutine.J2Staging;
            _selectedRoutine.J2Difficulty = CurrentRoutine.J2Difficulty;
            _selectedRoutine.J2Synchronization = CurrentRoutine.J2Synchronization;
            _selectedRoutine.J2Spacing = CurrentRoutine.J2Spacing;
            _selectedRoutine.J2Movement = CurrentRoutine.J2Movement;
            _selectedRoutine.J2Dynamics = CurrentRoutine.J2Dynamics;
            _selectedRoutine.J2Elements = CurrentRoutine.J2Elements;

            _selectedRoutine.J3Communication = CurrentRoutine.J3Communication;
            _selectedRoutine.J3Suitability = CurrentRoutine.J3Suitability;
            _selectedRoutine.J3Composition = CurrentRoutine.J3Composition;
            _selectedRoutine.J3Staging = CurrentRoutine.J3Staging;
            _selectedRoutine.J3Difficulty = CurrentRoutine.J3Difficulty;
            _selectedRoutine.J3Synchronization = CurrentRoutine.J3Synchronization;
            _selectedRoutine.J3Spacing = CurrentRoutine.J3Spacing;
            _selectedRoutine.J3Movement = CurrentRoutine.J3Movement;
            _selectedRoutine.J3Dynamics = CurrentRoutine.J3Dynamics;
            _selectedRoutine.J3Elements = CurrentRoutine.J3Elements;

            _selectedRoutine.TeamPenalty = CurrentRoutine.TeamPenalty;

            // reset the selected routine to clear out the form
            SelectedRoutine = null;
            NotifyOfPropertyChange(() => SelectedRoutine);
        }

        public void Cancel(object sender, RoutedEventArgs e)
        {
            Routines = new BindableCollection<RoutineModel>(SqliteDataAccess.LoadRoutines());
            NotifyOfPropertyChange(() => Routines);
        }

        public double J1Communication
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Communication;
                }
            }
            set
            {
                CurrentRoutine.J1Communication = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Communication);
                NotifyOfPropertyChange(() => Total);

            }
        }
        public double J1Suitability
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Suitability;
                }
            }
            set
            {
                CurrentRoutine.J1Suitability = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Suitability);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Composition
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Composition;
                }
            }
            set
            {
                CurrentRoutine.J1Composition = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Composition);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Staging
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Staging;
                }
            }
            set
            {
                CurrentRoutine.J1Staging = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Staging);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Difficulty
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Difficulty;
                }
            }
            set
            {
                CurrentRoutine.J1Difficulty = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Difficulty);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Synchronization
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Synchronization;
                }
            }
            set
            {
                CurrentRoutine.J1Synchronization = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Synchronization);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Spacing
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Spacing;
                }
            }
            set
            {
                CurrentRoutine.J1Spacing = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Spacing);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Movement
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Movement;
                }
            }
            set
            {
                CurrentRoutine.J1Movement = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Movement);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Dynamics
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Dynamics;
                }
            }
            set
            {
                CurrentRoutine.J1Dynamics = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Dynamics);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J1Elements
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J1Elements;
                }
            }
            set
            {
                CurrentRoutine.J1Elements = value;
                NotifyOfPropertyChange(() => J1Total);
                NotifyOfPropertyChange(() => Elements);
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
                    _j1Total = CurrentRoutine.J1Communication;
                    _j1Total += CurrentRoutine.J1Suitability;
                    _j1Total += CurrentRoutine.J1Composition;
                    _j1Total += CurrentRoutine.J1Staging;
                    _j1Total += CurrentRoutine.J1Difficulty;
                    _j1Total += CurrentRoutine.J1Synchronization;
                    _j1Total += CurrentRoutine.J1Spacing;
                    _j1Total += CurrentRoutine.J1Movement;
                    _j1Total += CurrentRoutine.J1Dynamics;
                    _j1Total += CurrentRoutine.J1Elements;

                    return _j1Total;
                }
            }
        }

        public double J2Communication
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Communication;
                }
            }
            set
            {
                CurrentRoutine.J2Communication = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Communication);
                NotifyOfPropertyChange(() => Total);

            }
        }
        public double J2Suitability
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Suitability;
                }
            }
            set
            {
                CurrentRoutine.J2Suitability = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Suitability);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Composition
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Composition;
                }
            }
            set
            {
                CurrentRoutine.J2Composition = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Composition);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Staging
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Staging;
                }
            }
            set
            {
                CurrentRoutine.J2Staging = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Staging);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Difficulty
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Difficulty;
                }
            }
            set
            {
                CurrentRoutine.J2Difficulty = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Difficulty);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Synchronization
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Synchronization;
                }
            }
            set
            {
                CurrentRoutine.J2Synchronization = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Synchronization);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Spacing
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Spacing;
                }
            }
            set
            {
                CurrentRoutine.J2Spacing = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Spacing);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Movement
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Movement;
                }
            }
            set
            {
                CurrentRoutine.J2Movement = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Movement);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Dynamics
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Dynamics;
                }
            }
            set
            {
                CurrentRoutine.J2Dynamics = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Dynamics);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J2Elements
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J2Elements;
                }
            }
            set
            {
                CurrentRoutine.J2Elements = value;
                NotifyOfPropertyChange(() => J2Total);
                NotifyOfPropertyChange(() => Elements);
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
                    _j2Total = CurrentRoutine.J2Communication;
                    _j2Total += CurrentRoutine.J2Suitability;
                    _j2Total += CurrentRoutine.J2Composition;
                    _j2Total += CurrentRoutine.J2Staging;
                    _j2Total += CurrentRoutine.J2Difficulty;
                    _j2Total += CurrentRoutine.J2Synchronization;
                    _j2Total += CurrentRoutine.J2Spacing;
                    _j2Total += CurrentRoutine.J2Movement;
                    _j2Total += CurrentRoutine.J2Dynamics;
                    _j2Total += CurrentRoutine.J2Elements;

                    return _j2Total;
                }
            }
        }

        public double J3Communication
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Communication;
                }
            }
            set
            {
                CurrentRoutine.J3Communication = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Communication);
                NotifyOfPropertyChange(() => Total);

            }
        }
        public double J3Suitability
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Suitability;
                }
            }
            set
            {
                CurrentRoutine.J3Suitability = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Suitability);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Composition
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Composition;
                }
            }
            set
            {
                CurrentRoutine.J3Composition = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Composition);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Staging
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Staging;
                }
            }
            set
            {
                CurrentRoutine.J3Staging = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Staging);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Difficulty
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Difficulty;
                }
            }
            set
            {
                CurrentRoutine.J3Difficulty = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Difficulty);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Synchronization
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Synchronization;
                }
            }
            set
            {
                CurrentRoutine.J3Synchronization = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Synchronization);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Spacing
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Spacing;
                }
            }
            set
            {
                CurrentRoutine.J3Spacing = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Spacing);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Movement
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Movement;
                }
            }
            set
            {
                CurrentRoutine.J3Movement = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Movement);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Dynamics
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Dynamics;
                }
            }
            set
            {
                CurrentRoutine.J3Dynamics = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Dynamics);
                NotifyOfPropertyChange(() => Total);
            }
        }
        public double J3Elements
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.J3Elements;
                }
            }
            set
            {
                CurrentRoutine.J3Elements = value;
                NotifyOfPropertyChange(() => J3Total);
                NotifyOfPropertyChange(() => Elements);
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
                    _j3Total = CurrentRoutine.J3Communication;
                    _j3Total += CurrentRoutine.J3Suitability;
                    _j3Total += CurrentRoutine.J3Composition;
                    _j3Total += CurrentRoutine.J3Staging;
                    _j3Total += CurrentRoutine.J3Difficulty;
                    _j3Total += CurrentRoutine.J3Synchronization;
                    _j3Total += CurrentRoutine.J3Spacing;
                    _j3Total += CurrentRoutine.J3Movement;
                    _j3Total += CurrentRoutine.J3Dynamics;
                    _j3Total += CurrentRoutine.J3Elements;

                    return _j3Total;
                }
            }
        }

        public double Communication
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _communication = CurrentRoutine.J1Communication;
                    _communication += CurrentRoutine.J2Communication;
                    _communication += CurrentRoutine.J3Communication;

                    return _communication;
                }
            }
        }
        public double Synchronization
        {
            get 
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _synchronization = CurrentRoutine.J1Synchronization;
                    _synchronization += CurrentRoutine.J2Synchronization;
                    _synchronization += CurrentRoutine.J3Synchronization;

                    return _synchronization;
                }
            }
        }
        public double Composition
        {
            get 
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _composition = CurrentRoutine.J1Composition;
                    _composition += CurrentRoutine.J2Composition;
                    _composition += CurrentRoutine.J3Composition;

                    return _composition;
                }
            }
        }
        public double Staging
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _staging = CurrentRoutine.J1Staging;
                    _staging += CurrentRoutine.J2Staging;
                    _staging += CurrentRoutine.J3Staging;

                    return _staging;
                }
            }
        }
        public double Suitability
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _suitability = CurrentRoutine.J1Suitability;
                    _suitability += CurrentRoutine.J2Suitability;
                    _suitability += CurrentRoutine.J3Suitability;

                    return _suitability;
                }
            }
        }
        public double Difficulty
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _difficulty = CurrentRoutine.J1Difficulty;
                    _difficulty += CurrentRoutine.J2Difficulty;
                    _difficulty += CurrentRoutine.J3Difficulty;

                    return _difficulty;
                }
            }
        }
        public double Spacing
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _spacing = CurrentRoutine.J1Spacing;
                    _spacing += CurrentRoutine.J2Spacing;
                    _spacing += CurrentRoutine.J3Spacing;

                    return _spacing;
                }
            }
        }
        public double Movement
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _movement = CurrentRoutine.J1Movement;
                    _movement += CurrentRoutine.J2Movement;
                    _movement += CurrentRoutine.J3Movement;

                    return _movement;
                }
            }
        }
        public double Dynamics
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _dynamics = CurrentRoutine.J1Dynamics;
                    _dynamics += CurrentRoutine.J2Dynamics;
                    _dynamics += CurrentRoutine.J3Dynamics;

                    return _dynamics;
                }
            }
        }
        public double Elements
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _elements = CurrentRoutine.J1Elements;
                    _elements += CurrentRoutine.J2Elements;
                    _elements += CurrentRoutine.J3Elements;

                    return _elements;
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
        public double GrandTotal
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    _grandtotal = _total - CurrentRoutine.TeamPenalty;

                    return _grandtotal;
                }
            }
        }
        public double TeamPenalty
        {
            get
            {
                if (CurrentRoutine == null)
                {
                    return 0;
                }
                else
                {
                    return CurrentRoutine.TeamPenalty;
                }
            }
            set
            {
                CurrentRoutine.TeamPenalty = value;
                NotifyOfPropertyChange(() => GrandTotal);
            }
        }
    }
}
