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
        int ssid_number_control = 0;
        /*
            int ssid_number_control = 0;
            Help matches signal, channel and radio type when there are more than one bssid... we want to use 1 bssid per ssid
            So ssid_number_control is 1 whenever a new SSID is found.
            And ssid_number_control is 0 when channel (the last data of the section for a single bssid) is found.
        */
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
        private void command_dump(string input_raw)
        {
            textBox1_test.Text += input_raw + "\r\n"; // Just fills the textbox with raw data (for each line)
        }

        #region Regex Section
        private void regex_lines(string input2)
        {
            Regex regex1 = new Regex(@"(?<before>\w+) \d+ : (?<after>.*)"); // SSID, Regex Matches Before and After Digits (Matches Hidden Networks too)
                                                                            // Regex regex1 = new Regex(@"SSID \d+ : (?<after>.*)"); // SSID ONLY (Can't match Hidden Networks)
            Regex regex2 = new Regex(@"BSSID 1 * : (?<after>\w+.*)"); // BSSID or    @"BSSID \d+ * : (?<after>\w+.*)"
                                                                        // Regex regex2 = new Regex(@"([a-f0-9]{2}:){5}[a-f0-9]{2}"); //BSSID, can match multiple BSSID from a single SSID
            Regex regex3 = new Regex(@"Authentication * : (?<after>\w+.*)"); // Authentication
            Regex regex4 = new Regex(@"Encryption * : (?<after>\w+.*)"); // Encryption
            Regex regex5 = new Regex(@"Signal * : (?<after>\w+.*)"); // Signal
            Regex regex6 = new Regex(@"Channel * : (?<after>\w+.*)"); // Channel
            Regex regex7 = new Regex(@"Radio type * : (?<after>\w+.*)"); // Radio Type

            Match match1 = regex1.Match(input2); // SSID
            Match match2 = regex2.Match(input2); // BSSID
            Match match3 = regex3.Match(input2); // Authentication
            Match match4 = regex4.Match(input2); // Encryption
            Match match5 = regex5.Match(input2); // Signal
            Match match6 = regex6.Match(input2); // Channel
            Match match7 = regex7.Match(input2); // Radio Type

            if (match1.Success)
            {
                count_ssid++;
                ssid_content = match1.Groups["after"].Value;
                if (ssid_content == "") { ssid_content = @"<Hidden Network> " + count_ssid; } // Handles hidden networks
                table.Rows.Add(count_ssid, ssid_content);
                // textBox1_test.Text += ssid_content + "\r\n"; // SSID
                ssid_number_control = 1; // switch one when we are currently working on one ssid
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
            #region Per BSSID
            if (match5.Success) // Signal
            {
                signal_content = match5.Groups["after"].Value;
                if (ssid_number_control == 1)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        if (dr["SSID"] == ssid_content)
                        {
                            dr["Signal"] = signal_content;
                            break;
                        }
                    }
                }
            }
            if (match6.Success) // Channel (Last for a single BSSID) (Note whe are not using data rates)
            {
                channel_content = match6.Groups["after"].Value;
                if (ssid_number_control == 1)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        if (dr["SSID"] == ssid_content)
                        {
                            dr["Channel"] = channel_content;
                            ssid_number_control = 0; // last ssid section sets this control to 0, so we return just the data for the first bssid found
                            break;
                        }
                    }
                }
            }
            if (match7.Success) // Radio Type
            {
                radiotype_content = match7.Groups["after"].Value;
                if (ssid_number_control == 1)
                {
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
        }
        #endregion
    }
}