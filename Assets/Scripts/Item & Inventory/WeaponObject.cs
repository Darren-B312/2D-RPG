using UnityEngine;

// Scriptable Object for creating items in-editor. Created items will be kept in an Items folder, and must be added to a game object or an inventory to be in-game.

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]
public class WeaponObject : ItemObject
{
    public float initialAttackCD;
    public float currentAttackCD;
    public float attackRange;

    public void Awake()
    {
        type = ItemType.Weapon;
    }
}
