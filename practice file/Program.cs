using System;

namespace Cardinal_Cordinales_Roses;

class Thisobject
{

    public const int x = 0, y = 0, z = 0;
    public static int px = 0, Py = 0, pz = 0;
    public static float Aritmetic_positionx = (int)0f, Aritmetic_posotiony = (int)0f;


    public static void Main(object cardinal_Cord)
    {
        while (true)
        {
            for (int i = 0; i < 40 + 1; i++)
            {
                if (i % 4 == 0)
                {
                    Console.WriteLine($"Cordenadas {Thisobject.Aritmetic_positionx} | {Thisobject.Aritmetic_posotiony}");
                    i = 0;
                }
            }
            Console.WriteLine("W para subir, S para bajar, D > < A");
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true);

                    if (tecla.Key == ConsoleKey.W)
                    {
                        Thisobject.Aritmetic_posotiony += 1f;
                    }
                    else if (tecla.Key == ConsoleKey.S)
                    {
                        Thisobject.Aritmetic_posotiony -= 1f;
                    }
                    else if (tecla.Key == ConsoleKey.D)
                    {
                        Thisobject.Aritmetic_positionx += 1f;
                    }
                    else if (tecla.Key == ConsoleKey.A)
                    {
                        Thisobject.Aritmetic_positionx -= 1f;
                    }
                }
            }
        }

    }
}

