
using MyRovers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyRover
{
    public class Rover
    {
        private const ulong _height = 9000000000000000000, _length = 9000000000000000000;
        private int _cord_X;
        private int _cord_Y;
        public string Name { get; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Direction { get; private set; }
        public void TurnLeft()
        {
            switch (Direction)
            {
                case 'N':
                    Direction = 'W';
                    break;
                case 'E':
                    Direction = 'N';
                    break;
                case 'S':
                    Direction = 'E';
                    break;
                case 'W':
                    Direction = 'S';
                    break;
                default:
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case 'N':
                    Direction = 'E';
                    break;
                case 'E':
                    Direction = 'S';
                    break;
                case 'S':
                    Direction = 'W';
                    break;
                case 'W':
                    Direction = 'N';
                    break;
                default:
                    break;
            }
        }

        public void MoveForward()
        {
            switch (Direction)
            {
                case 'N':
                    Y += 1;
                    break;
                case 'E':
                    X += 1;
                    break;
                case 'S':
                    Y -= 1;
                    break;
                case 'W':
                    X -= 1;
                    break;
                default:
                    break;
            }
        }

        public int Cord_X
        {
            get { return _cord_X; } // x koordinatı okunabilir (get)
            set { _cord_X = value; } // x koordinatı değiştirilebilir (set)
        }
        public int Cord_Y
        {
            get { return _cord_Y; }
            set { _cord_Y = value; }
        }
        public ulong Height
        {
            get { return _height; }
        }

        public ulong Length
        {
            get { return _length; }
        }
        internal class Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        static bool CanMove(Coordinate c)
        {
            if (c.X < 0 || c.X >= Console.WindowWidth)
                return false;

            if (c.Y < 0 || c.Y >= Console.WindowHeight)
                return false;

            return true;
        }
    }
    public class Rover2 : Rover
    {

    }
}
