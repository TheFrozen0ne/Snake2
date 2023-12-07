using System;

class SnakeGameMenu
{
    static void Main(string[] args)
    {
        bool gameRunning = true;

        while (gameRunning)
        {
            Console.Clear();
            Console.WriteLine("Snake Game Menu");
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Instructions");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                Console.Write("Enter your choice: ");
            }

            switch (choice)
            {
                case 1:
                    StartGame();
                    break;
                case 2:
                    DisplayInstructions();
                    break;
                case 3:
                    gameRunning = false;
                    break;
            }
        }
    }

    static void StartGame()
    {
        // Add your snake game logic here
        Console.WriteLine("Starting the game...");
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    static void DisplayInstructions()
    {
        Console.Clear();
        Console.WriteLine("Snake Game Instructions:");
        Console.WriteLine("Move the snake using W,S,A,D keys.");
        Console.WriteLine("Eat food to grow longer and earn points.");
        Console.WriteLine("Avoid hitting the walls or yourself.");
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }
}
