using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizzardController : Actor, ILizzard
{
    private LizzardStats _lizzardStats;
    private List<Transform> _waypoints = new List<Transform>();

    private void Awake()
    {
        _lizzardStats = _stats as LizzardStats;
    }

    private void Update()
    {
        
    }


    public void Move(Vector2 dir)
    {
        
    }

    public void Attack()
    {
        //Attack Do()
    }

    private void InitializeLizzard()
    {
        
    }
}
