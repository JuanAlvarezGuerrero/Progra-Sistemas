using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicArrow : MonoBehaviour, IArrow
{
    public void Travel()
    {
        
    }

    public void Damage(IActor actor, int dmg)
    {
        throw new System.NotImplementedException();
    }
}
