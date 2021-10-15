using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Magiska_fabriken
{
    class Fabric
    {
        private int _woodInFactory;
        private int _ironInFactory;          
        private int _rubberInFactory;
        private int _redPaintInFactory;
        private int _screwsInFactory;
        public List<Material> MaterialsToSendToFabric;

        public Fabric()
        {
        }
        public void MaterialFromUser(List<int> inputMaterials)
        {
            _woodInFactory = inputMaterials[0];
            _ironInFactory = inputMaterials[1];
            _rubberInFactory = inputMaterials[2];
            _redPaintInFactory = inputMaterials[3];
            _screwsInFactory = inputMaterials[4];
            CheckMaterialAgainstBlueprints();
        }

        private void CheckMaterialAgainstBlueprints()
        {
            int topTotalMaterial = 0;
            int indexOfTopBlueprint = 0;
            foreach (var item in Blueprints._ListOfAllBlueprints)
            {
                if (item.WoodNeeded <= _woodInFactory && item.SteelNeeded <= _ironInFactory && item.PlasticNeeded <= _rubberInFactory && item.RedPaintNeeded <= _redPaintInFactory && item.ScrewNeeded <= _screwsInFactory)
                {
                    if (item.SumAllMaterialNeeded > topTotalMaterial)
                    {
                        topTotalMaterial = item.SumAllMaterialNeeded;
                        indexOfTopBlueprint = Blueprints._ListOfAllBlueprints.IndexOf(item);
                    }
                }
            }


            if (Blueprints._ListOfAllBlueprints[indexOfTopBlueprint].WoodNeeded <= _woodInFactory &&
                Blueprints._ListOfAllBlueprints[indexOfTopBlueprint].SteelNeeded <= _ironInFactory &&
                Blueprints._ListOfAllBlueprints[indexOfTopBlueprint].PlasticNeeded <= _rubberInFactory &&
                Blueprints._ListOfAllBlueprints[indexOfTopBlueprint].RedPaintNeeded <= _redPaintInFactory &&
                Blueprints._ListOfAllBlueprints[indexOfTopBlueprint].ScrewNeeded <= _screwsInFactory)
            {
                Console.WriteLine("item to create: {0}", Blueprints._ListOfAllBlueprints[indexOfTopBlueprint].Name);
                CreateItemFromRecipe(Blueprints._ListOfAllBlueprints[indexOfTopBlueprint]);
            }
            else
            {
                Console.WriteLine("Found noting to create ");
            }
        }
        private void CreateItemFromRecipe(Blueprints Blueprints)
        {
            Random timeRando = new();
            Console.Write("Gathering rescourses ");
            string dotdotdot = ".";
            for (int i = 0; i < 10; i++)
            {
                Console.Write(dotdotdot);
                if (i % 4 == 0) { Console.Write("\b\b\b   \b\b\b"); }  
                Thread.Sleep(timeRando.Next(50, 400));
            }
            Console.WriteLine();

            Console.WriteLine("Construction of {0} is starting ...", Blueprints.Name);
            Thread.Sleep(timeRando.Next(50, 400));
            Storage._Playeritems.Add(Blueprints);
            Console.WriteLine("Success!");
            Console.WriteLine("The {0} was added to your inventory.", Blueprints.Name);
            Thread.Sleep(700);
            Console.WriteLine("Checking if there anything else to make ..");

            _woodInFactory -= Blueprints.WoodNeeded; 
            _ironInFactory -= Blueprints.SteelNeeded;
            _rubberInFactory -= Blueprints.PlasticNeeded;
            _redPaintInFactory -= Blueprints.RedPaintNeeded;
            _screwsInFactory -= Blueprints.ScrewNeeded;
            CheckMaterialAgainstBlueprints(); 


            Console.WriteLine("Your remaining material has been returned.");
            Storage._listOfMaterialsAmount[0] += _woodInFactory;          
            Storage._listOfMaterialsAmount[1] += _ironInFactory;
            Storage._listOfMaterialsAmount[2] += _rubberInFactory;
            Storage._listOfMaterialsAmount[3] += _screwsInFactory;
            Storage._listOfMaterialsAmount[4] += _redPaintInFactory;
            _woodInFactory = 0;
            _ironInFactory = 0;
            _rubberInFactory = 0;
            _screwsInFactory = 0;   
            _redPaintInFactory = 0;


        }


    }
}



    

