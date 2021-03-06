﻿using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SpotifyAPI.Local;

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
    class RefreshWorker
    {

        public int _selectedTab = -1;

        private volatile bool _shouldStop = false;
        private Settings _settings;
        private string _file;
        private SpotifyLocalAPI _spotify;

        private string lastOutput = "";

        public RefreshWorker(Settings settings, string file)
        {
            _settings = settings;
            _file = file;

            _spotify = new SpotifyLocalAPI();
            _spotify.Connect();
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
                    MainWindow.updateSongPreview(song);
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
            switch (_settings.source)
            {
                //If Spotify is selected.
                case SongSource.SPOTIFY:
                    //Check if Spotify is Running.
                    if(SpotifyLocalAPI.IsSpotifyRunning())
                    {
                        //Check if Spotify is Connected.
                        if(_spotify.Connect())
                        {
                            //Check if a Song is playing.
                            if (_spotify.GetStatus().Playing)
                            {
                                //Return the name of the Playing Song.
                                return _spotify.GetStatus().Track.TrackResource.Name;
                            }
                        }
                    }
                    return _settings.invalidSongMessage;
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
                    return _settings.invalidSongMessage;
                default:
                    return _settings.invalidSongMessage;
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
