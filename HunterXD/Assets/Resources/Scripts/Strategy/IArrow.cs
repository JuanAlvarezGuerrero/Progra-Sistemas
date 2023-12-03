using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IArrow:IProduct
{
    float Speed { get; }
    float LifeTime { get; }
    LayerMask HitteableLayer { get; }
    IWeapon Owner { get; }
    void Init();
    void Travel();
    void SetOwner(IWeapon weapon);
}
