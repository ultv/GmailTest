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
    public class Hub
    {
        [DataMember]
        public string Uri;
        [DataMember]
        public string Capabilities;
    }

    [DataContract]
    public class ConfigReader
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Pass { get; set; }                
        [DataMember]        
        public Hub [] Node { get; set; }
        [DataMember]
        public string BaseUrl { get; set; }
        [DataMember]
        public string SearchKey { get; set; }
        [DataMember]
        public string SearchText { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Message { get; set; }

        public ConfigReader(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {

                
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ConfigReader));
                    ConfigReader data = (ConfigReader)jsonFormatter.ReadObject(fs);                    

                    Login = data.Login;
                    Pass = data.Pass;
                    Node = data.Node;
                    BaseUrl = data.BaseUrl;
                    SearchKey = data.SearchKey;
                    SearchText = data.SearchText;
                    Subject = data.Subject;
                    Message = data.Message;
                }                                             
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Поместите файл config.json в директорию /bin/Debug/");
            }
        }            
    }
}
