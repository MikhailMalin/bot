using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IMapLoader
    {
        void Download(StreamReader reader, out Cell[,] map);
    }

    public class MapLoader : IMapLoader
    {
        public void Download(StreamReader reader, out Cell[,] map)
        {
            string line;
            List<string> lines = new List<string>();
            while ((line = reader.ReadLine()) != null)
                lines.Add(line);

            map = new Cell[lines.Count, lines[0].Count()];
            
            for (int i = 0; i < lines.Count; i++)
            {
                var line2 = lines[i];
                for (int j = 0; j < line2.Count(); j++)
                {
                    var newCell = GetCellFromChar(line2[j]);
                    map[i, j] = newCell;
                }
            }
        }

        public static void FillForest(Cell[,] map)
        {
            var lines = System.IO.File.ReadAllLines("../../1.txt");
            map = new Cell[lines.Count(), lines[0].Count()];
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (int j = 0; j < line.Count(); j++)
                {
                    var newCell = GetCellFromChar(line[j]);
                    map[i, j] = newCell;
                }
            }
        }

        public static Cell GetCellFromChar(char c)
        {
            return GetCreator(c)();
        }

        private static Func<Cell> GetCreator(char c)
        {
            switch (c)
            {
                case ' ':
                    return () => new Path();
                case '█':
                    return () => new Bush();
                case '@':
                    return () => new Trap();
                case '♥':
                    return () => new Life();
                default:
                    return () => new Bush();

            }

        }
    }
}
