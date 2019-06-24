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
using System.Security.AccessControl;
using System.Threading;

namespace RyzenHackintoshMediaBuilder
{


    public partial class Form1 : Form
    {
        String USBPath = "";
        String KextPath = "";
        String WorkingDir = "";
        StreamWriter stdin = null;
        String consoleOutput = "";
        bool dlMacOS, gennewbios, makeinstaller, macserial, configloaded = false;

        public Form1()
        {
            InitializeComponent();
            GetWorkingDir();
            CheckForUpdates();
            InstructLbl.Text = "Step 1 first!";
            Thread cmdThread = new Thread(ExecuteCommand);
            cmdThread.Start();
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
            // String MakeInstallPath = WorkingDir + @"\gibMacOS-master\MakeInstall.bat";
            //stdin.Write(MakeInstallPath + Environment.NewLine);
            MoveFiles();
        }

        private void GenSMBiosBtn_Click(object sender, EventArgs e)
        {
            gennewbios = true;
            //Generate a new SMBIOS based on "iMac14,2"
            String ConfigPath = "\"" + WorkingDir + @"\AMDVanillaConfig\config.plist" + "\"";
            InstructLbl.Text = "You'll need to press 1 and ENTER here, then \"y\", then let it download fully, then press enter.";
            String GenSMBIOSPath =  WorkingDir + @"\GenSMBIOS-master\GenSMBIOS.bat";
            stdin.Write(GenSMBIOSPath + Environment.NewLine);
        }

