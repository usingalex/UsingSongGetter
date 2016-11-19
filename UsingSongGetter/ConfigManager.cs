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
            _file = Path.Combine(path, filename);

            if(!File.Exists(_file))
            {
                File.Create(_file).Close();
                saveSettings(Settings.defaultValues());
            }
        }

        public void saveSettings(Settings settings)
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Settings));
            ser.WriteObject(stream, settings);

            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string json = reader.ReadToEnd();

            File.WriteAllText(@_file, json);
            reader.Close();
            stream.Close();

        }

        public Settings loadSettings()
        {
            string json = File.ReadAllText(@_file);

            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Settings));

            Settings settings = (Settings)ser.ReadObject(stream);
            stream.Close();

            return settings;
        }

    }
}
