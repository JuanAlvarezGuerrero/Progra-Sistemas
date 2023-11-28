using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private List<Waypoint> m_waypoints = new List<Waypoint>();

    bool Contains(Waypoint p_waypoint)
    {
        return m_waypoints.Contains(p_waypoint);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);

        foreach (var l_waypoint in m_waypoints)
        {
            Gizmos.color = Color.blue;
            if (l_waypoint.Contains(this))
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawLine(transform.position, l_waypoint.transform.position);
        }
    }
}
