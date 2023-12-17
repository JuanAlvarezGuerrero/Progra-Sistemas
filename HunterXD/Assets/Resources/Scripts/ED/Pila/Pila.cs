using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pila : MonoBehaviour, PilaTDA
{
    int cantidad_datos_max=4;
    [SerializeField] private int indice;
    [SerializeField] private GameObject[] objetosPuzzle;
    public void InicializarPila(int cantidad)
    {
        cantidad_datos_max = cantidad;
        objetosPuzzle = new GameObject[cantidad];
        indice = 0;
    }

    public int Apilar(GameObject elemento)
    {
        if (indice<cantidad_datos_max)
        {
            for (int i = indice - 1; i >= 0; i--)
            {
                objetosPuzzle[i + 1] = objetosPuzzle[i];
            }
            objetosPuzzle[0] = elemento;
            indice++;
            return indice;
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
            //objetosPuzzle[0] = null;
            for (int i = 0; i < indice - 1; i++)
            {
                objetosPuzzle[i] = objetosPuzzle[i + 1];
            }
            objetosPuzzle[indice-1] = null;
            indice--;
            return indice;
        }
        else
        {
            return 0;
        }

    }

    public bool PilaVacia()
    {
        return (indice==0);
    }

    public GameObject Tope()
    {
        return objetosPuzzle[0];
    }
}
public interface PilaTDA
{
    void InicializarPila(int cantidad); //siempre que la pila este inicializada
    int Apilar(GameObject elemento); //siempre que la pila este inicializada y no este vacia
    int Desapilar(); //siempre que la pila este inicializada
    bool PilaVacia(); //siempre que la pila este inicializada y no este vacia
    GameObject Tope();
}
