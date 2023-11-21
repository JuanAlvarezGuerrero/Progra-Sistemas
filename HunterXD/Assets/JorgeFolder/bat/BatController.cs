using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class BatController : MonoBehaviour
{
    private int index = 0;
    [SerializeField] private List<int> result;
    [SerializeField] private float _batSpeed =2f;
    private GrafoMA _grafoTda;
    public bool _finishTravel;
    public int _nodeOrigin;
    public Transform[] NodesPosition;
    private void Start()
    {
        
        //NodesPosition = new Transform[9];
        _nodeOrigin = 1;
        _grafoTda = new GrafoMA();
        _grafoTda.InicializarGrafo();
        int[] vertices = {1,2,3,4,5,6,7,8,9};
        for (int i = 0; i < vertices.Length; i++)
        {
            _grafoTda.AgregarVertice(vertices[i]);
        }

        int[] aristas_origen =  { 1, 1, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 7, 7, 8, 8, 8, 9, 9};
        int[] aristas_destino = { 2, 4, 1, 3, 5, 2, 6, 1, 5, 7, 4, 2, 6, 8, 3, 5, 9, 4, 8, 5, 7, 9, 6, 8};
        int[] aristas_pesos =   { 9, 9, 9, 2, 3, 1, 3, 9, 4, 6, 3, 1, 3, 3, 2, 2, 4, 2, 1, 2, 3, 1, 2, 1};

        for (int i = 0; i < aristas_pesos.Length; i++)
        {
            _grafoTda.AgregarArista(aristas_origen[i], aristas_destino[i], aristas_pesos[i]);
        }
        result = Dijkstra.RunDijkstra2(_grafoTda, _nodeOrigin);
        for (int i = 0; i < result.Count; i++)
        {
            Debug.Log(result[i]);
        }
    }

    private void Update()
    {
        
        if (_finishTravel)
        {
            int origin = Random.Range(0, 8);
            result = Dijkstra.RunDijkstra2(_grafoTda, origin);
            _finishTravel = false;
        }
        else
        {
            if (Vector3.Distance(NodesPosition[result[index]].position, transform.position) > 0.05f)
            {
                Transform vista = NodesPosition[result[index]];
                Vector3 dir = vista.position - transform.position;
                dir.z = 0;
                dir.Normalize();
                //Girar(vista);
                BatMove(dir);
            }
            else
            {
                index++;
                if (index >= NodesPosition.Length)
                {
                    index = 0;
                    _finishTravel = true;
                }
            }
        }
    }

    void BatMove(Vector3 destiny)
    {
        if (!_finishTravel)
        {
            transform.position += destiny *_batSpeed*Time.deltaTime;
        }
    }



}
