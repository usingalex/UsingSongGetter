using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UsingSongGetter
{
    class RefreshWorker
    {

        public int _selectedTab = -1;

        private volatile bool _shouldStop = false;
        private Settings _settings;
        private string _file;

        private string lastOutput = "";

        public RefreshWorker(Settings settings, string file)
        {
            _settings = settings;
            _file = file;
        }

        //Function for Updating the current song.
        public void update()
        {
            //While the thread is not Close Requested.
            while(!_shouldStop)
            {
                //Get the song, and add prefix and suffix.
                string song = getSong();
                string output = _settings.prefix + song + _settings.suffix;
                //If the current output is Different from the last, write it to the File.
                if (!output.Equals(lastOutput))
                {
                    lastOutput = output;
                    File.WriteAllText(@_file, output);
                }
                //Sleep for the selected interval.
                Thread.Sleep((int)((0.5 * _settings.refreshSpeed) * 1000));
            }
        }

        //Function for getting the Current song.
        private string getSong()
        {
            //Check which Source is selected.
            switch(_settings.source)
            {
                //If Spotify is selected.
                case SongSource.SPOTIFY:
                    //Go through all Processes.
                    foreach (Process process in Process.GetProcesses())
                    {
                        //If the process as a Window.
                        if(!String.IsNullOrEmpty(process.MainWindowTitle))
                        {
                            //If the process is called Spotify.
                            if(process.ProcessName.Equals("Spotify"))
                            {
                                //Return the title of the Spotify Window.
                                return process.MainWindowTitle;
                            }
                        }
                    }
                    return "Can't get Spotify Song.";
                //If InternetExplorer is selected.
                case SongSource.IE:
                    //Get all tabs from the TabManager.
                    string[] tabs = TabManager.getTabNames(_settings.source);
                    //If the selected tab is in the List.
                    if(_selectedTab >= 0 && (_selectedTab + 1) <= tabs.Length)
                    {
                        //Get the name of the selected tab.
                        string song = TabManager.getTabNames(_settings.source)[_selectedTab];

                        //Trim Names/Logos from start and end.
                        if(song.EndsWith(" - YouTube"))
                        {
                            song = song.TrimEnd(" - YouTube".ToCharArray());
                        } else if(song.StartsWith("▶ ")) {
                            song = song.TrimStart("▶ ".ToCharArray());
                        }

                        //Return the edited tab title.
                        return song;
                    }
                    return "Can't get IE Song.";
                default:
                    return "Can't get Song.";
            }
        }

        //Function for updating the Settings.
        public void updateSettings(Settings settings)
        {
            _settings = settings;
        }

        //Function for stopping the Thread.
        public void requestStop()
        {
            _shouldStop = true;
        }

    }
}
