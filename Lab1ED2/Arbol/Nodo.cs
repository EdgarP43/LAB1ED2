using System;
using System.Collections.Generic;
using System.Linq;
using Lab1ED2.SodaViewModel;
using System.Threading.Tasks;

namespace Lab1ED2.Arbol
{
    public class Nodo
    {
        public SodaClass valorDerecho { get; set; }
        public SodaClass valorIzquierdo { get; set; }
        public Nodo hijoIzquierdo { get; set; }
        public Nodo hijoMedio { get; set; }
        public Nodo hijoDerecho { get; set; }
    }
}
