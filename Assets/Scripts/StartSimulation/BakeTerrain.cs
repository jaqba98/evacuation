using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class BakeTerrain : MonoBehaviour {
    public NavMeshSurface surfaceManager;

    public void Init() {
        StartCoroutine(RebuildAndNotify());
    }

    private IEnumerator RebuildAndNotify() {
        surfaceManager.BuildNavMesh();
        yield return null;
        NotifyAgents();
    }

    private void NotifyAgents() {
        Agent[] agents = FindObjectsOfType<Agent>();
        foreach (var agent in agents) {
            agent.TrySetDestination();
        }
    }
}
