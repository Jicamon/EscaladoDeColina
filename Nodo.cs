using System;
using System.Collections.Generic;

namespace EscaladoColina
{
    class Nodo
    {
            public Boolean[] estado = new Boolean[5];
            public List<Nodo> hijos = new List<Nodo>();
            public Double heuristica {get; set;}
            
            public Nodo(Boolean[] miEstado) {
                estado = miEstado;
                heuristica = calcHeuristica(miEstado);
            }
            
            public Double calcHeuristica(Boolean[] miEstado) {
                
                int x1, x2, x3, x4, x5, y1, y2;
                double heuristica;
                
                if(miEstado[0] == true){
                    x1 = 1;
                }else {
                    x1 = 0;
                }
                
                if(miEstado[1] == true){
                    x2 = 1;
                }else {
                    x2 = 0;
                }

                if(miEstado[2] == true){
                    x3 = 1;
                }else {
                    x3 = 0;
                }
                
                if(miEstado[3] == true){
                    x4 = 1;
                }else {
                    x4 = 0;
                }
                
                if(miEstado[4] == true){
                    x5 = 1;
                }else {
                    x5 = 0;
                }
                
                if(contarTrues(miEstado) != 3) {
                    y1 = 1;
                }else {
                    y1 = 0;
                }
                
                if(_4y5(miEstado)) {
                    y2 = 1;
                }else {
                    y2 = 0;
                }
                
                heuristica = 2*x1 + 2.4*x2 + 3*x3 + 4*x4 + 4.4*x5 + 18*y1 + 8*y2;
                        
                return heuristica;
            }
            
            public Boolean _4y5(Boolean[] nodo) {
                Boolean flag = true;
                
                if(nodo[3] == false || nodo[4] == false)
                    flag = false;
                
                return flag;
            }

            
            
            public int contarTrues(Boolean[] nodo) {
                int cantidad = 0;
                
                int loop = nodo.Length;
                
                for(int i = 0; i < loop; i++) {
                    if(nodo[i] == true)
                        cantidad++;
                }
                
                return cantidad;
            }
    }
}