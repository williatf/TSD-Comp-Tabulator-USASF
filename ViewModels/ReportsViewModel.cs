using Caliburn.Micro;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using TSD_Comp_Tabulator.Models;

namespace TSD_Comp_Tabulator.ViewModels
{
    public class ReportsViewModel : Screen
    {

        private FlowDocument _solos;
        public ReportsViewModel()
        {
            _solos = generateSolos();
        }

        public FlowDocument Solos
        {
            get { return _solos; } 
        
        }

        private FlowDocument generateSolos()
        {
            FlowDocument fd = new FlowDocument();

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
            System.Collections.Generic.List<string> list = SqliteDataAccess.getStudioSoloClasses();
            
            // check to make sure there are studio solo classes
            if (list.Count > 0)
            {
                // loop over each solo class and print a table of results
                foreach (string vClass in list)
                {
                    // Class:
                    p = new Paragraph(new Run("Class: "+vClass));
                    fd.Blocks.Add(p);

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
                    List<Solos> trophies = SqliteDataAccess.getStudioSoloTrophies(vClass);

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

                    TableColumnCollection columns = tbl.Columns;
                    foreach (TableColumn column in columns)
                    {
                        column.Width = GridLength.Auto;
                    }

                    fd.Blocks.Add(tbl);


                
                }
            }


            return fd;
        }

    }

}
