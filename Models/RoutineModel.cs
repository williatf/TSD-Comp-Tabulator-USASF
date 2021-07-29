using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TSD_Comp_Tabulator.Models
{
    public class RoutineModel : INotifyPropertyChanged
    {
        private double _j1choreography;
        private double _j1technique;
        private double _j1execution;
        private double _j1artistry;
        private double _j1showmanship;
        private double _j1appearance;
        private double _j2choreography;
        private double _j2technique;
        private double _j2execution;
        private double _j2artistry;
        private double _j2showmanship;
        private double _j2appearance;
        private double _j3choreography;
        private double _j3technique;
        private double _j3execution;
        private double _j3artistry;
        private double _j3showmanship;
        private double _j3appearance;

        public RoutineModel()
        {
            if (false)
            {
                Random r = new Random();

                _j1appearance = r.Next(4, 5);
                _j1choreography = r.Next(20, 25);
                _j1artistry = r.Next(7, 10);
                _j1execution = r.Next(20, 25);
                _j1showmanship = r.Next(7, 10);
                _j1technique = r.Next(20, 25);
                _j2appearance = r.Next(4, 5);
                _j2choreography = r.Next(20, 25);
                _j2artistry = r.Next(7, 10);
                _j2execution = r.Next(20, 25);
                _j2showmanship = r.Next(7, 10);
                _j2technique = r.Next(20, 25);
                _j3appearance = r.Next(4, 5);
                _j3choreography = r.Next(20, 25);
                _j3artistry = r.Next(7, 10);
                _j3execution = r.Next(20, 25);
                _j3showmanship = r.Next(7, 10);
                _j3technique = r.Next(20, 25);

            }
        }

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
        public double J1Choreography
        {
            get
            {
                return this._j1choreography;
            }
            set
            {
                if (value != this._j1choreography)
                {
                    this._j1choreography = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Technique
        {
            get 
            { 
                return this._j1technique; 
            }
            set
            {
                if (value != this._j1technique)
                {
                    this._j1technique = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Execution
        {
            get
            {
                return this._j1execution;
            }
            set
            {
                if (value != this._j1execution)
                {
                    this._j1execution = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Artistry
        {
            get
            {
                return this._j1artistry;
            }
            set
            {
                if (value != this._j1artistry)
                {
                    this._j1artistry = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Showmanship
        {
            get
            {
                return this._j1showmanship;
            }
            set
            {
                if (value != this._j1showmanship)
                {
                    this._j1showmanship = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J1Appearance
        {
            get
            {
                return this._j1appearance;
            }
            set
            {
                if (value != this._j1appearance)
                {
                    this._j1appearance = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // Judge 2 Scores
        public double J2Choreography
        {
            get
            {
                return this._j2choreography;
            }
            set
            {
                if (value != this._j2choreography)
                {
                    this._j2choreography = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Technique
        {
            get
            {
                return this._j2technique;
            }
            set
            {
                if (value != this._j2technique)
                {
                    this._j2technique = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Execution
        {
            get
            {
                return this._j2execution;
            }
            set
            {
                if (value != this._j2execution)
                {
                    this._j2execution = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Artistry
        {
            get
            {
                return this._j2artistry;
            }
            set
            {
                if (value != this._j2artistry)
                {
                    this._j2artistry = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Showmanship
        {
            get
            {
                return this._j2showmanship;
            }
            set
            {
                if (value != this._j2showmanship)
                {
                    this._j2showmanship = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J2Appearance
        {
            get
            {
                return this._j2appearance;
            }
            set
            {
                if (value != this._j2appearance)
                {
                    this._j2appearance = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // Judge 3 Scores
        public double J3Choreography
        {
            get
            {
                return this._j3choreography;
            }
            set
            {
                if (value != this._j3choreography)
                {
                    this._j3choreography = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Technique
        {
            get
            {
                return this._j3technique;
            }
            set
            {
                if (value != this._j3technique)
                {
                    this._j3technique = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Execution
        {
            get
            {
                return this._j3execution;
            }
            set
            {
                if (value != this._j3execution)
                {
                    this._j3execution = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Artistry
        {
            get
            {
                return this._j3artistry;
            }
            set
            {
                if (value != this._j3artistry)
                {
                    this._j3artistry = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Showmanship
        {
            get
            {
                return this._j3showmanship;
            }
            set
            {
                if (value != this._j3showmanship)
                {
                    this._j3showmanship = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double J3Appearance
        {
            get
            {
                return this._j3appearance;
            }
            set
            {
                if (value != this._j3appearance)
                {
                    this._j3appearance = value;
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
