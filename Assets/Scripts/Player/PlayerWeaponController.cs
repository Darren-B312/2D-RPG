using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private WeaponObject weapon = null; // Drag and drop from inspector.
    [SerializeField] private LayerMask combatLayer;
    
    private Transform attackPoint = null; // Center from which to measure range of weapon attack.

    void Start()
    {
        combatLayer = LayerMask.GetMask("Combat");
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

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weapon.AttackRange, combatLayer);

        foreach (Collider2D h in hits)
        {
            Debug.Log($"HIT: {h.name}");
            Destroy(h.gameObject);
        }

    }

    //private void OnDrawGizmos()
    //{
    //    if (attackPoint)
    //    {
    //        Gizmos.color = Color.blue;
    //        Gizmos.DrawWireSphere(attackPoint.position, weapon.AttackRange);
    //    }
    //}
}
