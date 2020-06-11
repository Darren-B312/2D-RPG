using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRetreatBehaviour : NPCBaseBehaviour
{
    [SerializeField] float retreatMovementSpeed;
    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponent<NPCIdleBehaviour>().SpawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnPoint != GetComponent<NPCIdleBehaviour>().SpawnPoint)
        {
            spawnPoint = GetComponent<NPCIdleBehaviour>().SpawnPoint;
        }
    }

    public bool IsHome()
    {
        return Vector3.Distance(transform.position, spawnPoint) <= 0.01f;
    }

    public void Retreat()
    {
        transform.position = Vector3.MoveTowards(transform.position, spawnPoint, retreatMovementSpeed * Time.deltaTime);
    }
}
