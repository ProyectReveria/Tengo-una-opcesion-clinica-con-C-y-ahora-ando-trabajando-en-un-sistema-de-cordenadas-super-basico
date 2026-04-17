using System;

namespace Cardinal_Cordinales_Roses;

class Thisobject
{
    //Puntos flotantes dentro de los decimales
    public static Random RNG = new Random();
    public static int puntuacion = 0;
    public const int oofSetx = 9, oofsety = 9; 
    public static double Aritmetic_positionx = 0f, Aritmetic_posotiony = 0f, Aritmetic_positionz = 0;
    //IA
    public static bool IA_Active = true;
    public static double IA_XPosition = 0f, IA_YPosition = 0f, IA_Zpositoon = 0f;
    public static int IApx , IApy, IApz;
    public static int VIApx, VIApy, VIApz;

    //puntos exactos
    public static int px , py , pz;

    public static void Vupdate_Ia_PRecisePoint(int x,int y , int z)
    {
        {
            VIApx = (int)Thisobject.IA_XPosition + Thisobject.oofSetx;
            VIApy = (int)Thisobject.IA_YPosition + Thisobject.oofsety;
            VIApz = (int)Thisobject.IA_Zpositoon;

            if (VIApx < oofSetx)
            {
                VIApx = oofSetx;
            }
            else if (VIApy < oofsety)
            {
                VIApy = oofsety;
            }
        }
    }

    public static void Update_IA_PrecisePoint(double x,double y,double z)
    {
        IApx = (int)Thisobject.IA_XPosition + Thisobject.oofSetx;
        IApy = (int)Thisobject.IA_YPosition + Thisobject.oofsety;
        IApz = (int)Thisobject.IA_Zpositoon;

        if (IApx < oofSetx)
        {
            IApx = oofSetx;
        }
        else if (IApy < oofsety)
        {
            IApy = oofsety;
        }
    }

    public static void UpdateCordinates_PrecisePoint(double x, double y, double z)
    {
        px = (int)Thisobject.Aritmetic_positionx + Thisobject.oofSetx;
        py = (int)Thisobject.Aritmetic_posotiony + Thisobject.oofsety;
        pz = (int)Math.Ceiling(Thisobject.Aritmetic_positionz) + 100;
        if (px < oofSetx)
        {
            px = oofSetx;
        }
        else if (py < oofsety)
        {
            pz = oofsety;
        }
    }

