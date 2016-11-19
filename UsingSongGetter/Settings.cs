using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

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

        public Settings(string prefix, string suffix, SongSource source, int refreshSpeed)
        {
            this.prefix = prefix;
            this.suffix = suffix;
            this.source = source;
            this.refreshSpeed = refreshSpeed;
        }

        //Function for getting the Default Settings.
        public static Settings defaultValues()
        {
            return new Settings("", "", SongSource.SPOTIFY, 5);
        }

    }
}
