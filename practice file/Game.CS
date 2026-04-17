using System;


namespace Game_Class;

class Math_Alogirth
{
    public static Random RNG = new Random(); 

}
class ScreenCite
{

    public const int Map_Limitx = 16, Map_Limity = 16;
    public static int StarterPointAx = 16, StarterPointAy = 16;
    public static int StarterPointBx = 16, StarterPointBy = 16;
    public static int _HitBox_PlayerLimit_on_X = 15, _HitBox_PlayerLimit_On_Y = 15; 
}

public static class GameManager
{
    
    public static bool Game_Active = false;
    public static bool Game_oveer = false;

 

    public static void Game_UI()
    {
        {
            {
                Console.WriteLine("Bienvenido, Esto es un prototipo tecnico hice de forma simple");
                Console.WriteLine("Para iniciar Precione 1, para salir precione 2. Cualquier otra cosa efectuara la segunda opcion");
                Console.WriteLine("Una ves pierdas la partida se da la puntuacion y debe reiniciar el programa");
                string Respuesta = Console.ReadLine();

                if (Respuesta == "1")
                {
                    Game_Active = true;
                    Console.Clear();
                }
                else if (Respuesta == "2")
                {
                    Console.WriteLine("Programa Detenido, para iniciar Reinicie");
                }
                else
                {
                    Console.WriteLine("no es un opcion valida");
                    GameManager.Game_UI();
                }
            }
        }
    }
    public static void Game_Over_UI()
    {

        if (GameManager.Game_oveer == true)
        {
            Console.Clear();
            Console.WriteLine("Game over");
            Console.WriteLine($"Puntuacion {Player.Points}");
            Console.WriteLine("Close System");
        }
    }

}
class Player : ScreenCite
{
    public static int Px = 8, Py = 8;
    public static int Px_old, Py_old;
    
    public static int Points = 0;
    ConsoleKeyInfo key = Console.ReadKey(true);

    //Controles
    
    public enum controlManager
    {
        up,
        down,
        left,
        right,
        none,
    }

    public static void Control()
    {
        Px_old = Px;
        Py_old = Py;
        controlManager direccional_Control = controlManager.none;
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.W: direccional_Control = controlManager.up; Points++ ; break;
            case ConsoleKey.S: direccional_Control = controlManager.down; Points++; break;
            case ConsoleKey.D: direccional_Control = controlManager.left; Points++; break;
            case ConsoleKey.A: direccional_Control = controlManager.right; Points++;  break;
        }

        switch (direccional_Control)
        {
            case controlManager.up: Py--;break;
            case controlManager.down: Py++; break;
            case controlManager.left: Px++; break;
            case controlManager.right: Px--; break;
        }

        if (Px  == Map_Limitx) {
            Px = _HitBox_PlayerLimit_on_X;
        }

        if (Py == Map_Limity) {
            Py = _HitBox_PlayerLimit_On_Y ;
        }



        if (Px < 1)
        {
            Px = 1;  
        }

        if (Py < 1)
        {
            Py = 1; 
        }

    }
}




class Enemy_IA : Player
{
    public static int _IA_Position_X = Math_Alogirth.RNG.Next(0, ScreenCite.Map_Limitx - 1), _IA_Position_Y = Math_Alogirth.RNG.Next(0, ScreenCite.Map_Limity - 1);
    public static int _IA_Position_X_old, _IA_Position_Y_old; 

    public static void Enemy_IA_Controler()
    {
        _IA_Position_X_old = _IA_Position_X;
        _IA_Position_Y_old = _IA_Position_Y;
        if (_IA_Position_X < Px)
        {
            _IA_Position_X++;
            if (_IA_Position_X == _HitBox_PlayerLimit_on_X)
            {
                _IA_Position_X++;
            }
        }
        else if (_IA_Position_X > Px)
        {
            _IA_Position_X--;
            if (_IA_Position_X == _HitBox_PlayerLimit_on_X)
            {
                _IA_Position_X--;
            }
        }
        else if (_IA_Position_Y < Py)
        {
            _IA_Position_Y++;
            if (_IA_Position_Y == _HitBox_PlayerLimit_on_X)
            {
                _IA_Position_Y++;
            }
        }

        else if (_IA_Position_Y > Py)
        {
            _IA_Position_Y--;
            if (_IA_Position_Y == _HitBox_PlayerLimit_on_X)
            {
                _IA_Position_Y--;
            }
        }

        if (_IA_Position_X == Px && _IA_Position_Y == Py)
        {
            GameManager.Game_Active = false;
            GameManager.Game_oveer = true;
            Console.SetCursorPosition(_IA_Position_Y, _IA_Position_X);
            Console.Write(" "); 
            GameManager.Game_Over_UI(); 

        }

        

    }

    class Game : ScreenCite
    {
        public static void Main()
        {
            GameManager.Game_UI();


            if (GameManager.Game_Active == true)
            {
                for (int A = 0; A < StarterPointAx + 1; A++)
                {
                    Console.SetCursorPosition(A, 0);
                    Console.Write("x");
                }
                for (int A2 = 0; A2 < StarterPointAy + 1; A2++)
                {
                    Console.SetCursorPosition(0, A2);
                    Console.Write("x");
                }

                for (int B = 0; B < StarterPointBx + 1; B++)
                {
                    Console.SetCursorPosition(ScreenCite.StarterPointAx, B);
                    Console.Write("x");
                }
                for (int B2 = 0; B2 < StarterPointBy + 1; B2++)
                {
                    Console.SetCursorPosition(B2, StarterPointAy);
                    Console.Write("x");
                }


            }

            while (GameManager.Game_Active == true)
            {

                Player.Control();
                Console.SetCursorPosition(Player.Px_old, Py_old);
                Console.Write(" "); 
                Console.SetCursorPosition(Player.Px, Player.Py);
                Console.Write("0"); //Player
                Enemy_IA_Controler();
                Console.SetCursorPosition(Enemy_IA._IA_Position_X_old, Enemy_IA._IA_Position_Y_old);
                Console.Write(" ");
                Console.SetCursorPosition(Enemy_IA._IA_Position_X,Enemy_IA._IA_Position_Y);
                Console.Write("2"); //Enemy
                Console.SetCursorPosition(0, 17);
                Console.WriteLine($"Points: {Player.Points}");


            }
        }

    }
}
        


