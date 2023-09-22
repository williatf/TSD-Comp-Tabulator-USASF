using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TSD_Comp_Tabulator_USASF.Models
{
    public class RoutineModel : INotifyPropertyChanged
    {
        private double _j1communication;
        private double _j1suitability;
        private double _j1composition;
        private double _j1staging;
        private double _j1difficulty;
        private double _j1synchronization;
        private double _j1spacing;
        private double _j1movement;
        private double _j1dynamics;
        private double _j1elements;

        private double _j2communication;
        private double _j2suitability;
        private double _j2composition;
        private double _j2staging;
        private double _j2difficulty;
        private double _j2synchronization;
        private double _j2spacing;
        private double _j2movement;
        private double _j2dynamics;
        private double _j2elements;

        private double _j3communication;
        private double _j3suitability;
        private double _j3composition;
        private double _j3staging;
        private double _j3difficulty;
        private double _j3synchronization;
        private double _j3spacing;
        private double _j3movement;
        private double _j3dynamics;
        private double _j3elements;

        private double _teamPenalty;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int EntryID { get; set; }
        public string EntryType { get; set; }
        public string Category { get; set; }
        public string Class { get; set; }
        public string Participants { get; set; }
        public string StudioName { get; set; }
        public string RoutineTitle { get; set; }


        // Judge 1 Scores
        public double J1Communication
        {
            get
            {
                return this._j1communication;
            }
            set
            {
                if (value != this._j1communication)
                {
                    this._j1communication = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Suitability
        {
            get 
            { 
                return this._j1suitability; 
            }
            set
            {
                if (value != this._j1suitability)
                {
                    this._j1suitability = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Composition
        {
            get
            {
                return this._j1composition;
            }
            set
            {
                if (value != this._j1composition)
                {
                    this._j1composition = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Staging
        {
            get
            {
                return this._j1staging;
            }
            set
            {
                if (value != this._j1staging)
                {
                    this._j1staging = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Difficulty
        {
            get
            {
                return this._j1difficulty;
            }
            set
            {
                if (value != this._j1difficulty)
                {
                    this._j1difficulty = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Synchronization
        {
            get
            {
                return this._j1synchronization;
            }
            set
            {
                if (value != this._j1synchronization)
                {
                    this._j1synchronization = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Spacing
        {
            get
            {
                return this._j1spacing;
            }
            set
            {
                if (value != this._j1spacing)
                {
                    this._j1spacing = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Movement
        {
            get
            {
                return this._j1movement;
            }
            set
            {
                if (value != this._j1movement)
                {
                    this._j1movement = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Dynamics
        {
            get
            {
                return this._j1dynamics;
            }
            set
            {
                if (value != this._j1dynamics)
                {
                    this._j1dynamics = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Elements
        {
            get
            {
                return this._j1elements;
            }
            set
            {
                if (value != this._j1elements)
                {
                    this._j1elements = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // Judge 2 Scores
        public double J2Communication
        {
            get
            {
                return this._j2communication;
            }
            set
            {
                if (value != this._j2communication)
                {
                    this._j2communication = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Suitability
        {
            get
            {
                return this._j2suitability;
            }
            set
            {
                if (value != this._j2suitability)
                {
                    this._j2suitability = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Composition
        {
            get
            {
                return this._j2composition;
            }
            set
            {
                if (value != this._j2composition)
                {
                    this._j2composition = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Staging
        {
            get
            {
                return this._j2staging;
            }
            set
            {
                if (value != this._j2staging)
                {
                    this._j2staging = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Difficulty
        {
            get
            {
                return this._j2difficulty;
            }
            set
            {
                if (value != this._j2difficulty)
                {
                    this._j2difficulty = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Synchronization
        {
            get
            {
                return this._j2synchronization;
            }
            set
            {
                if (value != this._j2synchronization)
                {
                    this._j2synchronization = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Spacing
        {
            get
            {
                return this._j2spacing;
            }
            set
            {
                if (value != this._j2spacing)
                {
                    this._j2spacing = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Movement
        {
            get
            {
                return this._j2movement;
            }
            set
            {
                if (value != this._j2movement)
                {
                    this._j2movement = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Dynamics
        {
            get
            {
                return this._j2dynamics;
            }
            set
            {
                if (value != this._j2dynamics)
                {
                    this._j2dynamics = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Elements
        {
            get
            {
                return this._j2elements;
            }
            set
            {
                if (value != this._j2elements)
                {
                    this._j2elements = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // Judge 3 Scores
        public double J3Communication
        {
            get
            {
                return this._j3communication;
            }
            set
            {
                if (value != this._j3communication)
                {
                    this._j3communication = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Suitability
        {
            get
            {
                return this._j3suitability;
            }
            set
            {
                if (value != this._j3suitability)
                {
                    this._j3suitability = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Composition
        {
            get
            {
                return this._j3composition;
            }
            set
            {
                if (value != this._j3composition)
                {
                    this._j3composition = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Staging
        {
            get
            {
                return this._j3staging;
            }
            set
            {
                if (value != this._j3staging)
                {
                    this._j3staging = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Difficulty
        {
            get
            {
                return this._j3difficulty;
            }
            set
            {
                if (value != this._j3difficulty)
                {
                    this._j3difficulty = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Synchronization
        {
            get
            {
                return this._j3synchronization;
            }
            set
            {
                if (value != this._j3synchronization)
                {
                    this._j3synchronization = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Spacing
        {
            get
            {
                return this._j3spacing;
            }
            set
            {
                if (value != this._j3spacing)
                {
                    this._j3spacing = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Movement
        {
            get
            {
                return this._j3movement;
            }
            set
            {
                if (value != this._j3movement)
                {
                    this._j3movement = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Dynamics
        {
            get
            {
                return this._j3dynamics;
            }
            set
            {
                if (value != this._j3dynamics)
                {
                    this._j3dynamics = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Elements
        {
            get
            {
                return this._j3elements;
            }
            set
            {
                if (value != this._j3elements)
                {
                    this._j3elements = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public double TeamPenalty
        {
            get
            {
                return this._teamPenalty;
            }
            set
            {
                if (value != this._teamPenalty)
                {
                    this._teamPenalty = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public object Shallowcopy()
        {
            return this.MemberwiseClone();
        }
    }


}
