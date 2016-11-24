using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

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
    [DataContract]
    class Settings
    {
        [DataMember]
        public string prefix;

        [DataMember]
        public string suffix;

        [DataMember]
        public SongSource source;

        [DataMember]
        public int refreshSpeed;

        [DataMember]
        public string invalidSongMessage;

        public Settings(string prefix, string suffix, SongSource source, int refreshSpeed, string invalidSongMessage)
        {
            this.prefix = prefix;
            this.suffix = suffix;
            this.source = source;
            this.refreshSpeed = refreshSpeed;
            this.invalidSongMessage = invalidSongMessage;
        }

        //Function for Checking all values of the Given settings Object. If they are Invalid, set them to the Default values.
        public static Settings validateSettings(Settings settings)
        {
            if (settings.prefix == null)
                settings.prefix = defaultValues().prefix;

            if (settings.suffix == null)
                settings.suffix = defaultValues().suffix;

            if (settings.invalidSongMessage == null)
                settings.invalidSongMessage = defaultValues().invalidSongMessage;

            return settings;
        }

        //Function for getting the Default Settings.
        public static Settings defaultValues()
        {
            return new Settings("", "", SongSource.SPOTIFY, 5, "Can't get Song");
        }

    }
}
