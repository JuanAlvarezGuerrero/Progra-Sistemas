using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    private ArrowFactory _arrowFactory;
    public WeaponStats WeaponStats => _weaponStats;

    public int Damage => _damage;

    public int MagSize => _magSize;
    
    [SerializeField] protected int _damage;
    [SerializeField] protected int _magSize;
    [SerializeField] private WeaponStats _weaponStats;
    [SerializeField] private float _damageBoost;
    [SerializeField] private bool _applyDamage;

    private void Start()
    {
        BasicArrow currentArrow = _weaponStats.Arrow.GetComponent<BasicArrow>();
        _arrowFactory = new ArrowFactory(currentArrow);
    }
    private void Update()
    {
        _damageBoost -= Time.deltaTime;

        if (_damageBoost <= 0)
        {
            _damage = 1;
        }
    }
    public virtual void Shoot()
    {
        IProduct arrow = _arrowFactory.CreateProduct();
        GameObject arrowObject = arrow.MyGameObject;
        arrowObject.transform.position = transform.position;
        arrowObject.transform.rotation = transform.rotation;
        arrowObject.GetComponent<BasicArrow>().SetOwner(this);
    }
    public virtual void SpecialShoot()
    {
        _damage = 4;
        IProduct arrow = _arrowFactory.CreateProduct();
        GameObject arrowObject = arrow.MyGameObject;
        arrowObject.GetComponent<SpriteRenderer>().sprite = _weaponStats.SpecialArrow;
        arrowObject.transform.position = transform.position;
        arrowObject.transform.rotation = transform.rotation;
        arrowObject.GetComponent<BasicArrow>().SetOwner(this);
        _damageBoost = 1.5f;
    }
}
