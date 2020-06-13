using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPCBehaviourController : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private float movementSpeed;

    [SerializeField] private bool attackable;
    [SerializeField] private float pursuitMaxDistance;

    [SerializeField] private bool hostile;
    [SerializeField] private float aggroDistance;

    [SerializeField] private bool patrol;
    [SerializeField] private float patrolRadius;
    [SerializeField] private float patrolPauseTime;
    [SerializeField] private float patrolPauseTimer;


    public Vector3 SpawnPoint { get => spawnPoint; set => spawnPoint = value; }
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }


    public bool Attackable { get => attackable; set => attackable = value; }
    public float PursuitMaxDistance { get => pursuitMaxDistance; set => pursuitMaxDistance = value; }


    public bool Hostile { get => hostile; set => hostile = value; }
    public float AggroDistance { get => aggroDistance; set => aggroDistance = value; }


    public bool Patrol { get => patrol; private set => patrol = value; }
    public float PatrolRadius { get => patrolRadius; set => patrolRadius = value; }
    public float PatrolPauseTime { get => patrolPauseTime; set => patrolPauseTime = value; }
    public float PatrolPauseTimer { get => patrolPauseTimer; set => patrolPauseTimer = value; }
    public List<Vector3> PatrolPoints { get; set; }


    private void Awake()
    {
        spawnPoint = transform.position;
        PatrolPoints = Utilities.CalculateSquarePerimeterPoints(spawnPoint, patrolRadius);
    }

    void Start()
    {

    }

    void Update()
    {
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, aggroDistance);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(spawnPoint, pursuitMaxDistance);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnPoint, new Vector3(patrolRadius*2, patrolRadius*2));
    }

    [CustomEditor(typeof(NPCBehaviourController))]
    private class NPCBehaviourControllerScriptEditor : Editor // https://answers.unity.com/questions/192895/hideshow-properties-dynamically-in-inspector.html
    {
        override public void OnInspectorGUI()
        {
            var script = target as NPCBehaviourController;

            script.spawnPoint = EditorGUILayout.Vector2Field("", script.spawnPoint); // Use Vector 2 field so z co-ordinate can't be messed with.

            GUILayout.Space(10);

            script.movementSpeed = EditorGUILayout.FloatField("Movement Speed", script.movementSpeed);

            GUILayout.Space(10);

            script.hostile = GUILayout.Toggle(script.hostile, "Hostile");
            if (script.hostile)
            {
                script.aggroDistance = EditorGUILayout.FloatField("Aggro Range", script.aggroDistance);
            }
            else
            {
                script.aggroDistance = 0;
            }

            GUILayout.Space(10);

            script.attackable = GUILayout.Toggle(script.attackable, "Attackable");
            if (script.attackable)
            {
                script.pursuitMaxDistance = EditorGUILayout.FloatField("Pursuit Distance", script.pursuitMaxDistance);
            }
            else
            {
                script.pursuitMaxDistance = 0;
            }

            GUILayout.Space(10);

            script.patrol = GUILayout.Toggle(script.patrol, "Patrol");
            if (script.patrol)
            {
                script.patrolRadius = EditorGUILayout.FloatField("Radius", script.patrolRadius);
                script.patrolPauseTime = EditorGUILayout.FloatField("Pause Time", script.patrolPauseTime);
                script.patrolPauseTimer = EditorGUILayout.FloatField("Pause Timer", script.patrolPauseTimer);
            }
            else
            {
                script.patrolRadius = 0;
                script.patrolPauseTime = 0;
                script.patrol = false;
            }
        }
    }


}