    //Calculos Aritmeticos 
    public static double Aritmetic_Radio(double x, double y)
    {
        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)); 
    }



    public static void Main()
    {

        Thisobject.Aritmetic_positionx = Thisobject.RNG.Next(1,Thisobject.oofSetx);
        Thisobject.Aritmetic_posotiony = Thisobject.RNG.Next(1, Thisobject.oofsety); 

        Thisobject.IA_XPosition = Thisobject.RNG.Next(2, Thisobject.oofSetx); 
        Thisobject.IA_YPosition = Thisobject.RNG.Next(1, Thisobject.oofsety); 

        UpdateCordinates_PrecisePoint(Aritmetic_positionx, Aritmetic_posotiony, Aritmetic_positionz);
        Update_IA_PrecisePoint(IA_XPosition, IA_YPosition, IA_Zpositoon);

        Console.Clear(); 
        Console.SetCursorPosition(px, py); 
        Console.Write("0");
        Console.SetCursorPosition(IApx, IApy); 
        Console.Write("2");

            while (true)
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true);

                    if (tecla.Key == ConsoleKey.W)
                    {
                        Thisobject.Aritmetic_posotiony -= 1f;
                        UpdateCordinates_PrecisePoint (Thisobject.Aritmetic_positionx, Thisobject.Aritmetic_posotiony,Thisobject.Aritmetic_positionz);
                    Thisobject.Aritmetic_positionz = Aritmetic_Radio(Thisobject.Aritmetic_positionx, Thisobject.Aritmetic_posotiony); 
                    Console.SetCursorPosition(px, py);
                    Console.Write("0");
                    Thisobject.puntuacion += 1; 
                    //IALOGIC CENTER
                    Console.SetCursorPosition(VIApx, VIApy);
                    Console.Write(" ");
                    Vupdate_Ia_PRecisePoint(IApx, IApy, IApz);
                    if (IApx > px)
                    {
                        Thisobject.IA_XPosition -= 1;
                    }
                    else if (IApy > py)
                    {
                        Thisobject.IA_YPosition -= 1;
                    }

                    if (IApx < px)
                    {
                        Thisobject.IA_XPosition += 1;
                    }
                    else if (IApy < py)
                    {
                        Thisobject.IA_YPosition += 1;
                    }


                    Update_IA_PrecisePoint(IApx, IApy, IApz);
                    Console.SetCursorPosition(IApx, IApy);
                    Console.Write("2");
                    Update_IA_PrecisePoint(IApx, IApy, IApz);
                    Console.SetCursorPosition (VIApx, VIApy);
                    Console.Write(" ");                     
                    Console.SetCursorPosition(IApx, IApy);
                    Console.Write("2");


                }
                    else if (tecla.Key == ConsoleKey.S)
                    {
                        Thisobject.Aritmetic_posotiony += 1f;
                    UpdateCordinates_PrecisePoint(Thisobject.Aritmetic_positionx, Thisobject.Aritmetic_posotiony, Thisobject.Aritmetic_positionz);
                    Thisobject.Aritmetic_positionz = Aritmetic_Radio(Thisobject.Aritmetic_positionx, Thisobject.Aritmetic_posotiony);
                    Console.SetCursorPosition(px, py);
                    Console.Write("0");
                    Thisobject.puntuacion += 1;
                    Console.SetCursorPosition(VIApx, VIApy);
                    Console.Write(" ");
                    Vupdate_Ia_PRecisePoint(IApx, IApy, IApz);
                    if (IApx > px)
                    {
                        Thisobject.IA_XPosition -= 1;
                    }
                    else if (IApy > py)
                    {
                        Thisobject.IA_YPosition -= 1;
                    }

                    if (IApx < px)
                    {
                        Thisobject.IA_XPosition += 1;
                    }
                    else if (IApy < py)
                    {
                        Thisobject.IA_YPosition += 1;
                    }


                    Update_IA_PrecisePoint(IApx, IApy, IApz);
                    Console.SetCursorPosition(IApx, IApy);
                    Console.Write("2");

                }
                else if (tecla.Key == ConsoleKey.D)
                    {
                        Thisobject.Aritmetic_positionx += 1f;
                    UpdateCordinates_PrecisePoint(Thisobject.Aritmetic_positionx, Thisobject.Aritmetic_posotiony, Thisobject.Aritmetic_positionz);
                    Thisobject.Aritmetic_positionz = Aritmetic_Radio(Thisobject.Aritmetic_positionx, Thisobject.Aritmetic_posotiony);
                    Console.SetCursorPosition(px, py);
                    Console.Write("0");
                    Thisobject.puntuacion += 1;
                    Console.SetCursorPosition(VIApx, VIApy);
                    Console.Write(" ");
                    Vupdate_Ia_PRecisePoint(IApx, IApy, IApz);
                    if (IApx > px)
                    {
                        Thisobject.IA_XPosition -= 1;
                    }
                    else if (IApy > py)
                    {
                        Thisobject.IA_YPosition -= 1;
                    }

                    if (IApx < px)
                    {
                        Thisobject.IA_XPosition += 1;
                    }
                    else if (IApy < py)
                    {
                        Thisobject.IA_YPosition += 1;
                    }


                    Update_IA_PrecisePoint(IApx, IApy, IApz);
                    Console.SetCursorPosition(IApx, IApy);
                    Console.Write("2");

                }
                else if (tecla.Key == ConsoleKey.A)
                    {
                        Thisobject.Aritmetic_positionx -= 1f;
                    UpdateCordinates_PrecisePoint(Thisobject.Aritmetic_positionx, Thisobject.Aritmetic_posotiony, Thisobject.Aritmetic_positionz);
                    Thisobject.Aritmetic_positionz = Aritmetic_Radio(Thisobject.Aritmetic_positionx, Thisobject.Aritmetic_posotiony);
                    Console.SetCursorPosition(px, py);
                    Console.Write("0");
                    Thisobject.puntuacion += 1;
                    Console.SetCursorPosition(VIApx, VIApy);
                    Console.Write(" ");
                    Vupdate_Ia_PRecisePoint(IApx, IApy, IApz);
                    if (IApx > px)
                    {
                        Thisobject.IA_XPosition -= 1;
                    }
                    else if (IApy > py)
                    {
                        Thisobject.IA_YPosition -= 1;
                    }

                    if (IApx < px)
                    {
                        Thisobject.IA_XPosition += 1;
                    }
                    else if (IApy < py)
                    {
                        Thisobject.IA_YPosition += 1;
                    }


                    Update_IA_PrecisePoint(IApx, IApy, IApz);
                    Console.SetCursorPosition(IApx, IApy);
                    Console.Write("2");


                }
                else if (tecla.Key == ConsoleKey.Spacebar)
                {
                    Console.SetCursorPosition(px, py);
                    Console.Write("1");
                    Console.SetCursorPosition(IApx, IApz);
                    Console.Write("2");
                }
                if (px == IApx && py == IApy)
                {
                    Console.Clear();
                    Console.WriteLine("Game over, execute off");
                    Console.WriteLine($"Puntiacion: {Thisobject.puntuacion}"); 
                    break;
                }

            }
        }

    }
}

