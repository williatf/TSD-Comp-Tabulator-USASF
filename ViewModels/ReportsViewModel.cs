﻿using Caliburn.Micro;
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

        public ReportsViewModel()
        {
            _solos = generateSolos();
            _duets = generateDuets();
        }

        public FlowDocument Solos
        {
            get { return _solos; } 
        
        }
        public FlowDocument Duets
        {
            get { return _duets; }

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
                "The results are limited to the top 6 scores.  If there are less than 6 results, that means there were less than 6 competitors in that group. The bottom score shown in each group should be dropped and should NOT receive a trophy.\n\n" +
                "Only the top 5 performers should receive trophies. In a tie situation, all tied competitors would receive the same award.  For example, if there is a tie between two dancers for 1st runner up, both dancers would receive 1st runner up trophies, you would skip 2nd runner up, and the next dancer would receive the 3rd runner up trophy."
                )
            );
            p.FontSize = 12;
            fd.Blocks.Add(p);

            // Awards
            string category = "Studio";
            System.Collections.Generic.List<string> list = SqliteDataAccess.getSoloClasses(category);

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
            Section sec = new Section();
            sec.Margin = new Thickness(50);

            // Title
            Paragraph p = new Paragraph(new Run("Solo Trophies"));
            p.FontSize = 18;
            sec.Blocks.Add(p);

            // Description
            p = new Paragraph(new Run("Highest Scores at top!!\n\n" +
                "Top 3 scores within each age group, for both Studios and Schools.\n\n" +
                "The results are limited to the top 6 scores.  If there are less than 6 results, that means there were less than 6 competitors in that group. The bottom score shown in each group should be dropped and should NOT receive a trophy.\n\n" +
                "Only the top 5 performers should receive trophies. In a tie situation, all tied competitors would receive the same award.  For example, if there is a tie between two dancers for 1st runner up, both dancers would receive 1st runner up trophies, you would skip 2nd runner up, and the next dancer would receive the 3rd runner up trophy."
                )
            );
            p.FontSize = 12;
            sec.Blocks.Add(p);

            // Studio Awards
            System.Collections.Generic.List<string> list = SqliteDataAccess.getSoloClasses("Studio");

            // check to make sure there are studio solo classes
            if (list.Count > 0)
            {
                // loop over each solo class and print a table of results
                foreach (string vClass in list)
                {
                    // Class:
                    p = new Paragraph(new Run("Class: " + vClass));
                    p.Foreground = Brushes.Blue;
                    p.FontWeight = FontWeights.Bold;
                    sec.Blocks.Add(p);

                    // create the table
                    Table tbl = new Table();

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

                    // add content
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("EntryID"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("StudioName"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Dancer"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                    // get trophies
                    List<Solos> trophies = SqliteDataAccess.getSoloTrophies(vClass,"Studio");

                    // if there are trophies
                    if (trophies.Count > 0)
                    {
                        int i = 1; //table row index
                        foreach (Solos trophy in trophies)
                        {
                            // add a new row to the table
                            tbl.RowGroups[0].Rows.Add(new TableRow());
                            currentRow = tbl.RowGroups[0].Rows[i];
                            currentRow.FontSize = 12;
                            currentRow.FontWeight = FontWeights.Normal;
                            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.EntryID.ToString()))));
                            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.StudioName))));
                            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.Dancer))));
                            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.AvgScore))));

                            i++;
                        }
                    }

                    tbl.Columns[0].Width = new GridLength(75);
                    tbl.Columns[1].Width = new GridLength(200);
                    tbl.Columns[2].Width = new GridLength(200);
                    tbl.Columns[3].Width = new GridLength(75);

                    sec.Blocks.Add(tbl);
                    fd.Blocks.Add(sec);



                }
            }

            // School Awards
            list = SqliteDataAccess.getSoloClasses("School");

            if (list.Count > 0)
            {
                // loop over each solo class and print a table of results
                foreach (string vClass in list)
                {
                    // Class:
                    p = new Paragraph(new Run("Class: " + vClass));
                    p.Foreground = Brushes.Blue;
                    p.FontWeight = FontWeights.Bold;
                    sec.Blocks.Add(p);

                    // create the table
                    Table tbl = new Table();

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

                    // add content
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("EntryID"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("StudioName"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Dancer"))));
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run("AvgScore"))));

                    // get trophies
                    List<Solos> trophies = SqliteDataAccess.getSoloTrophies(vClass,"School");

                    // if there are trophies
                    if (trophies.Count > 0)
                    {
                        int i = 1; //table row index
                        foreach (Solos trophy in trophies)
                        {
                            // add a new row to the table
                            tbl.RowGroups[0].Rows.Add(new TableRow());
                            currentRow = tbl.RowGroups[0].Rows[i];
                            currentRow.FontSize = 12;
                            currentRow.FontWeight = FontWeights.Normal;
                            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.EntryID.ToString()))));
                            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.StudioName))));
                            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.Dancer))));
                            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(trophy.AvgScore))));

                            i++;
                        }
                    }

                    tbl.Columns[0].Width = new GridLength(75);
                    tbl.Columns[1].Width = new GridLength(200);
                    tbl.Columns[2].Width = new GridLength(200);
                    tbl.Columns[3].Width = new GridLength(75);

                    sec.Blocks.Add(tbl);
                    fd.Blocks.Add(sec);



                }
            }

            return fd;
        }

        private Table soloTable(string vClass, string category)
        {
            // create the table
            Table tbl = new Table();

            // create 4 columns and add them to the table's column collection
            int numCols = 4;
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
            header_cell.ColumnSpan = 4;
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
            List<Solos> trophies = SqliteDataAccess.getSoloTrophies(vClass, category);

            // if there are trophies
            if (trophies.Count > 0)
            {
                int i = 2; //table row index
                foreach (Solos trophy in trophies)
                {
                    // add a new row to the table
                    tbl.RowGroups[0].Rows.Add(new TableRow());
                    currentRow = tbl.RowGroups[0].Rows[i];
                    currentRow.FontSize = 12;
                    currentRow.FontWeight = FontWeights.Normal;
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
            tbl.Columns[1].Width = new GridLength(250);
            tbl.Columns[2].Width = new GridLength(250);
            tbl.Columns[3].Width = new GridLength(75);

            return tbl;
        }



    }

}
