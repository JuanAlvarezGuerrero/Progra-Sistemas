using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    private ArrowFactory _arrowFactory;
    public WeaponStats WeaponStats => _weaponStats;
    //public GameObject Bullet => _bullet;

    public int Damage => _damage;

    public int MagSize => _magSize;

    //[SerializeField] protected GameObject _bullet;
    [SerializeField] protected int _damage;
    [SerializeField] protected int _magSize;
    [SerializeField] protected int _bulletCount;
    [SerializeField] private WeaponStats _weaponStats;
    //[SerializeField] private WeaponShootBehavior shootBehavior;

    private void Start()
    {
        BasicArrow currentArrow = _weaponStats.Arrow.GetComponent<BasicArrow>();
        _arrowFactory = new ArrowFactory(currentArrow);
    }

    public virtual void Shoot()
    {
        IProduct arrow = _arrowFactory.CreateProduct();
        GameObject arrowObject = arrow.MyGameObject;
        arrowObject.transform.position = transform.position;
        arrowObject.transform.rotation = transform.rotation;
        arrowObject.GetComponent<BasicArrow>().SetOwner(this);
    }

    public void ChangeArrow()
    {
        throw new System.NotImplementedException();
    }
    
}
