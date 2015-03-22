using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Bot
    {
        private Creature Creature;
        private Cell[,] Map = new Cell[1000, 1000];
        private int[,] Visits = new int[1000, 1000];
        private Forest Forest;
        private int OldLifes;

        public Bot(Creature cr, Forest forest)
        {
            Creature = cr;
            OldLifes = cr.Lifes;
            Forest = forest;
        }
        public void GoToEnd()
        {
            Map[Creature.X, Creature.Y] = new Path();
            Map[Creature.EndX, Creature.EndY] = new Path();

            Visits[Creature.X, Creature.Y]++;
            
            if (Creature.EndX == Creature.X && Creature.EndY == Creature.Y)
                return;

            Direction dir;

            if (Creature.EndX - Creature.X > 0)
            {
                dir = new Down();
            }
            else
            {
                if (Creature.EndX - Creature.X < 0)
                    dir = new Up();
                else
                {
                    if (Creature.EndY - Creature.Y < 0)
                        dir = new Right();
                    else
                        dir = new Left();
                }
            }

            var turns = 0;

            while (Creature.X != Creature.EndX || Creature.EndY != Creature.Y)
            {
                if (Forest.TryToMove(Creature, dir))
                {
                    if (OldLifes == Creature.Lifes)
                        Map[Creature.X, Creature.Y] = new Path();
                    if (OldLifes > Creature.Lifes)
                        Map[Creature.X, Creature.Y] = new Trap();
                    if (OldLifes < Creature.Lifes)
                        Map[Creature.X, Creature.Y] = new Life();

                    Visits[Creature.X, Creature.Y]++;

                    if (Visits[Creature.X, Creature.Y] > 4)
                    {
                        Console.WriteLine("There's no way out!!!!");
                        return;
                    }

                    dir = dir.TurnRight();

                    turns = 0;

                    Console.WriteLine("{0}, {1}, dir: {2}, {3}", Creature.X, Creature.Y, dir.dx, dir.dy);
                }
                else
                {
                    if (Creature.Lifes == 0)
                    {
                        Console.WriteLine("We are dead!!!!");
                        return;
                    }

                    Map[Creature.X + dir.dx, Creature.Y + dir.dy] = new Bush();
                    dir = dir.TurnLeft();

                    turns++;

                    if (turns >= 4)
                    {
                        Console.WriteLine("Can't move anywhere!!!!");
                        return;
                    }
                }
            }
            if (Creature.IsExitFound()) Console.WriteLine("Exit is found!");

        }
    }
}
