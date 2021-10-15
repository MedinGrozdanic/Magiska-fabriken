using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magiska_fabriken
{
    public class Storage
    {
        public List<Material> listOfMaterials = new List<Material>();
        public static List<int> _listOfMaterialsAmount = new List<int>();
        public List<int> _materialsToSendNumber = new List<int>();
        public static List<Blueprints>_Playeritems = new();



        public Storage()
        {
            listOfMaterials = new List<Material>();
            _listOfMaterialsAmount = new List<int>();
            _materialsToSendNumber = new List<int>();
            Addlist();
        }

        public void Addlist()
        {
            for (int i = 0; i < Enum.GetNames(typeof(Material)).Length; i++)
            {
                int randomNumber = new Random().Next(2, 10);
                _listOfMaterialsAmount.Add(randomNumber);
                listOfMaterials.Add((Material)i);
                _materialsToSendNumber.Add(0);
            }
        }

        public void ShowLager()
        {
            Console.Clear();
            Console.WriteLine("The storage contains the following materials;  ");
            for (int i = 0; i < listOfMaterials.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {listOfMaterials[i],10} -Amount: {_listOfMaterialsAmount[i]}");
            }
            if (_Playeritems.Count > 0)
            {
                Console.WriteLine("You own following products: ");
                for (int i = 0; i < _Playeritems.Count; i++)
                {
                    Console.WriteLine($" - {_Playeritems[i].Name}");
                }
                Console.WriteLine("");
            }

        }   

        public List<int> MaterialFromStorageToFactory()
        {
            Console.WriteLine("");
            bool isDone = false;
            string sentMaterialsText = "";
            while(isDone == false)
            {
                ShowLager();
                Console.Write(sentMaterialsText);
                for (int r = 0; r < _materialsToSendNumber.Count; r++)
                {
                    if (_materialsToSendNumber[r] > 0)
                    {
                        Console.WriteLine($" - {listOfMaterials[r],10} -Amount: {_materialsToSendNumber[r]}");
                    }

                }

                Console.WriteLine("\nWhat material do you want to send to the factory?\nUse numbers to pick materials\nPress another key to send the materials to the fabric\n");


                var userInput = Console.ReadKey();
                if (char.IsDigit(userInput.KeyChar))
                {
                    int inputkey = int.Parse(userInput.KeyChar.ToString());
                    inputkey --;
                    if (inputkey < _listOfMaterialsAmount.Count)
                    {
                        if (_listOfMaterialsAmount[inputkey] > 0)
                        {
                            _listOfMaterialsAmount[inputkey] = _listOfMaterialsAmount[inputkey] - 1;
                            _materialsToSendNumber[inputkey]++;

                            sentMaterialsText = "\nMaterials you want to send in is:\n";
                        }
                        else
                        {
                            Console.WriteLine($"{(Material)inputkey} is out of stock. Press enter to continue.");
                            Console.ReadKey();
                        }

                    }
                }
                else
                {
                    Console.Clear();

                    isDone = true;
                    
                }
            }

            
        }


    }  



}



     




