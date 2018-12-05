using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Coursa4Library1
{
    public class Xml
    {
        public List<Person> DeSerializer(string FileOpen, List<Person> HumanTreat)
        {

            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));
            using (FileStream fs = new FileStream(FileOpen, FileMode.OpenOrCreate))
            {
                HumanTreat = (List<Person>)formatter.Deserialize(fs);
            }
            return HumanTreat;
        }
        public void Serializer(string FileSave, List<Person> HumanTreat)
        {
            XmlSerializer formatter2 = new XmlSerializer(typeof(List<Person>));
            File.Delete(FileSave);
            using (FileStream fs = new FileStream(FileSave, FileMode.OpenOrCreate))
            {
                formatter2.Serialize(fs, HumanTreat);
            }
        }
    }
}
