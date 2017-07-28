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
            button1_test.Enabled = false;
            reset_all(); // reset current data
            textBox1_test.Text = ""; // clear text box data
            textBox1_test.Text = "Command: netsh wlan show network mode=bssid" + "\r\n"; // show the command executed via CMD
            string wifidata = wificheck(); // Gets Wifi Data to string
            parse_lines(wifidata); // Process each line of the string
            dataGridView1.DataSource = table; // Show that data on the grid
            checkInsecureEncryption(); // Mark Cell with RED if WEP Encryption is found
            timer1_wifiScan.Start(); // Disable the scan wifi button for a few seconds
        }

        private void button1_test_Click(object sender, EventArgs e)
        {
            scan_wifi();
        }

        private void button_exportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                export_CSV();
                MessageBox.Show("Ok\nCheck for wifi.csv", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { MessageBox.Show("Scan for Wifi and then export to CSV", "Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); }
        }

        private void timer1_wifiScan_Tick(object sender, EventArgs e)
        {
            button1_test.Enabled = true;
            timer1_wifiScan.Stop();
        }

        private void checkInsecureEncryption()
        {
            int rowscount = dataGridView1.Rows.Count;
            for (int i = 0; i < rowscount; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[4].Value).StartsWith("WEP") == true)
                {
                    dataGridView1.Rows[i].Cells[4].Style.BackColor = Color.Red;
                }
            }
            dataGridView1.Refresh();
        }

    }
}
