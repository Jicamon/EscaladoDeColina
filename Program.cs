using System;
using System.Collections.Generic;
using System.Linq;

namespace EscaladoColina
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            
        }

        public static void recocidoSimulado()
        {
            Boolean[] esta = generadorDeEstadoInicial();
            Nodo mejorNodo;
            Nodo calis = new Nodo(esta);
            
            Console.WriteLine("---------------------------------------------");
            ImprimirEstado(calis, "Inicial");
            Console.WriteLine("---------------------------------------------");
            mejorNodo = Algoritmo.recocido(calis, 100, .9, 2586.98);
            Console.WriteLine("---------------------------------------------");
            ImprimirEstado(mejorNodo, "Mejor Nodo");
            Console.WriteLine("---------------------------------------------");
        }

        public static void escalarLaColina(){
            Boolean[] estadoI = generadorDeEstadoInicial();
            //Boolean[] estadoI = {true, false, false, true, true};
            Nodo esini = new Nodo(estadoI);
            int cont = 1;
            Console.WriteLine("---------------------------------------------");
            ImprimirEstado(esini, "Inicial");
            Console.WriteLine("---------------------------------------------");
            
            foreach(Nodo camino in Algoritmo.escalada(esini, 5))
            {
                ImprimirEstado(camino, cont + ".- ");
                cont++;
            }
        }

        public static void ImprimirEstado (Nodo estado, string tipo)
        {
            Console.Write(tipo + ": [");
                for(int i = 0; i<5; i++)
                {
                    if(i == 4 )
                    {   
                        if(estado.estado[i])
                        {
                            Console.Write("1] Heuristica: " + estado.heuristica);
                        }
                        else
                        {
                            Console.Write("0] Heuristica: " + estado.heuristica);
                        }
                        
                    }
                    else
                    {
                        if(estado.estado[i])
                        {
                            Console.Write("1, ");
                        }
                        else
                        {
                            Console.Write("0, ");
                        }
                    }
                    
                }
            Console.WriteLine();
        }

        public static bool[] generadorDeEstadoInicial()
        {
            bool[] estadoInicial = new bool[5];
            Random elRand = new Random();
            List<int> posiciones = new List<int>();

            do
            {
                int poc = elRand.Next(0,5);
                if(!posiciones.Contains(poc))
                {
                    posiciones.Add(poc);
                }
            }
            while(posiciones.Count<5);

            for (int i = 0; i < 5; i++)
            {
               
                if(posiciones.ElementAt(i) == 0 || posiciones.ElementAt(i) == 1 || posiciones.ElementAt(i) == 2)
                {
                    estadoInicial[i] = true;
                }
                else
                {
                    estadoInicial[i] = false;
                }
            }
            return estadoInicial;
        }
        public static void Menu(){
            int Menu;
            
            do
            {
                Console.WriteLine("-----------Menu--------------");
                Console.WriteLine("1.- Escalada de Colina");
                Console.WriteLine("2.- Recocido Simulado");
                Console.WriteLine("0.- Salir");
                Console.WriteLine("-----------------------------");

                Menu = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-----------------------------");
                if(Menu == 1)
                {
                    
                   
                   escalarLaColina();
                    
                }
                else
                {
                    if(Menu == 2)
                    {
                       recocidoSimulado();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            while(Menu > 0);
        }
        
    }
}