        private void DlMacOSBtn_Click(object sender, EventArgs e)
        {
            dlMacOS = true;
            //Use gibMacOS to download a copy of MacOS
            InstructLbl.Text = "You'll need to press 1 and ENTER here, then \"y\", then let it download fully, then press enter.";

            String gibMacOSPath = WorkingDir + @"\gibMacOS-master\gibMacOS.bat";
            
            stdin.WriteLine();
            stdin.Write(gibMacOSPath + Environment.NewLine);

           
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

        private void ExecuteCommand()
        {
            ProcessStartInfo pStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "start /WAIT",
                WorkingDirectory = WorkingDir,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process cmdProcess = new Process
            {
                StartInfo = pStartInfo,
                EnableRaisingEvents = true
            };

            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();
            stdin = cmdProcess.StandardInput;

            cmdProcess.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
            {
                if (e.Data != null)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        rtbStdOut.AppendText(e.Data + Environment.NewLine);
                        rtbStdOut.ScrollToCaret();
                        consoleOutput = e.Data;
                        CheckConsoleOuput();
                    }));
                }
            };

            cmdProcess.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
            {
                if (e.Data != null)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        rtbStdErr.AppendText(e.Data + Environment.NewLine);
                        rtbStdErr.ScrollToCaret();
                    }));
                }
            };

            cmdProcess.Exited += (object source, EventArgs ev) =>
            {
                cmdProcess.Close();
                if (cmdProcess != null)
                {
                    cmdProcess.Dispose();
                }
            };
        }

        private void GetConfigFile()
        {
            byte[] hashlocal;
            byte[] hashremote;
            Uri config = new Uri("https://raw.githubusercontent.com/andymanic/RyzenHackintoshMediaBuilder/master/AMDVanillaConfig/config.plist");

            if(!Directory.Exists(WorkingDir + "\\AMDVanillaConfig"))
            {
                Directory.CreateDirectory(WorkingDir + "\\AMDVanillaConfig");
            }

            try
            {
                System.Net.WebClient configFile = new System.Net.WebClient();
                configFile.DownloadFile(config, WorkingDir + "\\AMDVanillaConfig\\remoteconfig.plist");
            }
            catch
            {
                if (MessageBox.Show("We tried to check for an updated version of the Config.plist file but were unable to, would you like to run this check again?", "Config.plist file check", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        System.Net.WebClient configFile = new System.Net.WebClient();
                        configFile.DownloadFile(config, WorkingDir + "\\AMDVanillaConfig\\remoteconfig.plist");
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("We tried to check the file again, but were unable to. Please continue to use this tool, and manually verify the file version." + "  \n Exception: " + e);
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
            string zipPath = WorkingDir + "\\gibMacOS-master.zip";
            string extractPath = WorkingDir;
            Uri gibmacos = new Uri("https://github.com/corpnewt/gibMacOS/archive/master.zip");

            try
            {
                System.Net.WebClient gibMacOSFiles = new System.Net.WebClient();
                gibMacOSFiles.DownloadFile(gibmacos, WorkingDir +"\\gibMacOS-master.zip");
            }
            catch
            {
                if (MessageBox.Show("We tried to check for an updated version of the gibMacOS tool but were unable to, would you like to run this check again?", "GibMacOS tool check", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        System.Net.WebClient gibMacOSFiles = new System.Net.WebClient();
                        gibMacOSFiles.DownloadFile(gibmacos, WorkingDir + "\\gibMacOS-master.zip");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(""+e);
                    }
                }
            }
            DateTime modification = File.GetLastWriteTime(WorkingDir + "\\gibMacOS-master\\gibMacOS.bat");
            DateTime current = DateTime.Now;
            
            if (File.Exists(WorkingDir + @"\gibMacOS-master.zip"))
            {
                if (modification < current && File.Exists(WorkingDir + "\\gibMacOS-master\\gibMacOS.bat"))
                {
                    Directory.Delete(WorkingDir + "\\gibMacOS-master", true);
                    try
                    {
                        ZipFile.ExtractToDirectory(zipPath, extractPath);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("We had some problems, here's the exception: " + e);
                    }
                }
                else if (!File.Exists(WorkingDir + "\\gibMacOS-master\\gibMacOS.bat"))
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
                File.Delete(WorkingDir + "\\gibMacOS-master.zip");
            }
        }

        private void GetSMBIOSFiles()
        {
            string zipPath = WorkingDir + "\\GenSMBIOS-master.zip";
            string extractPath = WorkingDir;
            Uri gensmbios = new Uri("https://github.com/corpnewt/GenSMBIOS/archive/master.zip");

            try
            {
                System.Net.WebClient genSMBIOSFiles = new System.Net.WebClient();
                genSMBIOSFiles.DownloadFile(gensmbios, WorkingDir + "\\GenSMBIOS-master.zip");
            }
            catch
            {
                if (MessageBox.Show("We tried to check for an updated version of the GenSMBIOS tool but were unable to, would you like to run this check again?", "GenSMBIOS tool check", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        System.Net.WebClient genSMBIOSFiles = new System.Net.WebClient();
                        genSMBIOSFiles.DownloadFile(gensmbios, WorkingDir + "\\GenSMBIOS-master.zip");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("" + e);
                    }
                }
            }
            DateTime modification = File.GetLastWriteTime(WorkingDir + "\\GenSMBIOS-master\\GenSMBIOS.bat");
            DateTime current = DateTime.Now;

            if (File.Exists(WorkingDir + @"\GenSMBIOS-master.zip"))
            {
                if (modification < current && File.Exists(WorkingDir+"\\GenSMBIOS-master\\GenSMBIOS.bat"))
                {
                    Directory.Delete(WorkingDir + "\\GenSMBIOS-master", true);
                    try
                    {
                        ZipFile.ExtractToDirectory(zipPath, extractPath);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("We had some problems, here's the exception: " + e);
                    }
                }
                else if (!File.Exists(WorkingDir+"\\GenSMBIOS-master\\GenSMBIOS.bat"))
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
                File.Delete(WorkingDir + "\\GenSMBIOS-master.zip");
            }
        }

        private void rtbStdIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (stdin == null)
                {
                    rtbStdErr.AppendText("Process not started" + Environment.NewLine);
                    return;
                }

                e.Handled = true;
                stdin.Write(rtbStdIn.Text + Environment.NewLine);
                stdin.WriteLine();
                rtbStdIn.Clear();
            }
        }

        private void MakeInstallerBtn_Click(object sender, EventArgs e)
        {
            makeinstaller = true;
            String MakeInstallPath = WorkingDir + "\\gibMacOS-master\\MakeInstall.bat";
            stdin.Write(MakeInstallPath + Environment.NewLine);
            
        }

        private void CheckConsoleOuput()
        {
            if (dlMacOS)
            {
                //Checks the output of the console to determine the next input
                if (consoleOutput.Contains("Python"))
                {
                    stdin.Write("y" + Environment.NewLine);
                }
                else if (consoleOutput.Contains("Available Products"))
                {
                    stdin.Write("1" + Environment.NewLine);
                }
                else if(consoleOutput.Contains("Redownload")) {
                    stdin.Write("n" + Environment.NewLine);
                }
                else if (consoleOutput.Contains("Press [enter] to return"))
                {
                    stdin.Write(Environment.NewLine);
                    stdin.WriteLine();
                    stdin.Write("Q" + Environment.NewLine);
                    dlMacOS = false;
                }
            }else if (makeinstaller)
            {
                if (consoleOutput.Contains("Potential Removable Media"))
                {
                    //Work out which drive the user has already selected, then select that one.
                    switch (USBPath)
                    {
                        case "D:\\":
                            stdin.Write("1" + Environment.NewLine);
                            stdin.Write("y" + Environment.NewLine);
                            break;
                        case "E:\\":
                            stdin.Write("2" + Environment.NewLine);
                            stdin.Write("y" + Environment.NewLine);
                            break;
                        case "F:\\":
                            stdin.Write("3" + Environment.NewLine);
                            stdin.Write("y" + Environment.NewLine);
                            break;
                        case "G:\\":
                            stdin.Write("4" + Environment.NewLine);
                            stdin.Write("y" + Environment.NewLine);
                            break;
                        case "H:\\":
                            stdin.Write("5" + Environment.NewLine);
                            stdin.Write("y" + Environment.NewLine);
                            break;
                        case "I:\\":
                            stdin.Write("6" + Environment.NewLine);
                            stdin.Write("y" + Environment.NewLine);
                            break;
                        case "J:\\":
                            stdin.Write("7" + Environment.NewLine);
                            stdin.Write("y" + Environment.NewLine);
                            break;
                        case "K:\\":
                            stdin.Write("8" + Environment.NewLine);
                            stdin.Write("y" + Environment.NewLine);
                            break;
                        default:
                            MessageBox.Show("Please make sure you have selected your USB drive before continuing.");
                            break;
                    }
                    
                }else if(consoleOutput.Contains("Select Recovery Package"))
                {
                    String[] MacOSPath = Directory.GetDirectories(WorkingDir + "\\gibMacOS-master\\macOS Downloads\\publicrelease\\", "*", SearchOption.AllDirectories);
                    
                    String RecoveryPath = MacOSPath[0] + "\\RecoveryHDMetaDmg.pkg";
                    stdin.Write("\"" + RecoveryPath + "\"" + Environment.NewLine);
                }
                else if (consoleOutput.Contains("Press [enter]"))
                {
                    stdin.Write(Environment.NewLine);
                    stdin.Write("q" + Environment.NewLine);
                    makeinstaller = false;
                }
            }
            else if (gennewbios)
            {
                
                if (consoleOutput.Contains("MacSerial not found!") && !macserial)
                {
                    stdin.Write("1" + Environment.NewLine);
                    macserial = true;
                }else if (consoleOutput.Contains("Current plist: None") && !configloaded)
                {
                    stdin.Write(USBPath + "\\CLOVER\\EFI\\CLOVER\\config.plist" + Environment.NewLine);
                    configloaded = true;
                }else if (consoleOutput.Contains("3. Generate SMBIOS"))
                {
                    stdin.Write("3" + Environment.NewLine);
                    stdin.Write("iMac14,2" + Environment.NewLine);
                    stdin.Write(Environment.NewLine);
                    stdin.Write("q" + Environment.NewLine);
                    gennewbios = false;
                }
            }
        }
        private void MoveFiles()
        {
            String configPath = WorkingDir + "\\AMDVanillaConfig\\config.plist";
            String USBCloverPath = USBPath + "\\CLOVER\\EFI\\CLOVER";

            String atpioPath = USBCloverPath + "\\drivers-Off\\drivers64UEFI\\aptiomemoryfix-64.efi";
            String hfsPath = USBCloverPath + "\\drivers-Off\\drivers64UEFI\\HFSPlus.efi";

            String drivers64Path = USBCloverPath + "\\drivers64UEFI";

            String DestinationPath = USBCloverPath + "\\kexts\\Other";

            try
            {
                File.Copy(configPath, USBCloverPath + "\\config.plist", true); //copy config file, overwriting the old one
                File.Copy(atpioPath, drivers64Path + "\\AptioMemoryFix-64.efi"); //copy aptiomemoryfix to correct folder
                File.Copy(hfsPath, drivers64Path + "\\HFSPlus.efi"); //copy hfsplus to correct folder
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
            try
            {
                //Copy all kexts to the drive
                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(KextPath, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(KextPath, DestinationPath));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(KextPath, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(KextPath, DestinationPath), true);
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
            
        }
    }
}
