using System;
using System.Collections.Generic;
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

        private string lastSong = "";

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
                if (!song.Equals(lastSong))
                {
                    lastSong = song;
                    File.WriteAllText(@_file, _settings.prefix + song + _settings.suffix);
                }
                Thread.Sleep((int)((0.5 * _settings.refreshSpeed) * 1000));
            }
        }

        private string getSong()
        {
            Random rd = new Random();
            return "" + rd.Next(1, 5);
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
