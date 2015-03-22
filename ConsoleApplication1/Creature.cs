using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Creature
    {
        public char Type;
        public int X;
        public int Y;
        public int Lifes;
        public string Name;
        public int EndX;
        public int EndY;
        public Creature(char type, string name, int x, int y, int endX, int endY, int l = 1)
        {
            Type = type;
            X = x;
            Y = y;
            Lifes = l;
            Name = name;
            EndX = endX;
            EndY = endY;

        }

        public bool IsExitFound()
        {
            return (X == EndX && Y == EndY);
        }
        public bool IsAlive()
        {
            return Lifes > 0;
        }
    }
}
