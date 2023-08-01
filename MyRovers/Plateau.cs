using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRovers
{
    internal class Plateau
    {
        static public int _height;
        static public int _width;
        static private int _infoWidth;
        static Plateau()
        {
            _height = 0;
            _width = 0;//varsayılan 
            _infoWidth = 0;
        }
        public static int Height
        {
            get
            {
                if (_height == int.MaxValue)
                {

                }
                return _height;

            }
            set
            {
                if (int.MaxValue == value)
                {

                }
                _height = value;
            }
        }
        public static int Width
        {
            get
            {
                if (_width == int.MaxValue)
                {

                }
                return _width;

            }
            set
            {
                if (int.MaxValue == value)
                {

                }
                _width = value;
            }
        }

        public static int InfoWidth
        {
            get
            {
                if (_width == int.MaxValue)
                {

                }
                return _width;

            }



        }
    }
}