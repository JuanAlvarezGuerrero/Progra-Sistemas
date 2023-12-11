using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats/PlayerStats", order = 1)]
public class PlayerStats : ActorStats
{
    [SerializeField] private PlayerStatValues _statsPlayer;
    public float Speed => _statsPlayer.Speed;
    public float JumpingPower => _statsPlayer.JumpingPower;
    public LayerMask GroundLayer => _statsPlayer.GroundLayer;
    public float TimerShootArrow => _statsPlayer.TimerShootArrow;
}
[System.Serializable]
public struct PlayerStatValues
{
    public float Speed;
    public float JumpingPower;
    public LayerMask GroundLayer;
    public float TimerShootArrow;
}
