using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

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
