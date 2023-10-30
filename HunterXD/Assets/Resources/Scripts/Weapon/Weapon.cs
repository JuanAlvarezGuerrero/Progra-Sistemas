using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    public WeaponStats WeaponStats => _weaponStats;
    public GameObject Bullet => _bullet;

    public int Damage => _damage;

    public int MagSize => _magSize;

    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected int _damage;
    [SerializeField] protected int _magSize;
    [SerializeField] protected int _bulletCount;
    [SerializeField] private WeaponStats _weaponStats;
    //[SerializeField] private WeaponShootBehavior shootBehavior;

    public virtual void Shoot()
    {
        Debug.Log("Shoot");
    }

    public void ChangeArrow()
    {
        throw new System.NotImplementedException();
    }
    public void Reload() => _bulletCount = _magSize;
}
