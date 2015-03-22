using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace ConsoleApplication1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var stream = new StreamReader("../../1.txt");
            var forest = new Forest();
            var mapLoader = new MapLoader();
            mapLoader.Download(stream, out forest.map);
            var creature = new Creature('A', "Alice", 4, 5, 3, 7);
            forest.AddCreature(creature);
            var bot = new Bot(creature, forest);
            bot.GoToEnd();
            Assert.AreEqual(true, creature.IsExitFound());
        }

        [Test]
        public void Test2()
        {
            var stream = new StreamReader("../../2.txt");
            var forest = new Forest();
            var mapLoader = new MapLoader();
            mapLoader.Download(stream, out forest.map);
            var creature = new Creature('A', "Alice", 4, 5, 3, 7);
            forest.AddCreature(creature);
            var bot = new Bot(creature, forest);
            bot.GoToEnd();
            Assert.AreEqual(false, creature.IsAlive());
        }
    }
}
