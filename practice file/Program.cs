using System;

namespace Cardinal_Cordinales_Roses; 
public class Input_Control
{

}

class Thisobject : Input_Control
{

    public const int x = 0, y = 0, z = 0;
    public static int px = 0, Py = 0, pz = 0;
    public static float Aritmetic_positionx = (int)0f, Aritmetic_posotiony = (int)0f; 


    public static void Main(object cardinal_Cord)
    {
        Console.WriteLine("W para subir, S para bajar, D > < A"); 
        while (true) {

            if (Console.KeyAvailable) {
                ConsoleKeyInfo tecla = Console.ReadKey(true);

                if( tecla.Key == ConsoleKey.W)
                {
                    Thisobject.Aritmetic_positionx += 1f; 
                }
            }
        }
    }

}
