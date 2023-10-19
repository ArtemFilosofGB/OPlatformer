using System;

class Program
{
    static int playerX = 5; // начальная позиция героя по горизонтали
    static int playerY = 5; // начальная позиция героя по вертикали
    static bool isJumping = false; // флаг, указывающий, прыгает ли герой
    static int jumpHeight = 0; // текущая высота прыжка

    static bool isPlaying = true;

    static void Main()
    {
        Console.CursorVisible = false;


        while (isPlaying)
        {
            Console.Clear();
            DrawGameScreen();
            HandleInput();
            System.Threading.Thread.Sleep(20);
        }
        Console.Clear();
    }

    static void DrawGameScreen()
    {



        // Отображение локации (границы и платформы)
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"                O PLatform                   {playerX}-{playerY}");
        Console.WriteLine("##################################################");
        Console.WriteLine("#                                                #");
        Console.WriteLine("#                                                #");
        Console.WriteLine("#                       #####                    #");
        Console.WriteLine("#                                                #");
        Console.WriteLine("#                 ########                       #");
        Console.WriteLine("#                                                #");
        Console.WriteLine("#          ########                              #");
        Console.WriteLine("#                                                #");
        Console.WriteLine("##################################################");

        // Отображение героя
        Console.SetCursorPosition(playerX, playerY);
        Console.Write("O");

        // Обработка прыжка героя
        if (isJumping&& playerY<9)
        {
            jumpHeight++;
            if (jumpHeight > 10)
            {
                isJumping = false;
                jumpHeight = 0;
            }
        }
        else if (playerY < 10) // Если герой на платформе, но не на земле
        {
            jumpHeight--;
            if (jumpHeight < 0)
            {
                playerY++;
                jumpHeight = 0;
            }
        }
    }

    static void HandleInput()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            // Управление героем
            if (key == ConsoleKey.LeftArrow && playerX > 0)
            {
                playerX--;
            }
            else if (key == ConsoleKey.RightArrow && playerX < 50)
            {
                playerX++;
            }
            else if (key == ConsoleKey.DownArrow && playerY < 10)
            {
                playerY++;
            }
            else if (key == ConsoleKey.UpArrow && playerY > 0)
            {
                playerY--;
            }
            else if (key == ConsoleKey.Spacebar && !isJumping) // Герой может прыгнуть только, если он стоит на земле
            {
                isJumping = true;
            }
            else if (key == ConsoleKey.Escape) // Герой может прыгнуть только, если он стоит на земле
            {
                isPlaying = false;
            }
        }
    }
}
