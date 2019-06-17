using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace RyzenHackintoshMediaBuilder
{
    public partial class Form1 : Form
    {
        String USBPath = "";
        String KextPath = "";
        String WorkingDir = "";

        public Form1()
        {
            InitializeComponent();
            GetWorkingDir();
            CheckForUpdates();
            InstructLbl.Text = "Step 1 first!";
        }

        private void SelectDriveBtn_Click(object sender, EventArgs e)
        {
            //Select the USB Drive to write to
            FolderBrowserDialog folderBrowserDialog2 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog2.ShowDialog();
            USBPath = folderBrowserDialog2.SelectedPath;
        }

        private void SelectKextsFolderBtn_Click(object sender, EventArgs e)
        {
            //Select the folder the Kexts are in
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            KextPath = folderBrowserDialog1.SelectedPath;
            
        }

        private void customiseConfigplistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Customise config.plist settings
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open the about form
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void BldDriveBtn_Click(object sender, EventArgs e)
        {
            //Build the bootable USB drive

        }

        private void GenSMBiosBtn_Click(object sender, EventArgs e)
        {
            //Generate a new SMBIOS based on "iMac14,2"

        }

        private void DlMacOSBtn_Click(object sender, EventArgs e)
        {
            //Use gibMacOS to download a copy of MacOS
            MessageBox.Show("You'll need to press 1 and ENTER here, then \"y\", then let it download fully, then press enter. See \"Instructions\" section for this again.", "READ THIS FIRST", MessageBoxButtons.OK , MessageBoxIcon.Information);
            InstructLbl.Text = "You'll need to press 1 and ENTER here, then \"y\", then let it download fully, then press enter.";

            String gibMacOSPath = "\"" + WorkingDir + @"\gibMacOS-master\gibMacOS.bat" + "\"";
            ExecuteCommand(gibMacOSPath);
        }

        private void CheckForUpdates()
        {
            //Check for updates to the tools gibMacOS, GenSMBIOS, AMDVanillaPatches.

        }

        private void GetWorkingDir()
        {
            //Get the current directory where the program has been installed
            WorkingDir = Directory.GetCurrentDirectory();
            if (WorkingDir[0] != 'C')
            {
                MessageBox.Show("Please make sure to install this tool on your C drive. Ideally, where the installer recommended... This likely won't work otherwise.");
            }
        }

        static void ExecuteCommand(string command)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = false;

            var process = Process.Start(processInfo);

            /*process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("output>>" + e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("error>>" + e.Data);
            process.BeginErrorReadLine();
            */
            process.WaitForExit();

            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();
        }
    }
}
