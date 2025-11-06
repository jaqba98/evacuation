using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour {
    public NavMeshAgent agent;
    public SimulationStore simulationStore;

    [Header("Speed Settings")]
    public float calmSpeed = 3.5f;
    public float panicSpeed = 7.5f;

    private Transform target;
    private bool hasReachedDestination = false;
    private bool isPanicking = false;

    void Start() {
        isPanicking = Random.value < simulationStore.panic;
        if (agent != null) {
            agent.speed = isPanicking ? panicSpeed : calmSpeed;
        }
        DisableAllChildrenExceptRandom();
    }

    void Update() {
        if (target == null || agent == null) return;
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (!hasReachedDestination && distanceToTarget <= 2f) {
            hasReachedDestination = true;
            simulationStore.survivors++;
            Destroy(gameObject);
        }
    }

    public void TrySetDestination() {
        if (agent == null || simulationStore == null || simulationStore.exits == null || simulationStore.exits.Count == 0) return;
        GameObject nearestExit = null;
        float nearestDistance = Mathf.Infinity;
        foreach (GameObject exit in simulationStore.exits) {
            if (exit == null) continue;
            float distance = Vector3.Distance(transform.position, exit.transform.position);
            if (distance < nearestDistance) {
                nearestDistance = distance;
                nearestExit = exit;
            }
        }
        if (nearestExit != null) {
            target = nearestExit.transform;
            hasReachedDestination = false;
            agent.SetDestination(target.position);
        }
    }

    private void DisableAllChildrenExceptRandom() {
        int childCount = transform.childCount;
        if (childCount == 0) return;
        for (int i = 0; i < childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        int randomIndex = Random.Range(0, childCount);
        transform.GetChild(randomIndex).gameObject.SetActive(true);
    }
}
