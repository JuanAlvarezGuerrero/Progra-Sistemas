using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LumberjacStats", menuName = "Stats/LumberjacStats", order = 6)]
public class LumberjacStats : ActorStats
{
    [SerializeField] private LumberjacStatValues _statsLumberjac;
    //public float Speed => _statsLumberjac.Speed;
    // public LayerMask GroundLayer => _statsLumberjac.GroundLayer;
    // public List<Transform> Waypoints => _statsLumberjac._waypoints;

}
[System.Serializable]
public struct LumberjacStatValues
{
    // public float Speed;
    // public LayerMask GroundLayer;
    // public List<Transform> _waypoints;
}