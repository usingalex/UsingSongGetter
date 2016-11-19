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

namespace UsingSongGetter
{
    public partial class MainWindow : Form
    {

        private bool _titleBarClicked = false;
        private Point _lastCursorPosition;

        private ConfigManager _cm;
        private RefreshWorker _refreshWorker;
        private Thread _refreshThread;
        private Settings _settings;

        public MainWindow()
        {
            InitializeComponent();

            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UsingSongGetter");
            string file = Path.Combine(dir, "currentSong.txt");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (!File.Exists(file))
            {
                File.Create(file).Close();
            }

            _cm = new ConfigManager(dir, "settings.cfg");
            _settings = _cm.loadSettings();
            applySettings();

            _refreshWorker = new RefreshWorker(_settings, file);
            _refreshThread = new Thread(_refreshWorker.update);

            _refreshThread.Start();
        }

        private void applySettings()
        {
            prefixInput.Text = _settings.prefix;
            suffixInput.Text = _settings.suffix;
            refreshSlider.Value = _settings.refreshSpeed;

            updateRefreshLabel();

            switch (_settings.source)
            {
                case SongSource.SPOTIFY:
                    modeSelector_Spotify.Select();
                    break;
                case SongSource.IE:
                    modeSelector_InternetExplorer.Select();
                    break;
            }
        }

        private SongSource getSelectedSource()
        {
            if (modeSelector_Spotify.Checked)
                return SongSource.SPOTIFY;
            if (modeSelector_InternetExplorer.Checked)
                return SongSource.IE;

            return Settings.defaultValues().source;
        }

        private void updateRefreshLabel()
        {
            refreshLabel.Text = "Refresh-Rate: " + (0.5 * refreshSlider.Value) + " Second/s";
            refreshLabel.Location = new Point(((refreshSlider.Size.Width / 2) + refreshSlider.Location.X) - (refreshLabel.Size.Width / 2), refreshLabel.Location.Y);
        }

        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            _titleBarClicked = true;
            _lastCursorPosition = e.Location;
        }

        private void titleBar_MouseUp(object sender, MouseEventArgs e)
        {
            _titleBarClicked = false;
        }

        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if(_titleBarClicked)
            {
                this.Location = new Point((this.Location.X - _lastCursorPosition.X) + e.X, (this.Location.Y - _lastCursorPosition.Y) + e.Y);
                this.Update();
            }
        }

        private void titleBar_Close_MouseEnter(object sender, EventArgs e)
        {
            titleBar_Close.BackColor = (Color)new ColorConverter().ConvertFromString("#c0392b");
        }

        private void titleBar_Close_MouseLeave(object sender, EventArgs e)
        {
            titleBar_Close.BackColor = (Color)new ColorConverter().ConvertFromString("#e74c3c");
        }

        private void titleBar_Close_MouseClick(object sender, MouseEventArgs e)
        {
            _refreshWorker.requestStop();
            _refreshThread.Abort();
            _refreshThread.Join();
            Application.Exit();
        }

        private void titleBar_Minimize_MouseEnter(object sender, EventArgs e)
        {
            titleBar_Minimize.BackColor = (Color)new ColorConverter().ConvertFromString("#2980b9");
        }

        private void titleBar_Minimize_MouseLeave(object sender, EventArgs e)
        {
            titleBar_Minimize.BackColor = (Color)new ColorConverter().ConvertFromString("#3498db");
        }

        private void titleBar_Minimize_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            _cm.saveSettings(_settings = new Settings(prefixInput.Text, suffixInput.Text, getSelectedSource(), refreshSlider.Value));
            _refreshWorker.updateSettings(_settings);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _cm.saveSettings(_settings = Settings.defaultValues());
            _refreshWorker.updateSettings(_settings);
            applySettings();
        }

        private void refreshSlider_ValueChanged(object sender, EventArgs e)
        {
            updateRefreshLabel();
        }
    }
}
