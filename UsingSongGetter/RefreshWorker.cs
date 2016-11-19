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

        private volatile bool _shouldStop = false;
        private Settings _settings;
        private string _file;

        private string lastOutput = "";

        public RefreshWorker(Settings settings, string file)
        {
            _settings = settings;
            _file = file;
        }

        public void update()
        {
            while(!_shouldStop)
            {
                string song = getSong();
                string output = _settings.prefix + song + _settings.suffix;
                if (!output.Equals(lastOutput))
                {
                    lastOutput = output;
                    File.WriteAllText(@_file, output);
                }
                Thread.Sleep((int)((0.5 * _settings.refreshSpeed) * 1000));
            }
        }

        private string getSong()
        {
            switch(_settings.source)
            {
                case SongSource.SPOTIFY:
                    foreach(Process process in Process.GetProcesses())
                    {
                        if(!String.IsNullOrEmpty(process.MainWindowTitle))
                        {
                            if(process.ProcessName.Equals("Spotify"))
                            {
                                return process.MainWindowTitle;
                            }
                        }
                    }
                    return "Can't get Spotify Song.";
                default:
                    return "Can't get Song.";
            }
        }

        public void updateSettings(Settings settings)
        {
            _settings = settings;
        }

        public void requestStop()
        {
            _shouldStop = true;
        }

    }
}
