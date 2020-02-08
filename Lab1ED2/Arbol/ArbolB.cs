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
        public List<SodaClass> contenidoArbol = new List<SodaClass>();
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
                        nodo.valorDerecho = nodo.valorIzquierdo;
                        nodo.valorIzquierdo = dato;
                    }
                    else
                    {
                        nodo.valorDerecho = dato;
                    }
                    return null;
                }
                else
                {
                    //Tiene que subir
                    if (nodo.valorDerecho.nombre.CompareTo(dato.nombre) == -1)
                    {//Para que  suba el valor medio, en este caso seria el que tenia como dato derecho el nodo hoja
                        var nuevoParaSubir = new Nodo();//creas el nodo que va a subir
                        var partirActual = new Nodo();
                        nuevoParaSubir.valorIzquierdo = nodo.valorDerecho;//le asignas el valor medio
                        partirActual.valorIzquierdo = dato;
                        nodo.valorDerecho = null;//cambias por el valor que se inserto
                        //se le asignan los valores a los hijos que son producto de la particion del actual
                        nuevoParaSubir.hijoIzquierdo = nodo;
                        nuevoParaSubir.hijoMedio = partirActual;


                        return nuevoParaSubir;
                    }
                    //nodo.valorIzquierdo.nombre > dato.nombre
                    else if (nodo.valorIzquierdo.nombre.CompareTo(dato.nombre) == 1)//Va a tener que subir el que tenia como dato izquierdo
                    {
                        var nuevoParaSubir = new Nodo();//creas el nodo que va a subir
                        var partirActual = new Nodo();
                        partirActual.valorIzquierdo = nodo.valorDerecho;
                        nodo.valorDerecho = null;
                        nuevoParaSubir.valorIzquierdo = nodo.valorIzquierdo;//le asignas el valor medio
                        nodo.valorIzquierdo = dato;//cambias por el valor que se inserto
                        //se le asignan los valores a los hijos que son producto de la particion del actual
                        nuevoParaSubir.hijoIzquierdo = nodo;
                        nuevoParaSubir.hijoMedio = partirActual;


                        return nuevoParaSubir;
                    }
                    else
                    { //tiene que subir el dato actual
                        var nuevoParaSubir = new Nodo();//creas el nodo que va a subir
                        nuevoParaSubir.valorIzquierdo = dato;//le asignas el valor medio
                        var partirActual = new Nodo();
                        partirActual.valorIzquierdo = nodo.valorDerecho;
                        //se le asignan los valores a los hijos que son producto de la particion del actual
                        nodo.valorDerecho = null;
                        nuevoParaSubir.hijoIzquierdo = nodo;
                        nuevoParaSubir.hijoMedio = partirActual;
                        ////*********************
                        return nuevoParaSubir;
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
                        if (temp != null)
                        {
                            nodo.valorDerecho = temp.valorIzquierdo;
                            nodo.hijoMedio = temp.hijoIzquierdo;
                            nodo.hijoDerecho = temp.hijoMedio;
                        }
                        return null;//como ya se lleno el nodo no tiene que seguir subiendo nada
                    }
                    else
                    {
                        var temp = insertar(dato, nodo.hijoIzquierdo);//busca en el hijo izquierdo y guarda lo que este le retorne
                        if (temp != null)
                        {
                            nodo.valorDerecho = nodo.valorIzquierdo;//para que el mayor siempre quede del lado derecho
                            nodo.valorIzquierdo = temp.valorIzquierdo;//Se agrega el dato que subio
                            nodo.hijoIzquierdo = temp.hijoIzquierdo;//como el dato subio por la izquierda el hijo izquierdo del dato se mantiene
                            nodo.hijoDerecho = nodo.hijoMedio;//ya que el nodo actual tenia 2 hijos y ahora tendra 3 todo lo que tenia en ese 2do hijo tiene que moverse hasta la derecha
                            nodo.hijoMedio = temp.hijoMedio;//los nodos que traiga temporal como medios o mayores, seran los nuevos hijos del medio ya que el valor derecho del actual siempre sera mayor a estos
                        }
                        return null;//como ya se lleno el nodo no tiene que seguir subiendo nada
                    }
                }
                else//si el nodo actual ya esta lleno, es decir tiene sus 2 valores ocupados
                {
                    //nodo.valorIzquierdo > dato
                    if (dato.nombre.CompareTo(nodo.valorIzquierdo.nombre) == -1)//si el dato es menor que el dato izquierdo del nodo
                    {
                        var temporal = insertar(dato, nodo.hijoIzquierdo);
                        if (temporal != null)
                        {
                            var nodoParaSubir = new Nodo();
                            nodoParaSubir.valorIzquierdo = nodo.valorIzquierdo;
                            nodoParaSubir.hijoIzquierdo = temporal;
                            nodo.valorIzquierdo = nodo.valorDerecho;
                            nodo.valorDerecho = null;//Para liberarle el espacio
                            nodo.hijoIzquierdo = nodo.hijoMedio;
                            nodo.hijoMedio = nodo.hijoDerecho;
                            nodo.hijoDerecho = null;
                            nodoParaSubir.hijoMedio = nodo;
                            return nodoParaSubir;
                        }
                        else
                        {
                            return null;
                        }

                    }
                    //nodo.valorIzquierdo.nombre < dato.nombre && dato.nombre < nodo.valorDerecho.nombre
                    //(dato.nombre.CompareTo(nodo.valorIzquierdo.nombre) == 1) && (dato.nombre.CompareTo(nodo.valorDerecho.nombre) == -1)
                    else if ((dato.nombre.CompareTo(nodo.valorDerecho.nombre) == -1))
                    //si el dato a insertar es mayor que el dato izquierdo del nodo, pero menor que el dato derecho del nodo
                    {
                        var temporal = insertar(dato, nodo.hijoMedio);
                        if (temporal != null)
                        {
                            var nodoParaSubir = new Nodo();
                            nodoParaSubir.valorIzquierdo = temporal.valorIzquierdo;
                            var partirActual = new Nodo();
                            partirActual.valorIzquierdo = nodo.valorDerecho;
                            partirActual.hijoMedio = nodo.hijoDerecho;
                            partirActual.hijoIzquierdo = temporal.hijoMedio;
                            nodo.valorDerecho = null;
                            nodo.hijoDerecho = null;
                            nodoParaSubir.hijoIzquierdo = nodo;
                            nodo.hijoMedio = temporal.hijoIzquierdo;
                            nodoParaSubir.hijoMedio = partirActual;
                            partirActual.hijoIzquierdo = temporal.hijoMedio;
                            return nodoParaSubir;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {//si el dato a insertar es mayor que ambos datos del nodo
                        var temporal = insertar(dato, nodo.hijoDerecho);
                        if (temporal != null)
                        {
                            var nodoParaSubir = new Nodo();
                            nodoParaSubir.valorIzquierdo = nodo.valorDerecho;
                            nodo.hijoDerecho = null;
                            nodo.valorDerecho = null;
                            nodoParaSubir.hijoIzquierdo = nodo;
                            nodoParaSubir.hijoMedio = temporal;
                            return nodoParaSubir;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public string InOrden()
        {
            string contenido = null;
            contenidoArbol.RemoveAll(x => 0 == contenidoArbol.Count());
            var nodos = Recorrido(raiz);
            if (nodos != null)
            {
                foreach (var item in nodos)
                {
                    var mostrar = "-------------\n" + "Nombre: " + item.nombre + "\n" + "Sabor: " + item.sabor + "\n" + "Volumen: " + item.volumen + "\n" + "Precio: " + item.precio + "\n" + "Casa productora: " + item.productora + "\n" + "-----------------\n";
                    contenido += mostrar;
                }
            }
            else
            {
                contenido = "Arbol vacio";
            }

            return contenido;
        }
        public List<SodaClass> Recorrido(Nodo nodo)
        {

            if (nodo != null)
            {
                Recorrido(nodo.hijoIzquierdo);
                contenidoArbol.Add(nodo.valorIzquierdo);
                Recorrido(nodo.hijoMedio);
                if (nodo.valorDerecho != null)
                {
                    contenidoArbol.Add(nodo.valorDerecho);
                    Recorrido(nodo.hijoDerecho);
                }
            }
            return contenidoArbol;
        }

    }
}
