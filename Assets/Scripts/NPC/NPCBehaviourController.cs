using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviourController : MonoBehaviour
{
    [SerializeField] private float patrolMovementSpeed = 2f;
    [SerializeField] private float patrolRadius = 4f;
    [SerializeField] private float patrolPauseTime = 2f;
    [SerializeField] private float patrolPauseTimer;
    [Space(10)]
    [SerializeField] private float aggroRange = 2f;
    [SerializeField] private float chaseMovementSpeed = 5f;
    [Space(10)]
    [SerializeField] private float meleeRange = 1f;
    public List<Vector3> PatrolPoints { get; set; } = new List<Vector3>();

    private void Start()
    {
        PatrolPoints = Utilities.CalculateSquarePerimeterPoints(transform.position, patrolRadius);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);
    }

    public float PatrolMovementSpeed
    {
        get => patrolMovementSpeed;
        set => patrolMovementSpeed = value;
    }
    public float PatrolRadius
    {
        get => patrolRadius;
        set => patrolRadius = value;
    }
    public float PatrolPauseTime
    {
        get => patrolPauseTime;
        set => patrolPauseTime = value;
    }
    public float PatrolPauseTimer
    {
        get => patrolPauseTimer;
        set => patrolPauseTimer = value;
    }
    public float AggroRange
    {
        get => aggroRange;
        set => aggroRange = value;
    }
    public float ChaseMovementSpeed
    {
        get => chaseMovementSpeed;
        set => chaseMovementSpeed = value;
    }
}
