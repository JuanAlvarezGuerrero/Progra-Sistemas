using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ABB : ABBTDA
{
    /*Implementación en una ConsoleApp*/
    /*
     // Arboles Binarios de Búsqueda
            Console.WriteLine("Programa Iniciado\n");

            int[] vectorEnteros = { 20, 10, 1, 26, 35, 40, 18, 12, 15, 14, 30, 23 };

            // creo un TDA ABB
            ABB arbol = new ABB();
            arbol.InicializarArbol();

            // agrego los mismos elementos del vector al arbol
            for (int i = 0; i < vectorEnteros.Length; i++)
            {
                arbol.AgregarElem(ref arbol.raiz, vectorEnteros[i]);
            }

            // Altura total
            int aTotal = altura(arbol.raiz);
            Console.WriteLine("\nAltura total del arbol: " + aTotal.ToString());

            // Pre-Order
            Console.WriteLine("\nImpresión en Pre-Order");
            preOrder(arbol.raiz);

            // In-Order
            Console.WriteLine("\nImpresión en In-Order");
            inOrder(arbol.raiz);

            // Post-Order
            Console.WriteLine("\nImpresión en Post-Order");
            postOrder(arbol.raiz);

            // Level-Order
            Console.WriteLine("\nImpresión en Level-Order");
            levelOrder(arbol.raiz);

            // Alturas con Pre-Order
            Console.WriteLine("\nAlturas recorriendo con Pre-Order");
            preOrder_FE(arbol.raiz);

            Console.ReadKey();
     */
    public NodoABB raiz;

    public int Raiz()
    {
        return raiz.info;
    }

    public bool ArbolVacio()
    {
        return (raiz == null);
    }

    public void InicializarArbol()
    {
        raiz = null;
    }

    public NodoABB HijoDer()
    {
        return raiz.hijoDer;
    }

    public NodoABB HijoIzq()
    {
        return raiz.hijoIzq;
    }

    public void AgregarElem(ref NodoABB raiz, int x)
    {
        if (raiz == null)
        {
            raiz = new NodoABB();
            raiz.info = x;
        }
        else if (raiz.info > x)
        {
            AgregarElem(ref raiz.hijoIzq, x);
        }
        else if (raiz.info < x)
        {
            AgregarElem(ref raiz.hijoDer, x);
        }
    }

    public void EliminarElem(ref NodoABB raiz, int x)
    {
        if (raiz != null)
        {
            if (raiz.info == x && (raiz.hijoIzq == null) && (raiz.hijoDer == null))
            {
                raiz = null;
            }
            else if (raiz.info == x && raiz.hijoIzq != null)
            {
                raiz.info = this.Mayor(raiz.hijoIzq);
                EliminarElem(ref raiz.hijoIzq, raiz.info);
            }
            else if (raiz.info == x && raiz.hijoIzq == null)
            {
                raiz.info = this.Menor(raiz.hijoDer);
                EliminarElem(ref raiz.hijoDer, raiz.info);
            }
            else if (raiz.info < x)
            {
                EliminarElem(ref raiz.hijoDer, x);
            }
            else
            {
                EliminarElem(ref raiz.hijoIzq, x);
            }
        }
    }

    public int Mayor(NodoABB a)
    {
        if (a.hijoDer == null)
        {
            return a.info;
        }
        else
        {
            return Mayor(a.hijoDer);
        }
    }

    public int Menor(NodoABB a)
    {
        if (a.hijoIzq == null)
        {
            return a.info;
        }
        else
        {
            return Menor(a.hijoIzq);
        }
    }

    static int altura(NodoABB ab)
    {
        if (ab == null)
        {
            return -1;
        }
        else
        {
            return (1 + Math.Max(altura(ab.hijoIzq), altura(ab.hijoDer)));
            /*return (1 + Mathf.Max(altura(ab.hijoIzq), altura(ab.hijoDer)));*/
            /*return 0; esto es provisorio, borrar cuando se haya encontrado la solución de la linea de arriba.*/
        }
    }

    static void preOrder_FE(NodoABB a)
    {
        if (a != null)
        {
            // accion mientras recorro //
            Debug.Log("Nodo Padre: " + a.info.ToString());
            Debug.Log("Altura Izquierda: " + altura(a.hijoDer));
            Debug.Log("Altura Derecha: " + altura(a.hijoIzq));
            //                         //

            preOrder_FE(a.hijoIzq);
            preOrder_FE(a.hijoDer);
        }
    }

    static void preOrder(NodoABB a)
    {
        if (a != null)
        {
            Debug.Log(a.info.ToString());
            preOrder(a.hijoIzq);
            preOrder(a.hijoDer);
        }
    }

    static void inOrder(NodoABB a)
    {
        if (a != null)
        {
            inOrder(a.hijoIzq);
            Debug.Log(a.info.ToString());
            inOrder(a.hijoDer);
        }
    }

    static void postOrder(NodoABB a)
    {
        if (a != null)
        {
            postOrder(a.hijoIzq);
            postOrder(a.hijoDer);
            Debug.Log(a.info.ToString());
        }
    }

    static void level_Order(NodoABB nodo)
    {
        Queue<NodoABB> q = new Queue<NodoABB>();

        q.Enqueue(nodo);

        while (q.Count > 0)
        {
            nodo = q.Dequeue();

            Debug.Log(nodo.info.ToString());

            if (nodo.hijoIzq != null) { q.Enqueue(nodo.hijoIzq); }

            if (nodo.hijoDer != null) { q.Enqueue(nodo.hijoDer); }
        }
    }

    static void levelOrder(NodoABB nodo)
    {
        Queue<NodoABB> q = new Queue<NodoABB>();

        q.Enqueue(nodo);

        while (q.Count > 0)
        {
            nodo = q.Dequeue();

            Debug.Log("Padre: " + nodo.info.ToString());

            if (nodo.hijoIzq != null)
            {
                q.Enqueue(nodo.hijoIzq);
                Debug.Log("Hijo Izq: " + nodo.hijoIzq.info.ToString());
            }
            else
            {
                Debug.Log("Hijo Izq: null");
            }

            if (nodo.hijoDer != null)
            {
                q.Enqueue(nodo.hijoDer);
                Debug.Log("Hijo Der: " + nodo.hijoDer.info.ToString());
            }
            else
            {
                Debug.Log("Hijo Der: null");
            }
        }
    }
}
public class NodoABB
{
    // datos a almacenar, en este caso un entero
    public int info;
    // referencia los nodos izquiero y derecho
    public NodoABB hijoIzq = null;
    public NodoABB hijoDer = null;
}
public interface ABBTDA
{
    int Raiz();
    NodoABB HijoIzq();
    NodoABB HijoDer();
    bool ArbolVacio();
    void InicializarArbol();
    void AgregarElem(ref NodoABB n, int x);
    void EliminarElem(ref NodoABB n, int x);
}
