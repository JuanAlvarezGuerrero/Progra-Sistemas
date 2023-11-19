using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quicksort : MonoBehaviour
{
    /*Implementación en una ConsoleApp*/
    /*
      // creo el vector de enteros para ordenar
            //int[] vectorEnteros = { 67, 12, 95, 56, 85, 1, 100, 23, 60, 9 };
 
            Player[] arrayPlayer = new Player[10];
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                arrayPlayer[i] = new Player();
                arrayPlayer[i].name = "Player_" + i.ToString();
                arrayPlayer[i].score = rnd.Next(1, 100);
            }
 
            Console.WriteLine("Inicio Programa: Quick Sort");
 
            // muestro vector desordenado
            Console.Write("\nLista Desordenada: ");
            imprimirVector(arrayPlayer);
 
            // algoritmo de ordenamiento
            // inicialmente los parametros left y right son los extremos del vector
            quickSort(arrayPlayer, 0, arrayPlayer.Length - 1);
 
            // muestro vector ordenado
            Console.Write("\nLista Ordenada: ");
            imprimirVector(arrayPlayer);
 
            Console.ReadKey();
     */
    public void RunQuicksort(GameObject[] arr, int left, int right)
    {
        int pivot;
        if (left < right)
        {
            pivot = Partition(arr, left, right);

            if (pivot > 1)
            {
                // mitad del lado izquierdo del vector
                RunQuicksort(arr, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                // mitad del lado derecho del vector
                RunQuicksort(arr, pivot + 1, right);
            }
        }
    }
    public int Partition(GameObject[] arr, int left, int right)
    {
        float pivot;
        int aux = (left + right) / 2;   //tomo el valor central del vector
        pivot = arr[aux].transform.localScale.y;

        // en este ciclo debo dejar todos los valores menores al pivot
        // a la izquierda y los mayores a la derecha
        while (true)
        {
            while (arr[left].transform.localScale.y < pivot)
            {
                left++;
            }
            while (arr[right].transform.localScale.y > pivot)
            {
                right--;
            }
            if (left < right)
            {
                GameObject temp = arr[right];
                arr[right] = arr[left];
                arr[left] = temp;
            }
            else
            {
                // este es el valor que devuelvo como proxima posicion de
                // la particion en el siguiente paso del algoritmo
                return right;
            }
        }
    }
    static void imprimirVector(Player[] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Debug.Log(vec[i].name + " " + vec[i].score);
        }
    }
}

public class Player
{
    public string name;
    public int score;
}
