using Caliburn.Micro;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using TSD_Comp_Tabulator.Models;

namespace TSD_Comp_Tabulator.ViewModels
{
    public class ReportsViewModel : Screen
    {

/*        private FlowDocument _solos = new FlowDocument();
        private FlowDocument _duets = new FlowDocument();
        private FlowDocument _trios = new FlowDocument();
        private FlowDocument _ensembles = new FlowDocument();
        private FlowDocument _socials = new FlowDocument();
        private FlowDocument _officers = new FlowDocument();
*/      
        private FlowDocument _teams = new FlowDocument();
        private FlowDocument _specialty = new FlowDocument();
        private FlowDocument _champions = new FlowDocument();
        
/*        private List<string> list;
        private List<string> classList;
*/
        public ReportsViewModel()
        {
/*            generateSolos(_solos);
            generateDuets(_duets);
            generateTrios(_trios);
            generateEnsembles_new(_ensembles);
            generateSocials(_socials);
            generateOfficers(_officers);
*/            
            generateTeams(_teams);
            generateSpecialty(_specialty);
            generateChampions(_champions);
        }
        // flow documents
/*
        public FlowDocument Solos
        {
            get { return _solos; } 
        
        }
        public FlowDocument Duets
        {
            get { return _duets; }

        }
        public FlowDocument Trios
        {
            get { return _trios; }

        }
        public FlowDocument Ensembles
        {
            get { return _ensembles; }

        }
        public FlowDocument Socials
        {
            get { return _socials; }

        }
        public FlowDocument Officers
        {
            get { return _officers; }

        }
*/        
        public FlowDocument Teams
        {
            get { return _teams; }

        }
        public FlowDocument Specialty
        {
            get { return _specialty; }

        }
        public FlowDocument Champions
        {
            get { return _champions; }

        }
/*
        private FlowDocument generateSolos(FlowDocument fd)
        {
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Solo Trophies"));
            p.FontSize = 24;
            p.Margin = new Thickness(0, 0, 0, 0);
            fd.Blocks.Add(p);

            // Description
            p = new Paragraph(new Run("Highest Scores at top!!\n\n" +
                "Only the top 5 performers should receive trophies. In a tie situation, all tied competitors would receive the same award.  For example, if there is a tie between two dancers for 1st runner up, both dancers would receive 1st runner up trophies, you would skip 2nd runner up, and the next dancer would receive the 3rd runner up trophy."
                )
            );
            p.FontSize = 12;
            fd.Blocks.Add(p);

            // Awards
            string category = "Studio";
            list = SqliteDataAccess.getSoloClasses(category);

            if (list.Count > 0)
            {
                p = new Paragraph(new Run(category + "s"));
                p.FontSize = 16;
                p.Foreground = Brushes.Wheat;
                p.Background = Brushes.Brown;
                p.FontWeight = FontWeights.Bold;
                p.TextAlignment = TextAlignment.Left;
                p.Padding = new Thickness(5, 5, 0, 5);
                fd.Blocks.Add(p);

                // loop over each solo class and print a table of results
                foreach (string vClass in list)
                {
                    fd.Blocks.Add(soloTable(vClass, category));
                }
            }

            category = "School";
            list = SqliteDataAccess.getSoloClasses(category);

            if (list.Count > 0)
            {
                p = new Paragraph(new Run(category + "s"));
                p.FontSize = 16;
                p.Foreground = Brushes.Wheat;
                p.Background = Brushes.Brown;
                p.FontWeight = FontWeights.Bold;
                p.TextAlignment = TextAlignment.Left;
                p.Padding = new Thickness(5,5,0,5);
                fd.Blocks.Add(p);

                // loop over each solo class and print a table of results
                foreach (string vClass in list)
                {
                    fd.Blocks.Add(soloTable(vClass, category));
                }
            }

            return fd;
        }
        private FlowDocument generateDuets(FlowDocument fd)
        {
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Duet Trophies"));
            p.FontSize = 24;
            p.BreakPageBefore = true;
            fd.Blocks.Add(p);

            // Description
            p = new Paragraph(new Run("Highest Scores at top!!\n\n" +
                "Top 3 scores within each age group, for both Studios and Schools.\n\n" +
                "Only the top 5 performers should receive trophies. In a tie situation, all tied competitors would receive the same award.  For example, if there is a tie between two dancers for 1st runner up, both dancers would receive 1st runner up trophies, you would skip 2nd runner up, and the next dancer would receive the 3rd runner up trophy."
                )
            );
            p.FontSize = 12;
            fd.Blocks.Add(p);

            // Awards
            string category = "Studio";
            list = SqliteDataAccess.getDuetClasses(category);

            if (list.Count > 0)
            {
                p = new Paragraph(new Run(category + "s"));
                p.FontSize = 16;
                p.Foreground = Brushes.Wheat;
                p.Background = Brushes.Brown;
                p.FontWeight = FontWeights.Bold;
                p.TextAlignment = TextAlignment.Left;
                p.Padding = new Thickness(5, 5, 0, 5);
                fd.Blocks.Add(p);

                // loop over each solo class and print a table of results
                foreach (string vClass in list)
                {
                    fd.Blocks.Add(duetTable(vClass, category));
                }
            }

            category = "School";
            list = SqliteDataAccess.getDuetClasses(category);

            if (list.Count > 0)
            {
                p = new Paragraph(new Run(category + "s"));
                p.FontSize = 16;
                p.Foreground = Brushes.Wheat;
                p.Background = Brushes.Brown;
                p.FontWeight = FontWeights.Bold;
                p.TextAlignment = TextAlignment.Left;
                p.Padding = new Thickness(5, 5, 0, 5);
                fd.Blocks.Add(p);

                fd.Blocks.Add(duetTable("Middle School", "MiddleSchool"));
                fd.Blocks.Add(duetTable("High School", "HighSchool"));
            }

            return fd;
        }
        private FlowDocument generateTrios(FlowDocument fd)
        {
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Trio Trophies"));
            p.FontSize = 24;
            p.BreakPageBefore = true;
            fd.Blocks.Add(p);

            // Description
            p = new Paragraph(new Run("Highest Scores at top!!\n\n" +
                "Top 3 scores within each age group, for both Studios and Schools.\n\n" +
                "Only the top 5 performers should receive trophies. In a tie situation, all tied competitors would receive the same award.  For example, if there is a tie between two dancers for 1st runner up, both dancers would receive 1st runner up trophies, you would skip 2nd runner up, and the next dancer would receive the 3rd runner up trophy."
                )
            );
            p.FontSize = 12;
            fd.Blocks.Add(p);

            // Awards
            string category = "Studio";
            list = SqliteDataAccess.getTrioClasses(category);

            if (list.Count > 0)
            {
                p = new Paragraph(new Run(category + "s"));
                p.FontSize = 16;
                p.Foreground = Brushes.Wheat;
                p.Background = Brushes.Brown;
                p.FontWeight = FontWeights.Bold;
                p.TextAlignment = TextAlignment.Left;
                p.Padding = new Thickness(5, 5, 0, 5);
                fd.Blocks.Add(p);

                // loop over each solo class and print a table of results
                foreach (string vClass in list)
                {
                    fd.Blocks.Add(trioTable(vClass, category));
                }
            }

            category = "School";
            list = SqliteDataAccess.getTrioClasses(category);

            if (list.Count > 0)
            {
                p = new Paragraph(new Run(category + "s"));
                p.FontSize = 16;
                p.Foreground = Brushes.Wheat;
                p.Background = Brushes.Brown;
                p.FontWeight = FontWeights.Bold;
                p.TextAlignment = TextAlignment.Left;
                p.Padding = new Thickness(5, 5, 0, 5);
                fd.Blocks.Add(p);

                fd.Blocks.Add(trioTable("Middle School", "MiddleSchool"));
                fd.Blocks.Add(trioTable("High School", "HighSchool"));
            }

            return fd;
        }
        private FlowDocument generateEnsembles(FlowDocument fd)
        {
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Ensemble Trophies"));
            p.FontSize = 24;
            p.BreakPageBefore = true;
            fd.Blocks.Add(p);

            // Description
            p = new Paragraph(new Run("Highest Scores at top!!\n\n" +
                "Top 3 scores within each age group, for both Studios and Schools.\n\n" +
                "Only the top 5 routines should receive trophies. In a tie situation, all tied routines would receive the same award."
                )
            );
            p.FontSize = 12;
            fd.Blocks.Add(p);

            // Awards
            string category = "Studio";
            list = SqliteDataAccess.getEnsembleEntryTypes(category);

            if (list.Count > 0)
            {
                p = new Paragraph(new Run(category + "s"));
                p.FontSize = 16;
                p.Foreground = Brushes.Wheat;
                p.Background = Brushes.Brown;
                p.FontWeight = FontWeights.Bold;
                p.TextAlignment = TextAlignment.Left;
                p.Padding = new Thickness(5, 5, 0, 5);
                fd.Blocks.Add(p);

                // loop over each ensemble entrytype
                foreach (string entryType in list)
                {

                    p = new Paragraph(new Run("Entry Type: " + entryType));
                    p.FontSize = 16;
                    p.Foreground = Brushes.Brown;
                    p.Background = Brushes.Wheat;
                    p.FontWeight = FontWeights.SemiBold;
                    p.TextAlignment = TextAlignment.Left;
                    p.Padding = new Thickness(5, 5, 0, 5);
                    fd.Blocks.Add(p);

                    classList = SqliteDataAccess.getEnsembleClasses(category,entryType);

                    // loop over each class and print a table of results
                    foreach (string vClass in classList)
                    {
                        fd.Blocks.Add(ensembleTable(vClass, entryType));
                    }
                }
            }

            category = "School";
            list = SqliteDataAccess.getEnsembleEntryTypes(category);

            if (list.Count > 0)
            {
                p = new Paragraph(new Run(category + "s"));
                p.FontSize = 16;
                p.Foreground = Brushes.Wheat;
                p.Background = Brushes.Brown;
                p.FontWeight = FontWeights.Bold;
                p.TextAlignment = TextAlignment.Left;
                p.Padding = new Thickness(5, 5, 0, 5);
                fd.Blocks.Add(p);

                // loop over each ensemble entrytype
                foreach (string entryType in list)
                {

                    p = new Paragraph(new Run("Entry Type: " + entryType));
                    p.FontSize = 16;
                    p.Foreground = Brushes.Brown;
                    p.Background = Brushes.Wheat;
                    p.FontWeight = FontWeights.SemiBold;
                    p.TextAlignment = TextAlignment.Left;
                    p.Padding = new Thickness(5, 5, 0, 5);
                    fd.Blocks.Add(p);

                    classList = SqliteDataAccess.getEnsembleClasses(category, entryType);

                    // loop over each class and print a table of results
                    foreach (string vClass in classList)
                    {
                        fd.Blocks.Add(ensembleTable(vClass, entryType));
                    }
                }
            }

            return fd;
        }
        private FlowDocument generateEnsembles_new(FlowDocument fd)
        {
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Ensemble Trophies"));
            p.FontSize = 24;
            p.BreakPageBefore = true;
            fd.Blocks.Add(p);

            // Description
            p = new Paragraph(new Run("Highest Scores at top!!\n\n" +
                "Top 3 scores within each age group, for both Studios and Schools.\n\n" +
                "Only the top 5 routines should receive trophies. In a tie situation, all tied routines would receive the same award."
                )
            );
            p.FontSize = 12;
            fd.Blocks.Add(p);

            // Awards
            // get ordered list of entry types
            list = SqliteDataAccess.getEnsembleEntryTypes_new();

            if (list.Count > 0)
            {
                //p = new Paragraph(new Run(category + "s"));
                //p.FontSize = 16;
                //p.Foreground = Brushes.Wheat;
                //p.Background = Brushes.Brown;
                //p.FontWeight = FontWeights.Bold;
                //p.TextAlignment = TextAlignment.Left;
                //p.Padding = new Thickness(5, 5, 0, 5);
                //fd.Blocks.Add(p);

                // loop over each ensemble entrytype
                foreach (string entryType in list)
                {

                    p = new Paragraph(new Run("Entry Type: " + entryType));
                    p.FontSize = 16;
                    p.Foreground = Brushes.Brown;
                    p.Background = Brushes.Wheat;
                    p.FontWeight = FontWeights.SemiBold;
                    p.TextAlignment = TextAlignment.Left;
                    p.Padding = new Thickness(5, 5, 0, 5);
                    fd.Blocks.Add(p);

                    // do studios by Class
                    string category = "Studio";

                    classList = SqliteDataAccess.getEnsembleClasses(category, entryType);

                    // loop over each class and print a table of results
                    foreach (string vClass in classList)
                    {
                        fd.Blocks.Add(ensembleTable(vClass, entryType));
                    }

                    // do schools by Middle School and High School
                    category = "Public/Private School";
                    string school = "Middle School";

                    if (ensembleTable_School(school, category, entryType).IsInitialized)
                    {
                        fd.Blocks.Add(ensembleTable_School(school, category, entryType));
                    }
                    school = "High School";

                    if (ensembleTable_School(school, category, entryType).IsInitialized)
                    {
                        fd.Blocks.Add(ensembleTable_School(school, category, entryType));
                    }

                }
            }

            return fd;
        }
        private FlowDocument generateSocials(FlowDocument fd)
        {
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Social Officer Trophies"));
            p.FontSize = 24;
            p.BreakPageBefore = true;
            fd.Blocks.Add(p);

            // Description
            p = new Paragraph(new Run("Highest Scores at top!!\n\n" +
                "Top 3 scores within each age group, for both Studios and Schools.\n\n" +
                "Only the top 5 performers should receive trophies. In a tie situation, all tied competitors would receive the same award."
                )
            );
            p.FontSize = 12;
            fd.Blocks.Add(p);

            // Awards
            list = SqliteDataAccess.getSocialClasses();

            if (list.Count > 0)
            {
                // loop over each solo class and print a table of results
                foreach (string vClass in list)
                {
                    fd.Blocks.Add(socialTable(vClass));
                }
            }

            return fd;
        }
        private FlowDocument generateOfficers(FlowDocument fd)
        {
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Dance Officer Line Awards"));
            p.FontSize = 24;
            p.BreakPageBefore = true;
            fd.Blocks.Add(p);

            fd.Blocks.Add(officer_and_team_Awards("Officer"));

            return fd;
        }
*/        
        private FlowDocument generateTeams(FlowDocument fd)
        {
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Team Awards"));
            p.FontSize = 24;
            p.BreakPageBefore = true;
            fd.Blocks.Add(p);

            fd.Blocks.Add(officer_and_team_Awards("Team"));

            return fd;
        }
        private FlowDocument generateSpecialty(FlowDocument fd)
        {
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Specialty Awards"));
            p.FontSize = 24;
            p.BreakPageBefore = true;
            fd.Blocks.Add(p);

            #region High Point Performance
            // High Point Performance
            p = new Paragraph(new Run("High Point Performance"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            fd.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to the ONE performance with the highest score of the day."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            fd.Blocks.Add(p);

            fd.Blocks.Add(highPointPerformanceAwardTable());
            #endregion

            #region Artistry
            // Artistry
            p = new Paragraph(new Run("Artistry Award"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            fd.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to the ONE performance selected by the Judges based on Musical Interpretation, Artistry, and Performance Appeal."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            fd.Blocks.Add(p);

            p = new Paragraph(new Run("[... Anounce Judges Selection...]"));
            p.FontSize = 16;
            p.Foreground = Brushes.Black;
            p.Padding = new Thickness(3, 0, 0, 3);
            fd.Blocks.Add(p);

            #endregion

            #region Trendsetters Award of Excellence
            // Trendsetters Award of Excellence
            p = new Paragraph(new Run("Trendsetters Award of Excellence"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            fd.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to the Teams and Officers that received the highest average total score for 3 routines."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            fd.Blocks.Add(p);

            //p = new Paragraph(new Run("Officer Line Awards"));
            //p.FontSize = 14;
            //p.Foreground = Brushes.Blue;
            //p.Padding = new Thickness(3, 0, 0, 3);
            //fd.Blocks.Add(p);

            fd.Blocks.Add(awardOfExcellenceTable("Officer_Team_Combined"));

            //p = new Paragraph(new Run("Team Awards"));
            //p.FontSize = 14;
            //p.Foreground = Brushes.Blue;
            //p.Padding = new Thickness(3, 0, 0, 3);
            //fd.Blocks.Add(p);

            //fd.Blocks.Add(awardOfExcellenceTable("Team"));

            #endregion

            return fd;
        }
        private FlowDocument generateChampions(FlowDocument fd)
        {
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Overall Grand Champion Awards"));
            p.FontSize = 24;
            p.BreakPageBefore = true;
            fd.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to the Officer Lines and Teams receiving the highest average total score for 3 routines."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            fd.Blocks.Add(p);

            #region Award for Officers
            // Award for Officers
            p = new Paragraph(new Run("Award for Officers"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            fd.Blocks.Add(p);

            fd.Blocks.Add(championTable("Studio","Officer"));
            fd.Blocks.Add(championTable("MiddleSchool","Officer"));
            fd.Blocks.Add(championTable("School","Officer"));

            #endregion

            #region Award for Teams
            // Award for Teams
            p = new Paragraph(new Run("Award for Teams"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            fd.Blocks.Add(p);

            fd.Blocks.Add(championTable("Studio", "Team"));
            fd.Blocks.Add(championTable("MiddleSchool", "Team"));
            fd.Blocks.Add(championTable("School", "Team"));

            #endregion

            return fd;
        }

        private Block officer_and_team_Awards(string db_table)
        {

            Paragraph p;
            Section blk = new Section();

            #region Superior Awards - Out of Scope
            // Superior Awards
/*            p = new Paragraph(new Run("Superior Awards"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            blk.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to Teams and Officers competing in less than 3 routines and scoring 85 or higher."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            blk.Blocks.Add(p);

            blk.Blocks.Add(superiorTable(db_table));
*/
            #endregion

            #region Sweepstakes Awards - Out of Scope
/*            // Sweepstakes Awards
            p = new Paragraph(new Run("Sweepstakes Awards"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            blk.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to Teams and Officers receiving an average score of 85-90 on 3 routines."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            blk.Blocks.Add(p);

            blk.Blocks.Add(sweepstakesTable(db_table));
*/
            #endregion

            #region Super Sweepstakes Awards - Out of Scope
/*            // Super Sweepstakes Awards
            p = new Paragraph(new Run("Super Sweepstakes Awards"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            blk.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to Teams and Officers receiving an average score of 90-95 on 3 routines."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            blk.Blocks.Add(p);

            blk.Blocks.Add(superSweepstakesTable(db_table));
*/
            #endregion

            #region Judges Awards - Out of Scope
/*            // Judges Awards
            p = new Paragraph(new Run("Judges Awards"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            blk.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to Teams and Officers receiving an average score of 95 or higher on 3 routines."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            blk.Blocks.Add(p);

            blk.Blocks.Add(judgesTable(db_table));
*/            
            #endregion

            #region Technical Merit Awards - Out of Scope
/*            // Technical Merit Awards
            p = new Paragraph(new Run("Technical Merit Awards"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            blk.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to Teams and Officers receiving an average technique score of 23 or higher on 3 routines."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            blk.Blocks.Add(p);

            blk.Blocks.Add(technicalMeritTable(db_table));
*/            
            #endregion

            #region High Point Technique Award - Out of Scope
/*            // High Point Technique Award
            p = new Paragraph(new Run("Overall High Point Technique Award"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            blk.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to the Team and Officers, regardless of size, with the highest overall average in technique for 3 routines. Must have 8 or more teams to award."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            blk.Blocks.Add(p);

            blk.Blocks.Add(highPointTechniqueTable(db_table));
*/
            #endregion

            #region Precision Merit Awards - Out of Scope
/*            // Precision Merit Awards
            p = new Paragraph(new Run("Precision Merit Awards"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            blk.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to Teams and Officers receiving an average precision score of 23 or higher on 3 routines."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            blk.Blocks.Add(p);

            blk.Blocks.Add(precisionMeritTable(db_table));
*/
            #endregion

            #region High Point Precision Award - Out of Scope
/*            // High Point Precision Award
            p = new Paragraph(new Run("Overall High Point Precision Award"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            blk.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to the Team and Officers, regardless of size, with the highest overall average in precision for 3 routines. Must have 8 or more teams to award."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            blk.Blocks.Add(p);

            blk.Blocks.Add(highPointPrecisionTable(db_table));
*/
            #endregion

            #region Outstanding Choreography - Out of Scope
/*            // Outstanding Choreography
            p = new Paragraph(new Run("Outstanding Choreography"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            blk.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to the Teams and Officers receiving an average choreography score of 23 or higher for any routine entered."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            blk.Blocks.Add(p);

            blk.Blocks.Add(outstandingChoreographyTable(db_table));
*/
            #endregion

            #region Best In Category
            // Best In Category
            p = new Paragraph(new Run("Best In Category"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            blk.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to Teams with the highest score in a category."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            blk.Blocks.Add(p);

/*            p = new Paragraph(new Run("Must score 90 or higher to qualify."));
            p.FontSize = 12;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            blk.Blocks.Add(p);
*/
            string vClass = "Studio";
            blk.Blocks.Add(bestInCategoryTable(vClass,db_table));

            vClass = "MiddleSchool";
            blk.Blocks.Add(bestInCategoryTable(vClass, db_table));

            vClass = "School";
            blk.Blocks.Add(bestInCategoryTable(vClass, db_table));
            #endregion

            #region Best In Class
            // Best In Class
            p = new Paragraph(new Run("Best In Class"));
            p.FontSize = 16;
            p.Foreground = Brushes.Wheat;
            p.Background = Brushes.Brown;
            p.FontWeight = FontWeights.Bold;
            p.TextAlignment = TextAlignment.Left;
            p.Padding = new Thickness(5, 5, 0, 5);
            blk.Blocks.Add(p);

            p = new Paragraph(new Run("Awarded to the officer lines and teams with the highest average score for 3 routines in each Division and Classification."));
            p.FontSize = 14;
            p.Foreground = Brushes.Gray;
            p.Padding = new Thickness(3, 0, 0, 3);
            blk.Blocks.Add(p);

            // Class:
            p = new Paragraph(new Run("Non-Elite"));
            p.FontSize = 16;
            p.Foreground = Brushes.Blue;
            p.FontWeight = FontWeights.Bold;
            blk.Blocks.Add(p);

            blk.Blocks.Add(bestInClassTable(db_table));

            #endregion

            #region Best In Class Elite
            //// Best In Class Elite
            //p = new Paragraph(new Run("Best In Class"));
            //p.FontSize = 16;
            //p.Foreground = Brushes.Wheat;
            //p.Background = Brushes.Brown;
            //p.FontWeight = FontWeights.Bold;
            //p.TextAlignment = TextAlignment.Left;
            //p.Padding = new Thickness(5, 5, 0, 5);
            //blk.Blocks.Add(p);

            //p = new Paragraph(new Run("Awarded to the officer lines and teams with the highest average score for 3 routines in each Division and Classification."));
            //p.FontSize = 14;
            //p.Foreground = Brushes.Gray;
            //p.Padding = new Thickness(3, 0, 0, 3);
            //blk.Blocks.Add(p);

            // Class:
            p = new Paragraph(new Run("Elite"));
            p.FontSize = 16;
            p.Foreground = Brushes.Blue;
            p.FontWeight = FontWeights.Bold;
            blk.Blocks.Add(p);

            blk.Blocks.Add(bestInClassEliteTable(db_table));

            #endregion

            return blk;

        }

        private Table soloTable(string vClass, string category)
        {
            // create the table
            Table tbl = new Table();

            // create 5 columns and add them to the table's column collection
            int numCols = 5;
            for (int x = 0; x < numCols; x++)
            {
                tbl.Columns.Add(new TableColumn());
            }

            // create and add and empty TableRowGroup to hold the table's rows
            tbl.RowGroups.Add(new TableRowGroup());

            // Class:
            Paragraph p = new Paragraph(new Run("Class: " + vClass));
            p.FontSize = 16;
            p.Foreground = Brushes.Blue;
            p.FontWeight = FontWeights.Bold;

            // add the class header to the table
            TableRow header_row = new TableRow();
            TableCell header_cell = new TableCell(p);
            header_cell.ColumnSpan = 5;
            header_cell.Padding = new Thickness(0, 0, 0, 10);
            header_row.Cells.Add(header_cell);
            tbl.RowGroups[0].Rows.Add(header_row);

            // add the first (title) row
            tbl.RowGroups[0].Rows.Add(new TableRow());

            // alias the current row
            TableRow currentRow = tbl.RowGroups[0].Rows[1];

            // format the header row
            currentRow.FontSize = 12;
            currentRow.FontWeight = FontWeights.Bold;
            currentRow.Background = Brushes.Gray;


            // add content
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Rank"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("EntryID"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("StudioName"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Dancer"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

            for (int n = 0; n < currentRow.Cells.Count; n++)
            {
                currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                currentRow.Cells[n].BorderBrush = Brushes.Black;
                currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
            }

            // get trophies
            List<Individual> trophies = SqliteDataAccess.getSoloTrophies(vClass, category);

            // if there are trophies
            if (trophies.Count > 0)
            {
                int i = 2; //table row index
                foreach (Individual trophy in trophies)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.Rank.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.EntryID.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.Dancer))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }
            }

            tbl.Columns[0].Width = new GridLength(75);
            tbl.Columns[1].Width = new GridLength(75);
            tbl.Columns[2].Width = new GridLength(200);
            tbl.Columns[3].Width = new GridLength(200);
            tbl.Columns[4].Width = new GridLength(75);

            return tbl;
        }
        private Table duetTable(string vClass, string category)
        {
            // create the table
            Table tbl = new Table();

            // create 5 columns and add them to the table's column collection
            int numCols = 5;
            for (int x = 0; x < numCols; x++)
            {
                tbl.Columns.Add(new TableColumn());
            }

            // create and add and empty TableRowGroup to hold the table's rows
            tbl.RowGroups.Add(new TableRowGroup());

            // Class:
            Paragraph p = new Paragraph(new Run("Class: " + vClass));
            p.FontSize = 16;
            p.Foreground = Brushes.Blue;
            p.FontWeight = FontWeights.Bold;

            // add the class header to the table
            TableRow header_row = new TableRow();
            TableCell header_cell = new TableCell(p);
            header_cell.ColumnSpan = 5;
            header_cell.Padding = new Thickness(0, 0, 0, 10);
            header_row.Cells.Add(header_cell);
            tbl.RowGroups[0].Rows.Add(header_row);

            // add the first (title) row
            tbl.RowGroups[0].Rows.Add(new TableRow());

            // alias the current row
            TableRow currentRow = tbl.RowGroups[0].Rows[1];

            // format the header row
            currentRow.FontSize = 12;
            currentRow.FontWeight = FontWeights.Bold;
            currentRow.Background = Brushes.Gray;


            // add content
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Rank"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("EntryID"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("StudioName"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Dancers"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

            for (int n = 0; n < currentRow.Cells.Count; n++)
            {
                currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                currentRow.Cells[n].BorderBrush = Brushes.Black;
                currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
            }

            // get trophies
            List<Individual> trophies = SqliteDataAccess.getDuetTrophies(vClass, category);

            // if there are trophies
            if (trophies.Count > 0)
            {
                int i = 2; //table row index
                foreach (Individual trophy in trophies)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.Rank.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.EntryID.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.Dancer.Replace(", ","\n")))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }
            }

            tbl.Columns[0].Width = new GridLength(75);
            tbl.Columns[1].Width = new GridLength(75);
            tbl.Columns[2].Width = new GridLength(200);
            tbl.Columns[3].Width = new GridLength(200);
            tbl.Columns[4].Width = new GridLength(75);

            return tbl;
        }
        private Table trioTable(string vClass, string category)
        {
            // create the table
            Table tbl = new Table();

            // create 4 columns and add them to the table's column collection
            int numCols = 5;
            for (int x = 0; x < numCols; x++)
            {
                tbl.Columns.Add(new TableColumn());
            }

            // create and add and empty TableRowGroup to hold the table's rows
            tbl.RowGroups.Add(new TableRowGroup());

            // Class:
            Paragraph p = new Paragraph(new Run("Class: " + vClass));
            p.FontSize = 16;
            p.Foreground = Brushes.Blue;
            p.FontWeight = FontWeights.Bold;

            // add the class header to the table
            TableRow header_row = new TableRow();
            TableCell header_cell = new TableCell(p);
            header_cell.ColumnSpan = 5;
            header_cell.Padding = new Thickness(0, 0, 0, 10);
            header_row.Cells.Add(header_cell);
            tbl.RowGroups[0].Rows.Add(header_row);

            // add the first (title) row
            tbl.RowGroups[0].Rows.Add(new TableRow());

            // alias the current row
            TableRow currentRow = tbl.RowGroups[0].Rows[1];

            // format the header row
            currentRow.FontSize = 12;
            currentRow.FontWeight = FontWeights.Bold;
            currentRow.Background = Brushes.Gray;


            // add content
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Rank"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("EntryID"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("StudioName"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Dancers"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

            for (int n = 0; n < currentRow.Cells.Count; n++)
            {
                currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                currentRow.Cells[n].BorderBrush = Brushes.Black;
                currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
            }

            // get trophies
            List<Individual> trophies = SqliteDataAccess.getTrioTrophies(vClass, category);

            // if there are trophies
            if (trophies.Count > 0)
            {
                int i = 2; //table row index
                foreach (Individual trophy in trophies)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.Rank.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.EntryID.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.Dancer.Replace(", ", "\n")))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }
            }

            tbl.Columns[0].Width = new GridLength(75);
            tbl.Columns[1].Width = new GridLength(75);
            tbl.Columns[2].Width = new GridLength(200);
            tbl.Columns[3].Width = new GridLength(200);
            tbl.Columns[4].Width = new GridLength(75);

            return tbl;
        }
        private Table ensembleTable(string vClass, string entryType)
        {
            // create the table
            Table tbl = new Table();

            // create 4 columns and add them to the table's column collection
            int numCols = 5;
            for (int x = 0; x < numCols; x++)
            {
                tbl.Columns.Add(new TableColumn());
            }

            // create and add and empty TableRowGroup to hold the table's rows
            tbl.RowGroups.Add(new TableRowGroup());

            // Class:
            Paragraph p = new Paragraph(new Run("Class: " + vClass));
            p.FontSize = 16;
            p.Foreground = Brushes.Blue;
            p.FontWeight = FontWeights.Bold;

            // add the class header to the table
            TableRow header_row = new TableRow();
            TableCell header_cell = new TableCell(p);
            header_cell.ColumnSpan = 5;
            header_cell.Padding = new Thickness(0, 0, 0, 10);
            header_row.Cells.Add(header_cell);
            tbl.RowGroups[0].Rows.Add(header_row);

            // add the first (title) row
            tbl.RowGroups[0].Rows.Add(new TableRow());

            // alias the current row
            TableRow currentRow = tbl.RowGroups[0].Rows[1];

            // format the header row
            currentRow.FontSize = 12;
            currentRow.FontWeight = FontWeights.Bold;
            currentRow.Background = Brushes.Gray;


            // add content
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Rank"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("EntryID"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("StudioName"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Routine Title"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

            for (int n = 0; n < currentRow.Cells.Count; n++)
            {
                currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                currentRow.Cells[n].BorderBrush = Brushes.Black;
                currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
            }

            // get trophies
            List<Team> trophies = SqliteDataAccess.getEnsembleTrophies(vClass, entryType);

            // if there are trophies
            if (trophies.Count > 0)
            {
                int i = 2; //table row index
                foreach (Team trophy in trophies)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.Rank.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.EntryID.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.RoutineTitle))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }
            }

            tbl.Columns[0].Width = new GridLength(75);
            tbl.Columns[1].Width = new GridLength(75);
            tbl.Columns[2].Width = new GridLength(200);
            tbl.Columns[3].Width = new GridLength(200);
            tbl.Columns[4].Width = new GridLength(75);

            return tbl;
        }
        private Table ensembleTable_School(string vClass, string category, string entryType)
        {
            // create the table
            Table tbl = new Table();

            // get trophies
            List<Team> trophies = SqliteDataAccess.getEnsembleTrophies_Schools(vClass, category, entryType);

            // if there are trophies
            if (trophies.Count > 0)
            {
                // create 4 columns and add them to the table's column collection
                int numCols = 5;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // Class:
                Paragraph p = new Paragraph(new Run("Class: " + vClass));
                p.FontSize = 16;
                p.Foreground = Brushes.Blue;
                p.FontWeight = FontWeights.Bold;

                // add the class header to the table
                TableRow header_row = new TableRow();
                TableCell header_cell = new TableCell(p);
                header_cell.ColumnSpan = 5;
                header_cell.Padding = new Thickness(0, 0, 0, 10);
                header_row.Cells.Add(header_cell);
                tbl.RowGroups[0].Rows.Add(header_row);

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[1];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Rank"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("EntryID"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("StudioName"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Routine Title"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 2; //table row index
                foreach (Team trophy in trophies)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.Rank.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.EntryID.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.RoutineTitle))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(75);
                tbl.Columns[1].Width = new GridLength(75);
                tbl.Columns[2].Width = new GridLength(200);
                tbl.Columns[3].Width = new GridLength(200);
                tbl.Columns[4].Width = new GridLength(75);

            }

