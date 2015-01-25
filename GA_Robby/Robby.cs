using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA_Robby
{
    class Robby
    {
        public string[] poblacion = new string[1];
        public char[,] map = new char[1, 1];
        public int[,] grid = new int[1, 1];
        public int iPosition { get; set; } // Posiscion de robi para la coordenada i
        public int jPosition { get; set; } // Posiscion de robi para la coordenada J
        public int movesCount = 200;
        public int calificacion = 0;
        public int[] calificaciones { get; set; }
        public int ObjectsToPick = 0;
        public int challenge { get; set; }

        public Robby(Map Map, int ObjectsToPick, int Challenge)
        {
            this.challenge = Challenge;
            this.map = Map.GenerateChallenge(challenge);
            this.ObjectsToPick = Map.ObjectsToPick;
        }
        public void Initialize()
        {
            iPosition = 0;
            jPosition = 0;
            movesCount = 200;
            calificacion = 0;
        }
        //public void setGenetics(int[] genes, int individualName)
        //{

        //}
        public void GenerateStrategy(int TamañoPoblacion, int MapSize )
        {
            string[] poblacion = this.GeneratePopulation(TamañoPoblacion, MapSize);
            int[] Calificaciones = new int[TamañoPoblacion];
            calificaciones = Calificaciones;
            
            // Obtengo a cada individuo, lo enfrento al desafio y lo califico
            for (int i = 0; i < TamañoPoblacion; i++ )
            {
                char[,] currentMap = this.map;
                string geneString = poblacion[i];
                string[] genes = new string[243];
                genes = geneString.Split('|');
                this.Initialize();
                bool end = false;
                foreach(var g in genes)
                {
                    switch (Convert.ToInt32(g))
                    {
                        case 1:
                            this.Move("left", currentMap, i, end);
                            break;
                        case 2:
                            this.Move("right", currentMap, i, end);
                            break;
                        case 3:
                            this.Move("up", currentMap, i, end);
                            break;
                        case 4:
                            this.Move("down", currentMap, i, end);
                            break;
                        case 5:
                            this.Move("pick", currentMap, i, end);
                            break;
                        case 6:
                            this.Move("stay", currentMap, i, end);
                            break;
                        default:
                            this.Move("stay", currentMap, i, end);
                            break;
                    }
                    if(end)
                    {
                        break;
                    }
                }

                // Evaluo calificaciones, cruzo individuos, muto a la descendencia y comienzo nueva generacion
                this.EvaluateGeneration();
            }
        }

        private void EvaluateGeneration()
        {
         int lastInd = 0;
         Queue<int> ListaEvaluacion = new Queue<>();
            foreach(var c in calificaciones)
            {
                
            }
            
        }
        public void Move(string move, char[,] currentMap, int individual, bool end)
        {
            movesCount--;
            if (move == "left")
            {
                int PositionI = iPosition;
                PositionI += 1;

                if (currentMap[PositionI, jPosition] == '-')
                {
                    calificacion -= 5;
                    return;
                }
                else
                {
                    iPosition = PositionI;
                }
            }
            if (move == "right")
            {
                int PositionI = iPosition;
                PositionI -= 1;

                if (currentMap[PositionI, jPosition] == '-')
                {
                    calificacion -= 5;
                    return;
                }
                else
                {
                    iPosition = PositionI;
                }
            }
            if (move == "up")
            {
                int PositionJ = jPosition;
                PositionJ -= 1;

                if (currentMap[iPosition, PositionJ] == '-')
                {
                    calificacion -= 5;
                    return;
                }
                else
                {
                    jPosition = PositionJ;
                }
            }
            if (move == "down")
            {
                int PositionJ = jPosition;
                PositionJ += 1;

                if (currentMap[iPosition, PositionJ] == '-')
                {
                    calificacion -= 5;
                    return;
                }
                else
                {
                    jPosition = PositionJ;
                }
            }
            if (move == "pick")
            {
                if (currentMap[iPosition, jPosition] == '@')
                {
                    calificacion += 5;
                    currentMap[iPosition, jPosition] = ' ';
                    ObjectsToPick--;
                    if(ObjectsToPick == 0)
                    {
                        calificacion += 100;
                        this.End(individual);
                        end = true
                    }
                    return;
                }
                else
                {
                    calificacion -= 2; 
                }
            }
            if (move == "stay")
            {
                
            }
        }
        public void End(int i)
        {
            calificaciones[i] = calificacion;
        }
        public string[] GeneratePopulation(int TamañoPoblacion, int MapSize)
        {   
            // Construyendo población
            string[] Poblacion = new string[TamañoPoblacion];
            this.poblacion = Poblacion;
            Random ran = new Random();
            
            for(int i = 0; i < TamañoPoblacion; i++)
            {
                for (int j = 0; j < 242; j++)
                {
                    poblacion[i] += Convert.ToString(ran.Next(6) + 1) + "|";
                    
                }
                Console.WriteLine(poblacion[i]);
                Console.WriteLine();
            }
            Console.ReadLine();
            return poblacion;
           
        }

    }
}
