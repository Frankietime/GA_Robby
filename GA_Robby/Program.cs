using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Robby
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map(20);
            Robby robby = new Robby();

            robby.GenerateStrategy(10, 20);

            //map.GenerateChallenge(20);
            //map.printMap();
            //map.resetMap();
            //map.GenerateChallenge(20);
            //map.printMap();
            //map.resetMap();
            //map.GenerateChallenge(20);
            //map.printMap();
            //map.resetMap();
            //map.GenerateChallenge(20);
            //map.printMap();
            //map.resetMap();
            //map.GenerateChallenge(20);
            //map.printMap();
            //map.resetMap();
        }
    }
}