using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using TSD_Comp_Tabulator.Models;

namespace TSD_Comp_Tabulator.ViewModels
{
    public class ReportsViewModel : Screen
    {

        private FlowDocument _solos;
        private FlowDocument _duets;
        private FlowDocument _trios;
        private FlowDocument _ensembles;
        private FlowDocument _socials;
        private FlowDocument _officers;
        private List<string> list;
        private List<string> classList;

        public ReportsViewModel()
        {
            _solos = generateSolos();
            _duets = generateDuets();
            _trios = generateTrios();
            _ensembles = generateEnsembles();
            _socials = generateSocials();
            _officers = generateOfficers();
        }

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
        private FlowDocument generateSolos()
        {
            FlowDocument fd = new FlowDocument();
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Solo Trophies"));
            p.FontSize = 18;
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
        private FlowDocument generateDuets()
        {
            FlowDocument fd = new FlowDocument();
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Duet Trophies"));
            p.FontSize = 18;
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
        private FlowDocument generateTrios()
        {
            FlowDocument fd = new FlowDocument();
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Trio Trophies"));
            p.FontSize = 18;
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
        private FlowDocument generateEnsembles()
        {
            FlowDocument fd = new FlowDocument();
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Ensemble Trophies"));
            p.FontSize = 18;
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
        private FlowDocument generateSocials()
        {
            FlowDocument fd = new FlowDocument();
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Social Officer Trophies"));
            p.FontSize = 18;
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
        private FlowDocument generateOfficers()
        {
            FlowDocument fd = new FlowDocument();
            fd.PagePadding = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Dance Officer Line Awards"));
            p.FontSize = 18;
            fd.Blocks.Add(p);

            fd.Blocks.Add(officer_and_team_Awards("Officer"));

            return fd;
        }

        private Block officer_and_team_Awards(string db_table)
        {

            Paragraph p;
            Section blk = new Section();

            // Superior Awards
            p = new Paragraph(new Run("Superior Awards"));
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

            // Sweepstakes Awards
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
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
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
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(250);
                tbl.Columns[1].Width = new GridLength(250);
                tbl.Columns[2].Width = new GridLength(100);
                tbl.Columns[3].Width = new GridLength(75);

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
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Studio Name"))));
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
                    }

                    i++;
                }

                tbl.Columns[0].Width = new GridLength(250);
                tbl.Columns[1].Width = new GridLength(250);
                tbl.Columns[2].Width = new GridLength(100);
                tbl.Columns[3].Width = new GridLength(75);

            }

            return tbl;

        }

    }

}
