using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace Wifi_Check
{
    public partial class Form1 : Form
    {
        private void export_CSV()
        {
            // Time
            DateTime theDate = DateTime.Now;
            string dateString = theDate.ToString("dd-MM-yy-HH.mm.ss");
            string filename = "wifi-" + dateString + ".csv";

            // Write File
            var lines = new List<string>();

            string[] columnNames = table.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();

            var header = string.Join(",", columnNames);
            lines.Add(header);

            var valueLines = table.AsEnumerable()
                       .Select(row => string.Join(",", row.ItemArray));
            lines.AddRange(valueLines);

            File.WriteAllLines(filename, lines);
        }
    }
}
