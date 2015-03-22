using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new StreamReader("../../1.txt");
            
            var forest = new Forest();

            var mapLoader = new MapLoader();
            mapLoader.Download(stream, out forest.map);

            var visualizer = new Visualizer(forest);

            var cr1 = new Creature('A', "Alice", 4, 5,3,7);
            //Console.WriteLine("{0} {1} {2}", cr1.X, cr1.Y, cr1.Lifes);
            
            var cr2 = new Creature('B', "BoBa", 4, 5,1,1);
            //var cr3 = new Creature('C',3,4,2);


            forest.AddCreature(cr1);
            //forest.AddCreature(cr2);

            //forest.TryToMove(cr1, new Left());
            //forest.TryToMove(cr1, new Left());
            //forest.TryToMove(cr1, new Up());

            //forest.TryToMove(cr2, new Left());
            //forest.TryToMove(cr2, new Left());
            //forest.TryToMove(cr2, new Up());
            
            //Console.WriteLine("{0} {1} {2}", cr1.X, cr1.Y, cr1.Lifes);
            var bot1 = new Bot(cr1, forest);
            bot1.GoToEnd();
        }
    }
}
