using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleABB : MonoBehaviour
{
    ABB arbol = new ABB();
    [SerializeField] private List<GameObject> objetos;
    // Start is called before the first frame update
    void Start()
    {
        arbol.InicializarArbol();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < objetos.Count; i++)
        {
            //arbol.AgregarElem(ref arbol.raiz, objetos[i]);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjetoPuzzle"))
        {
            objetos.Add(collision.gameObject);
        }
    }
}
