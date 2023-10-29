using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Actor : MonoBehaviour, IDamagable
{
    #region PRIVATE_PROPERTIES

    [SerializeField] protected ActorStats _stats;
    [SerializeField] protected int _currentLife;
    #endregion
    
    #region PUBLIC_PROPERTIES

    public int MaxLife => _stats.MaxLife;
    public int CurrentLife => _currentLife;
    #endregion

    private void Start()
    {
        _currentLife = _stats.MaxLife;
    }

    #region IDamagable_Methods
    public void TakeDamage(int damage)
    {
        _currentLife -= damage;
        Debug.Log("OUCH! " + _currentLife);
        if (_currentLife <= 0)
        {
            Debug.Log("MUERTE");
        }
    }
    #endregion
}
