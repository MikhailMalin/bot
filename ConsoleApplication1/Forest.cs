using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Forest
    {
        public event ChangedEventHandler Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        public static List<Creature> AllCreatures = new List<Creature>();

        public Cell[,] map;

        public bool AddCreature(Creature cr)
        {
            if (map[cr.EndX, cr.EndY].Name() == ' ')
            {
                var result = map[cr.X, cr.Y].TryCreate(cr);

                if (result)
                    OnChanged(EventArgs.Empty);

                return result;
            }
            return false;
        }

        public bool TryToMove(Creature creature, Direction direction)
        {
            while(creature.IsAlive())
            {
                var result = map[creature.X + direction.dx, creature.Y + direction.dy].CanStand(creature, direction);

                if (result)
                    OnChanged(EventArgs.Empty);

                return result;
            }
            Console.WriteLine("Move is impossible. {0} is dead", creature.Name);
            return false;
        }
    }
}
