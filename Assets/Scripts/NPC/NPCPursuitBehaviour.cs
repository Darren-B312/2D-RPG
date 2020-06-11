using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPCPursuitBehaviour : NPCBaseBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float pursuitMaxDistance;
    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponent<NPCIdleBehaviour>().SpawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnPoint != GetComponent<NPCIdleBehaviour>().SpawnPoint)
        {
            spawnPoint = GetComponent<NPCIdleBehaviour>().SpawnPoint;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(spawnPoint, pursuitMaxDistance);
    }

    public void PursueTarget(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed *  Time.deltaTime);
    }

    public bool IsOutOfPursuitRange()
    {
        return Vector3.Distance(transform.position, spawnPoint) >= pursuitMaxDistance;
    }
}
