using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class Direction
    {
        public virtual int dx
        {
            get { return 0; }
        }

        public virtual int dy
        {
            get { return 0; }
        }

        public abstract Direction TurnLeft();
        public abstract Direction TurnRight();
        
    }
    

    public class Up : Direction
    {
        public override int dx
        {
            get { return -1; }
        }

        public override Direction TurnLeft()
        {
            return new Left();
        }
        public override Direction TurnRight()
        {
            return new Right();
        }
    }
    public class Down : Direction
    {
        public override int dx
        {
            get { return 1; }
        }
        public override Direction TurnLeft()
        {
            return new Right();
        }
        public override Direction TurnRight()
        {
            return new Left();
        }

    }
    public class Left : Direction
    {
        public override int dy
        {
            get { return -1; }
        }
        public override Direction TurnLeft()
        {
            return new Down();
        }
        public override Direction TurnRight()
        {
            return new Up();
        }
    }
    public class Right : Direction
    {
        public override int dy
        {
            get { return 1; }
        }
        public override Direction TurnLeft()
        {
            return new Up();
        }
        public override Direction TurnRight()
        {
            return new Down();
        }
    }
}
