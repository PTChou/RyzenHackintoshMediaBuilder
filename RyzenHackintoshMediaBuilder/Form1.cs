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
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO.Compression;

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
            String ConfigPath = "\"" + WorkingDir + @"\AMDVanillaConfig\config.plist" + "\"";
            MessageBox.Show("Press 1 and ENTER, let it download, press enter. Then press 2. Copy and Paste: " + ConfigPath + " Then press ENTER. Once done, press 3 See \"Instructions\" section for this again.", "READ THIS FIRST", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InstructLbl.Text = "You'll need to press 1 and ENTER here, then \"y\", then let it download fully, then press enter.";
            String GenSMBIOSPath = "\"" + WorkingDir + @"\GenSMBIOS-master\GenSMBIOS.bat" + "\"";
            ExecuteCommand(GenSMBIOSPath, "1");
        }

        private void DlMacOSBtn_Click(object sender, EventArgs e)
        {
            //Use gibMacOS to download a copy of MacOS
            MessageBox.Show("You'll need to press 1 and ENTER here, then \"y\", then let it download fully, then press enter. See \"Instructions\" section for this again.", "READ THIS FIRST", MessageBoxButtons.OK , MessageBoxIcon.Information);
            InstructLbl.Text = "You'll need to press 1 and ENTER here, then \"y\", then let it download fully, then press enter.";

            String gibMacOSPath = "\"" + WorkingDir + @"\gibMacOS-master\gibMacOS.bat" + "\"";
            ExecuteCommand(gibMacOSPath, "1");
        }

        private void CheckForUpdates()
        {
            //Check for updates to the tools gibMacOS, GenSMBIOS, AMDVanillaPatches.
            GetConfigFile();
            GetGibMacOS();
            GetSMBIOSFiles();

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

        static void ExecuteCommand(string command, string input)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;

            p.StartInfo.FileName = command;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            System.IO.StreamWriter wr = p.StandardInput;
            System.IO.StreamReader rr = p.StandardOutput;

            wr.Write("BlaBlaBla" + "\n");
            Console.WriteLine(rr.ReadToEnd());
            wr.Flush();
        }

        private void GetConfigFile()
        {
            byte[] hashlocal;
            byte[] hashremote;
            Uri config = new Uri("https://raw.githubusercontent.com/andymanic/RyzenHackintoshMediaBuilder/master/AMDVanillaConfig/config.plist");

            try
            {
                System.Net.WebClient configFile = new System.Net.WebClient();
                configFile.DownloadFile(config, WorkingDir + @"\AMDVanillaConfig\remoteconfig.plist");
            }
            catch
            {
                if (MessageBox.Show("We tried to check for an updated version of the Config.plist file but were unable to, would you like to run this check again?", "Config.plist file check", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        System.Net.WebClient configFile = new System.Net.WebClient();
                        configFile.DownloadFile(config, WorkingDir + @"\AMDVanillaConfig\remoteconfig.plist");
                    }
                    catch
                    {
                        MessageBox.Show("We tried to check the file again, but were unable to. Please continue to use this tool, and manually verify the file version.");
                    }
                }
            }
            if (!File.Exists(WorkingDir + @"\AMDVanillaConfig\config.plist"))
            {
                try
                {
                    File.Move(WorkingDir + @"\AMDVanillaConfig\remoteconfig.plist", WorkingDir + @"\AMDVanillaConfig\config.plist");
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("We had a bit of a problem. Here's the error: " + e);
                }
            }
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(WorkingDir + @"\AMDVanillaConfig\config.plist"))
                {
                    hashlocal = md5.ComputeHash(stream);

                }
                using (var stream2 = File.OpenRead(WorkingDir + @"\AMDVanillaConfig\remoteconfig.plist"))
                {
                    hashremote = md5.ComputeHash(stream2);
                }
            }
            if (hashlocal.SequenceEqual(hashremote))
            {
                File.Delete(WorkingDir + @"\AMDVanillaConfig\remoteconfig.plist");
            }
            else
            {
                File.Delete(WorkingDir + @"\AMDVanillaConfig\config.plist");
                File.Move(WorkingDir + @"\AMDVanillaConfig\remoteconfig.plist", WorkingDir + @"\AMDVanillaConfig\config.plist");
            }
        }

        private void GetGibMacOS()
        {
            string zipPath = WorkingDir;
            string extractPath = WorkingDir + @"\gibMacOS-master";
            Uri gibmacos = new Uri("https://github.com/corpnewt/gibMacOS/archive/master.zip");

            try
            {
                System.Net.WebClient gibMacOSFiles = new System.Net.WebClient();
                gibMacOSFiles.DownloadFile(gibmacos, WorkingDir);
            }
            catch
            {
                if (MessageBox.Show("We tried to check for an updated version of the gibMacOS tool but were unable to, would you like to run this check again?", "GibMacOS tool check", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        System.Net.WebClient gibMacOSFiles = new System.Net.WebClient();
                        gibMacOSFiles.DownloadFile(gibmacos, WorkingDir);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            if (File.Exists(WorkingDir + @"\gibMacOS-master.zip"))
            {
                try
                {
                    ZipFile.ExtractToDirectory(zipPath, extractPath);
                }
                catch (Exception e)
                {
                    MessageBox.Show("We had some problems, here's the exception: " + e);
                }
            }
        }

        private void GetSMBIOSFiles()
        {
            string zipPath = WorkingDir;
            string extractPath = WorkingDir + "\\gibMacOS-master";
            Uri gensmbios = new Uri("https://github.com/corpnewt/GenSMBIOS/archive/master.zip");

            try
            {
                System.Net.WebClient gibMacOSFiles = new System.Net.WebClient();
                gibMacOSFiles.DownloadFile(gensmbios, WorkingDir);
            }
            catch
            {
                if (MessageBox.Show("We tried to check for an updated version of the SMBIOS tool but were unable to, would you like to run this check again?", "SMBIOS tool check", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        System.Net.WebClient gibMacOSFiles = new System.Net.WebClient();
                        gibMacOSFiles.DownloadFile(gensmbios, WorkingDir);
                    }
                    catch
                    {
                        MessageBox.Show("We tried to check the tool again, but were unable to. Please continue to use this tool, and manually verify the tool's version.");
                    }
                }
            }
            if (File.Exists(WorkingDir + "\\GenSMBIOS-master.zip"))
            {
                try
                {
                    ZipFile.ExtractToDirectory(zipPath, extractPath);
                }
                catch (Exception e)
                {
                    MessageBox.Show("We had some problems, here's the exception: " + e);
                }
            }
        }
    }
}
