using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleBehaviour : NPCBaseBehaviour
{
    [SerializeField] private bool hostile;
    [SerializeField] private float aggroDistance;
    private Vector3 spawnPoint;


    public bool Hostile { get => hostile; set => hostile = value; }
    public float AggroDistance { get => aggroDistance; set => aggroDistance = value; }
    public Vector3 SpawnPoint { get => spawnPoint; set => spawnPoint = value; }


    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, aggroDistance);
    }

    public bool IsTargetInAggroDistance(Transform target)
    {
        return Vector3.Distance(target.position, transform.position) <= aggroDistance;
    }
}
