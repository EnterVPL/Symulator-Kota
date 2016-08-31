using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Symulator_kota {
    class Program {
        public static string path = AppDomain.CurrentDomain.BaseDirectory;
        static GlobalWorld world;

        static void Main(string[] args) {
            bool saveData = File.Exists(path + "save.dat");

            Console.WriteLine("Witaj w grze \"Symulator Kota\"!");
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1.Stwórz nową grę");
            Console.WriteLine("2.Wczytaj");
            Console.WriteLine("3.Wyjdź");
            int value;
            while (true) {
                if (!int.TryParse(Console.ReadLine(), out value)) continue;

                bool isEnd = true;
                switch (value) {
                    case 1:
                        NewGame();
                        break;
                    case 2:
                        LoadGame();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa wartość.");
                        isEnd = false;
                        break;
                }
                if (isEnd) break;
            }

            //Wczytywanie lokacji
            //pętla działania
            Console.ReadKey();
        }
        static void NewGame() {
            world = new GlobalWorld();
            Console.Clear();
            Console.Write("Podaj nazwę swojego pupilka: ");
            string pupilName = Console.ReadLine();
            Player player = new Player(pupilName);
            world.player = player;
            new SaveData(world).SaveToFile();


        }

        static void LoadGame() {
            SaveData data = SaveData.loadFromFile();
            world = new GlobalWorld();
            world.player = data.player;
            world.personList = data.personList;
        }


    }
}
