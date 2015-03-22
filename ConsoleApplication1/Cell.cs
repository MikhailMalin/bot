using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class Cell
    {
        public abstract bool CanStand(Creature creature, Direction direction);
        public abstract bool TryCreate(Creature creature); 
        public abstract char Name();
    }

    public class Path : Cell
    {
        public override bool CanStand(Creature creature, Direction direction)
        {
            creature.X += direction.dx;
            creature.Y += direction.dy;
            return true;
        }

        public override bool TryCreate(Creature creature)
        {
            Forest.AllCreatures.Add(creature);
            return true;
        }

        public override char Name()
        {
            return ' ';
        }
    }

    public class Trap : Cell
    {
        public override bool CanStand(Creature creature, Direction direction)
        {
            creature.X += direction.dx;
            creature.Y += direction.dy;
            creature.Lifes--;
            return true;
        }

        public override bool TryCreate(Creature creature)
        {
            return false;
        }
        public override char Name()
        {
            return '@';
        }
    }

    public class Bush : Cell
    {
        public override bool CanStand(Creature creature, Direction direction)
        {
            return false;
        }

        public override bool TryCreate(Creature creature)
        {
            return false;
        }
        public override char Name()
        {
            return '█';
        }
    }

    public class Life : Cell
    {
        public override bool CanStand(Creature creature, Direction direction)
        {
            creature.X += direction.dx;
            creature.Y += direction.dy;
            creature.Lifes++; 
            return true;
        }

        public override bool TryCreate(Creature creature)
        {
            return false;
        }
        public override char Name()
        {
            return '♥';
        }
    }
}
