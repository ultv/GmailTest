using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace GmailTest
{
    [DataContract]
    public class ConfigReader
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Pass { get; set; }
        [DataMember]        
        public string[] Uri { get; set; }
        [DataMember]
        public string BaseUrl { get; set; }
        [DataMember]
        public string SearchText { get; set; }

        public ConfigReader(string fileName)
        {
            
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ConfigReader));
                ConfigReader data = (ConfigReader)jsonFormatter.ReadObject(fs);

                Login = data.Login;
                Pass = data.Pass;
                Uri = data.Uri;
                BaseUrl = data.BaseUrl;
                SearchText = data.SearchText;
            }
        }            
    }
}
