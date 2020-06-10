using UnityEngine;

// Scriptable Object for creating items in-editor. Created items will be kept in an Items folder, and must be added to a game object or an inventory to be in-game.

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]
public class WeaponObject : BaseItemScriptableObject
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackCooldownTimer;
    [SerializeField] private float attackRange;

    public float AttackCooldown
    {
        get => attackCooldown;
        set => attackCooldown = value;
    }
    public float AttackCooldownTimer
    {
        get => attackCooldownTimer;
        set => attackCooldownTimer = value;
    }
    public float AttackRange
    {
        get => attackRange;
        set => attackRange = value;
    }

    public void Awake()
    {
        type = ItemType.Weapon;
    }
}
