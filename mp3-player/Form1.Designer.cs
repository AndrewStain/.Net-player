namespace mp3_player
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonPlayPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPrewSound = new System.Windows.Forms.Button();
            this.buttonNextSound = new System.Windows.Forms.Button();
            this.buttonMute = new System.Windows.Forms.Button();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.trackBarSound = new System.Windows.Forms.TrackBar();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelPlaylist = new System.Windows.Forms.Label();
            this.listBoxPlaylist = new System.Windows.Forms.ListBox();
            this.buttonFilters = new System.Windows.Forms.Button();
            this.labelDuration = new System.Windows.Forms.Label();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSelectedFilters = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSound)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.Location = new System.Drawing.Point(13, 13);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(25, 25);
            this.buttonPlayPause.TabIndex = 0;
            this.buttonPlayPause.UseVisualStyleBackColor = true;
            this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(51, 13);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(25, 25);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPrewSound
            // 
            this.buttonPrewSound.Location = new System.Drawing.Point(88, 13);
            this.buttonPrewSound.Name = "buttonPrewSound";
            this.buttonPrewSound.Size = new System.Drawing.Size(25, 25);
            this.buttonPrewSound.TabIndex = 2;
            this.buttonPrewSound.UseVisualStyleBackColor = true;
            this.buttonPrewSound.Click += new System.EventHandler(this.buttonPrewSound_Click);
            // 
            // buttonNextSound
            // 
            this.buttonNextSound.Location = new System.Drawing.Point(123, 13);
            this.buttonNextSound.Name = "buttonNextSound";
            this.buttonNextSound.Size = new System.Drawing.Size(25, 25);
            this.buttonNextSound.TabIndex = 3;
            this.buttonNextSound.UseVisualStyleBackColor = true;
            this.buttonNextSound.Click += new System.EventHandler(this.buttonNextSound_Click);
            // 
            // buttonMute
            // 
            this.buttonMute.Location = new System.Drawing.Point(158, 13);
            this.buttonMute.Name = "buttonMute";
            this.buttonMute.Size = new System.Drawing.Size(25, 25);
            this.buttonMute.TabIndex = 4;
            this.buttonMute.UseVisualStyleBackColor = true;
            this.buttonMute.Click += new System.EventHandler(this.buttonMute_Click);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolume.AutoSize = false;
            this.trackBarVolume.Location = new System.Drawing.Point(189, 13);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(195, 45);
            this.trackBarVolume.TabIndex = 5;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVolume.Value = 50;
            this.trackBarVolume.ValueChanged += new System.EventHandler(this.trackBarVolume_ValueChanged);
            // 
            // trackBarSound
            // 
            this.trackBarSound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSound.AutoSize = false;
            this.trackBarSound.LargeChange = 1;
            this.trackBarSound.Location = new System.Drawing.Point(12, 44);
            this.trackBarSound.Maximum = 300;
            this.trackBarSound.Name = "trackBarSound";
            this.trackBarSound.Size = new System.Drawing.Size(372, 45);
            this.trackBarSound.TabIndex = 6;
            this.trackBarSound.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarSound.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarSound_MouseUp);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBrowse.Location = new System.Drawing.Point(65, 71);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowse.TabIndex = 7;
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelPlaylist
            // 
            this.labelPlaylist.AutoSize = true;
            this.labelPlaylist.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPlaylist.Location = new System.Drawing.Point(12, 72);
            this.labelPlaylist.Name = "labelPlaylist";
            this.labelPlaylist.Size = new System.Drawing.Size(47, 17);
            this.labelPlaylist.TabIndex = 8;
            this.labelPlaylist.Text = "Playlist";
            // 
            // listBoxPlaylist
            // 
            this.listBoxPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPlaylist.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxPlaylist.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxPlaylist.FormattingEnabled = true;
            this.listBoxPlaylist.Location = new System.Drawing.Point(12, 97);
            this.listBoxPlaylist.Name = "listBoxPlaylist";
            this.listBoxPlaylist.Size = new System.Drawing.Size(372, 303);
            this.listBoxPlaylist.TabIndex = 9;
            this.listBoxPlaylist.DoubleClick += new System.EventHandler(this.listBoxPlaylist_DoubleClick);
            this.listBoxPlaylist.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxPlaylist_KeyUp);
            this.listBoxPlaylist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxPlaylist_MouseDown);
            // 
            // buttonFilters
            // 
            this.buttonFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFilters.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFilters.Location = new System.Drawing.Point(10, 4);
            this.buttonFilters.Name = "buttonFilters";
            this.buttonFilters.Size = new System.Drawing.Size(54, 20);
            this.buttonFilters.TabIndex = 10;
            this.buttonFilters.Text = "Filters";
            this.buttonFilters.UseVisualStyleBackColor = true;
            this.buttonFilters.Click += new System.EventHandler(this.buttonFilters_Click);
            // 
            // labelDuration
            // 
            this.labelDuration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelDuration.AutoSize = true;
            this.labelDuration.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDuration.Location = new System.Drawing.Point(136, 64);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(117, 25);
            this.labelDuration.TabIndex = 11;
            this.labelDuration.Text = "00:00 / 00:00";
            // 
            // buttonRandom
            // 
            this.buttonRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRandom.Location = new System.Drawing.Point(70, 4);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(20, 20);
            this.buttonRandom.TabIndex = 12;
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(96, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(20, 20);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(122, 4);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(20, 20);
            this.buttonLoad.TabIndex = 14;
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Controls.Add(this.buttonRandom);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.buttonFilters);
            this.panel1.Location = new System.Drawing.Point(244, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 27);
            this.panel1.TabIndex = 15;
            // 
            // labelSelectedFilters
            // 
            this.labelSelectedFilters.AutoSize = true;
            this.labelSelectedFilters.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSelectedFilters.Location = new System.Drawing.Point(12, 407);
            this.labelSelectedFilters.Name = "labelSelectedFilters";
            this.labelSelectedFilters.Size = new System.Drawing.Size(153, 13);
            this.labelSelectedFilters.TabIndex = 16;
            this.labelSelectedFilters.Text = "Selected Filters: not selected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(398, 427);
            this.Controls.Add(this.labelSelectedFilters);
            this.Controls.Add(this.listBoxPlaylist);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.labelPlaylist);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.trackBarSound);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.buttonMute);
            this.Controls.Add(this.buttonNextSound);
            this.Controls.Add(this.buttonPrewSound);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlayPause);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MusicMan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSound)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlayPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPrewSound;
        private System.Windows.Forms.Button buttonNextSound;
        private System.Windows.Forms.Button buttonMute;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.TrackBar trackBarSound;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelPlaylist;
        private System.Windows.Forms.ListBox listBoxPlaylist;
        private System.Windows.Forms.Button buttonFilters;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSelectedFilters;
        private System.Windows.Forms.ToolTip toolTip;
    }
}