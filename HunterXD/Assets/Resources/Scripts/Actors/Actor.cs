using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Actor : MonoBehaviour, IDamagable
{
    #region PRIVATE_PROPERTIES

    [SerializeField] private int _maxLife;
    [SerializeField] private int _currentLife;
    #endregion
    
    #region PUBLIC_PROPERTIES
    public int MaxLife => _maxLife;
    public int CurrentLife => _currentLife;
    #endregion

    private void Start()
    {
        _maxLife = 100;
        _currentLife = _maxLife;
    }
    private void Update()
    {
        
    }

    #region IDamagable_Methods
    public void TakeDamage(int damage)
    {
        _currentLife -= damage;
        if (_currentLife <= 0)
        {
            //die
        }
    }
    #endregion
}
