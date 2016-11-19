using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

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
    class ConfigManager
    {

        private string _file;

        public ConfigManager(string path, string filename)
        {
            //Get the path of the Settings-File.
            _file = Path.Combine(path, filename);

            //Create the Settings-File if it Doesn't exists.
            if(!File.Exists(_file))
            {
                File.Create(_file).Close();
                saveSettings(Settings.defaultValues());
            }
        }

        //Function for saving the Settings to a File.
        public void saveSettings(Settings settings)
        {
            //Write the Settings to a MemoryStream.
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Settings));
            ser.WriteObject(stream, settings);

            //Get the Json-String from the Steam.
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string json = reader.ReadToEnd();

            //Write the Settings to a File.
            File.WriteAllText(@_file, json);
            reader.Close();
            stream.Close();
        }

        //Function for saving the Settings to a File.
        public Settings loadSettings()
        {
            //Read the Json-String form the File.
            string json = File.ReadAllText(@_file);

            //Write the Json-String to a MemoryStream.
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Settings));

            //Get the Settings-Object from the MemoryStream.
            Settings settings = (Settings)ser.ReadObject(stream);
            stream.Close();

            //Return the loaded Settings.
            return settings;
        }

    }
}
