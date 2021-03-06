﻿/*
    UsingSongGetter is a easy to use Program, to get your Current Playing Song
    and Display it for example in your Livestream.

    Copyright (C) 2016  usingalex

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

	If you need Help, or you have any Questions Contact me at: usingalex@gmail.com
*/
namespace UsingSongGetter
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.titleBar = new System.Windows.Forms.Panel();
            this.titleBarLogo = new System.Windows.Forms.PictureBox();
            this.titleBar_Title = new System.Windows.Forms.Label();
            this.titleBar_Close = new System.Windows.Forms.Panel();
            this.titleBar_Minimize = new System.Windows.Forms.Panel();
            this.refreshSlider = new System.Windows.Forms.TrackBar();
            this.prefixInput = new System.Windows.Forms.TextBox();
            this.suffixInput = new System.Windows.Forms.TextBox();
            this.songPreview = new System.Windows.Forms.TextBox();
            this.modeSelector_Spotify = new System.Windows.Forms.RadioButton();
            this.modeSelector_InternetExplorer = new System.Windows.Forms.RadioButton();
            this.saveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.prefixLabel = new System.Windows.Forms.Label();
            this.suffixLabel = new System.Windows.Forms.Label();
            this.songLabel = new System.Windows.Forms.Label();
            this.refreshLabel = new System.Windows.Forms.Label();
            this.tabSelector = new System.Windows.Forms.ComboBox();
            this.refreshTabsButton = new System.Windows.Forms.Button();
            this.tabSelectorLabel = new System.Windows.Forms.Label();
            this.aboutButton = new System.Windows.Forms.Button();
            this.hideButton = new System.Windows.Forms.Button();
            this.invalidSongInput = new System.Windows.Forms.TextBox();
            this.invalidSongLabel = new System.Windows.Forms.Label();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titleBarLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.titleBar.Controls.Add(this.titleBarLogo);
            this.titleBar.Controls.Add(this.titleBar_Title);
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(470, 25);
            this.titleBar.TabIndex = 0;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseMove);
            this.titleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseUp);
            // 
            // titleBarLogo
            // 
            this.titleBarLogo.Image = global::UsingSongGetter.Properties.Resources.logo;
            this.titleBarLogo.Location = new System.Drawing.Point(0, 0);
            this.titleBarLogo.Name = "titleBarLogo";
            this.titleBarLogo.Size = new System.Drawing.Size(25, 25);
            this.titleBarLogo.TabIndex = 3;
            this.titleBarLogo.TabStop = false;
            // 
            // titleBar_Title
            // 
            this.titleBar_Title.AutoSize = true;
            this.titleBar_Title.Location = new System.Drawing.Point(25, 7);
            this.titleBar_Title.Name = "titleBar_Title";
            this.titleBar_Title.Size = new System.Drawing.Size(88, 13);
            this.titleBar_Title.TabIndex = 3;
            this.titleBar_Title.Text = "UsingSongGetter";
            // 
            // titleBar_Close
            // 
            this.titleBar_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.titleBar_Close.Location = new System.Drawing.Point(445, 0);
            this.titleBar_Close.Name = "titleBar_Close";
            this.titleBar_Close.Size = new System.Drawing.Size(25, 25);
            this.titleBar_Close.TabIndex = 1;
            this.titleBar_Close.MouseClick += new System.Windows.Forms.MouseEventHandler(this.titleBar_Close_MouseClick);
            this.titleBar_Close.MouseEnter += new System.EventHandler(this.titleBar_Close_MouseEnter);
            this.titleBar_Close.MouseLeave += new System.EventHandler(this.titleBar_Close_MouseLeave);
            // 
            // titleBar_Minimize
            // 
            this.titleBar_Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.titleBar_Minimize.Location = new System.Drawing.Point(420, 0);
            this.titleBar_Minimize.Name = "titleBar_Minimize";
            this.titleBar_Minimize.Size = new System.Drawing.Size(25, 25);
            this.titleBar_Minimize.TabIndex = 2;
            this.titleBar_Minimize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.titleBar_Minimize_MouseClick);
            this.titleBar_Minimize.MouseEnter += new System.EventHandler(this.titleBar_Minimize_MouseEnter);
            this.titleBar_Minimize.MouseLeave += new System.EventHandler(this.titleBar_Minimize_MouseLeave);
            // 
            // refreshSlider
            // 
            this.refreshSlider.Location = new System.Drawing.Point(12, 153);
            this.refreshSlider.Name = "refreshSlider";
            this.refreshSlider.Size = new System.Drawing.Size(446, 45);
            this.refreshSlider.TabIndex = 3;
            this.refreshSlider.Value = 5;
            this.refreshSlider.ValueChanged += new System.EventHandler(this.refreshSlider_ValueChanged);
            // 
            // prefixInput
            // 
            this.prefixInput.Location = new System.Drawing.Point(13, 64);
            this.prefixInput.Name = "prefixInput";
            this.prefixInput.Size = new System.Drawing.Size(100, 20);
            this.prefixInput.TabIndex = 4;
            // 
            // suffixInput
            // 
            this.suffixInput.Location = new System.Drawing.Point(358, 64);
            this.suffixInput.Name = "suffixInput";
            this.suffixInput.Size = new System.Drawing.Size(100, 20);
            this.suffixInput.TabIndex = 5;
            // 
            // songPreview
            // 
            this.songPreview.Location = new System.Drawing.Point(119, 64);
            this.songPreview.Name = "songPreview";
            this.songPreview.ReadOnly = true;
            this.songPreview.Size = new System.Drawing.Size(233, 20);
            this.songPreview.TabIndex = 6;
            this.songPreview.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // modeSelector_Spotify
            // 
            this.modeSelector_Spotify.AutoSize = true;
            this.modeSelector_Spotify.Checked = true;
            this.modeSelector_Spotify.Location = new System.Drawing.Point(12, 300);
            this.modeSelector_Spotify.Name = "modeSelector_Spotify";
            this.modeSelector_Spotify.Size = new System.Drawing.Size(57, 17);
            this.modeSelector_Spotify.TabIndex = 8;
            this.modeSelector_Spotify.TabStop = true;
            this.modeSelector_Spotify.Text = "Spotify";
            this.modeSelector_Spotify.UseVisualStyleBackColor = true;
            // 
            // modeSelector_InternetExplorer
            // 
            this.modeSelector_InternetExplorer.AutoSize = true;
            this.modeSelector_InternetExplorer.Location = new System.Drawing.Point(11, 323);
            this.modeSelector_InternetExplorer.Name = "modeSelector_InternetExplorer";
            this.modeSelector_InternetExplorer.Size = new System.Drawing.Size(102, 17);
            this.modeSelector_InternetExplorer.TabIndex = 9;
            this.modeSelector_InternetExplorer.Text = "Internet Explorer";
            this.modeSelector_InternetExplorer.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(358, 294);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Apply Settings";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(358, 323);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(100, 23);
            this.resetButton.TabIndex = 11;
            this.resetButton.Text = "Reset Settings ";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // prefixLabel
            // 
            this.prefixLabel.AutoSize = true;
            this.prefixLabel.Location = new System.Drawing.Point(46, 48);
            this.prefixLabel.Name = "prefixLabel";
            this.prefixLabel.Size = new System.Drawing.Size(33, 13);
            this.prefixLabel.TabIndex = 12;
            this.prefixLabel.Text = "Prefix";
            // 
            // suffixLabel
            // 
            this.suffixLabel.AutoSize = true;
            this.suffixLabel.Location = new System.Drawing.Point(391, 47);
            this.suffixLabel.Name = "suffixLabel";
            this.suffixLabel.Size = new System.Drawing.Size(33, 13);
            this.suffixLabel.TabIndex = 13;
            this.suffixLabel.Text = "Suffix";
            // 
            // songLabel
            // 
            this.songLabel.AutoSize = true;
            this.songLabel.Location = new System.Drawing.Point(219, 47);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(32, 13);
            this.songLabel.TabIndex = 14;
            this.songLabel.Text = "Song";
            // 
            // refreshLabel
            // 
            this.refreshLabel.AutoSize = true;
            this.refreshLabel.Location = new System.Drawing.Point(200, 137);
            this.refreshLabel.Name = "refreshLabel";
            this.refreshLabel.Size = new System.Drawing.Size(70, 13);
            this.refreshLabel.TabIndex = 15;
            this.refreshLabel.Text = "Refresh-Rate";
            // 
            // tabSelector
            // 
            this.tabSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tabSelector.FormattingEnabled = true;
            this.tabSelector.Location = new System.Drawing.Point(11, 382);
            this.tabSelector.Name = "tabSelector";
            this.tabSelector.Size = new System.Drawing.Size(259, 21);
            this.tabSelector.TabIndex = 16;
            this.tabSelector.Visible = false;
            this.tabSelector.SelectedIndexChanged += new System.EventHandler(this.tabSelector_SelectedIndexChanged);
            // 
            // refreshTabsButton
            // 
            this.refreshTabsButton.Location = new System.Drawing.Point(11, 423);
            this.refreshTabsButton.Name = "refreshTabsButton";
            this.refreshTabsButton.Size = new System.Drawing.Size(75, 23);
            this.refreshTabsButton.TabIndex = 17;
            this.refreshTabsButton.Text = "Refresh";
            this.refreshTabsButton.UseVisualStyleBackColor = true;
            this.refreshTabsButton.Visible = false;
            this.refreshTabsButton.Click += new System.EventHandler(this.refreshTabsButton_Click);
            // 
            // tabSelectorLabel
            // 
            this.tabSelectorLabel.AutoSize = true;
            this.tabSelectorLabel.Location = new System.Drawing.Point(111, 366);
            this.tabSelectorLabel.Name = "tabSelectorLabel";
            this.tabSelectorLabel.Size = new System.Drawing.Size(59, 13);
            this.tabSelectorLabel.TabIndex = 18;
            this.tabSelectorLabel.Text = "Select Tab";
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(11, 496);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 19;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // hideButton
            // 
            this.hideButton.Location = new System.Drawing.Point(358, 496);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(100, 23);
            this.hideButton.TabIndex = 20;
            this.hideButton.Text = "Hide Window";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // invalidSongInput
            // 
            this.invalidSongInput.Location = new System.Drawing.Point(13, 102);
            this.invalidSongInput.Name = "invalidSongInput";
            this.invalidSongInput.Size = new System.Drawing.Size(100, 20);
            this.invalidSongInput.TabIndex = 21;
            // 
            // invalidSongLabel
            // 
            this.invalidSongLabel.AutoSize = true;
            this.invalidSongLabel.Location = new System.Drawing.Point(30, 87);
            this.invalidSongLabel.Name = "invalidSongLabel";
            this.invalidSongLabel.Size = new System.Drawing.Size(66, 13);
            this.invalidSongLabel.TabIndex = 22;
            this.invalidSongLabel.Text = "Invalid Song";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(470, 531);
            this.Controls.Add(this.invalidSongLabel);
            this.Controls.Add(this.invalidSongInput);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.tabSelectorLabel);
            this.Controls.Add(this.refreshTabsButton);
            this.Controls.Add(this.tabSelector);
            this.Controls.Add(this.refreshLabel);
            this.Controls.Add(this.songLabel);
            this.Controls.Add(this.suffixLabel);
            this.Controls.Add(this.prefixLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.modeSelector_InternetExplorer);
            this.Controls.Add(this.modeSelector_Spotify);
            this.Controls.Add(this.songPreview);
            this.Controls.Add(this.suffixInput);
            this.Controls.Add(this.prefixInput);
            this.Controls.Add(this.refreshSlider);
            this.Controls.Add(this.titleBar_Minimize);
            this.Controls.Add(this.titleBar_Close);
            this.Controls.Add(this.titleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsingSongGetter";
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titleBarLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Panel titleBar_Close;
        private System.Windows.Forms.Panel titleBar_Minimize;
        private System.Windows.Forms.Label titleBar_Title;
        private System.Windows.Forms.PictureBox titleBarLogo;
        private System.Windows.Forms.TrackBar refreshSlider;
        private System.Windows.Forms.TextBox prefixInput;
        private System.Windows.Forms.TextBox suffixInput;
        private System.Windows.Forms.TextBox songPreview;
        private System.Windows.Forms.RadioButton modeSelector_Spotify;
        private System.Windows.Forms.RadioButton modeSelector_InternetExplorer;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label prefixLabel;
        private System.Windows.Forms.Label suffixLabel;
        private System.Windows.Forms.Label songLabel;
        private System.Windows.Forms.Label refreshLabel;
        private System.Windows.Forms.ComboBox tabSelector;
        private System.Windows.Forms.Button refreshTabsButton;
        private System.Windows.Forms.Label tabSelectorLabel;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.TextBox invalidSongInput;
        private System.Windows.Forms.Label invalidSongLabel;
    }
}

