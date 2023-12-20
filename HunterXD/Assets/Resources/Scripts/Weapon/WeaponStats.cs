using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Stats/WeaponStats", order = 4)]
public class WeaponStats : ScriptableObject
{
    [field: SerializeField] public GameObject Arrow { get; private set; }
    [field: SerializeField] public Sprite SpecialArrow { get; private set; }
}
