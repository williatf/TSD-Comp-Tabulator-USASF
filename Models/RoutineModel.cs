using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSD_Comp_Tabulator.Models
{
    public class RoutineModel
    {
        public int EntryID { get; set; }
        public string EntryType { get; set; }
        public string Category { get; set; }
        public string Class { get; set; }
        public string Participants { get; set; }
        public string StudioName { get; set; }
        public string RoutineTitle { get; set; }
        public double J1Technique { get; set; }
        public double J1Choreography { get; set; }
        public double J1Execution { get; set; }
        public double J1Artistry { get; set; }
        public double J1Showmanship { get; set; }
        public double J1Appearance { get; set; }
        public double J2Technique { get; set; }
        public double J2Choreography { get; set; }
        public double J2Execution { get; set; }
        public double J2Artistry { get; set; }
        public double J2Showmanship { get; set; }
        public double J2Appearance { get; set; }
        public double J3Technique { get; set; }
        public double J3Choreography { get; set; }
        public double J3Execution { get; set; }
        public double J3Artistry { get; set; }
        public double J3Showmanship { get; set; }
        public double J3Appearance { get; set; }
        
        public object Shallowcopy()
        {
            return this.MemberwiseClone();
        }
    }


}
