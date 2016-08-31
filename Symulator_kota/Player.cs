using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_kota {
    [Serializable]
    public class Player {
        public string Name {
            get;
            protected set;
        }
        public int Foodlevel {
            get;
            protected set;
        }

        public Player(string name) {
            Name = name;
            Foodlevel = 100;
        }


    }
}
