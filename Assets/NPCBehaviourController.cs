using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPCBehaviourController : MonoBehaviour
{
    [SerializeField] private bool hostile;
    [SerializeField] private float aggroDistance;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float pursuitMaxDistance;
    private Vector3 spawnPoint;

    public bool Hostile { get => hostile; set => hostile = value; }
    public float AggroDistance { get => aggroDistance; set => aggroDistance = value; }
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public float PursuitMaxDistance { get => pursuitMaxDistance; set => pursuitMaxDistance = value; }
    public Vector3 SpawnPoint { get => spawnPoint; set => spawnPoint = value; }

    private void Awake()
    {
        spawnPoint = transform.position;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, aggroDistance);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(spawnPoint, pursuitMaxDistance);
    }
}
