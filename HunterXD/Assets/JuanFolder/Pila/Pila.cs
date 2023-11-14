using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pila : PilaTDA
{
    // arreglo en donde se guarda la informacion
    int[] a;
    // cantidad de anillos de datos de la pila
    int cantidad_datos_max;

    public void InicializarPila(int cantidad)
    {
        cantidad_datos_max = cantidad;
        a = new int[cantidad];
        a[0] = 0;
    }

    public int Apilar(int x)
    {
        if (a[0] <= cantidad_datos_max)
        {
            a[0]++;
            a[a[0]] = x;
            return a[0];
        }
        else
        {
            return 0;
        }

    }
    public int Desapilar()
    {
        if (!PilaVacia())
        {
            a[0]--;
            return a[0];
        }
        else
        {
            return 0;
        }

    }

    public bool PilaVacia()
    {
        return (a[0] == 0);
    }

    public int Tope()
    {
        return a[a[0]];
    }
}
public interface PilaTDA
{
    void InicializarPila(int cantidad); //siempre que la pila este inicializada
    int Apilar(int x); //siempre que la pila este inicializada y no este vacia
    int Desapilar(); //siempre que la pila este inicializada
    bool PilaVacia(); //siempre que la pila este inicializada y no este vacia
    int Tope();
}
