using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;


namespace Wifi_Check
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init_table(); // load table columns
        }

        private void scan_wifi()
        {
            reset_all(); // reset current data
            textBox1_test.Text = ""; // clear text box data
            textBox1_test.Text = "Command: netsh wlan show network mode=bssid" + "\r\n"; // show the command executed via CMD
            string wifidata = wificheck(); // Gets Wifi Data to string
            parse_lines(wifidata); // Process each line of the string
            dataGridView1.DataSource = table; // Show that data on the grid
        }

        private void button1_test_Click(object sender, EventArgs e)
        {
            scan_wifi();
        }        
    }
}
