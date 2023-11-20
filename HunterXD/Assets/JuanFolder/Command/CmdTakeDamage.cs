using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdTakeDamage : ICommand
{
    private IDamagable _victim;
    private int _damage;

    public CmdTakeDamage(IDamagable victim, int damage)
    {
        _victim = victim;
        _damage = damage;
    }

    public void Do()
    {
        _victim.TakeDamage(_damage);
    }
}
