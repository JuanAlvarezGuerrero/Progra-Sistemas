using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pila : MonoBehaviour, PilaTDA
{
    // arreglo en donde se guarda la informacion
    [SerializeField] private List<GameObject> objetosPuzzle = new List<GameObject>();
    // cantidad de anillos de datos de la pila
    int cantidad_datos_max=3;
    int indice;
    
    public void InicializarPila()
    {
        objetosPuzzle = new List<GameObject>(cantidad_datos_max);
        indice = 0;
    }

    public void Apilar(GameObject elemento)
    {
        if (!PilaLlena())
        {
            indice++;
            objetosPuzzle[indice] = elemento;
        }
        else
        {
            Debug.Log("La pila está llena");
        }

    }
    public void Desapilar()
    {
        if (!PilaVacia())
        {
            indice--;
        }
        else
        {
            return;
        }

    }

    public bool PilaVacia()
    {
        return indice==0;
    }

    public bool PilaLlena()
    {
        return indice==cantidad_datos_max-1;
    }
}
public interface PilaTDA
{
    void InicializarPila(); //siempre que la pila este inicializada
    void Apilar(GameObject elemento); //siempre que la pila este inicializada y no este vacia
    void Desapilar(); //siempre que la pila este inicializada
    bool PilaVacia(); //siempre que la pila este inicializada y no este vacia
    bool PilaLlena();
}
