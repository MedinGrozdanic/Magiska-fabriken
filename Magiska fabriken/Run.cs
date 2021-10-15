using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magiska_fabriken
{
    class Run
    {

        private Fabric myFabric = new();
        private Storage myStorage = new();
         
        public Run()
        {

        }

        public void run()
        {
            Blueprints.CreateBlueprints();
            while (true)
            {
                Console.WriteLine("Welcome to the Magical Factory!");
                myStorage.ShowLager();
                
            }

        }
    }
}
