using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

using System.Windows;
using System.Web;
using Pidev.data;

namespace Pidev.web
{
    public class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook Workbook;
        Worksheet Worksheet;
        public Excel()
        {

            Workbook = excel.Workbooks.Add();
            Worksheet = Workbook.Worksheets[1];
            Worksheet.Cells[1, 1].value2 = "Etat Tache";
            Worksheet.Cells[1, 2].value2 = "nbr congé";
            Worksheet.Cells[1, 3].value2 = "nbr des heures travailler par jour";
            Worksheet.Cells[1, 4].value2 = "nbr des heures travailler par semaine";
            Worksheet.Cells[1, 5].value2 = "Id° Employe";
            Worksheet.Cells[1, 6].value2 = "Id° projet";
           
        }

        public void saveAs(string path)
        {
            Workbook.SaveAs(path);
        }

        public void close()
        {
            Workbook.Close();
        }

        public void export(IEnumerable<tp_jsf_timesheet> timeSheets)
        {
            int j = 0;
            int i = 2;
           
            Worksheet.Name = "Erriiiii";
            Workbook.Title = "Erriiiiiii";
            foreach (var ts in timeSheets)
            {
                Worksheet.Cells[i, 1].Value2 = ts.EtatTache;
                Worksheet.Cells[i, 2].Value2 = ts.idEmploye;
                Worksheet.Cells[i, 3].Value2 = ts.idpfk;
                Worksheet.Cells[i, 4].Value2 = ts.NbreConge;
                Worksheet.Cells[i, 5].Value2 = ts.NbreHeureTRavJour;
                Worksheet.Cells[i, 6].Value2 = ts.NbreHeureTRavS;
                i++;
            }
            Worksheet.Cells.WrapText = true;
        }

    }
}