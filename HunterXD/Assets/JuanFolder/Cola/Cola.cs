using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cola : MonoBehaviour, ColaTDA
{
    [SerializeField] private int CantidadCola;
    [SerializeField] private int indice;
    [SerializeField] public GameObject[] objetosCola;
    //int[] a; // arreglo en donde se guarda la informacion
    //int indice; // variable entera en donde se guarda la cantidad de elementos que se tienen guardados

    public void InicializarCola(int cantidad)
    {
        objetosCola = new GameObject[cantidad];
        indice = 0;
    }
    public void Acolar(GameObject x)
    {
        if (indice < CantidadCola)
        {
            for (int i = indice - 1; i >= 0; i--)
            {
                objetosCola[i + 1] = objetosCola[i];
            }
            objetosCola[0] = x;
            indice++;
        }
    }
    public int Desacolar()
    {
        if (!ColaVacia())
        {
            objetosCola[indice-1] = null;
            indice--;
            return indice;
        }
        else
        {
            return 0;
        }
    }

    public bool ColaVacia()
    {
        return (indice == 0);
    }

    public GameObject Primero()
    {
        return objetosCola[indice - 1];
    }

}
public interface ColaTDA
{
    void InicializarCola(int cantidad); //siempre que la cola este inicializada
    void Acolar(GameObject x); //siempre que la cola este inicializada y no este vacia
    int Desacolar(); //siempre que la cola este inicializada
    bool ColaVacia(); //siempre que la cola este inicializada y no este vacia
    GameObject Primero();
}
