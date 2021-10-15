using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magiska_fabriken
{
    class Blueprints
    {

        public static List<Blueprints> _ListOfAllBlueprints = new List<Blueprints>();


        public string Name { get; }
        public int WoodNeeded { get; }
        public int SteelNeeded { get; }
        public int PlasticNeeded { get; }
        public int RedPaintNeeded { get; }
        public int ScrewNeeded { get; }
        public int SumAllMaterialNeeded { get; }


        public Blueprints(string name, int wood, int iron, int rubber, int rPaint, int screws) 
                                                                                                                                                               
        {                                                           
            Name = name;
            WoodNeeded = wood;
            SteelNeeded = iron;
            PlasticNeeded = rubber;
            RedPaintNeeded = rPaint;
            ScrewNeeded = screws;
            SumAllMaterialNeeded = WoodNeeded + SteelNeeded + PlasticNeeded + RedPaintNeeded + ScrewNeeded;
            _ListOfAllBlueprints.Add(this);
        }
        public static void CreateBlueprints() 
        {
            Blueprints axe = new Blueprints("axe", 2, 1, 0, 1, 0);
            Blueprints plunger = new Blueprints("plunger", 1, 0, 1, 1, 0);
            Blueprints chopsticks = new Blueprints("chopsticks", 2, 0, 0, 0, 0);
            Blueprints bikecycle = new Blueprints("bikecycle", 0, 3, 1, 1, 2);
        }
        public static void ShowListOfBlueprints() 
        {
            Console.WriteLine($"{ "Name",-10} { "Wood",-5} {"Iron",-5} {"Rubber"}");
            Console.WriteLine("----------------------------");
            foreach (var item in _ListOfAllBlueprints)
            {
                Console.WriteLine($"{ item.Name,-10} { item.WoodNeeded,-5} { item.SteelNeeded,-5} {item.PlasticNeeded}");
            }
        }
    }
}


    


