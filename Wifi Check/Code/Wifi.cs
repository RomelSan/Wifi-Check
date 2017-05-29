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
        private string wificheck()
        {
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
    }
}
