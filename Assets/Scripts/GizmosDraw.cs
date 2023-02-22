using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosDraw : MonoBehaviour
{
    [SerializeField]
    public GameObject[] _agentSpawnPoints;

    private void OnDrawGizmos()
    {
        foreach (var spawn in _agentSpawnPoints)
        {
            Gizmos.DrawIcon(spawn.transform.position, "spawn.png", true); ;
        }
    }
}
