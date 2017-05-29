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
        // Global variables
        int count = 0; // Number of lines from netsh command
        int count_ssid = 0; // Number of total SSID
        string ssid_content;
        string bssid_content;
        string authentication_content;
        string encryption_content;
        string signal_content;
        string channel_content;
        string radiotype_content;
        DataTable table = new DataTable();


        private void Form1_Load(object sender, EventArgs e)
        {
            init_table();
        }
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
        private string wificheck()
        {
            count = 0; //Resets counts to 0 on each wifi scan
            count_ssid = 0;
            table.Rows.Clear(); // Clear previous table rows
            
            // netsh wlan show networks mode=bssid
            Process processWifi = new Process();
            processWifi.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processWifi.StartInfo.FileName = "netsh";
            processWifi.StartInfo.Arguments = "wlan show networks mode=bssid";
            //processWifi.StartInfo.WorkingDirectory = Path.GetDirectoryName(YourApplicationPath);

            processWifi.StartInfo.UseShellExecute = false;
            processWifi.StartInfo.RedirectStandardError = true;
            processWifi.StartInfo.RedirectStandardInput = true;
            processWifi.StartInfo.RedirectStandardOutput = true;
            processWifi.StartInfo.CreateNoWindow = true;
            processWifi.Start();
            //* Read the output (or the error)
            string output = processWifi.StandardOutput.ReadToEnd();
            // Show output commands
            string err = processWifi.StandardError.ReadToEnd();
            // show error commands
            processWifi.WaitForExit();
            return output;
        }
        private void parse_lines(string input)
        {
            // Reads the string
            using (StringReader reader = new StringReader(input))
            {
                // Loop over the lines in the string.
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                    // --------------------- testing ----------------------------- 
                    // textBox1_test.Text += ("Line " + count + line + "\r\n");
                    // Console.WriteLine("Line {0}: {1}", count, line);
                    //---------------------- end testing -------------------------
                    // Do X stuff with each line
                    regex_lines(line);
                    command_dump(line);
                }
            }
        }
        #region Regex Section
        private void regex_lines(string input2)
        {
            Regex regex = new Regex(@"SSID \d : (?<after>\w+)"); // SSID
            Regex regex2 = new Regex(@"BSSID \d * : (?<after>\w+.*)"); // BSSID
         // Regex regex2 = new Regex(@"([a-f0-9]{2}:){5}[a-f0-9]{2}"); //BSSID
            Regex regex3 = new Regex(@"Authentication * : (?<after>\w+.*)"); // Authentication
            Regex regex4 = new Regex(@"Encryption * : (?<after>\w+.*)"); // Encryption
            Regex regex5 = new Regex(@"Signal * : (?<after>\w+.*)"); // Signal
            Regex regex6 = new Regex(@"Channel * : (?<after>\w+.*)"); // Channel
            Regex regex7 = new Regex(@"Radio type * : (?<after>\w+.*)"); // Radio Type

            Match match = regex.Match(input2); // SSID
            Match match2 = regex2.Match(input2); // BSSID
            Match match3 = regex3.Match(input2); // Authentication
            Match match4 = regex4.Match(input2); // Encryption
            Match match5 = regex5.Match(input2); // Signal
            Match match6 = regex6.Match(input2); // Channel
            Match match7 = regex7.Match(input2); // Radio Type


            if (match.Success) // SSID
            {
                count_ssid++;
                ssid_content = match.Groups["after"].Value;
                table.Rows.Add(count_ssid, ssid_content);
                // textBox1_test.Text += ssid_content + "\r\n"; // SSID
            }

            if (match2.Success) // BSSID
            {
                bssid_content = match2.Groups["after"].Value;
                foreach (DataRow dr in table.Rows) // search whole table
                {
                    if (dr["SSID"] == ssid_content)
                    {
                        dr["BSSID"] = bssid_content;
                        break;
                    }
                }  
                // textBox1_test.Text += bssid_content + "\r\n"; // BSSID               
            }

            if (match3.Success) // Authentication
            {
                authentication_content = match3.Groups["after"].Value;
                foreach (DataRow dr in table.Rows) // search whole table
                {
                    if (dr["SSID"] == ssid_content)
                    {
                        dr["Authentication"] = authentication_content;
                        break;
                    }
                }
            }

            if (match4.Success) // Encryption
            {
                encryption_content = match4.Groups["after"].Value;
                foreach (DataRow dr in table.Rows)
                {
                    if (dr["SSID"] == ssid_content)
                    {
                        dr["Encryption"] = encryption_content;
                        break;
                    }
                }
            }
            if (match5.Success) // Signal
            {
                signal_content = match5.Groups["after"].Value;
                foreach (DataRow dr in table.Rows)
                {
                    if (dr["SSID"] == ssid_content)
                    {
                        dr["Signal"] = signal_content;
                        break;
                    }
                }
            }
            if (match6.Success) // Channel
            {
                channel_content = match6.Groups["after"].Value;
                foreach (DataRow dr in table.Rows)
                {
                    if (dr["SSID"] == ssid_content)
                    {
                        dr["Channel"] = channel_content;
                        break;
                    }
                }
            }
            if (match7.Success) // Radio Type
            {
                radiotype_content = match7.Groups["after"].Value;
                foreach (DataRow dr in table.Rows)
                {
                    if (dr["SSID"] == ssid_content)
                    {
                        dr["Radio Type"] = radiotype_content;
                        break;
                    }
                }
            }
        }
        #endregion

        private void command_dump(string input2)
        {
            textBox1_test.Text += input2 + "\r\n"; // Just fills the textbox with raw data (for each line)
        }

        private void button1_test_Click(object sender, EventArgs e)
        {
            textBox1_test.Text = "";
            textBox1_test.Text = "Command: netsh wlan show network mode=bssid" + "\r\n";
            string wifidata = wificheck();
            parse_lines(wifidata);
            dataGridView1.DataSource = table;
        }        
    }
}
