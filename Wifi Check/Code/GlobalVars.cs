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
    }
}
