using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LizzardStats", menuName = "Stats/LizzardStats", order = 2)]
public class LizzardStats : ActorStats
{
    [SerializeField] private LizzardStatValues _statsLizzard;
    public float Speed => _statsLizzard.Speed;
    //public float JumpingPower => _statsPlayer.JumpingPower;
    public LayerMask GroundLayer => _statsLizzard.GroundLayer;
}
[System.Serializable]
public struct LizzardStatValues
{
    public float Speed;
    //public float JumpingPower;
    public LayerMask GroundLayer;
}
