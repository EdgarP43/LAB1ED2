using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1ED2.Arbol;
using Lab1ED2.SodaViewModel;

namespace Lab1ED2.Arbol
{
    public class ArbolB
    {
        private Nodo raiz;
        public void inserta(SodaClass dato)
        {
            if (raiz == null)
            {
                Nodo nuevoNodo = new Nodo();
                nuevoNodo.valorIzquierdo = dato;
                raiz = nuevoNodo;

            }
            else
            {
                Nodo temporal = insertar(dato, raiz);
                if (temporal != null)
                {
                    raiz = temporal;//si tuvo que partir la raiz significa que otro tuvo que subir y ese sera la nueva raiz
                }

            }
           
        }
        public Nodo insertar(SodaClass dato, Nodo nodo)
        {
            return null;
        }
    }
}
