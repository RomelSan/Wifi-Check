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
        private void init_table()
        {
            table.Columns.Add("Number", typeof(int));
            table.Columns.Add("SSID", typeof(string));
            table.Columns.Add("BSSID", typeof(string));
            table.Columns.Add("Authentication", typeof(string));
            table.Columns.Add("Encryption", typeof(string));
            table.Columns.Add("Signal", typeof(string));
            table.Columns.Add("Channel", typeof(string));
            table.Columns.Add("Radio Type", typeof(string));
        }
        private void reset_all()
        {
            count = 0; //Resets counts to 0 on each wifi scan
            count_ssid = 0;
            table.Rows.Clear(); // Clear previous table rows
        }

    }
}