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
                var nuevoNodo = new Nodo();
                nuevoNodo.valorIzquierdo = dato;
                raiz = nuevoNodo;

            }
            else
            {
                var temporal = insertar(dato, raiz);
                if (temporal != null)
                {
                    raiz = temporal;//si tuvo que partir la raiz significa que otro tuvo que subir y ese sera la nueva raiz
                }

            }
           
        }
        public Nodo insertar(SodaClass dato, Nodo nodo)
        {
            if (nodo.hijoIzquierdo == null && nodo.hijoMedio == null && nodo.hijoDerecho == null)
            {
                if (nodo.valorDerecho == null)//Si tiene valor izquierdo pero no derecho
                {
                    if (nodo.valorIzquierdo.nombre.CompareTo(dato.nombre) == 1)
                    {//Si el dato que ya tenia el nodo es mayor que el que se desea agregar, el dato que se va a agregar tiene que ser el valor izquierdo

                    }
                    else
                    {

                    }
                    return null;
                }
                else
                {
                    //Tiene que subir
                    if (nodo.valorDerecho.nombre.CompareTo(dato.nombre) == -1)
                    {//Para que  suba el valor medio, en este caso seria el que tenia como dato derecho el nodo hoja

                    }
                    //nodo.valorIzquierdo.nombre > dato.nombre
                    else if (nodo.valorIzquierdo.nombre.CompareTo(dato.nombre) == 1)//Va a tener que subir el que tenia como dato izquierdo
                    {

                    }
                    else
                    { //tiene que subir el dato actual

                    }
                }
            }
            else
            {
                if (nodo.valorDerecho == null)//Si el valor derecho esta vacio
                {
                    //nodo.valorIzquierdo.nombre < dato.nombre
                    if (nodo.valorIzquierdo.nombre.CompareTo(dato.nombre) == -1)
                    {
                        var temp = insertar(dato, nodo.hijoMedio);//busca en el hijo medio y guarda lo que este le retorne

                    }
                    else
                    {
                        var temp = insertar(dato, nodo.hijoIzquierdo);//busca en el hijo izquierdo y guarda lo que este le retorne

                        return null;//como ya se lleno el nodo no tiene que seguir subiendo nada
                    }
                }
                else//si el nodo actual ya esta lleno, es decir tiene sus 2 valores ocupados
                {
                    //nodo.valorIzquierdo > dato
                    if (dato.nombre.CompareTo(nodo.valorIzquierdo.nombre) == -1)//si el dato es menor que el dato izquierdo del nodo
                    {
                        var temporal = insertar(dato, nodo.hijoIzquierdo);
                    }
                    //nodo.valorIzquierdo.nombre < dato.nombre && dato.nombre < nodo.valorDerecho.nombre
                    //(dato.nombre.CompareTo(nodo.valorIzquierdo.nombre) == 1) && (dato.nombre.CompareTo(nodo.valorDerecho.nombre) == -1)
                    else if ((dato.nombre.CompareTo(nodo.valorDerecho.nombre) == -1))
                    //si el dato a insertar es mayor que el dato izquierdo del nodo, pero menor que el dato derecho del nodo
                    {
                        var temporal = insertar(dato, nodo.hijoMedio);
                    }
                    else
                    {//si el dato a insertar es mayor que ambos datos del nodo
                        var temporal = insertar(dato, nodo.hijoDerecho);
                    }
                }
            }
            return null;
        }
    }
}
