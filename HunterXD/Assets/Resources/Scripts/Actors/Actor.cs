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
    private static IActorUIManagerProvider uiProvider => UIManager.Instance;
    [SerializeField] private string actorID;
    #endregion
    
    #region PUBLIC_PROPERTIES

    public int MaxLife => _stats.MaxLife;
    public int CurrentLife => _currentLife;
    #endregion

    public SimpleFlash sf;
    private void Start()
    {
        _currentLife = _stats.MaxLife;
        sf=GetComponent<SimpleFlash>();
    }

    #region IDamagable_Methods
    public void TakeDamage(int damage)
    {
        _currentLife -= damage;
        uiProvider.ActorUIManager.UpdateActorHealth(actorID, _currentLife);
        sf.Flash();
    }
    public void GetLife(int value)
    {
        if (_currentLife <5)
        {
            _currentLife += value;
        }
        uiProvider.ActorUIManager.UpdateActorHealth(actorID, _currentLife);
    }
    #endregion
}