            return tbl;
        }
        private Table socialTable(string vClass)
        {
            // create the table
            Table tbl = new Table();

            // create 4 columns and add them to the table's column collection
            int numCols = 5;
            for (int x = 0; x < numCols; x++)
            {
                tbl.Columns.Add(new TableColumn());
            }

            // create and add and empty TableRowGroup to hold the table's rows
            tbl.RowGroups.Add(new TableRowGroup());

            // Class:
            Paragraph p = new Paragraph(new Run("Class: " + vClass));
            p.FontSize = 16;
            p.Foreground = Brushes.Blue;
            p.FontWeight = FontWeights.Bold;

            // add the class header to the table
            TableRow header_row = new TableRow();
            TableCell header_cell = new TableCell(p);
            header_cell.ColumnSpan = 5;
            header_cell.Padding = new Thickness(0, 0, 0, 10);
            header_row.Cells.Add(header_cell);
            tbl.RowGroups[0].Rows.Add(header_row);

            // add the first (title) row
            tbl.RowGroups[0].Rows.Add(new TableRow());

            // alias the current row
            TableRow currentRow = tbl.RowGroups[0].Rows[1];

            // format the header row
            currentRow.FontSize = 12;
            currentRow.FontWeight = FontWeights.Bold;
            currentRow.Background = Brushes.Gray;


            // add content
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Rank"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("EntryID"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("StudioName"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Routine Title"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

            for (int n = 0; n < currentRow.Cells.Count; n++)
            {
                currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                currentRow.Cells[n].BorderBrush = Brushes.Black;
                currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
            }

            // get trophies
            List<Team> trophies = SqliteDataAccess.getSocialTrophies(vClass);

            // if there are trophies
            if (trophies.Count > 0)
            {
                int i = 2; //table row index
                foreach (Team trophy in trophies)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.Rank.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.EntryID.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.RoutineTitle))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }
            }

            tbl.Columns[0].Width = new GridLength(75);
            tbl.Columns[1].Width = new GridLength(75);
            tbl.Columns[2].Width = new GridLength(250);
            tbl.Columns[3].Width = new GridLength(250);
            tbl.Columns[4].Width = new GridLength(75);

            return tbl;
        }
        private Table superiorTable(string db_table)
        {
            // get recipients
            List<TeamAward> awards = SqliteDataAccess.getSuperiorAwards(db_table);
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 5 columns and add them to the table's column collection
                int numCols = 5;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[0];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("# Routines"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 1; //table row index
                foreach (TeamAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.NumRoutines.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(250);
                tbl.Columns[1].Width = new GridLength(130);
                tbl.Columns[2].Width = new GridLength(200);
                tbl.Columns[3].Width = new GridLength(100);
                tbl.Columns[4].Width = new GridLength(75);

            }

            return tbl;

        }
        private Table sweepstakesTable(string db_table)
        {
            // get recipients
            List<TeamAward> awards = SqliteDataAccess.getSweepstakesAwards(db_table);
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 4 columns and add them to the table's column collection
                int numCols = 5;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[0];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("# Routines"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 1; //table row index
                foreach (TeamAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.NumRoutines.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(250);
                tbl.Columns[1].Width = new GridLength(130);
                tbl.Columns[2].Width = new GridLength(200);
                tbl.Columns[3].Width = new GridLength(100);
                tbl.Columns[4].Width = new GridLength(75);

            }

            return tbl;

        }
        private Table superSweepstakesTable(string db_table)
        {
            // get recipients
            List<TeamAward> awards = SqliteDataAccess.getSuperSweepstakesAwards(db_table);
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 4 columns and add them to the table's column collection
                int numCols = 5;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[0];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("# Routines"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 1; //table row index
                foreach (TeamAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.NumRoutines.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(250);
                tbl.Columns[1].Width = new GridLength(130);
                tbl.Columns[2].Width = new GridLength(200);
                tbl.Columns[3].Width = new GridLength(100);
                tbl.Columns[4].Width = new GridLength(75);

            }

            return tbl;

        }
        private Table judgesTable(string db_table)
        {
            // get recipients
            List<TeamAward> awards = SqliteDataAccess.getJudgesAwards(db_table);
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 5 columns and add them to the table's column collection
                int numCols = 5;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[0];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("# Routines"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 1; //table row index
                foreach (TeamAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.NumRoutines.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(250);
                tbl.Columns[1].Width = new GridLength(130);
                tbl.Columns[2].Width = new GridLength(200);
                tbl.Columns[3].Width = new GridLength(100);
                tbl.Columns[4].Width = new GridLength(75);

            }

            return tbl;

        }

/*        private Table technicalMeritTable(string db_table)
        {
            // get recipients
            List<TeamAward> awards = SqliteDataAccess.getTechnicalMeritAwards(db_table);
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 5 columns and add them to the table's column collection
                int numCols = 5;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[0];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("# Routines"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 1; //table row index
                foreach (TeamAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.NumRoutines.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(250);
                tbl.Columns[1].Width = new GridLength(130);
                tbl.Columns[2].Width = new GridLength(200);
                tbl.Columns[3].Width = new GridLength(100);
                tbl.Columns[4].Width = new GridLength(75);

            }

            return tbl;

        }
*/
/*        private Table highPointTechniqueTable(string db_table)
        {
            // get recipients
            List<TeamAward> awards = SqliteDataAccess.gethighPointTechniqueAwards(db_table);
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 5 columns and add them to the table's column collection
                int numCols = 5;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[0];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("# Routines"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 1; //table row index
                foreach (TeamAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.NumRoutines.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(250);
                tbl.Columns[1].Width = new GridLength(130);
                tbl.Columns[2].Width = new GridLength(200);
                tbl.Columns[3].Width = new GridLength(100);
                tbl.Columns[4].Width = new GridLength(75);

            }

            return tbl;

        }
*/        
/*        private Table precisionMeritTable(string db_table)
        {
            // get recipients
            List<TeamAward> awards = SqliteDataAccess.getPrecisionMeritAwards(db_table);
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 5 columns and add them to the table's column collection
                int numCols = 5;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[0];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("# Routines"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 1; //table row index
                foreach (TeamAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.NumRoutines.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(250);
                tbl.Columns[1].Width = new GridLength(130);
                tbl.Columns[2].Width = new GridLength(200);
                tbl.Columns[3].Width = new GridLength(100);
                tbl.Columns[4].Width = new GridLength(75);

            }

            return tbl;

        }
*/        
/*        private Table highPointPrecisionTable(string db_table)
        {
            // get recipients
            List<TeamAward> awards = SqliteDataAccess.gethighPointPrecisionAwards(db_table);
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 5 columns and add them to the table's column collection
                int numCols = 5;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[0];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("# Routines"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 1; //table row index
                foreach (TeamAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.NumRoutines.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(250);
                tbl.Columns[1].Width = new GridLength(130);
                tbl.Columns[2].Width = new GridLength(200);
                tbl.Columns[3].Width = new GridLength(100);
                tbl.Columns[4].Width = new GridLength(75);

            }

            return tbl;

        }
*/        
/*        private Table outstandingChoreographyTable(string db_table)
        {
            // get recipients
            List<ChoreographyAward> awards = SqliteDataAccess.getoutstandingChoreographyAwards(db_table);
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 6 columns and add them to the table's column collection
                int numCols = 6;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[0];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("EntryID"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Category"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 1; //table row index
                foreach (ChoreographyAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryID.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Category))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(75);
                tbl.Columns[1].Width = new GridLength(250);
                tbl.Columns[2].Width = new GridLength(130);
                tbl.Columns[3].Width = new GridLength(200);
                tbl.Columns[4].Width = new GridLength(100);
                tbl.Columns[5].Width = new GridLength(75);

            }

            return tbl;

        }
*/
        private Table bestInCategoryTable(string vClass, string db_table)
        {
            // get recipients
            List<BestInCategoryAward> awards = SqliteDataAccess.getBestInCategoryAwards(vClass,db_table);

            // create the table
            Table tbl = new Table();
            int i = 0; //table row index


            // create 6 columns and add them to the table's column collection
            int numCols = 6;
            for (int x = 0; x < numCols; x++)
            {
                tbl.Columns.Add(new TableColumn());
            }

            // create and add an empty TableRowGroup to hold the table's rows
            tbl.RowGroups.Add(new TableRowGroup());


            // if there are trophies
            if (awards.Count > 0)
            {
                string currentClass = "";
                string currentCategory = "";

                foreach (BestInCategoryAward award in awards)
                {

                    if (award.Class != currentClass || award.Category != currentCategory)
                    {
                        currentClass = award.Class;
                        currentCategory = award.Category;

                        // Class:
                        Paragraph p = new Paragraph(new Run("Division: " + currentClass + ", Category: " + currentCategory));
                        p.FontSize = 16;
                        p.Foreground = Brushes.Blue;
                        p.FontWeight = FontWeights.Bold;

                        // add the class header to the table
                        TableRow header_row = new TableRow();
                        TableCell header_cell = new TableCell(p);
                        header_cell.ColumnSpan = 5;
                        header_cell.Padding = new Thickness(0, 20, 0, 10);
                        header_row.Cells.Add(header_cell);
                        tbl.RowGroups[0].Rows.Add(header_row);

                        i++;

                        // add the first (title) row
                        tbl.RowGroups[0].Rows.Add(new TableRow());

                        // alias the current row
                        TableRow currentRow = tbl.RowGroups[0].Rows[i];

                        // format the header row
                        currentRow.FontSize = 12;
                        currentRow.FontWeight = FontWeights.Bold;
                        currentRow.Background = Brushes.Gray;

                        // add content
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Category"))));
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("EntryID"))));
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("RoutineTitle"))));
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                        for (int n = 0; n < currentRow.Cells.Count; n++)
                        {
                            currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                            currentRow.Cells[n].BorderBrush = Brushes.Black;
                            currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        }

                        i++;
                    }


                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    TableRow dataRow = tbl.RowGroups[0].Rows[i];
                    dataRow.FontSize = 12;
                    dataRow.FontWeight = FontWeights.Normal;
                    dataRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    dataRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Category))));
                    dataRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryID.ToString()))));
                    dataRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    dataRow.Cells.Add(new TableCell(new Paragraph(new Run(award.RoutineTitle))));
                    dataRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        dataRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < dataRow.Cells.Count; n++)
                    {
                        dataRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        dataRow.Cells[n].BorderBrush = Brushes.Black;
                        dataRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        dataRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;



                }




                tbl.Columns[0].Width = new GridLength(200);
                tbl.Columns[1].Width = new GridLength(100);
                tbl.Columns[2].Width = new GridLength(50);
                tbl.Columns[3].Width = new GridLength(200);
                tbl.Columns[4].Width = new GridLength(200);
                tbl.Columns[5].Width = new GridLength(80);

            }

            return tbl;

        }
        private Table bestInClassTable(string db_table)
        {
            // get recipients
            List<TeamAward> awards = SqliteDataAccess.getBestInClassAwards(db_table);
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 4 columns and add them to the table's column collection
                int numCols = 4;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[0];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 1; //table row index
                foreach (TeamAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(250);
                tbl.Columns[1].Width = new GridLength(300);
                tbl.Columns[2].Width = new GridLength(130);
                tbl.Columns[3].Width = new GridLength(75);

            }

            return tbl;

        }
        private Table bestInClassEliteTable(string db_table)
        {
            // create the table
            Table tbl = new Table();

            if (db_table != "Officer")
            {

                // get recipients
                List<TeamAward> awards = SqliteDataAccess.getBestInClassEliteAwards(db_table);

                // if there are trophies
                if (awards.Count > 0)
                {

                    // create 4 columns and add them to the table's column collection
                    int numCols = 4;
                    for (int x = 0; x < numCols; x++)
                    {
                        tbl.Columns.Add(new TableColumn());
                    }

                    // create and add and empty TableRowGroup to hold the table's rows
                    tbl.RowGroups.Add(new TableRowGroup());

                    // add the first (title) row
                    tbl.RowGroups[0].Rows.Add(new TableRow());

                    // alias the current row
                    TableRow currentRow = tbl.RowGroups[0].Rows[0];

                    // format the header row
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Bold;
                    currentRow.Background = Brushes.Gray;


                    // add content
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                    }

                    int i = 1; //table row index
                    foreach (TeamAward award in awards)
                    {
                        // add a new row to the table
                        tbl.RowGroups[0].Rows.Add(new TableRow());
                        currentRow = tbl.RowGroups[0].Rows[i];
                        currentRow.FontSize = 12;
                        currentRow.FontWeight = FontWeights.Normal;
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                        if (i % 2 == 0)
                            currentRow.Background = Brushes.AntiqueWhite;

                        for (int n = 0; n < currentRow.Cells.Count; n++)
                        {
                            currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                            currentRow.Cells[n].BorderBrush = Brushes.Black;
                            currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                            currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                        }

                        i++;
                    }

                    tbl.Columns[0].Width = new GridLength(250);
                    tbl.Columns[1].Width = new GridLength(300);
                    tbl.Columns[2].Width = new GridLength(130);
                    tbl.Columns[3].Width = new GridLength(75);

                }

            }

            return tbl;

        }
        private Table highPointPerformanceAwardTable()
        {
            // get recipients
            List<highPointPerformanceAward> awards = SqliteDataAccess.getHighPointPerformanceAward();
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 3 columns and add them to the table's column collection
                int numCols = 7;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[0];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("EntryID"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("EntryType"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("RoutineTitle"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Category"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 1; //table row index
                foreach (highPointPerformanceAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryID.ToString()))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.RoutineTitle))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Category))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(60);
                tbl.Columns[1].Width = new GridLength(80);
                tbl.Columns[2].Width = new GridLength(150);
                tbl.Columns[3].Width = new GridLength(150);
                tbl.Columns[4].Width = new GridLength(80);
                tbl.Columns[5].Width = new GridLength(80);
                tbl.Columns[6].Width = new GridLength(60);

            }

            return tbl;

        }
        private Table awardOfExcellenceTable(string db_table)
        {
            // get recipients
            List<TeamAward> awards = SqliteDataAccess.getAwardOfExcellenceAwards(db_table);
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 3 columns and add them to the table's column collection
                int numCols = 3;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[0];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                }

                int i = 1; //table row index
                foreach (TeamAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                        currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(300);
                tbl.Columns[1].Width = new GridLength(250);
                tbl.Columns[2].Width = new GridLength(75);

            }

            return tbl;

        }
        private Table championTable(string vClass, string db_table)
        {
            // get recipients
            List<TeamAward> awards = SqliteDataAccess.getChampionAwards(vClass,db_table);
            // create the table
            Table tbl = new Table();

            // if there are trophies
            if (awards.Count > 0)
            {

                // create 4 columns and add them to the table's column collection
                int numCols = 4;
                for (int x = 0; x < numCols; x++)
                {
                    tbl.Columns.Add(new TableColumn());
                }

                // create and add and empty TableRowGroup to hold the table's rows
                tbl.RowGroups.Add(new TableRowGroup());

                // Class:
                Paragraph p = new Paragraph(new Run(vClass + "s"));
                p.FontSize = 16;
                p.Foreground = Brushes.Blue;
                p.FontWeight = FontWeights.Bold;

                // add the class header to the table
                TableRow header_row = new TableRow();
                TableCell header_cell = new TableCell(p);
                header_cell.ColumnSpan = 3;
                header_cell.Padding = new Thickness(0, 0, 0, 10);
                header_row.Cells.Add(header_cell);
                tbl.RowGroups[0].Rows.Add(header_row);


                // add the first (title) row
                tbl.RowGroups[0].Rows.Add(new TableRow());

                // alias the current row
                TableRow currentRow = tbl.RowGroups[0].Rows[1];

                // format the header row
                currentRow.FontSize = 12;
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Background = Brushes.Gray;


                // add content
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Type"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Class"))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                for (int n = 0; n < currentRow.Cells.Count; n++)
                {
                    currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[n].BorderBrush = Brushes.Black;
                    currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                    currentRow.Cells[n].TextAlignment = TextAlignment.Left;
                }

                int i = 2; //table row index
                foreach (TeamAward award in awards)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.StudioName))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.EntryType))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.Class))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(award.AvgScore))));

                    if (i % 2 == 0)
                        currentRow.Background = Brushes.AntiqueWhite;

                    for (int n = 0; n < currentRow.Cells.Count; n++)
                    {
                        currentRow.Cells[n].BorderThickness = new Thickness(1, 1, 1, 1);
                        currentRow.Cells[n].BorderBrush = Brushes.Black;
                        currentRow.Cells[n].Padding = new Thickness(3, 3, 3, 3);
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(300);
                tbl.Columns[1].Width = new GridLength(130);
                tbl.Columns[2].Width = new GridLength(250);
                tbl.Columns[3].Width = new GridLength(75);

            }

            return tbl;

        }

        public void PrintAll_Click()
        {

            FlowDocument doc = new FlowDocument();
            doc.PagePadding = new Thickness(50);

/*            generateSolos(doc);
            generateDuets(doc);
            generateTrios(doc);
            generateEnsembles(doc);
            generateSocials(doc);
            generateOfficers(doc);
*/
            generateTeams(doc);
            generateSpecialty(doc);
            generateChampions(doc);


            // create print dialog
            PrintDialog printDlg = new PrintDialog();

            if (printDlg.ShowDialog().Value)
            {
                doc.PageHeight = printDlg.PrintableAreaHeight;
                doc.PageWidth = printDlg.PrintableAreaWidth;
                doc.ColumnWidth = printDlg.PrintableAreaWidth;

                // create idocpaginator source from flow doc
                IDocumentPaginatorSource idpSource = doc;

                // call printdocument method to send to printer
                printDlg.PrintDocument(idpSource.DocumentPaginator, "Printing Reports...");
            }
        }

        /// <summary>
        /// Adds one flowdocument to another.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public static void AddDocument(FlowDocument from, FlowDocument to, bool addPageBreak)
        {
            //TextRange range = new TextRange(from.ContentStart, from.ContentEnd);
            //MemoryStream stream = new MemoryStream();
            //System.Windows.Markup.XamlWriter.Save(range, stream);
            //range.Save(stream, DataFormats.XamlPackage);

            //TextRange range2 = new TextRange(to.ContentEnd, to.ContentEnd);
            //range2.Load(stream, DataFormats.XamlPackage);

            //if (addPageBreak)
            //{
            //    Section section = new Section();
            //    section.BreakPageBefore = true;
            //    section.Blocks.Add(new Paragraph(new Run("\n")));
            //    to.Blocks.Add(section);
            //}

            BlockCollection blocks = from.Blocks;
            foreach (Block block in blocks)
            {
                to.Blocks.Add(block);
            } 

        }
    }

}
