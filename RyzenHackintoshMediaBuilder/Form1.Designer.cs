namespace RyzenHackintoshMediaBuilder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectDriveBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SelectKextsFolderBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customiseConfigplistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DlMacOSBtn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BldDriveBtn = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.GenSMBiosBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.InstructLbl = new System.Windows.Forms.Label();
            this.rtbStdOut = new System.Windows.Forms.RichTextBox();
            this.rtbStdIn = new System.Windows.Forms.RichTextBox();
            this.rtbStdErr = new System.Windows.Forms.RichTextBox();
            this.MakeInstallerBtn = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectDriveBtn
            // 
            this.SelectDriveBtn.BackColor = System.Drawing.Color.White;
            this.SelectDriveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectDriveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDriveBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SelectDriveBtn.Location = new System.Drawing.Point(24, 59);
            this.SelectDriveBtn.Name = "SelectDriveBtn";
            this.SelectDriveBtn.Size = new System.Drawing.Size(383, 57);
            this.SelectDriveBtn.TabIndex = 0;
            this.SelectDriveBtn.Text = "Select USB Drive";
            this.SelectDriveBtn.UseVisualStyleBackColor = false;
            this.SelectDriveBtn.Click += new System.EventHandler(this.SelectDriveBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightCoral;
            this.groupBox1.Controls.Add(this.SelectDriveBtn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(23, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start here - Step 1";
            // 
            // SelectKextsFolderBtn
            // 
            this.SelectKextsFolderBtn.BackColor = System.Drawing.Color.White;
            this.SelectKextsFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectKextsFolderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectKextsFolderBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SelectKextsFolderBtn.Location = new System.Drawing.Point(24, 60);
            this.SelectKextsFolderBtn.Name = "SelectKextsFolderBtn";
            this.SelectKextsFolderBtn.Size = new System.Drawing.Size(383, 57);
            this.SelectKextsFolderBtn.TabIndex = 2;
            this.SelectKextsFolderBtn.Text = "Select Kexts Folder";
            this.SelectKextsFolderBtn.UseVisualStyleBackColor = false;
            this.SelectKextsFolderBtn.Click += new System.EventHandler(this.SelectKextsFolderBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightCoral;
            this.groupBox2.Controls.Add(this.SelectKextsFolderBtn);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(23, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 140);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1417, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customiseConfigplistToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // customiseConfigplistToolStripMenuItem
            // 
            this.customiseConfigplistToolStripMenuItem.Name = "customiseConfigplistToolStripMenuItem";
            this.customiseConfigplistToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.customiseConfigplistToolStripMenuItem.Text = "Customise config.plist";
            this.customiseConfigplistToolStripMenuItem.Click += new System.EventHandler(this.customiseConfigplistToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightCoral;
            this.groupBox4.Controls.Add(this.DlMacOSBtn);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox4.Location = new System.Drawing.Point(23, 370);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(433, 140);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Step 3";
            // 
            // DlMacOSBtn
            // 
            this.DlMacOSBtn.BackColor = System.Drawing.Color.White;
            this.DlMacOSBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DlMacOSBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DlMacOSBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DlMacOSBtn.Location = new System.Drawing.Point(24, 55);
            this.DlMacOSBtn.Name = "DlMacOSBtn";
            this.DlMacOSBtn.Size = new System.Drawing.Size(383, 57);
            this.DlMacOSBtn.TabIndex = 4;
            this.DlMacOSBtn.Text = "Download MacOS";
            this.DlMacOSBtn.UseVisualStyleBackColor = false;
            this.DlMacOSBtn.Click += new System.EventHandler(this.DlMacOSBtn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.LightCoral;
            this.groupBox5.Controls.Add(this.BldDriveBtn);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox5.Location = new System.Drawing.Point(505, 212);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(433, 140);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Step 5";
            // 
            // BldDriveBtn
            // 
            this.BldDriveBtn.BackColor = System.Drawing.Color.White;
            this.BldDriveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BldDriveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BldDriveBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BldDriveBtn.Location = new System.Drawing.Point(24, 60);
            this.BldDriveBtn.Name = "BldDriveBtn";
            this.BldDriveBtn.Size = new System.Drawing.Size(383, 57);
            this.BldDriveBtn.TabIndex = 5;
            this.BldDriveBtn.Text = "copy files";
            this.BldDriveBtn.UseVisualStyleBackColor = false;
            this.BldDriveBtn.Click += new System.EventHandler(this.BldDriveBtn_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.LightCoral;
            this.groupBox6.Controls.Add(this.GenSMBiosBtn);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox6.Location = new System.Drawing.Point(505, 371);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(433, 140);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Step 4";
            // 
            // GenSMBiosBtn
            // 
            this.GenSMBiosBtn.BackColor = System.Drawing.Color.White;
            this.GenSMBiosBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenSMBiosBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenSMBiosBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GenSMBiosBtn.Location = new System.Drawing.Point(24, 55);
            this.GenSMBiosBtn.Name = "GenSMBiosBtn";
            this.GenSMBiosBtn.Size = new System.Drawing.Size(383, 57);
            this.GenSMBiosBtn.TabIndex = 4;
            this.GenSMBiosBtn.Text = "Generate SMBIOS";
            this.GenSMBiosBtn.UseVisualStyleBackColor = false;
            this.GenSMBiosBtn.Click += new System.EventHandler(this.GenSMBiosBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightCoral;
            this.groupBox3.Controls.Add(this.InstructLbl);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Location = new System.Drawing.Point(973, 446);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(433, 127);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Instructions";
            // 
            // InstructLbl
            // 
            this.InstructLbl.AutoSize = true;
            this.InstructLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructLbl.Location = new System.Drawing.Point(16, 45);
            this.InstructLbl.MaximumSize = new System.Drawing.Size(400, 0);
            this.InstructLbl.Name = "InstructLbl";
            this.InstructLbl.Size = new System.Drawing.Size(400, 48);
            this.InstructLbl.TabIndex = 0;
            this.InstructLbl.Text = "label112156156165165165156165151651651516515616516156161655";
            // 
            // rtbStdOut
            // 
            this.rtbStdOut.Location = new System.Drawing.Point(973, 51);
            this.rtbStdOut.Name = "rtbStdOut";
            this.rtbStdOut.Size = new System.Drawing.Size(433, 274);
            this.rtbStdOut.TabIndex = 7;
            this.rtbStdOut.Text = "";
            // 
            // rtbStdIn
            // 
            this.rtbStdIn.Location = new System.Drawing.Point(972, 380);
            this.rtbStdIn.Name = "rtbStdIn";
            this.rtbStdIn.Size = new System.Drawing.Size(434, 35);
            this.rtbStdIn.TabIndex = 8;
            this.rtbStdIn.Text = "";
            this.rtbStdIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbStdIn_KeyPress);
            // 
            // rtbStdErr
            // 
            this.rtbStdErr.Location = new System.Drawing.Point(972, 331);
            this.rtbStdErr.Name = "rtbStdErr";
            this.rtbStdErr.Size = new System.Drawing.Size(433, 43);
            this.rtbStdErr.TabIndex = 9;
            this.rtbStdErr.Text = "";
            // 
            // MakeInstallerBtn
            // 
            this.MakeInstallerBtn.BackColor = System.Drawing.Color.White;
            this.MakeInstallerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MakeInstallerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MakeInstallerBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MakeInstallerBtn.Location = new System.Drawing.Point(24, 48);
            this.MakeInstallerBtn.Name = "MakeInstallerBtn";
            this.MakeInstallerBtn.Size = new System.Drawing.Size(383, 57);
            this.MakeInstallerBtn.TabIndex = 6;
            this.MakeInstallerBtn.Text = "Make installer";
            this.MakeInstallerBtn.UseVisualStyleBackColor = false;
            this.MakeInstallerBtn.Click += new System.EventHandler(this.MakeInstallerBtn_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.LightCoral;
            this.groupBox7.Controls.Add(this.MakeInstallerBtn);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox7.Location = new System.Drawing.Point(505, 51);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(433, 140);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Step 5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1417, 590);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.rtbStdErr);
            this.Controls.Add(this.rtbStdIn);
            this.Controls.Add(this.rtbStdOut);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Ryzen Hackintosh Media Builder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectDriveBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SelectKextsFolderBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customiseConfigplistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button DlMacOSBtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button GenSMBiosBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label InstructLbl;
        private System.Windows.Forms.RichTextBox rtbStdOut;
        private System.Windows.Forms.RichTextBox rtbStdIn;
        private System.Windows.Forms.RichTextBox rtbStdErr;
        private System.Windows.Forms.Button BldDriveBtn;
        private System.Windows.Forms.Button MakeInstallerBtn;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}

