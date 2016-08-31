using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Symulator_kota {
    [Serializable]
    public class SaveData {
        public string pathfile;
        public Player player;
        public List<object> personList;

        protected SaveData() { }
        public SaveData(GlobalWorld world) {
            
            player = world.player;
            personList = world.personList;
            pathfile = Program.path + "save.dat";
        }



        public void SaveToFile() {
            BinaryFormatter writer = new BinaryFormatter();
            using(FileStream file = new FileStream(pathfile,FileMode.Create,FileAccess.Write)) {
                writer.Serialize(file, this);
            }
        }

        public static SaveData loadFromFile() {
            string pathfile = Program.path + "save.dat";
            BinaryFormatter writer = new BinaryFormatter();
            using (FileStream file = new FileStream(pathfile, FileMode.Open, FileAccess.Read)) {
                return (SaveData) writer.Deserialize(file);
            }
        }
    }
}
