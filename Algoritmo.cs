using System;
using System.Collections.Generic;
using System.Linq;

namespace EscaladoColina
{
    class Algoritmo
    {
        public static Nodo recocido (Nodo actual, int repeticiones, double alpha, double temperatura)
        {

            Boolean[] esta = {true,true,true,true,true};
            Random rand = new Random();
            Nodo elBueno = actual;
            List<Nodo> ruta = new List<Nodo>();
            List<Nodo> visitados = new List<Nodo>();
            Nodo vecino = new Nodo(cambiarUnaFincaDeLugar(actual.estado));
            double uniforme = 0;
            double mathdeltasobretemp = 0;
            double delta = 0;
            Nodo mejorEstado = new Nodo(esta);
            double temperaturaNueva = temperatura;
            int flag = 0;
            int flag2 = 0;
            int iteracion = 1;
            do
            {
                

                if(elBueno.heuristica < mejorEstado.heuristica){
                    mejorEstado = elBueno;
                }
                Console.WriteLine("---------------------" + iteracion + "-----------------------");
                iteracion++;
                ImprimirEstado(elBueno, "Actual");
                ImprimirEstado(vecino, "Vecino");

                ruta.Add(elBueno);
                visitados.Add(elBueno);
                delta = vecino.heuristica - elBueno.heuristica;

                mathdeltasobretemp = Math.Exp(-(delta/temperaturaNueva));

                if((delta > 0))
                {
                    uniforme = rand.NextDouble();
                    
                    if(uniforme < mathdeltasobretemp)
                    {
                        elBueno = vecino;
                        flag++;
                    }

                }
                else
                {
                    elBueno = vecino;
                    flag = 0;
                }
                
                do
                {
                    flag2++;
                    vecino = new Nodo(cambiarUnaFincaDeLugar(elBueno.estado));
                }
                while(visitados.Contains(vecino) && flag2 < 20);
               
                if(flag2 == 20){
                    flag = 10;
                }

                Console.WriteLine(  "Delta: " + delta + 
                                    " \nTemperatura: " + temperaturaNueva + 
                                    " \nexp(-delta/temp): " + mathdeltasobretemp +
                                    " \nUniforme:" + uniforme);
                temperaturaNueva = temperaturaNueva * alpha;
                
                flag2 = 0;
            }
            while(iteracion <= repeticiones && flag < 3);

            return mejorEstado;
        }
        public static bool[] cambiarUnaFincaDeLugar(bool[] aCambiar)
        {
            bool[] cambiado = new bool[aCambiar.Length];
            List<int> losTrues = new List<int>();
            List<int> losFalses = new List<int>();
            Random rand = new Random();

            bool[] temporal = new bool[5];
            for(int i = 0; i < 5; i++)
            {
                temporal[i] = aCambiar[i];
            }

            for(int i = 0; i < temporal.Length; i++)
            {
                bool valor = temporal[i];
                if(valor)
                {
                    losTrues.Add(i);
                }
                else
                {
                    losFalses.Add(i);
                }
            }

            int elTrue = losTrues.ElementAt(rand.Next(0,losTrues.Count));
            int elFalse = losFalses.ElementAt(rand.Next(0,losFalses.Count));

            temporal[elTrue] = !temporal[elTrue];
            temporal[elFalse] = !temporal[elFalse];

            for(int i = 0; i < 5; i++) 
            {
                cambiado[i] = temporal[i];
            }
            

            return cambiado;
        }
        public static List<Nodo> escalada (Nodo actual, int repeticiones) 
        {
            //double HeuristicaActual;
            //bool[] estadoSiguiente;
            Nodo elBueno = actual;
            List<Nodo> ruta = new List<Nodo>();
            do
            {
                Console.WriteLine("-----------------------------");
                ImprimirEstado(elBueno, "Nodo: ");
                
                if(elBueno.hijos.Count == 0){
                    elBueno.hijos = OrdenarTodosLosVecinos(ObtenerTodosLosVecinos(elBueno));
                }
                if((elBueno.heuristica > elBueno.hijos.ElementAt(0).heuristica))
                {
                    ruta.Add(elBueno);
                    elBueno = elBueno.hijos.ElementAt(0);
                    repeticiones--;
                }
                else
                {
                    repeticiones = 0;
                    ruta.Add(elBueno);
                }
            }
            while(repeticiones > 0);
            Console.WriteLine("-----------------------------\nRecorrido:");
            return ruta;
	    }
        public static List<Nodo> ObtenerTodosLosVecinos(Nodo padre)
        {
            List<Nodo> vecinos = new List<Nodo>();
            
            Nodo nuevoNodo1 = new Nodo(cambiarUnaFincaDeLugar(padre.estado));
            vecinos.Add(nuevoNodo1);

            Nodo nuevoNodo2 = new Nodo(cambiarUnaFincaDeLugar(padre.estado));
            vecinos.Add(nuevoNodo2);

            Nodo nuevoNodo3 = new Nodo(cambiarUnaFincaDeLugar(padre.estado));
            vecinos.Add(nuevoNodo3);

            Nodo nuevoNodo4 = new Nodo(cambiarUnaFincaDeLugar(padre.estado));
            vecinos.Add(nuevoNodo4);

            Nodo nuevoNodo5 = new Nodo(cambiarUnaFincaDeLugar(padre.estado));
            vecinos.Add(nuevoNodo5);

            foreach(Nodo hijo in vecinos)
            {
                ImprimirEstado(hijo, "Vecino");
            }

            return vecinos;
        }
        public static List<Nodo> OrdenarTodosLosVecinos(List<Nodo> vecinos)
        {

            List<Nodo> vecinosOrdenados = vecinos.OrderBy( o => o.heuristica).ToList();

            return vecinosOrdenados;
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
    }
}
