using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABB : MonoBehaviour, ABBTDA
{
    public List<float> PlatformValues;
    public NodoABB raiz;

    public float Raiz()
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

    public void AgregarElem(ref NodoABB raiz, float x)
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

    public void EliminarElem(ref NodoABB raiz, float x)
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

    public float Mayor(NodoABB a)
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

    public float Menor(NodoABB a)
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
    
    public void preOrder(NodoABB a)
    {
        if (a != null)
        {
            Debug.Log(a.info.ToString());
            PlatformValues.Add(a.info);
            preOrder(a.hijoIzq);
            preOrder(a.hijoDer);
        }
    }

    public void inOrder(NodoABB a)
    {
        if (a != null)
        {
            inOrder(a.hijoIzq);
            Debug.Log(a.info.ToString());
            PlatformValues.Add(a.info);
            inOrder(a.hijoDer);
        }
    }

    public void postOrder(NodoABB a)
    {
        if (a != null)
        {
            postOrder(a.hijoIzq);
            postOrder(a.hijoDer);
            Debug.Log(a.info.ToString());
            PlatformValues.Add(a.info);
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
    public float info;
    
    public NodoABB hijoIzq = null;
    public NodoABB hijoDer = null;
}
public interface ABBTDA
{
    float Raiz();
    NodoABB HijoIzq();
    NodoABB HijoDer();
    bool ArbolVacio();
    void InicializarArbol();
    void AgregarElem(ref NodoABB n, float x);
    void EliminarElem(ref NodoABB n, float x);
}
