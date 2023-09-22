﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSD_Comp_Tabulator_USASF.Models
{
    public class Individual
    {
        public int EntryID { get; set; }
        public string StudioName { get; set; }
        public string Dancer { get; set; }
        public string AvgScore { get; set; }
        public string Class { get; set; }
        public int Rank { get; set; }
    }
    public class Team
    {
        public int EntryID { get; set; }
        public string StudioName { get; set; }
        public string RoutineTitle { get; set; }
        public string AvgScore { get; set; }
        public string Class { get; set; }
        public int Rank { get; set; }

    }

}
