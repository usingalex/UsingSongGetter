using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
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
    public partial class MainWindow : Form
    {

        public static volatile MainWindow instance;

        private bool _titleBarClicked = false;
        private Point _lastCursorPosition;

        private ConfigManager _cm;
        private RefreshWorker _refreshWorker;
        private Thread _refreshThread;
        private Settings _settings;

        public MainWindow()
        {
            InitializeComponent();
            instance = this;

            //Get the Path of the Directory and currentSong file.
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UsingSongGetter");
            string file = Path.Combine(dir, "currentSong.txt");

            //Create the Directory and File if they don't exist.
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (!File.Exists(file))
            {
                File.Create(file).Close();
            }

            //Initialize the ConfigManager, and load the Settings.
            _cm = new ConfigManager(dir, "settings.cfg");
            _settings = _cm.loadSettings();
            applySettings();

            //Setup the Refresh-Thread.
            _refreshWorker = new RefreshWorker(_settings, file);
            _refreshThread = new Thread(_refreshWorker.update);

            //Start the Refresh-Thread.
            _refreshThread.Start();
        }

        //Function for applying the Settings to the Input Fields.
        private void applySettings()
        {
            //Set the text of the prefix/suffix input.
            prefixInput.Text = _settings.prefix;
            suffixInput.Text = _settings.suffix;

            //Set the value of the RefreshSlider.
            refreshSlider.Value = _settings.refreshSpeed;
            updateRefreshLabel();

            //Hide the TabSelector.
            tabSelector.Visible = false;
            refreshTabsButton.Visible = false;
            tabSelectorLabel.Visible = false;

            //Check which source is Selected, and check the Corresponding Radio-Box.
            switch (_settings.source)
            {
                case SongSource.SPOTIFY:
                    modeSelector_Spotify.Select();
                    break;
                case SongSource.IE:
                    modeSelector_InternetExplorer.Select();
                    //Show the TabSelector.
                    tabSelector.Visible = true;
                    refreshTabsButton.Visible = true;
                    tabSelectorLabel.Visible = true;
                    break;
            }
        }

        //Function for getting the Selected Source.
        private SongSource getSelectedSource()
        {
            //Check which Radio-Box is Selected, and return the Corresponding Source.
            if (modeSelector_Spotify.Checked)
                return SongSource.SPOTIFY;
            if (modeSelector_InternetExplorer.Checked)
                return SongSource.IE;

            return Settings.defaultValues().source;
        }

        //Function for Updating the Label of the Refresh-Slider.
        private void updateRefreshLabel()
        {
            //Set the text of the Refresh-Label.
            refreshLabel.Text = "Refresh-Rate: " + (0.5 * refreshSlider.Value) + " Second/s";
            //Center the Location of the Refresh-Label.
            refreshLabel.Location = new Point(((refreshSlider.Size.Width / 2) + refreshSlider.Location.X) - (refreshLabel.Size.Width / 2), refreshLabel.Location.Y);
        }

        //Function for Updation the Song-Preview.
        public static void updateSongPreview(string song)
        {
            instance.Invoke(new Action(()=> {
                instance.songPreview.Text = song;
            }));
        }

        //Function for Detecting if the Title-Bar is Clicked.
        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            _titleBarClicked = true;
            _lastCursorPosition = e.Location;
        }

        //Function for Detecting if the Title-Bar is Clicked.
        private void titleBar_MouseUp(object sender, MouseEventArgs e)
        {
            _titleBarClicked = false;
        }

        //Function for moving the Window.
        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            //If the Title-Bar is Clicked.
            if(_titleBarClicked)
            {
                //Move the Window.
                this.Location = new Point((this.Location.X - _lastCursorPosition.X) + e.X, (this.Location.Y - _lastCursorPosition.Y) + e.Y);
                this.Update();
            }
        }

        //Change the Close-Button Color on Hover.
        private void titleBar_Close_MouseEnter(object sender, EventArgs e)
        {
            titleBar_Close.BackColor = (Color)new ColorConverter().ConvertFromString("#c0392b");
        }

        //Change the Close-Button Color on Hover.
        private void titleBar_Close_MouseLeave(object sender, EventArgs e)
        {
            titleBar_Close.BackColor = (Color)new ColorConverter().ConvertFromString("#e74c3c");
        }

        //Exit the Application when the Close-Button is Clicked.
        private void titleBar_Close_MouseClick(object sender, MouseEventArgs e)
        {
            _refreshWorker.requestStop();
            _refreshThread.Abort();
            _refreshThread.Join();
            Application.Exit();
        }

        //Change the Minimize-Button Color on Hover.
        private void titleBar_Minimize_MouseEnter(object sender, EventArgs e)
        {
            titleBar_Minimize.BackColor = (Color)new ColorConverter().ConvertFromString("#2980b9");
        }

        //Change the Minimize-Button Color on Hover.
        private void titleBar_Minimize_MouseLeave(object sender, EventArgs e)
        {
            titleBar_Minimize.BackColor = (Color)new ColorConverter().ConvertFromString("#3498db");
        }

        //Minimize the Window if the Minimize-Button is Clicked.
        private void titleBar_Minimize_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Apply the Settings if the Apply-Button is Clicked.
        private void applyButton_Click(object sender, EventArgs e)
        {
            //Save the Settings to the File.
            _cm.saveSettings(_settings = new Settings(prefixInput.Text, suffixInput.Text, getSelectedSource(), refreshSlider.Value));
            //Update the Settings in the Refresh-Worker.
            _refreshWorker.updateSettings(_settings);
            //Apply the Settings to the Input-Fields.
            applySettings();
        }

        //Resets the Settings if the Reset-Button is Clicked.
        private void resetButton_Click(object sender, EventArgs e)
        {
            //Save the Default-Settings to the File.
            _cm.saveSettings(_settings = Settings.defaultValues());
            //Update the Settings in the Refresh-Worker.
            _refreshWorker.updateSettings(_settings);
            //Apply the Settings to the Input-Fields.
            applySettings();
        }

        //Update the Refresh-Label if the Refresh-Slider changes it's Value.
        private void refreshSlider_ValueChanged(object sender, EventArgs e)
        {
            updateRefreshLabel();
        }

        //Refresh the Tab-List when the Refresh-Button is Clicked.
        private void refreshTabsButton_Click(object sender, EventArgs e)
        {
            //Clear the current items.
            tabSelector.Items.Clear();
            //Get the all tabs from the TabManager and put then into the list.
            foreach(string tab in TabManager.getTabNames(getSelectedSource()))
            {
                tabSelector.Items.Add(tab);
            }
        }

        //Update the Selected tab in the Refresh-Worker.
        private void tabSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            _refreshWorker._selectedTab = tabSelector.SelectedIndex;
        }

        //Method for Displaying information about the Programm.
        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UsingSongGetter is a esay to use Programm, to get your Current Playing Song \n"
                          + "and Display it for example in your Livestream. \n\n"
                          + "Copyright(C) 2016  usingalex", "About", MessageBoxButtons.OK);
        }
    }
}