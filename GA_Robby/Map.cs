using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Robby
{
    class Map
    {
        public int size { get; set; }
        public char[,]  map = new char[1,1];
        public int ObjectsToPick = 0;
        public Map(int Size)
        {
            // Crea un mapa en blanco
            this.size = Size;
            
            char[,] Map = new char[size,size];
            this.map = Map;
            for (int i = 0; i < map.Length/size; i++ )
            {
                for(int j = 0; j < map.Length/size; j++)
                {
                    if (i == 0 || i == (map.Length/size - 1))
                    {
                        map[i,j] = '-';
                    }
                    else
                    {
                        if(j == 0 || j == (map.Length/size - 1))
                        {
                            map[i,j] = '-';
                        }
                    }
                }
            }

        }
        public void printMap()
        {
            for(int k = 0; k < map.Length/size; k++)
            {
                for(int l = 0; l < map.Length/size; l++)
                {
                    Console.Write(map[k,l]);
                    if( l == map.Length/size - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadLine();
        }

        public char[,] GenerateChallenge(int challenge)
        {
            Random ran = new Random();
            
            for (int i = 0; i < map.Length / size; i++)
            {
                for (int j = 0; j < map.Length / size; j++)
                {
                    if (i != 0 && i != (map.Length / size - 1) && j != 0 && j != (map.Length / size -1))
                    {
                        if (ran.Next(100) < challenge)
                        {
                            map[i, j] = '@';
                            ObjectsToPick += 1;
                        }
                    }
                }
            }
            return map;
        }

        internal void resetMap()
        {
            ObjectsToPick = 0;
            for (int i = 0; i < map.Length / size; i++)
            {
                for (int j = 0; j < map.Length / size; j++)
                {
                    if (i != 0 && i != (map.Length / size - 1) && j != 0 && j != (map.Length / size - 1))
                    {
                       map[i, j] = ' ';
                    }
                }
            }
        }
    }
}

    
