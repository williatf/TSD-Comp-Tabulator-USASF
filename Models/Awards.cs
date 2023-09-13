using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSD_Comp_Tabulator.Models
{
    public class TeamAward
    {
        public string StudioName { get; set; }
        public string AvgScore { get; set; }
        public string Class { get; set; }
        public int Rank { get; set; }
        public int NumRoutines { get; set; }
        public string EntryType { get; set; }

    }

    public class ChoreographyAward
    {
        public int EntryID { get; set; }
        public string StudioName { get; set; }
        public string Category { get; set; }
        public string Class { get; set; }
        public string AvgScore { get; set; }
        public string EntryType { get; set; }
    }

    public class BestInCategoryAward
    {
        public int EntryID { get; set; }
        public string StudioName { get; set; }
        public string Category { get; set; }
        public string RoutineTitle { get; set; }
        public string AvgScore { get; set; }
        public string Class { get; set; }

    }

    public class highPointPerformanceAward
    {
        public int EntryID { get; set; }
        public string EntryType { get; set; }
        public string RoutineTitle { get; set; }
        public string StudioName { get; set; }
        public string Class { get; set; }
        public string Category { get; set; }
        public string AvgScore { get; set; }
    }
}
