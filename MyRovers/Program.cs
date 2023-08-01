using MyRover;

using MyRover;
using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace MyRovers
{
    enum Movement // numaralandırma,sabit liste olusturma belli türdeki degerleri tutmaya yarar.
    {
        W,//Yukarı
        D,//Sag
        S,//Asagı
        A,//Sol
        L,
        R,
        M,
        TurnRight
    }

    class Program
    {
        static bool choice;
        static void Main(string[] args)
        {
            ulong[,] plateau;


            Console.WriteLine("Make Your Choice");
            Console.WriteLine("Enter Your User Name");
            Console.WriteLine("You require  to input dimensions of the plateau");
            CreatePlateau(out plateau);//cıkıs parametresi metodun icinde degeri degistirip cagrıldıgı yeri etkileyebilir

            bool exit = false;
            List<Rover> rovers = new List<Rover>();

            while (!exit)
            {
                Console.WriteLine("1.Deploy a Rover");
                if (rovers.Count > 0)
                {
                    Console.WriteLine("2.Control a Rover");
                    Console.WriteLine("3.Check your all Rovers");
                }

                Console.WriteLine("4.Exit");
                Console.Write("Which number do you choose?:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Rover newRover = CreateRover();
                        if (IncorrectLocation(plateau, newRover.X, newRover.Y))
                        {
                            Console.WriteLine();

                            Console.WriteLine("!!!!!!");
                            Console.WriteLine("Another rover is located at these coordinates");
                            Console.WriteLine("Please enter another coordinate");
                        }
                        else
                        {
                            rovers.Add(newRover);
                            plateau[newRover.X, newRover.Y] = (ulong)rovers.Count;
                            Console.WriteLine();
                            Console.WriteLine("Rover successfully deployed");
                           
                        }
                        break;

                    case "2": // Rover Hareket Ettir
                        if (rovers.Count == 0)
                        {
                            Console.WriteLine("Rover not docked");
                        }
                        else
                        {
                            Console.WriteLine();
                            foreach (Rover rover in rovers)
                            {
                                Console.WriteLine("{rover.Name} : {rover.X} {rover.Y} {rover.Direction}");
                            }
                            Console.Write("Which rover would you like to control:");
                            int roverControlNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                            MoveRover(rovers[roverControlNumber], plateau);
                        }
                        break;

                    case "3": 
                        ShowPlateauWithRovers(plateau, rovers);
                        break;

                    case "4": 
                        Console.WriteLine("The program is ending...");
                        return;

                    default:
                        Console.WriteLine("Please select a valid transaction!");
                        break;
                }
            }
            static void CreatePlateau(out ulong[,] plateau)
            {
                Console.Write("Enter the width of the plateau ");
                ulong width = ulong.Parse(Console.ReadLine());
                Console.Write("Enter the height of the plateau: ");
                ulong height = ulong.Parse(Console.ReadLine());
                plateau = new ulong[width, height];
            }
            static Rover CreateRover()
            {
                Console.Write("Enter the coordinates (X Y) where the rover will be located: ");
                string[] coordinates = Console.ReadLine().Split(' ');
                int x = int.Parse(coordinates[0]);
                int y = int.Parse(coordinates[1]);

                Console.Write("Enter the starting direction (N, S, E, W) of the rover: ");
                char direction = char.ToUpper(Console.ReadKey().KeyChar);

                return new Rover();
            }
            static bool IncorrectLocation(ulong[,] plateau, int x, int y)
            {
                return plateau[x, y] != 0;
            }

            static void MoveRover(Rover rover, ulong[,] plateau)
            {
                Console.Write("Enter the movement (L:Turn Left, R:  Turn Right, M: MoveForward): ");
                string movement = Console.ReadLine().ToUpper();

                switch (movement)
                {
                    case "L":
                        rover.TurnLeft();
                        break;
                    case "R":
                        rover.TurnRight();
                        break;
                    case "M":
                        rover.MoveForward();
                        break;
                    default:
                        Console.WriteLine("Invalid movement type!");
                        break;
                }
            }

            static void ShowPlateauWithRovers(ulong[,] plateau, List<Rover> rovers)
            {
                Console.WriteLine();
                for (int y = plateau.GetLength(1) - 1; y >= 0; y--)
                {
                    for (int x = 0; x < plateau.GetLength(0); x++)
                    {
                        if (plateau[x, y] == 0)
                            Console.Write("- ");
                        else
                            Console.Write(plateau[x, y] + " ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
                foreach (Rover rover in rovers)
                {
                    Console.WriteLine("{rover.Name} : {rover.X} {rover.Y} {rover.Direction}");
                }
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                        int e = 0;

                        if (key.Key == ConsoleKey.DownArrow && e != 3)
                        {
                            e++;
                        }
                        else if (key.Key == ConsoleKey.UpArrow && e
                                   >= 1)
                        {
                            e--;
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            switch (e)
                            {
                                case 0:
                                    MenuChoice1();
                                    break;
                                case 1:
                                    MenuChoice2();
                                    break;
                                case 2:
                                    MenuChoice3();
                                    break;
                                case 3:
                                    MenuChoice4();
                                    break;
                            }
                        }
                    }
                }

                static void MenuChoice1()
                {


                    Console.Clear();

                    Console.ReadKey();
                }

                static void MenuChoice2()
                {



                    Console.Clear();

                    Console.ReadKey();
                }
                static void MenuChoice3()
                {
                    Console.Clear();

                    Console.ReadKey();


                }

                static void MenuChoice4()
                {

                    Console.Clear();

                    Console.WriteLine("Press Enter To Exit The Menu");
                    Console.ReadKey();
                    Console.Clear();
                    Environment.Exit(1);

                    Console.Clear();
                    Console.SetWindowSize(Plateau.Width + Plateau.InfoWidth, Plateau.Height);
                    Console.SetBufferSize(Plateau.Width + Plateau.InfoWidth, Plateau.Height);
                    Rover rover = new Rover();
                    Movement movement = new Movement();

                    ulong x = 0;
                    ulong y = 0;
                    x++;
                    y++;
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo;
                        while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                        {
                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.L:
                                    Console.ReadKey();
                                    Console.WriteLine("turn left");
                                    break;
                                case ConsoleKey.R:
                                    Console.ReadKey();
                                    Console.WriteLine("turn right");
                                    break;
                                case ConsoleKey.M:
                                    Console.ReadKey();
                                    Console.WriteLine("Move 1 unit");
                                    break;
                                case ConsoleKey.W:
                                    Console.ReadKey();
                                    Console.WriteLine("Move Up ");
                                    break;
                                case ConsoleKey.D:
                                    Console.ReadKey();
                                    Console.WriteLine("Move right");
                                    break;

                                case ConsoleKey.S:
                                    Console.ReadKey();
                                    Console.WriteLine("Move down");
                                    break;

                                case ConsoleKey.A:
                                    Console.ReadKey();
                                    Console.WriteLine("Move left +1");
                                    break;

                                default:
                                    Console.WriteLine("Invalid key.");
                                    break;

                            }
                        }
                        while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                        {
                            Console.WriteLine("Press a key");
                        }
                    }
                }
                static void CreatePlateau(out ulong[,] plateau)
                {
                    Console.Write("Enter the width of the plateau: ");
                    ulong width = ulong.Parse(Console.ReadLine());
                    Console.Write("Enter the height of the plateau: ");
                    ulong height = ulong.Parse(Console.ReadLine());
                    plateau = new ulong[width, height];

                }
                static void IncorrectLocation()
                {
                    Console.WriteLine("CHECK YOUR ROVERS");
                }
            } 
        } 
    } 
} 