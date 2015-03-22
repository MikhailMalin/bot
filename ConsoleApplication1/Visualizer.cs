using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Visualizer
    {
        public Forest Forest;
        
        
        public Visualizer(Forest forest)
        {
            Forest = forest;
            forest.Changed += ListChanged;
        }
        private void ListChanged(object sender, EventArgs e)
        {
            DrawMap();
        }
        public void DrawMap()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=========");
            Console.WriteLine();

            DrawMap2();

            DrawLegend();

            Console.WriteLine();
            Console.WriteLine("=========");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void DrawMap2()
        {
            var mapCopy = new Char[Forest.map.GetLength(0), Forest.map.GetLength(1)];

            for (int i = 0; i < Forest.map.GetLength(0); i++)
            {
                for (int j = 0; j < Forest.map.GetLength(1); j++)
                {
                    mapCopy[i, j] = Forest.map[i, j].Name();
                }
            }

            foreach (var creature in Forest.AllCreatures)
                mapCopy[creature.X, creature.Y] = creature.Type;

            for (int i = 0; i < mapCopy.GetLength(0); i++)
            {
                for (int j = 0; j < mapCopy.GetLength(1); j++)
                {
                    Console.Write(mapCopy[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void DrawLegend()
        {
            Console.WriteLine();
            Console.WriteLine("  - path");
            Console.WriteLine("█ - bush");
            Console.WriteLine("@ - trap");
            Console.WriteLine("♥ - life");
            foreach (var creature in Forest.AllCreatures)
                Console.WriteLine("{0} - {1} ({2} lifes)", creature.Type, creature.Name, creature.Lifes);
        }
    }
}
