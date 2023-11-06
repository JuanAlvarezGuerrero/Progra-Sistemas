using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ArrowStats", menuName = "Stats/ArrowStats", order = 5)]
public class ArrowStats : ScriptableObject
{
    [SerializeField] private ArrowStatValues _statsArrow;
    public float Speed => _statsArrow.Speed;
    public float LifeTime => _statsArrow.LifeTime;
    public LayerMask HitteableLayer => _statsArrow.HitteableLayer;
}
[System.Serializable]
public struct ArrowStatValues
{
    public float Speed;
    public float LifeTime;
    public LayerMask HitteableLayer;
}
