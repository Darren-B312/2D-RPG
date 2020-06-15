using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private WeaponObject weapon = null; // Drag and drop from inspector.
    [SerializeField] private LayerMask layer;
    [SerializeField] public int MyInt { get; set; }

    private Transform attackPoint = null; // Center from which to measure range of weapon attack.

    void Start()
    {
        layer = LayerMask.GetMask("NPC");
        attackPoint = transform; // Set attack point to player position.
    }

    void Update()
    {
        if (weapon.AttackCooldownTimer <= 0) // If weapon is ready.
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                weapon.AttackCooldownTimer = weapon.AttackCooldown;
            }

        }
        else
        {
            weapon.AttackCooldownTimer -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        // play animation here

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weapon.AttackRange, layer);

        foreach (Collider2D h in hits)
        {
            NPCBehaviourController behaviourController = h.GetComponent<NPCBehaviourController>();

            if(behaviourController.Attackable) // If the NPC is flagged for combat.
            {
                Debug.Log($"HIT: {h.name}");
                behaviourController.Combat = true;
            }

        }

    }

    private void OnDrawGizmos()
    {
        if (attackPoint)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(attackPoint.position, weapon.AttackRange);
        }
    }
}
